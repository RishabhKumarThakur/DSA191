using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using static GreedyAlgorithm.NMeetingInOneRoom_M_1;
using System.Buffers.Text;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;
using static Heaps.MaxHeapAndMinHeap_M_1;
using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Collections;

namespace Heaps
{
    public class MaxHeapAndMinHeap_M_1
    {
        /*
        To implement a Max Heap and Min Heap in C#, you can use the following classes. These implementations are basic and sufficient for interview purposes.

        ### Max Heap Implementation

        A Max Heap is a complete binary tree where the value of each node is greater than or equal to the values of its children.The root node contains the largest value.

        ### Min Heap Implementation

        A Min Heap is a complete binary tree where the value of each node is less than or equal to the values of its children.The root node contains the smallest value.

        ### Explanation

        1. ** Swap Method**:
           - A helper method to swap elements in the list.

        2. **Insert Method**:
           - Adds a new element to the heap.
           - Maintains the heap property by bubbling up the new element until the correct position is found.

        3. ** ExtractMax/ExtractMin Method**:
           - Removes and returns the maximum or minimum element from the heap.
           - Maintains the heap property by bubbling down the root element until the correct position is found.

        4. ** PeekMax/PeekMin Method**:
           - Returns the maximum or minimum element without removing it.

        5. ** Size and IsEmpty Methods**:
           - Provide the current size of the heap and check if the heap is empty, respectively.


        This code demonstrates how to create instances of `MaxHeap` and `MinHeap`, insert elements, and extract the maximum or minimum elements.
        These implementations are simple and ideal for demonstrating your understanding of heaps in an interview setting.
        */
        public class MaxHeap
        {
            private List<int> heap;

            public MaxHeap()
            {
                heap = new List<int>();
            }

            private void Swap(int i, int j)
            {
                int temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }

            public void Insert(int element)
            {
                heap.Add(element);
                int current = heap.Count - 1;

                while (current > 0)
                {
                    int parent = (current - 1) / 2;

                    if (heap[current] <= heap[parent])
                        break;

                    Swap(current, parent);
                    current = parent;
                }
            }

            public int ExtractMax()
            {
                if (heap.Count == 0)
                    throw new InvalidOperationException("Heap is empty.");

                int max = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                int current = 0;

                while (true)
                {
                    int leftChild = 2 * current + 1;
                    int rightChild = 2 * current + 2;
                    int largest = current;

                    if (leftChild < heap.Count && heap[leftChild] > heap[largest])
                        largest = leftChild;

                    if (rightChild < heap.Count && heap[rightChild] > heap[largest])
                        largest = rightChild;

                    if (largest == current)
                        break;

                    Swap(current, largest);
                    current = largest;
                }

                return max;
            }

            public int PeekMax()
            {
                if (heap.Count == 0)
                    throw new InvalidOperationException("Heap is empty.");

                return heap[0];
            }

            public int Size()
            {
                return heap.Count;
            }

            public bool IsEmpty()
            {
                return heap.Count == 0;
            }

