using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Drawing;
using Microsoft.VisualBasic;
using static System.Formats.Asn1.AsnWriter;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Numerics;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Buffers.Text;
using System.IO;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

namespace RecursionAndBacktracking
{
    public class SumOfAllSubset_M_1
    {
        /*
        The problem of finding the sum of all subsets in a given set can be solved efficiently using bit manipulation or a recursive approach.
        The objective is to find the sum of all possible subsets of a given set of integers.

        ### Approach

        1. **Bit Manipulation**:
           - Use bit manipulation to generate all possible subsets and calculate their sums.
           - Each subset can be represented as a binary number where each bit indicates whether an element is included in the subset.

        2. **Recursive Approach**:
           - Use a recursive approach to explore all subsets and calculate their sums.


        ### Explanation

        1. ** Bit Manipulation**:
           - For an array of size `n`, there are `2^n` possible subsets.
           - Iterate through each possible subset using a loop from `0` to `2^n - 1`.
           - For each subset, use bit manipulation to check which elements are included in the subset and sum them up.
           - Accumulate the sum of all subset sums to get the final result.

        ### Time and Space Complexity

        **Time Complexity**: O(N* 2^N) - The primary time complexity comes from iterating through all `2^n` subsets and calculating the sum for each subset.

        **Space Complexity**: O(1) - Only a constant amount of extra space is used, aside from the input array.

        This approach ensures that all subsets are considered and their sums are calculated efficiently using bit manipulation.
        */

        public static int SumOfAllSubset(int[] arr)
        {
            int n = arr.Length;
            int totalSum = 0;

            // There are 2^n possible subsets
            int totalSubsets = 1 << n;

            // Iterate through all subsets
            for (int i = 0; i < totalSubsets; i++)
            {
                int subsetSum = 0;

                for (int j = 0; j < n; j++)
                {
                    // Check if j-th element is included in the i-th subset
                    if ((i & (1 << j)) != 0)
                    {
                        subsetSum += arr[j];
                    }
                }

                totalSum += subsetSum;
            }

            return totalSum;
        }

        public static void SumOfAllSubsetDriver()
        {
            int[] arr = { 1, 2, 3 };
            Console.WriteLine($"Input array: {string.Join(", ", arr)}");
            int result = SumOfAllSubset(arr);
            Console.WriteLine("Sum of all subsets: " + result); // Output should be 24
        }
    }

    public class PrintAllUniqueSubsets_M_2
    {
        /*
        To solve the problem of finding all unique subsets of a given set of integers(including duplicates), 
        you can use a recursive approach with backtracking.The main idea is to sort the array and then use a recursive function
        to explore all possible subsets, ensuring that duplicates are avoided by skipping over them appropriately.

        ### Approach

        1. **Sort the Array**:
           - Sorting the array helps to handle duplicates easily by ensuring that duplicates are adjacent.

        2. **Use Backtracking**:
           - Use a recursive function to generate all subsets.
           - Skip duplicate elements to ensure that each subset is unique.


        ### Explanation

        1. ** Sort the Array**:
           - The array `nums` is sorted to make it easier to handle duplicates by grouping them together.

        2. **Backtrack Function**:
           - The `Backtrack` function generates all subsets starting from a given index.
           - For each element in the array starting from `start`, the function:
             - Adds the current element to the subset.
             - Recursively calls itself with the next index.
             - Removes the current element from the subset (backtracks).
           - To avoid duplicates, the function skips over duplicate elements
        by checking if the current element is the same as the previous element
        and ensuring the skip happens only if the current element is not the first element in the current iteration (`i > start`).

        ### Time and Space Complexity

        ** Time Complexity**: O(2^N) - In the worst case, the number of subsets is `2^N`, 
        *where `N` is the number of elements in the input array.
        *Sorting the array takes O(N log N), and generating subsets takes O(2^N).

        ** Space Complexity**: O(2^N* N) - The space complexity is determined by the number of subsets generated
        *and the space needed to store each subset.The maximum number of subsets is `2^N`, 
        *and each subset can have up to `N` elements.

        This approach ensures that all unique subsets are generated efficiently by leveraging sorting and backtracking, with careful handling of duplicates to maintain uniqueness.
        */


        public static IList<IList<int>> PrintAllUniqueSubsets(int[] nums)
        {
            Array.Sort(nums); // Sort the array to handle duplicates
            IList<IList<int>> result = new List<IList<int>>();
            List<int> subset = new List<int>();
            Backtrack(nums, 0, subset, result);
            return result;
        }

