import cv2
import numpy as np

# 加载PNG图像
image_path = 'D:\yolov5\HSV\detected_object_frame_223.png'
image = cv2.imread(image_path)
if image is None:
    print(f"Error: Could not load image from {image_path}")
else:
    print("Image loaded successfully.")

kernel = cv2.getStructuringElement(cv2.MORPH_ELLIPSE, (6, 6))

def callback(object):
    pass

imgi = np.zeros((50, 500), np.uint8)
cv2.namedWindow('tj')
cv2.imshow("tj", imgi)

cv2.createTrackbar('LH', 'tj', 0, 179, callback)
cv2.createTrackbar('LS', 'tj', 65, 255, callback)
cv2.createTrackbar('LV', 'tj', 0, 255, callback)
cv2.createTrackbar('HH', 'tj', 179, 179, callback)
cv2.createTrackbar('HS', 'tj', 76, 255, callback)
cv2.createTrackbar('HV', 'tj', 67, 255, callback)

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

    cv2.destroyAllWindows()
