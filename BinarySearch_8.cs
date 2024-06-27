using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Timers;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using System.Security.Principal;
using System.Globalization;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.Intrinsics.Arm;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.Numerics;

namespace BinarySearch
{
    public class NthRoot_E_1
    {
        /*
        To find the Nth root of a number using binary search, we can use an iterative approach.
        The idea is to use binary search to narrow down the range of possible values for the Nth root.We will use two pointers,
        `low` and `high`, and repeatedly refine the range until we get a sufficiently accurate approximation of the root.

        ### Approach

        1. **Initialize**:
           - Start with `low` as 0 and `high` as the given number.
           - Set a tolerance level (e.g., 1e-7) to decide the precision of the result.

        2. ** Binary Search**:
           - Calculate the middle value `mid` of `low` and `high`.
           - Compute `mid^N`.
           - If `mid^N` is close enough to the given number within the tolerance, return `mid`.
           - If `mid^N` is less than the given number, move the `low` pointer to `mid`.
           - If `mid^N` is greater than the given number, move the `high` pointer to `mid`.

        3. ** Repeat**:
           - Continue refining the range until the difference between `low` and `high` is less than the tolerance level.


        ### Explanation

        1. ** FindNthRoot Function**:
           - The `FindNthRoot` function takes three parameters: the number, the root to be found(`n`), and the precision level(default is `1e-7`).
           - If the number is 0, it immediately returns 0 since the root of 0 is 0.
           - It initializes `low` to 0 and `high` to the given number.
           - It uses a while loop to repeatedly narrow down the range until the difference between `low` and `high` is less than the precision level.
           - In each iteration, it calculates the middle value `mid` and `mid^n`.
           - If `mid^n` is close enough to the given number, it returns `mid`.
           - If `mid^n` is less than the given number, it sets `low` to `mid`.
           - If `mid^n` is greater than the given number, it sets `high` to `mid`.

        2. **Main Function**:
           - The `Main` function initializes the number and the root to be found, then calls the `FindNthRoot` function to find the root.
           - It prints the result.

        ### Time and Space Complexity

        **Time Complexity**: O(log(number) / precision) - 
        *The time complexity is determined by the number of iterations needed to narrow down the range to within the precision level.
        *In each iteration, the range is halved, leading to a logarithmic number of iterations relative to the size of the number and the precision.

        ** Space Complexity**: O(1) -
        *The space complexity is constant as it only uses a fixed amount of additional space for the variables `low`, `high`, `mid`, and `precision`.

        This approach efficiently finds the Nth root of a number using binary search, providing a good balance between simplicity and accuracy.
        */

        public static double FindNthRoot(double number, int n, double precision = 1e-7)
        {
            if (number == 0) return 0;
            if (n == 1) return number;

            double low = 0;
            double high = number;
            double mid;

            while ((high - low) > precision)
            {
                mid = (low + high) / 2;
                double midPower = Math.Pow(mid, n);

                if (Math.Abs(midPower - number) < precision)
                {
                    return mid;
                }
                else if (midPower < number)
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }

            return (low + high) / 2;
        }

        public static void FindNthRootDriver()
        {
            double number = 27;
            int n = 3;

            double result = FindNthRoot(number, n);
            Console.WriteLine("The " + n + "th root of " + number + " is approximately: " + result);
        }
    }

