import tensorflow as tf
from tensorflow.keras import datasets, layers, models
import matplotlib as plt
from tensorflow.keras.datasets import cifar10

(ip_train, op_train), (ip_test, op_text) = cifar10.load_data()
print(ip_train.shape, ip_test.shape)

ip_train = ip_train.reshape(ip_train.shape[0], 32,32, 3)
ip_test = ip_test.reshape(ip_test.shape[0], 32, 32, 3)

model = models.Sequential()
model.add(layers.Conv2D(32, (3, 3), activation="relu", input_shape=(32, 32, 3)))
model.add(layers.MaxPooling2D((2, 2)))

model.add(layers.Conv2D(32, (3, 3), activation="relu"))
model.add(layers.MaxPooling2D((2, 2)))

model.add(layers.Conv2D(32, (3, 3), activation="relu"))
model.add(layers.Flatten())
model.add(layers.Dense(64, activation="relu"))
model.add(layers.Dense(10, activation="softmax"))

model.compile(optimizer ="Adam", loss = "sparse_categorical_cross")

plt.plot(history.history['accuracy'])
plt.title("Model accuracy")
plt.xlabel("epoch")
plt.legend(["Train"], loc="upper left")
plt.grid()
plt.show()

plt.plot(history.history["loss"])
plt.title("Model loss")
plt.ylabel("loss")
plt.xlabel("epoch")
plt.legend(["Train", "Validation"], loc="upper left")
plt.grid()
plt.show()