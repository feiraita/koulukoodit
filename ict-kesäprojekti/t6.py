import cv2 as cv
from matplotlib import pyplot as plt

img = cv.imread('testi.jpg', cv.IMREAD_GRAYSCALE)
ret, thresh_image1 = cv.threshold(img, 132, 255, cv.THRESH_BINARY)
ret, thresh_image2 = cv.threshold(img, 132, 255, cv.THRESH_BINARY)
ret, thresh_image3 = cv.threshold(img, 132, 255, cv.THRESH_BINARY)
ret, thresh_image4 = cv.threshold(img, 132, 255, cv.THRESH_BINARY)
ret, thresh_image5 = cv.threshold(img, 132, 255, cv.THRESH_BINARY)

titles = ["input image", "BINARY", "BINARY_INV", "TRUNC", "TOZERO", "TOZERO_INV"]
threshold_images = [img, thresh_image1, thresh_image2, thresh_image3, thresh_image4, thresh_image5]

for i in range(6):
    plt. subplot(1, 6, i+1), plt.imshow(threshold_images[i], "gray", vmin=0, vmax=255)
    plt.title(titles[i])
    plt.xticks([]), plt.yticks([])