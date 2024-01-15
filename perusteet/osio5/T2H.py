import os
import json
from datetime import datetime

DATABASE_FILE = "paivakirja.json"

paivakirja = {
    "01/01/1999" : [
        "hdhdhd"
    ], "02/01/1999" : [
        "ghghgh"
    ]
}

def MainMenu():
    os.system("cls")
    valinta = int(input("[1] Lisää päiväkirjaan kirjaus \n[2] Näytä päiväkirja \n>> "))
    if valinta == 1:
        Add(GetDate())

    elif valinta == 2:
        Show()

def Show():
    print("Päiväkirjan kirjaukset:")
    for kirjaus in paivakirja:
        print(kirjaus)
        kaikki_kirjaukset = paivakirja[kirjaus]
        if len(kaikki_kirjaukset) > 0:
            for kirjaus in kaikki_kirjaukset:
                print(f"- {kirjaus}")
        else: 
            print("/ Ei kirjauksia /")
    
    input("\nPaina enter jatkaaksesi...")

def GetDate():
    pvm = datetime.today().date().strftime("%d/%m/%Y")

    return pvm

def Add(pvm):
    if pvm in paivakirja:
        paivan_kirjaukset = paivakirja[pvm]

    else:
        paivan_kirjaukset = []

    print("Tämän päivän kirjaukset: ")
    if len(paivan_kirjaukset) > 0:
        for kirjaus in paivan_kirjaukset:
            print(f"- {kirjaus}")
    else:
        print("/ Ei kirjauksia /")

    print("\nKirjoita päiväkirjaan: ")
    while True:
        uusi_kirjaus = str(input("> "))
        if uusi_kirjaus == "":
            break

        paivan_kirjaukset.append(uusi_kirjaus)
        paivakirja.update( {pvm: paivan_kirjaukset} )
        SaveDb()


def SaveDb():
    with open("paivakirja.json", "w") as file:
        json.dump(paivakirja, file)

def ReadDb():
    try:
        with open("paivakirja.json", "r") as file:
            return json.load(file)
    except FileNotFoundError:
        return []

while True:
    paivakirja = ReadDb()
    MainMenu()