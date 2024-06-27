using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Xml;
using System.Data;
using static StackAndQueue.RottenOranges_M_14;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.Arm;

namespace Strings
{
    public class ReverseWordsInString_M_1
    {
        /*
        To achieve an `O(1)` space complexity while reversing the words in a string,
        we need to reverse the characters of the entire string first and then reverse the characters of each word in place.
        This approach avoids using any additional space for storing intermediate results.

        Here's the step-by-step approach and the corresponding C# code:

        ### Steps:

        1. ** Reverse the Entire String**: Reverse all characters in the string.
        2. ** Reverse Each Word in Place**: Iterate through the reversed string and reverse the characters of each word to restore 
        the correct word order.

        ### Explanation

        1. ** Reverse the Entire String**:
           - The `Reverse` method reverses a portion of the character array in place by swapping characters 
        from the start and end towards the middle.

        2. **Reverse Each Word in Place**:
           - Iterate through the character array and reverse each word.Words are identified by spaces.
        We reverse the word when we encounter a space or reach the end of the string.

        3. **Clean Up Extra Spaces**:
           - The `CleanSpaces` method removes leading, trailing, and multiple intermediate spaces,
        ensuring that only single spaces separate words.

        ### Complexity

        - **Time Complexity**: (O(n)), where (n) is the length of the input string. 
        Each character in the string is processed a constant number of times.
        - **Space Complexity**: (O(1)) additional space, since all operations are performed in place on the input string's character array.

        This approach ensures that the words in the string are reversed correctly while minimizing additional space usage.
        */

        private static void Reverse(char[] arr, int start, int end)
        {
            while (start < end)
            {
                char temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        public static string ReverseWordsInString(string s)
        {
            char[] str = s.Trim().ToCharArray();
            int n = str.Length;

            // Step 1: Reverse the entire string
            Reverse(str, 0, n - 1);

            // Step 2: Reverse each word in place
            int start = 0;
            for (int end = 0; end < n; end++)
            {
                if (str[end] == ' ')
                {
                    Reverse(str, start, end - 1);
                    start = end + 1;
                }
                else if (end == n - 1)
                {
                    Reverse(str, start, end);
                }
            }

            // Remove extra spaces between words
            return new string(CleanSpaces(str, n));
        }

        private static char[] CleanSpaces(char[] a, int n)
        {
            int i = 0, j = 0;
            while (j < n)
            {
                while (j < n && a[j] == ' ') j++; // skip spaces
                while (j < n && a[j] != ' ') a[i++] = a[j++]; // keep non spaces
                while (j < n && a[j] == ' ') j++; // skip spaces
                if (j < n) a[i++] = ' '; // keep only one space
            }
            return a[0..i];
        }

        public static void ReverseWordsInStringDriver()
        {
            string input = "  the sky is blue  ";
            string reversed = ReverseWordsInString(input);
            Console.WriteLine("Original string: \"" + input + "\"");
            Console.WriteLine("Reversed words: \"" + reversed + "\"");
        }
    }

    public class LongestPalindromeSubstring_M_2
    {
        /*
        To find the longest palindromic substring in a given string, we can use several approaches, 
        but one of the most efficient ones is the** Expand Around Center** method.
        This method leverages the fact that a palindrome mirrors around its center.
        Therefore, for each character (and between each pair of characters) in the string,
        we can expand outward to check for palindromes.

        ### Expand Around Center Method

        For a given string `s` of length `n`, the idea is to consider each character(and each gap between characters)
        as potential centers and expand outward as long as the characters on both sides are equal.
        This results in `2n - 1` potential centers(one for each character and one for each gap).

        #### Steps:
        1. Iterate over each character and each gap in the string.
        2. For each center, expand outward as long as the characters on both sides are equal.
        3. Keep track of the longest palindrome found during the expansions.

        ### Explanation

        1. ** LongestPalindrome Function**:
           - Iterates over each character and each gap in the string.
           - Calls `ExpandAroundCenter` for each center.
           - Updates the start and end indices of the longest palindrome found.

        2. **ExpandAroundCenter Function**:
           - Expands outward from the given center as long as the characters on both sides are equal.
           - Returns the length of the palindrome found.

        3. **Main Function**:
           - Demonstrates the usage of `LongestPalindrome` with sample inputs.

        ### Complexity

        - **Time Complexity**: (O(n^2)), where (n) is the length of the string. 
        In the worst case, each character in the string is compared (n) times.
        - ** Space Complexity**: (O(1)), since we only use a constant amount of extra space for the indices and lengths.

        This approach efficiently finds the longest palindromic substring in the given string without requiring additional
        space beyond a few integer variables.
        */

        public static string LongestPalindrome(string s)
        {
            if (s == null || s.Length < 1)
            {
                return "";
            }

            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);     // Odd length palindromes
                int len2 = ExpandAroundCenter(s, i, i + 1); // Even length palindromes
                int len = Math.Max(len1, len2);

                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1; // Length of the palindrome
        }

        public static void LongestPalindromeSubstringDriver()
        {
            string input = "babad";
            string result = LongestPalindrome(input);
            Console.WriteLine("Input string: " + input);
            Console.WriteLine("Longest palindromic substring: " + result);

            input = "cbbd";
            result = LongestPalindrome(input);
            Console.WriteLine("Input string: " + input);
            Console.WriteLine("Longest palindromic substring: " + result);
        }
    }