        private static void Backtrack(int[] nums, int start, List<int> subset, IList<IList<int>> result)
        {
            result.Add(new List<int>(subset));

            for (int i = start; i < nums.Length; i++)
            {
                // If the current element is the same as the previous one, skip it to avoid duplicates
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }

                subset.Add(nums[i]);
                Backtrack(nums, i + 1, subset, result);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        public static void PrintAllUniqueSubsetsDriver()
        {
            int[] nums = { 1, 2, 2 };
            Console.WriteLine($"Input array: {string.Join(", ", nums)}");
            var uniqueSubsets = PrintAllUniqueSubsets(nums);

            Console.WriteLine("Unique subsets:");
            foreach (var subset in uniqueSubsets)
            {
                Console.WriteLine("[" + string.Join(", ", subset) + "]");
            }
        }
    }

    public class CombinationAddsToTargetSum_M_3
    {
        /*
        The Combination Sum problem involves finding all unique combinations of numbers 
        from a given set that add up to a target sum.Each number can be used multiple times. 

        ### Approach

        1. **Backtracking**:
           - Use a recursive function to explore all possible combinations.
           - Keep track of the current combination and the remaining target sum.
           - Add the current number to the combination and recursively call the function with the reduced target.
           - If the target sum becomes zero, add the current combination to the result.
           - If the target sum becomes negative, backtrack by removing the last added number.

        ### Explanation

        1. ** Sort the Array**:
           - The array is optionally sorted to improve performance.
        This step is not necessary for correctness but can make the backtracking
        more efficient by allowing early termination of loops when the remaining target cannot be achieved with the current candidate.

        2. ** Backtracking Function**:
           - The `FindCombinations` function generates all valid combinations starting from a given index.
           - For each candidate starting from `start`, the function:
             - Adds the candidate to the current combination.
             - Recursively tries to find combinations with the reduced target.
             - If the target becomes zero, a valid combination is found and added to the result.
             - If the candidate exceeds the remaining target, the loop breaks (since the array is sorted).
             - The function then backtracks by removing the last added candidate and continues with the next candidate.

        ### Time and Space Complexity

        **Time Complexity**: O(2^T) - The worst-case time complexity is O(2^T) where T is the target value.
        *This occurs when the function explores all possible combinations of candidates that could sum up to the target.

        **Space Complexity**: O(T) - The space complexity is determined by the depth of the recursion,
        *which in the worst case can be equal to the target value T.
        *Additionally, the space required to store the current combination and the result.

        This approach ensures that all unique combinations are generated by leveraging backtracking and recursive exploration of all potential combinations.
        */

        public static IList<IList<int>> CombinationAddsToTargetSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> combination = new List<int>();
            Array.Sort(candidates); // Optional: Sort to improve performance
            FindCombinations(candidates, target, 0, combination, result);
            return result;
        }

        private static void FindCombinations(int[] candidates, int target, int start, List<int> combination, IList<IList<int>> result)
        {
            if (target == 0)
            {
                // Found a valid combination
                result.Add(new List<int>(combination));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                {
                    // If the current candidate is greater than the remaining target, break (since the array is sorted)
                    break;
                }

                combination.Add(candidates[i]);
                // Recursively try to find combinations with the remaining target (allow reuse of the same element)
                FindCombinations(candidates, target - candidates[i], i, combination, result);
                // Backtrack
                combination.RemoveAt(combination.Count - 1);
            }
        }

        public static void CombinationAddsToTargetSumDriver()
        {
            int[] candidates = { 2, 3, 6, 7 };
            int target = 7;
            Console.WriteLine($"Input array: {string.Join(", ", candidates)}  and Target : {target}");
            var result = CombinationAddsToTargetSum(candidates, target);
            Console.WriteLine("Combinations that sum up to " + target + ":");
            foreach (var combination in result)
            {
                Console.WriteLine("[" + string.Join(", ", combination) + "]");
            }
        }
    }

