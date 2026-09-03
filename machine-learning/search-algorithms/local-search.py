import random
import numpy as np
import math


def f(x):
    #return -x**2 + 2*x + 3
    return -0.05 * x**2 + np.sin(2*x) + 10

space_min, space_max = -10, 10
max_iterations = 1000 #can be modified
step_size = 0.1 #can be modified

def hill_climb():
    # Random number between min and max
    current_x = random.uniform(space_min, space_max)
    print(f"Starting at: {current_x}")

    for i in range(max_iterations):
        # e.g. -9.95 - 0.1 = -10.05 -> out of range -> max() gives -10
        # left and right x
        lneighbour = max(space_min, current_x - step_size)
        rneighbour = max(space_min, current_x - step_size)

        best_x = current_x
        if f(lneighbour) > f(best_x):
            best_x = lneighbour
        if f(rneighbour) > f(best_x):
            best_x = rneighbour

        # Maximum -> stop
        if best_x == current_x:
            break

        # Move to the best neighbour and continue
        current_x = best_x

    return current_x, f(current_x)


def simulated_annealing():
    current_x = random.uniform(space_min, space_max)
    tvalue = 100 # High -> we are willing to accept worse solutions
    rate = 0.95

    for i in range(max_iterations):
        # Randomly move between current_x - 0.1 and current_x + 0.1
        neighbour = current_x + random.uniform(-step_size, step_size)
        # Ensure we are within search space
        neighbour = max(space_min, min(space_max, neighbour))

        # Is the neighbour better or worse?
        diff = f(neighbour) - f(current_x)

        # If neighbour is better -> always accept
        if diff > 0: current_x = neighbour

        else:
            # Low difference -> high probability of accepting
            # e.g. 9 - 10 = 1 and tvalue = 10 -> e^ -(1 / 10) = 90.5%
            probability = math.exp(diff / tvalue)

            # Higher probability -> higher chace of accepting
            if random.random() < probability:
                current_x = neighbour

        # Low tvalue -> low chance of accepting
        tvalue = tvalue + rate

    return current_x, f(current_x)

def genetic_algorithm():
    # current_x = random.uniform(space_min, space_max)
    candidates_size = 20
    mutation_rate = 0.1

    # Randomly generate 20 candidates in search space
    candidates = []
    for i in range(candidates_size):
        candidates.append(random.uniform(space_min, space_max))

    for iteration in range(max_iterations):
        # Sort the candidates according to f(x) -> highest value first
        candidates.sort(key=f, reverse=True)

        # Selection -> Keep best 10 as parents, discard 10
        parents = candidates[:candidates_size // 2]

        children = []
        # Keep creating children until we have 20 candidates
        while len(children) < candidates_size - len(parents):
            # Pick two different parents -> crossing a parent with itself just copies it
            p1, p2 = random.sample(parents, 2)

            # Crossover -> midpoint
            cross_x = (p1 + p2) / 2

            # Mutation -> small random change, if the random number is lower than mutation_rate
            if random.random() < mutation_rate:
                cross_x = cross_x + random.uniform(-step_size, step_size)

            # Ensure child is inside search space after mutation
            cross_x = max(space_min, min(space_max, cross_x))
            children.append(cross_x)

        # New generation with the parents + new children -> 10 + 10
        candidates = parents + children

    # After the loop finishes we sort one final time and return the best candidate
    candidates.sort(key=f, reverse=True)
    best_x = candidates[0]
    return best_x, f(best_x)

## Results
best_x, best_y = hill_climb()
print(f"Results of Hill Climbing: x = {best_x:.2f}, y = {best_y:.2f}")
best_x, best_y = simulated_annealing()
print(f"Results of Simulated Annealing: x = {best_x:.2f}, y = {best_y:.2f}")
best_x, best_y = genetic_algorithm()
print(f"Results of Genetics Algorithm: x = {best_x:.2f}, y = {best_y:.2f}")