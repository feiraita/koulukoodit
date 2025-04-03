import os
import requests
import urllib.request
from bs4 import BeautifulSoup
import re

dangerous_words = ['terrorism', 'murder', 'kill', 'terror', 'terrorist', 'terrorists', 'bomb']
def dangerous_count(text):
    words_pattern = r'\b(?:' + '|'.join(re.escape(word) for word in dangerous_words) + r')\b'
    words_matches = re.findall(words_pattern, text, re.IGNORECASE)

    count = len(words_matches)
    print(f"Number of dangerous words: {count}")
    return count

def check(url):
    try:
        response = requests.get(url)
        content_type = response.headers.get('Content-Type', '')
        return content_type
    except requests.exceptions.RequestException as e:
        print(f"Error opening URL: {e}")
        return None

def save_image(url, save_path):
    try:
        urllib.request.urlretrieve(url, save_path)
        print(f"Image saved to: {save_path}")
    except Exception as e:
        print(f"Error saving the image: {e}")

def save_html(content, page_path, is_binary=False):
    try:
        mode = "wb" if is_binary else "w"
        with open(page_path, mode, encoding=None if is_binary else 'utf-8') as page_file:
            page_file.write(content)
            print(f"Page saved to: {page_path}")
    except Exception as e:
        print(f"Error saving page: {e}")

def extract(html_content):
    soup = BeautifulSoup(html_content, "html.parser")
    return soup.get_text(separator=" ", strip=True)

while True:
    path = "T2/saved/"
    url = input("Give me a valid URL to download, or press enter to cancel: ").strip()
    if not url:
        print("Exiting program.")
        break

    content_type = check(url)
    if not content_type:
        print("You gave an invalid URL.")
        continue

    if "image" in content_type.lower():
        image = input("Name and save the file, or press enter to cancel: ").strip()
        if not image: continue    
        
        image_path = os.path.join(path, image)
        save_image(url, image_path)
    
    elif "text/html" in content_type.lower():
        try:
            response = requests.get(url)
            html_content = response.text
            text = extract(html_content)
            dangerous_count(text)

            html = input("Name and save the file, or press enter to cancel: ").strip()
            if not html: continue

            html_path = os.path.join(path, html)
            save_html(text, html_path)

        except Exception as e:
            print(f"Error: {e}")