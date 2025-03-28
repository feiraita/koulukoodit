import json
file_name = "T1/words.json"

try:
    with open(file_name, "r", encoding='utf-8') as file:
        data = json.load(file)

except (FileNotFoundError, json.JSONDecodeError):
    def initialize(file_name, text):
        with open(file_name, 'w', encoding='utf-8') as file:
            file.write(text)
        with open(file_name, 'r', encoding='utf-8') as file:
            return json.load(file)
    
    sanakirja = '{"cat": "kissa", "snake": "käärme"}'
    data = initialize(file_name, sanakirja)

def add(word, sana):
    data[word] = sana
    with open(file_name, "w", encoding='utf-8') as file:
        json.dump(data, file)

while True:
    word = input("Give me a word: ").lower().strip()
    if word == "":
        print("Exiting program.")
        break
    if word not in data:
        sana = input(f"{word} not found. \nPlease give a definition or press enter to cancel: ").lower().strip()
        if sana != "":
            add(word, sana)
            print(f"{word} added to dictionary.")
    else:
        print(f"{word}: {data[word]}")