    public class FindMedianOfRowSortedMatrix_H_2
    {
        /*
        To find the median of a row-wise sorted matrix, you can use a binary search approach.
        Since each row is sorted, we can leverage this property to efficiently determine the median.

        ### Approach

        1. **Binary Search on Value Range**:
           - Use binary search to find the median value within the possible range of matrix elements.
           - The minimum value in the matrix is the smallest element in the first row, and the maximum value is the largest element in the last row.

        2. **Count of Elements Less Than or Equal to Mid**:
           - For each mid value in the binary search, count how many elements in the matrix are less than or equal to mid.
           - If this count is greater than or equal to half of the total number of elements in the matrix, then adjust the search range to find the median.


        ### Explanation

        1. ** CountLessThanOrEqualTo Function**:
           - The `CountLessThanOrEqualTo` function counts how many elements in a given row are less than or equal to the provided mid value using binary search.

        2. ** FindMedian Function**:
           - The `FindMedian` function initializes the minimum and maximum values by examining the first and last elements of each row.
           - It uses binary search on the value range to find the median.
           - For each mid value, it counts the number of elements less than or equal to mid using the `CountLessThanOrEqualTo` function.
           - Depending on the count, it adjusts the search range to narrow down the median value.

        3. **GetRow Function**:
           - The `GetRow` function extracts a specific row from the matrix and returns it as an array.

        4. **Main Function**:
           - The `Main` function initializes the matrix and calls the `FindMedian` function to find and print the median.

        ### Time and Space Complexity

        ** Time Complexity**: O(R* log(C)* log(Max - Min))
        - R is the number of rows, and C is the number of columns.
        - The binary search on the value range runs in O(log(Max - Min)).
        - For each value in the binary search, counting the number of elements less than or equal to the mid value takes O(R* log(C)).

        ** Space Complexity**: O(R) - The space complexity is O(R) due to the temporary storage of each row during the counting process.

        This approach efficiently finds the median of a row-wise sorted matrix using binary search, ensuring an optimal balance between time and space complexity.
        */

        public static int CountLessThanOrEqualTo(int[] row, int mid)
        {
            int l = 0, h = row.Length - 1;
            while (l <= h)
            {
                int md = (l + h) / 2;
                if (row[md] <= mid)
                {
                    l = md + 1;
                }
                else
                {
                    h = md - 1;
                }
            }
            return l;
        }

        public static int FindMedian(int[,] matrix)
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            int min = matrix[0, 0], max = matrix[0, c - 1];

            for (int i = 1; i < r; i++)
            {
                if (matrix[i, 0] < min) min = matrix[i, 0];
                if (matrix[i, c - 1] > max) max = matrix[i, c - 1];
            }

            int desired = (r * c + 1) / 2;
            while (min < max)
            {
                int mid = (min + max) / 2;
                int place = 0;
                for (int i = 0; i < r; i++)
                {
                    place += CountLessThanOrEqualTo(GetRow(matrix, i), mid);
                }

                if (place < desired)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid;
                }
            }

