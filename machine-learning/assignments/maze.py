# -*- coding: utf-8 -*-
"""
This code is from https://medium.com/@nicholas.w.swift/easy-a-star-pathfinding-7e6689c7f7b2
"""
class Node():
    """
    A node class for A* Pathfinding
    """

    def __init__(self, parent=None, position=None,  direction=None):
        self.parent = parent
        self.position = position
        self.direction = direction
        
        self.g = 0
        self.h = 0
        self.f = 0

    #Vertailu
    def __eq__(self, other):
        return self.position == other.position and self.direction == other.direction

def getMoves(direction):
    moves = {
        0: [(-1, 0), (0, 1)],   #up
        1: [(1, 0), (0, -1)],   #down
        2: [(0, 1), (1, 0)],    #right
        3: [(0, -1), (-1, 0)]   #left
    }

    return moves.get(direction)

def astar(maze, start, end, start_direction=0):
    """
    Returns a list of tuples as a path from the given start 
    to the given end in the given maze
    """

    # Create start and end node
    start_node = Node(None, start, start_direction)
    start_node.g = start_node.h = start_node.f = 0
    end_node = Node(None, end)
    end_node.g = end_node.h = end_node.f = 0

    # Initialize both open and closed list
    # Nodes that found ending
    open_list = []
    # Nodes that have not found ending
    closed_list = []

    # Add the start node
    open_list.append(start_node)

    # Loop until you find the end
    while len(open_list) > 0:
        # Get the current node
        current_node = open_list[0]
        current_index = 0
        # Turn open_list into list with indexes
        for index, item in enumerate(open_list):
            # If better f value, we set it as current node
            if item.f < current_node.f:
                current_node = item
                current_index = index

        # Pop current off open list, add to closed list
        open_list.pop(current_index)
        closed_list.append(current_node)

        # Found the goal, because of direction we need to compare the positions specifically
        if current_node.position == end_node.position:
            # Array for the path
            path = []
            current = current_node
            # Traverse / Travel again the whole path
            while current is not None:
                # Add position (y, x) of current node to the array
                path.append(current.position)
                # Make current node the parrent node
                current = current.parent
            return path[::-1] # Return reversed path

        # Generate children
        children = []
        allowed = getMoves(current_node.direction)

        for new_position in allowed:
            # Get node position by combining the new x and y position
            node_position = (current_node.position[0] + new_position[0], current_node.position[1] + new_position[1])
        
            # Make sure within range, if not - skip
            if node_position[0] > (len(maze) - 1) or node_position[0] < 0 or node_position[1] > (len(maze[len(maze)-1]) -1) or node_position[1] < 0:
                continue

            # Make sure walkable terrain
            if maze[node_position[0]][node_position[1]] != 0:
                continue

            #(row, column)
            if new_position == (-1, 0): #up
                new_direction = 0
            elif new_position == (1, 0): #down
                new_direction = 1
            elif new_position == (0, 1): #right
                new_direction = 2
            elif new_position == (0, -1): #left
                new_direction = 3

            # Create new node that has current nodes position and its properties
            new_node = Node(current_node, node_position, new_direction)

            # Add to list
            children.append(new_node)

        # Loop through children
        for child in children:
            # If node exists somewhere within closed list - skip
            if len([closed_child for closed_child in closed_list if closed_child == child]) > 0:
                continue

            # Create the f, g, and h values
            # Give child + 1 g because its always 1 further away from start than previous one
            child.g = current_node.g + 1

            # Heuristic costs calculated here, this is using eucledian distance
            # Heuristic calculation based on what would be the fastest path
            child.h = (((child.position[0] - end_node.position[0]) ** 2) + 
                       ((child.position[1] - end_node.position[1]) ** 2)) 

            child.f = child.g + child.h

            # If child is in the open list or cost is higher - skip
            if len([open_node for open_node in open_list if child == open_node and child.f > open_node.f]) > 0:
                continue

            # Add the child to the yet_to_visit list
            open_list.append(child)

def main():
    # The maze we are actually looking for the solution
    maze = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 1, 0, 1, 0 ,1, 1, 1, 0, 1, 1, 1, 0],
            [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 1, 0, 1, 0 ,1, 1, 1, 1, 1, 0, 1, 0],
            [0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0],
            [0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0], # 5th row
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0],
            [1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0],
            [1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
            [1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0],
            [1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], # 10th row
            [1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1]] #12 wide

    start = (11, 10)
    end = (11, 2)

    path = astar(maze, start, end, start_direction=0)
    if path:
        print(path)
    else:
        print("No path found!")
        
'''
visualization
if path:
        print("Path found:", path)
        for step in path:
            maze[step[0]][step[1]] = "*"

        for row in maze:
            print(" ".join(str(cell) for cell in row))

    else:
        print("No path found!")
'''
    
if __name__ == '__main__':
    main()