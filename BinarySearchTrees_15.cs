using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics.Metrics;
using Microsoft.VisualBasic;
using System.Net;
using System.ComponentModel.DataAnnotations;
namespace BinarySearchTrees
{
    public class PopulateNextRightPointersOfTree_M_1
    {
        /*
            To populate the next right pointers in each node of a binary tree, we need to connect each node to its right neighbor at the same level.
         This problem can be efficiently solved using level order traversal, where we connect nodes at each level.

            ### Approach

            1. **Level Order Traversal Using a Queue**:
               - Use a queue to perform a level order traversal (BFS) of the tree.
               - At each level, connect each node's `next` pointer to the next node in the queue.
               - Ensure the last node in each level points to `null`.


            ### Explanation

            1. ** TreeNode Class**:
               - Represents a node in the binary tree with `val`, `left`, `right`, and `next` pointers.

            2. ** Connect Method**:
               - Initializes a queue and starts from the root node.
               - Performs a level order traversal using the queue.
               - For each level, connects each node's `next` pointer to the next node in the queue.
               - Ensures the last node at each level points to `null`.

            3. ** Main Method**:
               - Demonstrates the usage of the `Connect` method by creating a sample tree and populating the next right pointers.
               - Calls the `PrintNextPointers` method to verify the connections.

            4. **PrintNextPointers Method**:
               - Prints the value of each node followed by the value of its `next` pointer to verify the connections.

            ### Complexity

            - **Time Complexity**:
              - The algorithm visits each node once, resulting in a time complexity of (O(N)), where (N) is the number of nodes in the tree.

            - **Space Complexity**:
              - The space complexity is (O(N)) in the worst case due to the queue used for level order traversal.
            In a balanced tree, the space complexity is (O(W)), where (W) is the maximum width of the tree.

            This solution efficiently populates the next right pointers for each node in a binary tree using a level order traversal approach with a queue.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left, right, next;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null, TreeNode next = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                this.next = next;
            }
        }


        public void Connect(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                TreeNode prev = null;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();

                    if (prev != null)
                    {
                        prev.next = current;
                    }
                    prev = current;

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }

                // Ensure the last node in this level points to null
                if (prev != null)
                {
                    prev.next = null;
                }
            }
        }

        public static void PopulateNextRightPointersOfTreeDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.right = new TreeNode(7);

            PopulateNextRightPointersOfTree_M_1 populator = new PopulateNextRightPointersOfTree_M_1();
            populator.Connect(root);

            // Print next pointers for each node
            PrintNextPointers(root);
        }

        private static void PrintNextPointers(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();
                    Console.Write(current.val + "->");
                    if (current.next != null)
                    {
                        Console.Write(current.next.val + " ");
                    }
                    else
                    {
                        Console.Write("null ");
                    }

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
                Console.WriteLine();
            }
        }
    }

    public class SearchGivenKeyInBST_E_2
    {
        /*
        To search for a given key in a Binary Search Tree(BST), we can leverage the properties of the BST, where for any node:
        - All nodes in the left subtree have values less than the node's value.
        - All nodes in the right subtree have values greater than the node's value.

        This allows us to perform the search operation efficiently by comparing the key with the current node's value and deciding whether to go left or right.

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** Search Method**:
             - Takes the root of the BST and the key to be searched as input.
             - If the root is null or the root's value is equal to the key, return the root.
             - If the key is greater than the root's value, recursively search the right subtree.
             - If the key is smaller than the root's value, recursively search the left subtree.
           - ** InorderTraversal Method**:
             - Prints the BST in an inorder manner(left-root-right).
           - ** Insert Method**:
             - Inserts a new key into the BST while maintaining its properties.
           - ** Main Method**:
             - Demonstrates the creation of a BST, insertion of nodes, inorder traversal, and searching for a given key.

        ### Complexity

        - ** Time Complexity**:
          - The time complexity of the search operation in a BST is (O(h)), where (h) is the height of the tree.In the worst case, 
        the height of the tree can be (O(N)) for a skewed tree, making the time complexity (O(N)). 
        However, for a balanced BST, the time complexity is (O(log N)).

        - ** Space Complexity**:
          - The space complexity of the search operation is (O(h)) due to the recursive call stack.
        In the worst case, this can be (O(N)) for a skewed tree, but it is (O(log N)) for a balanced tree.

        This implementation efficiently searches for a given key in a BST while demonstrating the basic operations of insertion and traversal.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        // Method to search for a given key in the BST
        public TreeNode Search(TreeNode root, int key)
        {
            // Base case: root is null or key is present at root
            if (root == null || root.val == key)
            {
                return root;
            }

            // Key is greater than root's key
            if (root.val < key)
            {
                return Search(root.right, key);
            }

            // Key is smaller than root's key
            return Search(root.left, key);
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        // Method to insert a new key in BST
        public TreeNode Insert(TreeNode root, int key)
        {
            if (root == null)
            {
                return new TreeNode(key);
            }

            if (key < root.val)
            {
                root.left = Insert(root.left, key);
            }
            else if (key > root.val)
            {
                root.right = Insert(root.right, key);
            }

            return root;
        }

        public static void SearchGivenKeyInBSTDriver()
        {
            SearchGivenKeyInBST_E_2 bst = new SearchGivenKeyInBST_E_2();
            TreeNode root = null;

            // Insert nodes into the BST
            root = bst.Insert(root, 50);
            root = bst.Insert(root, 30);
            root = bst.Insert(root, 20);
            root = bst.Insert(root, 40);
            root = bst.Insert(root, 70);
            root = bst.Insert(root, 60);
            root = bst.Insert(root, 80);

            // Print the BST (Inorder Traversal)
            Console.WriteLine("Inorder traversal of the BST:");
            bst.InorderTraversal(root);
            Console.WriteLine();

            // Search for a given key in the BST
            int keyToSearch = 40;
            Console.WriteLine($"keyToSearch :  {keyToSearch}");
            TreeNode result = bst.Search(root, keyToSearch);

            if (result != null)
            {
                Console.WriteLine($"Key {keyToSearch} found in the BST.");
            }
            else
            {
                Console.WriteLine($"Key {keyToSearch} not found in the BST.");
            }
        }
    }

    public class ConstructBSTFromGivenKeys_H_3
    {
        /*
        Constructing a Binary Search Tree(BST) from a given list of keys involves inserting each key into the BST one by one while maintaining the properties of the BST.
        Here's a detailed explanation and implementation in C#.

        ### Steps to Construct a BST from Given Keys

        1. * *Initialize the BST**:
           -Start with an empty BST.


        2. * *Insert Each Key**:
           -For each key in the given list, insert it into the BST using the BST insert operation.

        ### BST Insert Operation

        The insert operation for a BST follows these steps:
        -If the tree is empty, the new key becomes the root.
        - Otherwise, compare the key with the root:
          -If the key is less than the root, insert it into the left subtree.
          - If the key is greater than the root, insert it into the right subtree.

        ### Explanation

        1. * *TreeNode Class * *:
           -Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. * *BinarySearchTree Class * *:
           -**Insert Method * *:
             -Takes the root of the BST and the key to be inserted as input.
             - If the root is null, creates a new node with the key and returns it.
             - If the key is less than the root's value, recursively inserts the key into the left subtree.
             - If the key is greater than the root's value, recursively inserts the key into the right subtree.
           - **ConstructBST Method * *:
             -Takes an array of keys as input.
             - Initializes the root as null and iterates through each key, inserting it into the BST using the `Insert` method.
             - Returns the root of the constructed BST.
           -**InorderTraversal Method * *:
             -Prints the BST in an inorder manner(left - root - right).
           - **Main Method * *:
             -Demonstrates the construction of a BST from a given list of keys, and performs an inorder traversal to print the BST.

        ### Complexity

        - **Time Complexity * *:
          -The time complexity for inserting each key into the BST is (O(h)), where (h) is the height of the tree.In the worst case,
        the height of the tree can be (O(N)) for a skewed tree, making the overall time complexity (O(N ^ 2)).
        For a balanced BST, the time complexity is (O(N log N)).

        -**Space Complexity * *:
          -The space complexity is (O(h)) due to the recursive call stack. In the worst case, this can be (O(N)) for a skewed tree, but it is (O(log N)) for a balanced tree.

        This implementation provides a clear and efficient way to construct a BST from a given list of keys, with helper methods to insert nodes and print the tree in an inorder manner.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        // Method to insert a new key in BST
        public TreeNode Insert(TreeNode root, int key)
        {
            if (root == null)
            {
                return new TreeNode(key);
            }

            if (key < root.val)
            {
                root.left = Insert(root.left, key);
            }
            else if (key > root.val)
            {
                root.right = Insert(root.right, key);
            }

            return root;
        }

        // Method to construct a BST from a given list of keys
        public TreeNode ConstructBST(int[] keys)
        {
            TreeNode root = null;
            foreach (int key in keys)
            {
                root = Insert(root, key);
            }
            return root;
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        public static void ConstructBSTFromGivenKeysDriver()
        {
            ConstructBSTFromGivenKeys_H_3 bst = new ConstructBSTFromGivenKeys_H_3();
            int[] keys = { 50, 30, 20, 40, 70, 60, 80 };
            Console.WriteLine($"Given Keys : {string.Join(", ", keys)}");

            TreeNode root = bst.ConstructBST(keys);

            // Print the BST (Inorder Traversal)
            Console.WriteLine("Inorder traversal of the constructed BST:");
            bst.InorderTraversal(root);
            Console.WriteLine();
        }
    }

    public class ConstructBSTFromPreorderTraversal_M_4
    {
        /*
        Constructing a Binary Search Tree(BST) from a preorder traversal involves inserting elements in the order they appear in the traversal while maintaining the BST properties.
        Here's an efficient way to achieve this with a single pass using bounds to control the insertion.

        ### Steps to Construct a BST from Preorder Traversal

        1. **Use Index Tracking**:
           - Maintain an index to track the current element in the preorder array.
   
        2. **Use Bounds**:
           - Use upper and lower bounds to ensure the correct placement of nodes in the BST.
   
        3. **Recursive Insertion**:
           - Recursively insert nodes by checking the current value against the bounds.

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** ConstructBSTFromPreorder Method**:
             - Initializes the recursive construction with the entire range of valid BST values(from `int.MinValue` to `int.MaxValue`).
           - ** ConstructBSTFromPreorder Helper Method**:
             - Recursively constructs the BST from the preorder traversal array.
             - Checks if the current value is within the bounds defined by `lower` and `upper`.
             - If within bounds, it creates a new node with the current value, increments the index, and recursively constructs the left and right subtrees with updated bounds.
           - ** InorderTraversal Method**:
             - Prints the BST in an inorder manner(left-root-right).
           - ** Main Method**:
             - Demonstrates the construction of a BST from a given preorder traversal array, and performs an inorder traversal to print the BST.

        ### Complexity

        - **Time Complexity**:
          - The time complexity is (O(N)), where(N) is the number of nodes in the BST.Each node is processed exactly once.
  
        - **Space Complexity**:
          - The space complexity is (O(N)) due to the recursion stack.In the worst case, the height of the tree can be(O(N)) for a skewed tree.

        This implementation provides an efficient way to construct a BST from a preorder traversal using a single pass through the input array and bounds to control the insertion of nodes.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private int index = 0;

        // Method to construct a BST from preorder traversal
        public TreeNode ConstructBSTFromPreorder(int[] preorder)
        {
            return ConstructBSTFromPreorder(preorder, int.MinValue, int.MaxValue);
        }

        private TreeNode ConstructBSTFromPreorder(int[] preorder, int lower, int upper)
        {
            if (index == preorder.Length)
            {
                return null;
            }

            int val = preorder[index];
            if (val < lower || val > upper)
            {
                return null;
            }

            index++;
            TreeNode root = new TreeNode(val);
            root.left = ConstructBSTFromPreorder(preorder, lower, val);
            root.right = ConstructBSTFromPreorder(preorder, val, upper);
            return root;
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        public static void ConstructBSTFromPreorderTraversalDriver()
        {
            ConstructBSTFromPreorderTraversal_M_4 bst = new ConstructBSTFromPreorderTraversal_M_4();
            int[] preorder = { 8, 5, 1, 7, 10, 12 };
            Console.WriteLine($"Given preorder : {string.Join(", ", preorder)}");

            TreeNode root = bst.ConstructBSTFromPreorder(preorder);

            // Print the BST (Inorder Traversal)
            Console.WriteLine("Inorder traversal of the constructed BST:");
            bst.InorderTraversal(root);
            Console.WriteLine();
        }
    }

    public class CheckIfBInaryTreeIsBST_M_5
    {
        /*
        To check if a binary tree is a binary search tree(BST), we need to verify that the tree satisfies the BST properties:

        1. The left subtree of a node contains only nodes with keys less than the node's key.
        2. The right subtree of a node contains only nodes with keys greater than the node's key.
        3. Both the left and right subtrees must also be binary search trees.

        An efficient way to perform this check is to use the concept of valid ranges for each node. Each node should lie within a specific range of values, and we can use recursion to enforce these constraints.

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary tree with `val`, `left`, and `right` properties.

        2. ** BinaryTree Class**:
           - ** IsBSTHelper Method**:
             - Recursively checks if the tree satisfies the BST properties.
             - Takes the current node, the lower bound, and the upper bound as parameters.
             - If the current node's value is less than or equal to the lower bound or greater than or equal to the upper bound, the tree is not a BST.
             - Recursively checks the left and right subtrees with updated bounds.
           - **IsBST Method**:
             - Starts the recursive check from the root with no bounds initially.
           - **InorderTraversal Method**:
             - Prints the tree in an inorder manner (left-root-right).
           - ** Main Method**:
             - Demonstrates the check for a sample tree and prints whether the tree is a BST.

        ### Complexity

        - **Time Complexity**:
          - The time complexity is (O(N)), where(N) is the number of nodes in the tree.Each node is visited once.
  
        - **Space Complexity**:
          - The space complexity is (O(H)), where(H) is the height of the tree due to the recursion stack.In the worst case (for a skewed tree), this can be (O(N)).

        This implementation provides an efficient way to check if a binary tree is a BST by using recursion and maintaining valid ranges for each node.
        */
        public class TreeNode
        { 

            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        // Helper method to check if the tree is a BST
        private bool IsBSTHelper(TreeNode node, int? lower, int? upper)
        {
            if (node == null)
            {
                return true;
            }

            if ((lower.HasValue && node.val <= lower.Value) || (upper.HasValue && node.val >= upper.Value))
            {
                return false;
            }

            if (!IsBSTHelper(node.left, lower, node.val) || !IsBSTHelper(node.right, node.val, upper))
            {
                return false;
            }

            return true;
        }

