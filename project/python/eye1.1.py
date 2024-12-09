import numpy as np
import pandas as pd
import torch
import cv2

#修改内容总结
#导入并配置MySQL连接器。

#在主循环中插入数据到MySQL数据库，替换原来的CSV文件保存方式。

#每次插入数据后，调用 conn.commit() 方法以确保数据被保存到数据库中。

#这样就实现了将数据保存到MySQL数据库中，并且可以支持多进程并发访问。如果有任何其他问题或需要进一步的帮助，请告诉我！
import mysql.connector

#import csv
from yolov5.models.common import DetectMultiBackend
from yolov5.utils.general import non_max_suppression, scale_boxes, xyxy2xywh
from yolov5.utils.augmentations import letterbox

# 配置MySQL连接
db_config = {
    'user': 'eye',
    'password': '123',
    'host': 'localhost',
    'database': 'eye_database'
}

# 创建MySQL连接和游标
conn = mysql.connector.connect(**db_config)
cursor = conn.cursor()

# 创建表（如果不存在）
cursor.execute("""
CREATE TABLE IF NOT EXISTS tanxy_output (
    frame INT,
    tanxy_x INT,
    tanxy_y INT,
    region VARCHAR(255)
)
""")



# 加载模型
model = DetectMultiBackend('eye_best .pt')

# 打开视频捕捉
cap = cv2.VideoCapture(0, cv2.CAP_DSHOW)  # 第一个摄像头
cap.set(6, cv2.VideoWriter.fourcc('M', 'J', 'P', 'G'))  # 设置图像的编码格式
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1280)  # 设置图像的宽
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 720)  # 设置视频输出
fourcc = cv2.VideoWriter_fourcc(*'mp4v')
out = cv2.VideoWriter('output.mp4', fourcc, 20.0, (640, 480))

# 定义处理图像的函数
def process_img(original_image, select=0):
    if original_image is None or original_image.size == 0:
        return None
    if select == 0:
        LH, LS, LV, HH, HS, HV = 0, 0, 63, 179, 255, 93  # 眼眶
    else:
        LH, LS, LV, HH, HS, HV = 0, 0, 0, 179, 255, 47  # 眼珠
    # 用颜色分割图像
    low_range = np.array([LH, LS, LV])
    high_range = np.array([HH, HS, HV])
    processed_img = cv2.cvtColor(original_image, cv2.COLOR_BGR2HSV)
    processed_img = cv2.inRange(processed_img, low_range, high_range)
    if select == 0:
        kernel = np.ones((5, 5), np.uint8)
        processed_img = cv2.dilate(processed_img, kernel, iterations=3)
    else:
        processed_img = cv2.erode(processed_img, None, iterations=2)  # iterations 值越高，腐蚀程度越高
    return processed_img

def tana(yk, yz):  # 输入眼眶和眼珠中心点
    L = (yk[0] - yz[0], yk[1] - yz[1])  # 得到眼眶和眼珠中心点x ， y 偏移量，即对边长度
    zx = L[0] / 5  # 获取x轴上对边长度除以眼球z轴长度，得到斜率m，即tan角度
    zy = L[1] / 5  # 获取y轴上对边长度除以眼球z轴长度，得到斜率m，即tan角度
    return (int(yk[0] + zx * 10), int(yk[1] + zy * 10))  # 根据斜率，返回一个z轴投影到相应位置的点

def resize_image(image, scale_percent):
    width = int(image.shape[1] * scale_percent / 100)
    height = int(image.shape[0] * scale_percent / 100)
    dim = (width, height)
    return cv2.resize(image, dim, interpolation=cv2.INTER_AREA)

# 定义区域边界
regions = {
    '1': {'x_min': 7, 'x_max': 23, 'y_min': 1, 'y_max': 2},         #区域1：右下
    '2': {'x_min': 11, 'x_max': 23, 'y_min': -8, 'y_max': 1},       #区域2：右上
    '3': {'x_min': 193, 'x_max': 207, 'y_min': -9, 'y_max': -7},    #区域3：中间
    '4': {'x_min': 207, 'x_max': 224, 'y_min': -9, 'y_max': -7},    #区域4：左上
    '5': {'x_min': 213, 'x_max': 220, 'y_min': 1, 'y_max': 3}       #区域5：左下
}



# 判断每条数据所属的区域
def get_region(tanxy):
    for region_name, bounds in regions.items():
        if bounds['x_min'] <= tanxy[0] <= bounds['x_max'] and bounds['y_min'] <= tanxy[1] <= bounds['y_max']:
            return region_name
    return '0'

# 打开CSV文件
#csv_file = open('tanxy_output.csv', mode='w', newline='')
#csv_writer = csv.writer(csv_file)
#csv_writer.writerow(['Frame', 'tanxy_x', 'tanxy_y', 'Region'])