            return min;
        }

        private static int[] GetRow(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int[] result = new int[cols];
            for (int i = 0; i < cols; i++)
            {
                result[i] = matrix[row, i];
            }
            return result;
        }

        public static void FindMedianOfRowSortedMatrixDriver()
        {
            int[,] matrix = {
                {1, 3, 5},
                {2, 6, 9},
                {3, 6, 9}
            };

            int median = FindMedian(matrix);
            Console.WriteLine("The median is: " + median);
        }
    }

    public class FindOneElementNotOcurringTwiceInsortedArray_M_3
    {
        /*
        To find a single element in a sorted array where every element appears twice except for one element that appears only once, you can leverage binary search to achieve an optimal solution.This approach works in O(log N) time complexity, which is more efficient than the O(N) time complexity of a linear scan.

        ### Approach

        1. **Binary Search**:
           - Use binary search to identify the single element.
           - Check the middle element and determine whether the single element is in the left or right half of the array by comparing the indices of the duplicates.

        2. **Index Checking**:
           - If the middle element has the same value as the next element and the middle index is even, the single element is in the right half.
           - If the middle element has the same value as the previous element and the middle index is odd, the single element is in the right half.
           - Otherwise, the single element is in the left half.


        ### Explanation

        1. ** FindSingleElement Function**:
           - The `FindSingleElement` function takes a sorted array `nums` as input.
           - It initializes `low` to 0 and `high` to the last index of the array.
           - It uses a while loop to perform binary search until `low` is less than `high`.
           - It calculates the middle index `mid` and ensures it is even to compare pairs correctly.
           - If `nums[mid]` is equal to `nums[mid + 1]`, the single element must be in the right half, so `low` is updated to `mid + 2`.
           - If `nums[mid]` is not equal to `nums[mid + 1]`, the single element must be in the left half, so `high` is updated to `mid`.
           - When the loop exits, `low` points to the single element, which is then returned.

        2. **Main Function**:
           - The `Main` function initializes the input array and calls the `FindSingleElement` function to find the single element.
           - It prints the result.

        ### Time and Space Complexity

        **Time Complexity**: O(log N) - The binary search approach ensures that the time complexity is logarithmic with respect to the number of elements in the array.

        **Space Complexity**: O(1) - The space complexity is constant as the solution only uses a fixed amount of additional space for the variables `low`, `high`, and `mid`.

        This approach efficiently finds the single element in a sorted array where every other element appears twice, ensuring an optimal balance between time and space complexity.
        */

        public static int FindOneElementNotOcurringTwiceInsortedArray(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                // Ensure mid is even, to compare pairs correctly
                if (mid % 2 == 1) mid--;

                if (nums[mid] == nums[mid + 1])
                {
                    // If pair is matched, the single element is in the right half
                    low = mid + 2;
                }
                else
                {
                    // If pair is not matched, the single element is in the left half
                    high = mid;
                }
            }

            // low should be at the single element
            return nums[low];
        }

        public static void FindOneElementNotOcurringTwiceInsortedArrayDriver()
        {
            int[] nums = { 1, 1, 2, 3, 3, 4, 4, 8, 8 };
            Console.WriteLine($"Input Array : {string.Join(", ", nums)}");
            int result = FindOneElementNotOcurringTwiceInsortedArray(nums);
            Console.WriteLine("The single element is: " + result);
        }
    }

    public class SearchElementInRotatedSortedArray_M_4
    {
        /*
        To search for an element in a rotated sorted array, you can use a modified binary search.
        This approach leverages the fact that, even though the array is rotated, it consists of two sorted subarrays.
        By determining which subarray is sorted, you can efficiently narrow down the search range.

        ### Approach

        1. **Binary Search**:
           - Use binary search to find the target element.
           - At each step, determine which part of the array (left or right) is sorted.
           - If the target is within the sorted part, continue the search within that part.
           - Otherwise, continue the search in the other part.


        ### Explanation

        1. ** Search Function**:
           - The `Search` function takes a rotated sorted array `nums` and the `target` element as input.
           - It initializes `left` to 0 and `right` to the last index of the array.
           - It uses a while loop to perform binary search until `left` is less than or equal to `right`.
           - It calculates the middle index `mid`.
           - If `nums[mid]` is equal to the `target`, it returns `mid`.
           - It checks if the left part of the array is sorted by comparing `nums[left]` and `nums[mid]`.
             - If the left part is sorted and the `target` is within this range, it updates `right` to `mid - 1`.
             - Otherwise, it updates `left` to `mid + 1`.
           - If the left part is not sorted, it means the right part must be sorted.
             - If the `target` is within the range of the sorted right part, it updates `left` to `mid + 1`.
             - Otherwise, it updates `right` to `mid - 1`.
           - If the loop exits without finding the `target`, it returns -1.

        2. **Main Function**:
           - The `Main` function initializes the rotated sorted array and the target element.
           - It calls the `Search` function to find the index of the target element.
           - It prints the result.

        ### Time and Space Complexity

        **Time Complexity**: O(log N) - 
        *The binary search approach ensures that the time complexity is logarithmic with respect to the number of elements in the array.

        **Space Complexity**: O(1) - 
        *The space complexity is constant as the solution only uses a fixed amount of additional space for the variables `left`, `right`, and `mid`.

        This approach efficiently searches for an element in a rotated sorted array using a modified binary search, ensuring optimal time and space complexity.
        */

        public static int SearchElementInRotatedSortedArray(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                // Check if the left side is sorted
                if (nums[left] <= nums[mid])
                {
                    // Target is in the left part
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                // Right side is sorted
                else
                {
                    // Target is in the right part
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1; // Target not found
        }

        public static void SearchElementInRotatedSortedArrayDriver()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 0;
            Console.WriteLine($"Input Array : {string.Join(", ", nums)} and Target : {target}");

            int result = SearchElementInRotatedSortedArray(nums, target);
            if (result != -1)
            {
                Console.WriteLine("Element found at index: " + result);
            }
            else
            {
                Console.WriteLine("Element not found in the array.");
            }
        }
    }

    public class FindMedianOf2SortedArraysOfDifferentSizes_H_5
    {
        /*
        To find the median of two sorted arrays of different sizes, you can use a binary search approach.
        This method ensures an efficient solution with a time complexity of O(log(min(N, M))), 
        where N and M are the lengths of the two arrays.

        ### Approach

        1. * *Binary Search on the Smaller Array * *:
           - Perform binary search on the smaller array to minimize the search space.
           - Partition both arrays such that the elements on the left side of the partition are less than or equal to the elements on the right side.

        2. * *Maintain Invariants * *:
           -Ensure that the partitioning is valid by comparing the elements around the partition.

        3. * *Calculate the Median**:
           -If the total number of elements is odd, the median is the maximum of the left side of the partition.
           - If the total number of elements is even, the median is the average of the maximum of the left side and the minimum of the right side of the partition.


        ### Explanation

        1. * *FindMedianSortedArrays Function * *:
           -This function takes two sorted arrays, `nums1` and `nums2`, and finds their median.
           -It ensures `nums1` is the smaller array to minimize the search space.
           -It uses binary search to partition `nums1` and `nums2` such that the left side of the partition contains elements less than or equal to the right side.
           -It calculates the maximum and minimum values around the partition to check if the partition is valid.
           - If the partition is valid, it calculates the median based on whether the total number of elements is odd or even.
           - If the partition is not valid, it adjusts the search range and repeats the process.

        2. * *Main Function * *:
           -The `Main` function initializes two test cases and calls the `FindMedianSortedArrays` function to find and print the median for each case.

        ### Time and Space Complexity

        * *Time Complexity * *: O(log(min(N, M))) - The binary search is performed on the smaller of the two arrays,
        * resulting in logarithmic time complexity with respect to the smaller array's size.

        * *Space Complexity * *: O(1) -
        * The space complexity is constant as the solution only uses a fixed amount of additional space for the variables used in the binary search.

        This approach efficiently finds the median of two sorted arrays of different sizes using a modified binary search, ensuring optimal time and space complexity.

        */

        public static double FindMedianOf2SortedArraysOfDifferentSizes(int[] nums1, int[] nums2)
        {
            // Ensure nums1 is the smaller array
            if (nums1.Length > nums2.Length)
            {
                return FindMedianOf2SortedArraysOfDifferentSizes(nums2, nums1);
            }

            int x = nums1.Length;
            int y = nums2.Length;

            int low = 0, high = x;
            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;

                int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                int minX = (partitionX == x) ? int.MaxValue : nums1[partitionX];

                int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
                int minY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

                if (maxX <= minY && maxY <= minX)
                {
                    if ((x + y) % 2 == 0)
                    {
                        return ((double)Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2;
                    }
                    else
                    {
                        return (double)Math.Max(maxX, maxY);
                    }
                }
                else if (maxX > minY)
                {
                    high = partitionX - 1;
                }
                else
                {
                    low = partitionX + 1;
                }
            }

            throw new InvalidOperationException("Input arrays are not sorted.");
        }

        public static void FindMedianOf2SortedArraysOfDifferentSizesDriver()
        {
            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2 };
            Console.WriteLine($"\n Input Array 1 : {string.Join(", ", nums1)}");
            Console.WriteLine($"Input Array 2 : {string.Join(", ", nums2)} \n");
            double median = FindMedianOf2SortedArraysOfDifferentSizes(nums1, nums2);
            Console.WriteLine("The median is: " + median);

            nums1 = new int[] { 1, 2 };
            nums2 = new int[] { 3, 4 };
            Console.WriteLine($"\n Input Array 1 : {string.Join(", ", nums1)}");
            Console.WriteLine($"Input Array 2 : {string.Join(", ", nums2)} \n");
            median = FindMedianOf2SortedArraysOfDifferentSizes(nums1, nums2);
            Console.WriteLine("The median is: " + median);
        }
    }

    public class FindKthElementIn2SortedArrays_M_6
    {
        /*
        To find the k-th element of two sorted arrays, we can utilize a binary search approach.
        This method efficiently narrows down the search space by eliminating half of the elements from one of the arrays at each step.
        This is optimal and works in O(log(min(N, M))) time complexity, where N and M are the lengths of the two arrays.

        ### Approach

        1. **Binary Search**:
           - Use binary search on the smaller array to partition both arrays such that the total number of elements in the left parts is `k`.
           - At each step, compare the elements around the partition to determine if the current partition is valid.

        2. **Maintain Invariants**:
           - Ensure that the elements in the left part of the partition are less than or equal to the elements in the right part.

        3. **Determine the k-th Element**:
           - If the partition is valid, the k-th element will be the maximum of the left parts.


        ### Explanation

        1. ** FindKthElement Function**:
           - This function takes two sorted arrays, `nums1` and `nums2`, and an integer `k` to find the k-th element.
           - It ensures `nums1` is the smaller array to minimize the search space.
           - It initializes `low` and `high` to define the search range in the smaller array.
           - It uses binary search to partition `nums1` and `nums2` such that the total number of elements in the left parts of both partitions is `k`.
           - It calculates the maximum and minimum values around the partition to check if the partition is valid.
           - If the partition is valid, it returns the maximum of the left parts as the k-th element.
           - If the partition is not valid, it adjusts the search range and repeats the process.

        2. **Main Function**:
           - The `Main` function initializes two sorted arrays and a value `k`.
           - It calls the `FindKthElement` function to find and print the k-th element.

        ### Time and Space Complexity

        **Time Complexity**: O(log(min(N, M))) - The binary search is performed on the smaller of the two arrays,
        *resulting in logarithmic time complexity with respect to the smaller array's size.

        ** Space Complexity**: O(1) - The space complexity is constant as the solution only uses a fixed amount of additional space for the variables used in the binary search.

        This approach efficiently finds the k - th element in the union of two sorted arrays using a modified binary search, ensuring optimal time and space complexity.
        */

        public static int FindKthElementIn2SortedArrays(int[] nums1, int[] nums2, int k)
        {
            int len1 = nums1.Length;
            int len2 = nums2.Length;

            if (len1 > len2)
            {
                return FindKthElementIn2SortedArrays(nums2, nums1, k);
            }

            int low = Math.Max(0, k - len2), high = Math.Min(k, len1);

            while (low <= high)
            {
                int partition1 = (low + high) / 2;
                int partition2 = k - partition1;

                int maxLeft1 = (partition1 == 0) ? int.MinValue : nums1[partition1 - 1];
                int minRight1 = (partition1 == len1) ? int.MaxValue : nums1[partition1];

                int maxLeft2 = (partition2 == 0) ? int.MinValue : nums2[partition2 - 1];
                int minRight2 = (partition2 == len2) ? int.MaxValue : nums2[partition2];

                if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
                {
                    return Math.Max(maxLeft1, maxLeft2);
                }
                else if (maxLeft1 > minRight2)
                {
                    high = partition1 - 1;
                }
                else
                {
                    low = partition1 + 1;
                }
            }

            throw new InvalidOperationException("Input arrays are not sorted or k is out of bounds.");
        }

        public static void FindKthElementIn2SortedArraysDriver()
        {
            int[] nums1 = { 2, 3, 6, 7, 9 };
            int[] nums2 = { 1, 4, 8, 10 };
            Console.WriteLine($"\nInput Array 1 : {string.Join(", ", nums1)}");
            Console.WriteLine($"Input Array 2 : {string.Join(", ", nums2)} \n");

            int k = 5;
            Console.WriteLine($"Kth Element : {k} \n");
            int result = FindKthElementIn2SortedArrays(nums1, nums2, k);
            Console.WriteLine($"The {k}-th element is: " + result);
        }
    }

    public class AssignMinPagesSuchMaxPagesToOneIsMinimised_H_7
    {
        /*
        To solve the problem of allocating the minimum number of pages such that the maximum number of pages assigned to a student is minimized,
        we can use a binary search approach.
        This problem is often seen in the context of dividing books among students such that the maximum pages read by a student is minimized.

        ### Problem Statement

        Given an array of integers where each integer represents the number of pages in a book,
        and an integer `m` representing the number of students, we need to allocate books to students such that:
        1. Each student gets at least one book.
        2. Each book is allocated to exactly one student.
        3. The maximum number of pages assigned to a student is minimized.

        ### Approach

        1. ** Binary Search**:
           - Use binary search to find the minimum possible value of the maximum pages a student can read.
           - Set the lower bound `low` to the maximum number of pages in a single book(since no student can read fewer than the most pages in a single book).
           - Set the upper bound `high` to the sum of all book pages(in the worst case, one student reads all the books).

        2. ** Check Feasibility**:
           - For each mid value(potential solution), check if it is possible to allocate the books such that no student reads more than `mid` pages.

        ### Explanation

        1. ** IsFeasible Function**:
           - The `IsFeasible` function checks if it is possible to allocate books such that no student reads more than `mid` pages.
           - It iterates through the books and sums the pages for each student.If adding another book exceeds `mid`,
        it allocates the current sum to a new student and continues.

        2. ** FindPages Function**:
           - The `FindPages` function performs binary search to find the minimum possible maximum pages.
           - It calculates the initial `low` as the maximum pages in a single book and `high` as the sum of all book pages.
           - It uses the `IsFeasible` function to check if a mid value is a valid solution and adjusts the search range accordingly.

        3. **Main Function**:
           - The `Main` function initializes the array of books and the number of students, then calls `FindPages` to find and print the minimum number of pages.

        ### Time and Space Complexity

        ** Time Complexity**: O(N log(sum - maxPages)), where N is the number of books.The binary search runs in O(log(sum - maxPages)) time,
        *and for each mid value, the feasibility check runs in O(N) time.

        ** Space Complexity**: O(1). The space complexity is constant as we use a fixed amount of additional space for the variables.

        This approach efficiently finds the minimum number of pages that can be allocated to a student in a way that the maximum number of pages read by any student is minimized.
        */

        public static bool IsFeasible(int[] books, int n, int m, int mid)
        {
            int studentsRequired = 1;
            int currentPages = 0;

            for (int i = 0; i < n; i++)
            {
                if (books[i] > mid)
                    return false;

                if (currentPages + books[i] > mid)
                {
                    studentsRequired++;
                    currentPages = books[i];

                    if (studentsRequired > m)
                        return false;
                }
                else
                {
                    currentPages += books[i];
                }
            }

            return true;
        }

        public static int FindPages(int[] books, int n, int m)
        {
            if (n < m)
                return -1;

            int sum = 0;
            int maxPages = 0;

            for (int i = 0; i < n; i++)
            {
                sum += books[i];
                maxPages = Math.Max(maxPages, books[i]);
            }

            int low = maxPages;
            int high = sum;
            int result = int.MaxValue;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (IsFeasible(books, n, m, mid))
                {
                    result = Math.Min(result, mid);
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }

        public static void AssignMinPagesSuchMaxPagesToOneIsMinimisedDriver()
        {
            int[] books = { 12, 34, 67, 90 };
            int students = 2;
            Console.WriteLine($"Pages in books : {string.Join(", ", books)}");
            Console.WriteLine($" number of students : {students} \n");
            int result = FindPages(books, books.Length, students);
            Console.WriteLine("The minimum number of pages is: " + result);
        }
    }

    public class MaximiseTheMinimumDistanceBetweenAny2Cows_H_8
    {
        /*
        The "Aggressive Cows" problem is a classic example of using binary search on the answer.
        In this problem, you are given an array representing stalls and an integer representing the number of cows.
        The goal is to place the cows in the stalls such that the minimum distance between any two cows is maximized.

        ### Problem Statement

        Given:
        1. An array of integers `stalls` representing the positions of stalls.
        2. An integer `k` representing the number of cows.

        Objective:
        - Place the cows in the stalls such that the minimum distance between any two cows is maximized.

        ### Approach

        1. **Sort the Stalls**:
           - First, sort the array of stalls to facilitate the search process.

        2. **Binary Search on the Minimum Distance**:
           - Use binary search to determine the largest minimum distance possible.
           - Set `low` to 1 (the smallest possible distance) 
        and `high` to the difference between the maximum and minimum stall positions(the largest possible distance).

        3. ** Feasibility Check**:
           - For a given mid-distance, check if it is possible to place all cows such that each cow is at least mid-distance apart.
           - Use a greedy approach to place the cows: place the first cow in the first stall
        and then place each subsequent cow in the next stall that is at least mid-distance away from the last placed cow.


        ### Explanation

        1. ** IsFeasible Function**:
           - This function checks if it is possible to place all cows with at least `mid` distance apart.
           - It starts by placing the first cow in the first stall.
           - It then iterates through the stalls, placing each subsequent cow in the next stall that is at least `mid` distance away from the last placed cow.
           - If all cows are placed successfully, it returns `true`; otherwise, it returns `false`.

        2. ** AggressiveCows Function**:
           - This function uses binary search to find the maximum possible minimum distance.
           - It sorts the stalls and initializes `low` and `high` for binary search.
           - It iteratively checks the feasibility of the mid value and adjusts the search range based on the feasibility check.
           - The result is updated whenever a feasible mid value is found.

        3. **Main Function**:
           - The `Main` function initializes the array of stalls and the number of cows.
           - It calls `AggressiveCows` to find and print the largest minimum distance.

        ### Time and Space Complexity

        **Time Complexity**: O(N log(D)), where N is the number of stalls and D is the difference between the maximum and minimum stall positions.
        *The binary search runs in O(log(D)) time, and the feasibility check runs in O(N) time.

        ** Space Complexity**: O(1). The space complexity is constant as we use a fixed amount of additional space for the variables.

        This approach efficiently finds the largest minimum distance possible to place the cows in the stalls
        using a binary search on the answer, ensuring optimal time and space complexity.
        */

        public static bool IsFeasible(int[] stalls, int k, int mid)
        {
            int count = 1;  // Place the first cow in the first stall
            int lastPosition = stalls[0];

            for (int i = 1; i < stalls.Length; i++)
            {
                if (stalls[i] - lastPosition >= mid)
                {
                    count++;
                    lastPosition = stalls[i];
                    if (count == k)
                        return true;
                }
            }

            return false;
        }

        public static int AggressiveCows(int[] stalls, int k)
        {
            Array.Sort(stalls);
            int n = stalls.Length;

            int low = 1;
            int high = stalls[n - 1] - stalls[0];
            int result = 0;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (IsFeasible(stalls, k, mid))
                {
                    result = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;
        }

        public static void MaximiseTheMinimumDistanceBetweenAny2CowsDriver()
        {
            int[] stalls = { 1, 2, 8, 4, 9 };
            int cows = 3;
            Console.WriteLine($"stalls : {string.Join(", ", stalls)}");
            Console.WriteLine($"number of cows : {cows} \n");

            int result = AggressiveCows(stalls, cows);
            Console.WriteLine("The largest minimum distance is: " + result);
        }
    }

}