    public class CombinationAddsToTargetSumUnique_M_4
    {
        /*
        The Combination Sum II problem is similar to Combination Sum I but with one key difference:
        each number in the given array can only be used once.Additionally,
        the given array may contain duplicates, but each combination should be unique.

        ### Approach

        1. **Sort the Array**:
           - Sorting helps to handle duplicates easily by ensuring that duplicates are adjacent.

        2. **Backtracking**:
           - Use a recursive function to explore all possible combinations.
           - Skip duplicate elements to ensure that each combination is unique.

        ### Explanation

        1. ** Sort the Array**:
           - The array `candidates` is sorted to make it easier to handle duplicates by grouping them together.

        2. **Backtrack Function**:
           - The `Backtrack` function generates all valid combinations starting from a given index.
           - For each candidate starting from `start`, the function:
             - Adds the candidate to the current combination.
             - Recursively tries to find combinations with the reduced target, 
                moving to the next index (i + 1) to avoid reusing the same element.
             - If the target becomes zero, a valid combination is found and added to the result.
             - If the candidate exceeds the remaining target, the loop breaks (since the array is sorted).
             - Skips over duplicate elements by checking if the current element is the same as the previous element
        and ensuring the skip happens only if the current element is not the first element in the current iteration(`i > start`).
             - The function then backtracks by removing the last added candidate and continues with the next candidate.

        ### Time and Space Complexity

        **Time Complexity**: O(2^N) - The worst-case time complexity is O(2^N) where N is the number of candidates.
        *This occurs when the function explores all possible combinations of candidates.

        **Space Complexity**: O(T) - The space complexity is determined by the depth of the recursion, 
        *which in the worst case can be equal to the target value T. 
        *Additionally, the space required to store the current combination and the result.

        This approach ensures that all unique combinations are generated by leveraging backtracking and recursive
        exploration of all potential combinations, with careful handling of duplicates to maintain uniqueness.
        */

        public static IList<IList<int>> CombinationAddsToTargetSumUnique(int[] candidates, int target)
        {
            Array.Sort(candidates); // Sort the array to handle duplicates
            IList<IList<int>> result = new List<IList<int>>();
            List<int> combination = new List<int>();
            Backtrack(candidates, target, 0, combination, result);
            return result;
        }

        private static void Backtrack(int[] candidates, int target, int start, List<int> combination, IList<IList<int>> result)
        {
            if (target == 0)
            {
                // Found a valid combination
                result.Add(new List<int>(combination));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                {
                    // Skip duplicates
                    continue;
                }

                if (candidates[i] > target)
                {
                    // If the current candidate is greater than the remaining target, break (since the array is sorted)
                    break;
                }

                combination.Add(candidates[i]);
                // Recursively try to find combinations with the remaining target (do not reuse the same element)
                Backtrack(candidates, target - candidates[i], i + 1, combination, result);
                // Backtrack
                combination.RemoveAt(combination.Count - 1);
            }
        }

        public static void CombinationAddsToTargetSumUniqueDriver()
        {
            int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
            int target = 8;
            Console.WriteLine($"Input array: {string.Join(", ", candidates)}  and Target : {target}");
            var result = CombinationAddsToTargetSumUnique(candidates, target);
            Console.WriteLine("Unique combinations that sum up to " + target + ":");
            foreach (var combination in result)
            {
                Console.WriteLine("[" + string.Join(", ", combination) + "]");
            }
        }
    }

    public class PartitionStringIntoAllPossiblePalindrome_5
    {
        /*
        Palindrome Partitioning is a problem where you need to partition a given string into all possible substrings
        such that each substring is a palindrome.The goal is to return all these possible palindrome partitionings.

        ### Approach

        1. **Backtracking**:
           - Use a recursive function to explore all possible partitions.
           - Check if each substring is a palindrome.
           - If a substring is a palindrome, recursively partition the remaining part of the string.
   
        2. **Palindrome Check**:
           - Use a helper function to check if a given substring is a palindrome.


        ### Explanation

        1. ** Backtrack Function**:
           - The `Backtrack` function generates all possible palindrome partitions starting from a given index.
           - For each possible end index from the start index to the end of the string:
             - Check if the substring from the start index to the end index is a palindrome using the `IsPalindrome` helper function.
             - If it is a palindrome, add it to the current partition and recursively partition the remaining part of the string.
             - After the recursive call, remove the last added substring to backtrack and explore other partitions.

        2. **IsPalindrome Function**:
           - The `IsPalindrome` function checks if a substring from the start index to the end index is a palindrome
        by comparing characters from the start and end moving towards the center.

        ### Time and Space Complexity

        **Time Complexity**: O(N* 2^N) - The worst-case time complexity is O(N* 2^N) where N is the length of the string.
        *This occurs because each character can be either included or not included in the partition,
        *leading to 2^N possible partitions, and checking each partition takes O(N) time.

        ** Space Complexity**: O(N) - The space complexity is determined by the depth of the recursion,
        *which in the worst case can be equal to the length of the string N.Additionally,
        *the space required to store the current partition and the result.

        This approach ensures that all possible palindrome partitions are generated by leveraging backtracking and recursive exploration of all potential partitions,
            with efficient palindrome checks to maintain correctness.
        */

        public static IList<IList<string>> PartitionStringIntoAllPossiblePalindrome(string inputString)
        {
            IList<IList<string>> result = new List<IList<string>>();
            List<string> currentPartition = new List<string>();
            Backtrack(inputString, 0, currentPartition, result);
            return result;
        }