            public void PrintHeap()
            {
                Console.WriteLine("Max Heap:");
                foreach (var item in heap)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        public class MinHeap
        {
            private List<int> heap;

            public MinHeap()
            {
                heap = new List<int>();
            }

            private void Swap(int i, int j)
            {
                int temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }

            public void Insert(int element)
            {
                heap.Add(element);
                int current = heap.Count - 1;

                while (current > 0)
                {
                    int parent = (current - 1) / 2;

                    if (heap[current] >= heap[parent])
                        break;

                    Swap(current, parent);
                    current = parent;
                }
            }

            public int ExtractMin()
            {
                if (heap.Count == 0)
                    throw new InvalidOperationException("Heap is empty.");

                int min = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                int current = 0;

                while (true)
                {
                    int leftChild = 2 * current + 1;
                    int rightChild = 2 * current + 2;
                    int smallest = current;

                    if (leftChild < heap.Count && heap[leftChild] < heap[smallest])
                        smallest = leftChild;

                    if (rightChild < heap.Count && heap[rightChild] < heap[smallest])
                        smallest = rightChild;

                    if (smallest == current)
                        break;

                    Swap(current, smallest);
                    current = smallest;
                }

                return min;
            }

            public int PeekMin()
            {
                if (heap.Count == 0)
                    throw new InvalidOperationException("Heap is empty.");

                return heap[0];
            }

            public int Size()
            {
                return heap.Count;
            }

            public bool IsEmpty()
            {
                return heap.Count == 0;
            }

            public void PrintHeap()
            {
                Console.WriteLine("Min Heap:");
                foreach (var item in heap)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }


        public static void MaxHeapAndMinHeapDriver()
        {
            MaxHeap maxHeap = new MaxHeap();
            maxHeap.Insert(3);
            maxHeap.Insert(5);
            maxHeap.Insert(9);
            maxHeap.Insert(6);
            maxHeap.Insert(8);
            maxHeap.Insert(20);
            maxHeap.PrintHeap();

            Console.WriteLine("Max Element: " + maxHeap.ExtractMax());

            MinHeap minHeap = new MinHeap();
            minHeap.Insert(3);
            minHeap.Insert(5);
            minHeap.Insert(9);
            minHeap.Insert(6);
            minHeap.Insert(8);
            minHeap.Insert(20);
            minHeap.PrintHeap();

            Console.WriteLine("Min Element: " + minHeap.ExtractMin());
        }
    }

    public class KthLargestAndSmallestElementInArray_E_2
    {
        /*
        Finding the Kth largest or smallest element in an array is a common problem that can be solved using various methods.Below are some of the approaches you can use:

        ### 1. Sorting Method
        - ** Time Complexity**: O(N log N) due to sorting
        - ** Space Complexity**: O(1) if sorting in place

        ### 2. Min-Heap for Kth Largest
        - ** Time Complexity**: O(N log K)
        - ** Space Complexity**: O(K)

        ### 3. Max-Heap for Kth Smallest
        - ** Time Complexity**: O(N log K)
        - ** Space Complexity**: O(K)

        ### 4. Quickselect Algorithm
        - ** Time Complexity**: O(N) on average, O(N ^ 2) in the worst case
        - ** Space Complexity**: O(1)

        For interviews, using the Quickselect algorithm or heap methods are generally preferred due to their better average time complexities.

        
        ### Explanation

        1. ** Sorting Method**:
           - Sort the array and return the element at the appropriate index for the Kth largest or smallest element.

        2. **Heap Method**:
           - Use a min-heap to keep track of the largest K elements for finding the Kth largest element.
           - Use a max-heap to keep track of the smallest K elements for finding the Kth smallest element.
           - PriorityQueue in C# is used here to implement the heaps.

        3. **Quickselect Algorithm**:
           - A selection algorithm to find the Kth smallest or largest element in an unordered list.
           - Uses a similar approach to QuickSort, with partitioning based on a pivot element.

        Each of these methods provides a different approach with varying time and space complexities, giving you multiple tools to tackle the problem in interviews.
        */

        //### Using Sorting

        public class KthElementUsingSorting
        {
            public static int FindKthLargest(int[] nums, int k)
            {
                Array.Sort(nums);
                return nums[nums.Length - k];
            }

            public static int FindKthSmallest(int[] nums, int k)
            {
                Array.Sort(nums);
                return nums[k - 1];
            }

            public static void KthElementUsingSortingDriver()
            {
                int[] nums = { 3, 2, 1, 5, 6, 4 };
                int k = 2;
                Console.WriteLine($"Input Numbers : {string.Join(", ", nums)}");
                Console.WriteLine($"K value: {k}");

                Console.WriteLine("Kth Largest: " + FindKthLargest(nums, k));
                Console.WriteLine("Kth Smallest: " + FindKthSmallest(nums, k));
            }
        }


        //### Using Min-Heap for Kth Largest

        public class KthLargestUsingMinHeap
        {
            public static int FindKthLargest(int[] nums, int k)
            {
                PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

                foreach (int num in nums)
                {
                    minHeap.Enqueue(num, num);
                    if (minHeap.Count > k)
                    {
                        minHeap.Dequeue();
                    }
                }

                return minHeap.Peek();
            }

            public static void KthLargestUsingMinHeapDriver()
            {
                int[] nums = { 3, 2, 1, 5, 6, 4 };
                int k = 2;
                Console.WriteLine($"Input Numbers : {string.Join(", ", nums)}");
                Console.WriteLine($"K value: {k}");

                Console.WriteLine("Kth Largest: " + FindKthLargest(nums, k));
            }
        }


        //### Using Max-Heap for Kth Smallest

        public class FindKthSmallestUsingMaxHeap
        {
            public static int FindKthSmallest(int[] nums, int k)
            {
                PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));

                foreach (int num in nums)
                {
                    maxHeap.Enqueue(num, num);
                    if (maxHeap.Count > k)
                    {
                        maxHeap.Dequeue();
                    }
                }

                return maxHeap.Peek();
            }

            public static void FindKthSmallestUsingMaxHeapDriver()
            {
                int[] nums = { 3, 2, 1, 5, 6, 4 };
                int k = 2;
                Console.WriteLine($"Input Numbers : {string.Join(", ", nums)}");
                Console.WriteLine($"K value: {k}");

                Console.WriteLine("Kth Smallest: " + FindKthSmallest(nums, k));
            }
        }


