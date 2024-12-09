import cv2
import numpy as np
import sys

# 检查是否传递了临时文件路径参数
if len(sys.argv) != 2:
    print("Usage: python hsv2.py <temp_file_path>")
    sys.exit(1)
temp_file_path = sys.argv[1]

# 加载PNG图像
image_path = 'test.png'  # 请替换为你的图像路径
image = cv2.imread(image_path)
if image is None:
    print(f"Error: Could not load image from {image_path}")
    sys.exit(1)
else:
    print("Image loaded successfully.")


# 回调函数，当滑动条改变时调用
def callback(_):
    LH, LS, LV, HH, HS, HV = [cv2.getTrackbarPos(t, 'tj') for t in ('LH', 'LS', 'LV', 'HH', 'HS', 'HV')]
    with open(temp_file_path, 'w') as f:
        f.write(f"{LH},{LS},{LV},{HH},{HS},{HV}\n")
    print(f"Parameters saved to {temp_file_path}: {LH},{LS},{LV},{HH},{HS},{HV}")


# 设置窗口和滑动条
cv2.namedWindow('tj')
cv2.createTrackbar('LH', 'tj', 0, 179, callback)
cv2.createTrackbar('LS', 'tj', 65, 255, callback)
cv2.createTrackbar('LV', 'tj', 0, 255, callback)
cv2.createTrackbar('HH', 'tj', 179, 179, callback)
cv2.createTrackbar('HS', 'tj', 76, 255, callback)
cv2.createTrackbar('HV', 'tj', 67, 255, callback)

callback("")  # 初始化并保存默认值


# 处理图像的函数
def process_img(original_image):
    LH = cv2.getTrackbarPos('LH', 'tj')
    LS = cv2.getTrackbarPos('LS', 'tj')
    LV = cv2.getTrackbarPos('LV', 'tj')
    HH = cv2.getTrackbarPos('HH', 'tj')
    HS = cv2.getTrackbarPos('HS', 'tj')
    HV = cv2.getTrackbarPos('HV', 'tj')

    low_range = np.array([LH, LS, LV])
    high_range = np.array([HH, HS, HV])
    processed_img = cv2.cvtColor(original_image, cv2.COLOR_BGR2HSV)
    thresholded_img = cv2.inRange(processed_img, low_range, high_range)
    return thresholded_img


if image is not None:
    while True:
        mask = process_img(image)
        res = cv2.bitwise_and(image, image, mask=mask)

        cv2.imshow("img", image[:, :, ::-1])  # 显示原始图像
        cv2.imshow("res", res[:, :, ::-1])  # 显示处理后的图像

        key = cv2.waitKey(30)
        if key == 27:  # 按 ESC 键退出
            break
        elif key == ord('q'):  # 按 'q' 键保存参数并退出
            callback("")
            break

    cv2.destroyAllWindows()