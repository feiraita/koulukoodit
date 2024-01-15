musta = '⚫'
valkoinen = '⚪'

def prosentti(osuus, koko):
    if koko == 0:
        return 0
    prosentti = (osuus / koko)
    return prosentti

def visual(pilkku):
    pilkku = int(pilkku * 10)
    visualisointi = musta * pilkku + valkoinen * (10 - pilkku)
    return visualisointi

while True:
    luku1 = int(input("Anna ensimmäinen luku: "))
    luku2 = int(input("Anna toinen luku: "))

    if luku1 > luku2:
        print("Ensimmäisen luvun pitää olla pienempi kuin toisen luvun")
    else:
        break
prosenttiosuus = prosentti(luku1, luku2) * 100

print(f"Luku {luku1} on {prosenttiosuus:.2f}% luvusta {luku2}")
print(visual(prosentti(luku1,luku2)))