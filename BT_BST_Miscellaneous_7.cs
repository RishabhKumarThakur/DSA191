using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static GreedyAlgorithm.NMeetingInOneRoom_M_1;
using static Heaps.MaxHeapAndMinHeap_M_1;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinaryTreesMisellaneous
{
    public class BinaryTreeToDLL_M_1
    {
        /*
        To convert a binary tree to a doubly linked list(DLL), we need to traverse the tree in an inorder fashion
        and link the nodes as we go.The left pointer of each node in the binary tree will be used
        as the previous pointer in the DLL, and the right pointer will be used as the next pointer in the DLL.


        ### Explanation

        1. ** TreeNode Class**: Represents a node in the binary tree with a constructor to initialize its value and children.

        2. **ConvertToDLL Method**:
           - This method converts the binary tree to a doubly linked list in an inorder fashion.
           - The `prev` pointer is used to keep track of the previous node in the inorder traversal.
           - The method first recursively converts the left subtree and sets the head of the DLL if `prev` is null.
           - It then links the current node with the previous node using the left and right pointers.
           - Finally, it recursively converts the right subtree.

        3. **PrintDLL Method**:
           - This method prints the doubly linked list starting from the head node.

        4. **Main Method**:
           - Constructs a binary tree.
           - Converts the binary tree to a doubly linked list.
           - Prints the resulting doubly linked list.

        ### Complexity

        - **Time Complexity**: (O(N)), where (N) is the number of nodes in the binary tree.Each node is visited once.
        - **Space Complexity**: (O(H)), where (H) is the height of the tree, due to the recursion stack.

        ### Example Walkthrough

        Consider the following binary tree:

        ```
               10
              /  \
             12   15
            /  \  /
           25 30 36
        ```

        The inorder traversal of this tree is: 25, 12, 30, 10, 36, 15.

        The resulting doubly linked list will be: 25 <-> 12 <-> 30 <-> 10 <-> 36 <-> 15.

        When you run the code, it will output:

        ```
        Doubly Linked List:
        25 12 30 10 36 15
        ```

        This confirms that the binary tree has been successfully converted to a doubly linked list in inorder sequence.
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

        private TreeNode prev = null;

        public TreeNode ConvertToDLL(TreeNode root)
        {
            if (root == null) return null;

            TreeNode head = ConvertToDLL(root.left);

            if (prev == null)
            {
                head = root; // This is the leftmost node, which becomes the head of the DLL
            }
            else
            {
                root.left = prev;
                prev.right = root;
            }

            prev = root;

            ConvertToDLL(root.right);

            return head;
        }

        public static void PrintDLL(TreeNode head)
        {
            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.right;
            }
            Console.WriteLine();
        }

        public static void BinaryTreeToDLLDriver()
        {
            BinaryTreeToDLL_M_1 converter = new BinaryTreeToDLL_M_1();

            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(12);
            root.right = new TreeNode(15);
            root.left.left = new TreeNode(25);
            root.left.right = new TreeNode(30);
            root.right.left = new TreeNode(36);
            TreeNode head = converter.ConvertToDLL(root);
            Console.WriteLine("Doubly Linked List:");
            PrintDLL(head);
        }
    }

    public class MedianInAStreamOfRunningIntegerUsingSelfBalancingBST_H_2
    {
        /*
        Finding the median in a stream of integers efficiently can be achieved using a data structure that supports fast insertion
        and removal while keeping elements in order.Using a self-balancing binary search tree(BST) is one way to achieve this. 
        However, a more common approach is using two heaps(a max heap for the lower half of the numbers and a min heap for the upper half),
        which offers better time complexity.Since you asked specifically for a binary tree-based approach, we'll use a balanced BST.

        Here, we can use C#'s `SortedSet` class, which is implemented as a self-balancing BST, to maintain the order of the elements. 
        This class can efficiently manage insertions, deletions, and lookups.

        ### Approach

        1. ** Data Structure**: We use two `SortedSet`s to keep track of the numbers.One `SortedSet` will store
        the smaller half of the numbers and the other will store the larger half.
        2. **Balancing**: Ensure both halves are balanced such that the difference in their sizes is at most 1.
        3. **Median Calculation**: If both sets have the same size, the median is the average of the largest number 
        from the lower half and the smallest number from the upper half. If the sizes differ, the median is the root of the larger set.

        ### Explanation

        1. ** MedianFinder Class**:
           - `lowerHalf` and `upperHalf` are `SortedSet<int>` to maintain order and balance.
           - `lowerHalfCount` and `upperHalfCount` are dictionaries to handle duplicates,
        as `SortedSet` does not handle duplicates directly.
   
        2. ** AddNum Method**:
           - Adds the number to the appropriate set.
           - Balances the sets to ensure their size difference is at most 1.
   
        3. ** BalanceHeaps Method**:
           - Balances the sizes of the two sets by moving elements between them if necessary.

        4. ** FindMedian Method**:
           - Returns the median based on the sizes of the two sets.

        5. ** Main Method**:
           - Demonstrates how to use the `MedianFinder` with a stream of numbers.

        ### Complexity

        - ** Time Complexity**: (O(log N)) for insertion and deletion due to `SortedSet` operations.
        - ** Space Complexity**: (O(N)) to store the numbers.

        This approach ensures an efficient median finding in a stream of integers using a balanced BST-like structure.
        */

        private SortedSet<int> lowerHalf;
        private SortedSet<int> upperHalf;
        private Dictionary<int, int> lowerHalfCount;
        private Dictionary<int, int> upperHalfCount;

        public MedianInAStreamOfRunningIntegerUsingSelfBalancingBST_H_2()
        {
            lowerHalf = new SortedSet<int>();
            upperHalf = new SortedSet<int>();
            lowerHalfCount = new Dictionary<int, int>();
            upperHalfCount = new Dictionary<int, int>();
        }

        public void AddNum(int num)
        {
            if (lowerHalf.Count == 0 || num <= lowerHalf.Max)
            {
                lowerHalf.Add(num);
                if (!lowerHalfCount.ContainsKey(num)) lowerHalfCount[num] = 0;
                lowerHalfCount[num]++;
            }
            else
            {
                upperHalf.Add(num);
                if (!upperHalfCount.ContainsKey(num)) upperHalfCount[num] = 0;
                upperHalfCount[num]++;
            }

            BalanceHeaps();
        }

        private void BalanceHeaps()
        {
            if (lowerHalf.Count > upperHalf.Count + 1)
            {
                int maxOfLowerHalf = lowerHalf.Max;
                lowerHalf.Remove(maxOfLowerHalf);
                lowerHalfCount[maxOfLowerHalf]--;
                if (lowerHalfCount[maxOfLowerHalf] == 0) lowerHalfCount.Remove(maxOfLowerHalf);

                upperHalf.Add(maxOfLowerHalf);
                if (!upperHalfCount.ContainsKey(maxOfLowerHalf)) upperHalfCount[maxOfLowerHalf] = 0;
                upperHalfCount[maxOfLowerHalf]++;
            }
            else if (upperHalf.Count > lowerHalf.Count)
            {
                int minOfUpperHalf = upperHalf.Min;
                upperHalf.Remove(minOfUpperHalf);
                upperHalfCount[minOfUpperHalf]--;
                if (upperHalfCount[minOfUpperHalf] == 0) upperHalfCount.Remove(minOfUpperHalf);

                lowerHalf.Add(minOfUpperHalf);
                if (!lowerHalfCount.ContainsKey(minOfUpperHalf)) lowerHalfCount[minOfUpperHalf] = 0;
                lowerHalfCount[minOfUpperHalf]++;
            }
        }

        public double FindMedian()
        {
            if (lowerHalf.Count > upperHalf.Count)
            {
                return lowerHalf.Max;
            }
            else
            {
                return (lowerHalf.Max + upperHalf.Min) / 2.0;
            }
        }

        public static void MedianInAStreamOfRunningIntegerUsingSelfBalancingBSTDriver()
        {
            MedianInAStreamOfRunningIntegerUsingSelfBalancingBST_H_2 medianFinder = new MedianInAStreamOfRunningIntegerUsingSelfBalancingBST_H_2();
            int[] stream = { 5, 15, 1, 3 };
            Console.WriteLine($"Integers in stream: {string.Join(", ", stream)}");
            foreach (var num in stream)
            {
                medianFinder.AddNum(num);
                Console.WriteLine("Median: " + medianFinder.FindMedian());
            }
        }
    }

    public class KthLargestInStreamOfIntegersUsingSelfBalancingBST_E_3
    {
        /*
        To find the K-th largest element in a stream of integers using a binary tree structure,
        we can use a self-balancing binary search tree(BST) such as a `SortedSet` in C#. 
        This will allow us to maintain the elements in a sorted order and efficiently find the K-th largest element.

        Here’s a detailed approach and implementation:

        ### Approach

        1. ** Data Structure**: Use a `SortedSet` to store the integers from the stream.
        This will help keep the elements in sorted order and allow for efficient insertion, deletion, and K-th largest element retrieval.
        2. **Size Management**: Ensure the `SortedSet` does not grow beyond K elements. 
        If it exceeds, remove the smallest element to keep the size manageable.
        3. **K-th Largest Calculation**: The K-th largest element will be the smallest element in the `SortedSet`
        if it contains exactly K elements.

        ### Explanation

        1. ** KthLargest Class**:
           - `minHeap` is a `SortedSet<int>` that maintains the K largest elements.
           - `k` is the K-th position we are interested in.

        2. **Constructor**:
           - Initializes the `SortedSet` and populates it with the initial stream of numbers.
           - Ensures the `SortedSet` size does not exceed K by maintaining only the largest K elements.

        3. **Add Method**:
           - Adds a new number to the `SortedSet`.
           - If the `SortedSet` exceeds K elements, it removes the smallest element to maintain only the K largest elements.
           - Returns the K-th largest element, which is the smallest element in the `SortedSet` when its size is exactly K.

        4. **Main Method**:
           - Demonstrates the usage of the `KthLargest` class by adding numbers to the stream and
        retrieving the K-th largest element after each addition.

        ### Complexity

        - **Time Complexity**: 
          - Insertion and deletion in `SortedSet` are (O(log K)), where K is the number of elements it maintains.
          - The `Add` method is (O(log K)) because it potentially involves an insertion and a deletion.
        - ** Space Complexity**: (O(K)), as the `SortedSet` stores only the K largest elements.

        This solution efficiently maintains the K largest elements and allows for fast retrieval
        of the K-th largest element in a stream of integers using a binary tree structure.

        */


        private SortedSet<int> minHeap;
        private int k;

        public KthLargestInStreamOfIntegersUsingSelfBalancingBST_E_3(int k, int[] nums)
        {
            this.k = k;
            minHeap = new SortedSet<int>();

            foreach (var num in nums)
            {
                Add(num);
            }
        }

        public int Add(int num)
        {
            minHeap.Add(num);
            if (minHeap.Count > k)
            {
                minHeap.Remove(minHeap.Min);
            }
            return minHeap.Min;
        }

        public static void KthLargestInStreamOfIntegersUsingSelfBalancingBSTDriver()
        {
            int k = 3;
            int[] stream = { 4, 5, 8, 2 };
            Console.WriteLine($"Integers in stream: {string.Join(", ", stream)}");
            Console.WriteLine($"K value: {k}");
            KthLargestInStreamOfIntegersUsingSelfBalancingBST_E_3 kthLargest = new KthLargestInStreamOfIntegersUsingSelfBalancingBST_E_3(k, stream);

            Console.WriteLine(kthLargest.Add(3));  // returns 4
            Console.WriteLine(kthLargest.Add(5));  // returns 5
            Console.WriteLine(kthLargest.Add(10)); // returns 5
            Console.WriteLine(kthLargest.Add(9));  // returns 8
            Console.WriteLine(kthLargest.Add(4));  // returns 8
        }
    }

    public class DistinctNumbersInWindowUsingSelfBalancingBST_M_4
    {
        /*
        To find the count of distinct numbers in each window of size `k` in a stream of integers, 
        we can use a self-balancing binary search tree(BST) such as `SortedDictionary` or `SortedSet` in C#.
        For maintaining the frequency of each element in the current window, we'll also use a `Dictionary` (hashmap).

        ### Approach
        1. ** Data Structures**:
           - `SortedDictionary<int, int>`: To maintain the count of each element in the current window.
           - `SortedSet<int>`: To efficiently keep track of the distinct elements in the current window.

        2. ** Sliding Window**:
           - Use a sliding window technique to move through the array.
           - Add the new element entering the window and remove the element leaving the window.
           - Maintain the count of distinct elements in the current window.


        ### Explanation

        1. ** CountDistinctNumbers Method**:
           - Initialize a `Dictionary<int, int>` (`freqMap`) to keep track of the frequency of each element in the current window.
           - Initialize the distinct count for the first window of size `k`.
           - Slide the window through the array by updating the frequency map and the distinct count.
           - Add the distinct count for each window to the result list.

        2. **Main Method**:
           - Demonstrates the usage of the `CountDistinctNumbers` method by passing an example array and window size.
           - Prints the count of distinct numbers in each window.

        ### Complexity

        - **Time Complexity**:
          - The sliding window moves through the array in (O(N)) time, where (N) is the length of the array.
          - Inserting and removing elements from the `Dictionary` takes (O(1)) on average.
          - Overall time complexity: (O(N)).

        - ** Space Complexity**:
          - The `Dictionary` and `SortedSet` store up to (O(K)) elements, where (K) is the window size.
          - Overall space complexity: (O(K)).

        This solution efficiently finds the count of distinct numbers in each window of size `k`
        using a combination of a dictionary and a self-balancing binary search tree structure.

        */
        public static List<int> CountDistinctNumbers(int[] nums, int k)
        {
            List<int> result = new List<int>();
            if (nums == null || nums.Length < k)
            {
                return result;
            }

            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            int distinctCount = 0;

            // Initialize the first window
            for (int i = 0; i < k; i++)
            {
                if (freqMap.ContainsKey(nums[i]))
                {
                    freqMap[nums[i]]++;
                }
                else
                {
                    freqMap[nums[i]] = 1;
                    distinctCount++;
                }
            }
            result.Add(distinctCount);

            // Slide the window
            for (int i = k; i < nums.Length; i++)
            {
                // Remove the element going out of the window
                int outElem = nums[i - k];
                freqMap[outElem]--;
                if (freqMap[outElem] == 0)
                {
                    freqMap.Remove(outElem);
                    distinctCount--;
                }

                // Add the new element coming into the window
                int inElem = nums[i];
                if (freqMap.ContainsKey(inElem))
                {
                    freqMap[inElem]++;
                }
                else
                {
                    freqMap[inElem] = 1;
                    distinctCount++;
                }

                result.Add(distinctCount);
            }

            return result;
        }

        public static void DistinctNumbersInWindowUsingSelfBalancingBSTDriver()
        {
            int[] nums = { 1, 2, 1, 3, 4, 2, 3 };
            int k = 4;
            Console.WriteLine($"Integer array: {string.Join(", ", nums)}");
            Console.WriteLine($"K value: {k}");
            List<int> distinctCounts = CountDistinctNumbers(nums, k);

            Console.WriteLine("Distinct counts in each window:");
            foreach (var count in distinctCounts)
            {
                Console.WriteLine(count);
            }
        }
    }

    public class KthLargestElementUsingSelfBalancingBST_E_5
    {
        /*
        To find the K-th largest element in an unsorted array using a binary tree approach,
        we can use a self-balancing binary search tree.In C#, the `SortedSet` or `SortedDictionary`
        can be used to maintain a dynamically updated sorted order of elements as we process the array.

        ### Approach

        1. **Data Structure**:
           - Use a `SortedDictionary<int, int>` to store the elements and their frequencies.
           - Maintain the size of the dictionary to not exceed `K` elements.
           - If the dictionary exceeds `K` elements, remove the smallest element (to keep only the K largest elements).

        2. ** K-th Largest Calculation**:
           - The K-th largest element is the smallest element in the dictionary when it contains exactly `K` elements.


        ### Explanation

        1. ** KthLargestElement Class**:
           - `sortedDict` is a `SortedDictionary<int, int>` that maintains the K largest elements and their counts.
           - `k` is the K-th position we are interested in.

        2. ** Add Method**:
           - Adds a new number to the `SortedDictionary`.
           - If the `SortedDictionary` exceeds K elements, it removes the smallest element to maintain only the K largest elements.
           - It handles the frequency of elements to ensure the correct removal of elements when the size exceeds K.

        3. **GetKthLargest Method**:
           - Returns the K-th largest element, which is the smallest element in the `SortedDictionary` when its size is exactly K.

        4. **Main Method**:
           - Demonstrates the usage of the `KthLargestElement` class by passing an example array and finding the K-th largest element.

        ### Complexity

        - ** Time Complexity**:
          - Insertion and deletion in `SortedDictionary` are (O(log K)) since we are maintaining at most K elements.
          - The overall time complexity for processing the entire array is (O(N log K)), where (N) is the length of the array.

        - ** Space Complexity**:
          - The space complexity is (O(K)), as the `SortedDictionary` stores only the K largest elements.

        This solution efficiently finds the K-th largest element in an unsorted array using a self-balancing binary search tree structure.
        */



        private SortedDictionary<int, int> sortedDict;
        private int k;

        public KthLargestElementUsingSelfBalancingBST_E_5(int k)
        {
            this.k = k;
            this.sortedDict = new SortedDictionary<int, int>();
        }

        public void Add(int num)
        {
            if (sortedDict.ContainsKey(num))
            {
                sortedDict[num]++;
            }
            else
            {
                sortedDict[num] = 1;
            }

            if (sortedDict.Count > k)
            {
                var firstElement = sortedDict.First();
                if (firstElement.Value == 1)
                {
                    sortedDict.Remove(firstElement.Key);
                }
                else
                {
                    sortedDict[firstElement.Key]--;
                }
            }
        }

        public int GetKthLargest()
        {
            return sortedDict.First().Key;
        }

        public static void KthLargestElementUsingSelfBalancingBSTDriver()
        {
            int[] nums = { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            Console.WriteLine($"Integer array: {string.Join(", ", nums)}");
            Console.WriteLine($"K value: {k}");
            KthLargestElementUsingSelfBalancingBST_E_5 kthLargest = new KthLargestElementUsingSelfBalancingBST_E_5(k);

            foreach (var num in nums)
            {
                kthLargest.Add(num);
            }
            Console.WriteLine("The K-th largest element is: " + kthLargest.GetKthLargest());
        }
    }

    public class FloodFillAlgorithmUsingBinaryTree_H_6
    {
        /*
        The Flood Fill algorithm is commonly used in image processing to fill connected, similarly-colored areas.
        However, using a binary tree structure for Flood Fill is unconventional because the algorithm typically operates on a 2D grid.

        To adapt the Flood Fill algorithm using a tree-like structure, we can model the grid as a tree of nodes,
        where each node represents a pixel and has links to its neighboring pixels.Each node will store its color, 
        and we will traverse this tree to apply the flood fill.

        ### Approach

        1. **TreeNode Class**:
           - Each node represents a pixel with links to its neighboring pixels (up, down, left, right).
           - Each node has a color value.

        2. **FloodFill Method**:
           - Use a recursive approach to traverse and fill the connected nodes with the new color.

        ### Explanation

        1. ** TreeNode Class**:
           - Represents a pixel with properties for the color and links to neighboring pixels.

        2. ** ApplyFloodFill Method**:
           - Checks if the node is null.
           - Initializes the flood fill process by comparing the original color with the new color to prevent redundant work.

        3. ** FloodFillRecursive Method**:
           - Recursively fills the neighboring nodes if they have the same original color.

        4. **Main Method**:
           - Demonstrates the usage of the `FloodFill` class by creating a small grid of nodes and applying the flood fill algorithm.

        ### Complexity

        - **Time Complexity**:
          - Each node (pixel) is visited once, leading to a time complexity of (O(N)),
        where (N) is the number of nodes(pixels) in the tree(grid).

        - ** Space Complexity**:
          - The space complexity is (O(N)) in the worst case due to the recursive call stack.

        By representing the grid as a tree, we can apply the flood fill algorithm using a tree traversal approach.
        This adaptation demonstrates the flexibility of algorithms to different data structures,
        although for grid-based problems, using grid-specific data structures and algorithms would be more conventional and efficient.
        */
        public class TreeNode
        {
            public int Color { get; set; }
            public TreeNode Up { get; set; }
            public TreeNode Down { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(int color)
            {
                this.Color = color;
            }
        }

        public void ApplyFloodFill(TreeNode node, int newColor)
        {
            if (node == null)
            {
                return;
            }

            int originalColor = node.Color;
            if (originalColor == newColor)
            {
                return;
            }

            FloodFillRecursive(node, originalColor, newColor);
        }

        private void FloodFillRecursive(TreeNode node, int originalColor, int newColor)
        {
            if (node == null || node.Color != originalColor)
            {
                return;
            }

            node.Color = newColor;

            FloodFillRecursive(node.Up, originalColor, newColor);
            FloodFillRecursive(node.Down, originalColor, newColor);
            FloodFillRecursive(node.Left, originalColor, newColor);
            FloodFillRecursive(node.Right, originalColor, newColor);
        }

        public static void FloodFillAlgorithmUsingBinaryTreeDriver()
        {
            // Create a sample grid as a tree
            TreeNode node00 = new TreeNode(1);
            TreeNode node01 = new TreeNode(1);
            TreeNode node10 = new TreeNode(1);
            TreeNode node11 = new TreeNode(0);

            int newcolor = 2;

            node00.Right = node01;
            node00.Down = node10;

            node01.Left = node00;
            node01.Down = node11;

            node10.Up = node00;
            node10.Right = node11;

            node11.Left = node10;
            node11.Up = node01;

            FloodFillAlgorithmUsingBinaryTree_H_6 floodFill = new FloodFillAlgorithmUsingBinaryTree_H_6();
            floodFill.ApplyFloodFill(node00, newcolor);

            Console.WriteLine($"New colors : {newcolor}");
            Console.WriteLine("Flood fill applied.");
            Console.WriteLine($"node00 color: {node00.Color}");
            Console.WriteLine($"node01 color: {node01.Color}");
            Console.WriteLine($"node10 color: {node10.Color}");
            Console.WriteLine($"node11 color: {node11.Color}");
        }
    }

}
