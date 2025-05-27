import cv2
import numpy as np

fig, axs = plt.subplots(1, 2, figsize=(10,5))

axs[0].imshow(img_cv2)
axs[1].imshow(img_mpl)

axs[0].set_title('CV2 Image')
axs[0].set_title('Matplotlib Image')
plt.show()
