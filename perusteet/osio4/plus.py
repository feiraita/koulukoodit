#Dict ja def harjoitus

import os
import json

DATABASE_FILE = "musiikit.json"

def MainMenu():
    os.system("cls")
    print("[1] Näytä artistit")
    print("[2] Lisää artisti")
    print("[3] Lisää kappaleita artisteille")
    print("[4] Poista artisti")
    valinta = input("> ")

    if valinta == "1":
        ShowArtists()

    elif valinta == "2":
        AddArtist()

    #Lisää kappaleita artisteille
    elif valinta == "3":
        AddSongs(ChooseArtist())

    #Poista artisti
    elif valinta == "4":
        DeleteArtist(ChooseArtist())

def ShowArtists():
    #os.system("cls")
    print("Kirjastossa olevat artistit:")
    for artist in musicLibrary:
        print(artist)
        songs = musicLibrary[artist]
        if len(songs) > 0:
            for song in songs:
                print(f"- {song}")
        else: 
            print("/ Ei kappaleita /")
    
    input("\nPaina enter jatkaaksesi...")

def AddArtist():
    #os.system("cls")
    nimi = str(input("Anna artistin nimi \n> "))
    musicLibrary.update( {nimi: []} ) #dictionary.update( {"Key" : "value"} )
    SaveDatabase()

def ChooseArtist():
    for index, artist in enumerate(musicLibrary):
        print(index + 1, " ", artist)
    valinta = input("> ")
    artists = list(musicLibrary)
    try:
        index = int(valinta) - 1
        artistName = artists[index]
        return artistName
    except:
        return ""

def AddSongs(artistName):
    artistSongs = musicLibrary[artistName]
    print("Nykyiset kappaleet:")
    if len(artistSongs) > 0:
        for song in artistSongs:
            print(f"- {song}")
    else: 
        print("/ Ei kappaleita /")

    print("\nAnna kappaleen nimi:")
    while True:
        newSong = str(input("> "))
        if newSong == "":
            break
        
        artistSongs.append(newSong)
        musicLibrary.update( {artistName: artistSongs} )
        SaveDatabase()

def DeleteArtist(artistName):
    musicLibrary.pop(artistName)
    SaveDatabase()

def SaveDatabase():
    musicLibraryJSON = json.dumps(musicLibrary)
    kirjoittaja = open("musiikit.json", "w") # w = write
    kirjoittaja.write(musicLibraryJSON)
    kirjoittaja.close()

def ReadDatabase():
    try:
        kirjoittaja = open("musiikit.json", "r")
        tiedot = kirjoittaja.read()
        kirjoittaja.close()
        return json.loads(tiedot)
    except:
        input("Kantatiedostoa ei löytynyt, paina enter jatkaaksesi...")
        return {}

#päätoiminnot
musicLibrary = {
    "Ressu Redford" : [
        "Särkynyt sydän", "Kuka on se oikea"
        ]
}

while True:
    MainMenu()