        // Method to check if the tree is a BST
        public bool IsBST(TreeNode root)
        {
            return IsBSTHelper(root, null, null);
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        public static void CheckIfBInaryTreeIsBSTDriver()
        {
            CheckIfBInaryTreeIsBST_M_5 bt = new CheckIfBInaryTreeIsBST_M_5();

            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(5);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);

            Console.WriteLine("Inorder traversal of the tree:");
            bt.InorderTraversal(root);
            Console.WriteLine();

            bool isBST = bt.IsBST(root);
            Console.WriteLine($"The tree is {(isBST ? "" : "not ")}a BST.");
        }
    }

    public class FindLCAof2NodesBST_M_6
    {
        /*
        Finding the Lowest Common Ancestor(LCA) of two nodes in a Binary Search Tree(BST) is a common problem.
        The LCA of two nodes (p ) and (q ) in a BST is the lowest(i.e., deepest) node that has both (p ) and (q )
        as descendants(where we allow a node to be a descendant of itself).

        In a BST, we can leverage the properties of the tree to find the LCA efficiently:

        1. If both nodes are smaller than the current node, the LCA must be in the left subtree.
        2. If both nodes are larger than the current node, the LCA must be in the right subtree.
        3. If one node is smaller and the other is larger(or one is equal to the current node), the current node is the LCA.

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** LowestCommonAncestor Method**:
             - Takes the root of the BST and two nodes (p ) and (q ) as input.
             - Uses a loop to traverse the tree.
             - If both (p ) and (q ) are less than the current node's value, move to the left subtree.
             - If both (p ) and (q ) are greater than the current node's value, move to the right subtree.
             - If neither of the above conditions is true, the current node is the LCA.
           - **InorderTraversal Method**:
             - Prints the BST in an inorder manner (left-root-right).
           - ** Main Method**:
             - Demonstrates the finding of the LCA for a sample BST.

        ### Complexity

        - ** Time Complexity**:
          - The time complexity is (O(H)), where (H) is the height of the tree.In the worst case (for a skewed tree),
        this can be (O(N)), where (N) is the number of nodes.
  
        - **Space Complexity**:
          - The space complexity is (O(1)) for the iterative solution as it does not use additional space other than a few variables.

        This implementation provides an efficient way to find the LCA of two nodes in a BST by leveraging the properties of the tree.
        The iterative approach ensures minimal space usage.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        // Method to find the Lowest Common Ancestor (LCA) of two nodes in a BST
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                if (p.val < root.val && q.val < root.val)
                {
                    // Both nodes are in the left subtree
                    root = root.left;
                }
                else if (p.val > root.val && q.val > root.val)
                {
                    // Both nodes are in the right subtree
                    root = root.right;
                }
                else
                {
                    // We have found the split point, i.e. the LCA node
                    return root;
                }
            }
            return null;
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        public static void FindLCAof2NodesBSTDriver()
        {
            FindLCAof2NodesBST_M_6 bst = new FindLCAof2NodesBST_M_6();

            TreeNode root = new TreeNode(6);
            root.left = new TreeNode(2);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(0);
            root.left.right = new TreeNode(4);
            root.left.right.left = new TreeNode(3);
            root.left.right.right = new TreeNode(5);
            root.right.left = new TreeNode(7);
            root.right.right = new TreeNode(9);

            TreeNode p = root.left; // Node with value 2
            TreeNode q = root.left.right; // Node with value 4

            Console.WriteLine("Inorder traversal of the tree:");
            bst.InorderTraversal(root);
            Console.WriteLine();

            TreeNode lca = bst.LowestCommonAncestor(root, p, q);
            Console.WriteLine($"The Lowest Common Ancestor of nodes {p.val} and {q.val} is: {lca.val}");
        }
    }

    public class FindInorderPredecessorAndSuccessorofagivenkeyBST_M_7
    {
        /*
        Finding the inorder predecessor and successor of a given key in a Binary Search Tree(BST) involves two different tasks.
        The predecessor of a node is the largest node that is smaller than the given key, 
        and the successor is the smallest node that is larger than the given key.

        Here is the C# code to find both the inorder predecessor and successor of a given key in a BST:


        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** FindPredecessor Method**:
             - This method finds the inorder predecessor of the given key.
             - It starts from the root and traverses the tree.If the current node's value is greater than or equal to the key,
        it moves to the left subtree. Otherwise, it moves to the right subtree and updates the predecessor.
           - **FindSuccessor Method**:
             - This method finds the inorder successor of the given key.
             - It starts from the root and traverses the tree.If the current node's value is less than or equal to the key, 
        it moves to the right subtree. Otherwise, it moves to the left subtree and updates the successor.
           - **InorderTraversal Method**:
             - Prints the BST in an inorder manner (left-root-right).
           - ** Main Method**:
             - Demonstrates finding the inorder predecessor and successor for a sample BST and prints the results.

        ### Complexity

        - ** Time Complexity**:
          - The time complexity for both `FindPredecessor` and `FindSuccessor` is (O(H)), where (H) is the height of the tree.
        In the worst case (for a skewed tree), this can be (O(N)), where (N) is the number of nodes.
  
        - **Space Complexity**:
          - The space complexity is (O(1)) for both methods as they do not use additional space other than a few variables.

        This implementation efficiently finds the inorder predecessor and successor of a given key in a BST using the properties of the BST to guide the search.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public TreeNode FindPredecessor(TreeNode root, int key)
        {
            TreeNode predecessor = null;
            while (root != null)
            {
                if (key <= root.val)
                {
                    root = root.left;
                }
                else
                {
                    predecessor = root;
                    root = root.right;
                }
            }
            return predecessor;
        }

        public TreeNode FindSuccessor(TreeNode root, int key)
        {
            TreeNode successor = null;
            while (root != null)
            {
                if (key >= root.val)
                {
                    root = root.right;
                }
                else
                {
                    successor = root;
                    root = root.left;
                }
            }
            return successor;
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        public static void FindInorderPredecessorAndSuccessorofagivenkeyBSTDriver()
        {
            FindInorderPredecessorAndSuccessorofagivenkeyBST_M_7 bst = new FindInorderPredecessorAndSuccessorofagivenkeyBST_M_7();

            TreeNode root = new TreeNode(20);
            root.left = new TreeNode(8);
            root.right = new TreeNode(22);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(12);
            root.left.right.left = new TreeNode(10);
            root.left.right.right = new TreeNode(14);

            int key = 10;

            Console.WriteLine("Inorder traversal of the tree:");
            bst.InorderTraversal(root);
            Console.WriteLine();

            TreeNode predecessor = bst.FindPredecessor(root, key);
            TreeNode successor = bst.FindSuccessor(root, key);

            if (predecessor != null)
            {
                Console.WriteLine($"The inorder predecessor of {key} is: {predecessor.val}");
            }
            else
            {
                Console.WriteLine($"There is no inorder predecessor of {key}");
            }

            if (successor != null)
            {
                Console.WriteLine($"The inorder successor of {key} is: {successor.val}");
            }
            else
            {
                Console.WriteLine($"There is no inorder successor of {key}");
            }
        }
    }

    public class FindFloorInBST_E_8
    {
        /*
        Finding the floor of a given key in a Binary Search Tree(BST) involves finding the largest value in the BST that is less than or equal to the given key.

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** FindFloor Method**:
             - This method finds the floor of the given key.
             - It starts from the root and traverses the tree.If the current node's value is equal to the key, it returns that node.
             - If the current node's value is less than the key, it updates the floor and moves to the right subtree to find a larger value that is still less than or equal to the key.
             - If the current node's value is greater than the key, it moves to the left subtree to find a smaller value.
           - ** InorderTraversal Method**:
             - Prints the BST in an inorder manner(left-root-right).
           - ** Main Method**:
             - Demonstrates finding the floor for a sample BST and prints the results.

        ### Complexity

        - ** Time Complexity**:
          - The time complexity for `FindFloor` is (O(H)), where (H) is the height of the tree.In the worst case (for a skewed tree), this can be (O(N)), where (N) is the number of nodes.
  
        - **Space Complexity**:
          - The space complexity is (O(1)) as the method does not use additional space other than a few variables.

        This implementation efficiently finds the floor of a given key in a BST using the properties of the BST to guide the search.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        // Method to find the floor of a given key in the BST
        public TreeNode FindFloor(TreeNode root, int key)
        {
            TreeNode floor = null;
            while (root != null)
            {
                if (root.val == key)
                {
                    return root;
                }
                if (root.val < key)
                {
                    floor = root;
                    root = root.right;
                }
                else
                {
                    root = root.left;
                }
            }
            return floor;
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        public static void FindFloorInBSTDriver()
        {
            FindFloorInBST_E_8 bst = new FindFloorInBST_E_8();

            TreeNode root = new TreeNode(20);
            root.left = new TreeNode(8);
            root.right = new TreeNode(22);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(12);
            root.left.right.left = new TreeNode(10);
            root.left.right.right = new TreeNode(14);

            int key = 17;
            
            Console.WriteLine($"Floor - finding the largest value in the BST that is less than or equal to the given key.");
            Console.WriteLine($"Key : {key}");
            Console.WriteLine("Inorder traversal of the tree:");
            bst.InorderTraversal(root);
            Console.WriteLine();

            TreeNode floorNode = bst.FindFloor(root, key);

            if (floorNode != null)
            {
                Console.WriteLine($"The floor of {key} is: {floorNode.val}");
            }
            else
            {
                Console.WriteLine($"There is no floor for {key} in the tree");
            }
        }
    }

    public class FindCeilInBST_E_9
    {
        /*
        Finding the ceil of a given key in a Binary Search Tree(BST) involves finding the smallest value in the BST that is greater than or equal to the given key.

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** FindCeil Method**:
             - This method finds the ceil of the given key.
             - It starts from the root and traverses the tree.If the current node's value is equal to the key, it returns that node.
             - If the current node's value is greater than the key,
        it updates the ceil and moves to the left subtree to find a smaller value that is still greater than or equal to the key.
             - If the current node's value is less than the key, it moves to the right subtree to find a larger value.
           - ** InorderTraversal Method**:
             - Prints the BST in an inorder manner(left-root-right).
           - ** Main Method**:
             - Demonstrates finding the ceil for a sample BST and prints the results.

        ### Complexity

        - ** Time Complexity**:
          - The time complexity for `FindCeil` is (O(H)), where(H) is the height of the tree.In the worst case (for a skewed tree),
        this can be (O(N)), where (N) is the number of nodes.
  
        - **Space Complexity**:
          - The space complexity is (O(1)) as the method does not use additional space other than a few variables.

        This implementation efficiently finds the ceil of a given key in a BST using the properties of the BST to guide the search.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        // Method to find the ceil of a given key in the BST
        public TreeNode FindCeil(TreeNode root, int key)
        {
            TreeNode ceil = null;
            while (root != null)
            {
                if (root.val == key)
                {
                    return root;
                }
                if (root.val > key)
                {
                    ceil = root;
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }
            return ceil;
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        public static void FindCeilInBSTDriver()
        {
            FindCeilInBST_E_9 bst = new FindCeilInBST_E_9();

            TreeNode root = new TreeNode(20);
            root.left = new TreeNode(8);
            root.right = new TreeNode(22);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(12);
            root.left.right.left = new TreeNode(10);
            root.left.right.right = new TreeNode(14);

            int key = 17;

            Console.WriteLine($" ceil - finding the smallest value in the BST that is greater than or equal to the given key.");
            Console.WriteLine($"Key : {key}");

            Console.WriteLine("Inorder traversal of the tree:");
            bst.InorderTraversal(root);
            Console.WriteLine();

            TreeNode ceilNode = bst.FindCeil(root, key);

            if (ceilNode != null)
            {
                Console.WriteLine($"The ceil of {key} is: {ceilNode.val}");
            }
            else
            {
                Console.WriteLine($"There is no ceil for {key} in the tree");
            }
        }
    }

    public class KthSmallestElementInBST_M_10
    {
        /*
        Finding the K-th smallest element in a Binary Search Tree(BST) requires an efficient approach due to the nature of BSTs where nodes are arranged
        in a specific order(left subtree < root<right subtree). Here's how you can implement this in C#:

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** KthSmallest Method**:
             - Initializes a counter `count` with `k` to keep track of how many nodes are left to visit.
             - Uses an inorder traversal approach to visit nodes in ascending order(left-root-right).
             - Decrements `count` for each node visited and checks if `count` reaches 0, in which case it sets `result` to the current node's value.
             - Stops further traversal once `result` is set.
           - ** InorderTraversal Method**:
             - Prints the BST in an inorder manner(left-root-right).
           - ** Main Method**:
             - Demonstrates finding the K-th smallest element for a sample BST and prints the result.

        ### Complexity

        - ** Time Complexity**:
          - The time complexity for finding the K-th smallest element is (O(H + k)), where (H) is the height of the tree.In the worst case,
        this can be (O(N + k)) for a skewed tree, where (N) is the number of nodes.
  
        - **Space Complexity**:
          - The space complexity is (O(1)) excluding recursion stack space.

        This implementation efficiently finds the K-th smallest element in a BST using an inorder traversal approach modified to stop early when the K-th element is found.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        private int count = 0;
        private int result = int.MinValue;

        // Method to find the K-th smallest element in the BST
        public int KthSmallest(TreeNode root, int k)
        {
            count = k;
            InorderTraversal(root);
            return result;
        }

        // Helper method for inorder traversal to find K-th smallest element
        public void InorderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            InorderTraversal(node.left);

            count--;
            if (count == 0)
            {
                result = node.val;
                return;
            }

            InorderTraversal(node.right);
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversalPrint(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversalPrint(root.left);
                Console.Write(root.val + " ");
                InorderTraversalPrint(root.right);
            }
        }

        public static void KthSmallestElementInBSTDriver()
        {
            KthSmallestElementInBST_M_10 bst = new KthSmallestElementInBST_M_10();

            TreeNode root = new TreeNode(20);
            root.left = new TreeNode(10);
            root.right = new TreeNode(30);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(15);
            root.right.left = new TreeNode(25);
            root.right.right = new TreeNode(35);

            int k = 3;
            Console.WriteLine($"K value: {k}");
            Console.WriteLine("Inorder traversal of the tree:");
            bst.InorderTraversalPrint(root);
            Console.WriteLine();

            int kthSmallest = bst.KthSmallest(root, k);

            Console.WriteLine($"The {k}-th smallest element in the BST is: {kthSmallest}");
        }
    }

    public class KthLargestElementInBST_M_11
    {
        /*
        To find the K-th largest element in a Binary Search Tree(BST), we can modify the approach used for finding the K-th smallest element.Here's how you can implement this in C#:

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** KthLargest Method**:
             - Initializes a counter `count` with `k` to keep track of how many nodes are left to visit.
             - Uses a reverse inorder traversal approach to visit nodes in descending order(right-root-left).
             - Decrements `count` for each node visited and checks if `count` reaches 0, in which case it sets `result` to the current node's value.
             - Stops further traversal once `result` is set.
           - ** InorderTraversal Method**:
             - Prints the BST in an inorder manner(left-root-right).
           - ** Main Method**:
             - Demonstrates finding the K-th largest element for a sample BST and prints the result.

        ### Complexity

        - ** Time Complexity**:
          - The time complexity for finding the K-th largest element is (O(H + k)), where (H) is the height of the tree.In the worst case, this can be (O(N + k)) for a skewed tree, where (N) is the number of nodes.
  
        - **Space Complexity**:
          - The space complexity is (O(1)) excluding recursion stack space.

        This implementation efficiently finds the K-th largest element in a BST using a reverse inorder traversal approach modified to stop early when the K-th element is found.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private int count = 0;
        private int result = int.MinValue;

        // Method to find the K-th largest element in the BST
        public int KthLargest(TreeNode root, int k)
        {
            count = k;
            InorderTraversal(root);
            return result;
        }

        // Helper method for reverse inorder traversal to find K-th largest element
        private void InorderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            InorderTraversal(node.right);

            count--;
            if (count == 0)
            {
                result = node.val;
                return;
            }

            InorderTraversal(node.left);
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversalPrint(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversalPrint(root.left);
                Console.Write(root.val + " ");
                InorderTraversalPrint(root.right);
            }
        }

        public static void KthLargestElementInBSTDriver()
        {
            KthLargestElementInBST_M_11 bst = new KthLargestElementInBST_M_11();

            TreeNode root = new TreeNode(20);
            root.left = new TreeNode(10);
            root.right = new TreeNode(30);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(15);
            root.right.left = new TreeNode(25);
            root.right.right = new TreeNode(35);

            int k = 3;
            Console.WriteLine($"K value: {k}");
            Console.WriteLine("Inorder traversal of the tree:");
            bst.InorderTraversalPrint(root);
            Console.WriteLine();

            int kthLargest = bst.KthLargest(root, k);

            Console.WriteLine($"The {k}-th largest element in the BST is: {kthLargest}");
        }
    }

    public class PairWithGivenSumBST_M_12
    {
        /*
        To find a pair of nodes in a Binary Search Tree(BST) that sums up to a given target value,
        we can utilize a two-pointer approach using iterative inorder traversals.Here's how you can implement this in C#:


        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BinarySearchTree Class**:
           - ** FindPairWithSum Method**:
             - Uses two stacks(`leftStack` and `rightStack`) to perform simultaneous inorder traversals:
               - `leftStack` is used to traverse nodes in ascending order(left-root-right).
               - `rightStack` is used to traverse nodes in descending order(right-root-left).
             - Initializes two pointers(`leftCurrent` and `rightCurrent`) to the smallest and largest values in the BST respectively.
             - Compares the sum of `leftCurrent.val` and `rightCurrent.val` with the target:
               - If they match, prints the pair and returns `true`.
               - If the sum is less than the target, moves `leftCurrent` to its successor(right subtree).
               - If the sum is greater than the target, moves `rightCurrent` to its predecessor(left subtree).
             - Stops when the pointers meet or exhaust the BST nodes.
           - **InorderTraversal Method**:
             - Prints the BST in an inorder manner (left-root-right).
           - ** Main Method**:
             - Demonstrates finding a pair with a given sum for a sample BST and prints the result.

        ### Complexity

        - ** Time Complexity**:
          - The time complexity for finding a pair with a given sum is (O(N)), where (N) is the number of nodes in the BST.Each node is processed exactly once.

        - **Space Complexity**:
          - The space complexity is (O(H)) due to the two stacks used, where (H) is the height of the BST.In the worst case, this can be (O(N)) for a skewed tree.

        This implementation efficiently finds a pair of nodes in a BST that sums up to a given target value using a two-pointer technique with iterative inorder traversals.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        // Method to find a pair with a given sum in the BST
        public bool FindPairWithSum(TreeNode root, int target)
        {
            Stack<TreeNode> leftStack = new Stack<TreeNode>();
            Stack<TreeNode> rightStack = new Stack<TreeNode>();

            TreeNode leftCurrent = root;
            TreeNode rightCurrent = root;

            while ((leftCurrent != null || leftStack.Count > 0) && (rightCurrent != null || rightStack.Count > 0 || rightCurrent != leftCurrent))
            {
                while (leftCurrent != null)
                {
                    leftStack.Push(leftCurrent);
                    leftCurrent = leftCurrent.left;
                }

                while (rightCurrent != null)
                {
                    rightStack.Push(rightCurrent);
                    rightCurrent = rightCurrent.right;
                }

                leftCurrent = leftStack.Peek();
                rightCurrent = rightStack.Peek();

                if (leftCurrent.val + rightCurrent.val == target)
                {
                    Console.WriteLine($"Pair found: ({leftCurrent.val}, {rightCurrent.val})");
                    return true;
                }
                else if (leftCurrent.val + rightCurrent.val < target)
                {
                    leftCurrent = leftStack.Pop();
                    leftCurrent = leftCurrent.right;
                }
                else
                {
                    rightCurrent = rightStack.Pop();
                    rightCurrent = rightCurrent.left;
                }
            }

            Console.WriteLine("No pair found.");
            return false;
        }

        // Helper method to print the tree (Inorder Traversal)
        public void InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.left);
                Console.Write(root.val + " ");
                InorderTraversal(root.right);
            }
        }

        public static void PairWithGivenSumBSTDriver()
        {
            PairWithGivenSumBST_M_12 bst = new PairWithGivenSumBST_M_12();

            TreeNode root = new TreeNode(15);
            root.left = new TreeNode(10);
            root.right = new TreeNode(20);
            root.left.left = new TreeNode(8);
            root.left.right = new TreeNode(12);
            root.right.left = new TreeNode(16);
            root.right.right = new TreeNode(25);

            int target = 28;
            Console.WriteLine("Target : " + target);
            Console.WriteLine("Inorder traversal of the tree:");
            bst.InorderTraversal(root);
            Console.WriteLine();

            bool foundPair = bst.FindPairWithSum(root, target);

            if (!foundPair)
            {
                Console.WriteLine($"No pair found with sum equal to {target}.");
            }
        }
    }

    public class BSTIterator_M_13
    {
        /*
        Implementing an iterator for a Binary Search Tree(BST) involves providing a way to iterate through the nodes of the tree in a specific order,
        typically inorder(ascending order). Here’s how you can implement a BST iterator in C#:

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a node in the binary search tree with `val`, `left`, and `right` properties.

        2. ** BSTIterator Class**:
           - ** Constructor(`BSTIterator`)**:
             - Initializes a stack(`stack`) to store nodes during traversal.
             - Calls `PushLeftNodes(root)` to push all left nodes starting from the root onto the stack, ensuring the smallest element is at the top.
           - ** HasNext Method**:
             - Returns `true` if there are more nodes to iterate over(i.e., stack is not empty).
           - ** Next Method**:
             - Pops the top node from the stack(which is the next smallest element).
             - If the popped node has a right subtree, calls `PushLeftNodes(node.right)` to push all left nodes of the right subtree onto the stack.
             - Returns the value of the popped node.
           - **PushLeftNodes Method**:
             - Takes a node as input and pushes all its left children onto the stack until it reaches a null node.

        3. **Program Class (Main Method)**:
           - Creates a sample BST.
           - Creates a `BSTIterator` instance with the root of the BST.
           - Iterates through the BST using the iterator(`HasNext` and `Next` methods) and prints each element in inorder.

        ### Complexity

        - ** Time Complexity**:
          - The `Next` and `HasNext` operations have an average time complexity of (O(1)) because each node is pushed and popped from the stack at most once.

        - ** Space Complexity**:
          - The space complexity is (O(H)), where (H) is the height of the BST.In the worst case, the stack can hold all nodes of the longest path from the root to a leaf.

        This implementation efficiently provides an iterator for inorder traversal of a BST using a stack to simulate recursive traversal, ensuring elements are visited in ascending order.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private Stack<TreeNode> stack;

        // Constructor to initialize the iterator with the root node
        public BSTIterator_M_13(TreeNode root)
        {
            stack = new Stack<TreeNode>();
            PushLeftNodes(root); // Push all left nodes onto the stack
        }

        // Method to check if there are more elements to iterate over
        public bool HasNext()
        {
            return stack.Count > 0;
        }

        // Method to get the next smallest element in the BST
        public int Next()
        {
            TreeNode node = stack.Pop();
            PushLeftNodes(node.right); // Push left nodes of the right subtree onto stack
            return node.val;
        }

        // Helper method to push all left nodes of a subtree onto stack
        private void PushLeftNodes(TreeNode node)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
        }

        public static void BSTIteratorDriver()
        {
            TreeNode root = new TreeNode(7);
            root.left = new TreeNode(3);
            root.right = new TreeNode(15);
            root.right.left = new TreeNode(9);
            root.right.right = new TreeNode(20);

            // Create a BST iterator
            BSTIterator_M_13 iterator = new BSTIterator_M_13(root);

            // Print all elements using the iterator
            Console.WriteLine("Inorder traversal using iterator:");
            while (iterator.HasNext())
            {
                int next = iterator.Next();
                Console.Write(next + " ");
            }
            Console.WriteLine();
        }
    }

    public class SizeOfLargestBSTinBinaryTree_M_14
    {
        /*
        Finding the size of the largest Binary Search Tree(BST) within a Binary Tree involves checking each subtree to verify if it is a valid BST and calculating its size.
        Here's how you can approach this problem in C#:

        ### Approach

        To determine the size of the largest BST in a Binary Tree, we need to traverse each node and check if its subtree is a valid BST.
        We can use a recursive approach to achieve this:

        1. **Recursive Function**: Implement a recursive function `LargestBSTSize` that:
           - Returns an object containing:
             - `size`: Size of the BST subtree rooted at the current node.
             - `min`: Minimum value in the subtree.
             - `max`: Maximum value in the subtree.
             - `isBST`: Indicates if the subtree is a valid BST.

        2. **Traversal**: Perform a depth-first search (DFS) traversal of the Binary Tree:
           - For each node, recursively calculate the size of the largest BST in its left and right subtrees.
           - Check if the current node forms a valid BST by ensuring:
             - Its value is greater than the maximum value in the left subtree.
             - Its value is less than the minimum value in the right subtree.

        3. **Update Maximum**: Keep track of the maximum BST size encountered during traversal.

        ### Explanation

        - ** TreeNode Class**: Represents a node in the binary tree with `val`, `left`, and `right` properties.

        - ** LargestBSTResult Class**: Represents the result of the `LargestBST` function, containing `size`, `min`, `max`, and `isBST` properties.

        - ** BinaryTree Class**:
          - ** LargestBSTSize Method**: Initializes `largestBSTSize` and calls `LargestBST` to find the size of the largest BST in the Binary Tree.
          - ** LargestBST Method**: Recursively computes the size of the largest BST rooted at the current node and updates `largestBSTSize` accordingly.

        - ** Main Method**: Constructs a sample Binary Tree and calculates the size of the largest BST using `LargestBSTSize`.

        ### Complexity

        - ** Time Complexity**: (O(N)), where (N) is the number of nodes in the Binary Tree.Each node is visited once.

        - **Space Complexity**: (O(H)), where (H) is the height of the Binary Tree due to the recursive call stack.In the worst case,
        this could be (O(N)) for a skewed tree.

        This implementation efficiently finds the size of the largest BST within a Binary Tree using a recursive approach with postorder traversal.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class LargestBSTResult
        {
            public int size;   // Size of the BST
            public int min;    // Minimum value in the BST
            public int max;    // Maximum value in the BST
            public bool isBST; // Whether the subtree is a valid BST

            public LargestBSTResult(int size, int min, int max, bool isBST)
            {
                this.size = size;
                this.min = min;
                this.max = max;
                this.isBST = isBST;
            }
        }


        private int largestBSTSize;

        // Method to find the size of the largest BST in the Binary Tree
        public int LargestBSTSize(TreeNode root)
        {
            largestBSTSize = 0;
            LargestBST(root);
            return largestBSTSize;
        }

        // Helper method to calculate the size of the largest BST
        private LargestBSTResult LargestBST(TreeNode node)
        {
            // Base case: For null nodes
            if (node == null)
                return new LargestBSTResult(0, int.MaxValue, int.MinValue, true);

            // Recursively calculate sizes of left and right subtrees
            LargestBSTResult left = LargestBST(node.left);
            LargestBSTResult right = LargestBST(node.right);

            // Check if current node forms a valid BST
            if (left.isBST && right.isBST && node.val > left.max && node.val < right.min)
            {
                int size = 1 + left.size + right.size;
                largestBSTSize = Math.Max(largestBSTSize, size);
                return new LargestBSTResult(size, Math.Min(node.val, left.min), Math.Max(node.val, right.max), true);
            }
            else
            {
                // If current node does not form a valid BST
                return new LargestBSTResult(0, int.MinValue, int.MaxValue, false);
            }
        }
      

        public static void SizeOfLargestBSTinBinaryTreeDriver()
        {
            // Example usage:
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(5);
            root.right = new TreeNode(15);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(8);
            root.right.right = new TreeNode(7);

            SizeOfLargestBSTinBinaryTree_M_14 binaryTree = new SizeOfLargestBSTinBinaryTree_M_14();
            int largestBSTSize = binaryTree.LargestBSTSize(root);

            Console.WriteLine($"Size of the largest BST in the Binary Tree: {largestBSTSize}");
        }
    }

    public class BinaryTreeSerializationAndDeSerialization_H_15
    {
        /*
        Serialization and deserialization of a Binary Tree involves converting a tree structure into a string representation(serialization) and
        reconstructing the tree from the serialized string (deserialization). Here's how you can implement serialization and deserialization of a Binary Tree in C#:

        ### Serialization

        To serialize a Binary Tree, you can perform a preorder traversal(root -> left -> right) and concatenate node values into a string,
        marking null nodes with a special character(like "#"). Here’s how you can implement it:

        ### Explanation

        - ** TreeNode Class**: Represents a node in the binary tree with `val`, `left`, and `right` properties.

        - ** BinaryTreeSerialization Class**:
          - ** Serialize Method**: Serializes a binary tree into a string using preorder traversal.Null nodes are marked with `#`.
          - ** SerializeHelper Method**: Recursive helper method for serialization.
          - ** Deserialize Method**: Deserializes a string back into a binary tree.
          - **DeserializeHelper Method**: Recursive helper method for deserialization.
  
        - **Main Method**: 
          - Constructs a sample binary tree.
          - Serializes the tree into a string.
          - Deserializes the string back into a binary tree.
          - Prints the deserialized tree to verify correctness.

        ### Complexity

        - **Serialization Time Complexity**: (O(N)), where (N) is the number of nodes in the Binary Tree.Each node is processed once during serialization.
  
        - **Deserialization Time Complexity**: (O(N)), where (N) is the number of nodes in the Binary Tree.Each node is processed once during deserialization.

        - **Space Complexity**: (O(N)) for both serialization and deserialization due to the use of recursion and the string array to store node values.

        This implementation efficiently serializes and deserializes a Binary Tree using preorder traversal and is validated by printing the deserialized tree.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        // Serialize a binary tree to a string
        public string Serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            SerializeHelper(root, sb);
            return sb.ToString();
        }

        private void SerializeHelper(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("# "); // Mark null node with #
                return;
            }

            // Append current node value and space
            sb.Append(node.val).Append(" ");

            // Recursively serialize left and right subtrees
            SerializeHelper(node.left, sb);
            SerializeHelper(node.right, sb);
        }

        // Deserialize a string to a binary tree
        public TreeNode Deserialize(string data)
        {
            string[] nodes = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            return DeserializeHelper(nodes, ref index);
        }

        private TreeNode DeserializeHelper(string[] nodes, ref int index)
        {
            if (index >= nodes.Length || nodes[index] == "#")
            {
                index++; // Move to the next node in the array
                return null;
            }

            // Create a new node with the current value
            int val = int.Parse(nodes[index++]);
            TreeNode node = new TreeNode(val);

            // Recursively deserialize left and right subtrees
            node.left = DeserializeHelper(nodes, ref index);
            node.right = DeserializeHelper(nodes, ref index);

            return node;
        }

        // Helper method to print the binary tree (inorder traversal)
        private static void PrintTree(TreeNode node)
        {
            if (node == null)
                return;

            PrintTree(node.left);
            Console.Write(node.val + " ");
            PrintTree(node.right);
        }

        public static void BinaryTreeSerializationAndDeSerializationDriver()
        {
            // Example usage:
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(5);

            // Print the Given tree
            Console.WriteLine("Given tree:");
            PrintTree(root);

            BinaryTreeSerializationAndDeSerialization_H_15 serializer = new BinaryTreeSerializationAndDeSerialization_H_15();

            // Serialize the binary tree
            string serializedString = serializer.Serialize(root);
            Console.WriteLine("\n\nSerialized tree:");
            Console.WriteLine(serializedString);

            // Deserialize the string back to a binary tree
            TreeNode deserializedRoot = serializer.Deserialize(serializedString);

            // Print the deserialized tree (to verify)
            Console.WriteLine("\nDeserialized tree:");
            PrintTree(deserializedRoot);
        }
    }
}
