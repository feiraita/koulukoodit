#Ei toimi kunnolla, 
#mutta generoi arvauksia ja looppi loppuu sitten kun 
#oikea numerosarja löytyy

#Tulee samoja arvauksia atm

import random
#Viikko 4.9.-10.9.2023
lotto = [3, 4, 6, 13, 16, 22, 35]
#Pienempi lottosarja testailuun
lotto2 = [1, 2, 3]
yritykset = 0

while True:
    arvatut = set()
    arvaus = list(range(1, 4))
    random.shuffle(arvaus)
    yritykset += 1

    if tuple(arvaus) in arvatut:
        print("yritit sitä jo")
        break

    arvatut.add(tuple(arvaus))

    if arvaus == lotto2:
        print(f"Voitit! Oikea lukusarja oli {arvaus}.")
        if yritykset == 1:
            print("Sait arvattua ensimmäisellä yrityksellä.")
            break
        print(f"Sinulla meni {yritykset} yritystä.")
        break
    
    print(arvaus)

"""
 while True:
    arvaus = list(range(1, 4))
    random.shuffle(arvaus)
    yritykset += 1

    if arvaus == lotto2:
        print(f"Voitit! Oikea lukusarja oli {arvaus}.")
        if yritykset == 1:
            print("Sait arvattua ensimmäisellä yrityksellä.")
            break
        print(f"Sinulla meni {yritykset} yritystä.")
        break
 
    print(arvaus)
"""