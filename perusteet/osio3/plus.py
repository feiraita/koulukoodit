numerot = []
summa = 0

while True:
    syote = int(input("Anna numero, 0 lopettaa: "))
    if syote == 0:
        break
    summa += syote
    numerot.append(syote)
    
print(summa / len(numerot))


"""

keskiarvot = []

while kayttajaSyote != "":
    kayttajaSyote = input("Anna numero: ")
    try:
        tempNumero = int(kayttajaSyote)
        keskiarvo.append("tempNumero)

    expect:
    if kayttajaSyote != "":
        print("Syötä numeroita kiitos")
    
print("Keskiarvo on {sum(keskiarvo) / len(keskiarvo)})

"""