## Implementing BFS, DFS and UCS algorithms

# represent the graphs as a dictionaries
graph = {'A': ['B', 'E', 'C'],
         'B': ['D'],
         'C': ['F', 'G'],
         'D': [],
         'E': ['D'],
         'F': [],
         'G': []
        }

weighted_graph = {'A': [('B', 2), ('E', 1), ('C', 2)],
                  'B': [('A', 2), ('D', 3), ('E', 3)],
                  'C': [('A', 2), ('E', 3), ('F', 3), ('G', 3)],
                  'D': [('B', 3), ('E', 1), ('F', 1)],
                  'E': [('A', 1), ('B', 3), ('C', 3), ('D', 1), ('F', 3) ],
                  'F': [('E', 3), ('C', 3), ('D', 1), ('G', 1)],
                  'G': [('C', 3), ('F', 1)]
                }

def bfs(graph, start):
    # keep track of all visited nodes
    path = []
    # keep track of nodes to be checked
    queue = [start]

    # keep looping until there are nodes still to be checked
    while queue:
        # pop shallowest node (first node) from queue
        node = queue.pop(0)

        #Check if node has been visited
        if node not in path:
            path.append(node)

        for neighbor in graph[node]:
            #Add unvisited children to the queue
            if neighbor not in path:
                queue.append(neighbor)

    return path

def dfs(graph, start):
    path = []
    stack = [start]

    while stack:
        node = stack.pop()
        if node not in path:
            path.append(node)
            stack.extend(reversed(graph[node]))
    return path

def path_cost(path):
    total = 0
    for (node, cost) in path:
        total += cost
    return total


def ucs(graph, start, goal):
    queue = [[(start, 0)]]
    visited = []

    while queue:
        queue.sort(key=path_cost)
        path = queue.pop(0)
        node = path[-1][0]

        if node in visited:
            continue

        visited.append(node)

        if node == goal:
            total = path_cost(path)
            return path, total
        
        else:
            #Get neighbors
            adjacent_nodes = weighted_graph.get(node, [])
            for (node2, cost) in adjacent_nodes:
                new_path = path.copy()
                new_path.append([node2, cost])
                queue.append(new_path)

print('BFS results: ', bfs(graph, 'A'), '\n')
print('DFS results: ', dfs(graph, 'A'), '\n')
              
path, total = ucs(weighted_graph, 'A', 'G')
print(f'UCS results: {path}')
print(f'Total cost: {total}', '\n')