lause = str(input("Anna tekstinpätkä: "))
lista = list(lause.lower())
merkki = max(set(lista), key = lista.count)

print(f"Eniten käytetty merkki oli: {merkki} \nja se esiintyi tekstissä {lista.count(merkki)} kertaa")