        //### Using Quickselect Algorithm

        public class KthElementUsingQuickselect
        {
            public static int FindKthLargest(int[] nums, int k)
            {
                return QuickselectAlgorithm(nums, 0, nums.Length - 1, nums.Length - k);
            }

            public static int FindKthSmallest(int[] nums, int k)
            {
                return QuickselectAlgorithm(nums, 0, nums.Length - 1, k - 1);
            }

            private static int QuickselectAlgorithm(int[] nums, int left, int right, int k)
            {
                if (left == right)
                    return nums[left];

                int pivotIndex = Partition(nums, left, right);

                if (k == pivotIndex)
                    return nums[k];
                else if (k < pivotIndex)
                    return QuickselectAlgorithm(nums, left, pivotIndex - 1, k);
                else
                    return QuickselectAlgorithm(nums, pivotIndex + 1, right, k);
            }

            private static int Partition(int[] nums, int left, int right)
            {
                int pivot = nums[right];
                int i = left;

                for (int j = left; j < right; j++)
                {
                    if (nums[j] <= pivot)
                    {
                        Swap(nums, i, j);
                        i++;
                    }
                }

                Swap(nums, i, right);
                return i;
            }

            private static void Swap(int[] nums, int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            public static void KthElementUsingQuickselectDriver()
            {
                int[] nums = { 3, 2, 1, 5, 6, 4 };
                int k = 2;
                Console.WriteLine($"Input Numbers : {string.Join(", ", nums)}");
                Console.WriteLine($"K value: {k}");

                Console.WriteLine("Kth Largest: " + FindKthLargest(nums, k));
                Console.WriteLine("Kth Smallest: " + FindKthSmallest(nums, k));
            }
        }
    }

    public class KMaxSumCombinations_E_3
    {
        /*
        To find the K maximum sum combinations from two arrays, we can use a max-heap to efficiently manage and extract the largest sums.
        The idea is to generate potential combinations in a structured way and use a heap to keep track of the top K sums.

        ### Detailed Explanation

        1. ** Max-Heap**: Use a max-heap(priority queue) to keep track of the current largest sums.
        2. **Heap Elements**: Each element in the heap is a tuple containing the sum, and the indices from the two arrays.
        3. **Initialization**: Start by inserting the largest possible sum (i.e., the sum of the largest elements of both arrays) into the heap.
        4. ** Exploration**: Extract the maximum sum from the heap and then push the next possible sums formed by decrementing the indices of the arrays.
        5. **Tracking**: Use a set to keep track of the pairs of indices that have already been pushed to the heap to avoid duplicates.

        ### Time and Space Complexity

        - **Time Complexity**: O(K log K), where K is the number of combinations you need.This is because we perform K heap insertions/extractions.
        - **Space Complexity**: O(K) for storing the heap elements and the set for tracking.

        ### Explanation

        1. ** Sorting**: Both arrays are sorted in ascending order to facilitate the creation of the largest sums.
        2. **Initialization**: The heap is initialized with the largest possible sum from the last elements of both arrays.
        3. **Max-Heap Operations**:
           - The largest sum is extracted.
           - The next possible sums (by decrementing the indices) are computed and pushed into the heap if they haven't been visited before.
        4. ** Result Compilation**: This process is repeated until K sums have been extracted.

        This approach ensures that the top K largest sums are efficiently found using a max-heap and a set for tracking visited pairs.
        */

