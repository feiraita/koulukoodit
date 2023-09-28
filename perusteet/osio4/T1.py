import random

def LuoKayttajatunnus(enimi:str, snimi:str):
    numerot = str(random.randrange(1, 999)).zfill(3)
    ktunnus = enimi[:3].lower() + snimi[:3].lower() + numerot

    print(ktunnus)

LuoKayttajatunnus("Matti", "Mallikas")