numero = int(input("Anna numero: "))

if numero > 5:
    print("Numero on suurempi kuin 5!")
    if numero < 10:
        print("Numero on pienempi kuin 10!")
    elif numero > 10:
        print("Numero on suurempi kuin 10!")
    elif numero == 10: #sdasd
        print("Numero on tasan 10!")

elif numero == 5:
    print("Numero on tasan 5!")
    
else:
    print("Numero on pienempi kuin 5!")