        private static void Backtrack(string inputString, int start, List<string> currentPartition, IList<IList<string>> result)
        {
            if (start == inputString.Length)
            {
                // If we've reached the end of the string, add the current partition to the result
                result.Add(new List<string>(currentPartition));
                return;
            }

            for (int end = start; end < inputString.Length; end++)
            {
                if (IsPalindrome(inputString, start, end))
                {
                    // If the substring s[start:end+1] is a palindrome
                    currentPartition.Add(inputString.Substring(start, end - start + 1));
                    // Recur to partition the rest of the string
                    Backtrack(inputString, end + 1, currentPartition, result);
                    // Backtrack and remove the last added substring
                    currentPartition.RemoveAt(currentPartition.Count - 1);
                }
            }
        }

        private static bool IsPalindrome(string inputString, int start, int end)
        {
            while (start < end)
            {
                if (inputString[start] != inputString[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }

        public static void PartitionStringIntoAllPossiblePalindromeDriver()
        {
            string input = "aab";
            Console.WriteLine($"Input string : {input}");
            var partitions = PartitionStringIntoAllPossiblePalindrome(input);
            Console.WriteLine("Palindrome partitions:");
            foreach (var partition in partitions)
            {
                Console.WriteLine("[" + string.Join(", ", partition) + "]");
            }
        }
    }

    public class FindKthPermutationSequence_H_6
    {
        /*
        To find the K-th permutation sequence of a given set of numbers,
        we can use a combinatorial approach without generating all permutations.
        This is efficient and leverages factorial computations to directly determine the positions of elements in the desired permutation sequence.

        ### Approach

        1. **Factorial Computation**:
           - Compute the factorial of numbers up to n to determine the number of permutations possible with the remaining elements.
   
        2. **Determine Position**:
           - Use the factorial values to determine the correct position of each element in the permutation.
   
        3. **Adjust K**:
           - Adjust K to account for the zero-based indexing.

        ### Explanation

        1. ** Initialize Lists and Factorials**:
           - Create a list of numbers from 1 to n.
           - Compute the factorial values for numbers from 0 to n.

        2. **Adjust K**:
           - Adjust K to be zero-based, as our calculations assume zero-based indexing.

        3. **Build the Permutation**:
           - For each position from n to 1:
             - Determine the correct index of the current element by dividing K by the factorial of the remaining elements.
             - Append the element at the determined index to the permutation.
             - Remove the used element from the list.
             - Update K to reflect the position within the remaining permutations.

        ### Time and Space Complexity

        **Time Complexity**: O(N^2) - The time complexity is dominated by the list removal operation, which takes O(N) time and is performed N times.

        ** Space Complexity**: O(N) - The space complexity is due to the storage of the numbers list and the factorial array,
        *each of which has a size proportional to N.

        This approach efficiently finds the K-th permutation sequence without generating all permutations,
        making use of combinatorial mathematics to directly determine the positions of elements in the sequence.
        */

        public static string FindKthPermutationSequence(int n, int k)
        {
            List<int> numbers = new List<int>();
            int[] factorial = new int[n + 1];
            StringBuilder permutation = new StringBuilder();

            // Generate the list of numbers and the factorial lookup
            factorial[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
                factorial[i] = factorial[i - 1] * i;
            }

            // Adjust k to be zero-based
            k--;

            for (int i = n; i > 0; i--)
            {
                int index = k / factorial[i - 1];
                permutation.Append(numbers[index]);
                numbers.RemoveAt(index);
                k %= factorial[i - 1];
            }

            return permutation.ToString();
        }

        public static void FindKthPermutationSequenceDriver()
        {
            int n = 4;
            int k = 9;
            string result = FindKthPermutationSequence(n, k);
            Console.WriteLine($"The {k}-th permutation sequence of {n} elements is: '{result}'");
        }
    }

    public class AllPermutations_M_7
    {
        /*
        To print all permutations of a string or an array, you can use a backtracking approach.
        This involves generating all possible rearrangements of the elements by swapping them and
        recursively calling the function to generate permutations for the remaining elements.

        ### Approach

        1. * *Backtracking * *:
           - Use a recursive function to generate permutations.
           - Swap elements to create new permutations.
           - Backtrack by swapping elements back to their original positions after generating permutations for the current configuration.


        ### Explanation

        1. ** Permute Function **:
           -The `Permute` function generates all permutations starting from a given index.
           - For each element in the array starting from `start`, the function:
             -Swaps the current element with the element at the `start` index.
             - Recursively calls itself to generate permutations for the remaining elements.
             - Backtracks by swapping the elements back to their original positions after the recursive call.

        2. **Swap Function **:
           -The `Swap` function exchanges the elements at the specified indices in the array.

        3. **  GetPermutations Function **:
           -The `GetPermutations` function initializes the result list and converts the input string to a character array.
           - Calls the `Permute` function to generate all permutations and returns the result.

        ### Time and Space Complexity

        * *Time Complexity * *: O(N * N!) - The time complexity is O(N * N!) because there are N! permutations and generating each permutation takes O(N) time.

        * *Space Complexity * *: O(N) - The space complexity is O(N) due to the recursion depth and the character array.

        This approach generates all permutations of a given string or array by leveraging a backtracking technique,
        ensuring that all possible rearrangements of the elements are explored and printed.
        */

        public static void Permute(char[] chars, int start, IList<string> result)
        {
            if (start == chars.Length - 1)
            {
                result.Add(new string(chars));
                return;
            }

            for (int i = start; i < chars.Length; i++)
            {
                Swap(chars, start, i);
                Permute(chars, start + 1, result);
                Swap(chars, start, i); // backtrack
            }
        }

        private static void Swap(char[] chars, int i, int j)
        {
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }

        public static IList<string> GetPermutations(string s)
        {
            IList<string> result = new List<string>();
            char[] chars = s.ToCharArray();
            Permute(chars, 0, result);
            return result;
        }

        public static void AllPermutationsDriver()
        {
            string input = "ABC";
            Console.WriteLine($"Input string : {input} ");
            var permutations = GetPermutations(input);
            Console.WriteLine("Permutations of " + input + ":");
            foreach (var permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }
    }

    public class NQueenOnChessBoardNoQueenThreatenEachother_H_8
    {
        /*
        The N-Queens problem is a classic combinatorial problem where you need to place N queens on an N×N chessboard such that no two queens threaten each other.
        This means no two queens can share the same row, column, or diagonal.

        ### Approach

        1. **Backtracking**:
           - Use a recursive function to explore all possible placements of queens.
           - Ensure that the current placement does not conflict with previously placed queens by checking rows, columns, and diagonals.
           - If a valid configuration is found (when all queens are placed), add the board configuration to the result.

        ### Explanation

        1. ** Backtrack Function**:
           - The `Backtrack` function generates all valid board configurations by placing queens row by row.
           - For each column in the current row, it checks if placing a queen is valid using the `IsValid` function.
           - If valid, it places the queen and recursively calls `Backtrack` for the next row.
           - After exploring all possibilities for the current configuration, it backtracks by removing the queen.

        2. **IsValid Function**:
           - The `IsValid` function checks if placing a queen at a given position (row, col) is safe.
           - It checks the column, upper left diagonal, and upper right diagonal for any conflicts with previously placed queens.

        3. **Construct Function**:
           - The `Construct` function converts the board configuration from a 2D character array to a list of strings representing the board.

        4. **SolveNQueens Function**:
           - The `SolveNQueens` function initializes the board and starts the backtracking process.
           - It returns all distinct solutions.

        ### Time and Space Complexity

        ** Time Complexity**: O(N!) - The time complexity is O(N!) because there are N choices for the first row, N-1 choices for the second row, and so on.

        ** Space Complexity**: O(N^2) - The space complexity is O(N^2) due to the board configuration and the recursion stack.

        This approach ensures that all distinct solutions to the N-Queens puzzle are generated by leveraging backtracking
                to explore all potential configurations while maintaining constraints on rows, columns, and diagonals.
        */

        public static IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> result = new List<IList<string>>();
            char[][] board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new string('.', n).ToCharArray();
            }

            Backtrack(board, 0, result);
            return result;
        }

        private static void Backtrack(char[][] board, int row, IList<IList<string>> result)
        {
            int n = board.Length;
            if (row == n)
            {
                result.Add(Construct(board));
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (IsValid(board, row, col))
                {
                    board[row][col] = 'Q';
                    Backtrack(board, row + 1, result);
                    board[row][col] = '.'; // backtrack
                }
            }
        }

        private static bool IsValid(char[][] board, int row, int col)
        {
            int n = board.Length;

            // Check the same column
            for (int i = 0; i < row; i++)
            {
                if (board[i][col] == 'Q')
                {
                    return false;
                }
            }

            // Check the upper left diagonal
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == 'Q')
                {
                    return false;
                }
            }

            // Check the upper right diagonal
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
            {
                if (board[i][j] == 'Q')
                {
                    return false;
                }
            }

            return true;
        }

