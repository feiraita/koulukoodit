""""
names = ["Bob", "Alice", "Charlie"]
names.append("David")

for name in names:
    print(f"Hello {name}!")

for name in sorted(names):
    print(f"Sorted {name}!")

for name in reversed(names):
    print(f"Reversed {name}!")
"""

numbers = [ 1, 2, 3, 4, 5, -1, -2, -3, -4, -5]
even_numbers = [number for number in numbers if number % 2 == 0]
print(even_numbers)

squared_numbers = [number ** 2 for number in numbers]
print(squared_numbers)