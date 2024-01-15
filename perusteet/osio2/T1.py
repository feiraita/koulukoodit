n1 = float(input("Anna ensimmäinen luku: "))
n2 = float(input("Anna toinen luku: "))
lasku = int(input("Haluatko lukujen (1) plus-, (2) vähennys-, (3) kerto- vai (4) jakolaskun? "))

if lasku == 1:
    print(f"Lukujen summa on {n1 + n2}")

elif lasku == 2:
    print(f"Lukujen vähennys on {n1 - n2}")

elif lasku == 3:
    print(f"Lukujen tulo on {n1 * n2}")

elif lasku == 4:
    print(f"Lukujen osamäärä on {n1 / n2}")

else:
    print("...")