    public class RomanNumberToIntegerAndViceversa_E_3
    {
        /*
        To handle the conversion between Roman numerals and integers, we need two separate methods:
        one for converting Roman numerals to integers and another for converting integers to Roman numerals.

        ### 1. Roman to Integer

        Roman numerals are based on certain combinations of letters from the Latin alphabet(I, V, X, L, C, D, M).
        To convert a Roman numeral to an integer, we can use the following approach:

        - Create a dictionary to map Roman numeral characters to their integer values.
        - Iterate through the characters of the Roman numeral string.
          - If the current character's value is less than the next character's value, 
        subtract the current character's value from the total.
          - Otherwise, add the current character's value to the total.

        ### 2. Integer to Roman

        To convert an integer to a Roman numeral, we can use the following approach:

        - Create a list of tuples that map integer values to their corresponding Roman numeral strings, ordered from largest to smallest.
        - Iterate through the list, subtracting the integer value from the input number and
        appending the corresponding Roman numeral string to the result until the input number is reduced to zero.


        ### Explanation

        1. ** Roman to Integer**:
           - The dictionary `RomanToIntMap` maps each Roman numeral character to its corresponding integer value.
           - The method `RomanToInt` iterates through the input string, 
        checking if the current character's value is less than the next character's value. 
        If so, it subtracts the current character's value from the total; otherwise, it adds the value to the total.

        2. **Integer to Roman**:
           - The list `IntToRomanMap` contains tuples of integer values and their corresponding Roman numeral strings,
        ordered from largest to smallest.
           - The method `IntToRoman` iterates through the list, appending the corresponding Roman numeral string
        to the result while subtracting the integer value from the input number until the input number is reduced to zero.

        ### Complexity

        - **Time Complexity**:
          - Roman to Integer: (O(n)), where (n) is the length of the input string.
          - Integer to Roman: (O(1)), since the number of unique Roman numeral symbols is constant and
        the number of iterations is bounded by the fixed size of the integer.

        - **Space Complexity * *: (O(1)) for both conversions, as we only use a fixed amount
        of extra space for the mappings and the result string.

        This solution efficiently handles both conversions and demonstrates the usage with examples.
        */

        private static readonly Dictionary<char, int> RomanToIntMap = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        private static readonly List<(int, string)> IntToRomanMap = new List<(int, string)>
        {
            (1000, "M"),
            (900, "CM"),
            (500, "D"),
            (400, "CD"),
            (100, "C"),
            (90, "XC"),
            (50, "L"),
            (40, "XL"),
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I")
        };

        public static int RomanToInt(string s)
        {
            int total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 < s.Length && RomanToIntMap[s[i]] < RomanToIntMap[s[i + 1]])
                {
                    total -= RomanToIntMap[s[i]];
                }
                else
                {
                    total += RomanToIntMap[s[i]];
                }
            }
            return total;
        }

        public static string IntToRoman(int num)
        {
            var result = new System.Text.StringBuilder();
            foreach (var (value, numeral) in IntToRomanMap)
            {
                while (num >= value)
                {
                    num -= value;
                    result.Append(numeral);
                }
            }
            return result.ToString();
        }

