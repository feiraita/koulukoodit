import random
import time
import os

pisteet = 0
ai_pisteet = 0

kps = {
    1: "kivi",
    2: "paperi",
    3: "sakset"
}

def Game(vastaus):
    os.system("cls")
    global pisteet
    voitit = "Sait pisteen!"

    global ai_pisteet
    havisit = "AI sai pisteen!"

    ai_vastaus = random.choice(list(kps.keys()))
    print(f"Vastasit {kps[vastaus]}")
    print(f"AI vastasi {kps[ai_vastaus]}")

    #Samat vastaukset
    if ai_vastaus == vastaus:
        print("Tasapeli")

    #Kivi
    elif ai_vastaus == 1:
        if vastaus == 2:
            pisteet += 1
            print(voitit)
        else:
            ai_pisteet += 1
            print(havisit)

    #Paperi
    elif ai_vastaus == 2:
        if vastaus == 3:
            pisteet += 1
            print(voitit)
        else:
            ai_pisteet += 1
            print(havisit)

    #Sakset
    elif ai_vastaus == 3:
        if vastaus == 1:
            pisteet += 1
            print(voitit)
        else:
            ai_pisteet += 1
            print(havisit)

    time.sleep(1)

def Points():
    global pisteet
    global ai_pisteet
    tulos = ""

    print(f"AI:n pisteet: {ai_pisteet}")
    print(f"Sinun pisteet: {pisteet}")

    if pisteet > ai_pisteet:
        tulos = "Voitit  pelin! :-)"

    elif pisteet < ai_pisteet:
        tulos = "Hävisit! :("

    else:
        tulos = "Tasapeli!"

    print(tulos)
    time.sleep(2)

while True:
    print("\nValitse vastauksesi, 0 tulostaa tuloksen: ")
    vastaus = int(input("[1] Kivi \n[2] Paperi \n[3] Sakset \n>> "))

    if vastaus == 0:
        Points()
    else:
        Game(vastaus)