frame_count = 0
while cap.isOpened():
    ret, frame = cap.read()
    if not ret:
        break
    frame_count += 1

    # 图像预处理
    stride, names = model.stride, model.names
    imgsz = [640, 640]
    im = letterbox(frame, imgsz[0], stride=stride, auto=True)[0]
    im = im.transpose((2, 0, 1))[::-1]
    im = np.ascontiguousarray(im)

    # 推断
    im = torch.from_numpy(im).to(model.device)
    im = im.half() if model.fp16 else im.float()
    im /= 255
    if len(im.shape) == 3:
        im = im[None]
    pred = model(im, augment=False, visualize=False)
    pred = non_max_suppression(pred, 0.25, 0.45, max_det=1000)

    # 处理检测结果
    for i, det in enumerate(pred):
        gn = torch.tensor(frame.shape)[[1, 0, 1, 0]]
        if len(det):
            det[:, :4] = scale_boxes(im.shape[2:], det[:, :4], frame.shape).round()

            # 只保留标签为“right eye”的检测结果
            det = [d for d in det if names[int(d[5])] == 'right eye' and d[4] > 0.5]

            if len(det) > 0:
                det = sorted(det, key=lambda x: x[4], reverse=True)[:1]

                # 创建掩码
                mask = np.zeros(frame.shape[:2], dtype=np.uint8)
                for *xyxy, conf, cls in det:
                    label = f'{names[int(cls)]} {conf:.2f}'
                    xywh = (xyxy2xywh(torch.tensor(xyxy).view(1, 4)) / gn).view(-1).tolist()
                    line = (names[int(cls)], *xywh, int(100 * float(conf)))

                    # 在掩码上绘制边界框
                    cv2.rectangle(mask, (int(xyxy[0]), int(xyxy[1])), (int(xyxy[2]), int(xyxy[3])), 255, -1)
                    
                    # 绘制边界框
                    #cv2.rectangle(frame, (int(xyxy[0]), int(xyxy[1])), (int(xyxy[2]), int(xyxy[3])), (0, 255, 0), 2)
                    cv2.putText(frame, label, (int(xyxy[0]), int(xyxy[1]) - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.3, (0, 255, 0), 2)
                
                # 将检测到的对象抠出并放大
                result = cv2.bitwise_and(frame, frame, mask=mask)
                x, y, w, h = int(det[0][0]), int(det[0][1]), int(det[0][2] - det[0][0]), int(det[0][3] - det[0][1])
                roi = result[y:y + h, x:x + w].copy()
                roi = resize_image(roi, scale_percent=500)

                # 对抠出的图像进行处理
                rows, cols, _ = roi.shape
                threshold = process_img(roi)

                contours, _ = cv2.findContours(threshold, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
                contours = sorted(contours, key=lambda x: cv2.contourArea(x), reverse=True) #按面积排序

                for cnt in contours:
                    (x1, y1, w1, h1) = cv2.boundingRect(cnt)
                    yk_xy = (x1 + int(w1 / 2), y1 + int(h1 / 2))#眼眶xy坐标

                    cv2.rectangle(roi, (x1, y1), (x1 + w1, y1 + h1), (255, 0, 0), 2)#画眼眶
                    cv2.line(roi, (x1 + int(w1 / 2), 0), (x1 + int(w1 / 2), rows), (0, 255, 0), 2) #画眼眶十字线x轴
                    cv2.line(roi, (0, y1 + int(h1 / 2)), (cols, y1 + int(h1 / 2)), (0, 255, 0), 2)  #画眼眶十字线y轴
                    break

                if 'y1' in locals() and 'x1' in locals():
                    eye_img = roi[y1:y1 + h1, x1:x1 + w1]
                    eye_img1 = eye_img.copy()
                    eye_img1 = process_img(eye_img1, select=1)

                    if eye_img1 is not None:
                        contours, _ = cv2.findContours(eye_img1, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
                        contours = sorted(contours, key=lambda x: cv2.contourArea(x), reverse=True)

                        for cnt in contours:
                            (x2, y2, w2, h2) = cv2.boundingRect(cnt)
                            yz_xy = (x1 + x2 + int(w2 / 2), y1 + y2 + int(h2 / 2))

                            cv2.rectangle(eye_img, (x2, y2), (x2 + w2, y2 + h2), (255, 0, 0), 2)
                            cv2.circle(eye_img, (x2 + int(w2 / 2), y2 + int(h2 / 2)), 10, (255, 255, 0), 2)

                            cv2.circle(roi, yz_xy, 10, (255, 255, 0), 2)
                            tanxy = tana(yz_xy, yk_xy)

                            cv2.line(roi, yk_xy, tanxy, (0, 255, 255), 2)
                            cv2.line(roi, yk_xy, yz_xy, (255, 0, 255), 2)

                            #以左下角为原点，即为眼眶左下角（0，0）时的坐标输出tanxy
                            yk_xy = (0 + int(w1 / 2), 0 + int(h1 / 2))#眼眶xy坐标
                            yz_xy = (0 + x2 + int(w2 / 2), 0 + y2 + int(h2 / 2))
                            
                            tanxy = tana(yz_xy, yk_xy)

                            # 打印并保存 tanxy 的输出数据
                            #print(f"Frame {frame_count}: tanxy = {tanxy}")
                            region = get_region(tanxy)
                            #csv_writer.writerow([frame_count, tanxy[0], tanxy[1], region])

                            # 插入数据到MySQL数据库 
                            cursor.execute( 
                                "INSERT INTO tanxy_output (frame, tanxy_x, tanxy_y, region) VALUES (%s, %s, %s, %s)", 
                                (frame_count, tanxy[0], tanxy[1], region)) 
                            conn.commit() 

                            break

                            


                            
                            

                            
                #cv2.imshow(f"eye_img", eye_img)
                cv2.imshow(f"gray_roi", roi)
                cv2.imshow(f"threshold", threshold)

    # 写入视频
    out.write(frame)

    # 显示视频
    cv2.imshow('frame', frame)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break


    key = cv2.waitKey(30)
    if key == 27:  # 按 ESC 键退出
        break


# 释放资源
cap.release()
out.release()
cv2.destroyAllWindows()
#csv_file.close()
# 在程序结束时关闭连接 
conn.close()