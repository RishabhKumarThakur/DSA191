namespace Trie
{
    public class ImplementTrie1_H_1
    {
        /*
        ### Trie Data Structure Implementation

                A Trie(also known as a Prefix Tree) is a special type of tree used to store associative data structures.
        A common application of a Trie is storing a predictive text or autocomplete dictionary.

        ### Trie Operations

        1. ** Insert**: Add a word to the Trie.
        2. **Search**: Check if a word is in the Trie.
        3. **StartsWith**: Check if there is any word in the Trie that starts with a given prefix.


        ### Explanation of the Code

        1. ** TrieNode Class**:
           - `Children`: A dictionary that maps each character to its corresponding child node.
           - `IsEndOfWord`: A boolean flag that indicates whether the node represents the end of a word.

        2. **Trie Class**:
           - `root`: The root node of the Trie.
           - `Insert(string word)`: Adds a word to the Trie by iterating through each character and creating nodes as necessary.
        Sets the `IsEndOfWord` flag on the final node.
           - `Search(string word)`: Checks if a word exists in the Trie by traversing through the characters of the word.
           - `StartsWith(string prefix)`: Checks if any word in the Trie starts with the given prefix
        by traversing through the characters of the prefix.

        ### Time Complexity

        - **Insert**: O(m), where m is the length of the word.
        - **Search**: O(m), where m is the length of the word.
        - **StartsWith**: O(m), where m is the length of the prefix.

        ### Space Complexity

        - The space complexity of the Trie is O(N* M), where N is the number of words and M is the average length of the words,
        due to the storage of characters in the nodes.
        */

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
            public bool IsEndOfWord { get; set; }
        }


        private readonly TrieNode root;

        public ImplementTrie1_H_1()
        {
            root = new TrieNode();
        }

        // Insert a word into the trie.
        public void Insert(string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
        }

        // Search for a word in the trie.
        public bool Search(string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                node = node.Children[ch];
            }
            return node.IsEndOfWord;
        }

        // Check if there is any word in the trie that starts with the given prefix.
        public bool StartsWith(string prefix)
        {
            var node = root;
            foreach (var ch in prefix)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                node = node.Children[ch];
            }
            return true;
        }

        public static void Driver()
        {
            ImplementTrie1_H_1 trie = new ImplementTrie1_H_1();

            trie.Insert("apple");
            Console.WriteLine(trie.Search("apple"));   // Output: true
            Console.WriteLine(trie.Search("app"));     // Output: false
            Console.WriteLine(trie.StartsWith("app")); // Output: true

            trie.Insert("app");
            Console.WriteLine(trie.Search("app"));     // Output: true
        }
    }

    public class ImplementTrie2_H_2
    {
        /*
        ### Trie Data Structure Implementation (Prefix Tree)

        In this implementation, we will extend the Trie data structure to include additional methods for enhanced functionality.

        ### Trie Operations

        1. **Insert**: Add a word to the Trie.
        2. **Search**: Check if a word is in the Trie.
        3. **StartsWith**: Check if there is any word in the Trie that starts with a given prefix.
        4. **Delete**: Remove a word from the Trie.


        ### Explanation of the Code

        1. ** TrieNode Class**:
           - `Children`: A dictionary that maps each character to its corresponding child node.
           - `IsEndOfWord`: A boolean flag that indicates whether the node represents the end of a word.

        2. **Trie Class**:
           - `root`: The root node of the Trie.
           - `Insert(string word)`: Adds a word to the Trie by iterating through each character and creating nodes as necessary.
        Sets the `IsEndOfWord` flag on the final node.
           - `Search(string word)`: Checks if a word exists in the Trie by traversing through the characters of the word.
           - `StartsWith(string prefix)`: Checks if any word in the Trie starts with the given prefix by
        traversing through the characters of the prefix.
           - `Delete(string word)`: Removes a word from the Trie. The recursive `Delete` method handles the actual 
        deletion by ensuring nodes are only removed if they are not needed by other words.

        ### Time Complexity

        - **Insert**: O(m), where m is the length of the word.
        - **Search**: O(m), where m is the length of the word.
        - **StartsWith**: O(m), where m is the length of the prefix.
        - **Delete**: O(m), where m is the length of the word.

        ### Space Complexity

        - The space complexity of the Trie is O(N* M), where N is the number of words and M is the average length of the words,
        due to the storage of characters in the nodes.

        */

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
            public bool IsEndOfWord { get; set; }
        }


        private readonly TrieNode root;

        public ImplementTrie2_H_2()
        {
            root = new TrieNode();
        }

        // Insert a word into the trie.
        public void Insert(string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
        }

        // Search for a word in the trie.
        public bool Search(string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                node = node.Children[ch];
            }
            return node.IsEndOfWord;
        }

        // Check if there is any word in the trie that starts with the given prefix.
        public bool StartsWith(string prefix)
        {
            var node = root;
            foreach (var ch in prefix)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                node = node.Children[ch];
            }
            return true;
        }

        // Delete a word from the trie.
        public bool Delete(string word)
        {
            return Delete(root, word, 0);
        }

        private bool Delete(TrieNode current, string word, int index)
        {
            if (index == word.Length)
            {
                if (!current.IsEndOfWord)
                {
                    return false;
                }
                current.IsEndOfWord = false;
                return current.Children.Count == 0;
            }

            char ch = word[index];
            if (!current.Children.ContainsKey(ch))
            {
                return false;
            }

            var node = current.Children[ch];
            bool shouldDeleteCurrentNode = Delete(node, word, index + 1);

            if (shouldDeleteCurrentNode)
            {
                current.Children.Remove(ch);
                return current.Children.Count == 0 && !current.IsEndOfWord;
            }

            return false;
        }

        public static void Driver()
        {
            ImplementTrie2_H_2 trie = new ImplementTrie2_H_2();

            trie.Insert("apple");
            Console.WriteLine(trie.Search("apple"));   // Output: true
            Console.WriteLine(trie.Search("app"));     // Output: false
            Console.WriteLine(trie.StartsWith("app")); // Output: true

            trie.Insert("app");
            Console.WriteLine(trie.Search("app"));     // Output: true

            trie.Delete("apple");
            Console.WriteLine(trie.Search("apple"));   // Output: false
            Console.WriteLine(trie.Search("app"));     // Output: true
        }
    }

    public class LongestStringWithAllPrefixesUsingTrie_M_3
    {
        /*
         To find the longest string in a list that has all its prefixes present in the list,
        we can use a Trie(Prefix Tree) data structure.This problem can be efficiently solved by 
        leveraging the Trie to keep track of each string and its prefixes.

        Here's a step-by-step approach:

        1. **Insert all words into the Trie.**
        2. **For each word, check if all its prefixes exist in the Trie.**
        3. **Track the longest word that satisfies the condition.**

        ### Explanation

        1. ** TrieNode Class**:
           - Each node contains a dictionary `Children` mapping each character to its corresponding child node.
           - A boolean `IsEndOfWord` indicating if the node represents the end of a word.

        2. **Trie Class**:
           - `Insert(string word)`: Adds a word to the Trie.
           - `AllPrefixesExist(string word)`: Checks if all prefixes of a word exist in the Trie.

        3. **Solution Class**:
           - `LongestStringWithAllPrefixes(string[] words)`: This method finds the longest
        string with all its prefixes present in the list.
           - It first inserts all words into the Trie.
           - It then checks each word to see if all its prefixes exist.
           - It keeps track of the longest word that satisfies the condition.

        ### Time Complexity

        - **Insert**: O(m) per word, where m is the length of the word.
        - **AllPrefixesExist**: O(m) per word, where m is the length of the word.
        - Overall, the time complexity is O(N* m), where N is the number of words and m is the average length of the words.

        ### Space Complexity

        - The space complexity of the Trie is O(N* m), where N is the number of words and m is the average length of the words. 
        This is due to the storage of characters in the nodes.
        */

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
            public bool IsEndOfWord { get; set; } = false;
        }


        private TrieNode root;

        public LongestStringWithAllPrefixesUsingTrie_M_3()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
        }

        public bool AllPrefixesExist(string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                node = node.Children[ch];
                if (!node.IsEndOfWord)
                {
                    return false;
                }
            }
            return true;
        }

        public static string LongestStringWithAllPrefixes(string[] words)
        {
            LongestStringWithAllPrefixesUsingTrie_M_3 trie = new LongestStringWithAllPrefixesUsingTrie_M_3();
            foreach (var word in words)
            {
                trie.Insert(word);
            }

            string result = string.Empty;
            foreach (var word in words)
            {
                if (trie.AllPrefixesExist(word))
                {
                    if (word.Length > result.Length || (word.Length == result.Length && word.CompareTo(result) < 0))
                    {
                        result = word;
                    }
                }
            }

            return result;
        }

        public static void Driver()
        {
            string[] words = { "a", "banana", "app", "appl", "ap", "apply", "apple" };
            Console.WriteLine($"words : {string.Join(", ", words)}");
            Console.WriteLine($"Longest String with All Prefixes : {LongestStringWithAllPrefixes(words)}");  // Output: apple
        }
    }

    public class NumberOfDistinctSubstringsUsingTrie_H_4
    {
        /*
        To find the number of distinct substrings in a string using a Trie, we can follow this approach:

        1. Insert all possible substrings of the given string into a Trie.
        2. Traverse the Trie to count the number of distinct substrings.

        ### Explanation

        1. ** TrieNode Class**:
           - Each node contains a dictionary `Children` mapping each character to its corresponding child node.

        2. **Trie Class**:
           - `Insert(string word)`: Adds a substring to the Trie.
           - `CountDistinctSubstrings()`: Traverses the Trie to count the number of distinct substrings.
           - `CountNodes(TrieNode node)`: Recursively counts the nodes in the Trie, which represent the substrings.

        3. **Solution Class**:
           - `NumberOfDistinctSubstrings(string s)`: This method inserts all possible substrings of the given 
        string into the Trie and returns the count of distinct substrings.
           - It subtracts 1 from the total count to exclude the root node, which does not represent any substring.

        ### Example Walkthrough

        For the string "ababa":

        - Substrings: "ababa", "baba", "aba", "ba", "a"
        - Distinct substrings in the Trie: "a", "ab", "aba", "abab", "ababa", "b", "ba", "bab", "baba"

        ### Time Complexity

        - **Insertion**: O(N^2), where N is the length of the string. This is because we are inserting N substrings, 
        and each insertion takes O(N) in the worst case.
        - ** Counting Nodes**: O(N^2) because in the worst case, the Trie can have O(N^2) nodes.

        ### Space Complexity

        - The space complexity of the Trie is O(N^2) in the worst case, where N is the length of the string. 
        This is because each substring can potentially add a new path in the Trie.
        */

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        }


        private TrieNode root;

        public NumberOfDistinctSubstringsUsingTrie_H_4()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
        }

        public int CountDistinctSubstrings()
        {
            return CountNodes(root);
        }

        private int CountNodes(TrieNode node)
        {
            int count = 0;
            foreach (var child in node.Children.Values)
            {
                count += CountNodes(child);
            }
            return 1 + count; // Counting the current node
        }

        public static int NumberOfDistinctSubstrings(string s)
        {
            NumberOfDistinctSubstringsUsingTrie_H_4 trie = new NumberOfDistinctSubstringsUsingTrie_H_4();
            for (int i = 0; i < s.Length; i++)
            {
                trie.Insert(s.Substring(i));
            }
            return trie.CountDistinctSubstrings() - 1; // Subtract 1 to not count the root node
        }

        public static void Driver()
        {
            string s = "ababa";
            Console.WriteLine("Given string : " + s);
            Console.WriteLine($"Number of distinct substrings : {NumberOfDistinctSubstrings(s)}");  // Output: 9
        }
    }

    public class PowerSetUsingTrie_M_5_IMP
    {
        /*
        To generate the power set(all possible subsets) of a given set using a Trie, 
        we can follow a systematic approach:

        1. Insert all subsets of the given set into the Trie.
        2. Traverse the Trie to gather all the subsets.

        ### Explanation

        1. ** TrieNode Class**:
           - Each node contains a dictionary `Children` mapping each character to its corresponding child node.
           - `IsEndOfSubset` is a flag to mark the end of a subset.

        2. **Trie Class**:
           - `Insert(string subset)`: Adds a subset to the Trie.
           - `GetAllSubsets()`: Traverses the Trie to gather all subsets.
           - `GetAllSubsetsHelper(TrieNode node, string current, List<string> result)`:
        Helper function to recursively gather all subsets from the Trie.

        3. **Solution Class**:
           - `GeneratePowerSet(string input)`:
        This method generates all possible subsets of the input string and inserts them into the Trie.
        Then, it retrieves all subsets from the Trie.
           - It uses bit manipulation to generate all subsets.

        ### Example Walkthrough

        For the input string "abc":

        - Subsets: "", "a", "b", "c", "ab", "ac", "bc", "abc"
        - All these subsets are inserted into the Trie, and then they are retrieved in lexicographic order.

        ### Time Complexity

        - **Insertion**: O(2^N* N), where N is the length of the input string. 
        This is because we generate 2^N subsets and each subset takes O(N) time to insert.
        - ** Retrieving Subsets**: O(2^N* N) because in the worst case, 
        we have 2^N nodes to visit and each subset can take O(N) time to concatenate.

        ### Space Complexity

        - The space complexity of the Trie is O(2^N* N) in the worst case,
        where N is the length of the input string. 
        This is because each subset can potentially add a new path in the Trie.

        */

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
            public bool IsEndOfSubset { get; set; } = false;
        }

        private TrieNode root;

        public PowerSetUsingTrie_M_5_IMP()
        {
            root = new TrieNode();
        }

        public void Insert(string subset)
        {
            var node = root;
            foreach (var ch in subset)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfSubset = true;
        }

        public List<string> GetAllSubsets()
        {
            List<string> result = new List<string>();
            GetAllSubsetsHelper(root, "", result);
            return result;
        }

        private void GetAllSubsetsHelper(TrieNode node, string current, List<string> result)
        {
            if (node.IsEndOfSubset)
            {
                result.Add(current);
            }
            foreach (var kvp in node.Children)
            {
                GetAllSubsetsHelper(kvp.Value, current + kvp.Key, result);
            }
        }

        public static List<string> GeneratePowerSet(string input)
        {
            PowerSetUsingTrie_M_5_IMP trie = new PowerSetUsingTrie_M_5_IMP();
            int n = input.Length;

            // Insert all subsets
            for (int i = 0; i < (1 << n); i++)
            {
                string subset = "";
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        subset += input[j];
                    }
                }
                trie.Insert(subset);
            }

            // Get all subsets
            return trie.GetAllSubsets();
        }

        public static void Driver()
        {
            string input = "abc";
            Console.WriteLine("Given input :  " + input);
            List<string> powerSet = GeneratePowerSet(input);

            Console.WriteLine("Power Set:");
            foreach (var subset in powerSet)
            {
                Console.WriteLine($"'{subset}'");
            }
        }
    }

    #region XOR
    /*
        XOR stands for "exclusive or," a bitwise operation that takes two bits and returns 1 if the bits are different,
        and 0 if they are the same.It's a fundamental operation in computer science and digital electronics. 

        Here is how XOR works:

        - `0 XOR 0` = `0`
        - `1 XOR 1` = `0`
        - `0 XOR 1` = `1`
        - `1 XOR 0` = `1`

        ### Properties of XOR

        1. **Self-inverse**: `a XOR a = 0` for any bit `a`. 
        This property can be useful for various algorithms, such as finding missing numbers in a sequence.
        2. **Commutative**: `a XOR b = b XOR a`
        3. **Associative**: `(a XOR b) XOR c = a XOR(b XOR c)`
        4. ** Identity**: `a XOR 0 = a`

    */
    #endregion

    public class MaximumXOROfTwoNumbersInArrayUsingTrie_M_6
    {
        /*
        To solve the problem of finding the maximum XOR of two numbers in an array,
        we can use a Trie-based approach.
        This method leverages the properties of binary representations of numbers to efficiently find the maximum XOR value.

        ### Trie Data Structure for Maximum XOR

        1. **Insert numbers into the Trie**:
        Insert each number in the array into the Trie by considering each bit of the number
        (from the most significant bit to the least significant bit).

        2. ** Query for the maximum XOR**:
        For each number, traverse the Trie to find the number which, when XOR'd with the current number,
        gives the maximum value. The idea is to try to match opposite bits as we traverse the Trie to maximize the XOR result.

        ### Explanation

        1. ** TrieNode Class**:
           - Represents each node in the Trie, with an array `Children` of size 2 to store the child nodes for bit 0 and bit 1.

        2. ** Trie Class**:
           - `Insert(int num)`: Inserts a number into the Trie by examining each bit from the most significant to the least significant.
           - `GetMaxXOR(int num)`: Computes the maximum XOR value for a given number by traversing the Trie and attempting to match opposite bits.

        3. **Solution Class**:
           - `FindMaximumXOR(int[] nums)`: Main method to find the maximum XOR value in the array.
        It inserts each number into the Trie and then computes the maximum XOR for each number.

        ### Example Walkthrough

        For the input array `[3, 10, 5, 25, 2, 8]`:

        - The Trie is built by inserting each number in its binary form.
        - For each number, we traverse the Trie to find the number that gives the maximum XOR with the current number.
        - The maximum XOR value is found to be 28, which is the result of XOR'ing 5 and 25.

        ### Time Complexity

        - **Insertion**: O(N* 32) = O(N), where N is the number of elements in the array and 32 is the number of bits in an integer.
        - **Query for max XOR**: O(N* 32) = O(N), for each number in the array.

        ### Space Complexity

        - The space complexity of the Trie is O(N* 32) = O(N), 
        where N is the number of elements in the array and 32 is the number of bits in an integer.
        This is because each number can potentially add up to 32 nodes in the Trie.
        */

        public class TrieNode
        {
            public TrieNode[] Children { get; set; } = new TrieNode[2];
        }

        private TrieNode root;

        public MaximumXOROfTwoNumbersInArrayUsingTrie_M_6()
        {
            root = new TrieNode();
        }

        public void Insert(int num)
        {
            TrieNode node = root;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;
                if (node.Children[bit] == null)
                {
                    node.Children[bit] = new TrieNode();
                }
                node = node.Children[bit];
            }
        }

        public int GetMaxXOR(int num)
        {
            TrieNode node = root;
            int maxXOR = 0;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;
                int oppositeBit = bit == 1 ? 0 : 1;
                if (node.Children[oppositeBit] != null)
                {
                    maxXOR = (maxXOR << 1) | 1;
                    node = node.Children[oppositeBit];
                }
                else
                {
                    maxXOR = (maxXOR << 1);
                    node = node.Children[bit];
                }
            }
            return maxXOR;
        }

        public static int FindMaximumXOR(int[] nums)
        {
            MaximumXOROfTwoNumbersInArrayUsingTrie_M_6 trie = new MaximumXOROfTwoNumbersInArrayUsingTrie_M_6();
            foreach (int num in nums)
            {
                trie.Insert(num);
            }

            int maxResult = 0;
            foreach (int num in nums)
            {
                maxResult = Math.Max(maxResult, trie.GetMaxXOR(num));
            }

            return maxResult;
        }

        public static void Driver()
        {
            int[] nums = { 3, 10, 5, 25, 2, 8 };
            Console.WriteLine($"Given numbers: {string.Join(", ", nums)}");
            int maxXOR = FindMaximumXOR(nums);
            Console.WriteLine($"Maximum XOR is: {maxXOR}");
        }
    }

    public class MaximumXORWithAnElementFromArrayUsingTrie_H_7
    {
        /*
        To solve the problem of finding the maximum XOR of each element in one array with any element in another array,
        and ensuring the XOR value is the largest, we can use a Trie-based approach.
        The Trie will be used to store the binary representation of the numbers from one array and 
        then query for the maximum XOR value for each element in the other array.

        ### Implementation Steps

        1. **Insert numbers from the first array into the Trie**:
        Insert each number from the first array into the Trie by considering each bit of the number 
        (from the most significant bit to the least significant bit).

        2. ** Query for the maximum XOR**: For each number in the second array, 
        traverse the Trie to find the number in the first array which, 
        when XOR'd with the current number, gives the maximum value.

        ### Explanation

        1. ** TrieNode Class**:
           - Represents each node in the Trie with an array `Children` of size 2 to store the child nodes for bit 0 and bit 1.

        2. ** Trie Class**:
           - `Insert(int num)`:
        Inserts a number into the Trie by examining each bit from the most significant to the least significant.
           - `GetMaxXOR(int num)`:
        Computes the maximum XOR value for a given number by traversing the Trie and attempting to match opposite bits.

        3. **Solution Class**:
           - `FindMaximumXOR(int[] arr1, int[] arr2)`: 
        Main method to find the maximum XOR values for each number in the second array.
        It inserts each number from the first array into the Trie and then computes the maximum XOR for each number in the second array.
           - `Main` method demonstrates the usage by providing two arrays and printing the maximum XOR values.

        ### Example Walkthrough

        For the input arrays:
        - `arr1 = [3, 10, 5, 25, 2, 8]`
        - `arr2 = [10, 7, 6, 15]`

        The program will:
        1. Build a Trie using the numbers in `arr1`.
        2. For each number in `arr2`, it will query the Trie to find the maximum XOR value.
        3. Print the results: `Maximum XORs are: 18, 29, 31, 18`.

        ### Time Complexity

        - ** Insertion into Trie**: O(M* 32) = O(M), 
        where M is the number of elements in `arr1` and 32 is the number of bits in an integer.
        - **Query for max XOR**: O(N* 32) = O(N), where N is the number of elements in `arr2`.

        ### Space Complexity

        - The space complexity of the Trie is O(M* 32) = O(M),
        where M is the number of elements in `arr1` and 32 is the number of bits in an integer.
        This is because each number can potentially add up to 32 nodes in the Trie.
        */

        public class TrieNode
        {
            public TrieNode[] Children { get; set; } = new TrieNode[2];
        }

        private TrieNode root;

        public MaximumXORWithAnElementFromArrayUsingTrie_H_7()
        {
            root = new TrieNode();
        }

        public void Insert(int num)
        {
            TrieNode node = root;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;
                if (node.Children[bit] == null)
                {
                    node.Children[bit] = new TrieNode();
                }
                node = node.Children[bit];
            }
        }

        public int GetMaxXOR(int num)
        {
            TrieNode node = root;
            int maxXOR = 0;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;
                int oppositeBit = bit == 1 ? 0 : 1;
                if (node.Children[oppositeBit] != null)
                {
                    maxXOR = (maxXOR << 1) | 1;
                    node = node.Children[oppositeBit];
                }
                else
                {
                    maxXOR = (maxXOR << 1);
                    node = node.Children[bit];
                }
            }
            return maxXOR;
        }

        public static int[] FindMaximumXOR(int[] arr1, int[] arr2)
        {
            MaximumXORWithAnElementFromArrayUsingTrie_H_7 trie = new MaximumXORWithAnElementFromArrayUsingTrie_H_7();
            foreach (int num in arr1)
            {
                trie.Insert(num);
            }

            int[] result = new int[arr2.Length];
            for (int i = 0; i < arr2.Length; i++)
            {
                result[i] = trie.GetMaxXOR(arr2[i]);
            }

            return result;
        }

        public static void Driver()
        {
            int[] arr1 = { 3, 10, 5, 25, 2, 8 };
            Console.WriteLine("Given array 1: " + string.Join(", ", arr1));

            int[] arr2 = { 10, 7, 6, 15 };
            Console.WriteLine("Given array 2: " + string.Join(", ", arr2));

            int[] maxXORs = FindMaximumXOR(arr1, arr2);
            Console.WriteLine("Maximum XORs are: " + string.Join(", ", maxXORs));
        }
    }

}