        public static List<int> FindKMaxSumCombinations(int[] arr1, int[] arr2, int K)
        {
            // Sort both arrays
            Array.Sort(arr1);
            Array.Sort(arr2);

            int N = arr1.Length;

            // Max heap to store the (sum, (i, j)) tuple
            PriorityQueue<(int sum, int i, int j), int> maxHeap = new PriorityQueue<(int sum, int i, int j), int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            // Initial sum combination (i=N-1, j=N-1)
            maxHeap.Enqueue((arr1[N - 1] + arr2[N - 1], N - 1, N - 1), arr1[N - 1] + arr2[N - 1]);
            visited.Add((N - 1, N - 1));

            List<int> result = new List<int>();

            while (K > 0 && maxHeap.Count > 0)
            {
                var (sum, i, j) = maxHeap.Dequeue();
                result.Add(sum);
                K--;

                // Check next possible pairs (i-1, j) and (i, j-1)
                if (i > 0 && !visited.Contains((i - 1, j)))
                {
                    maxHeap.Enqueue((arr1[i - 1] + arr2[j], i - 1, j), arr1[i - 1] + arr2[j]);
                    visited.Add((i - 1, j));
                }

                if (j > 0 && !visited.Contains((i, j - 1)))
                {
                    maxHeap.Enqueue((arr1[i] + arr2[j - 1], i, j - 1), arr1[i] + arr2[j - 1]);
                    visited.Add((i, j - 1));
                }
            }

            return result;
        }

        public static void KMaxSumCombinationsDriver()
        {
            int[] arr1 = { 1, 4, 2, 3 };
            int[] arr2 = { 2, 5, 1, 6 };
            int K = 4;
            Console.WriteLine($"Given array 1 : {string.Join(",", arr1)}");
            Console.WriteLine($"Given array 2 : {string.Join(",", arr2)}");
            Console.WriteLine($"K value : {K}");

            List<int> result = FindKMaxSumCombinations(arr1, arr2, K);

            Console.WriteLine("K max sum combinations:");
            foreach (int sum in result)
            {
                Console.WriteLine(sum);
            }
        }
    }

    public class FindMedianFromDataStream_H_4
    {
        /*
        To find the median from a data stream efficiently, you can use two heaps: 
        a max-heap to store the smaller half of the numbers and a min-heap to store the larger half.
        This way, you can maintain the balance of elements in the two heaps such that the median can be found in constant time.

        ### Detailed Explanation

        1. **Max-Heap**: This heap will store the smaller half of the elements.
        2. **Min-Heap**: This heap will store the larger half of the elements.
        3. **Balancing**: Ensure the heaps are balanced such that the max-heap can either have the same number of elements as the min-heap or one more element than the min-heap.

        ### Algorithm

        - When adding a new number:
          1. Add the number to the max-heap.
          2. Balance the heaps by moving the largest number from the max-heap to the min-heap if necessary.
          3. If the max-heap has more than one extra element compared to the min-heap, move the smallest number from the min-heap back to the max-heap.
        - Finding the median:
          - If the total number of elements is odd, the median is the top element of the max-heap.
          - If the total number of elements is even, the median is the average of the top elements of both heaps.

        ### Explanation

        1. ** Initialization**: Two priority queues(heaps) are used.
        The `maxHeap` is used to store the smaller half of the numbers (as a max-heap), and the `minHeap` is used to store the larger half(as a min-heap).

        2. ** Adding a number**:
           - Add the number to the `maxHeap`.
           - If the `maxHeap` root is greater than the `minHeap` root, move the root of the `maxHeap` to the `minHeap` to balance the heaps.
           - If the size difference between the heaps is greater than 1, balance them by moving elements between the heaps.

        3. **Finding the median**:
           - If the `maxHeap` has more elements, the median is the root of the `maxHeap`.
           - If both heaps have the same number of elements, the median is the average of the roots of both heaps.

        ### Time and Space Complexity

        - **Time Complexity**: O(log N) for adding a number (due to heap operations) and O(1) for finding the median.
        - ** Space Complexity**: O(N) to store the numbers in the heaps.
        */

        private PriorityQueue<int, int> maxHeap; // Max-Heap for the smaller half
        private PriorityQueue<int, int> minHeap; // Min-Heap for the larger half

