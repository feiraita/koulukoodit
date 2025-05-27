import numpy as np
from tensorflow.keras.preprocessing import image

classes=["airplane", "automobile", "bird", "cat", "deer", "dog", "frog", "horse", "ship", "truck"]

test_image = image.img_to_array(test_image)
test_image = test_image.reshape(1, 32, 32, 3)

result = model.precidict(test_image)

np.around(result)
n = (np.around(result)).argmax()
print(classes[n])