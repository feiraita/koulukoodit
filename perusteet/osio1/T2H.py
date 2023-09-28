alku_raha = int(input("Kuinka paljon rahaa sinulla jää keskimäärin kuukaudessa elämiseen? "))
koulupv = int(input("Kuinka monta päivää kuukaudesta vietät kamppuksella? "))
kouluruoka = int(input("Kouluruoan hinta? "))
muu_raha = alku_raha - kouluruoka * koulupv

print(f"Sinulla menee kuukaudessa {kouluruoka * koulupv} euroa kouluruokaan.")
print(f"Sinulla jää siis {muu_raha} euroa muuhun puuhasteluun.")

menot = int((input("Paljonko sinulla menee muihin elämiskustannuksiin kouluruoan lisäksi? ")))
loppu_raha = muu_raha - menot
saastoon = loppu_raha * 0.2

print(f"Voisit laittaa säästöön {saastoon} euroa kuukaudessa, jolloin sinulla olisi neljän vuoden päästä {saastoon * 4} euroa")