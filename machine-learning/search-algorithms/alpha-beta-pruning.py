import math

def minimax(current_depth, node_index, is_max_turn, leaf_scores, target_depth):
    """
    Implements the core Minimax recursive algorithm.
    
    Parameters:
    current_depth (int): Current depth in the game tree.
    node_index (int): Index of the current node in the leaf_scores array.
    is_max_turn (bool): True if current turn is Maximizer, False if Minimizer.
    leaf_scores (list): Array containing the values of the leaf nodes.
    target_depth (int): Maximum depth of the game tree.
    """
    # Base Case: Target depth reached, return the leaf node value
    if current_depth == target_depth:
        return leaf_scores[node_index]

    # Maximizer's Turn: Choose the maximum possible value from children
    if is_max_turn:
        left_child = minimax(current_depth + 1, node_index * 2, False, leaf_scores, target_depth)
        right_child = minimax(current_depth + 1, node_index * 2 + 1, False, leaf_scores, target_depth)
        return max(left_child, right_child)

    # Minimizer's Turn: Choose the minimum possible value from children
    else:
        left_child = minimax(current_depth + 1, node_index * 2, True, leaf_scores, target_depth)
        right_child = minimax(current_depth + 1, node_index * 2 + 1, True, leaf_scores, target_depth)
        return min(left_child, right_child)


# --- Driver Code Code to Execute the Game Tree Example ---
if __name__ == "__main__":
    # Jos tietää vaikn pääte leaf arvot -> terminal node, eikä väliarvoja
    scores = [1, 4, 5, 7, 0, 1, -1, -2]
    
    # Calculate target depth using log base 2 of total leaves
    # log2(8) = 3 levels deep
    tree_depth = int(math.log2(len(scores)))

    print("Evaluating Game Tree...")
    print(f"Leaf nodes: {scores}")
    
    # Start the algorithm from depth 0, root index 0, and Maximizer's turn (True)
    optimal_value = minimax(
        current_depth=0, 
        node_index=0, 
        is_max_turn=True, 
        leaf_scores=scores, 
        target_depth=tree_depth
    )
    
    print(f"The optimal value guaranteed for the Maximizer is: {optimal_value}")