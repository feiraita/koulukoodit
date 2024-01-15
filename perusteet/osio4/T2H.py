import random

lista = []
errors = []

def Viantarkastus(enimi, snimi):
    if len(enimi.strip()) == 0 or len(snimi.strip()) == 0:
        errors.append("Et voi palauttaa tyhjää kenttää!")
    if not enimi.isalpha() or not snimi.isalpha():
        errors.append("Et voi syöttää numeroita tai erikoismerkkejä!")

def LuoKayttajatunnus(enimi, snimi):
    numerot = str(random.randrange(1, 999)).zfill(3)
    ktunnus = enimi[:3].lower() + snimi[:3].lower() + numerot
    lista.append(f"Nimi: {enimi.capitalize()} {snimi.capitalize()}, Käyttäjätunnus: {ktunnus}")

    print(f"Käyttäjätunnuksesi on {ktunnus}")

while True:
    tapahtuma = int(input("[1] Luo käyttäjätunnus, [2] Listaa kaikki käyttäjätunnukset [3] Lopeta ohjelma\n>> "))
    if tapahtuma == 1:
        enimi = str(input("Etunimi: "))
        snimi = str(input("Sukunimi: "))
        Viantarkastus(enimi, snimi)

        if len(errors) > 0:
            print(*errors, sep="\n")
            errors.clear()
        else:
            LuoKayttajatunnus(enimi, snimi)

    elif tapahtuma == 2:
        print(*lista, sep="\n")

    elif tapahtuma == 3:
        break