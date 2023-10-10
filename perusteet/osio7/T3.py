#Anagrammi
mjono_a = str(input("Anna 1. merkkijono: "))
mjono_b = str(input("Anna 2. merkkijono: "))

if sorted(mjono_a) == sorted(mjono_b):
    print("Sanat ovat anagrammeja.")

else:
    print("Sanat eivät ole anagrammeja.")