import json

file_name = "T1/words.json"
with open(file_name, "r", encoding='utf-8') as file:
    data = json.load(file)

def show():
    with open(file_name, "r", encoding='utf-8') as file:
        print(json.load(file))

def add(word, sana):
    data[word] = sana
    with open(file_name, "w", encoding='utf-8') as file:
        json.dump(data, file)

show()

while True:
    word = input(str("Give me a word: ")).lower().strip()
    if word == "":
        print("Exiting program.")
        break
    if word not in data:
        sana = input(f"{word} not found. \nPlease give a definition or press enter to cancel: ").lower().strip()
        if sana != "":
            add(word, sana)
            print(f"{word} added to dictionary.")
        continue

    print(f"{word}: {data[word]}")