        public FindMedianFromDataStream_H_4()
        {
            maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x))); // Max-Heap
            minHeap = new PriorityQueue<int, int>(); // Min-Heap
        }

        public void AddNum(int num)
        {
            maxHeap.Enqueue(num, num); // Add to max-heap

            // Balance the heaps
            if (maxHeap.Count > 0 && minHeap.Count > 0 && maxHeap.Peek() > minHeap.Peek())
            {
                int maxHeapRoot = maxHeap.Dequeue();
                minHeap.Enqueue(maxHeapRoot, maxHeapRoot);
            }

            // Ensure the max-heap can have at most one extra element
            if (maxHeap.Count > minHeap.Count + 1)
            {
                int maxHeapRoot = maxHeap.Dequeue();
                minHeap.Enqueue(maxHeapRoot, maxHeapRoot);
            }

            if (minHeap.Count > maxHeap.Count)
            {
                int minHeapRoot = minHeap.Dequeue();
                maxHeap.Enqueue(minHeapRoot, minHeapRoot);
            }
        }

        public double FindMedian()
        {
            if (maxHeap.Count > minHeap.Count)
            {
                return maxHeap.Peek();
            }
            else
            {
                return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
            }
        }

        public static void FindMedianFromDataStreamDriver()
        {
            FindMedianFromDataStream_H_4 medianFinder = new FindMedianFromDataStream_H_4();
            medianFinder.AddNum(1);
            medianFinder.AddNum(2);
            Console.WriteLine("Median: " + medianFinder.FindMedian()); // Output: 1.5
            medianFinder.AddNum(3);
            Console.WriteLine("Median: " + medianFinder.FindMedian()); // Output: 2
        }
    }

    public class MergeKSortedArrays_M_5
    {
        /*
        To merge `K` sorted arrays efficiently, we can use a min-heap.The idea is to keep track of the smallest elements of each array using the min-heap.
        Here's a detailed explanation and implementation in C#:

        ### Detailed Explanation

        1. ** Min-Heap**: Use a min-heap to keep track of the smallest elements from each of the `K` arrays.
        2. ** Heap Elements**: Each element in the heap is a tuple containing the value, the index of the array it comes from, and the index of the element in that array.
        3. **Initialization**: Initialize the heap by inserting the first element of each array along with its array index and element index.
        4. **Merging**: Extract the minimum element from the heap, add it to the result list, and insert the next element from the same array into the heap.
        5. **Continue**: Repeat the process until the heap is empty.

        ### Time and Space Complexity

        - **Time Complexity**: O(N log K), where `N` is the total number of elements across all arrays and `K` is the number of arrays.
        Each insertion and extraction operation from the heap takes O(log K) time.
        - **Space Complexity**: O(K) for storing elements in the heap.


        ### Explanation

        1. ** MinHeapNode Class**: This class is used to store the value along with its array index and element index.
        2. ** MergeKSortedArrays Method**:
           - Initialize a min-heap and add the first element of each array.
           - Extract the smallest element from the heap, add it to the result list, and push the next element from the same array into the heap.
           - Repeat until the heap is empty.
        3. ** Main Method**:
           - Initialize a list of sorted arrays.
           - Call the `MergeKSortedArrays` method to get the merged array.
           - Print the merged array.

        This approach ensures that we efficiently merge `K` sorted arrays with an optimal time and space complexity.

        */

        public class MinHeapNode
        {
            public int Value { get; set; }
            public int ArrayIndex { get; set; }
            public int ElementIndex { get; set; }

            public MinHeapNode(int value, int arrayIndex, int elementIndex)
            {
                Value = value;
                ArrayIndex = arrayIndex;
                ElementIndex = elementIndex;
            }
        }

        public static List<int> MergeKSortedArrays(List<int[]> arrays)
        {
            List<int> result = new List<int>();
            PriorityQueue<MinHeapNode, int> minHeap = new PriorityQueue<MinHeapNode, int>();

            // Initialize the heap with the first element of each array
            for (int i = 0; i < arrays.Count; i++)
            {
                if (arrays[i].Length > 0)
                {
                    minHeap.Enqueue(new MinHeapNode(arrays[i][0], i, 0), arrays[i][0]);
                }
            }

            // Extract the minimum element and add the next element of the same array to the heap
            while (minHeap.Count > 0)
            {
                MinHeapNode minNode = minHeap.Dequeue();
                result.Add(minNode.Value);

                int nextElementIndex = minNode.ElementIndex + 1;
                if (nextElementIndex < arrays[minNode.ArrayIndex].Length)
                {
                    minHeap.Enqueue(new MinHeapNode(arrays[minNode.ArrayIndex][nextElementIndex], minNode.ArrayIndex, nextElementIndex), arrays[minNode.ArrayIndex][nextElementIndex]);
                }
            }

            return result;
        }

        public static void MergeKSortedArraysDriver()
        {
            List<int[]> arrays = new List<int[]>
            {
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 3, 6, 9 }
            };

            Console.WriteLine("Initial array:");
            foreach (int[] nums in arrays)
            {
                foreach (int num in nums)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }


            List<int> mergedArray = MergeKSortedArrays(arrays);

            Console.WriteLine("Merged array:");
            foreach (int num in mergedArray)
            {
                Console.Write(num + " ");
            }
        }
    }

    public class KMostFrequentElements_M_6
    {
        /*
         * 
        To find the K most frequent elements in an array, you can use a combination of a hash map to count frequencies and
        a min-heap to keep track of the top K elements.
        This ensures efficient computation and retrieval of the most frequent elements.

        ### Detailed Explanation

        1. ** Hash Map**: Use a hash map(or dictionary) to count the frequency of each element in the array.
        2. **Min-Heap**: Use a min-heap to keep track of the top K most frequent elements.The heap will store pairs of (frequency, element).
        3. **Balancing the Heap**: If the size of the heap exceeds K, remove the element with the smallest frequency.

        ### Time and Space Complexity

        - **Time Complexity**: O(N log K)
          - Building the frequency map: O(N)
          - Building the heap: O(N log K)
        - ** Space Complexity**: O(N) for the hash map and O(K) for the heap.


        ### Explanation

        1. ** Frequency Map**: Build a frequency map using a dictionary where the key is the element and the value is its frequency.
        2. **Min-Heap**: Use a min-heap to maintain the top K frequent elements. The heap stores pairs of (frequency, element).
           - Enqueue elements into the heap.
           - If the heap size exceeds K, dequeue the element with the smallest frequency.
        3. **Extracting Elements**: Extract elements from the heap and add them to the result list.
        4. **Reversing the List**: The result list needs to be reversed to present the elements in descending order of frequency.

        ### Example Walkthrough

        - Given `nums = { 1, 1, 1, 2, 2, 3}` and `k = 2`.
        - Frequency map: `{1: 3, 2: 2, 3: 1}`.
        -Min - heap operations:
        -Insert `(3, 1)`: Heap is `[(3, 1)]`.
          -Insert `(2, 2)`: Heap is `[(2, 2), (3, 1)]`.
          -Insert `(1, 3)`: Heap is `[(1, 3), (3, 1), (2, 2)]`.
          -Remove `(1, 3)` to maintain size `K = 2`: Heap is `[(2, 2), (3, 1)]`.
        -Extract elements: `[2, 1]`.
        -Reverse the list: `[1, 2]`.

        This approach ensures that you efficiently find the K most frequent elements using a combination of a hash map and a min-heap.

        */

        public static IList<int> TopKFrequent(int[] nums, int k)
        {
            // Frequency dictionary
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }

            // Min-heap to keep top k frequent elements
            PriorityQueue<(int freq, int num), int> minHeap = new PriorityQueue<(int freq, int num), int>();

            foreach (var entry in frequencyMap)
            {
                minHeap.Enqueue((entry.Value, entry.Key), entry.Value);
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            // Extract elements from the heap
            List<int> topKFrequent = new List<int>();
            while (minHeap.Count > 0)
            {
                topKFrequent.Add(minHeap.Dequeue().num);
            }

            // The elements need to be in descending order of frequency, so reverse the list
            topKFrequent.Reverse();
            return topKFrequent;
        }

        public static void KMostFrequentElementsDriver()
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int k = 2;
            Console.WriteLine($"Given Nums : {string.Join(",",nums)}");
            Console.WriteLine($"K value : {k}");

            IList<int> result = TopKFrequent(nums, k);

            Console.WriteLine("Top " + k + " most frequent elements:");
            foreach (int num in result)
            {
                Console.Write(num + " ");
            }
        }
    }

}
