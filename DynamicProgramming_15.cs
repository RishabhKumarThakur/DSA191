namespace DynamicProgramming
{
    public class MaximumProductSubarray_M_1
    {
        /*
        To find the maximum product subarray in an array using dynamic programming, you need to keep track of both the maximum and minimum products up to the current position.
        This is because a negative number can change a large minimum product to a maximum product when multiplied.

             Here's a detailed explanation and implementation of the solution:

            ### Explanation

            1. **Initialize Variables**:
               - `maxProd`: The maximum product subarray ending at the current position.
                - `minProd`: The minimum product subarray ending at the current position.
                - `result`: The global maximum product found so far.

            2. **Iterate Through the Array**:
               - For each element, you need to calculate the potential new `maxProd` and `minProd`.
               - Update `maxProd` to be the maximum of the current element, `maxProd` multiplied by the current element, and `minProd` multiplied by the current element.
               - Update `minProd` similarly.
               - Update the global `result` to be the maximum of `result` and `maxProd`.

            3. ** Handle Negative Numbers**:
               - If the current element is negative, swapping `maxProd` and `minProd` before updating them can help because a negative number turns a large positive product into a large negative product and vice versa.

            ### Explanation of the Code

            1. ** Initialization**:
               - `maxProd`, `minProd`, and `result` are initialized to the first element of the array.

            2. ** Iteration**:
               - Start iterating from the second element.
               - If the current element is negative, swap `maxProd` and `minProd`.
               - Update `maxProd` to the maximum of the current element, `maxProd` multiplied by the current element, and `minProd` multiplied by the current element.
               - Similarly, update `minProd`.
               - Update `result` to be the maximum of `result` and `maxProd`.

            3. **Result**:
               - Return the `result`, which contains the maximum product subarray.

            ### Complexity Analysis

            - **Time Complexity**: (O(n)), where (n) is the number of elements in the array.Each element is processed once.
            - **Space Complexity**: (O(1)). The algorithm uses a constant amount of space, regardless of the input size.

            This approach ensures that the solution is both time-efficient and space-efficient, making it optimal for this problem.
        */


        public static int MaxProduct(int[] nums)
        {
            if (nums.Length == 0) return 0;

            // Initialize variables
            int maxProd = nums[0];
            int minProd = nums[0];
            int result = nums[0];

            // Iterate through the array starting from the second element
            for (int i = 1; i < nums.Length; i++)
            {
                // If the current number is negative, swap maxProd and minProd
                if (nums[i] < 0)
                {
                    int temp = maxProd;
                    maxProd = minProd;
                    minProd = temp;
                }

                // Update maxProd and minProd
                maxProd = Math.Max(nums[i], maxProd * nums[i]);
                minProd = Math.Min(nums[i], minProd * nums[i]);

                // Update the result
                result = Math.Max(result, maxProd);
            }

            return result;
        }

        public static void MaximumProductSubarrayDriver()
        {
            int[] nums = { 2, 3, -2, 4 };
            Console.WriteLine($"Array : {string.Join(", ", nums)}");
            Console.WriteLine("Maximum Product Subarray: " + MaxProduct(nums)); // Output: 6

            int[] nums2 = { -2, 0, -1 };
            Console.WriteLine($"Array : {string.Join(", ", nums2)}");
            Console.WriteLine("Maximum Product Subarray: " + MaxProduct(nums2)); // Output: 0
        }
    }

    public class LongestIncreasingSubsequence_M_2
    {
        /*
        To find the longest increasing subsequence(LIS) in an array using dynamic programming, you can use a simple yet effective approach.
        This approach involves maintaining an array `dp` where `dp[i]` represents the length of the longest increasing subsequence that ends at the ith index.

        ### Steps to Solve the Problem:

        1. **Initialize**:
           - Create an array `dp` of the same length as the input array and initialize all elements to 1. This is because the smallest LIS ending at each element is the element itself.
           - Initialize a variable `maxLength` to 1 to keep track of the maximum length of the LIS found so far.

        2. **Dynamic Programming Transition**:
           - For each element in the array, check all previous elements.
           - If a previous element is smaller than the current element, update the current element’s `dp` value if the LIS ending at the current element can be extended by the previous element.

        3. **Update the Result**:
           - During the update process, also keep track of the maximum value in the `dp` array, which will be the length of the LIS.

        ### Explanation of the Code:

        1. ** Initialization**:
           - `dp` array is initialized with 1 because the minimum length of the increasing subsequence ending at any element is 1.
   
        2. ** Dynamic Programming Transition**:
           - For each element `nums[i]`, iterate through all previous elements `nums[j]`.
           - If `nums[i]` is greater than `nums[j]`, then check if the subsequence ending at `nums[j]` can be extended by `nums[i]`.
           - Update `dp[i]` to the maximum value of `dp[i]` and `dp[j] + 1`.

        3. ** Result Update**:
           - Keep track of the maximum length of the subsequence found so far and store it in `maxLength`.

        ### Complexity Analysis:

        - ** Time Complexity**: (O(n^2)), where (n) is the number of elements in the array.This is because there are two nested loops iterating over the array.
        - **Space Complexity**: (O(n)) for the `dp` array used to store the length of the longest increasing subsequence ending at each element.

        This dynamic programming approach ensures that you find the length of the longest increasing subsequence efficiently.

        */

        public static int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            // Initialize the dp array with 1s
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
            }

            int maxLength = 1;

            // Fill dp array
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                maxLength = Math.Max(maxLength, dp[i]);
            }

            return maxLength;
        }

        public static void LongestIncreasingSubsequenceDriver()
        {
            int[] nums = { 10, 9, 2, 5, 3, 7, 101, 18 };
            Console.WriteLine($"Array : {string.Join(", ", nums)}");
            Console.WriteLine("Length of Longest Increasing Subsequence: " + LengthOfLIS(nums)); // Output: 4

            int[] nums2 = { 0, 1, 0, 3, 2, 3 };
            Console.WriteLine($"Array : {string.Join(", ", nums2)}");
            Console.WriteLine("Length of Longest Increasing Subsequence: " + LengthOfLIS(nums2)); // Output: 4

            int[] nums3 = { 7, 7, 7, 7, 7, 7, 7 };
            Console.WriteLine($"Array : {string.Join(", ", nums3)}");
            Console.WriteLine("Length of Longest Increasing Subsequence: " + LengthOfLIS(nums3)); // Output: 1
        }
    }

    public class LongestCommonSubsequence_M_3
    {
        /*
        The Longest Common Subsequence(LCS) is a classic problem in dynamic programming.Given two strings,
        the task is to find the length of the longest subsequence that is present in both strings.
        A subsequence is a sequence that appears in the same relative order but not necessarily consecutively.

        ### Problem Statement

        Given two strings `text1` and `text2`, return the length of their longest common subsequence.

        ### Dynamic Programming Approach

        1. **Define the State**:
           - Let `dp[i][j]` represent the length of the longest common subsequence of `text1[0...i - 1]` and `text2[0...j - 1]`.

        2. **Initial State**:
           - `dp[0][j] = 0` for all `j` because an empty string has no common subsequence with any other string.
           - `dp[i][0] = 0` for all `i` for the same reason.

        3. **State Transition**:
           - If `text1[i - 1] == text2[j - 1]`, then `dp[i][j] = dp[i - 1][j - 1] + 1`.
           - Otherwise, `dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])`.

        4. **Result**:
           - The value at `dp[len1][len2]` will be the length of the LCS for `text1` and `text2`,
        where `len1` and `len2` are the lengths of the two strings.

        ### Explanation of the Code

        1. ** Initialization**:
           - Create a 2D array `dp` with dimensions `(len1 + 1) x(len2 + 1)` where `len1` is the length of `text1` and `len2` is the length of `text2`.
           - Initialize the first row and column of `dp` to 0 because an LCS with an empty string is 0.

        2. ** Filling the DP Table**:
           - Iterate through each character of `text1` and `text2`.
           - If the characters match, update the `dp` table by adding 1 to the value from the diagonal cell `dp[i - 1][j - 1]`.
           - If the characters do not match, take the maximum value from either the left cell `dp[i][j - 1]` or the top cell `dp[i - 1][j]`.

        3. ** Result**:
           - The value at `dp[len1][len2]` contains the length of the longest common subsequence.

        ### Complexity Analysis

        - **Time Complexity**: (O(n times m)), where (n) is the length of `text1` and (m) is the length of `text2`. 
        This is because we have two nested loops iterating through both strings.
        - **Space Complexity**: (O(n times m)) for the `dp` array used to store the lengths
        of the longest common subsequences for substrings of `text1` and `text2`.

        This approach ensures an efficient solution to the LCS problem using dynamic programming.
        */

        public static int LCS(string text1, string text2)
        {
            int len1 = text1.Length;
            int len2 = text2.Length;

            int[,] dp = new int[len1 + 1, len2 + 1];

            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[len1, len2];
        }

        public static void LongestCommonSubsequenceDriver()
        {
            string text1 = "abcde";
            string text2 = "ace";
            Console.WriteLine($"Length of Longest Common Subsequence between {text1} and {text2}: " + LCS(text1, text2)); // Output: 3

            string text3 = "abc";
            string text4 = "abc";
            Console.WriteLine($"Length of Longest Common Subsequence between {text3} and {text4}: " + LCS(text3, text4)); // Output: 3

            string text5 = "abc";
            string text6 = "def";
            Console.WriteLine($"Length of Longest Common Subsequence between {text5} and {text6}: " + LCS(text5, text6)); // Output: 0
        }
    }

    public class Knapsack01_H_4
    {
        /*
        The 0/1 Knapsack problem is a classic problem in dynamic programming.Given a set of items, each with a weight and a value,
        determine the maximum value that can be obtained by selecting items such that the total weight does not exceed a given limit.
        Each item can either be included in the knapsack or not (hence the name 0/1 knapsack).

        ### Problem Statement

        You are given `N` items, each with a weight `w[i]` and a value `v[i]`, and a knapsack with a capacity `W`.
        Find the maximum value that can be achieved by selecting items such that their total weight does not exceed `W`.


        ### Dynamic Programming Approach

        1. ** Define the State**:
           - Let `dp[i][w]` represent the maximum value that can be achieved using the first `i` items and a knapsack of capacity `w`.

        2. ** Initial State**:
           - `dp[0][w] = 0` for all `w` because with 0 items, the maximum value is 0.
           - `dp[i][0] = 0` for all `i` because with a knapsack of 0 capacity, the maximum value is 0.

        3. ** State Transition**:
           - For each item `i` and each capacity `w`:
             - If the weight of the item `i` is more than `w`, it cannot be included, so `dp[i][w] = dp[i - 1][w]`.
             - Otherwise, the item can be included or excluded.Thus, `dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - w[i]] + v[i])`.

        4. ** Result**:
           - The value at `dp[N][W]` will be the maximum value that can be achieved with `N` items and a knapsack of capacity `W`.

        ### Explanation of the Code

        1. ** Initialization**:
           - Create a 2D array `dp` with dimensions `(n + 1) x(W + 1)` where `n` is the number of items and `W` is the capacity of the knapsack.
           - Initialize the first row and column of `dp` to 0 because with 0 items or 0 capacity, the maximum value is 0.

        2. ** Filling the DP Table**:
           - Iterate through each item and each capacity.
           - If the weight of the current item is less than or equal to the current capacity,
        update the `dp` table by taking the maximum of including or excluding the current item.
           - If the weight of the current item is more than the current capacity, exclude the current item.

        3. **Result**:
           - The value at `dp[n][W]` contains the maximum value that can be achieved with `n` items and a knapsack of capacity `W`.

        ### Complexity Analysis

        - **Time Complexity**: (O(n times W)), where (n) is the number of items and (W) is the capacity of the knapsack.
        This is because we have two nested loops iterating through the items and capacities.
        - **Space Complexity**: (O(n times W)) for the `dp` array used to store the maximum values.

        This approach ensures an efficient solution to the 0/1 knapsack problem using dynamic programming.
        */

        public static int KnapsackDP(int[] weights, int[] values, int W)
        {
            int n = weights.Length;
            int[,] dp = new int[n + 1, W + 1];

            // Initializing the dp array
            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        dp[i, w] = 0;
                    }
                    else if (weights[i - 1] <= w)
                    {
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - weights[i - 1]] + values[i - 1]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[n, W];
        }

        public static void Knapsack01Driver()
        {
            int[] weights = { 1, 3, 4, 5 };
            Console.WriteLine($"Weights : {string.Join(", ", weights)}");

            int[] values = { 1, 4, 5, 7 };
            Console.WriteLine($"values : {string.Join(", ", values)}");

            int W = 7;
            Console.WriteLine($"capacity : {string.Join(", ", W)}");

            Console.WriteLine("Maximum value in Knapsack: " + KnapsackDP(weights, values, W)); // Output: 9
        }
    }

    public class EditDistance_H_5
    {
        /*
        The Edit Distance problem, also known as the Levenshtein distance, is a classic problem in dynamic programming.
        The goal is to find the minimum number of operations required to convert one string into another.
        The allowed operations are insertion, deletion, and substitution of characters.

        ### Problem Statement

        Given two strings `S1` and `S2`, determine the minimum number of operations required to convert `S1` into `S2`.

        ### Dynamic Programming Approach

        1. **Define the State**:
           - Let `dp[i][j]` represent the minimum number of operations required to convert the first `i` characters of `S1` to the first `j` characters of `S2`.

        2. **Initial State**:
           - `dp[0][j] = j` for all `j`, because converting an empty string to a string of length `j` requires `j` insertions.
           - `dp[i][0] = i` for all `i`, because converting a string of length `i` to an empty string requires `i` deletions.

        3. **State Transition**:
           - If `S1[i - 1] == S2[j - 1]`, then no new operation is needed: `dp[i][j] = dp[i - 1][j - 1]`.
           - Otherwise, consider the minimum of the following three operations:
             - Insert a character: `dp[i][j - 1] + 1`
             - Delete a character: `dp[i - 1][j] + 1`
             - Replace a character: `dp[i - 1][j - 1] + 1`
             - Thus, `dp[i][j] = min(dp[i][j - 1] + 1, dp[i - 1][j] + 1, dp[i - 1][j - 1] + 1)`.

        4. ** Result**:
           - The value at `dp[len(S1)][len(S2)]` will be the minimum number of operations required to convert `S1` to `S2`.

        ### Explanation of the Code

        1. ** Initialization**:
           - Create a 2D array `dp` with dimensions `(m + 1) x(n + 1)` where `m` is the length of `S1` and `n` is the length of `S2`.
           - Initialize the first row and column of `dp` to handle conversions involving empty substrings.

        2. **Filling the DP Table**:
           - Iterate through each character of `S1` and `S2`.
           - If the characters match, no new operation is needed, and we take the value from `dp[i - 1][j - 1]`.
           - If the characters do not match, consider the three possible operations(insert, delete, replace) and take the minimum of those values plus one.

        3. ** Result**:
           - The value at `dp[m][n]` contains the minimum number of operations required to convert `S1` to `S2`.

        ### Complexity Analysis

        - ** Time Complexity**: (O(m times n)), where (m) is the length of `S1` and (n) is the length of `S2`. 
        This is because we have a nested loop iterating through each character of both strings.
        - ** Space Complexity**: (O(m times n)) for the `dp` array used to store the minimum number of operations.

        This approach efficiently solves the Edit Distance problem using dynamic programming.
        */

        public static int MinDistance(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;
            int[,] dp = new int[m + 1, n + 1];

            // Initialize the dp array
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j; // If s1 is empty, insert all characters of s2
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i; // If s2 is empty, remove all characters of s1
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1]; // Characters match, no new operation
                    }
                    else
                    {
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j - 1], // Replace
                                                Math.Min(dp[i, j - 1], // Insert
                                                         dp[i - 1, j])); // Delete
                    }
                }
            }

            return dp[m, n];
        }

        public static void EditDistanceDriver()
        {
            string s1 = "kitten";
            string s2 = "sitting";
            Console.WriteLine("Minimum operations to convert '" + s1 + "' to '" + s2 + "': " + MinDistance(s1, s2));
            // Output: Minimum operations to convert 'kitten' to 'sitting': 3
        }
    }

    public class MaximumSumIncreasingSubsequence_H_6
    {
        /*
        The Maximum Sum Increasing Subsequence(MSIS) problem is a classic dynamic programming problem.
        The goal is to find the maximum sum of a subsequence in a given array such that all elements of the subsequence are in increasing order.

        ### Problem Statement

        Given an array of integers, find the maximum sum of an increasing subsequence in the array.

        ### Dynamic Programming Approach

        1. **Define the State**:
           - Let `dp[i]` represent the maximum sum of the increasing subsequence that ends with the element at index `i`.

        2. **Initial State**:
           - Initialize each element of `dp` with the corresponding value of the array since each element is a subsequence of length 1.

        3. **State Transition**:
           - For each element `arr[i]`, check all the previous elements `arr[j]` (where `j<i`). If `arr[j] < arr[i]`,
        then consider `arr[i]` as part of the subsequence ending at `arr[j]`. Update `dp[i]` as `dp[i] = max(dp[i], dp[j] + arr[i])`.

        4. ** Result**:
           - The result will be the maximum value in the `dp` array, which represents the maximum sum of an increasing subsequence in the array.

        ### Explanation of the Code

        1. ** Initialization**:
           - Create a `dp` array of the same length as the input array and initialize each element of `dp` with the corresponding value of the input array.

        2. **Filling the DP Table**:
           - For each element `arr[i]`, check all previous elements `arr[j]` (where `j<i`). If `arr[j] < arr[i]`,
        update `dp[i]` as the maximum of its current value and `dp[j] + arr[i]`.

        3. ** Result**:
           - The result is the maximum value in the `dp` array, which represents the maximum sum of an increasing subsequence in the array.

        ### Complexity Analysis

        - **Time Complexity**: (O(n^2)), where (n) is the length of the input array.
        This is because of the nested loops iterating through each pair of elements in the array.
        - **Space Complexity**: (O(n)) for the `dp` array used to store the maximum sum of increasing subsequences ending at each index.

        This approach efficiently solves the Maximum Sum Increasing Subsequence problem using dynamic programming.

        */

        public static int MaxSumIS(int[] arr, int n)
        {
            int[] dp = new int[n];

            // Initialize dp array with array values
            for (int i = 0; i < n; i++)
            {
                dp[i] = arr[i];
            }

            // Fill dp array in bottom-up manner
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && dp[i] < dp[j] + arr[i])
                    {
                        dp[i] = dp[j] + arr[i];
                    }
                }
            }

            // Find the maximum value in dp array
            int max = dp[0];
            for (int i = 1; i < n; i++)
            {
                if (dp[i] > max)
                {
                    max = dp[i];
                }
            }

            return max;
        }

        public static void MaximumSumIncreasingSubsequenceDriver()
        {
            int[] arr = { 1, 101, 2, 3, 100, 4, 5 };
            Console.WriteLine($"Array : {string.Join(", ", arr)}");
            int n = arr.Length;
            Console.WriteLine("Maximum sum of increasing subsequence is: " + MaxSumIS(arr, n));
            // Output: Maximum sum of increasing subsequence is: 106
        }
    }

    public class MatrixChainMultiplication_H_7
    {
        /*
        Matrix Chain Multiplication is a classic problem in dynamic programming.
        The goal is to determine the most efficient way to multiply a given sequence of matrices.
        The problem is not to perform the multiplications but merely to decide in which order to perform the multiplications.

        ### Problem Statement

        Given a sequence of matrices, find the minimum number of multiplications needed to multiply the entire sequence.

        ### Approach

        1. **Define the State**:
           - Let `dp[i][j]` represent the minimum number of scalar multiplications needed to compute the matrix product `Ai...Aj`.

        2. **Initial State**:
           - The cost of multiplying one matrix is zero, so for any matrix `A`, `dp[i][i] = 0`.

        3. **State Transition**:
           - To compute `dp[i][j]`, consider all possible positions `k` to split the product `Ai...Aj`. Then, `dp[i][j]` can be obtained by:
             [
             dp[i][j] = min_{ i leq k<j}
            (dp[i][k] + dp[k + 1][j] + p[i - 1] times p[k] times p[j])
             ]
           - Here, `p` is the array representing the dimensions of the matrices such that the dimension of matrix `Ai` is `p[i - 1] x p[i]`.

        4. ** Result**:
           - The result will be `dp[1][n - 1]` where `n` is the number of matrices plus one(since the length of `p` is one more than the number of matrices).

        ### Explanation of the Code

        1. ** Initialization**:
           - A 2D array `dp` is initialized where `dp[i][i]` is set to 0 since multiplying a single matrix requires zero multiplications.

        2. **Filling the DP Table**:
           - The length of the chain `L` is varied from 2 to `n-1`.
           - For each possible starting index `i`, the ending index `j` is computed as `i + L - 1`.
           - For each possible position `k` to split the product `Ai...Aj`, the cost is computed and the minimum cost is stored in `dp[i][j]`.

        3. **Result**:
           - The result is stored in `dp[1][n - 1]`, which gives the minimum number of multiplications needed to multiply the matrices from `A1` to `An`.

        ### Complexity Analysis

        - **Time Complexity**: (O(n^3)), where (n) is the number of matrices.
        This is because of the three nested loops iterating through the dimensions of the matrices.
        - **Space Complexity**: (O(n^2)) for the `dp` array used to store the minimum multiplication costs.

        This approach efficiently solves the Matrix Chain Multiplication problem using dynamic programming.
        */

        public static int MatrixChainOrder(int[] p, int n)
        {
            int[,] dp = new int[n, n];

            // dp[i, i] = 0 for single matrix multiplication cost
            for (int i = 1; i < n; i++)
            {
                dp[i, i] = 0;
            }

            // L is the chain length.
            for (int L = 2; L < n; L++)
            {
                for (int i = 1; i < n - L + 1; i++)
                {
                    int j = i + L - 1;
                    dp[i, j] = int.MaxValue;

                    for (int k = i; k <= j - 1; k++)
                    {
                        int q = dp[i, k] + dp[k + 1, j] + p[i - 1] * p[k] * p[j];
                        if (q < dp[i, j])
                        {
                            dp[i, j] = q;
                        }
                    }
                }
            }

            return dp[1, n - 1];
        }

        public static void MatrixChainMultiplicationDriver()
        {
            int[] arr = { 1, 2, 3, 4 };  // Dimensions of the matrices
            Console.WriteLine($"Array : {string.Join(", ", arr)}");
            int size = arr.Length;

            Console.WriteLine("Minimum number of multiplications is " + MatrixChainOrder(arr, size));
            // Output: Minimum number of multiplications is 18
        }
    }

    public class MinimumPathSumInMatrix_M_8
    {
        /*
        ### Problem Statement

        Given a `m x n` matrix filled with non-negative integers, find the minimum sum path from the top-left to the bottom-right corner of the matrix.
        You can only move either down or right at any point in time.
        Additionally, count the number of such minimum sum paths and backtrack to find one such path.

        ### Approach

        1. **Define the State**:
           - Let `dp[i][j]` represent the minimum sum path to reach cell `(i, j)`.

        2. **Initial State**:
           - `dp[0][0] = matrix[0][0]`, as there's only one way to start at the top-left corner.

        3. **State Transition**:
           - For each cell `(i, j)`, the minimum path sum can be computed as:
             [
             dp[i][j] = text{matrix}[i][j] + min(dp[i-1][j], dp[i][j-1])
             ]
           - Here, `dp[i-1][j]` is the cost of reaching the cell from above, and `dp[i][j-1]` is the cost of reaching the cell from the left.

        4. **Count Paths**:
           - Let `count[i][j]` represent the number of ways to reach cell `(i, j)` with the minimum path sum.
           - Initialize `count[0][0] = 1`.
           - For each cell `(i, j)`, update the count based on the cells contributing to the minimum path sum.

        5. **Backtrack**:
           - Start from the bottom-right corner and backtrack to find one of the paths that give the minimum sum.

        ### Explanation of the Code

        1. **Initialization**:
           - Initialize `dp` and `count` matrices.
           - Set `dp[0,0]` to the value of the top-left cell and `count[0,0]` to 1.
           - Initialize the first row and the first column for both `dp` and `count`.

        2. **Filling the DP Table**:
           - Iterate over the matrix to fill in the `dp` table based on the minimum sum path.
           - Simultaneously, update the `count` table based on the number of ways to reach the cell with the minimum path sum.

        3. **Backtracking**:
           - Start from the bottom-right cell and move upwards/leftwards to trace back one of the minimum sum paths.

        4. **Output**:
           - Print the minimum path sum, the number of such paths, and one of the paths.

        ### Complexity Analysis

        - **Time Complexity**: (O(m times n)) where (m) is the number of rows and (n) is the number of columns in the grid.
        This is because we iterate over the entire grid once to fill in the `dp` and `count` tables.
        - **Space Complexity**: (O(m times n)) for the `dp` and `count` tables.

        This approach efficiently finds the minimum path sum in the grid, counts the number of such paths,
        and provides one of the paths using backtracking.### Explanation of the Code

        1. **Initialization**:
           - Initialize `dp` and `count` matrices.
           - Set `dp[0,0]` to the value of the top-left cell and `count[0,0]` to 1.
           - Initialize the first row and the first column for both `dp` and `count`.

        2. **Filling the DP Table**:
           - Iterate over the matrix to fill in the `dp` table based on the minimum sum path.
           - Simultaneously, update the `count` table based on the number of ways to reach the cell with the minimum path sum.

        3. **Backtracking**:
           - Start from the bottom-right cell and move upwards/leftwards to trace back one of the minimum sum paths.

        4. **Output**:
           - Print the minimum path sum, the number of such paths, and one of the paths.

        ### Complexity Analysis

        - **Time Complexity**: (O(m times n)) where (m) is the number of rows and (n) is the number of columns in the grid.
        This is because we iterate over the entire grid once to fill in the `dp` and `count` tables.
        - **Space Complexity**: (O(m times n)) for the `dp` and `count` tables.

        This approach efficiently finds the minimum path sum in the grid, counts the number of such paths, and provides one of the paths using backtracking.
        */

        public static int MinPathSum(int[,] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            int[,] dp = new int[m, n];
            int[,] count = new int[m, n];
        
            dp[0, 0] = grid[0, 0];
            count[0, 0] = 1;

            for (int i = 1; i < m; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + grid[i, 0];
                count[i, 0] = 1;
            }

            for (int j = 1; j < n; j++)
            {
                dp[0, j] = dp[0, j - 1] + grid[0, j];
                count[0, j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (dp[i - 1, j] < dp[i, j - 1])
                    {
                        dp[i, j] = dp[i - 1, j] + grid[i, j];
                        count[i, j] = count[i - 1, j];
                    }
                    else if (dp[i - 1, j] > dp[i, j - 1])
                    {
                        dp[i, j] = dp[i, j - 1] + grid[i, j];
                        count[i, j] = count[i, j - 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + grid[i, j];
                        count[i, j] = count[i - 1, j] + count[i, j - 1];
                    }
                }
            }

            List<(int, int)> path = new List<(int, int)>();
            Backtrack(dp, grid, m - 1, n - 1, path);

            Console.WriteLine("Minimum Path Sum: " + dp[m - 1, n - 1]);
            Console.WriteLine("Number of Minimum Paths: " + count[m - 1, n - 1]);
            Console.WriteLine("One of the Minimum Paths: ");
            foreach (var point in path)
            {
                Console.Write($"({point.Item1}, {point.Item2}) ");
            }

            return dp[m - 1, n - 1];
        }

        private static void Backtrack(int[,] dp, int[,] grid, int i, int j, List<(int, int)> path)
        {
            if (i == 0 && j == 0)
            {
                path.Add((0, 0));
                path.Reverse();
                return;
            }

            path.Add((i, j));
            if (i > 0 && dp[i, j] == dp[i - 1, j] + grid[i, j])
            {
                Backtrack(dp, grid, i - 1, j, path);
            }
            else if (j > 0 && dp[i, j] == dp[i, j - 1] + grid[i, j])
            {
                Backtrack(dp, grid, i, j - 1, path);
            }
        }

        public static void MinimumPathSumInMatrixDriver()
        {
            int[,] grid = {
                { 1, 3, 1 },
                { 1, 5, 1 },
                { 4, 2, 1 }
            };

            MinPathSum(grid);
        }
    }

    public class CoinChangeProblem_H_9
    {
        /*
        ### Coin Change Problem Statement
            Given an integer array `coins` representing coins of different denominations and an integer `amount` representing a total amount of money,
        return the fewest number of coins needed to make up that amount. If that amount of money cannot be made up by any combination of the coins, return `-1`.

        ### Approach
        We can solve this problem using dynamic programming. The idea is to create a dp array where each index `i` represents the minimum number of coins needed to make the amount `i`.

        ### Steps
        1. **Initialize the dp array**:
            - Create an array `dp` of size `amount + 1` and initialize all the values to `amount + 1` (a value greater than any possible minimum number of coins).
            - Set `dp[0]` to `0` because no coins are needed to make the amount `0`.

        2. **Fill the dp array**:
            - For each coin in the coins array, update the dp array.
            - For each amount from the value of the coin to `amount`, update `dp[j]` as:
                [
                dp[j] = min(dp[j], dp[j - text{coin}] + 1)
                ]

        3. **Result**:
            - If `dp[amount]` is still `amount + 1`, return `-1` (it means it's not possible to make the amount with the given coins).
            - Otherwise, return `dp[amount]`.

        ### Complexity Analysis
        - **Time Complexity**: (O(n times text{amount})), where `n` is the number of coins. 
        We iterate over each coin and for each coin, we iterate over the amounts up to `amount`.
        - **Space Complexity**: (O(text{amount})), the space required for the dp array.

        ### Explanation of the Code

        1. **Initialization**:
            - `dp` array is initialized with a value greater than any possible number of coins (`amount + 1`).
            - `dp[0]` is set to `0` since no coins are needed to make amount `0`.

        2. **Filling the dp array**:
            - For each coin, we update the `dp` array for all amounts from the coin value to `amount`.
            - We update `dp[j]` to be the minimum of its current value and `dp[j - coin] + 1`.

        3. **Result**:
            - If `dp[amount]` is still `amount + 1`, it means it's not possible to make that amount with the given coins, so we return `-1`.
            - Otherwise, we return `dp[amount]`, which is the minimum number of coins needed to make up the amount.

        This solution is efficient and provides the optimal way to solve the coin change problem using dynamic programming### Explanation of the Code

        1. **Initialization**:
            - `dp` array is initialized with a value greater than any possible number of coins (`amount + 1`).
            - `dp[0]` is set to `0` since no coins are needed to make amount `0`.

        2. **Filling the dp array**:
            - For each coin, we update the `dp` array for all amounts from the coin value to `amount`.
            - We update `dp[j]` to be the minimum of its current value and `dp[j - coin] + 1`.

        3. **Result**:
            - If `dp[amount]` is still `amount + 1`, it means it's not possible to make that amount with the given coins, so we return `-1`.
            - Otherwise, we return `dp[amount]`, which is the minimum number of coins needed to make up the amount.

        This solution is efficient and provides the optimal way to solve the coin change problem using dynamic programming
        */

        public static int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= amount; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j - coins[i]] + 1);
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

        public static void CoinChangeProblemDriver()
        {
            int[] coins = { 1, 2, 5 };
            int amount = 11;
            Console.WriteLine($"coins : {string.Join(", ", coins)}");
            Console.WriteLine($"amount : {amount}");
            int result = CoinChange(coins, amount);
            Console.WriteLine(result);  // Output: 3
        }
    }

    public class SubsetSumProblem_M_10
    {
        /*
        ### Subset Sum Problem Statement

                Given an array of positive integers `nums` and an integer `target`, determine if there is a subset of the given set with a sum equal to the given `target`.

        ### Approach

        We can solve this problem using dynamic programming.The idea is to use a 2D dp array where `dp[i][j]` indicates whether a subset of the first `i` elements of `nums` can sum up to `j`.

        ### Steps

        1. ** Initialize the dp array**:
           - Create a 2D array `dp` of size `(n+1) x(target+1)` where `n` is the length of `nums`.
           - Set `dp[i][0]` to `true` for all `i` because a sum of `0` can always be achieved with an empty subset.
           - Set `dp[0][j]` to `false` for all `j > 0` because no sum can be achieved with zero elements.

        2. **Fill the dp array**:
           - For each element in `nums`, update the `dp` array:
             - If the current element `nums[i - 1]` is less than or equal to `j`, set `dp[i][j]` as `dp[i - 1][j]` OR `dp[i - 1][j - nums[i - 1]]`.
             - Otherwise, set `dp[i][j]` as `dp[i - 1][j]`.

        3. **Result**:
           - The value at `dp[n][target]` will indicate whether a subset with the sum equal to `target` exists.

        ### Complexity Analysis

        - **Time Complexity**: (O(n times text{ target})), where `n` is the number of elements in `nums`. We iterate over each element and for each element, we iterate over the sums up to `target`.
        - ** Space Complexity**: (O(n times text{target
        })), the space required for the dp array.

        ### Explanation of the Code

        1. * *Initialization * *:
           - `dp[i, 0]` is set to `true` for all `i` because a sum of `0` can always be achieved with an empty subset.
           - `dp[0, j]` is set to `false` for all `j > 0` because no sum can be achieved with zero elements.

        2. * *Filling the dp array * *:
           -For each element in `nums`, update the `dp` array.
           - If the current element `nums[i - 1]` is less than or equal to `j`, we check if we can form the sum `j` either by including or excluding the current element.
           - Otherwise, we simply carry forward the value from `dp[i-1][j]`.

        3. * *Result * *:
           -The value at `dp[n][target]` will indicate whether a subset with the sum equal to `target` exists.

        This solution provides an efficient way to determine if there exists a subset within the given set that sums up to the target value using dynamic programming.
        */

        public static bool SubsetSum(int[] nums, int target)
        {
            int n = nums.Length;
            bool[,] dp = new bool[n + 1, target + 1];

            // Initialize dp array
            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = true;  // Sum of 0 can always be achieved with an empty subset
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= target; j++)
                {
                    if (nums[i - 1] <= j)
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[n, target];
        }

        public static void Driver()
        {
            int[] nums = { 1, 2, 3, 7 };
            int target = 6;
            Console.WriteLine($"nums : {string.Join(", ", nums)}");
            Console.WriteLine($"target : {target}");
            bool result = SubsetSum(nums, target);
            Console.WriteLine(result);  // Output: True
        }
    }

    public class RodCuttingProblem_H_11
    {
        /*
        ### Rod Cutting Problem Statement

                Given a rod of length `n` and an array of prices that contains prices of all pieces of size smaller than `n`, determine the maximum value obtainable by cutting up the rod and selling the pieces.

        ### Approach

            We can solve this problem using dynamic programming.The idea is to build a solution incrementally and store intermediate results to avoid redundant calculations.

        ### Steps

        1. ** Define the dp array**:
           - Create a 1D dp array `dp` where `dp[i]` will store the maximum profit obtainable by cutting a rod of length `i`.

        2. ** Initialize the dp array**:
           - Set `dp[0]` to `0` because no profit can be made from a rod of length `0`.

        3. ** Fill the dp array**:
           - For each length `i` from `1` to `n`, iterate through all possible first cuts `j` from `1` to `i` and update `dp[i]` as the maximum of `dp[i]` and `prices[j - 1] + dp[i - j]`.

        4. ** Result**:
           - The value at `dp[n]` will be the maximum profit obtainable by cutting the rod of length `n`.

        ### Complexity Analysis

        - ** Time Complexity**: (O(n^2)), where `n` is the length of the rod.We iterate over each length `i` and for each length, we iterate through all possible first cuts `j`.
        - ** Space Complexity**: (O(n)), the space required for the dp array.

        ### Explanation of the Code

        1. ** Initialization**:
           - `dp[0]` is set to `0` because no profit can be made from a rod of length `0`.

        2. ** Filling the dp array**:
           - For each length `i` from `1` to `n`, we iterate through all possible first cuts `j`.
           - For each cut `j`, we calculate the maximum profit by considering the profit from the current cut and the remaining part of the rod(`dp[i - j]`).

        3. ** Result**:
           - The value at `dp[n]` will be the maximum profit obtainable by cutting the rod of length `n`.

        This solution provides an efficient way to determine the maximum profit that can be obtained by cutting a rod into smaller pieces using dynamic programming.
        */

        public static int RodCutting(int[] prices, int n)
        {
            int[] dp = new int[n + 1];

            // Initialize dp array
            dp[0] = 0;

            // Fill dp array
            for (int i = 1; i <= n; i++)
            {
                int maxProfit = int.MinValue;
                for (int j = 1; j <= i; j++)
                {
                    maxProfit = Math.Max(maxProfit, prices[j - 1] + dp[i - j]);
                }
                dp[i] = maxProfit;
            }

            return dp[n];
        }

        public static void Driver()
        {
            int[] prices = { 1, 5, 8, 9, 10, 17, 17, 20 };
            int n = 8;
            Console.WriteLine($"prices : {string.Join(", ", prices)}");
            Console.WriteLine($"n : {n}");
            int result = RodCutting(prices, n);
            Console.WriteLine(result);  // Output: 22
        }
    }

    public class EggDroppingProblem_M_12
    {
        /*
        ### Egg Dropping Problem Statement

                The problem is to find the minimum number of attempts needed to find the critical floor in the worst-case scenario given `k` eggs and
        a building with `n` floors.An egg breaks if dropped from a floor above the critical floor and does not break if dropped from a floor below or equal to the critical floor.

        ### Approach

            We can solve this problem using dynamic programming.
        The idea is to build a solution incrementally and store intermediate results to avoid redundant calculations.

        ### Steps

        1. ** Define the dp table**:
           - Create a 2D dp array `dp` where `dp[i][j]` represents the minimum number of attempts needed with `i` eggs and `j` floors.

        2. ** Initialize the dp table**:
           - If we have `1` egg, we need `j` attempts for `j` floors(`dp[1][j] = j`).
           - If we have `0` floors, we need `0` attempts(`dp[i][0] = 0`).
           - If we have `1` floor, we need `1` attempt(`dp[i][1] = 1`).

        3. ** Fill the dp table**:
           - For each number of eggs `i` from `2` to `k` and for each number of floors `j` from `2` to `n`,
        calculate the minimum number of attempts needed by trying each floor `x` from `1` to `j` and taking the maximum of two cases:
             - The egg breaks: We need to check the floors below `x` with one less egg(`dp[i - 1][x - 1]`).
             - The egg does not break: We need to check the floors above `x` with the same number of eggs(`dp[i][j - x]`).

        4. ** Result**:
           - The value at `dp[k][n]` will be the minimum number of attempts needed in the worst-case scenario.

        ### Complexity Analysis

        - ** Time Complexity**: (O(k cdot n^2)), where `k` is the number of eggs and `n` is the number of floors.
        We iterate over each egg and for each egg, we iterate over each floor, and for each floor, we iterate over all possible floors to drop the egg from.
        - **Space Complexity**: (O(k cdot n)), the space required for the dp table.

        ### Explanation of the Code

        1. ** Initialization**:
           - The base cases are initialized where if we have `1` egg, we need `j` attempts for `j` floors, and if we have `0` floors, we need `0` attempts.

        2. ** Filling the dp table**:
           - For each number of eggs and floors, we iterate over each floor to drop the egg from and calculate the minimum number of attempts needed by taking the worst-case scenario.

        3. ** Result**:
           - The value at `dp[k][n]` will be the minimum number of attempts needed to find the critical floor in the worst-case scenario.

        This solution provides an efficient way to determine the minimum number of attempts needed to find the critical floor using dynamic programming.
        */

        public static int EggDrop(int k, int n)
        {
            int[,] dp = new int[k + 1, n + 1];

            // Initialize the dp table
            for (int i = 1; i <= k; i++)
            {
                dp[i, 0] = 0;
                dp[i, 1] = 1;
            }

            for (int j = 1; j <= n; j++)
            {
                dp[1, j] = j;
            }

            // Fill the dp table
            for (int i = 2; i <= k; i++)
            {
                for (int j = 2; j <= n; j++)
                {
                    dp[i, j] = int.MaxValue;
                    for (int x = 1; x <= j; x++)
                    {
                        int res = 1 + Math.Max(dp[i - 1, x - 1], dp[i, j - x]);
                        dp[i, j] = Math.Min(dp[i, j], res);
                    }
                }
            }

            return dp[k, n];
        }

        public static void Driver()
        {
            int k = 2; // Number of eggs
            Console.WriteLine("Number of eggs " + k);

            int n = 10; // Number of floors
            Console.WriteLine("Number of floors: " + n);

            int result = EggDrop(k, n);            
            Console.WriteLine("Minimum number of attempts needed: " + result);
        }
    }

    public class WordBreakProblem_H_13
    {
        /*
        ### Problem Statement

                Given a non-empty string `s` and a dictionary `wordDict` containing a list of non-empty words, 
                determine if `s` can be segmented into a space-separated sequence of one or more dictionary words.

        ### Approach

            To solve this problem using dynamic programming, we can use a boolean array `dp` where `dp[i]`
                indicates whether the substring `s[0:i]` can be segmented into words from the dictionary.
    
        ### Steps

        1. **Define the dp table**:
           - Create a boolean array `dp` of size `n+1` (where `n` is the length of the string `s`), initialized to `false`.
           - `dp[0]` is `true` because an empty string can always be segmented.

        2. ** Fill the dp table**:
           - Iterate over each position `i` from `1` to `n`.
           - For each position `i`, iterate over each position `j` from `0` to `i`.
           - If `dp[j]` is `true` and the substring `s[j:i]` is in the dictionary, set `dp[i]` to `true`.

        3. ** Result**:
           - The value at `dp[n]` will be `true` if the string `s` can be segmented, and `false` otherwise.

        ### Complexity Analysis

        - ** Time Complexity**: (O(n^2 cdot m)), where `n` is the length of the string and `m` is the average length of the words in the dictionary.
                The nested loops contribute to (O(n^2)), and checking if a substring is in the dictionary takes (O(m)).
        - ** Space Complexity**: (O(n)), the space required for the dp table.

        ### Explanation of the Code

        1. ** Initialization**:
           - Create a set `wordSet` from the dictionary for fast lookup.
           - Initialize the boolean array `dp` where `dp[0]` is `true`.

        2. **Filling the dp table**:
           - For each position `i`, check all substrings ending at `i`.
           - If a substring `s[j:i]` can be found in the dictionary and `dp[j]` is `true`, then set `dp[i]` to `true`.

        3. **Result**:
           - Return `dp[s.Length]` which indicates if the entire string `s` can be segmented into dictionary words.

        This approach efficiently determines if the string can be segmented into words from the dictionary using dynamic programming.
        */

        public static bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> wordSet = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true; // Empty string can always be segmented

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        public static void Driver()
        {
            string s = "RishabhThakur";
            Console.WriteLine("Given string : " + s);

            IList<string> wordDict = new List<string> { "Rishabh", "Thakur" };
            Console.WriteLine("Given wordDict : ");
            foreach (var item in wordDict)
            {
                Console.WriteLine($" {item} ");
            }

            bool result = WordBreak(s, wordDict);
            Console.WriteLine("Can the string be segmented? " + result);
        }
    }

    public class PalindromePartitioning_H_14
    {
        /*
        ### Problem Statement

                Given a string `s`, partition `s` such that every substring of the partition is a palindrome.
        Return the minimum cuts needed for a palindrome partitioning of `s`.

        ### Approach

            This problem can be approached using Dynamic Programming(DP). 
        The main idea is to use a DP table to store the minimum number of cuts needed for each substring of the input string.

        1. ** Define the DP Table**:
           - Let `dp[i]` be the minimum number of cuts needed for a palindrome partitioning of the substring `s[0..i]`.

        2. ** Palindrome Check Table**:
           - Use a 2D boolean array `isPalindrome` where `isPalindrome[i][j]` is true if the substring `s[i..j]` is a palindrome.

        3. **Initialization**:
           - If the substring `s[0..i]` is already a palindrome, then `dp[i] = 0` since no cuts are needed.
           - Otherwise, try to partition the string at every possible position and update the DP table accordingly.

        4. **Filling the DP Table**:
           - For each substring `s[0..i]`, check all possible partitions.
           - If the substring `s[j + 1..i]` is a palindrome, then the minimum cuts for `s[0..i]` can be found by adding 1 to the minimum cuts for `s[0..j]`.

        ### Complexity Analysis

        - **Time Complexity**: (O(n^2)) for filling the DP table and palindrome checks.
        - ** Space Complexity**: (O(n^2)) for storing the DP table and palindrome checks.

        ### Explanation of the Code

        1. ** Initialization**:
           - The `dp` array is initialized with the worst-case scenario, where each character requires a cut before it.
           - The `isPalindrome` 2D array is used to store whether a substring `s[i..j]` is a palindrome.

        2. **Palindrome Check**:
           - For each substring `s[start..end]`, check if it is a palindrome. If `s[start] == s[end]` and the inner substring `s[start + 1..end - 1]` 
        is also a palindrome (or the length of the substring is less than 3), then `s[start..end]` is a palindrome.

        3. **DP Array Update**:
           - If the substring `s[start..end]` is a palindrome and starts from index 0, then `dp[end]` is 0 since no cuts are needed.
           - Otherwise, update `dp[end]` to be the minimum of its current value and `dp[start - 1] + 1` (one cut after the palindrome `s[start..end]`).

        4. ** Result**:
           - The value at `dp[n - 1]` gives the minimum number of cuts needed for a palindrome partitioning of the entire string.

        This approach ensures that we efficiently calculate the minimum cuts needed for a palindrome partitioning using dynamic programming and palindrome checks.
        */

        public static int MinCut(string s)
        {
            int n = s.Length;
            if (n <= 1) return 0;

            // DP table to store minimum cuts for each substring
            int[] dp = new int[n];
            // Table to store palindrome checks
            bool[,] isPalindrome = new bool[n, n];

            // Initialize the dp array with the worst case (cut between each character)
            for (int i = 0; i < n; i++)
            {
                dp[i] = i; // max cuts needed are i (cut before each character)
            }

            for (int end = 0; end < n; end++)
            {
                for (int start = 0; start <= end; start++)
                {
                    // Check if substring s[start..end] is a palindrome
                    if (s[start] == s[end] && (end - start <= 2 || isPalindrome[start + 1, end - 1]))
                    {
                        isPalindrome[start, end] = true;

                        // If it's a palindrome, update the dp array
                        if (start == 0)
                        {
                            dp[end] = 0; // No cut needed if the whole substring is a palindrome
                        }
                        else
                        {
                            dp[end] = Math.Min(dp[end], dp[start - 1] + 1);
                        }
                    }
                }
            }

            return dp[n - 1];
        }

        public static void Driver()
        {
            string s = "aab";
            Console.WriteLine("Given string: " + s);
            int minCuts = MinCut(s);
            Console.WriteLine("The minimum cuts needed for a palindrome partitioning are: " + minCuts);
        }
    }

    public class JobScheduling_M_15
    {
        /*
        ### Problem Statement

                You are given `n` jobs, where each job is represented by `startTime[i]`, `endTime[i]` and `profit[i]`. 
        You're tasked with finding the maximum profit you can achieve by scheduling non-overlapping jobs.

        ### Approach

        To solve this problem using dynamic programming, we can follow these steps:

        1. ** Sort the Jobs**:
           - First, we sort the jobs by their end times.This helps in efficiently finding the next job that does not overlap with the current job using binary search.

        2. ** Dynamic Programming Array**:
           - Create a DP array where `dp[i]` represents the maximum profit achievable by scheduling jobs from the first job up to the `i-th` job.

        3. ** Binary Search for Non-Overlapping Job**:
           - For each job `i`, find the latest job `j` (where `j<i`) that does not overlap with job `i` using binary search.

        4. ** Fill the DP Table**:
           - For each job `i`, calculate the maximum profit by either including job `i` or excluding it.
           - If including job `i`, add the profit of job `i` to `dp[j]` where `j` is the latest non-overlapping job found using binary search.
           - If excluding job `i`, take the maximum profit from the previous job `dp[i - 1]`.

        5. ** Result**:
           - The value at `dp[n]` will give the maximum profit where `n` is the total number of jobs.

        ### Complexity Analysis

        - ** Time Complexity**: (O(n log n)) due to sorting the jobs and performing binary search for each job.
        - **Space Complexity**: (O(n)) for the DP array.

        ### Explanation of the Code

        1. ** Job Class**:
           - A `Job` class is defined to store the start time, end time, and profit of each job.

        2. ** Initialization**:
           - An array of `Job` objects is created from the given start times, end times, and profits.

        3. **Sorting Jobs**:
           - Jobs are sorted by their end times to facilitate finding non-overlapping jobs using binary search.

        4. ** DP Array**:
           - The `dp` array is initialized, and the maximum profit for each job is calculated by considering both including and excluding the current job.

        5. **Binary Search**:
           - A helper method `BinarySearch` is used to find the latest non-overlapping job for each job.

        6. **Result**:
           - The maximum profit is printed, which is the last value in the `dp` array.

        This implementation efficiently calculates the maximum profit from scheduling non-overlapping jobs using dynamic programming and binary search.
        */
        public class Job
        {
            public int StartTime { get; set; }
            public int EndTime { get; set; }
            public int Profit { get; set; }

            public Job(int startTime, int endTime, int profit)
            {
                StartTime = startTime;
                EndTime = endTime;
                Profit = profit;
            }
        }

        public static int JobSchedule(int[] startTime, int[] endTime, int[] profit)
        {
            int n = startTime.Length;
            Job[] jobs = new Job[n];

            for (int i = 0; i < n; i++)
            {
                jobs[i] = new Job(startTime[i], endTime[i], profit[i]);
            }

            // Sort jobs by end time
            Array.Sort(jobs, (a, b) => a.EndTime.CompareTo(b.EndTime));

            // DP array to store maximum profit up to job i
            int[] dp = new int[n];
            dp[0] = jobs[0].Profit;

            for (int i = 1; i < n; i++)
            {
                int includeProfit = jobs[i].Profit;
                int l = BinarySearch(jobs, i);

                if (l != -1)
                {
                    includeProfit += dp[l];
                }

                dp[i] = Math.Max(includeProfit, dp[i - 1]);
            }

            return dp[n - 1];
        }

        // Binary search to find the latest non-overlapping job
        private static int BinarySearch(Job[] jobs, int index)
        {
            int low = 0, high = index - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (jobs[mid].EndTime <= jobs[index].StartTime)
                {
                    if (jobs[mid + 1].EndTime <= jobs[index].StartTime)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        public static void Driver()
        {
            int[] startTime = { 1, 2, 3, 3 };
            int[] endTime = { 3, 4, 5, 6 };
            int[] profit = { 50, 10, 40, 70 };

            Console.WriteLine($"startTime : {string.Join(", ", startTime)}");
            Console.WriteLine($"endTime : {string.Join(", ", endTime)}");
            Console.WriteLine($"profit : {string.Join(", ", profit)}");

            int maxProfit = JobSchedule(startTime, endTime, profit);
            Console.WriteLine("The maximum profit is: " + maxProfit);
        }
    }

}
