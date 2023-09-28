import random
import time

print("EHDOLLINEN SEIKKAILU")
print("--")
print("Istut kasinossa jo viidettä tuntia ja olet hävinnyt kaikki rahasi.\nPäätät pelata vielä yhden pelin, mutta tällä kertaa lyöt vetoa jostain muusta...")
print("Jos nyt heität nopalla ykkösen tai kutosen, niin voitat kaiken häviämäsi takaisin.")
noppa = random.randint(1, 6)
voitto = False

while True:
    time.sleep(1)
    print("Lyötkö vetoa..\n [1] Kotiavaimistasi, ja samalla kodistasi \n [2] Autostasi, joka odottaa kasinon edessä")
    vastaus = int(input(">> "))
    print("Heitetään noppaa..")
    time.sleep(0.5)
    print(noppa)

    if noppa == 1 or noppa == 6:
        print("Jee voitit!")
        voitto = True
        break
    else:
        print("Voi ei hävisit!")
        if vastaus == 1:
            print("Annat kotiavaimesi pois.")
        elif vastaus == 2:
            print("Luovutat auton avaimesi.")
        break
        
while voitto != True:
    time.sleep(1)
    print("Sinulla riittäisi vielä yhteen peliin. Haluatko pelata? [y / n]")
    jatketaanko = str(input(">> "))
    if jatketaanko == "y":
        jatketaanko = True
        print("Heitetään noppaa..")
        time.sleep(0.5)
        print(noppa)
        if noppa == 6:
            print("Jee voitit!!")
            voitto = True
            break
        else:
            if vastaus == 1:
                print("Voi ei hävisit autosi avaimet myös!")
            elif vastaus == 2:
                print("Voi ei hävisit kotiavaimesi myös!")
                break
    elif jatketaanko == "n":
        jatketaanko = False
        break
        
if voitto == True:
    time.sleep(1)
    print("Voitit jackpotin!")
    print("Mitä haluat tehdä nyt? \n[1] Lähdet kotiin juhlimaan \n[2] Jäät pelaamaan noppapeliä")
    vastaus = int(input(">> "))
    if vastaus == 1:
        print("Woooo")
    elif vastaus == 2:
        print("Noppas for life <3")

elif jatketaanko == False:
    print("Hyvä on. Sait ainakin pitää puolet omaisuudestasi.")
    
else:
    time.sleep(1)
    print("Hävisit koko omaisuutesi!")
    print("Mitä aiot tehdä nyt? \n[1] Alat itkemään \n[2] Hankit rahaa, että voit pelata noppapeliä")
    vastaus = int(input(">> "))
    if vastaus == 1:
        print(";_;")
    elif vastaus == 2:
        print("Must play noppa $_$")

print("--")
print("LOPPU")