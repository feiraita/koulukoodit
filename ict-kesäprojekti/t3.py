import cv2
import numpy as np

img = cv2.imread('testi.jpg', 0)

cv2.imshow('Original image', img)
cv2.waitKey()
cv2.destroyAllWindows()

grey_image = cv2.cvtColor(img, cv2.COLOR_BAYER_BG2GRAY)
cv2.imshow('Grey image', grey_image)
cv2.waitKey()
cv2.destroyAllWindows()


Sharp_Kernel1 = np.array([[0, -1, 0], [-1, 5, -1], [0,-1,0]]) ## Kernel type 1
Sharpened_image = cv2.filter2D(grey_image, -1, Sharp_Kernel1)
cv2.imshow('Sharpened image', Sharpened_image)
cv2.waitKey()
cv2.destroyAllWindows()