        public static void RomanNumberToIntegerAndViceversaDriver()
        {
            // Roman to Integer examples
            Console.WriteLine("Roman to Integer:");
            string roman = "MCMXCIV";
            Console.WriteLine($"{roman} -> {RomanToInt(roman)}");

            roman = "LVIII";
            Console.WriteLine($"{roman} -> {RomanToInt(roman)}");

            // Integer to Roman examples
            Console.WriteLine("\nInteger to Roman:");
            int number = 1994;
            Console.WriteLine($"{number} -> {IntToRoman(number)}");

            number = 58;
            Console.WriteLine($"{number} -> {IntToRoman(number)}");
        }
    }

    public class StringToInteger_M_4
    {
        /*
        Sure! Let's go through the implementation of two commonly requested string manipulation functions: 
        `atoi` (convert a string to an integer) and `strstr` (find the first occurrence of a substring in a string).

        ### atoi Implementation

        The `atoi` function(ASCII to Integer) converts a string representation of an integer to its integer value.
        Here's how to implement it in C#:

        ### Steps:
        1. Skip leading whitespace.
        2. Check for an optional sign(`+` or `-`).
        3. Convert the numerical digits.
        4. Handle overflow and underflow.

        ### Explanation:
        1. ** Skipping leading whitespaces**.
        2. ** Checking for the optional sign**: Sets the sign multiplier to `-1` for a negative sign.
        3. ** Converting numerical digits**: Converts characters to their integer value by subtracting `'0'`.
        4. ** Handling overflow**: Checks if adding the next digit would cause an overflow.

        ### Complexity:
        - **atoi**:
          - Time Complexity: (O(n)), where (n) is the length of the input string.
          - Space Complexity: (O(1)), constant space usage.
        */

        public static int Atoi(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            int i = 0, sign = 1, result = 0;
            // Step 1: Skip leading whitespace
            while (i < str.Length && char.IsWhiteSpace(str[i])) i++;

            // Step 2: Check for optional sign
            if (i < str.Length && (str[i] == '+' || str[i] == '-'))
            {
                sign = (str[i] == '-') ? -1 : 1;
                i++;
            }

            // Step 3: Convert numerical digits and handle overflow
            while (i < str.Length && char.IsDigit(str[i]))
            {
                int digit = str[i] - '0';
                if (result > (int.MaxValue - digit) / 10)
                {
                    // Handle overflow
                    return (sign == 1) ? int.MaxValue : int.MinValue;
                }
                result = result * 10 + digit;
                i++;
            }

            return result * sign;
        }

        public static void StringToIntegerDriver()
        {
            Console.WriteLine($"Atoi(\"42\") : {Atoi("42")}");              // 42
            Console.WriteLine($"Atoi(\"42\") : {Atoi("   -42")}");          // -42
            Console.WriteLine($"Atoi(\"4193 with words\") : {Atoi("4193 with words")}"); // 4193
            Console.WriteLine($"Atoi(\"words and 987\") : {Atoi("words and 987")}");   // 0
            Console.WriteLine($"Atoi(\"-91283472332\") : {Atoi("-91283472332")}");    // -2147483648 (int.MinValue)
        }
    }

    public class SubstringSearch_M_5
    {
        /*
        ### strstr Implementation

        The `strstr` function finds the first occurrence of a substring within a string. 
        This is also known as the substring search.
        The simplest and most intuitive method is to use a sliding window approach.

        ### Steps:
        1. Loop through the main string.
        2. For each position, check if the substring matches the characters starting from that position.

        ### Explanation:
        1. ** Handling edge cases**: Returns `0` if the needle is empty.
        2. ** Sliding window approach**: Loops through each position in the haystack string where the needle could fit.
        3. **Matching characters**: For each position, checks if the substring matches starting from that position.

        ### Complexity:
        - ** strstr**:
          - Time Complexity: (O((n - m + 1) * m)), where (n) is the length of the haystack and (m) is the length of the needle.
        This is due to the nested loop.
          - Space Complexity: (O(1)), constant space usage.

        These implementations provide a clear and efficient way to convert strings to integers and
        to search for substrings within strings using C#.
        */

        public static int StrStr(string haystack, string needle)
        {
            if (needle == "") return 0;
            if (haystack.Length < needle.Length) return -1;

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                int j;
                for (j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        break;
                    }
                }
                if (j == needle.Length)
                {
                    return i;
                }
            }

            return -1;
        }

        public static void SubstringSearchDriver()
        {
            Console.WriteLine($"StrStr(\"hello\", \"ll\") : {StrStr("hello", "ll")}");   // 2
            Console.WriteLine($"StrStr(\"aaaaa\", \"bba\") : {StrStr("aaaaa", "bba")}");  // -1
            Console.WriteLine($"StrStr(\"abc\", \"\") : {StrStr("abc", "")}");       // 0
        }
    }

    public class LongestCommonPrefix_E_6
    {
        /*
        To find the longest common prefix among an array of strings, we can use several methods.
        One of the most straightforward and efficient methods is to use the vertical scanning approach.
        This method involves comparing characters of each string at the same index until a mismatch is found.

        ### Vertical Scanning Method

        The vertical scanning method works as follows:
        1. Take the first string as the initial prefix.
        2. Compare each character of this prefix with the corresponding character in each of the other strings.
        3. If a mismatch is found or the end of any string is reached, truncate the prefix to the matched characters so far.
        4. Continue until you have compared all characters of the prefix with all strings.


        ### Explanation:

        1. ** Check for empty input**: If the input array is null or empty, return an empty string.
        2. ** Outer loop**: Iterate over the characters of the first string.
        3. ** Inner loop**: Compare each character with the corresponding character in all other strings.
        4. ** Mismatch handling**: If a mismatch is found or the end of any string is reached, 
        return the substring of the first string up to the current index.
        5. **Return prefix**: If no mismatch is found, return the first string as it is the common prefix.

        ### Complexity:

        - **Time Complexity**: (O(S)), where (S) is the sum of all characters in all strings.In the worst case,
        all characters of all strings are checked.
        - **Space Complexity**: (O(1)), constant space usage since we are only using a few variables for comparison and indexing.

        This approach is efficient and simple, making it suitable for finding the longest common prefix among
        a list of strings in an optimal manner.
        */

        public static string FindLongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";

            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != c)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0];
        }

        public static void LongestCommonPrefixDriver()
        {
            string[] strs1 = { "flower", "flow", "flight" };
            foreach (var str in strs1)
            {
                Console.Write($" {str} ");
            }
            Console.WriteLine();
            Console.WriteLine("Longest Common Prefix: " + FindLongestCommonPrefix(strs1)); // Output: "fl"

            string[] strs2 = { "dog", "racecar", "car" };
            foreach (var str in strs2)
            {
                Console.Write($" {str} ");
            }
            Console.WriteLine();
            Console.WriteLine("Longest Common Prefix: " + FindLongestCommonPrefix(strs2)); // Output: ""
        }
    }

    public class RabinKarpAlgorithm_M_7
    {
        /*
        The Rabin-Karp algorithm is a string-searching algorithm that uses hashing to find any one of a set of pattern strings in a text.
        It is particularly useful for searching multiple patterns at once.

        ### Rabin-Karp Algorithm

        Here's a step-by-step breakdown of how the Rabin-Karp algorithm works:

        1. **Hash the pattern**: Compute the hash value of the pattern string.
        2. **Hash the initial part of the text**: Compute the hash value of the first window of text of the same length as the pattern.
        3. **Slide the window**: Slide the window over the text one character at a time and update the hash value efficiently.
        4. **Check hash matches**: If the hash values of the current window of text and the pattern match,
        check the characters one by one to avoid spurious hits.

        ### Explanation:

        1. ** Hashing**:
           - The hash function used is a simple rolling hash function.
           - We compute the hash of the pattern and the hash of the first window of text of the same length.

        2. **Sliding the window**:
           - We slide the window one character at a time and update the hash value using the rolling hash formula
        to avoid recomputing the hash from scratch.

        3. **Checking hash matches**:
           - When the hash values match, we check the actual characters to avoid spurious hits 
        (since different strings can have the same hash).

        4. ** Handling hash value**:
           - We use modulo arithmetic with a prime number to keep the hash values manageable and reduce the likelihood of collisions.

        ### Complexity:

        - **Time Complexity**:
          - Average case: (O(n + m)) where (n) is the length of the text and (m) is the length of the pattern.
          - Worst case: (O((n - m + 1) times m)) in case of many hash collisions.

        - **Space Complexity**: (O(1)), constant extra space is used for hashing.

        This implementation provides an efficient way to search for a pattern in a text using the Rabin-Karp algorithm.
        */

        public static List<int> Search(string text, string pattern)
        {
            List<int> result = new List<int>();

            int m = pattern.Length;
            int n = text.Length;
            int prime = 101; // A prime number
            int patternHash = 0; // Hash value for pattern
            int textHash = 0; // Hash value for text
            int h = 1;
            int d = 256; // Number of characters in the input alphabet

            // The value of h would be "pow(d, M-1)%q"
            for (int i = 0; i < m - 1; i++)
                h = (h * d) % prime;

            // Calculate the hash value of pattern and first window of text
            for (int i = 0; i < m; i++)
            {
                patternHash = (d * patternHash + pattern[i]) % prime;
                textHash = (d * textHash + text[i]) % prime;
            }

            // Slide the pattern over text one by one
            for (int i = 0; i <= n - m; i++)
            {
                // Check the hash values of current window of text and pattern.
                // If the hash values match then only check for characters one by one
                if (patternHash == textHash)
                {
                    bool match = true;
                    for (int j = 0; j < m; j++)
                    {
                        if (text[i + j] != pattern[j])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                        result.Add(i);
                }

                // Calculate hash value for next window of text: Remove leading digit,
                // add trailing digit
                if (i < n - m)
                {
                    textHash = (d * (textHash - text[i] * h) + text[i + m]) % prime;

                    // We might get negative value of textHash, converting it to positive
                    if (textHash < 0)
                        textHash = (textHash + prime);
                }
            }

            return result;
        }

        public static void RabinKarpAlgorithmDriver()
        {
            string text = "ABCCDDAEFG";
            string pattern = "CDD";
            List<int> result = Search(text, pattern);

            Console.WriteLine($"Text : {text}");
            Console.WriteLine($"Pattern : {pattern}");
            Console.WriteLine("Pattern found at indices: " + string.Join(", ", result));
        }
    }

    public class ZFunction_E_8
    {
        /*
        The Z-function for a string is an array of length equal to the string's length,
        where the value at each position indicates the length of the longest substring starting 
        from that position which is also a prefix of the string. This can be very useful in pattern matching algorithms.

        ### Z-Function Algorithm

        The algorithm to compute the Z-function efficiently uses a combination of comparisons and
        a sliding window technique to avoid redundant comparisons.Here is the step-by-step approach:

        1. Initialize the Z-array with the same length as the string and set the first element to the length of the string.
        2. Use two pointers, `L` and `R`, to keep track of the interval [L, R] which matches a prefix of the string.
        3. Iterate through the string from the second character to the end:
           - If the current position is within the [L, R] interval, use previously computed Z-values to skip some comparisons.
           - Expand the interval[L, R] as far as possible by comparing characters directly.
        4. Store the length of the matching prefix in the Z-array.


        ### Explanation:

        1. ** Initialization**:
           - The Z-array is initialized with the length of the string.
           - The first element is set to the length of the string since the entire string is trivially a prefix of itself.

        2. ** Using the interval[L, R]**:
           - The interval[L, R] represents the segment of the string which matches a prefix of the string.
           - If the current position `i` is within the interval, use previously computed Z-values
        to set a lower bound on the current Z-value.

        3. ** Expanding the interval**:
           - If the current position `i` is not within the interval, or if the current Z-value is less than the length of the interval,
        expand the interval by comparing characters directly.
           - Update the interval[L, R] if necessary.

        4. ** Storing Z-values**:
           - The Z-values represent the length of the longest prefix starting at each position which matches a prefix of the string.

        ### Complexity:

        - ** Time Complexity**: (O(n)), where (n) is the length of the string.
        Each character of the string is compared at most a constant number of times.
        - **Space Complexity**: (O(n)) for the Z-array, where (n) is the length of the string.

        This implementation of the Z-function is efficient and useful for various pattern matching and string processing tasks.
        */

        public static int[] ComputeZFunction(string s)
        {
            int n = s.Length;
            int[] Z = new int[n];
            Z[0] = n;

            int L = 0, R = 0;
            for (int i = 1; i < n; i++)
            {
                if (i <= R)
                {
                    Z[i] = Math.Min(R - i + 1, Z[i - L]);
                }
                while (i + Z[i] < n && s[Z[i]] == s[i + Z[i]])
                {
                    Z[i]++;
                }
                if (i + Z[i] - 1 > R)
                {
                    L = i;
                    R = i + Z[i] - 1;
                }
            }

            return Z;
        }

        public static void ZFunctionDriver()
        {
            string s = "abacaba";
            Console.WriteLine("Input string: " + s);
            int[] Z = ComputeZFunction(s);
            Console.WriteLine("Z-function values: " + string.Join(", ", Z));
        }
    }

    public class KMP_E_9
    {
        /*
        KMP - occurrences of a "pattern" string within a "text" string.
        The Knuth-Morris-Pratt(KMP) algorithm is an efficient string-searching algorithm that searches for occurrences of a "pattern" 
        string within a "text" string. It achieves this efficiency by using information from previous matches to avoid rechecking
        characters that have already been matched.

        ### Key Concepts of KMP Algorithm

        1. **LPS (Longest Prefix Suffix) Array**: The LPS array(also known as the "pi" array) is the key component of the KMP algorithm.
        For a given pattern, the LPS array stores the length of the longest proper prefix of the pattern that is also
        a suffix for each prefix of the pattern.
        2. ** Pattern Matching**: The KMP algorithm uses the LPS array to skip characters in the text string,
        avoiding unnecessary comparisons.

        ### Steps to Implement KMP Algorithm

        1. ** Compute the LPS Array**: This step preprocesses the pattern to build the LPS array.
        2. **Pattern Matching Using the LPS Array**: This step uses the LPS array to search for the pattern in the text efficiently.

        ### Explanation:

        1. ** ComputeLPSArray**:
           - This function calculates the LPS array for the given pattern.
           - The LPS array helps in determining the next positions to match after a mismatch occurs.

        2. **KMPSearch**:
           - This function uses the LPS array to efficiently search for the pattern in the given text.
           - It avoids unnecessary re-checks by utilizing the information stored in the LPS array.

        ### Complexity:

        - **Time Complexity**:
          - LPS Array Computation: (O(M)), where (M) is the length of the pattern.
          - Pattern Matching: (O(N)), where (N) is the length of the text.
          - Overall: (O(N + M)).

        - ** Space Complexity**:
          - The space complexity is (O(M)) for the LPS array.

        This implementation of the KMP algorithm efficiently searches for a pattern in a text by leveraging the LPS array,
        making it an optimal solution for the string search problem.
        */

        // Function to compute the LPS (Longest Prefix Suffix) array
        public static int[] ComputeLPSArray(string pattern)
        {
            int length = 0; // Length of the previous longest prefix suffix
            int i = 1;
            int M = pattern.Length;
            int[] lps = new int[M];
            lps[0] = 0; // lps[0] is always 0

            // Loop to calculate lps[i] for i = 1 to M-1
            while (i < M)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    // If (pattern[i] != pattern[length])
                    if (length != 0)
                    {
                        length = lps[length - 1];
                        // Do not increment i here
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }

        // KMP pattern matching algorithm
        public static void KMPSearch(string text, string pattern)
        {
            int N = text.Length;
            int M = pattern.Length;
            int[] lps = ComputeLPSArray(pattern);

            int i = 0; // Index for text[]
            int j = 0; // Index for pattern[]
            while (i < N)
            {
                if (pattern[j] == text[i])
                {
                    i++;
                    j++;
                }

                if (j == M)
                {
                    Console.WriteLine("Found pattern at index " + (i - j));
                    j = lps[j - 1];
                }
                else if (i < N && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        public static void KMPDriver()
        {
            string text = "ABABDABACDABABCABAB";
            string pattern = "ABABCABAB";
            Console.WriteLine($"Text : {text}");
            Console.WriteLine($"Pattern : {pattern}");
            KMPSearch(text, pattern);
        }
    }

    public class MinimumInsertionsToMakeStringPalindrome_M_10
    {
        /*
        To find the minimum number of characters needed to be inserted at the beginning of a string to make it a palindrome,
        we can leverage the concept of the longest prefix which is also a suffix(LPS) using the KMP algorithm.

        ### Explanation

        The idea is to use the KMP algorithm to find the longest palindromic suffix in the given string.
        By adding the minimum characters in the beginning of the string to match this suffix, we can make the whole string a palindrome.

        Here's how we can do it:

        1. **Concatenate the string with its reverse**: Create a new string that is the concatenation of the original string,
        a special character(not present in the string), and the reverse of the original string.
        2. ** Compute the LPS array** for this concatenated string.
        3. **The value at the last index of the LPS array** will give us the length of the longest palindromic suffix of the original string.
        4. **Calculate the minimum characters** needed to be inserted:
        This will be the difference between the original string's length and the length of the longest palindromic suffix.

        ### Explanation of the Code:

        1. ** ComputeLPSArray**:
           - This function computes the LPS array for a given string using the KMP preprocessing algorithm.

        2. ** MinCharsToPalindrome**:
           - This function computes the minimum number of characters needed to be inserted at the beginning to make the string a palindrome.
           - It constructs a concatenated string consisting of the original string, a special character `#`,
        and the reverse of the original string.
           - It then calculates the LPS array for this concatenated string and uses the last value in the LPS array
        to determine the length of the longest palindromic suffix.
           - The number of insertions required is the difference between the length of the original string and the length of this suffix.

        ### Complexity:

        - **Time Complexity**: (O(N)), where (N) is the length of the original string.
        The LPS computation and string operations are linear in terms of the length of the string.
        - **Space Complexity**: (O(N)) for the LPS array and the concatenated string.

        This method is efficient and leverages the power of the KMP algorithm to solve the problem in linear time.
        */


        public static int ComputeLPSArray(string str)
        {
            int n = str.Length;
            int[] lps = new int[n];
            int length = 0;  // length of the previous longest prefix suffix
            int i = 1;

            lps[0] = 0;  // lps[0] is always 0

            while (i < n)
            {
                if (str[i] == str[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps[n - 1];
        }

        public static int MinCharsToPalindrome(string str)
        {
            string revStr = new string(str.ToCharArray().Reverse().ToArray());
            string concat = str + "#" + revStr;
            int lps = ComputeLPSArray(concat);

            return str.Length - lps;
        }

        public static void MinimumInsertionsToMakeStringPalindromeDriver()
        {
            string str = "AACECAAAA";
            Console.WriteLine("Given string: " + str);
            int minInsertions = MinCharsToPalindrome(str);
            Console.WriteLine("Minimum insertions needed at start to make string palindrome: " + minInsertions);
        }
    }

    public class AnagramChecker_E_11
    {
        /*
         * ANAgram -  one string can be rearranged to form the other.
        To check if two strings are anagrams, we need to determine if one string can be rearranged to form the other.
        An anagram of a string is another string that contains the same characters, only the order of characters can be different.

        ### Key Steps to Check for Anagrams

        1. **Character Counting**: Use an array to count the occurrences of each character in both strings.
        2. **Comparison**: Compare the character counts of both strings.If they match for all characters, the strings are anagrams.

        ### Explanation:

        1. ** Character Counting**:
           - We assume the ASCII character set, so we create a count array of size 256 to store the count of each character.
           - For each character in `str1`, we increment its corresponding count in the count array.
           - For each character in `str2`, we decrement its corresponding count in the count array.

        2. ** Comparison**:
           - After processing both strings, if all values in the count array are 0, the two strings are anagrams.
           - If any value in the count array is not 0, the two strings are not anagrams.

        ### Complexity:

        - **Time Complexity**: (O(N)), where (N) is the length of the strings.This is because we iterate over both strings once.
        - ** Space Complexity**: (O(1)), as the count array size is fixed (256 for ASCII character set).

        This approach is efficient and straightforward, leveraging the character counting technique to determine if two strings are anagrams.

        */

        public static bool AreAnagrams(string str1, string str2)
        {
            // If the lengths are not the same, they cannot be anagrams
            if (str1.Length != str2.Length)
            {
                return false;
            }

            // Create a count array and initialize all values as 0
            int[] count = new int[256]; // Assuming ASCII character set

            // For each character in input strings, increment the count in the count array
            foreach (char c in str1)
            {
                count[c]++;
            }

            // For each character in the second string, decrement the count in the count array
            foreach (char c in str2)
            {
                count[c]--;
            }

            // Check if all counts are 0
            for (int i = 0; i < 256; i++)
            {
                if (count[i] != 0)
                {
                    return false; // If any count is not zero, str1 and str2 are not anagrams
                }
            }

            return true; // If all counts are zero, str1 and str2 are anagrams
        }

        public static void AnagramCheckerDriver()
        {
            string str1 = "listen";
            string str2 = "silent";
            Console.WriteLine($"Given string - string 1 : {str1}");
            Console.WriteLine($"Given string - string 2 : {str2}");
            if (AreAnagrams(str1, str2))
            {
                Console.WriteLine($"{str1} and {str2} are anagrams.");
            }
            else
            {
                Console.WriteLine($"{str1} and {str2} are not anagrams.");
            }
        }
    }

    public class CountAndSay_M_12
    {
        /*
        The "Count and Say" sequence is a sequence of numbers where each term is generated based on the previous term.
        The sequence starts with "1", and each subsequent term describes the count of each group of identical digits in the previous term.

        Here's a step-by-step explanation of how to generate the nth term of the "Count and Say" sequence:

        1.Start with "1".
        2.To generate each subsequent term, read the previous term and count the number of times each digit appears in groups,
        then say the digit and its count.
        3.Repeat this process until the nth term is generated.

        ### Example Walkthrough

        1. * *Term 1 * *: "1"
        2. * *Term 2 * *: The previous term is "1", which is read as "one 1" or "11".
        3. * *Term 3 * *: The previous term is "11", which is read as "two 1s" or "21".
        4. * *Term 4 * *: The previous term is "21", which is read as "one 2, then one 1" or "1211".
        5. * *Term 5 * *: The previous term is "1211", which is read as "one 1, one 2, then two 1s" or "111221".

        ### Explanation:

        1. * *GetNextTerm * *:
           -This method takes the current term as input and generates the next term.
           - It iterates through the current term, counting consecutive identical digits, 
        and appends the count followed by the digit to a StringBuilder.

        2. * *CountAndSaySequence * *:
           -This method generates the nth term of the "Count and Say" sequence.
           - It starts with the first term "1" and iteratively generates each subsequent term using the GetNextTerm method.

        3. * *Main Method * *:
           -The main method sets `n` to the desired term number and calls `CountAndSaySequence` to generate and print the nth term.

        ### Complexity:

        - **Time Complexity * *: (O(N cdot T)), where (N) is the term number and (T) is the average length of the terms in the sequence.
        The length of the terms grows exponentially, so this complexity is more of a theoretical upper bound.
        -**Space Complexity * *: (O(T)) for storing the current term and the next term.

        This approach ensures that we generate the "Count and Say" sequence efficiently, 
        using string manipulation techniques to build each term from the previous one.
        */


        public static string GetNextTerm(string term)
        {
            StringBuilder nextTerm = new StringBuilder();
            int count = 1;
            char currentChar = term[0];

            for (int i = 1; i < term.Length; i++)
            {
                if (term[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    nextTerm.Append(count.ToString());
                    nextTerm.Append(currentChar);
                    currentChar = term[i];
                    count = 1;
                }
            }

            nextTerm.Append(count.ToString());
            nextTerm.Append(currentChar);

            return nextTerm.ToString();
        }

        public static string CountAndSaySequence(int n)
        {
            if (n <= 0)
            {
                return "";
            }

            string result = "1";

            for (int i = 1; i < n; i++)
            {
                result = GetNextTerm(result);
            }

            return result;
        }

        public static void CountAndSayDriver()
        {
            int n = 5;
            string result = CountAndSaySequence(n);
            Console.WriteLine($"The {n}th term in the Count and Say sequence is: {result}");
        }
    }

    public class VersionComparer_M_13
    {
        /*
        Comparing version numbers involves treating each version number as a dot-separated list of integers and 
        comparing these integers from left to right.Here is how you can implement a function to compare two version numbers in C#.

        ### Steps to Compare Version Numbers

        1. **Split the version strings**: Split both version strings by the dot character to get individual components.
        2. **Compare each component**: Convert these components to integers and compare them one by one from left to right.
        3. **Handle different lengths**: If one version string has more components than the other, 
        consider the missing components as zeros for comparison.

        ### Explanation:

        1. ** Split the Version Strings**:
           - The version strings are split by the dot character to get an array of string components representing
        each level of the version number.

        2. ** Comparison Logic**:
           - The `for` loop iterates through the components of both version strings.
        It handles cases where one version string might have fewer components than the other by considering the missing components as zeros.
           - Each component is parsed as an integer for comparison.
        If the component from the first version string is greater than the corresponding component from the second version string,
        it returns `1`. If it's smaller, it returns `-1`.

        3. ** Handling Different Lengths**:
           - If the lengths of the split arrays are different, the loop ensures that the missing components are treated as zeros, 
        making the comparison accurate.

        4. **Main Method**:
           - The `Main` method demonstrates the comparison by calling the `CompareVersion` method with different version strings
        and printing the results.

        ### Complexity:

        - **Time Complexity**: (O(N + M)), where (N) and (M) are the lengths of the version strings.
        The split operation and the loop both run in linear time relative to the length of the version strings.
        - **Space Complexity**: (O(N + M)) for storing the split arrays of version components.

        This approach ensures that the version numbers are compared efficiently,
        correctly handling different version string formats and lengths.

        */

        public static int CompareVersion(string version1, string version2)
        {
            // Split version strings by '.'
            string[] levels1 = version1.Split('.');
            string[] levels2 = version2.Split('.');

            int length = Math.Max(levels1.Length, levels2.Length);

            for (int i = 0; i < length; i++)
            {
                // Parse the current level, defaulting to 0 if the level is missing
                int v1 = i < levels1.Length ? int.Parse(levels1[i]) : 0;
                int v2 = i < levels2.Length ? int.Parse(levels2[i]) : 0;

                // Compare the current levels
                if (v1 > v2)
                {
                    return 1;
                }
                else if (v1 < v2)
                {
                    return -1;
                }
            }

            // All levels are equal
            return 0;
        }

        public static void VersionComparerDriver()
        {
            string version1 = "1.01";
            string version2 = "1.001";
            int result = CompareVersion(version1, version2);
            Console.WriteLine($"Comparison result between {version1} and {version2}: {result}");

            version1 = "1.0";
            version2 = "1.0.0";
            result = CompareVersion(version1, version2);
            Console.WriteLine($"Comparison result between {version1} and {version2}: {result}");

            version1 = "0.1";
            version2 = "1.1";
            result = CompareVersion(version1, version2);
            Console.WriteLine($"Comparison result between {version1} and {version2}: {result}");
        }
    }

}
