using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using static GreedyAlgorithm.NMeetingInOneRoom_M_1;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinaryTrees
{
    public class BinaryTreeNode
    {
        public int val;
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public BinaryTreeNode(int val = 0, BinaryTreeNode left = null, BinaryTreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class InorderTraversal_E_1
    {
        /*
        Inorder traversal of a binary tree involves visiting the nodes in the following order:
        left subtree, root, and then right subtree.This traversal can be implemented both recursively and iteratively.

        ### Recursive Implementation

         The recursive approach is straightforward and involves calling the same function for the left subtree,
        then visiting the root node, and finally calling the function for the right subtree.

        ### Iterative Implementation

         The iterative approach uses a stack to simulate the recursive call stack.
        This approach is useful when you need to avoid the overhead of recursion, especially in environments where stack space is limited.


        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** Recursive Inorder Traversal**:
           - The `InorderTraversal` method recursively traverses the tree.
           - It first calls itself on the left subtree, then processes the root node by printing its value,
        and finally calls itself on the right subtree.

        3. **Iterative Inorder Traversal**:
           - The `InorderTraversalIterative` method uses a stack to traverse the tree.
           - It first goes as deep as possible to the left, pushing nodes onto the stack.
           - Once it reaches the leftmost node, it starts processing nodes by popping from the stack,
        then moving to the right subtree.

        ### Complexity

        - **Time Complexity**: (O(N)) for both recursive and iterative implementations, where (N) is the number of nodes in the tree.
        Each node is visited exactly once.
        - **Space Complexity**: 
          - Recursive implementation: (O(H)), where (H) is the height of the tree due to the call stack.
          - Iterative implementation: (O(H)), where (H) is the height of the tree due to the stack used for traversal.
        In the worst case, this can be (O(N)) for a skewed tree.

        These implementations provide efficient ways to perform inorder traversal of a binary tree, 
        with the iterative approach being particularly useful in environments where recursion depth might be a concern.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class InorderTraversalRecursive_E_1
        {
            public void InorderTraversalRecursive(TreeNode root)
            {
                if (root == null) return;

                InorderTraversalRecursive(root.left);
                Console.Write(root.val + " ");
                InorderTraversalRecursive(root.right);
            }

            public static void InorderTraversalRecursiveDriver()
            {
                TreeNode root = new TreeNode(1);
                root.right = new TreeNode(2);
                root.right.left = new TreeNode(3);

                InorderTraversalRecursive_E_1 tree = new InorderTraversalRecursive_E_1();
                Console.WriteLine("Recursive Inorder Traversal:");
                tree.InorderTraversalRecursive(root);  // Output: 1 3 2
            }
        }

        //#### Iterative Inorder Traversal

        public class InorderTraversalIterative_E_1
        {
            public void InorderTraversalIterative(TreeNode root)
            {
                if (root == null) return;

                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode current = root;

                while (current != null || stack.Count > 0)
                {
                    while (current != null)
                    {
                        stack.Push(current);
                        current = current.left;
                    }

                    current = stack.Pop();
                    Console.Write(current.val + " ");
                    current = current.right;
                }
            }

            public static void InorderTraversalIterativeDriver()
            {
                TreeNode root = new TreeNode(1);
                root.right = new TreeNode(2);
                root.right.left = new TreeNode(3);

                InorderTraversalIterative_E_1 tree = new InorderTraversalIterative_E_1();
                Console.WriteLine("Iterative Inorder Traversal:");
                tree.InorderTraversalIterative(root);  // Output: 1 3 2
            }
        }
    }

    public class PreOrderTraversal_E_2
    {
        /*
        Preorder traversal of a binary tree involves visiting the nodes in the following order: 
        root, left subtree, and then right subtree.Similar to inorder traversal, this can be implemented both recursively and iteratively.

        ### Recursive Implementation

        The recursive approach calls the same function for the root node, then the left subtree, and finally the right subtree.

        ### Iterative Implementation

        The iterative approach uses a stack to simulate the recursive call stack.
        This approach is useful for avoiding the overhead of recursion and can be particularly advantageous in certain environments.

        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** Recursive Preorder Traversal**:
           - The `PreorderTraversal` method recursively traverses the tree.
           - It first processes the root node by printing its value, then calls itself on the left subtree, and finally calls itself on the right subtree.

        3. **Iterative Preorder Traversal**:
           - The `PreorderTraversalIterative` method uses a stack to traverse the tree.
           - It starts by pushing the root node onto the stack. While the stack is not empty, it pops a node,
        processes it by printing its value, then pushes its right and left children onto the stack (in that order) to ensure the left child is processed first.

        ### Complexity

        - **Time Complexity**: (O(N)) for both recursive and iterative implementations, 
        where(N) is the number of nodes in the tree.Each node is visited exactly once.
        - **Space Complexity**: 
          - Recursive implementation: (O(H)), where(H) is the height of the tree due to the call stack.
          - Iterative implementation: (O(H)), where(H) is the height of the tree due to the stack used for traversal.
        In the worst case, this can be(O(N)) for a skewed tree.

        These implementations provide efficient ways to perform preorder traversal of a binary tree,
        with the iterative approach being particularly useful in environments where recursion depth might be a concern.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class PreorderTraversalRecursive_E_2
        {
            public void PreorderTraversalRecursive(TreeNode root)
            {
                if (root == null) return;

                Console.Write(root.val + " ");
                PreorderTraversalRecursive(root.left);
                PreorderTraversalRecursive(root.right);
            }

            public static void PreorderTraversalRecursiveDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);

                PreorderTraversalRecursive_E_2 tree = new PreorderTraversalRecursive_E_2();
                Console.WriteLine("Recursive Preorder Traversal:");
                tree.PreorderTraversalRecursive(root);  // Output: 1 2 4 5 3
            }
        }


        //#### Iterative Preorder Traversal

        public class PreorderTraversalIterative_E_2
        {
            public void PreorderTraversalIterative(TreeNode root)
            {
                if (root == null) return;

                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);

                while (stack.Count > 0)
                {
                    TreeNode node = stack.Pop();
                    Console.Write(node.val + " ");

                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }

                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }
            }

            public static void PreorderTraversalIterativeDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);

                PreorderTraversalIterative_E_2 tree = new PreorderTraversalIterative_E_2();
                Console.WriteLine("Iterative Preorder Traversal:");
                tree.PreorderTraversalIterative(root);  // Output: 1 2 4 5 3
            }
        }
    }

    public class PostOrderTraversal_E_3
    {
        /*
        Postorder traversal of a binary tree involves visiting the nodes in the following order: 
        left subtree, right subtree, and then root.This traversal can also be implemented both recursively and iteratively.

        ### Recursive Implementation

        The recursive approach calls the same function for the left subtree, then the right subtree, and finally processes the root node.

        ### Iterative Implementation

        The iterative approach uses a stack to simulate the recursive call stack. 
        This is slightly more complex than inorder or preorder traversal but can be efficiently implemented using two stacks or a modified single-stack approach.

        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** Recursive Postorder Traversal**:
           - The `PostorderTraversal` method recursively traverses the tree.
           - It first calls itself on the left subtree, then calls itself on the right subtree,
        and finally processes the root node by printing its value.

        3. **Iterative Postorder Traversal**:
           - The `PostorderTraversalIterative` method uses two stacks to traverse the tree.
           - The first stack is used to traverse the tree and push nodes onto the second stack.
           - The second stack then contains the nodes in postorder sequence, and we can simply pop from it to get the postorder traversal.
           - This approach ensures that we process the left subtree, right subtree, and root node in the correct order.

        ### Complexity

        - **Time Complexity**: (O(N)) for both recursive and iterative implementations,
        where (N) is the number of nodes in the tree.Each node is visited exactly once.
        - **Space Complexity**: 
          - Recursive implementation: (O(H)), where (H) is the height of the tree due to the call stack.
          - Iterative implementation: (O(N)) in the worst case, due to the use of two stacks.

        These implementations provide efficient ways to perform postorder traversal of a binary tree,
        with the iterative approach being particularly useful in environments where recursion depth might be a concern.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class PostOrderTraversalRecursive_E_3
        {
            public void PostOrderTraversalRecursive(TreeNode root)
            {
                if (root == null) return;

                PostOrderTraversalRecursive(root.left);
                PostOrderTraversalRecursive(root.right);
                Console.Write(root.val + " ");
            }

            public static void PostOrderTraversalRecursiveDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);

                PostOrderTraversalRecursive_E_3 tree = new PostOrderTraversalRecursive_E_3();
                Console.WriteLine("Recursive Postorder Traversal:");
                tree.PostOrderTraversalRecursive(root);  // Output: 4 5 2 3 1
            }
        }

        //#### Iterative Postorder Traversal

        public class PostorderTraversalIterative_E_3
        {
            public void PostorderTraversalIterative(TreeNode root)
            {
                if (root == null) return;

                Stack<TreeNode> stack = new Stack<TreeNode>();
                Stack<TreeNode> output = new Stack<TreeNode>();
                stack.Push(root);

                while (stack.Count > 0)
                {
                    TreeNode node = stack.Pop();
                    output.Push(node);

                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }

                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                }

                while (output.Count > 0)
                {
                    TreeNode node = output.Pop();
                    Console.Write(node.val + " ");
                }
            }

            public static void PostorderTraversalIterativeDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);

                PostorderTraversalIterative_E_3 tree = new PostorderTraversalIterative_E_3();
                Console.WriteLine("Iterative Postorder Traversal:");
                tree.PostorderTraversalIterative(root);  // Output: 4 5 2 3 1
            }
        }
    }

    public class MorrisInorderTraversal_M_4
    {
        /*
        Morris Inorder Traversal is an algorithm for performing an inorder traversal of a binary tree with (O(1)) space complexity, 
        excluding the input and output.This algorithm modifies the tree structure during traversal and restores it afterwards,
        ensuring that no extra space is used apart from a few pointers.

        ### Algorithm

        1. Initialize the current node as the root.
        2. While the current node is not null:
           - If the current node does not have a left child:
             - Print the current node's value.
             - Move to the right child.
           - Otherwise:
             - Find the inorder predecessor of the current node (the rightmost node in the current node's left subtree).
             - If the right child of the inorder predecessor is null:
               - Make the current node the right child of the inorder predecessor (create a temporary thread).
               - Move to the left child of the current node.
             - If the right child of the inorder predecessor is the current node:
               - Remove the temporary thread(restore the tree structure).
               - Print the current node's value.
               - Move to the right child of the current node.

        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** Morris Inorder Traversal**:
           - The `MorrisInorderTraversal` method performs the inorder traversal using the Morris Traversal algorithm.
           - The `current` pointer is initialized to the root node.
           - The algorithm proceeds to traverse the tree, modifying the structure to create temporary threads and restore the structure after processing each node.

        ### Complexity

        - ** Time Complexity**: (O(N)), where (N) is the number of nodes in the tree.Each edge is traversed at most twice, and each node is processed once.
        - **Space Complexity**: (O(1)), excluding the input and output.No additional space is used apart from a few pointers.

        The Morris Inorder Traversal is a space-efficient way to perform an inorder traversal of a binary tree, making it useful in environments with strict memory constraints.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public void MorrisInorderTraversal(TreeNode root)
        {
            TreeNode current = root;

            while (current != null)
            {
                if (current.left == null)
                {
                    Console.Write(current.val + " ");
                    current = current.right;
                }
                else
                {
                    TreeNode predecessor = current.left;
                    while (predecessor.right != null && predecessor.right != current)
                    {
                        predecessor = predecessor.right;
                    }

                    if (predecessor.right == null)
                    {
                        predecessor.right = current;
                        current = current.left;
                    }
                    else
                    {
                        predecessor.right = null;
                        Console.Write(current.val + " ");
                        current = current.right;
                    }
                }
            }
        }

        public static void MorrisInorderTraversalDriver()
        {
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);

            MorrisInorderTraversal_M_4 tree = new MorrisInorderTraversal_M_4();
            Console.WriteLine("Morris Inorder Traversal:");
            tree.MorrisInorderTraversal(root);  // Output: 1 3 2
        }
    }

    public class MorrisPreorderTraversal_M_5
    {
        /*
        Morris Preorder Traversal is an algorithm for performing a preorder traversal of a binary tree with (O(1)) space complexity,
        excluding the input and output.Similar to Morris Inorder Traversal,
        it modifies the tree structure during traversal and restores it afterward.

        ### Algorithm

        1. Initialize the current node as the root.
        2. While the current node is not null:
           - If the current node does not have a left child:
             - Print the current node's value.
             - Move to the right child.
           - Otherwise:
             - Find the inorder predecessor of the current node (the rightmost node in the current node's left subtree).
             - If the right child of the inorder predecessor is null:
               - Print the current node's value (this is the difference from the inorder traversal).
               - Make the current node the right child of the inorder predecessor (create a temporary thread).
               - Move to the left child of the current node.
             - If the right child of the inorder predecessor is the current node:
               - Remove the temporary thread(restore the tree structure).
               - Move to the right child of the current node.

        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** Morris Preorder Traversal**:
           - The `MorrisPreorderTraversal` method performs the preorder traversal using the Morris Traversal algorithm.
           - The `current` pointer is initialized to the root node.
           - The algorithm proceeds to traverse the tree,
        modifying the structure to create temporary threads and restore the structure after processing each node.
           - The key difference from Morris Inorder Traversal is that the current node's value is printed before moving to the left subtree.

        ### Complexity

        - ** Time Complexity**: (O(N)), where (N) is the number of nodes in the tree.Each edge is traversed at most twice, and each node is processed once.
        - **Space Complexity**: (O(1)), excluding the input and output.No additional space is used apart from a few pointers.

        The Morris Preorder Traversal is a space-efficient way to perform a preorder traversal of a binary tree,
        making it useful in environments with strict memory constraints.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public void MorrisPreorderTraversal(TreeNode root)
        {
            TreeNode current = root;

            while (current != null)
            {
                if (current.left == null)
                {
                    Console.Write(current.val + " ");
                    current = current.right;
                }
                else
                {
                    TreeNode predecessor = current.left;
                    while (predecessor.right != null && predecessor.right != current)
                    {
                        predecessor = predecessor.right;
                    }

                    if (predecessor.right == null)
                    {
                        Console.Write(current.val + " ");
                        predecessor.right = current;
                        current = current.left;
                    }
                    else
                    {
                        predecessor.right = null;
                        current = current.right;
                    }
                }
            }
        }

        public static void MorrisPreorderTraversalDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            MorrisPreorderTraversal_M_5 tree = new MorrisPreorderTraversal_M_5();
            Console.WriteLine("Morris Preorder Traversal:");
            tree.MorrisPreorderTraversal(root);  // Output: 1 2 4 5 3 6 7
        }
    }

    public class LeftView_E_6
    {
        /*
        The left view of a binary tree consists of the nodes that are visible when the tree is viewed from the left side.
        To find the left view, we can perform a level-order traversal(BFS) or use a depth-first search(DFS) approach.

        ### BFS Approach

        In the BFS approach, we use a queue to perform a level-order traversal and ensure that we capture the first node at each level.

        ### DFS Approach

        In the DFS approach, we keep track of the maximum level visited and update the left view whenever we encounter a node at a new level.

        ### BFS Implementation
        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** BFS Left View**:
           - The `LeftView` method performs a level-order traversal using a queue.
           - For each level, it prints the first node encountered.
           - This ensures that only the leftmost nodes are included in the left view.

        3. **DFS Left View**:
           - The `LeftView` method calls `LeftViewUtil`, which performs a depth-first traversal.
           - The `LeftViewUtil` method tracks the maximum level visited and prints the node value if it is the first node at that level.
           - This ensures that only the leftmost nodes are included in the left view.

        ### Complexity

        - **Time Complexity**: (O(N)) for both BFS and DFS implementations, where (N) is the number of nodes in the tree.Each node is visited exactly once.
        - **Space Complexity**:
          - BFS implementation: (O(W)), where (W) is the maximum width of the tree(maximum number of nodes at any level).
          - DFS implementation: (O(H)), where (H) is the height of the tree due to the call stack.

        These implementations provide efficient ways to compute the left view of a binary tree,
        with the BFS approach being straightforward and the DFS approach being more recursive and elegant.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class LeftViewBFS_E_6
        {
            public void LeftViewBFS(TreeNode root)
            {
                if (root == null) return;

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    int levelSize = queue.Count;

                    for (int i = 0; i < levelSize; i++)
                    {
                        TreeNode currentNode = queue.Dequeue();

                        // Print the first node of each level
                        if (i == 0)
                        {
                            Console.Write(currentNode.val + " ");
                        }

                        if (currentNode.left != null)
                        {
                            queue.Enqueue(currentNode.left);
                        }

                        if (currentNode.right != null)
                        {
                            queue.Enqueue(currentNode.right);
                        }
                    }
                }
            }

            public static void LeftViewBFSDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);
                root.right.left = new TreeNode(6);
                root.right.right = new TreeNode(7);

                LeftViewBFS_E_6 tree = new LeftViewBFS_E_6();
                Console.WriteLine("Left View of the Binary Tree BFS approach:");
                tree.LeftViewBFS(root);  // Output: 1 2 4
            }
        }

        //### DFS Implementation

        public class LeftViewDFS_E_6
        {
            private int maxLevel = -1;

            public void LeftViewDFS(TreeNode root)
            {
                LeftViewUtil(root, 0);
            }

            private void LeftViewUtil(TreeNode node, int level)
            {
                if (node == null) return;

                // If this is the first node of its level
                if (maxLevel < level)
                {
                    Console.Write(node.val + " ");
                    maxLevel = level;
                }

                // Recur for left and right subtrees
                LeftViewUtil(node.left, level + 1);
                LeftViewUtil(node.right, level + 1);
            }

            public static void LeftViewDFSDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);
                root.right.left = new TreeNode(6);
                root.right.right = new TreeNode(7);

                LeftViewDFS_E_6 tree = new LeftViewDFS_E_6();
                Console.WriteLine("Left View of the Binary Tree DFS approach:");
                tree.LeftViewDFS(root);  // Output: 1 2 4
            }
        }

    }

    public class BottomView_M_7
    {
        /*
        The bottom view of a binary tree is a set of nodes visible when the tree is viewed from the bottom.
        For each horizontal distance from the root, the bottom view includes the node that is the lowest (farthest from the root).

        To achieve this, we can perform a level-order traversal (BFS) using a queue.
        Additionally, we'll maintain a dictionary to keep track of the nodes at each horizontal distance from the root.

        ### Algorithm

        1. Initialize a queue and enqueue the root node along with its horizontal distance(0).
        2. Initialize a dictionary to store the bottommost node at each horizontal distance.
        3. While the queue is not empty:
           - Dequeue the front node and its horizontal distance.
           - Update the dictionary with the current node for the horizontal distance.
           - If the node has a left child, enqueue it with the horizontal distance decreased by 1.
           - If the node has a right child, enqueue it with the horizontal distance increased by 1.
        4. After the traversal, the dictionary will contain the bottom view of the tree.

        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** Bottom View**:
           - The `BottomView` method performs a level-order traversal using a queue to keep track of nodes and their horizontal distances.
           - A dictionary (`bottomViewMap`) keeps the bottommost node at each horizontal distance.
           - For each node, it updates the dictionary with the current node's value for its horizontal distance.
           - It enqueues the left and right children with updated horizontal distances.
           - After the traversal, it prints the nodes in the bottom view, ordered by their horizontal distances.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the tree.Each node is visited exactly once.
        - **Space Complexity**: (O(N)), for the queue and the dictionary used to store the nodes and their horizontal distances.

        This approach ensures an efficient computation of the bottom view of a binary tree,
        leveraging BFS to traverse each level and maintain the correct nodes for the bottom view.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public void BottomView(TreeNode root)
        {
            if (root == null) return;

            // Queue to store nodes along with their horizontal distance
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            // Dictionary to store the last node at each horizontal distance
            Dictionary<int, int> bottomViewMap = new Dictionary<int, int>();

            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                var (currentNode, hd) = queue.Dequeue();
                // Update the bottom view map with the current node
                bottomViewMap[hd] = currentNode.val;

                // Enqueue left child with horizontal distance hd - 1
                if (currentNode.left != null)
                {
                    queue.Enqueue((currentNode.left, hd - 1));
                }

                // Enqueue right child with horizontal distance hd + 1
                if (currentNode.right != null)
                {
                    queue.Enqueue((currentNode.right, hd + 1));
                }
            }

            // Extracting the values from the bottom view map
            foreach (var key in new SortedSet<int>(bottomViewMap.Keys))
            {
                Console.Write(bottomViewMap[key] + " ");
            }
        }

        public static void BottomViewDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            BottomView_M_7 tree = new BottomView_M_7();
            Console.WriteLine("Bottom View of the Binary Tree:");
            tree.BottomView(root);  // Expected Output: 4 2 6 3 7
        }
    }

    public class TopView_M_8
    {
        /*
        The top view of a binary tree is the set of nodes visible when the tree is viewed from the top.
        For each horizontal distance from the root, the top view includes the first node encountered at that distance.

        To achieve this, we can perform a level-order traversal (BFS) using a queue.Additionally, 
        we'll maintain a dictionary to keep track of the first node at each horizontal distance from the root.

        ### Algorithm

        1. Initialize a queue and enqueue the root node along with its horizontal distance(0).
        2. Initialize a dictionary to store the first node at each horizontal distance.
        3. While the queue is not empty:
           - Dequeue the front node and its horizontal distance.
           - If the horizontal distance is not already present in the dictionary, add the current node's value.
           - If the node has a left child, enqueue it with the horizontal distance decreased by 1.
           - If the node has a right child, enqueue it with the horizontal distance increased by 1.
        4. After the traversal, the dictionary will contain the top view of the tree.

        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** Top View**:
           - The `TopView` method performs a level-order traversal using a queue to keep track of nodes and their horizontal distances.
           - A dictionary (`topViewMap`) keeps the first node at each horizontal distance.
           - For each node, if its horizontal distance is not already in the dictionary, it adds the node's value to the dictionary.
           - It enqueues the left and right children with updated horizontal distances.
           - After the traversal, it prints the nodes in the top view, ordered by their horizontal distances.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the tree.Each node is visited exactly once.
        - **Space Complexity**: (O(N)), for the queue and the dictionary used to store the nodes and their horizontal distances.

        This approach ensures an efficient computation of the top view of a binary tree, 
        leveraging BFS to traverse each level and maintain the correct nodes for the top view.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public void TopView(TreeNode root)
        {
            if (root == null) return;

            // Queue to store nodes along with their horizontal distance
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            // Dictionary to store the first node at each horizontal distance
            Dictionary<int, int> topViewMap = new Dictionary<int, int>();

            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                var (currentNode, hd) = queue.Dequeue();

                // If horizontal distance is not already in the map, add it
                if (!topViewMap.ContainsKey(hd))
                {
                    topViewMap[hd] = currentNode.val;
                }

                // Enqueue left child with horizontal distance hd - 1
                if (currentNode.left != null)
                {
                    queue.Enqueue((currentNode.left, hd - 1));
                }

                // Enqueue right child with horizontal distance hd + 1
                if (currentNode.right != null)
                {
                    queue.Enqueue((currentNode.right, hd + 1));
                }
            }

            // Extracting the values from the top view map
            foreach (var key in new SortedSet<int>(topViewMap.Keys))
            {
                Console.Write(topViewMap[key] + " ");
            }
        }

        public static void TopViewDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            TopView_M_8 tree = new TopView_M_8();
            Console.WriteLine("Top View of the Binary Tree:");
            tree.TopView(root);  // Expected Output: 4 2 1 3 7
        }
    }

    public class InorderPreorderPostorderInSingleTraversal_M_9
    {
        /*
        To perform preorder, inorder, and postorder traversals in a single traversal, you can use a stack to simulate the recursion process.
        Each time you visit a node, you decide whether to process it for preorder, inorder, or postorder based on a specific condition.

        ### Algorithm

        1. Use a stack to keep track of nodes along with a state that indicates which part of the traversal the node is in (preorder, inorder, or postorder).
        2. Initialize the stack with the root node and its initial state for preorder.
        3. Loop until the stack is empty:
           - Pop the top element from the stack.
           - Based on the state, perform the following actions:
             - If in preorder state:
               - Record the node for preorder.
               - Push the node back to the stack with the next state for inorder.
               - If the node has a left child, push it to the stack with the preorder state.
             - If in inorder state:
               - Record the node for inorder.
               - Push the node back to the stack with the next state for postorder.
               - If the node has a right child, push it to the stack with the preorder state.
             - If in postorder state:
               - Record the node for postorder.

        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** AllTraversals Method**:
           - Uses a stack to perform a single traversal while generating preorder, inorder, and postorder traversals.
           - Each node is pushed onto the stack with a state indicating whether it is being processed for preorder (1), inorder(2), or postorder(3).
           - Based on the state, the node's value is added to the respective traversal list and the node's children are pushed onto the stack with appropriate states.

        3. **Main Method**:
           - Creates a sample binary tree and calls the `AllTraversals` method to print the preorder, inorder, and postorder traversals.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the tree.Each node is processed exactly once.
        - **Space Complexity**: (O(N)), for the stack used in the traversal.

        This approach ensures efficient computation of preorder, inorder, and postorder traversals 
        in a single pass through the binary tree using a stack to manage the traversal states.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public void AllTraversals(TreeNode root)
        {
            if (root == null) return;

            List<int> preorder = new List<int>();
            List<int> inorder = new List<int>();
            List<int> postorder = new List<int>();

            // Stack to store nodes along with their state
            Stack<(TreeNode, int)> stack = new Stack<(TreeNode, int)>();

            stack.Push((root, 1)); // 1 means preorder

            while (stack.Count > 0)
            {
                var (node, state) = stack.Pop();

                if (state == 1) // Preorder
                {
                    preorder.Add(node.val);
                    stack.Push((node, 2)); // Push the node back with state 2 (inorder)
                    if (node.left != null) stack.Push((node.left, 1)); // Push left child with state 1 (preorder)
                }
                else if (state == 2) // Inorder
                {
                    inorder.Add(node.val);
                    stack.Push((node, 3)); // Push the node back with state 3 (postorder)
                    if (node.right != null) stack.Push((node.right, 1)); // Push right child with state 1 (preorder)
                }
                else if (state == 3) // Postorder
                {
                    postorder.Add(node.val);
                }
            }

            // Print the traversals
            Console.WriteLine("Preorder: " + string.Join(", ", preorder));
            Console.WriteLine("Inorder: " + string.Join(", ", inorder));
            Console.WriteLine("Postorder: " + string.Join(", ", postorder));
        }

        public static void InorderPreorderPostorderInSingleTraversalDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            InorderPreorderPostorderInSingleTraversal_M_9 tree = new InorderPreorderPostorderInSingleTraversal_M_9();
            tree.AllTraversals(root);
        }
    }

    public class VerticalOrderTraversal_E_10
    {
        /*
        Vertical order traversal of a binary tree involves traversing the tree column by column.
        Nodes in the same column are grouped together. If two nodes are in the same row and column, the order should be top to bottom, left to right.

        ### Algorithm

        1. Use a breadth-first search (BFS) with a queue to traverse the tree.
        2. Maintain a dictionary to store nodes at each horizontal distance from the root.
        3. Use a priority queue (min-heap) to maintain the vertical order of nodes.
        4. For each node, determine its horizontal distance and row.
        Enqueue its left child with a horizontal distance one less and its right child with a horizontal distance one more.
        5. After traversing the tree, extract the nodes from the dictionary in order of their horizontal distance.

        ### Explanation

        1. ** TreeNode Class**:
           - Defines the structure of a tree node, including its value(`val`), left child(`left`), and right child(`right`).

        2. ** VerticalTraversal Method**:
           - Uses a queue to perform a level-order traversal(BFS) while keeping track of each node's horizontal distance (`hd`) and row.
           - The dictionary(`nodeMap`) stores nodes by their horizontal distance and row.
           - The nodes are added to the dictionary, with sorting handled for rows and nodes within the same row.
           - After the traversal, nodes are extracted from the dictionary in order of their horizontal distance and row, producing the vertical order.

        3. **Main Method**:
           - Creates a sample binary tree and calls the `VerticalTraversal` method to print the vertical order traversal.

        ### Complexity

        - **Time Complexity**: (O(N log N)), where (N) is the number of nodes in the tree.
        This accounts for inserting nodes into the dictionary and sorting them.
        - **Space Complexity**: (O(N)), for the queue and the dictionary used to store the nodes and their horizontal distances.

        This approach ensures an efficient computation of the vertical order traversal of a binary tree,
        leveraging BFS for traversal and sorting for maintaining the correct order of nodes.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            // Dictionary to store nodes by horizontal distance and row
            var nodeMap = new SortedDictionary<int, SortedDictionary<int, List<int>>>();
            // Queue for BFS traversal
            var queue = new Queue<(TreeNode node, int hd, int row)>();
            queue.Enqueue((root, 0, 0));

            while (queue.Count > 0)
            {
                var (node, hd, row) = queue.Dequeue();

                if (!nodeMap.ContainsKey(hd))
                    nodeMap[hd] = new SortedDictionary<int, List<int>>();
                if (!nodeMap[hd].ContainsKey(row))
                    nodeMap[hd][row] = new List<int>();

                nodeMap[hd][row].Add(node.val);

                if (node.left != null)
                    queue.Enqueue((node.left, hd - 1, row + 1));
                if (node.right != null)
                    queue.Enqueue((node.right, hd + 1, row + 1));
            }

            var result = new List<IList<int>>();
            foreach (var hd in nodeMap.Keys)
            {
                var col = new List<int>();
                foreach (var row in nodeMap[hd].Keys)
                {
                    var nodes = nodeMap[hd][row];
                    nodes.Sort();
                    col.AddRange(nodes);
                }
                result.Add(col);
            }

            return result;
        }

        public static void VerticalTraversalDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            VerticalOrderTraversal_E_10 traversal = new VerticalOrderTraversal_E_10();
            var result = traversal.VerticalTraversal(root);

            Console.WriteLine("Vertical Order Traversal:");
            foreach (var list in result)
            {
                Console.WriteLine(string.Join(", ", list));
            }
        }
    }

    public class RootToNodePath_M_11
    {
        /*
        To find the path from the root to a specific node in a binary tree, you can perform a depth-first search(DFS) traversal.
        During the traversal, you'll keep track of the current path from the root to the current node. 
        When the target node is found, you'll store a copy of the path.

        Here's how you can implement this in C#:

        ### TreeNode Class

        First, define the TreeNode class to represent nodes in the binary tree:
        ### Root to Node Path Method

        Next, implement the method to find the path from the root to a specific node:

        
        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.
  
        2. **PathToNode Method**: 
           - Initializes an empty list `path` to store the path from the root to the target node.
           - Calls the private method `FindPath` with the root node, target value, and `path` list.
           - Returns the `path` list after the `FindPath` method completes.

        3. **FindPath Method**:
           - Base case: If the current node is null, returns false.
           - Appends the current node's value to `path`.
           - If the current node's value matches the target, returns true.
           - Recursively searches in the left and right subtrees:
             - If found in either subtree, returns true.
           - If not found in the current subtree, removes the current node's value from `path` and returns false.

        4. **Main Method**: 
           - Creates a sample binary tree.
           - Calls `PathToNode` method to find the path to the target node (`5` in this case).
           - Prints the path if the node is found; otherwise, prints a message indicating that the node was not found.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited exactly once.
        - ** Space Complexity**: (O(H)), where (H) is the height of the binary tree.
        This space is used for the recursion stack during the DFS traversal and for storing the path list.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public List<int> PathToNode(TreeNode root, int target)
        {
            List<int> path = new List<int>();
            FindPath(root, target, path);
            return path;
        }

        private bool FindPath(TreeNode node, int target, List<int> path)
        {
            if (node == null)
                return false;

            // Add current node's value to path
            path.Add(node.val);

            // If target node found, return true
            if (node.val == target)
                return true;

            // Recursively search in left and right subtrees
            if (FindPath(node.left, target, path) || FindPath(node.right, target, path))
                return true;

            // If not found in current subtree, remove current node from path and return false
            path.RemoveAt(path.Count - 1);
            return false;
        }

        public static void RootToNodePathDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            RootToNodePath_M_11 tree = new RootToNodePath_M_11();
            int target = 5;
            List<int> path = tree.PathToNode(root, target);

            if (path.Count > 0)
            {
                Console.WriteLine($"Path to node {target}: " + string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine($"Node {target} not found in the tree.");
            }
        }
    }

    public class MaxWidth_M_12
    {
        /*
        To find the maximum width of a binary tree, we can perform a level-order traversal(BFS) while keeping track of the width of each level.
        Here's how you can implement this in C#:

        ### TreeNode Class

        First, define the `TreeNode` class to represent nodes in the binary tree:

        
        ### Maximum Width Calculation

        Implement a method to calculate the maximum width of the binary tree using BFS:


        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **MaxWidth Method**:
           - Initializes `maxWidth` to store the maximum width encountered.
           - Uses a queue to perform level-order traversal (BFS) of the binary tree.
           - Tracks the number of nodes (`levelWidth`) at each level.
           - Updates `maxWidth` with the maximum `levelWidth` encountered during traversal.
           - Enqueues all children of nodes at the current level for the next iteration.

        3. ** Main Method**:
           - Creates a sample binary tree.
           - Calls the `MaxWidth` method to find and print the maximum width of the binary tree.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited once.
        - **Space Complexity**: (O(W)), where (W) is the maximum width of the binary tree at any level.
        This is the maximum number of nodes that can be present at any level in the queue during BFS traversal.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public int MaxWidth(TreeNode root)
        {
            if (root == null) return 0;

            int maxWidth = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelWidth = queue.Count; // Number of nodes at current level

                maxWidth = Math.Max(maxWidth, levelWidth);

                // Enqueue all children of the current level
                for (int i = 0; i < levelWidth; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return maxWidth;
        }

        public static void MaxWidthDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.right.right = new TreeNode(5);
            root.right.right.left = new TreeNode(6);
            root.right.right.right = new TreeNode(7);

            MaxWidth_M_12 tree = new MaxWidth_M_12();
            int maxWidth = tree.MaxWidth(root);
            Console.WriteLine("Maximum width of the binary tree: " + maxWidth);
        }
    }

    public class LevelOrderTraversal_M_13
    {
        /*
        Level order traversal(also known as breadth-first traversal) involves visiting all nodes at each level of the tree before moving on to the next level.
        For spiral(or zigzag) level order traversal, we alternate the order of traversal between levels.

        Here are the implementations for both level order traversal and spiral level order traversal in C#:

        ### TreeNode Class

        First, define the `TreeNode` class to represent nodes in the binary tree:



        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **LevelOrder Method**:
           - Uses a queue to perform level-order traversal.
           - For each level, dequeues nodes and enqueues their children.
           - Adds each level's nodes to the result list.

        3. **SpiralOrder Method**:
           - Uses two stacks to perform zigzag traversal.
           - `currentLevel` stack contains nodes of the current level.
           - `nextLevel` stack stores nodes of the next level.
           - A boolean flag `leftToRight` determines the direction of traversal.
           - Switches direction after processing each level.

        4. **Main Method**:
           - Creates a sample binary tree.
           - Calls `LevelOrder` and `SpiralOrder` methods to print the traversals.

        ### Complexity

        - **Time Complexity**: Both methods have (O(N)) time complexity, where (N) is the number of nodes in the binary tree,
        as each node is visited exactly once.
        - ** Space Complexity**: (O(N)) for both methods due to the storage required for the queue or stacks.In the worst case,
        the space required is proportional to the maximum number of nodes at any level of the tree.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        //### Level Order Traversal

        public class LevelOrderTraversalNormalOrder_M_13
        {
            public IList<IList<int>> LevelOrder(TreeNode root)
            {
                IList<IList<int>> result = new List<IList<int>>();
                if (root == null) return result;

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    int levelSize = queue.Count;
                    List<int> currentLevel = new List<int>();

                    for (int i = 0; i < levelSize; i++)
                    {
                        TreeNode node = queue.Dequeue();
                        currentLevel.Add(node.val);
                        if (node.left != null) queue.Enqueue(node.left);
                        if (node.right != null) queue.Enqueue(node.right);
                    }

                    result.Add(currentLevel);
                }

                return result;
            }

            public static void LevelOrderTraversalNormalOrderDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);
                root.right.left = new TreeNode(6);
                root.right.right = new TreeNode(7);

                LevelOrderTraversalNormalOrder_M_13 tree = new LevelOrderTraversalNormalOrder_M_13();
                var result = tree.LevelOrder(root);

                Console.WriteLine("Level Order Traversal:");
                foreach (var level in result)
                {
                    Console.WriteLine(string.Join(", ", level));
                }
            }
        }

        //### Spiral Level Order Traversal

        public class LevelOrderTraversalSpiralOrder_M_13
        {
            public IList<IList<int>> SpiralOrder(TreeNode root)
            {
                IList<IList<int>> result = new List<IList<int>>();
                if (root == null) return result;

                Stack<TreeNode> currentLevel = new Stack<TreeNode>();
                Stack<TreeNode> nextLevel = new Stack<TreeNode>();
                currentLevel.Push(root);
                bool leftToRight = true;

                List<int> levelNodes = new List<int>();

                while (currentLevel.Count > 0)
                {
                    TreeNode node = currentLevel.Pop();
                    levelNodes.Add(node.val);

                    if (leftToRight)
                    {
                        if (node.left != null) nextLevel.Push(node.left);
                        if (node.right != null) nextLevel.Push(node.right);
                    }
                    else
                    {
                        if (node.right != null) nextLevel.Push(node.right);
                        if (node.left != null) nextLevel.Push(node.left);
                    }

                    if (currentLevel.Count == 0)
                    {
                        result.Add(new List<int>(levelNodes));
                        levelNodes.Clear();
                        leftToRight = !leftToRight;
                        Stack<TreeNode> temp = currentLevel;
                        currentLevel = nextLevel;
                        nextLevel = temp;
                    }
                }

                return result;
            }

            public static void LevelOrderTraversalSpiralOrderDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);
                root.right.left = new TreeNode(6);
                root.right.right = new TreeNode(7);

                LevelOrderTraversalSpiralOrder_M_13 tree = new LevelOrderTraversalSpiralOrder_M_13();
                var result = tree.SpiralOrder(root);

                Console.WriteLine("Spiral Order Traversal:");
                foreach (var level in result)
                {
                    Console.WriteLine(string.Join(", ", level));
                }
            }
        }
    }

    public class HeightOfBinaryTree_M_14
    {
        /*
        The height of a binary tree is the number of edges on the longest path from the root to a leaf node.
        To find the height of a binary tree, we can use a recursive approach where we calculate the height of the left and
        right subtrees and take the maximum of the two, adding one to account for the current node.

        Here's how you can implement this in C#:

        ### TreeNode Class

        First, define the `TreeNode` class to represent nodes in the binary tree:

        ### Height Calculation

        Implement the method to calculate the height of the binary tree:


        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **Height Method**:
           - Base case: If the node is `null`, return `-1`. If you consider the height of an empty tree as `0`, you can return `0` instead.
           - Recursively calculate the height of the left and right subtrees.
           - The height of the current node is the maximum of the heights of the left and right subtrees plus one.

        3. **Main Method**:
           - Creates a sample binary tree.
           - Calls the `Height` method to calculate and print the height of the binary tree.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited exactly once.
        - ** Space Complexity**: (O(H)), where (H) is the height of the binary tree.
        This space is used for the recursion stack during the depth-first traversal.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public int Height(TreeNode root)
        {
            if (root == null)
            {
                return -1; // If you consider the height of an empty tree as -1
            }

            int leftHeight = Height(root.left);
            int rightHeight = Height(root.right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static void HeightOfBinaryTreeDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            HeightOfBinaryTree_M_14 tree = new HeightOfBinaryTree_M_14();
            int height = tree.Height(root);
            Console.WriteLine("Height of the binary tree: " + height);
        }
    }

    public class DiameterOfBinaryTree_M_15
    {
        /*
        The diameter(or width) of a binary tree is the length of the longest path between any two nodes in a tree.
        This path may or may not pass through the root.The length of a path between two nodes is represented by the number of edges between them.

        To find the diameter of a binary tree, we need to find the maximum value of `(left_height + right_height + 2)` 
        for each node, where `left_height` and `right_height` are the heights of the left and right subtrees of the node.

        Explanation
        TreeNode Class: Represents a node in the binary tree with a constructor to initialize its value and children.

        DiameterOfBinaryTree Method:

        Initializes the diameter to 0.
        Calls the Height method to calculate the height of the tree and update the diameter during the process.
        Returns the diameter of the binary tree.
        Height Method:

        Base case: If the node is null, return -1 (or 0 if you consider the height of an empty tree as 0).
        Recursively calculates the height of the left and right subtrees.
        Updates the diameter to the maximum value of (left_height + right_height + 2) encountered so far.
        Returns the height of the subtree rooted at the current node.
        Main Method:

        Creates a sample binary tree.
        Calls the DiameterOfBinaryTree method to calculate and print the diameter of the binary tree.
        Complexity
        Time Complexity:
        O(N), where N is the number of nodes in the binary tree.Each node is visited exactly once.
        Space Complexity: 
        O(H), where H is the height of the binary tree.This space is used for the recursion stack during the depth-first traversal.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        private int diameter;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            diameter = 0;
            Height(root);
            return diameter;
        }

        private int Height(TreeNode node)
        {
            if (node == null)
            {
                return -1; // If you consider the height of an empty tree as -1
            }

            int leftHeight = Height(node.left);
            int rightHeight = Height(node.right);

            // Update the diameter if the path through the root is larger
            diameter = Math.Max(diameter, leftHeight + rightHeight + 2);

            // Return height of the subtree rooted at current node
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static void DiameterOfBinaryTreeDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            DiameterOfBinaryTree_M_15 tree = new DiameterOfBinaryTree_M_15();
            int diameter = tree.DiameterOfBinaryTree(root);
            Console.WriteLine("Diameter of the binary tree: " + diameter);
        }
    }

    public class CheckBinaryTreeIsHeightBalanced_M_16
    {
        /*
        A binary tree is considered height-balanced if, for every node in the tree, the difference in height between its left and right subtrees is at most one.
        To determine if a binary tree is height-balanced, we can use a recursive approach where we check the balance condition at each node and calculate the height of the subtrees.


        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **IsBalanced Method**:
           - Calls the `CheckHeight` method to determine if the tree is balanced.
           - Returns `true` if the tree is balanced, otherwise `false`.

        3. **CheckHeight Method**:
           - Base case: If the node is `null`, return `0` (height of an empty tree).
           - Recursively calculates the height of the left subtree.
             - If the left subtree is not balanced, return `-1`.
           - Recursively calculates the height of the right subtree.
             - If the right subtree is not balanced, return `-1`.
           - Checks if the current node is balanced by comparing the heights of the left and right subtrees.
             - If the difference is greater than `1`, return `-1` (tree is not balanced).
           - Returns the height of the subtree rooted at the current node.

        4. ** Main Method**:
           - Creates a sample binary tree.
           - Calls the `IsBalanced` method to check if the tree is height-balanced and prints the result.

        ### Complexity

        - ** Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited exactly once.
        - ** Space Complexity**: (O(H)), where (H) is the height of the binary tree.This space is used for the recursion stack during the depth-first traversal.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public bool IsBalanced(TreeNode root)
        {
            return CheckHeight(root) != -1;
        }

        private int CheckHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0; // Height of an empty tree is 0
            }

            int leftHeight = CheckHeight(node.left);
            if (leftHeight == -1) return -1; // Left subtree is not balanced

            int rightHeight = CheckHeight(node.right);
            if (rightHeight == -1) return -1; // Right subtree is not balanced

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1; // Current node is not balanced
            }

            return Math.Max(leftHeight, rightHeight) + 1; // Height of the current node
        }

        public static void CheckBinaryTreeIsHeightBalancedDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);
            root.left.left.left = new TreeNode(8);

            CheckBinaryTreeIsHeightBalanced_M_16 tree = new CheckBinaryTreeIsHeightBalanced_M_16();
            bool isBalanced = tree.IsBalanced(root);
            Console.WriteLine("Is the binary tree height-balanced? " + isBalanced);
        }
    }

    public class LowestCommonAncestorOf2Nodes_M_17
    {
        /*
        The Lowest Common Ancestor(LCA) of two nodes in a binary tree is defined as the deepest node that is an ancestor of both nodes.
        In other words, it's the lowest node in the tree that has both nodes as descendants (where we allow a node to be a descendant of itself).

        Here's how you can find the LCA in a binary tree in C#:

        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **LowestCommonAncestor Method**:
           - If the current node is `null`, or if it matches either `p` or `q`, return the current node.
           - Recursively call `LowestCommonAncestor` on the left and right children.
           - If both the left and right recursive calls return non-null values, it means `p` and `q` are found in different subtrees, and the current node is their LCA.
           - If only one of the recursive calls returns a non-null value, it means both `p` and `q` are located in the same subtree, so return the non-null value.

        3. **Main Method**:
           - Creates a sample binary tree.
           - Finds and prints the LCA of different pairs of nodes.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited exactly once in the worst case.
        - ** Space Complexity**: (O(H)), where (H) is the height of the binary tree.This space is used for the recursion stack during the depth-first traversal.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
            {
                return root;
            }

            return left ?? right;
        }

        public static void LowestCommonAncestorOf2NodesDriver()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(5);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(6);
            root.left.right = new TreeNode(2);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(8);
            root.left.right.left = new TreeNode(7);
            root.left.right.right = new TreeNode(4);

            LowestCommonAncestorOf2Nodes_M_17 tree = new LowestCommonAncestorOf2Nodes_M_17();
            TreeNode p = root.left; // Node 5
            TreeNode q = root.right; // Node 1
            TreeNode lca = tree.LowestCommonAncestor(root, p, q);
            Console.WriteLine("LCA of node 5 and node 1 is: " + lca.val);

            p = root.left; // Node 5
            q = root.left.right.right; // Node 4
            lca = tree.LowestCommonAncestor(root, p, q);
            Console.WriteLine("LCA of node 5 and node 4 is: " + lca.val);
        }
    }

    public class Check2BinaryTreeAreIdentical_M_18
    {
        /*
        To check if two binary trees are identical, you need to compare the structure and the values of the nodes in both trees.
        Two binary trees are considered identical if they have the same structure and the same node values at each corresponding position.


        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **IsIdentical Method**:
           - If both nodes (`root1` and `root2`) are `null`, they are identical, so return `true`.
           - If one of the nodes is `null` and the other is not, they are not identical, so return `false`.
           - If the values of `root1` and `root2` are not equal, they are not identical, so return `false`.
           - Recursively check the left and right subtrees for both nodes.Both subtrees must be identical for the trees to be considered identical.

        3. **Main Method**:
           - Creates two sample binary trees.
           - Calls the `IsIdentical` method to check if the two trees are identical and prints the result.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary trees.Each node is visited exactly once in the worst case.
        - ** Space Complexity**: (O(H)), where (H) is the height of the binary trees.This space is used for the recursion stack during the depth-first traversal.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public bool IsIdentical(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }
            if (root1 == null || root2 == null)
            {
                return false;
            }
            if (root1.val != root2.val)
            {
                return false;
            }
            return IsIdentical(root1.left, root2.left) && IsIdentical(root1.right, root2.right);
        }

        public static void Check2BinaryTreeAreIdenticalDriver()
        {
            TreeNode tree1 = new TreeNode(1);
            tree1.left = new TreeNode(2);
            tree1.right = new TreeNode(3);
            tree1.left.left = new TreeNode(4);
            tree1.left.right = new TreeNode(5);

            TreeNode tree2 = new TreeNode(1);
            tree2.left = new TreeNode(2);
            tree2.right = new TreeNode(3);
            tree2.left.left = new TreeNode(4);
            tree2.left.right = new TreeNode(5);

            Check2BinaryTreeAreIdentical_M_18 bt = new Check2BinaryTreeAreIdentical_M_18();
            bool identical = bt.IsIdentical(tree1, tree2);
            Console.WriteLine("Are the two binary trees identical? " + identical);
        }
    }

    public class ZigzagTraversalBinaryTree_E_19
    {
        /*
        Zigzag traversal of a binary tree involves traversing the nodes level by level
        but alternating the order of traversal between left-to-right and right-to-left for each level.


        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **ZigzagLevelOrder Method**:
           - Initialize an empty list `result` to store the levels of the traversal.
           - If the root is `null`, return the empty result.
           - Use a queue to perform level order traversal. Start by enqueuing the root.
           - Use a boolean variable `leftToRight` to keep track of the direction of traversal for each level.
           - For each level, dequeue all nodes in the queue, and depending on the value of `leftToRight`, 
        add node values to the current level's list either from the beginning or the end.
           - Enqueue the left and right children of the current node if they exist.
           - After processing each level, flip the `leftToRight` flag.

        3. **Main Method**:
           - Creates a sample binary tree.
           - Calls the `ZigzagLevelOrder` method to perform the traversal and prints the result.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited exactly once.
        - ** Space Complexity**: (O(N)) for the queue used in the level order traversal.The result list also takes (O(N)) space.
        The maximum number of nodes in the queue at any time is proportional to the width of the tree.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool leftToRight = true;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<int> level = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    if (leftToRight)
                    {
                        level.Add(currentNode.val);
                    }
                    else
                    {
                        level.Insert(0, currentNode.val);
                    }

                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }

                result.Add(level);
                leftToRight = !leftToRight;
            }

            return result;
        }

        public static void ZigzagTraversalBinaryTreeDriver()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            ZigzagTraversalBinaryTree_E_19 tree = new ZigzagTraversalBinaryTree_E_19();
            IList<IList<int>> result = tree.ZigzagLevelOrder(root);

            foreach (var level in result)
            {
                Console.WriteLine(string.Join(" ", level));
            }
        }
    }

    public class BoundaryTraversalBinaryTree_M_20
    {
        /*
        Boundary traversal of a binary tree involves traversing the nodes in the following order: left boundary, leaves, and then right boundary.
        This traversal should be in an anti-clockwise direction starting from the root.


        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **BoundaryTraversal Method**:
           - Initializes an empty list `result` to store the boundary nodes.
           - Adds the root node value to the result list.
           - Calls helper methods to get the left boundary, leaves, and right boundary in order.

        3. **GetLeftBoundary Method**:
           - Traverses the left boundary nodes, excluding leaf nodes and the root.
           - Adds node values to the result list as it traverses.

        4. **GetLeaves Method**:
           - Traverses all the leaf nodes (nodes with no children) and adds them to the result list.

        5. ** GetRightBoundary Method**:
           - Traverses the right boundary nodes, excluding leaf nodes and the root.
           - Adds node values to the result list after the recursive call to ensure the right boundary is added in reverse order.

        6. **Main Method**:
           - Creates a sample binary tree.
           - Calls the `BoundaryTraversal` method to perform the traversal and prints the result.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited exactly once.
        - ** Space Complexity**: (O(H)), where (H) is the height of the binary tree.This space is used for the recursion stack during the depth-first traversal. 

        The result list also takes (O(N)) space to store the boundary nodes.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public IList<int> BoundaryTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            result.Add(root.val);
            GetLeftBoundary(root.left, result);
            GetLeaves(root.left, result);
            GetLeaves(root.right, result);
            GetRightBoundary(root.right, result);

            return result;
        }

        private void GetLeftBoundary(TreeNode node, List<int> result)
        {
            if (node == null || (node.left == null && node.right == null))
                return;

            result.Add(node.val);

            if (node.left != null)
                GetLeftBoundary(node.left, result);
            else
                GetLeftBoundary(node.right, result);
        }

        private void GetLeaves(TreeNode node, List<int> result)
        {
            if (node == null) return;

            GetLeaves(node.left, result);

            if (node.left == null && node.right == null)
                result.Add(node.val);

            GetLeaves(node.right, result);
        }

        private void GetRightBoundary(TreeNode node, List<int> result)
        {
            if (node == null || (node.left == null && node.right == null))
                return;

            if (node.right != null)
                GetRightBoundary(node.right, result);
            else
                GetRightBoundary(node.left, result);

            result.Add(node.val);  // Add after child visit(reverse)
        }

        public static void BoundaryTraversalBinaryTreeDriver()
        {
            TreeNode root = new TreeNode(20);
            root.left = new TreeNode(8);
            root.right = new TreeNode(22);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(12);
            root.left.right.left = new TreeNode(10);
            root.left.right.right = new TreeNode(14);
            root.right.right = new TreeNode(25);

            BoundaryTraversalBinaryTree_M_20 tree = new BoundaryTraversalBinaryTree_M_20();
            IList<int> result = tree.BoundaryTraversal(root);

            Console.WriteLine(string.Join(" ", result));
        }
    }

    public class MaxPathSumBinaryTree_H_21
    {
        /*
        To find the maximum path sum in a binary tree, where the path can start and end at any node, you can use a recursive approach.
        The idea is to compute the maximum path sum that goes through each node and update the global maximum path sum during the traversal.


        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **MaxPathSum Method**:
           - Initializes the `maxSum` variable to `int.MinValue` to store the global maximum path sum.
           - Calls the `MaxPathSumHelper` method to compute the maximum path sum starting from the root.
           - Returns the `maxSum`.

        3. **MaxPathSumHelper Method**:
           - If the node is `null`, returns 0 (since a non-existing path contributes nothing to the path sum).
           - Recursively computes the maximum path sum for the left and right children, ignoring paths with negative sums(hence the `Math.Max(0, ...)`).
           - Updates the `maxSum` by considering the path that goes through the current node and includes both left and right children.
           - Returns the maximum path sum starting from the current node by considering the larger of the left and right child paths.

        4. ** Main Method**:
           - Creates a sample binary tree.
           - Calls the `MaxPathSum` method to find the maximum path sum and prints the result.

        ### Complexity

        - ** Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited exactly once.
        - ** Space Complexity**: (O(H)), where (H) is the height of the binary tree.
        This space is used for the recursion stack during the depth-first traversal.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private int maxSum;

        public int MaxPathSum(TreeNode root)
        {
            maxSum = int.MinValue;
            MaxPathSumHelper(root);
            return maxSum;
        }

        private int MaxPathSumHelper(TreeNode node)
        {
            if (node == null) return 0;

            // Compute the maximum path sum starting from the left and right children
            int left = Math.Max(0, MaxPathSumHelper(node.left));
            int right = Math.Max(0, MaxPathSumHelper(node.right));

            // Update the global maximum path sum
            maxSum = Math.Max(maxSum, left + right + node.val);

            // Return the maximum path sum starting from the current node
            return Math.Max(left, right) + node.val;
        }

        public static void MaxPathSumBinaryTreDriver()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            // Example of a tree with negative values
            // TreeNode root = new TreeNode(-10);
            // root.left = new TreeNode(9);
            // root.right = new TreeNode(20);
            // root.right.left = new TreeNode(15);
            // root.right.right = new TreeNode(7);

            MaxPathSumBinaryTree_H_21 tree = new MaxPathSumBinaryTree_H_21();
            int result = tree.MaxPathSum(root);

            Console.WriteLine("Maximum Path Sum: " + result);
        }
    }

    public class BinaryTreeFromPreorderAndInorderTraversal_H_22
    {
        /*
        To construct a binary tree from inorder and preorder traversal arrays, you can use a recursive approach.
        The preorder traversal array provides the root nodes in sequence, 
        while the inorder traversal array provides the relative positions of nodes in the left and right subtrees.

        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **BuildTree Method**:
           - Initializes a dictionary `inorderIndexMap` to store the indices of values in the inorder traversal array for quick lookup.
           - Sets the `preorderIndex` to 0, which keeps track of the current index in the preorder traversal array.
           - Calls the helper method `BuildTreeHelper` to construct the tree.

        3. **BuildTreeHelper Method**:
           - Takes `preorder`, `inorderStart`, and `inorderEnd` as parameters.
           - If `inorderStart` is greater than `inorderEnd`, returns `null` as there are no nodes to process.
           - Retrieves the current root value from the preorder array using `preorderIndex` and increments the `preorderIndex`.
           - Creates a new `TreeNode` with the root value.
           - Recursively builds the left and right subtrees using the indices from `inorderIndexMap`
        to determine the boundaries of the left and right subtrees.
           - Returns the constructed `TreeNode`.

        4. **PrintInOrder and PrintPreOrder Methods**:
           - Utility methods to print the inorder and preorder traversals of the constructed tree for verification.

        5. **Main Method**:
           - Defines sample inorder and preorder traversal arrays.
           - Constructs the binary tree using the `BuildTree` method.
           - Prints the inorder and preorder traversals of the constructed tree to verify correctness.

        ### Complexity

        - ** Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is processed once.
        - **Space Complexity**: \(O(N)\) for the dictionary storing the inorder indices and the recursion stack space.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private Dictionary<int, int> inorderIndexMap;
        private int preorderIndex;

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            inorderIndexMap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderIndexMap[inorder[i]] = i;
            }
            preorderIndex = 0;
            return BuildTreeHelper(preorder, 0, inorder.Length - 1);
        }

        private TreeNode BuildTreeHelper(int[] preorder, int inorderStart, int inorderEnd)
        {
            if (inorderStart > inorderEnd) return null;

            int rootValue = preorder[preorderIndex++];
            TreeNode root = new TreeNode(rootValue);

            root.left = BuildTreeHelper(preorder, inorderStart, inorderIndexMap[rootValue] - 1);
            root.right = BuildTreeHelper(preorder, inorderIndexMap[rootValue] + 1, inorderEnd);

            return root;
        }

        public void PrintInOrder(TreeNode root)
        {
            if (root == null) return;

            PrintInOrder(root.left);
            Console.Write(root.val + " ");
            PrintInOrder(root.right);
        }

        public void PrintPreOrder(TreeNode root)
        {
            if (root == null) return;

            Console.Write(root.val + " ");
            PrintPreOrder(root.left);
            PrintPreOrder(root.right);
        }

        public static void BinaryTreeFromPreorderAndInorderTraversalDriver()
        {
            int[] inorder = { 9, 3, 15, 20, 7 };
            int[] preorder = { 3, 9, 20, 15, 7 };

            BinaryTreeFromPreorderAndInorderTraversal_H_22 tree = new BinaryTreeFromPreorderAndInorderTraversal_H_22();
            TreeNode root = tree.BuildTree(preorder, inorder);

            Console.WriteLine("Inorder traversal of the constructed tree:");
            tree.PrintInOrder(root);
            Console.WriteLine("\nPreorder traversal of the constructed tree:");
            tree.PrintPreOrder(root);
        }
    }

    public class BinaryTreeFromInorderAndPostorderTraversal_H_23
    {
        /*
        To construct a binary tree from inorder and postorder traversal arrays, we can use a recursive approach 
        similar to the one used for inorder and preorder traversal arrays.
        The main difference is that in postorder traversal, the last element is the root of the current subtree.

        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **BuildTree Method**:
           - Initializes a dictionary `inorderIndexMap` to store the indices of values in the inorder traversal array for quick lookup.
           - Sets the `postorderIndex` to the last index of the postorder array, which keeps track of the current index in the postorder traversal array.
           - Calls the helper method `BuildTreeHelper` to construct the tree.

        3. **BuildTreeHelper Method**:
           - Takes `postorder`, `inorderStart`, and `inorderEnd` as parameters.
           - If `inorderStart` is greater than `inorderEnd`, returns `null` as there are no nodes to process.
           - Retrieves the current root value from the postorder array using `postorderIndex` and decrements the `postorderIndex`.
           - Creates a new `TreeNode` with the root value.
           - Recursively builds the right and left subtrees using the indices from `inorderIndexMap`
        to determine the boundaries of the right and left subtrees.
           - Returns the constructed `TreeNode`.

        4. **PrintInOrder and PrintPostOrder Methods**:
           - Utility methods to print the inorder and postorder traversals of the constructed tree for verification.

        5. **Main Method**:
           - Defines sample inorder and postorder traversal arrays.
           - Constructs the binary tree using the `BuildTree` method.
           - Prints the inorder and postorder traversals of the constructed tree to verify correctness.

        ### Complexity

        - ** Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is processed once.
        - **Space Complexity**: (O(N)) for the dictionary storing the inorder indices and the recursion stack space.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private Dictionary<int, int> inorderIndexMap;
        private int postorderIndex;

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            inorderIndexMap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderIndexMap[inorder[i]] = i;
            }
            postorderIndex = postorder.Length - 1;
            return BuildTreeHelper(postorder, 0, inorder.Length - 1);
        }

        private TreeNode BuildTreeHelper(int[] postorder, int inorderStart, int inorderEnd)
        {
            if (inorderStart > inorderEnd) return null;

            int rootValue = postorder[postorderIndex--];
            TreeNode root = new TreeNode(rootValue);

            root.right = BuildTreeHelper(postorder, inorderIndexMap[rootValue] + 1, inorderEnd);
            root.left = BuildTreeHelper(postorder, inorderStart, inorderIndexMap[rootValue] - 1);

            return root;
        }

        public void PrintInOrder(TreeNode root)
        {
            if (root == null) return;

            PrintInOrder(root.left);
            Console.Write(root.val + " ");
            PrintInOrder(root.right);
        }

        public void PrintPostOrder(TreeNode root)
        {
            if (root == null) return;

            PrintPostOrder(root.left);
            PrintPostOrder(root.right);
            Console.Write(root.val + " ");
        }

        public static void BinaryTreeFromInorderAndPostorderTraversalDriver()
        {
            int[] inorder = { 9, 3, 15, 20, 7 };
            int[] postorder = { 9, 15, 7, 20, 3 };

            BinaryTreeFromInorderAndPostorderTraversal_H_23 tree = new BinaryTreeFromInorderAndPostorderTraversal_H_23();
            TreeNode root = tree.BuildTree(inorder, postorder);

            Console.WriteLine("Inorder traversal of the constructed tree:");
            tree.PrintInOrder(root);
            Console.WriteLine("\nPostorder traversal of the constructed tree:");
            tree.PrintPostOrder(root);
        }
    }

    public class IsBinaryTreeSymmetric_M_24
    {
        /*
        To determine whether a binary tree is symmetric, we need to check if the left subtree is a mirror reflection of the right subtree.
        This can be achieved using a recursive approach or an iterative approach.

        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **IsSymmetric Method (Recursive Approach)**:
           - Calls the `IsMirror` helper method with the left and right children of the root.
           - The `IsMirror` method checks if two trees are mirrors of each other:
             - Both nodes being null means they are mirrors.
             - If one node is null and the other is not, they are not mirrors.
             - If the values of the nodes are different, they are not mirrors.
             - Recursively checks the left subtree of the left node with the right subtree of the right node and
        the right subtree of the left node with the left subtree of the right node.

        3. **IsSymmetric Method (Iterative Approach)**:
           - Uses a queue to perform a level-order traversal while checking if the tree is symmetric.
           - Enqueues pairs of nodes to be compared.
           - For each pair, if both nodes are null, continues to the next pair.
           - If one node is null and the other is not, returns false.
           - If the values of the nodes are different, returns false.
           - Enqueues the children nodes in the order needed to compare the left and right subtrees.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited once.
        - **Space Complexity**: 
          - **Recursive Approach**: (O(H)), where (H) is the height of the tree, due to the recursion stack.
          - ** Iterative Approach**: (O(N)), where (N) is the number of nodes, due to the queue used for level-order traversal.
        */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class IsBinaryTreeSymmetricRecursion_M_24
        {
            public bool IsSymmetricRecursion(TreeNode root)
            {
                if (root == null) return true;
                return IsMirrorRecursion(root.left, root.right);
            }

            private bool IsMirrorRecursion(TreeNode left, TreeNode right)
            {
                if (left == null && right == null) return true;
                if (left == null || right == null) return false;
                if (left.val != right.val) return false;

                return IsMirrorRecursion(left.left, right.right) && IsMirrorRecursion(left.right, right.left);
            }

            public static void IsBinaryTreeSymmetricRecursionDriver()
            {
                IsBinaryTreeSymmetricRecursion_M_24 tree = new IsBinaryTreeSymmetricRecursion_M_24();

                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(2);
                root.left.left = new TreeNode(3);
                root.left.right = new TreeNode(4);
                root.right.left = new TreeNode(4);
                root.right.right = new TreeNode(3);

                Console.WriteLine(tree.IsSymmetricRecursion(root) ? "The tree is symmetric." : "The tree is not symmetric.");
            }
        }

        public class IsBinaryTreeSymmetricIteration_M_24
        {
            public bool IsSymmetricIteration(TreeNode root)
            {
                if (root == null) return true;

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root.left);
                queue.Enqueue(root.right);

                while (queue.Count > 0)
                {
                    TreeNode left = queue.Dequeue();
                    TreeNode right = queue.Dequeue();

                    if (left == null && right == null) continue;
                    if (left == null || right == null) return false;
                    if (left.val != right.val) return false;

                    queue.Enqueue(left.left);
                    queue.Enqueue(right.right);
                    queue.Enqueue(left.right);
                    queue.Enqueue(right.left);
                }

                return true;
            }

            public static void IsBinaryTreeSymmetricIterationDriver()
            {
                IsBinaryTreeSymmetricIteration_M_24 tree = new IsBinaryTreeSymmetricIteration_M_24();

                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(2);
                root.left.left = new TreeNode(3);
                root.left.right = new TreeNode(4);
                root.right.left = new TreeNode(4);
                root.right.right = new TreeNode(3);

                Console.WriteLine(tree.IsSymmetricIteration(root) ? "The tree is symmetric." : "The tree is not symmetric.");
            }
        }

    }

    public class FlatenningOfBinaryTree_H_25
    {
        /*
        Flattening a binary tree to a linked list means restructuring the tree into a "linked list" in the same order
        as a pre-order traversal.Each node's right child points to the next node in the pre-order sequence,
        and the left child is set to null.

       ### Explanation

       1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

       2. **Flatten Method (Recursive Approach)**:
          - Uses a `prev` pointer to keep track of the previous node in the traversal.
          - Traverses the tree in reverse pre-order (right -> left -> root).
          - Sets the current node's right child to `prev` and left child to null.
          - Updates `prev` to the current node.

       3. **Flatten Method (Iterative Approach)**:
          - Uses a stack to perform a pre-order traversal iteratively.
          - Pushes the right and then the left child to the stack to ensure the left child is processed first.
          - Sets the current node's right child to the next node in the stack.
          - Sets the current node's left child to null.

       4. **Main Method**:
          - Defines a sample binary tree.
          - Calls the `Flatten` method to flatten the tree.
          - Prints the flattened tree to verify the result.

       ### Complexity

       - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is processed once.
       - **Space Complexity**: 
         - **Recursive Approach**: (O(H)), where (H) is the height of the tree, due to the recursion stack.
         - ** Iterative Approach**: (O(N)), where (N) is the number of nodes, due to the stack used for traversal.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class FlatenningOfBinaryTreeRecursion_H_25
        {
            private TreeNode prev = null;

            public void Flatten(TreeNode root)
            {
                if (root == null) return;

                Flatten(root.right);
                Flatten(root.left);

                root.right = prev;
                root.left = null;
                prev = root;
            }

            public static void FlatenningOfBinaryTreeRecursionDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(5);
                root.left.left = new TreeNode(3);
                root.left.right = new TreeNode(4);
                root.right.right = new TreeNode(6);

                FlatenningOfBinaryTreeRecursion_H_25 tree = new FlatenningOfBinaryTreeRecursion_H_25();
                tree.Flatten(root);

                TreeNode curr = root;
                while (curr != null)
                {
                    Console.Write(curr.val + " -> ");
                    curr = curr.right;
                }
                Console.WriteLine("null");
            }
        }

        public class FlatenningOfBinaryTreeIteration_H_25
        {
            public void Flatten(TreeNode root)
            {
                if (root == null) return;

                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);

                while (stack.Count > 0)
                {
                    TreeNode curr = stack.Pop();

                    if (curr.right != null)
                    {
                        stack.Push(curr.right);
                    }
                    if (curr.left != null)
                    {
                        stack.Push(curr.left);
                    }

                    if (stack.Count > 0)
                    {
                        curr.right = stack.Peek();
                    }

                    curr.left = null;
                }
            }

            public static void FlatenningOfBinaryTreeIterationDriver()
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(5);
                root.left.left = new TreeNode(3);
                root.left.right = new TreeNode(4);
                root.right.right = new TreeNode(6);

                FlatenningOfBinaryTreeIteration_H_25 tree = new FlatenningOfBinaryTreeIteration_H_25();
                tree.Flatten(root);

                TreeNode curr = root;
                while (curr != null)
                {
                    Console.Write(curr.val + " -> ");
                    curr = curr.right;
                }
                Console.WriteLine("null");
            }
        }

    }

    public class CheckBinaryTreeMirrorOfItself_M_26
    {
        /*
        To check if a binary tree is a mirror of itself(i.e., symmetric), we need to verify that the left subtree
        is a mirror reflection of the right subtree.This can be achieved using either a recursive or an iterative approach.


            ### Explanation

            1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

            2. **IsSymmetric Method (Recursive Approach)**:
               - Calls the `IsMirror` helper method with the left and right children of the root.
               - The `IsMirror` method checks if two trees are mirrors of each other:
                 - Both nodes being null means they are mirrors.
                 - If one node is null and the other is not, they are not mirrors.
                 - If the values of the nodes are different, they are not mirrors.
                 - Recursively checks the left subtree of the left node with the right subtree of the right node and
                the right subtree of the left node with the left subtree of the right node.

            3. **IsSymmetric Method (Iterative Approach)**:
               - Uses a queue to perform a level-order traversal while checking if the tree is symmetric.
               - Enqueues pairs of nodes to be compared.
               - For each pair, if both nodes are null, continues to the next pair.
               - If one node is null and the other is not, returns false.
               - If the values of the nodes are different, returns false.
               - Enqueues the children nodes in the order needed to compare the left and right subtrees.

            ### Complexity

            - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited once.
            - **Space Complexity**: 
              - **Recursive Approach**: (O(H)), where (H) is the height of the tree, due to the recursion stack.
              - ** Iterative Approach**: (O(N)), where (N) is the number of nodes, due to the queue used for level-order traversal.
         */

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        //### Symmetric Check (Recursive Approach)

        public class CheckBinaryTreeMirrorOfItselfRecursion_M_26
        {
            public bool IsSymmetricRecursion(TreeNode root)
            {
                if (root == null) return true;
                return IsMirror(root.left, root.right);
            }

            private bool IsMirror(TreeNode left, TreeNode right)
            {
                if (left == null && right == null) return true;
                if (left == null || right == null) return false;
                if (left.val != right.val) return false;

                return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
            }

            public static void CheckBinaryTreeMirrorOfItselfRecursionDriver()
            {
                CheckBinaryTreeMirrorOfItselfRecursion_M_26 tree = new CheckBinaryTreeMirrorOfItselfRecursion_M_26();

                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(2);
                root.left.left = new TreeNode(3);
                root.left.right = new TreeNode(4);
                root.right.left = new TreeNode(4);
                root.right.right = new TreeNode(3);

                Console.WriteLine(tree.IsSymmetricRecursion(root) ? "The tree is symmetric / mirror of itself." 
                    : "The tree is not symmetric / mirror of itself.");
            }
        }

        // Iteration Approach

        public class CheckBinaryTreeMirrorOfItselfIteration_M_26
        {
            public bool IsSymmetricIteration(TreeNode root)
            {
                if (root == null) return true;

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root.left);
                queue.Enqueue(root.right);

                while (queue.Count > 0)
                {
                    TreeNode left = queue.Dequeue();
                    TreeNode right = queue.Dequeue();

                    if (left == null && right == null) continue;
                    if (left == null || right == null) return false;
                    if (left.val != right.val) return false;

                    queue.Enqueue(left.left);
                    queue.Enqueue(right.right);
                    queue.Enqueue(left.right);
                    queue.Enqueue(right.left);
                }

                return true;
            }

            public static void CheckBinaryTreeMirrorOfItselfIterationDriver()
            {
                CheckBinaryTreeMirrorOfItselfIteration_M_26 tree = new CheckBinaryTreeMirrorOfItselfIteration_M_26();

                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(2);
                root.left.left = new TreeNode(3);
                root.left.right = new TreeNode(4);
                root.right.left = new TreeNode(4);
                root.right.right = new TreeNode(3);

                Console.WriteLine(tree.IsSymmetricIteration(root) ? "The tree is symmetric / mirror of itself."
                    : "The tree is not symmetric / mirror of itself.");
            }
        }
    }

    public class ChildrenSumPropertyInBinaryTree_H_27
    {
        /*
        The Children Sum Property for a binary tree states that for every node of the tree,
        the value of the node must be equal to the sum of the values of its left and right children(if they exist).

        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **IsChildrenSumProperty Method**:
           - Checks if the root is null or if it's a leaf node (no children). If so, it returns true because a null node or a leaf node trivially satisfies the property.
           - Retrieves the values of the left and right children.If a child is null, its value is considered 0.
           - Checks if the value of the current node is equal to the sum of its children.If true, it recursively checks the left and right subtrees.
           - Returns true if all nodes satisfy the children sum property; otherwise, returns false.

        ### Complexity

        - ** Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited once.
        - **Space Complexity**: (O(H)), where (H) is the height of the tree, due to the recursion stack.

        ### Example Walkthrough

        Consider the following binary tree:

        ```
               10
              /  
             8    2
            /     
           3   5    2
        ```

        1. ** Root Node(10)**:
           - Left Child Value: 8
           - Right Child Value: 2
           - Sum of Children: 8 + 2 = 10 (Matches the root node value)
   
        2. ** Left Subtree Root Node(8)**:
           - Left Child Value: 3
           - Right Child Value: 5
           - Sum of Children: 3 + 5 = 8 (Matches the node value)

        3. ** Right Subtree Root Node(2)**:
           - Left Child Value: 0 (No left child)
           - Right Child Value: 2
           - Sum of Children: 0 + 2 = 2 (Matches the node value)

        4. ** Leaf Nodes(3, 5, 2)**:
           - All leaf nodes trivially satisfy the children sum property as they have no children.

        Thus, the tree satisfies the children sum property.
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

         //### Check Children Sum Property (Recursive Approach)

        public bool IsChildrenSumProperty(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
                return true;

            int leftValue = (root.left != null) ? root.left.val : 0;
            int rightValue = (root.right != null) ? root.right.val : 0;

            if (root.val == leftValue + rightValue &&
                IsChildrenSumProperty(root.left) &&
                IsChildrenSumProperty(root.right))
            {
                return true;
            }
            return false;
        }

        public static void ChildrenSumPropertyInBinaryTreeDriver()
        {
            ChildrenSumPropertyInBinaryTree_H_27 tree = new ChildrenSumPropertyInBinaryTree_H_27();

            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(8);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(5);
            root.right.right = new TreeNode(2);

            Console.WriteLine(tree.IsChildrenSumProperty(root) ? "The tree satisfies the children sum property." : "The tree does not satisfy the children sum property.");
        }
    }

    
}