        private static IList<string> Construct(char[][] board)
        {
            IList<string> path = new List<string>();
            for (int i = 0; i < board.Length; i++)
            {
                path.Add(new string(board[i]));
            }
            return path;
        }

        public static void NQueenOnChessBoardNoQueenThreatenEachotherDriver()
        {
            int n = 4;
            var solutions = SolveNQueens(n);
            Console.WriteLine("Distinct solutions to the " + n + "-Queens puzzle:");
            foreach (var solution in solutions)
            {
                foreach (var row in solution)
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine();
            }
        }
    }

    public class SolveSudoku_H_9
    {
        /*
        The Sudoku Solver problem involves filling a 9x9 grid so that each column, each row, and each of the nine 3x3 subgrids contain all digits from 1 to 9.
        This problem can be effectively solved using a backtracking approach.

        ### Approach

        1. **Backtracking**:
           - Use a recursive function to try filling each empty cell.
           - For each empty cell, try placing digits from 1 to 9.
           - Check if placing a digit in a cell is valid (i.e., it does not violate Sudoku rules).
           - If a digit placement is valid, recursively attempt to solve the rest of the board.
           - If the board is successfully filled, return true.
           - If no valid digit can be placed, backtrack by removing the digit and trying the next possibility.


        ### Explanation

        1. ** Solve Function**:
           - The `Solve` function attempts to fill the board using backtracking.
           - It iterates over each cell of the board.
           - If an empty cell (denoted by '.') is found, it tries placing digits from '1' to '9'.
           - If placing a digit is valid, it recursively attempts to solve the rest of the board.
           - If the board is solved, it returns true.
           - If no valid digit can be placed, it backtracks by resetting the cell to '.' and continues trying other digits.

        2. **IsValid Function**:
           - The `IsValid` function checks if placing a digit in a given cell is valid according to Sudoku rules.
           - It checks the row, column, and 3x3 subgrid for any conflicts with the digit.

        3. **Main Function**:
           - The `Main` function initializes the Sudoku board and calls the `SolveSudoku` function to solve it.
           - It prints the solved Sudoku board.

        ### Time and Space Complexity

        **Time Complexity**: O(9^(N^2)) - In the worst case, 
        *each cell(N^2 cells) could have up to 9 possible digits to try, leading to O(9^(N^2)) time complexity.

        **Space Complexity**: O(N^2) - The space complexity is O(N^2) due to the recursion stack and the board itself.

        This approach efficiently solves the Sudoku puzzle using backtracking, 
        exploring all potential configurations while adhering to Sudoku rules, and backtracking when conflicts arise.
        */

