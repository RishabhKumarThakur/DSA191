
using System.Globalization;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System.Xml;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic;
using System.Buffers.Text;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Numerics;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Arrays
{
    public static class SetMatrixZeros_M_01
    {
        /*  Given a matrix if an element in the matrix is 0 then you will have to set its entire column and row to 0 and then return the matrix
    
         * Time and Space Complexity:
            Time Complexity: O(M * N), where M is the number of rows and N is the number of columns in the matrix.
        This is because we traverse the matrix a few times (constant number of passes).

            Space Complexity: O(1), since we are using the matrix itself for marking and do not use any additional space proportional to the input size.
            Example Walkthrough:

            Given the matrix:

            Copy code
            1  2  3  4
            5  0  7  8
            9  10 11 12
            13 14 15 0

            First, check the first row and first column for zeroes. 
            Here, the second element of the first column and the last element of the first row are zero.

            Use the first row and column to mark which rows and columns need to be zeroed. After this step, the matrix looks like this:

            Copy code
            1  0  3  0
            0  0  7  8
            9  10 11 12
            0  14 15 0

            Zero out cells based on the first row and column markers:
            Copy code
            1  0  3  0
            0  0  0  0
            9  0  11 0
            0  0  0  0

            Finally, zero out the first row and first column if they contained zeroes initially:
            Copy code
            1  0  3  0
            0  0  0  0
            9  0  11 0
            0  0  0  0

            And then the final result:

            1  0  3  0
            0  0  0  0
            9  0  11 0
            0  0  0  0

         */

        public static void SetMatrixZerosDriver()
        {
            int[,] matrix = {
                {1, 2, 3, 4},
                {5, 0, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 0}
            };

            Console.WriteLine("Original Matrix:");
            PrintMatrix(matrix);

            SetZeroes(matrix);

            Console.WriteLine("nModified Matrix:");
            PrintMatrix(matrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] SetZeroes(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // First row and first column markers
            bool firstRowHasZero = false;
            bool firstColHasZero = false;

            // Check if the first row has a zero
            for (int j = 0; j < cols; j++)
            {
                if (matrix[0, j] == 0)
                {
                    firstRowHasZero = true;
                    break;
                }
            }

            // Check if the first column has a zero
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    firstColHasZero = true;
                    break;
                }
            }

            // Use first row and column to mark zero rows and columns
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }

            // Zero out cells based on the marks in the first row and column
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            // Zero out the first row if necessary
            if (firstRowHasZero)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[0, j] = 0;
                }
            }

            // Zero out the first column if necessary
            if (firstColHasZero)
            {
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, 0] = 0;
                }
            }

            return matrix;
        }
    }

    public static class PascalTriangle_M_02
    {
        // Given the number of rows n. Print the first n rows of Pascal’s triangle.
        /*
         * Time Complexity: O(n^2)
         * Space Complexity: O(1)
         * 
         * Example Walkthrough:
            For 
            𝑛
            =
            5
            n=5:
            The first 5 rows are:

            Copy code
            1
            1 1
            1 2 1
            1 3 1 3
            1 4 6 4 1
         */

        public static void PascalTriangleDriver()
        {
            PrintFirstNRowsDriver();
            PrintNthRowDriver();
            ElementAtRandCDriver();
        }

        public static void PrintFirstNRowsDriver()
        {
            int n = 6;
            Console.WriteLine($"The first {n} rows of Pascal's Triangle are:");
            PrintFirstNRows(n);
        }

        public static void PrintFirstNRows(int n)
        {
            for (int i = 0; i < n; i++)
            {
                long value = 1;
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(value + " ");
                    value = value * (i - j) / (j + 1);
                }

                Console.WriteLine();
            }
        }

        /*
         * Given the row number n. Print the n-th row of Pascal’s triangle.
         * 
         * Time Complexity: O(n^2)
            Space Complexity: O(1)

            Example Walkthrough:
            For 
            𝑛
            =
            5
            n=5:
            The 5-th row is: 1 5 10 10 5 1
         */

        public static void PrintNthRowDriver()
        {
            int n = 5;
            Console.WriteLine($"The {n}-th row of Pascal's Triangle is:");
            PrintNthRow(n);
        }

        public static void PrintNthRow(int n)
        {
            for (int c = 0; c <= n; c++)
            {
                Console.Write(BinomialCoefficient(n, c) + " ");
            }
            Console.WriteLine();
        }

    
        /*
         * The element at position (r, c) in Pascal’s Triangle can be calculated using the binomial coefficient formula: 
         * Factorial(r) / (Factorial(c) * Factorial(r - c));​

            Time Complexity: O(r)
        Space Complexity: O(1)

        Example Walkthrough:r=5 and c=2
        C(5,2) = 5!
                 ---
                2! * 3!

        = 10
         */

        public static void ElementAtRandCDriver()
        {
            int r = 5;
            int c = 2;
            Console.WriteLine($"Element at position ({r}, {c}) is {BinomialCoefficient(r, c)}");
        }

        // Method to calculate binomial coefficient
        static long BinomialCoefficient(int r, int c)
        {
            return Factorial(r) / (Factorial(c) * Factorial(r - c));
        }

        // Method to calculate factorial
        static long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }

    public static class NextPermutations_M_03
    {
        /* Given an array Arr[] of integers, rearrange the numbers of the given array into the lexicographically next greater permutation of numbers.
         * Walkthrough with nums = { 1, 2, 3 }
            Initial Array:

            nums = { 1, 2, 3 }
            Step 1: Find the first decreasing element from the end.

            i = 1 (because nums[1] = 2 and nums[2] = 3)
            Step 2: Find the element just larger than nums[i].

            j = 2 (because nums[2] = 3 is just larger than nums[1] = 2)
            Step 3: Swap elements at indices i and j.

            Swap nums[1] and nums[2], resulting in nums = { 1, 3, 2 }
            Step 4: Reverse the elements from i + 1 to the end.

            No change needed since only one element is involved.
            Final Result:

            nums = { 1, 3, 2 }
            Time Complexity
            The algorithm runs in O(n) time where n is the number of elements in the array.
            Space Complexity
            The algorithm runs in O(1) extra space since it only uses a few additional variables.
         */

        public static void NextPermutationsDriver()
        {
            int[] nums = { 1, 2, 3 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));

            NextPermutations(nums);

            Console.WriteLine("Next permutation: " + string.Join(", ", nums));
        }

        public static void NextPermutations(int[] nums)
        {
            int n = nums.Length;
            if (n <= 1) return;

            int i = n - 2;

            // Step 1: Find the first decreasing element from the end
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }

            if (i >= 0)
            {
                // Step 2: Find the element just larger than nums[i] from the end
                int j = n - 1;
                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }
                // Step 3: Swap the elements at indices i and j
                Swap(nums, i, j);
            }

            // Step 4: Reverse the elements from i+1 to the end of the array
            Reverse(nums, i + 1, n - 1);
        }

        static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        static void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                Swap(nums, start, end);
                start++;
                end--;
            }
        }
    }

    public static class KadaneAlgorithmMaxSubArraySum_E_04_VVIMP
    {
        // KADANE ALGORITHM
        //    Explanation
        //FindMaxSubarray Function:
        //Initializes maxSum to the smallest possible integer(int.MinValue) to handle negative numbers in the array.
        //currentSum keeps track of the sum of the current subarray being considered.
        //start, end, and tempStart are used to track the indices of the maximum sum subarray.
        //start and end are the final indices of the subarray with the maximum sum.
        //tempStart is used to track the starting index of the potential subarray.
        //Loop Through Array:
        //Adds the current element to currentSum.
        //If currentSum exceeds maxSum, it updates maxSum and the indices start and end.
        //If currentSum becomes negative, it resets currentSum to 0 and updates tempStart to i + 1.


        //    Time Complexity
        //The algorithm runs in O(n) time complexity because it processes each element of the array exactly once.
        //    Space Complexity
        //    The algorithm runs in O(1) space complexity as it only uses a constant amount of extra space regardless of the input size.

        public static void MaxSubArraySumDriver()
        {
            int[] array = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine("Original array: " + string.Join(", ", array));
            var result = MaxSubArraySum(array);

            Console.WriteLine("Maximum sum of contiguous subarray: " + result.maxSum);
            Console.WriteLine("startIndex of contiguous subarray: " + result.startIndex);
            Console.WriteLine("endIndex of contiguous subarray: " + result.endIndex);
            Console.WriteLine("Original array: " + string.Join(", ", array[result.startIndex..(result.endIndex + 1)]));
        }

        public static (int maxSum, int startIndex, int endIndex) MaxSubArraySum(int[] array)
        {
            int maxsum = int.MinValue; // to handle -ve case for max comparision
            int currentSum = 0;
            int start = 0;
            int tempStart = 0;
            int end = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];

                if (currentSum > maxsum)
                {
                    maxsum = currentSum;
                    start = tempStart;
                    end = i;
                }

                if (currentSum < 0)
                {
                    currentSum = 0;
                    tempStart = i + 1;
                }
            }

            return (maxsum, start, end);
        }
    }

    public static class Sort0s1s2s_M_05
    {
        // Given an array consisting of only 0s, 1s, and 2s.
       // Write a program to in-place sort the array without using inbuilt sort functions.
        // Explanation

        //Initialization:
        //low and mid are initialized to 0.
        //high is initialized to the last index of the array.

        //Traversal:
        //The mid pointer traverses the array from left to right.
        //Depending on the value at array[mid], the algorithm performs the following actions:
        //Case 0: Swap array[low] and array[mid], then increment both low and mid.
        //Case 1: Just increment mid.
        //Case 2: Swap array[mid] and array[high], then decrement high.

        //Swapping:
        //The Swap function exchanges the elements at indices i and j.

        //Termination:
        //The loop terminates when mid exceeds high.

        //Space and Time Complexity
        //Time Complexity: O(n)
        //The algorithm makes a single pass through the array.
        //Space Complexity: O(1)
        //The algorithm uses a constant amount of extra space.

        public static void Sort0s1s2sDriver()
        {
            int[] inputarray = { 2, 0, 2, 1, 1, 0 };
            Console.WriteLine("Input array: " + string.Join(", ", inputarray));
            DutchFlagAlgorithm(inputarray);
            Console.WriteLine("Sorted array: " + string.Join(", ", inputarray));
        }

        public static void DutchFlagAlgorithm(int[] inputarray)
        {
            int start = 0;
            int mid = 0;
            int end = inputarray.Length - 1;

            while (mid <= end)
            {
                switch (inputarray[mid])
                {
                    case 0:
                        Swap(inputarray, mid, start);
                        mid++;
                        start++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        Swap(inputarray, mid, end);
                        end--;
                        break;
                }
            }
        }

        static void Swap(int[] arr1, int i, int j)
        {
            int temp = arr1[i];
            arr1[i] = arr1[j];
            arr1[j] = temp;
        }
    }

    public static class StockBuyAndSell_E_06
    {
        /*
         * Time and Space Complexity
            Time Complexity: O(n) - We only make one pass through the array.
            Space Complexity: O(1) - No additional space is used that scales with input size.

            Example Walkthrough
            Given prices = [7, 1, 5, 3, 6, 4]:

            Initialize minPrice = ∞, maxProfit = 0.
            Iterate over each price:
            Day 1 (price = 7): minPrice = 7, no profit since it's the first day.
            Day 2 (price = 1): minPrice = 1, no profit since we're still looking for a future sell.
            Day 3 (price = 5): Profit = 5 - 1 = 4, update maxProfit = 4, sellDay = 3.
            Day 4 (price = 3): Profit = 3 - 1 = 2, no update to maxProfit.
            Day 5 (price = 6): Profit = 6 - 1 = 5, update maxProfit = 5, sellDay = 5.
            Day 6 (price = 4): Profit = 4 - 1 = 3, no update to maxProfit.
            The maximum profit is 5, achieved by buying at price 1 and selling at price 6. 
         */


        public static void StockBuyAndSellDriver()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine("Input prices: " + string.Join(", ", prices));
            var result = MaxProfit(prices);

            if (result.Item1 > 0)
            {
                Console.WriteLine($"Maximum profit: {result.Item1}");
                Console.WriteLine($"Buy at: {result.Item2}");
                Console.WriteLine($"Sell at: {result.Item3}");
            }
            else
            {
                Console.WriteLine("No profit can be achieved.");
            }
        }

        // Method to calculate maximum profit
        public static (int, int, int) MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return (0, -1, -1); // No profit, invalid days
            }

            int minPrice = int.MaxValue;
            int maxProfit = 0;
            int buyDay = 0;
            int sellDay = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                // Update minPrice and buyDay if a new minimum is found
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                    buyDay = i;
                }

                // Calculate profit if selling on the current day
                int currentProfit = prices[i] - minPrice;
                if (currentProfit > maxProfit)
                {
                    maxProfit = currentProfit;
                    sellDay = i;
                }
            }

            if (maxProfit > 0)
            {
                return (maxProfit, prices[buyDay], prices[sellDay]);
            }
            else
            {
                return (0, -1, -1); // No profit
            }
        }
    }

    public static class Rotate_M_07
    {
        //    RotateArray Function:
        //First, the length of the array n is obtained.
        //The value of k is taken modulo n to handle cases where k is greater than n.
        //The entire array is reversed.
        //The first k elements are reversed.
        //The remaining n-k elements are reversed.

        //    Time Complexity
        //Reverse Function: Each call to the Reverse function runs in O(n) time, where n is the number of elements to reverse.
        //RotateArray Function: It calls the Reverse function three times, each running in O(n). Therefore, the total time complexity is O(n).
        //Space Complexity
        //The algorithm runs in O(1) extra space as it only uses a few additional variables regardless of the input size.

        public static void RotateDriver()
        {
            CyclicallyRotatebyKDriver();
            RotateMatrixby90ClockwiseDriver();
        }

        public static void CyclicallyRotatebyKDriver()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int k = 3;
            Console.WriteLine("Original array: " + string.Join(", ", array));
            Console.WriteLine($"Rotate array by k : {k}");

            CyclicallyRotateByK(array, k);

            Console.WriteLine("Array after rotation: " + string.Join(", ", array));
        }

        public static void CyclicallyRotateByK(int[] array, int k)
        {

            int n = array.Length;
            k = k % n;

            ReverseArray(array, 0, n - 1);
            ReverseArray(array, 0, k - 1);
            ReverseArray(array, k, n - 1);
        }

        public static void ReverseArray(int[] array, int start, int end)
        {
            while (start < end)
            {
                Swap(array, start, end);
                start++;
                end--;
            }
        }

        static void Swap(int[] arr1, int i, int j)
        {
            int temp = arr1[i];
            arr1[i] = arr1[j];
            arr1[j] = temp;
        }

        /*
         * Steps to Rotate a Matrix 90 Degrees Clockwise
            Transpose the Matrix: Convert rows to columns.
            Reverse Each Row: This will result in the matrix being rotated 90 degrees clockwise.
            Example
            Given the matrix:

            Copy code
            1 2 3
            4 5 6
            7 8 9
            After transposition:

            Copy code
            1 4 7
            2 5 8
            3 6 9
            After reversing each row:

            Copy code
            7 4 1
            8 5 2
            9 6 3

            Time and Space Complexity
            Time Complexity: O(n^2) - where n is the number of rows/columns in the matrix. This is because we need to visit each element of the matrix to transpose and then reverse each row.

            Space Complexity: O(1) - The rotation is done in place, so no additional space proportional to the input size is required.

            Explanation
            Transposing the Matrix: In this step, we swap matrix[i, j] with matrix[j, i]. This effectively flips the matrix over its diagonal.
            Reversing Each Row: After transposing, each row is reversed to achieve the 90-degree rotation. This step ensures that the elements are ordered correctly for the rotated matrix.
         */

        public static void RotateMatrixby90ClockwiseDriver()
        {
            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Console.WriteLine("Original matrix:");
            PrintMatrix(matrix);

            Rotate90Clockwise(matrix);

            Console.WriteLine("Matrix after rotating 90 degrees clockwise:");
            PrintMatrix(matrix);
        }

        // Method to print the matrix
        public static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Method to rotate the matrix 90 degrees clockwise
        public static void Rotate90Clockwise(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            // Transpose the matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }

            // Reverse each row
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, m - j - 1];
                    matrix[i, m - j - 1] = temp;
                }
            }
        }

    }

    public static class MergeIntervals_M_08
    {
        /* Given an array of intervals, merge all the overlapping intervals and return an array of non-overlapping intervals.
         * Walkthrough with intervals = { {1, 3}, {2, 6}, {8, 10}, {15, 18} }
            Sorting:

            The intervals are already sorted based on start times: [{1, 3}, {2, 6}, {8, 10}, {15, 18}].
            Merging:

            Initialize currentInterval = {1, 3}.
            Compare currentInterval {1, 3} with {2, 6}:
            Overlapping: Merge to {1, 6}.
            Compare currentInterval {1, 6} with {8, 10}:
            No overlap: Update currentInterval to {8, 10} and add to merged.
            Compare currentInterval {8, 10} with {15, 18}:
            No overlap: Update currentInterval to {15, 18} and add to merged.
            Final Result
            The merged intervals are [[1, 6], [8, 10], [15, 18]].
            Time Complexity
            The algorithm runs in O(n log n) time due to sorting, where n is the number of intervals.
            Space Complexity
            The algorithm runs in O(n) space for the output list, where n is the number of intervals.
         */

        public static void MergeIntervalsDriver()
        {
            int[][] intervals = new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };

            Console.WriteLine("Intervals:");
            foreach (var interval in intervals)
            {
                Console.WriteLine("[" + interval[0] + ", " + interval[1] + "]");
            }

            int[][] mergedIntervals = MergeIntervals(intervals);

            Console.WriteLine("Merged intervals:");
            foreach (var interval in mergedIntervals)
            {
                Console.WriteLine("[" + interval[0] + ", " + interval[1] + "]");
            }
        }

        public static int[][] MergeIntervals(int[][] intervals)
        {
            if (intervals.Length == 0)
                return new int[0][];

            // Sort intervals based on the start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> merged = new List<int[]>();
            int[] currentInterval = intervals[0];
            merged.Add(currentInterval);

            foreach (var interval in intervals)
            {
                int currentStart = currentInterval[0];
                int currentEnd = currentInterval[1];
                int nextStart = interval[0];
                int nextEnd = interval[1];

                if (currentEnd >= nextStart) // Overlapping intervals, merge them
                {
                    currentInterval[1] = Math.Max(currentEnd, nextEnd);
                }
                else // No overlap, add the new interval to the list
                {
                    currentInterval = interval;
                    merged.Add(currentInterval);
                }
            }

            return merged.ToArray();
        }
    }

    public static class Merge2SortedArrayNoExtraSpace_M_09
    {
        /*
         *MergeWithoutExtraSpace Function:

            Initialize the gap value using (n + m + 1) / 2. This is the initial gap.
            Use a while loop to reduce the gap until it becomes 1.
            Compare and swap elements at distance gap:
            If both elements are in arr1, compare and swap if needed.
            If one element is in arr1 and the other in arr2, compare and swap if needed.
            If both elements are in arr2, compare and swap if needed.
            Update the gap using (gap + 1) / 2.
            Swap Functions:

            Swap elements within the same array.
            Swap elements between two arrays.
            Example Walkthrough with arr1 = { 1, 3, 5, 7 } and arr2 = { 2, 4, 6, 8 }
            Initial Gap Calculation:

            gap = (4 + 4 + 1) / 2 = 4
            First Iteration (gap = 4):

            Compare arr1[0] and arr2[0] (1 and 2) - no swap needed.
            Compare arr1[1] and arr2[1] (3 and 4) - no swap needed.
            Compare arr1[2] and arr2[2] (5 and 6) - no swap needed.
            Compare arr1[3] and arr2[3] (7 and 8) - no swap needed.
            Reduce gap: gap = (4 + 1) / 2 = 2
            Second Iteration (gap = 2):

            Compare arr1[0] and arr1[2] (1 and 5) - no swap needed.
            Compare arr1[1] and arr1[3] (3 and 7) - no swap needed.
            Compare arr1[2] and arr2[0] (5 and 2) - swap needed. Arrays become arr1 = { 1, 3, 2, 7 }, arr2 = { 5, 4, 6, 8 }.
            Compare arr1[3] and arr2[1] (7 and 4) - swap needed. Arrays become arr1 = { 1, 3, 2, 4 }, arr2 = { 5, 7, 6, 8 }.
            Reduce gap: gap = (2 + 1) / 2 = 1
            Third Iteration (gap = 1):

            Compare arr1[0] and arr1[1] (1 and 3) - no swap needed.
            Compare arr1[1] and arr1[2] (3 and 2) - swap needed. Arrays become arr1 = { 1, 2, 3, 4 }, arr2 = { 5, 7, 6, 8 }.
            Compare arr1[2] and arr1[3] (3 and 4) - no swap needed.
            Compare arr1[3] and arr2[0] (4 and 5) - no swap needed.
            Compare arr2[0] and arr2[1] (5 and 7) - no swap needed.
            Compare arr2[1] and arr2[2] (7 and 6) - swap needed. Arrays become arr1 = { 1, 2, 3, 4 }, arr2 = { 5, 6, 7, 8 }.
            Compare arr2[2] and arr2[3] (7 and 8) - no swap needed.
            After these iterations, the two arrays are merged and sorted without using extra space:

            arr1 = { 1, 2, 3, 4 }
            arr2 = { 5, 6, 7, 8 }
            Time Complexity
            The algorithm runs in O((n + m) log(n + m)) time due to the iterative process and gap reduction.
            Space Complexity
            The algorithm runs in O(1) extra space as it uses no additional arrays or data structures.
         **/
        public static void Merge2SortedArrayNoExtraSpaceDriver()
        {
            int[] arr1 = { 1, 3, 5, 7 };
            int[] arr2 = { 2, 4, 6, 8 };
            Console.WriteLine("array1: " + string.Join(", ", arr1));
            Console.WriteLine("array2: " + string.Join(", ", arr2));

            Merge2SortedArrayNoExtraSpace(arr1, arr2);

            Console.WriteLine("Merged array: " + string.Join(", ", arr1) + ", " + string.Join(", ", arr2));
        }

        public static void Merge2SortedArrayNoExtraSpace(int[] arr1, int[] arr2)
        {
            int n = arr1.Length;
            int m = arr2.Length;
            int gap = (n + m + 1) / 2;

            while (gap > 0)
            {
                int i = 0;
                int j = gap;

                while (j < (n + m))
                {
                    if (j < n && arr1[i] > arr1[j])
                    {
                        Swap(arr1, i, j);
                    }
                    else if (j >= n && i < n && arr1[i] > arr2[j - n])
                    {
                        Swap(arr1, arr2, i, j - n);
                    }
                    else if (j >= n && i >= n && arr2[i - n] > arr2[j - n])
                    {
                        Swap(arr2, i - n, j - n);
                    }

                    i++;
                    j++;
                }

                if (gap == 1)
                    break;

                gap = (gap + 1) / 2;
            }
        }

        static void Swap(int[] arr1, int i, int j)
        {
            int temp = arr1[i];
            arr1[i] = arr1[j];
            arr1[j] = temp;
        }

        static void Swap(int[] arr1, int[] arr2, int i, int j)
        {
            int temp = arr1[i];
            arr1[i] = arr2[j];
            arr2[j] = temp;
        }

    }

    public static class DupInArrayOfN_M_10
    {
        // Floyd's Tortoise and Hare (Cycle Detection) algorithm.
        // This algorithm works in O(n) time and O(1) space complexity, making it very efficient.
        // To find a duplicate in an array of n + 1 integers where the integers are in the range from 1 to n,
        /*
         * FindDuplicate Function:

            Phase 1: Finding the intersection point.

            Initialize two pointers, tortoise and hare, both starting at the first element of the array.
            Move tortoise one step at a time (tortoise = nums[tortoise]).
            Move hare two steps at a time (hare = nums[nums[hare]]).
            Continue moving until tortoise and hare meet. This indicates a cycle in the array.

            Phase 2: Finding the entrance to the cycle.
            Reset tortoise to the start of the array.
            Move both tortoise and hare one step at a time until they meet. 
            The meeting point is the start of the cycle and thus the duplicate number.


            Example Walkthrough with nums = { 1, 3, 4, 2, 2 }

            Phase 1:

            Initial positions: tortoise = nums[0] = 1, hare = nums[0] = 1
            First step: tortoise = nums[1] = 3, hare = nums[nums[1]] = nums[3] = 2
            Second step: tortoise = nums[3] = 2, hare = nums[nums[2]] = nums[4] = 2
            They meet at index 2 (tortoise = 2, hare = 2).

            Phase 2:

            Reset tortoise to start: tortoise = nums[0] = 1
            First step: tortoise = nums[1] = 3, hare = nums[2] = 4
            Second step: tortoise = nums[3] = 2, hare = nums[4] = 2
            They meet at index 2 (tortoise = 2, hare = 2), which is the duplicate number.
            Time and Space Complexity
            Time Complexity: O(n) because both phases run in linear time.
            Space Complexity: O(1) because it uses only a constant amount of extra space.
         */

        public static void DupInArrayOfNDriver()
        {
            int[] nums = { 1, 2, 3, 4, 2 };
            Console.WriteLine($"Input array: {string.Join(",", nums)}");
            int duplicate = DupInArrayOfN(nums);

            Console.WriteLine("Duplicate number: " + duplicate);
        }

        public static int DupInArrayOfN(int[] nums)
        {
            // Phase 1: Finding the intersection point of the two runners.
            int tortoise = nums[0];
            int hare = nums[0];

            do
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            } while (tortoise != hare);

            // Phase 2: Finding the entrance to the cycle.
            tortoise = nums[0];
            while (tortoise != hare)
            {
                tortoise = nums[tortoise];
                hare = nums[hare];
            }

            return hare;
        }
    }

    class FindRepeatingAndMissing_H_11
    {
            /*
             * 
        ### Walkthrough with Example

        Given an array: ([4, 3, 6, 2, 1, 6])

        1. **Calculate Expected Sums**:
           - ( N = 6 )
           - ( S = frac{6 times 7}{2} = 21 )
           - ( S_2 = frac{6 times 7 times 13}{6} = 91 )

        2. **Calculate Actual Sums**:
           - ( S_{array} = 4 + 3 + 6 + 2 + 1 + 6 = 22 )
           - ( S_2{array} = 4^2 + 3^2 + 6^2 + 2^2 + 1^2 + 6^2 = 16 + 9 + 36 + 4 + 1 + 36 = 102 )

        3. **Calculate Differences**:
           - Difference in sums:
             [ S_{array} - S = 22 - 21 = 1 = A - B ]
           - Difference in squared sums:
             [ S_2{array} - S_2 = 102 - 91 = 11 = (A + B)(A - B) ]

           We know:
           [ A - B = 1 ]
           [ (A + B)(A - B) = 11 ]

        4. **Solve the Equations**:
           From ( A - B = 1 ), we get ( A = B + 1 ).

           Substituting ( A = B + 1 ) into ( (A + B)(A - B) = 11 ):
           [ (B + 1 + B) times 1 = 11 ]
           [ 2B + 1 = 11 ]
           [ 2B = 10 ]
           [ B = 5 ]
   
           Therefore, ( A = 5 + 1 = 6 ).

        So, the repeating number ( A ) is 6 and the missing number ( B ) is 5.

        This approach ensures that we efficiently find the repeating and missing numbers in linear time ( O(N) ) and constant space ( O(1) ).
         */

        public static void FindRepeatingAndMissingDriver()
        {
            int[] arr = { 4, 3, 6, 2, 1, 6 };
            Console.WriteLine("Input array: " + string.Join(", ", arr));
            FindRepeatingAndMissing(arr);
        }

        public static void FindRepeatingAndMissing(int[] arr)
        {
            int n = arr.Length;

            // Calculate expected sums
            int S = n * (n + 1) / 2;
            int S2 = n * (n + 1) * (2 * n + 1) / 6;

            // Calculate actual sums
            int sum = 0, sumSq = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
                sumSq += arr[i] * arr[i];
            }

            // Calculate differences
            int diff = sum - S; // A - B
            int diffSq = sumSq - S2; // A^2 - B^2

            // Solve the equations
            int sumAB = diffSq / diff; // A + B

            int A = (diff + sumAB) / 2;
            int B = sumAB - A;

            Console.WriteLine($"Repeating number : {A}");
            Console.WriteLine($"Missing number : {B}");
        }
    }

    class CountInversions_H_12
    {
        /*
         * Explanation
            MergeSortAndCount:

            Recursively divide the array into two halves.
            Count inversions in the left half, right half, and during the merge step.
            MergeAndCount:

            Merge two sorted subarrays while counting the inversions.
            If an element in the right subarray is smaller than an element in the left subarray, it contributes to inversions.
            Time and Space Complexity
            Time Complexity: O(N log N) - Due to the recursive divide and conquer approach of merge sort.

            Space Complexity: O(N) - Additional space is required for the temporary array used during merging.

           Given the array: [8, 4, 2, 1]

            Pairs: (8,4), (8,2), (8,1), (4,2), (4,1), (2,1)
            Number of inversions: 6
         * 
        */

        public static void CountInversionsDriver()
        {

            int[] arr = { 8, 4, 2, 1 };
            Console.WriteLine("Input array: " + string.Join(", ", arr));
            int n = arr.Length;
            int[] temp = new int[n];
            int result = MergeSortAndCount(arr, temp, 0, n - 1);
            Console.WriteLine("Number of inversions are: " + result);
        }

        public static int MergeSortAndCount(int[] arr, int[] temp, int left, int right)
        {
            int mid, inv_count = 0;
            if (left < right)
            {
                mid = (left + right) / 2;

                inv_count += MergeSortAndCount(arr, temp, left, mid);
                inv_count += MergeSortAndCount(arr, temp, mid + 1, right);

                inv_count += MergeAndCount(arr, temp, left, mid + 1, right);
            }
            return inv_count;
        }

        // Merge two sorted subarrays and count inversions
        public static int MergeAndCount(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i, j, k;
            int inv_count = 0;

            i = left;    // Starting index for left subarray
            j = mid;     // Starting index for right subarray
            k = left;    // Starting index to be sorted

            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];

                    // There are mid - i inversions, because all elements left to i in the left subarray
                    // are greater than arr[j]
                    inv_count += (mid - i);
                }
            }

            // Copy the remaining elements of left subarray, if any
            while (i <= mid - 1)
                temp[k++] = arr[i++];

            // Copy the remaining elements of right subarray, if any
            while (j <= right)
                temp[k++] = arr[j++];

            // Copy the sorted subarray into Original array
            for (i = left; i <= right; i++)
                arr[i] = temp[i];

            return inv_count;
        }
    }

    class Search2DSortedMatrix_M_13
    {
        /*
         * Explanation
            Initial Check:

            If the matrix is null or empty, return false.
            Starting Point:

            Begin at the top-right corner of the matrix.
            Traversal:

            If the current element is equal to the target, return true.
            If the current element is greater than the target, move left to decrease the value.
            If the current element is less than the target, move down to increase the value.
            Exit Condition:

            The loop continues until we either find the target or move out of the matrix bounds.
            Time and Space Complexity
            Time Complexity: O(N + M) - Where N is the number of rows and M is the number of columns. In the worst case, we traverse N rows and M columns.

            Space Complexity: O(1) - No additional space is used that scales with the input size.
         */
        public static void SearchMatrixDriver()
        {
            int[,] matrix = {
                { 1, 4, 7, 11, 15 },
                { 2, 5, 8, 12, 19 },
                { 3, 6, 9, 16, 22 },
                { 10, 13, 14, 17, 24 },
                { 18, 21, 23, 26, 30 }
            };
            PrintMatrix(matrix);

            int target = 5;
            bool result = SearchMatrix(matrix, target);
            Console.WriteLine($"Target {target} found in matrix: {result}");

            target = 20;
            result = SearchMatrix(matrix, target);
            Console.WriteLine($"Target {target} found in matrix: {result}");
        }

        public static bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return false;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int row = 0;
            int col = cols - 1;

            while (row < rows && col >= 0)
            {
                if (matrix[row, col] == target)
                {
                    return true;
                }
                else if (matrix[row, col] > target)
                {
                    col--; // Move left
                }
                else
                {
                    row++; // Move down
                }
            }

            return false;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }

    class XpowerN_M_14
    {
        /*
         * To implement an optimized version of calculating ( x^n ) (x raised to the power n), we can use the method of **Exponentiation by Squaring**. This method allows us to compute the power in ( O(log n) ) time, which is very efficient.

                ### Approach

                Exponentiation by Squaring works as follows:
                1. If ( n ) is 0, ( x^n ) is 1 (since any number to the power of 0 is 1).
                2. If ( n ) is negative, ( x^n ) is ( frac{1}{x^{-n}} ).
                3. If ( n ) is even, ( x^n ) is ( (x^2)^{n/2} ).
                4. If ( n ) is odd, ( x^n ) is ( x times x^{n-1} ).

                ### Explanation

                1. **Base Case**: If ( n ) is 0, return 1.
                2. **Divide and Conquer**:
                   - Recursively calculate `half = Pow(x, n / 2)`.
                   - If ( n ) is even, ( x^n = half times half ).
                   - If ( n ) is odd and positive, ( x^n = x times half times half ).
                   - If ( n ) is odd and negative, ( x^n = frac{half times half}{x} ).

                ### Time and Space Complexity

                The time complexity of this method is ( O(log n) ), as each step reduces the problem size by half.
                Space Complexity: O(log n) - Due to the recursion stack used in the algorithm.

                ### Example Walkthrough

                For ( x = 2 ) and ( n = 10 ):
                - Call Pow(2, 10):
                  - Call Pow(2, 5):
                    - Call Pow(2, 2):
                      - Call Pow(2, 1):
                        - Call Pow(2, 0): returns 1.
                        - Since ( n = 1 ) is odd, return ( 2 times 1 times 1 = 2 ).
                      - Since ( n = 2 ) is even, return ( 2 times 2 = 4 ).
                    - Since ( n = 5 ) is odd, return ( 2 times 4 times 4 = 32 ).
                  - Since ( n = 10 ) is even, return ( 32 times 32 = 1024 ).

                For ( x = 2 ) and ( n = -2 ):
                - Call Pow(2, -2):
                  - Call Pow(2, -1):
                    - Call Pow(2, -2 / 2 = 0): returns 1.
                    - Since ( n = -1 ) is odd, return ( frac{1 times 1}{2} = 0.5 ).
                  - Since ( n = -2 ) is even, return ( 0.5 times 0.5 = 0.25 ).

                This approach ensures that the calculation is done efficiently with a logarithmic time complexity.
         */

        public static void XpowerNDriver()
        {
            double x = 2.0;
            int n = 10;
            Console.WriteLine($"Pow({x}, {n}) = {XpowerN(x, n)}");

            x = 2.0;
            n = -2;
            Console.WriteLine($"Pow({x}, {n}) = {XpowerN(x, n)}");
        }

        public static double XpowerN(double x, int n)
        {
            if (n == 0)
                return 1;

            double half = XpowerN(x, n / 2);

            if (n % 2 == 0) // is even
                return half * half;
            else
            {
                if (n > 0) // is odd and positive
                    return x * half * half;
                else // is odd and negative
                    return (half * half) / x;
            }
        }
    }

    class MajorityElementsNby2_E_15
    {
        /* BOYER-MOORE Voting Algorithm.
        Finding the majority element in an array (an element that appears more than N/2 times) can be efficiently done using the** Boyer-Moore Voting Algorithm**. This algorithm works in O(N) time complexity and O(1) space complexity.

        ### Algorithm Explanation

        1. **Candidate Selection Phase**:
           -Initialize a candidate and a count.
           - Iterate through the array.
           - If the count is 0, set the current element as the candidate.
           - If the current element is the same as the candidate, increment the count.
           - If the current element is different from the candidate, decrement the count.

        2. **Candidate Verification Phase**:
           -After the first phase, the candidate might be the majority element.
           - Verify the candidate by counting its occurrences in the array to ensure it appears more than ⌊N/2⌋ times.

        ### Implementation in C#

        Here is the implementation of the Boyer-Moore Voting Algorithm in C#:

        ```

        ### Explanation

        1. * *GetCandidate Method * *:
           -Initialize `candidate` and `count`.
           - Traverse through the array.
           - Adjust `candidate` and `count` based on the current element.
   
        2. **IsMajority Method**:
           -Count the occurrences of the candidate in the array.
           - Check if the count is greater than N/2.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - The algorithm makes two passes over the array.

        **Space Complexity**: O(1) - Only a few extra variables are used.

        This efficient algorithm ensures that you can find the majority element in linear time and constant space.
        */

        public static int FindMajorityElementNby2Times(int[] nums)
        {
            int candidate = GetCandidate(nums);
            if (IsMajorityNby2(nums, candidate))
            {
                return candidate;
            }
            return -1; // No majority element
        }

        // Phase 1: Find a candidate
        private static int GetCandidate(int[] nums)
        {
            int count = 0;
            int candidate = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate) ? 1 : -1;
            }
            return candidate;
        }

        // Phase 2: Verify the candidate
        private static bool IsMajorityNby2(int[] nums, int candidate)
        {
            int count = 0;
            foreach (int num in nums)
            {
                if (num == candidate)
                {
                    count++;
                }
            }
            return count > nums.Length / 2;
        }

        public static void MajorityElementDriver()
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2 };
            Console.WriteLine("Original array: " + string.Join(", ", nums));
            int resultNby2 = FindMajorityElementNby2Times(nums);
            if (resultNby2 != -1)
            {
                Console.WriteLine($"The majority element N/2 times is {resultNby2}");
            }
            else
            {
                Console.WriteLine("No majority element found.");
            }
        }
    }

    class MajorityElementNby3_M_16
    {
        /* BOYER-MOORE Voting Algorithm.
         *  To find all elements that appear more than ⌊N/3⌋ times in an array, 
         *  we can extend the Boyer-Moore Voting Algorithm to handle up to two potential candidates since there can be at most two such elements in an array.

            ### Approach

            1. **Candidate Selection Phase**:
               -Use two candidate variables and their respective counts.
               - Traverse the array:
                 -If the current element matches one of the candidates, increment its count.
                 - If one of the counts is zero, set the current element as the new candidate with a count of one.
                 - If the current element doesn't match either candidate, decrement both counts.

            2. **Candidate Verification Phase**:
               -Verify the two candidates by counting their occurrences in the array.
               - Return the candidates that appear more than ⌊N/3⌋ times.

    
            ### Explanation

            1. * *GetCandidates Method * *:
               -Initializes two candidate variables and their counts.
               - Iterates through the array:
                 -If the current element matches one of the candidates, increment the corresponding count.
                 - If a count is zero, set the current element as the new candidate and reset the count.
                 - If the current element doesn't match either candidate, decrement both counts.
   
            2. **VerifyCandidates Method**:
               -Counts the occurrences of the two candidates.
               - Adds the candidates to the result list if they appear more than ⌊N/3⌋ times.

            ### Time and Space Complexity

            **Time Complexity**: O(N) - The algorithm makes two passes over the array.

            **Space Complexity**: O(1) - Only a few extra variables are used.

            This efficient approach ensures that we can find all elements that appear more than ⌊N/3⌋ times in linear time and constant space.

         */

        public static IList<int> FindMajorityElements(int[] nums)
        {
            int candidate1, candidate2, count1, count2;
            GetCandidates(nums, out candidate1, out candidate2, out count1, out count2);

            List<int> result = new List<int>();
            VerifyCandidates(nums, candidate1, candidate2, result);

            return result;
        }

        private static void GetCandidates(int[] nums, out int candidate1, out int candidate2, out int count1, out int count2)
        {
            candidate1 = candidate2 = 0;
            count1 = count2 = 0;

            foreach (int num in nums)
            {
                if (num == candidate1)
                {
                    count1++;
                }
                else if (num == candidate2)
                {
                    count2++;
                }
                else if (count1 == 0)
                {
                    candidate1 = num;
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    candidate2 = num;
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }
        }

        private static void VerifyCandidates(int[] nums, int candidate1, int candidate2, List<int> result)
        {
            int count1 = 0, count2 = 0;
            foreach (int num in nums)
            {
                if (num == candidate1) count1++;
                else if (num == candidate2) count2++;
            }

            if (count1 > nums.Length / 3) result.Add(candidate1);
            if (count2 > nums.Length / 3) result.Add(candidate2);
        }

        public static void MajorityElementDriver()
        {
            int[] nums = { 3, 2, 3 };
            IList<int> result = FindMajorityElements(nums);
            Console.WriteLine("Majority elements: " + string.Join(", ", result));

            nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            result = FindMajorityElements(nums);
            Console.WriteLine("Majority elements: " + string.Join(", ", result));
        }
    }

    class GridUniquePaths_M_17
    {
        /*
         * 
            To count the number of unique paths from the top-left corner to the bottom-right corner of an ( M times N ) grid, you can use dynamic programming. The idea is to build up the solution by solving subproblems: the number of ways to reach each cell in the grid.

            ### Dynamic Programming Approach

            1. **Initialize a 2D array `dp`**:
               - `dp[i][j]` will store the number of unique paths to reach cell ((i, j)).

            2. **Base Case**:
               - There is only one way to reach any cell in the first row (`dp[0][j] = 1`) because you can only move right.
               - There is only one way to reach any cell in the first column (`dp[i][0] = 1`) because you can only move down.

            3. **Fill the `dp` Table**:
               - For each cell ((i, j)) not in the first row or first column, the number of unique paths to reach ((i, j)) is the sum of the number of paths to reach the cell directly above it and the number of paths to reach the cell directly to the left of it:
                 [
                 dp[i][j] = dp[i-1][j] + dp[i][j-1]
                 ]

            4. **Result**:
               - The number of unique paths to reach the bottom-right corner will be stored in `dp[M-1][N-1]`.


            ### Explanation

            1. **Initialization**:
               - The first row and first column are initialized to 1 because there's only one way to reach any of those cells from the starting point.

            2. **DP Table Filling**:
               - For each cell not in the first row or first column, `dp[i, j]` is computed as the sum of the paths to the cell directly above and the cell directly to the left.

            ### Time and Space Complexity

            **Time Complexity**: O(M * N) - We fill an ( M times N ) grid once.

            **Space Complexity**: O(M * N) - We use an ( M times N ) array to store the number of paths.

            This approach ensures an efficient computation of the number of unique paths in a grid using dynamic programming.
        To count the number of unique paths from the top-left corner to the bottom-right corner of an ( M times N ) grid, you can use dynamic programming.
        The idea is to build up the solution by solving subproblems: the number of ways to reach each cell in the grid.

            ### Dynamic Programming Approach

            1. **Initialize a 2D array `dp`**:
               - `dp[i][j]` will store the number of unique paths to reach cell ((i, j)).

            2. **Base Case**:
               - There is only one way to reach any cell in the first row (`dp[0][j] = 1`) because you can only move right.
               - There is only one way to reach any cell in the first column (`dp[i][0] = 1`) because you can only move down.

            3. **Fill the `dp` Table**:
               - For each cell ((i, j)) not in the first row or first column, the number of unique paths to reach ((i, j)) is the sum of the number of paths to reach the cell directly
        above it and the number of paths to reach the cell directly to the left of it:
                 [
                 dp[i][j] = dp[i-1][j] + dp[i][j-1]
                 ]

            4. **Result**:
               - The number of unique paths to reach the bottom-right corner will be stored in `dp[M-1][N-1]`.

            ```

            ### Explanation

            1. * *Initialization * *:
               -The first row and first column are initialized to 1 because there's only one way to reach any of those cells from the starting point.

            2. **DP Table Filling**:
               -For each cell not in the first row or first column, `dp[i, j]` is computed as the sum of the paths to the cell directly above and the cell directly to the left.

            ### Time and Space Complexity

            **Time Complexity**: O(M * N) - We fill an ( M times N ) grid once.

            **Space Complexity**: O(M * N) - We use an ( M times N ) array to store the number of paths.

            This approach ensures an efficient computation of the number of unique paths in a grid using dynamic programming.

        */

        public static int UniquePaths(int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;

            int[,] dp = new int[m, n];

            // Initialize the first row and first column
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }

            // Fill the rest of the dp array
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i,j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }

        public static void GridUniquePathsDriver()
        {
            int m = 3, n = 7;
            Console.WriteLine($"Number of unique paths in a {m}x{n} grid: {UniquePaths(m, n)}");

            m = 3;
            n = 2;
            Console.WriteLine($"Number of unique paths in a {m}x{n} grid: {UniquePaths(m, n)}");
        }
    }

    class ReversePairs_H_18
    {
        /*
                To count reverse pairs in an array efficiently, you can use a modified version of the merge sort algorithm, known as merge sort with inversion count.
         This approach leverages the divide and conquer strategy to count the reverse pairs while sorting the array.

            Approach
            Merge Sort with Inversion Count:

            Divide the array into two halves.
            Recursively sort the two halves and count the number of reverse pairs in each half.
            Merge the sorted halves while counting the number of reverse pairs across them.
            Counting Reverse Pairs during Merge:

            While merging, if left[i] > 2 * right[j], where left and right are the two sorted halves, then all elements after left[i] in the left half will also form reverse pairs with right[j].
             So, increment the count by the number of remaining elements in the left half.
            Return Total Count:

            The total count of reverse pairs is the sum of reverse pairs in the left half, reverse pairs in the right half, and reverse pairs formed during the merge step.

                Explanation
            MergeSortWithCount Method:

            Recursively divides the array into two halves and counts the number of reverse pairs in each half.
            Merges the sorted halves while counting the reverse pairs formed during the merge step.
            Merge Method:

            Merges two sorted halves while counting the reverse pairs.
            If nums[i] > 2 * nums[j], where i is an index in the left half and j is an index in the right half, then there are mid - i + 1 reverse pairs.
            Time and Space Complexity
            Time Complexity: O(N log N) - The merge sort algorithm.

            Space Complexity: O(N) - Additional space is required for the temporary array used during merging.

            This approach efficiently counts the number of reverse pairs in an array in O(N log N) time.
        */

        public static int CountReversePairs(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return 0;

            return MergeSortAndCount(arr, 0, arr.Length - 1);
        }

        private static int MergeSortAndCount(int[] arr, int left, int right)
        {
            if (left >= right)
                return 0;

            int mid = left + (right - left) / 2;
            int count = MergeSortAndCount(arr, left, mid) + MergeSortAndCount(arr, mid + 1, right);
            count += CountAndMerge(arr, left, mid, right);
            return count;
        }

        private static int CountAndMerge(int[] arr, int left, int mid, int right)
        {
            int count = 0;
            int j = mid + 1;

            // Count reverse pairs
            for (int i = left; i <= mid; i++)
            {
                while (j <= right && arr[i] > 2L * arr[j])
                {
                    j++;
                }
                count += j - (mid + 1);
            }

            // Merge step
            int[] temp = new int[right - left + 1];
            int i1 = left, j1 = mid + 1, k = 0;

            while (i1 <= mid && j1 <= right)
            {
                if (arr[i1] <= arr[j1])
                {
                    temp[k++] = arr[i1++];
                }
                else
                {
                    temp[k++] = arr[j1++];
                }
            }

            while (i1 <= mid)
            {
                temp[k++] = arr[i1++];
            }

            while (j1 <= right)
            {
                temp[k++] = arr[j1++];
            }

            Array.Copy(temp, 0, arr, left, temp.Length);

            return count;
        }

        public static void ReversePairsDriver()
        {
            int[] arr = { 1, 3, 2, 3, 1 };
            Console.WriteLine($"Number of reverse pairs: {CountReversePairs(arr)}");

            arr = new int[] { 2, 4, 3, 5, 1 };
            Console.WriteLine($"Number of reverse pairs: {CountReversePairs(arr)}");
        }
    }

    class TwoSum_M_19
    {
        /*
         * Two Sum : Check if a pair with given sum exists in Array
            Certainly! You can achieve this without using extra space by utilizing a two-pointer approach. However, this method requires the array to be sorted beforehand.

            ### Approach

            1. **Sort the Array**:
               -Sort the given array in non-decreasing order. This sorting step usually takes O(N log N) time.

            2. **Two Pointer Technique**:
               -Initialize two pointers, `left` pointing to the beginning of the array and `right` pointing to the end.
               - Move `left` towards the right and `right` towards the left:
                 -If the sum of elements at `left` and `right` equals the target sum, return true.
                 - If the sum is less than the target, increment `left`.
                 - If the sum is greater than the target, decrement `right`.
               - Repeat this process until `left` is less than `right`.

            3. **Return False**:
               -If no pair with the given sum is found after traversing the array, return false.

            ```

            ### Explanation

            1. * *Sorting * *:
               -Sort the array in non-decreasing order.

            2. **Two Pointer Technique**:
               -Initialize two pointers, `left` at the start and `right` at the end of the array.
               - While `left` is less than `right`:
                 -Calculate the sum of elements at `left` and `right`.
                 - If the sum equals the target, return true.
                 - If the sum is less than the target, increment `left`.
                 - If the sum is greater than the target, decrement `right`.

            3. **Return Value**:
               -If no pair with the given sum is found, return false.

            ### Time Complexity

            **Time Complexity**: O(N log N) - Sorting the array takes O(N log N) time.

            ### Space Complexity

            **Space Complexity**: O(1) - No extra space is used apart from a few variables.
            */

        public static bool HasPairWithSum(int[] nums, int target)
        {
            Array.Sort(nums);
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == target)
                {
                    return true;
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return false;
        }

        public static void TwoSumDriver()
        {
            int[] nums = { 2, 7, 11, 15 };
            Console.WriteLine("Input array: " + string.Join(", ", nums));
            int target = 9;
            Console.WriteLine("Pair with sum " + target + " exists: " + HasPairWithSum(nums, target));

            nums = new int[] { 3, 2, 4 };
            Console.WriteLine("Input array: " + string.Join(", ", nums));
            target = 6;
            Console.WriteLine("Pair with sum " + target + " exists: " + HasPairWithSum(nums, target));
        }


        // USING HASH SET
        /*
                To check if a pair with a given sum exists in an array, you can use a hash set to efficiently track the elements you've seen so far.

            ### Approach

            1. **Initialize a HashSet**:
               - Create a HashSet to store the elements of the array as you iterate through them.

            2. **Iterate Through the Array**:
               - For each element `num` in the array:
                 - Calculate the difference `target - num`.
                 - Check if this difference exists in the HashSet. If it does, return true (indicating that a pair with the given sum exists).
                 - If the difference does not exist in the HashSet, add the current element to the HashSet.

            3. **Return False**:
               - If you iterate through the entire array without finding a pair with the given sum, return false.


            ```

            ### Explanation

            1. * *HashSet Initialization * *:
               -Create a HashSet to store the elements of the array.

            2. **Iteration**:
               -Iterate through each element of the array.
               - For each element `num`, calculate its complement (`target - num`).
               - Check if the complement exists in the HashSet.If it does, return true.
               - If the complement does not exist, add the current element to the HashSet.

            3. **Return Value**:
               -If no pair with the given sum is found after iterating through the array, return false.

            ### Time and Space Complexity

            **Time Complexity**: O(N) - We iterate through the array once.

            **Space Complexity**: O(N) - We store at most N elements in the HashSet.

            This approach efficiently determines whether a pair with the given sum exists in the array.
       */

        public static bool HasPairWithSumUsingHashSet(int[] nums, int target)
        {
            HashSet<int> seen = new HashSet<int>();

            foreach (int num in nums)
            {
                int complement = target - num;
                if (seen.Contains(complement))
                {
                    return true;
                }
                seen.Add(num);
            }

            return false;
        }

        public static void TwoSumDriverUsingHashSet()
        {
            int[] nums = { 2, 7, 11, 15 };
            Console.WriteLine("Input array: " + string.Join(", ", nums));
            int target = 9;
            Console.WriteLine("Pair with sum " + target + " exists: " + HasPairWithSumUsingHashSet(nums, target));

            nums = new int[] { 3, 2, 4 };
            Console.WriteLine("Input array: " + string.Join(", ", nums));
            target = 6;
            Console.WriteLine("Pair with sum " + target + " exists: " + HasPairWithSumUsingHashSet(nums, target));
        }
    }

    public class ThreeSum_M_25
    {
        /*
        To solve the 3 Sum problem, where we need to find unique triplets in an array that add up to zero, 
        we can use a sorted array and a two-pointer approach.
        This approach ensures that we get an optimal solution in terms of time complexity.

        ### Approach

        1. **Sort the Array**:
           - Sorting the array helps in efficiently using the two-pointer technique to find pairs that sum up to a specific value.

        2. **Iterate and Use Two Pointers**:
           - Fix one element and use two pointers to find pairs that sum up to the negative of the fixed element.
           - Adjust the pointers based on the sum of the triplet to zero.

        3. **Avoid Duplicates**:
           - Skip duplicate elements to ensure the uniqueness of the triplets.

                         
        ### Explanation

        1. ** Sort the Array**:
           - Sorting the array helps to easily skip duplicates and to use the two-pointer technique.

        2. **Iterate and Use Two Pointers**:
           - Fix one element (`nums[i]`) and set two pointers: `left` (starting just after the fixed element)
        and `right` (starting from the end of the array).
           -Calculate the target as the negative of the fixed element.
           - Adjust the pointers based on whether the sum of `nums[left]` and `nums[right]` is less than, greater than, or equal to the target.

        3. * *Avoid Duplicates * *:
           -Skip duplicate elements for the fixed element, `nums[i]`,
        and for the elements at `left` and `right` pointers to ensure all triplets are unique.

        ### Time and Space Complexity

        * *Time Complexity * *: O(N ^ 2) - Sorting the array takes O(N log N) time and finding the triplets takes O(N ^ 2) time.

        * *Space Complexity * *: O(1) - Apart from the space required to store the result, no additional space proportional to the input size is used.

        This approach efficiently finds all unique triplets that sum up to zero using sorting and the two-pointer technique.

        */
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            // Step 1: Sort the array
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                // Skip duplicates for the first element of the triplet
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int left = i + 1;
                int right = nums.Length - 1;
                int target = -nums[i];

                while (left < right)
                {
                    int sum = nums[left] + nums[right];
                    if (sum == target)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Skip duplicates for the second and third elements of the triplet
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }

        public static void ThreeSumDriver()
        {
            ThreeSum_M_25 solution = new ThreeSum_M_25();
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = solution.ThreeSum(nums);

            Console.WriteLine("Triplets that sum up to zero:");
            foreach (var triplet in triplets)
            {
                Console.WriteLine($"[{string.Join(", ", triplet)}]");
            }
        }
    }

    class FourSum_H_20
    {
        /*
          To find all unique quadruplets that add up to a target value in an array, you can use a similar approach to the three-sum problem, extending it to four elements. Here's how you can do it:

          ### Approach

          1. **Sort the Array**:
             - Sort the given array in non-decreasing order. Sorting the array helps in avoiding duplicate quadruplets.

          2. **Fix First Two Elements**:
             - Iterate over the array from index 0 to `N - 3`, fixing the first element `arr[i]` and the second element `arr[j]`.

          3. **Fix Remaining Two Elements with Two Pointer Technique**:
             - Use a nested loop with two pointers, `left` and `right`, to find the remaining two elements such that their sum equals the target minus the sum of the first two elements (`target - arr[i] - arr[j]`).
             - Increment `left` if the sum is less than the target, or decrement `right` if the sum is greater than the target.
             - If the sum equals the target, add the quadruplet `[arr[i], arr[j], arr[left], arr[right]]` to the result.

          4. **Avoid Duplicates**:
             - Skip duplicate elements when fixing the first two elements (`arr[i]` and `arr[j]`).
             - Skip duplicate quadruplets to ensure uniqueness.

          ### Approach

          1. **Sort the Array**:
             - Sort the given array in non-decreasing order. Sorting the array helps in avoiding duplicate quadruplets.

          2. **Fix First Two Elements**:
             - Iterate over the array from index 0 to `N - 3`, fixing the first element `arr[i]` and the second element `arr[j]`.

          3. **Fix Remaining Two Elements with Two Pointer Technique**:
             - Use a nested loop with two pointers, `left` and `right`, to find the remaining two elements such that their sum equals the target minus the sum of the first two elements (`target - arr[i] - arr[j]`).
             - Increment `left` if the sum is less than the target, or decrement `right` if the sum is greater than the target.
             - If the sum equals the target, add the quadruplet `[arr[i], arr[j], arr[left], arr[right]]` to the result.

          4. **Avoid Duplicates**:
             - Skip duplicate elements when fixing the first two elements (`arr[i]` and `arr[j]`).
             - Skip duplicate quadruplets to ensure uniqueness.

              Explanation
          Sorting:

          Sort the array in non-decreasing order to simplify the process of finding quadruplets and avoid duplicates.
          Fixing First Two Elements:

          Iterate over the array from index 0 to N - 3, fixing the first element (arr[i]) and the second element (arr[j]).
          Two Pointer Technique:

          Use two pointers (left and right) to find the remaining two elements such that their sum equals the target minus the sum of the first two elements (target - arr[i] - arr[j]).
          Avoiding Duplicates:

          Skip duplicate elements when fixing the first two elements (arr[i] and arr[j]).
          Skip duplicate quadruplets to ensure uniqueness.
          Time and Space Complexity
          Time Complexity: O(N^3) - The nested loops and two-pointer technique together result in cubic time complexity.

          Space Complexity: O(N) - Additional space is used for storing the quadruplets.Explanation
        */

        public static IList<IList<int>> FindQuadruplets(int[] nums, int target)
        {
            IList<IList<int>> quadruplets = new List<IList<int>>();
            Array.Sort(nums);

            int n = nums.Length;

            for (int i = 0; i < n - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) // Skip duplicate elements
                    continue;

                for (int j = i + 1; j < n - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) // Skip duplicate elements
                        continue;

                    int left = j + 1, right = n - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            quadruplets.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });

                            while (left < right && nums[left] == nums[left + 1]) left++; // Skip duplicate elements
                            while (left < right && nums[right] == nums[right - 1]) right--; // Skip duplicate elements
                            left++;
                            right--;
                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }

            return quadruplets;
        }

        public static void FourSumDriver()
        {
            int[] nums = { 1, 0, -1, 0, -2, 2 };
            Console.WriteLine("Input array: " + string.Join(", ", nums));
            int target = 0;
            IList<IList<int>> result = FindQuadruplets(nums, target);

            Console.WriteLine("Quadruplets with sum " + target + ": ");
            foreach (var quad in result)
            {
                Console.WriteLine("[" + string.Join(", ", quad) + "]");
            }
        }

        // USING HASH SET
        /*
         * Sure, we can use a HashSet to store pairs of sums encountered during the iteration. This approach helps in avoiding duplicate quadruplets efficiently.

        Approach
        Initialize a HashSet:

        Create a HashSet to store pairs of sums encountered during the iteration.
        Iterate Over Pairs of Indices:

        Iterate over pairs of indices i and j to represent the first two elements of the quadruplet.
        For each pair of indices, iterate over the remaining elements of the array using two nested loops.
        Calculate Sum:

        Calculate the sum of elements at indices i and j (nums[i] + nums[j]).
        Check If Target Sum Exists:

        Check if the difference between the target sum and the current sum exists in the HashSet. If it does, add the quadruplet to the result.
        Add Sum of Current Pair:

        Add the sum of the current pair of elements to the HashSet.
        Implementation in C#
        Here's how you can implement this approach using a HashSet in C#:

        Explanation
        HashSet Initialization:

        Create a HashSet to store pairs of sums encountered during the iteration.
        Iterate Over Pairs of Indices:

        Iterate over pairs of indices i and j to represent the first two elements of the quadruplet.
        Calculate Sum:

        Calculate the sum of elements at indices i and j (nums[i] + nums[j]).
        Check If Target Sum Exists:

        Check if the difference between the target sum and the current sum exists in the HashSet. If it does, add the quadruplet to the result.
        Add Sum of Current Pair:

        Add the sum of the current pair of elements to the HashSet.
        Time and Space Complexity
        Time Complexity: O(N^2) - Two nested loops iterate over the array to form pairs of indices.

        Space Complexity: O(N) - Additional space is used for storing sums in the HashSet.
         */

        public static IList<IList<int>> FindQuadrupletsUsingHashSet(int[] nums, int target)
        {
            HashSet<int> sums = new HashSet<int>();
            IList<IList<int>> quadruplets = new List<IList<int>>();

            int n = nums.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int currentSum = nums[i] + nums[j];
                    int remainingSum = target - currentSum;

                    if (sums.Contains(remainingSum))
                    {
                        quadruplets.Add(new List<int> { remainingSum, nums[i], nums[j], target - remainingSum - currentSum });
                    }

                    sums.Add(currentSum);
                }
            }

            return quadruplets;
        }

        public static void FourSumDriverUsingHashSet()
        {
            int[] nums = { 1, 0, -1, 0, -2, 2 };
            int target = 0;
            IList<IList<int>> result = FindQuadrupletsUsingHashSet(nums, target);

            Console.WriteLine("Quadruplets with sum " + target + ": ");
            foreach (var quad in result)
            {
                Console.WriteLine("[" + string.Join(", ", quad) + "]");
            }
        }
    }

    class LongestConsecutiveSequence_M_21
    {
        /*
        To find the longest consecutive sequence in an array without using additional space like a hash set, you can use a sorting-based approach. Here’s how you can do it:

        ### Approach

        1. * *Sort the Array**:
           -First, sort the array. This will bring all consecutive elements next to each other.

        2. **Iterate and Count**:
           -Iterate through the sorted array and count the length of each consecutive sequence.
           - Track the maximum length of the consecutive sequences found.

    
        ### Explanation

        1. * *Sorting * *:
           -First, sort the array. Sorting brings all consecutive elements next to each other, making it easier to find sequences.

        2. **Iterate and Count**:
           -Initialize `longestStreak` and `currentStreak` to 1.
           - Iterate through the sorted array:
             -If the current element is equal to the previous element plus one, it is part of a consecutive sequence. Increment `currentStreak`.
             - If not, update `longestStreak` to be the maximum of `longestStreak` and `currentStreak`, and reset `currentStreak` to 1.
           - Finally, return the maximum of `longestStreak` and `currentStreak` to account for the last sequence in the array.

        ### Time and Space Complexity

        **Time Complexity**: O(N log N) - Sorting the array takes O(N log N) time.

        **Space Complexity**: O(1) - No additional space is used apart from a few variables.

        This approach ensures that we efficiently find the longest consecutive sequence in an array without using extra space like a hash set.
        */

        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            Array.Sort(nums);

            int longestStreak = 1;
            int currentStreak = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1]) // Check for duplicates
                {
                    if (nums[i] == nums[i - 1] + 1)
                    {
                        currentStreak++;
                    }
                    else
                    {
                        longestStreak = Math.Max(longestStreak, currentStreak);
                        currentStreak = 1;
                    }
                }
            }

            return Math.Max(longestStreak, currentStreak);
        }

        public static void LongestConsecutiveDriver()
        {
            int[] nums = { 100, 4, 200, 1, 3, 2 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            Console.WriteLine("Longest consecutive sequence length: " + LongestConsecutive(nums)); // Output: 4 (sequence: 1, 2, 3, 4)

            nums = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            Console.WriteLine("Longest consecutive sequence length: " + LongestConsecutive(nums)); // Output: 9 (sequence: 0 to 8)
        }

        // USING HASHSET
        /*
        To find the longest consecutive sequence in an array, you can use a hash set to achieve this in O(N) time complexity.Here's the approach:

        ### Approach

        1. **Use a HashSet for Fast Lookup**:
           - Add all elements of the array to a HashSet.This allows for O(1) average time complexity for checking if an element exists in the set.

        2. * *Find the Start of a Sequence * *:
           -Iterate through the array.For each element, check if it's the start of a sequence (i.e., `num - 1` is not in the set). If it is the start, count the length of the sequence by incrementing a counter until the next element (`num + 1`) is not found in the set.

        3. * *Track the Maximum Length * *:
           -Keep track of the maximum sequence length found during the iteration.


        ### Explanation

        1. **HashSet Initialization**:
        - Add all elements of the array to a HashSet for fast lookup.

        2. **Find the Start of a Sequence**:
        - Iterate through the array. For each element, check if it's the start of a sequence by verifying if `num - 1` is not in the set.
        - If it is the start of a sequence, count the length of the sequence by incrementing a counter until `num + 1` is not found in the set.

        3. **Track the Maximum Length**:
        - Keep track of the maximum sequence length found during the iteration.

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - Adding elements to the HashSet and iterating through the array both take linear time.

        **Space Complexity**: O(N) - Additional space is used for storing elements in the HashSet.

        This approach ensures an efficient solution for finding the longest consecutive sequence in an array.

        */

        public static int LongestConsecutiveUsingHashset(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            HashSet<int> numSet = new HashSet<int>(nums);
            int longestStreak = 0;

            foreach (int num in numSet)
            {
                // Only check for the start of a sequence
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }

        public static void LongestConsecutiveDriverUsingHashset()
        {
            int[] nums = { 100, 4, 200, 1, 3, 2 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            Console.WriteLine("Longest consecutive sequence length: " + LongestConsecutiveUsingHashset(nums));
            // Output: 4 (sequence: 1, 2, 3, 4)

            nums = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            Console.WriteLine("Longest consecutive sequence length: " + LongestConsecutiveUsingHashset(nums));
            // Output: 9 (sequence: 0 to 8)
        }
    }

    class LongestZeroSumSubarray_M_22
    {
        /*
        Finding the length of the longest subarray with zero sum without using a hash map can be done using a brute-force approach.However, this approach is less efficient and can be significantly slower for large arrays due to its higher time complexity.

        ### Approach

        1. **Iterate Over All Possible Subarrays**:
           -Use two nested loops to consider all subarrays. The outer loop sets the starting point of the subarray, and the inner loop extends the subarray to include additional elements.
   
        2. **Calculate the Sum of Each Subarray**:
           -For each subarray, calculate the sum of its elements.
   
        3. **Track the Maximum Length**:
           -If a subarray with a sum of zero is found, update the maximum length if the current subarray length is greater than the previously recorded maximum length.

    
        ### Explanation

        1. * *Nested Loops * *:
           -The outer loop starts at each index of the array (`i`), and the inner loop extends the subarray from this starting point (`j`).
   
        2. **Sum Calculation**:
           -For each subarray defined by indices `i` and `j`, the sum of elements is calculated.
   
        3. **Track Maximum Length**:
           -If the sum of the current subarray is zero, the length of the subarray is calculated and compared with the current `maxLength`. If it is greater, `maxLength` is updated.

        ### Time and Space Complexity

        **Time Complexity**: O(N ^ 2) - We have two nested loops, each running up to `N`, where `N` is the length of the array.

        **Space Complexity**: O(1) - No additional space is used apart from a few variables.

        This brute-force approach ensures that we can find the length of the longest subarray with a zero sum without using a hash map, but it is less efficient compared to the hash map method, especially for larger arrays.

        */
        public static int LongestSubarrayWithZeroSum(int[] nums)
        {
            int maxLength = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int currentSum = 0;

                for (int j = i; j < nums.Length; j++)
                {
                    currentSum += nums[j];

                    if (currentSum == 0)
                    {
                        maxLength = Math.Max(maxLength, j - i + 1);
                    }
                }
            }

            return maxLength;
        }

        public static void LongestSubarrayWithZeroSumDriver()
        {
            int[] nums = { 1, 2, -3, 3, 0, -3, 4, -4 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            Console.WriteLine("Length of the longest subarray with zero sum: " + LongestSubarrayWithZeroSum(nums)); // Output: 6

            nums = new int[] { 1, -1, 3, 2, -2, -3, 3 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            Console.WriteLine("Length of the longest subarray with zero sum: " + LongestSubarrayWithZeroSum(nums)); // Output: 5
        }

        // USING HASHMAP
        /*
        To find the length of the longest subarray with a zero sum, we can use a prefix sum approach with a hash map.This allows us to efficiently track the sum of elements up to each index and identify subarrays that sum to zero.

        ### Approach

        1. **Initialize Variables**:
           - Use a hash map to store the first occurrence of each prefix sum.
           - Initialize the `maxLength` variable to track the length of the longest subarray with a zero sum.
           - Initialize the `currentSum` variable to store the sum of elements up to the current index.

        2. **Iterate Through the Array**:
           - For each element in the array, add it to `currentSum`.
           - If `currentSum` is zero, update `maxLength` to the current index plus one (since the whole array up to this index has a zero sum).
           - If `currentSum` is already present in the hash map, calculate the length of the subarray between the previous occurrence and the current index, and update `maxLength` if this length is greater than the current `maxLength`.
           - If `currentSum` is not in the hash map, add it with the current index as its value.


        ### Explanation

        1. * *Hash Map Initialization**:
           -Use a hash map (`prefixSumMap`) to store the first occurrence of each prefix sum.

        2. **Iterate Through the Array**:
           -For each element, add it to `currentSum`.
           - If `currentSum` is zero, update `maxLength` to the current index plus one.
           - If `currentSum` is already in the hash map, calculate the length of the subarray from the previous occurrence to the current index and update `maxLength`.
           - If `currentSum` is not in the hash map, add it with the current index.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - We iterate through the array once.

        **Space Complexity**: O(N) - Additional space is used for storing prefix sums in the hash map.

        This approach ensures that we efficiently find the length of the longest subarray with a zero sum.
      */

        public static int LongestSubarrayWithZeroSumUsingHashmap(int[] nums)
        {
            Dictionary<int, int> prefixSumMap = new Dictionary<int, int>();
            int maxLength = 0;
            int currentSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentSum += nums[i];

                if (currentSum == 0)
                {
                    maxLength = i + 1;
                }

                if (prefixSumMap.ContainsKey(currentSum))
                {
                    maxLength = Math.Max(maxLength, i - prefixSumMap[currentSum]);
                }
                else
                {
                    prefixSumMap[currentSum] = i;
                }
            }

            return maxLength;
        }

        public static void LongestSubarrayWithZeroSumDriverUsingHashmap()
        {
            int[] nums = { 1, 2, -3, 3, 0, -3, 4, -4 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            Console.WriteLine("Length of the longest subarray with zero sum: " + LongestSubarrayWithZeroSum(nums)); 
            // Output: 6

            nums = new int[] { 1, -1, 3, 2, -2, -3, 3 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            Console.WriteLine("Length of the longest subarray with zero sum: " + LongestSubarrayWithZeroSum(nums));
            // Output: 5
        }
    }

    class SubarraysWithGivenXOR_H_23
    {
        /*
        Counting the number of subarrays with a given XOR ( K ) without using a hash map is quite challenging because the hash map is key to achieving an optimal solution. However, we can explore a different approach, such as using brute force, which will not be optimal but does not use extra space like a hash map.

        ### Approach

        1. **Brute Force**:
           -Iterate over all possible subarrays using two nested loops.
           - For each subarray, calculate the XOR of its elements.
           - If the XOR of a subarray equals ( K ), increment the count.

        ### Explanation

        1. * *Nested Loops * *:
           -The outer loop sets the starting point of the subarray.
           - The inner loop extends the subarray to include additional elements.

        2. **Calculate XOR**:
           -For each subarray defined by indices ( i ) and ( j ), calculate the XOR of its elements.

        3. **Count Subarrays**:
           -If the XOR of the current subarray equals ( K ), increment the count.

        ### Time and Space Complexity

        **Time Complexity**: O(N ^ 2) - Two nested loops result in a quadratic time complexity.

        **Space Complexity**: O(1) - No additional space is used apart from a few variables.

        ### Note

        The brute-force approach is not optimal and can be inefficient for large arrays. The optimal solution using a hash map, as previously explained, achieves O(N) time complexity and is generally preferred for this problem. If you need to stick with an O(1) space solution, this brute-force method is the straightforward alternative.
        */

        public static int CountSubarraysWithXOR(int[] nums, int K)
        {
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int currentXor = 0;

                for (int j = i; j < nums.Length; j++)
                {
                    currentXor ^= nums[j];

                    if (currentXor == K)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static void CountSubarraysWithXORDriver()
        {
            int[] nums = { 4, 2, 2, 6, 4 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            int K = 6;
            Console.WriteLine("Number of subarrays with XOR " + K + ": " + CountSubarraysWithXOR(nums, K)); // Output: 4

            nums = new int[] { 5, 6, 7, 8, 9 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            K = 5;
            Console.WriteLine("Number of subarrays with XOR " + K + ": " + CountSubarraysWithXOR(nums, K)); // Output: 2
        }

        // USING HASHMAP
        /*
        To count the number of subarrays with a given XOR \(K \), we can use a prefix XOR approach combined with a hash map to achieve an efficient solution.Here's how we can do it:

        ### Approach

        1. **Prefix XOR**:
           - Compute the XOR of all elements from the start of the array up to the current index.This is known as the prefix XOR.

        2. **Hash Map**:
           - Use a hash map to store the frequency of each prefix XOR encountered.
           - This helps in quickly finding the number of subarrays that satisfy the condition.

        3. **Count Subarrays**:
           - For each element in the array, compute the prefix XOR.
           - Check if there exists a prefix XOR that, when XORed with the current prefix XOR, equals (K ). If such a prefix XOR exists, it means the subarray from that point to the current index has an XOR of (K ).
           - Update the hash map with the current prefix XOR.

                ### Explanation

        1. * *Prefix XOR Calculation**:
           -For each element, compute the cumulative XOR from the start of the array to the current element.

        2. **Hash Map Usage**:
           -Use a hash map (`prefixXorMap`) to store the frequency of each prefix XOR.
           - For the current prefix XOR (`currentXor`), check if the XOR of `currentXor` and (K ) exists in the hash map(`targetXor`). If it exists, it means there are subarrays with XOR (K ).

        3. **Count Subarrays**:
           -Increment the count by the frequency of `targetXor` found in the hash map.
           - If `currentXor` is equal to (K ), increment the count since this implies a subarray from the start to the current index has XOR (K ).

        4. **Update Hash Map**:
           -Update the hash map with the current prefix XOR.

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - We iterate through the array once.

        **Space Complexity**: O(N) - We use additional space to store the prefix XOR frequencies in the hash map.

        This approach ensures an efficient solution to count the number of subarrays with a given XOR (K ).
            */
        public static int CountSubarraysWithXORUsingHashmap(int[] nums, int K)
        {
            Dictionary<int, int> prefixXorMap = new Dictionary<int, int>();
            int currentXor = 0;
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentXor ^= nums[i];

                if (currentXor == K)
                {
                    count++;
                }

                int targetXor = currentXor ^ K;
                if (prefixXorMap.ContainsKey(targetXor))
                {
                    count += prefixXorMap[targetXor];
                }

                if (prefixXorMap.ContainsKey(currentXor))
                {
                    prefixXorMap[currentXor]++;
                }
                else
                {
                    prefixXorMap[currentXor] = 1;
                }
            }

            return count;
        }

        public static void CountSubarraysWithXORDriverUsingHashmap()
        {
            int[] nums = { 4, 2, 2, 6, 4 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            int K = 6;
            Console.WriteLine("Number of subarrays with XOR " + K + ": " + CountSubarraysWithXOR(nums, K)); // Output: 4

            nums = new int[] { 5, 6, 7, 8, 9 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            K = 5;
            Console.WriteLine("Number of subarrays with XOR " + K + ": " + CountSubarraysWithXOR(nums, K)); // Output: 2
        }
    }

    class LongestSubstringWithoutRepeatingCharacters_M_24
    {
        /*
        To find the length of the longest substring without any repeating characters without using a hash set, we can use an array to track the last index of each character. This approach maintains the efficiency of the sliding window technique while avoiding the need for a hash set.

        ### Approach

        1. **Sliding Window with Array**:
           -Use two pointers(`left` and `right`) to represent the current window of characters.
           - Use an array `lastIndex` to store the last index of each character. The size of the array is 256 to cover all possible ASCII characters.

        2. **Expand the Window and Track Characters**:
           -Expand the window by moving the `right` pointer and updating the `lastIndex` array.
           - If a character is repeated, move the `left` pointer to one position after the last occurrence of the character.

        3. **Track the Maximum Length**:
           -Keep track of the maximum length of the substring found during the process.

        ### Explanation

        1. * *Initialization * *:
           - `lastIndex` is an array of size 256 (covering all ASCII characters), initialized to -1 to indicate that no character has been seen yet.
           - `maxLength` keeps track of the maximum length of substrings found.
           - `left` is the start of the current window.

        2. **Iterate Through the String**:
           -For each character at position `right`, check if the character was seen after the start of the current window (`left`). If it was, move the `left` pointer to one position after the last occurrence of the character.
           - Update the `lastIndex` of the current character to the current position (`right`).
           - Update `maxLength` with the length of the current window whenever it's larger than the previously recorded maximum.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - Each character is visited once by the `right` pointer, and the `left` pointer only moves forward.

        **Space Complexity**: O(1) - The `lastIndex` array uses a fixed amount of space (256 integers), independent of the input size.

        This approach ensures an optimal solution to find the length of the longest substring without any repeating characters while avoiding the use of a hash set.
            */

        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int[] lastIndex = new int[256];
            Array.Fill(lastIndex, -1);

            int maxLength = 0;
            int left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                if (lastIndex[s[right]] >= left)
                {
                    left = lastIndex[s[right]] + 1;
                }

                lastIndex[s[right]] = right;
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }

        public static void LengthOfLongestSubstringDriver()
        {
            string s = "abcabcbb";
            Console.WriteLine($"Current String: {s}");
            Console.WriteLine("Length of the longest substring without repeating characters: " + LengthOfLongestSubstring(s)); // Output: 3 ("abc")

            s = "bbbbb";
            Console.WriteLine($"Current String: {s}");
            Console.WriteLine("Length of the longest substring without repeating characters: " + LengthOfLongestSubstring(s)); // Output: 1 ("b")

            s = "pwwkew";
            Console.WriteLine($"Current String: {s}");
            Console.WriteLine("Length of the longest substring without repeating characters: " + LengthOfLongestSubstring(s)); // Output: 3 ("wke")
        }

        // USING HASHSET
        /*
        To find the length of the longest substring without any repeating characters efficiently, you can use the sliding window technique with a set.This approach ensures that we check each character only once, leading to an optimal solution.

        ### Approach

        1. **Sliding Window**:
           - Use two pointers (left and right) to represent the current window of characters.
           - Use a set to store characters in the current window to quickly check for duplicates.

        2. **Expand and Contract the Window**:
           - Expand the window by moving the right pointer and adding characters to the set.
           - If a duplicate character is encountered, contract the window by moving the left pointer until the duplicate is removed.

        3. **Track the Maximum Length**:
           - Keep track of the maximum length of the substring found during the process.

                                        
        ### Explanation

        1. * *Initialization**:
           - `maxLength` keeps track of the maximum length of substrings found.
           - `left` is the start of the current window.
           - `charSet` is a hash set that stores characters in the current window.

        2. **Iterate Through the String**:
           -Use the right pointer to expand the window by adding new characters to `charSet`.
           - If a duplicate character is encountered(i.e., `charSet` contains the character at `s[right]`), move the left pointer to the right until the duplicate character is removed from the window.
           - Update `maxLength` with the length of the current window whenever it's larger than the previously recorded maximum.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - Each character is visited at most twice(once by the right pointer and once by the left pointer).

        **Space Complexity * *: O(min(N, M)) - Space used by the hash set, where N is the length of the string and M is the size of the character set(e.g., 26 for lowercase English letters).

        This approach ensures an optimal and efficient solution to find the length of the longest substring without any repeating characters.
            */
        public static int LengthOfLongestSubstringUsingHashset(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int maxLength = 0;
            int left = 0;
            HashSet<char> charSet = new HashSet<char>();

            for (int right = 0; right < s.Length; right++)
            {
                while (charSet.Contains(s[right]))
                {
                    charSet.Remove(s[left]);
                    left++;
                }

                charSet.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }

        public static void LengthOfLongestSubstringDriverUsingHashset()
        {
            string s = "abcabcbb";
            Console.WriteLine($"Current String: {s}");
            Console.WriteLine("Length of the longest substring without repeating characters: " + LengthOfLongestSubstring(s)); // Output: 3 ("abc")

            s = "bbbbb";
            Console.WriteLine($"Current String: {s}");
            Console.WriteLine("Length of the longest substring without repeating characters: " + LengthOfLongestSubstring(s)); // Output: 1 ("b")

            s = "pwwkew";
            Console.WriteLine($"Current String: {s}");
            Console.WriteLine("Length of the longest substring without repeating characters: " + LengthOfLongestSubstring(s)); // Output: 3 ("wke")
        }
    }

    public class TrappingRainWater_H_26
    {
        /*
        The Trapping Rainwater problem can be efficiently solved using a two-pointer approach.
        This method ensures that we keep track of the maximum heights encountered from both ends of the array, 
        and calculate the trapped water based on these maximum heights.

        ### Approach

        1. **Initialize Two Pointers**:
           - Use two pointers, one starting from the beginning (`left`) and one from the end(`right`) of the array.
           - Also, initialize two variables to keep track of the maximum heights encountered 
        so far from the left(`leftMax`) and the right(`rightMax`).

        2. ** Calculate Trapped Water**:
           - Iterate through the array using the two pointers until they meet.
           - At each step, compare the heights at the left and right pointers.
           - If the height at the left pointer is less than or equal to the height at the right pointer,
        calculate the trapped water at the left pointer based on `leftMax`, update `leftMax`, and move the left pointer to the right.
           - Otherwise, calculate the trapped water at the right pointer based on `rightMax`, 
        update `rightMax`, and move the right pointer to the left.

        ### Explanation

        1. ** Initialize Two Pointers**:
           - `left` pointer starts at the beginning of the array.
           - `right` pointer starts at the end of the array.
           - `leftMax` and `rightMax` are initialized to 0.

        2. **Calculate Trapped Water**:
           - Iterate while `left` is less than `right`.
           - If `height[left]` is less than `height[right]`, compare `height[left]` with `leftMax`.
             - If `height[left]` is greater than or equal to `leftMax`, update `leftMax`.
             - Otherwise, calculate the trapped water at `left` and add it to the total.
           - If `height[left]` is greater than or equal to `height[right]`, compare `height[right]` with `rightMax`.
             - If `height[right]` is greater than or equal to `rightMax`, update `rightMax`.
             - Otherwise, calculate the trapped water at `right` and add it to the total.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - Each element in the array is processed exactly once.

        ** Space Complexity**: O(1) - Only a constant amount of extra space is used.

        This two-pointer approach efficiently calculates the amount of water trapped after rain using linear time and constant space.
        */

        public int TrappingRainWater(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }

            int left = 0;
            int right = height.Length - 1;
            int leftMax = 0;
            int rightMax = 0;
            int totalWater = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        totalWater += leftMax - height[left];
                    }
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        totalWater += rightMax - height[right];
                    }
                    right--;
                }
            }

            return totalWater;
        }

        public static void TrappingRainWaterDriver()
        {
            TrappingRainWater_H_26 solution = new TrappingRainWater_H_26();
            int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int trappedWater = solution.TrappingRainWater(height);
            Console.WriteLine($"Total water trapped: {trappedWater}"); // Output should be 6
        }
    }

    public class RemoveDuplicatesInPlaceInSortedArray_E_27
    {

        /*
        To remove duplicates from a sorted array in-place, we can use a two-pointer approach.
        This method ensures that each unique element is moved to the front of the array, and the duplicates are effectively ignored.

        ### Approach

        1. **Initialize Pointers**:
           - Use one pointer (`i`) to keep track of the position to place the next unique element.
           - Use another pointer (`j`) to iterate through the array.

        2. ** Iterate Through the Array**:
           - Iterate through the array with the `j` pointer.
           - If the current element(`nums[j]`) is different from the 
        last unique element(`nums[i - 1]`), move it to the `i` position and increment `i`.

        3. ** Return the Length of the Unique Elements**:
           - The pointer `i` will indicate the length of the array with unique elements.

        
        ### Explanation

        1. ** Initialize Pointers**:
           - Start with `i = 1` because the first element is always unique.
           - Use `j` to iterate through the array starting from the second element.

        2. **Iterate Through the Array**:
           - For each element from `nums[1]` to `nums[n - 1]`, compare it with the previous element.
           - If `nums[j]` is different from `nums[j - 1]`, assign it to `nums[i]` and increment `i`.

        3. **Return the Length of the Unique Elements**:
           - The pointer `i` will indicate the position where the next unique element should be placed,
        which is also the length of the array with unique elements.

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - Each element in the array is processed exactly once.

        ** Space Complexity**: O(1) - No extra space is used other than a few variables.

        This two-pointer approach efficiently removes duplicates from a sorted array in-place using linear time and constant space.
        */

        public int RemoveDuplicatesInPlaceInSortedArray(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int i = 1; // Start from the second element

            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[j - 1])
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            return i;
        }

        public static void RemoveDuplicatesInPlaceInSortedArrayDriver()
        {
            RemoveDuplicatesInPlaceInSortedArray_E_27 solution = new RemoveDuplicatesInPlaceInSortedArray_E_27();
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            int length = solution.RemoveDuplicatesInPlaceInSortedArray(nums);

            Console.WriteLine("Array after removing duplicates:");
            for (int i = 0; i < length; i++)
            {
                Console.Write(nums[i] + ", ");
            }
            Console.WriteLine(); // Output should be: 0 1 2 3 4
        }
    }

    public class FindMaxConsecutiveOnes_E_28
    {
        /*
        To count the maximum number of consecutive 1's in a binary array (an array consisting of only 0's and 1's),
        you can use a simple iteration approach to keep track of the current streak of 1's and the maximum streak encountered so far.

        ### Approach

        1. **Initialize Counters**:
           - `maxCount` to keep track of the maximum number of consecutive 1's.
           - `currentCount` to count the current streak of consecutive 1's.

        2. **Iterate Through the Array**:
           - For each element, if it is 1, increment `currentCount`.
           - If it is 0, compare `currentCount` with `maxCount` and update `maxCount` if necessary, then reset `currentCount` to 0.

        3. **Final Check**:
           - After the iteration, compare `currentCount` with `maxCount` one last time to account for a streak that may end at the last element of the array.


        ### Explanation

        1. ** Initialize Counters**:
           - `maxCount` is set to 0 to store the maximum number of consecutive 1's.
           - `currentCount` is set to 0 to store the current streak of consecutive 1's.

        2. ** Iterate Through the Array**:
           - For each element in the array:
             - If the element is 1, increment `currentCount` and update `maxCount` if `currentCount` exceeds `maxCount`.
             - If the element is 0, reset `currentCount` to 0 because the streak of 1's has ended.

        3. ** Final Check**:
           - At the end of the iteration, `maxCount` holds the maximum number of consecutive 1's encountered in the array.

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - The array is traversed once, where N is the length of the array.

        ** Space Complexity**: O(1) - Only a few variables are used regardless of the input size.

        This approach efficiently counts the maximum number of consecutive 1's in a binary array using linear time and constant space.
        */

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxCount = 0;
            int currentCount = 0;

            foreach (int num in nums)
            {
                if (num == 1)
                {
                    currentCount++;
                    maxCount = Math.Max(maxCount, currentCount);
                }
                else
                {
                    currentCount = 0;
                }
            }

            return maxCount;
        }

        public static void FindMaxConsecutiveOnesDriver()
        {
            FindMaxConsecutiveOnes_E_28 solution = new FindMaxConsecutiveOnes_E_28();
            int[] nums = { 1, 1, 0, 1, 1, 1 };
            Console.WriteLine("Current number: " + string.Join(", ", nums));
            int maxConsecutiveOnes = solution.FindMaxConsecutiveOnes(nums);
            Console.WriteLine($"Maximum number of consecutive 1's: {maxConsecutiveOnes}"); // Output should be 3
        }
    }


}
