import cv2
import time

cap = cv2.VideoCapture(0,cv2.CAP_DSHOW)     #第一个摄像头
cap.set(6, cv2.VideoWriter.fourcc('M', 'J', 'P', 'G') ) #设置图像的编码格式 
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1280)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 720) #设置图像的宽
#cap.set(cv2.CAP_PROP_FPS, 60)
		

i = 0
fps = "0"
t1 = time.time()
print(cap.get(5))
print(cap.get(6))
while True:
    ret, frame = cap.read()
    i += 1
    if (time.time() - t1) > 1:
        fps = i / (time.time() - t1)
        fps = str(round(fps,2))
        i = 0
        t1 = time.time()
    cv2.putText(frame, "FPS:"+fps, (20, 20), 1, 1.5, (255, 255, 255), 2)

    cv2.imshow('frame', frame)
    if cv2.waitKey(1) & 0xFF == 27:
        break

cap.release()
cv2.destroyAllWindows() #作者：啥也不会的夏学长 https://www.bilibili.com/read/cv29875049/ 出处：bilibili