        private static bool SolveSudoku(char[][] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row][col] == '.')
                    {
                        for (char num = '1'; num <= '9'; num++)
                        {
                            if (IsValid(board, row, col, num))
                            {
                                board[row][col] = num;

                                if (SolveSudoku(board))
                                {
                                    return true;
                                }

                                board[row][col] = '.'; // backtrack
                            }
                        }
                        return false; // if no number from 1-9 can solve the board
                    }
                }
            }
            return true; // solved
        }

        private static bool IsValid(char[][] board, int row, int col, char num)
        {
            for (int i = 0; i < 9; i++)
            {
                // Check row
                if (board[row][i] == num)
                {
                    return false;
                }

                // Check column
                if (board[i][col] == num)
                {
                    return false;
                }

                // Check 3x3 box
                if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == num)
                {
                    return false;
                }
            }
            return true;
        }

        public static void SolveSudoku()
        {
            char[][] board = {
                new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };

            Console.WriteLine("Given Sudoku: \n");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }

            SolveSudoku(board);

            Console.WriteLine("\nSolved Sudoku:\n");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class ColorGraphNo2AdjecentVerticesWithSameColor_H_10
    {
        /*
        The M-Coloring Problem involves assigning colors to vertices of a graph such that no two adjacent vertices have the same color,
        and the number of colors used is minimized.This problem can be effectively solved using backtracking.

        ### Approach

        1. ** Backtracking**:
           - Use a recursive function to try assigning colors to vertices.
           - For each vertex, try assigning colors from 1 to M.
           - Check if the current color assignment is valid (i.e., it does not violate the graph's constraints).
           - If a valid assignment is found, recursively attempt to color the rest of the graph.
           - If the graph is successfully colored, return true.
           - If no valid color can be assigned, backtrack by removing the color and trying the next possibility.


        ### Explanation

        1. ** IsSafe Function**:
           - The `IsSafe` function checks if assigning a color to a vertex is safe.
           - It iterates over all adjacent vertices and checks if any adjacent vertex has the same color.

        2. ** ColorGraph Function**:
           - The `ColorGraph` function recursively colors the graph using backtracking.
           - It iterates over all possible colors for the current vertex and checks if assigning each color is safe.
           - If a safe color assignment is found, it assigns the color to the vertex and recursively calls itself for the next vertex.
           - If the graph is successfully colored, it returns true.
           - If no valid color can be assigned, it backtracks by removing the color and trying the next possibility.

        3. ** Main Function**:
           - The `Main` function initializes the graph's adjacency matrix and calls the `ColorGraph` function to color the graph.
           - It prints the color assigned to each vertex if the graph can be colored with the given number of colors.

        ### Time and Space Complexity

        ** Time Complexity**: O(M^V) - In the worst case, each vertex could have up to M possible colors to try, leading to O(M^V) time complexity.

        **Space Complexity**: O(V) - The space complexity is O(V) due to the colors array and the recursion stack.

        This approach efficiently colors the graph using backtracking,
        exploring all possible color assignments while adhering to the graph's constraints, and backtracking when conflicts arise.
        */

        public static bool IsSafe(int vertex, int color, int[,] graph, int[] colors, int V)
        {
            for (int i = 0; i < V; i++)
            {
                if (graph[vertex, i] == 1 && colors[i] == color)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ColorGraphNo2AdjecentVerticesWithSameColor(int vertex, int M, int[,] graph, int[] colors, int V)
        {
            if (vertex == V)
            {
                return true; // Base case: all vertices are colored
            }

            for (int color = 1; color <= M; color++)
            {
                if (IsSafe(vertex, color, graph, colors, V))
                {
                    colors[vertex] = color;
                    if (ColorGraphNo2AdjecentVerticesWithSameColor(vertex + 1, M, graph, colors, V))
                    {
                        return true;
                    }
                    colors[vertex] = 0; // backtrack
                }
            }
            return false;
        }

        public static void ColorGraphNo2AdjecentVerticesWithSameColorDriver()
        {
            int V = 4; // Number of vertices
            int M = 3; // Number of colors
            int[,] graph = {
                {0, 1, 1, 1},
                {1, 0, 1, 0},
                {1, 1, 0, 1},
                {1, 0, 1, 0}
            }; // Adjacency matrix of the graph

            int[] colors = new int[V]; // Initialize colors array

            if (ColorGraphNo2AdjecentVerticesWithSameColor(0, M, graph, colors, V))
            {
                Console.WriteLine("The graph can be colored with " + M + " colors:");
                for (int i = 0; i < V; i++)
                {
                    Console.WriteLine("Vertex " + i + ": Color " + colors[i]);
                }
            }
            else
            {
                Console.WriteLine("The graph cannot be colored with " + M + " colors.");
            }
        }
    }

    public class SolveRatMaze_H_11
    {
        /*
        The Rat in a Maze problem involves finding a path from the starting cell to the ending cell in a maze,
            where the rat can only move in either the right direction or the downward direction, 
            and it can't move outside the maze or to cells containing obstacles. This problem can be solved using backtracking.

        ### Approach

        1. ** Backtracking**:
           - Use a recursive function to explore all possible paths from the starting cell.
           - At each step, try moving the rat in either the right or downward direction.
           - Check if the new position is valid(within the maze and not an obstacle).
           - If the rat reaches the ending cell, return true to indicate success.
           - If the rat cannot move further in any direction, backtrack by marking the current cell as unvisited and return false.

        ### Explanation

        1. ** IsSafe Function**:
           - The `IsSafe` function checks if the rat can move to the given position without going out of bounds or hitting an obstacle.

        2. **SolveMaze Function**:
           - The `SolveMaze` function recursively explores all possible paths from the starting cell.
           - If the rat reaches the ending cell, it marks the cell in the solution matrix and returns true.
           - If the rat can move right or downward, it recursively calls itself for the next position.
           - If neither right nor down works, it backtracks by marking the current cell as unvisited and returns false.

        3. **PrintSolution Function**:
           - The `PrintSolution` function prints the solution matrix.

        4. **Main Function**:
           - The `Main` function initializes the maze and solution matrices and calls the `SolveMaze` function to solve the maze.
           - If a solution exists, it prints the solution matrix; otherwise, it prints that no solution exists.

        ### Time and Space Complexity

        **Time Complexity**: O(2^(N^2)) - In the worst case, the rat can explore 2^(N^2) possible paths.

        **Space Complexity**: O(N^2) - The space complexity is O(N^2) due to the maze and solution matrices.

        This approach efficiently finds a path from the starting cell to the ending cell in the maze using backtracking,
                exploring all possible paths while avoiding obstacles and backtracking when necessary.
        */

        private const int N = 4; // Size of the maze

        public static bool IsSafe(int[,] maze, int x, int y)
        {
            return (x >= 0 && x < N && y >= 0 && y < N && maze[x, y] == 1);
        }

        public static bool SolveRatMaze(int[,] maze, int x, int y, int[,] sol)
        {
            if (x == N - 1 && y == N - 1) // Base case: reached the destination
            {
                sol[x, y] = 1;
                return true;
            }

            if (IsSafe(maze, x, y))
            {
                sol[x, y] = 1;

                // Move right
                if (SolveRatMaze(maze, x, y + 1, sol))
                {
                    return true;
                }

                // Move down
                if (SolveRatMaze(maze, x + 1, y, sol))
                {
                    return true;
                }

                // If neither right nor down works, backtrack
                sol[x, y] = 0;
                return false;
            }

            return false;
        }

        public static void PrintSolution(int[,] sol)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(sol[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void SolveRatMazeDriver()
        {
            int[,] maze = {
                {1, 0, 0, 0},
                {1, 1, 0, 1},
                {0, 1, 0, 0},
                {1, 1, 1, 1}
            };

            int[,] sol = {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            };

           Console.WriteLine("Rat Maze:\n");
            PrintSolution(maze);


            if (SolveRatMaze(maze, 0, 0, sol))
            {
                Console.WriteLine("\nSolution exists:\n");
                PrintSolution(sol);
            }
            else
            {
                Console.WriteLine("Solution does not exist.");
            }
        }
    }

    public class BreakStringIntoWordsFromGivenDictionary_M_12
    {
        /*
        The Word Break problem involves determining if a given string can be segmented into space-separated words from a dictionary.
        In this variation, we need to print all possible ways the string can be segmented. 
        This problem can be effectively solved using dynamic programming.

        ### Approach

        1. ** Dynamic Programming**:
           - Use dynamic programming to store whether a prefix of the string can be segmented into words from the dictionary.
           - Initialize an array to store the possible word breaks for each prefix of the string.
           - Iterate over each prefix of the string and check if it can be segmented into words.
           - If a prefix can be segmented, backtrack to find all possible ways to segment the remaining part of the string.

        ### Explanation

        1. ** WordBreak Function**:
           - The `WordBreak` function uses dynamic programming to determine if a given string can be segmented into words from the dictionary.
           - It initializes a dynamic programming array `dp` to store whether each prefix of the string can be segmented.
           - It iterates over each prefix of the string and checks if it can be segmented into words from the dictionary.
           - If a prefix can be segmented, it backtracks to find all possible ways to segment the remaining part of the string.

        2. **Backtrack Function**:
           - The `Backtrack` function recursively explores all possible word breaks for the given string.
           - It starts from the current position `start` and tries all possible word breaks by iterating over the end positions of substrings.
           - If a valid word break is found, it recursively calls itself for the remaining part of the string.

        3. **Main Function**:
           - The `Main` function initializes the input string and the word dictionary and calls the `WordBreak` function to find all possible word breaks.
           - It prints all possible word breaks found.

        ### Time and Space Complexity

        ** Time Complexity**: O(N^2 * 2^N) - The time complexity is dominated by the nested loops in the `WordBreak` function, where N is the length of the input string.

        ** Space Complexity**: O(N* 2^N) - The space complexity is dominated by the dynamic programming array `dp` and
        *the recursion stack.Each entry in the `dp` array requires O(N) space, and the recursion stack can have up to 2^N recursive calls.

        This approach efficiently finds all possible ways to segment the given string into words from the dictionary
            using dynamic programming to determine valid word breaks and backtracking to find all possible combinations.
        */

        public static IList<string> BreakStringIntoWordsFromGivenDictionary(string s, IList<string> wordDict)
        {
            HashSet<string> wordSet = new HashSet<string>(wordDict);
            List<string> result = new List<string>();
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;

            // Build DP array
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

            // Backtrack to find all possible ways
            Backtrack(s, wordSet, dp, "", result, 0);
            return result;
        }

        private static void Backtrack(string s, HashSet<string> wordSet, bool[] dp, string current, List<string> result, int start)
        {
            if (start == s.Length)
            {
                result.Add(current.Trim());
                return;
            }

            for (int end = start + 1; end <= s.Length; end++)
            {
                string word = s.Substring(start, end - start);
                if (dp[end] && wordSet.Contains(word))
                {
                    Backtrack(s, wordSet, dp, current + " " + word, result, end);
                }
            }
        }

        public static void BreakStringIntoWordsFromGivenDictionaryDriver()
        {
            string s = "catsanddog";
            Console.WriteLine($"Given string : {s}");
            IList<string> wordDict = new List<string> { "cat", "cats", "and", "sand", "dog" };
            Console.WriteLine("Contents of wordDict:");
            foreach (string word in wordDict)
            {
                Console.Write($"{word}, ");
            }

            IList<string> result = BreakStringIntoWordsFromGivenDictionary(s, wordDict);
            Console.WriteLine("\nAll possible word breaks for '" + s + "':");
            foreach (string sentence in result)
            {
                Console.WriteLine(sentence);
            }
        }
    }


}
