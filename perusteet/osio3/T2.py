#Ostoslista
ostoslista = []

while True:
    tuote = str(input("Lisää tuote: "))
    if tuote == "valmis":
        break

    ostoslista.append(tuote)

sorted_ostoslista = sorted(ostoslista)

print("Ostoslistassasi on ")
print(*sorted_ostoslista, sep=", ")