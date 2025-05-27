import cv2
import numpy as np

img = cv2.imread('testi.jpg', 0)
equ = cv2. equalizeHist(img)

res = np.hstack((img, equ))
cv2.imwrite('output.png', res)