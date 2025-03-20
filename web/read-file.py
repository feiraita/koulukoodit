def load_text_file(file_path):
    with open(file_path, 'r') as file:
        return file.read()
    
def save_text_file(file_path, text):
    with open(file_path, 'w') as file:
        file.write(text)

def main():
    example_text = 'Hello World! \nLine1\nLine2'
    save_text_file('example.txt', example_text)
    text = load_text_file('example.txt')
    print(text)

if __name__ == '__main__':
    main()