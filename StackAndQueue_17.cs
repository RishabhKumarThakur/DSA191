using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Net.NetworkInformation;
using static GreedyAlgorithm.FractionalKnapsack_M_4;
using System.Buffers.Text;
using System.Reflection.Metadata;
using System.Data;
using System.Threading;
using System.Timers;
using System.ComponentModel.DataAnnotations;

namespace StackAndQueue
{
    public class ImplementStackUsingArray_E_1
    {
        /*
        Implementing a stack using an array in C# involves creating a custom class that manages an array and provides standard stack operations like `Push`,
        `Pop`, `Peek`, and checking if the stack is empty. Here's a step-by-step guide and implementation:

        ### Step-by-Step Guide

        1. ** Initialize Array**: Create an array to store stack elements.
        2. ** Track Size**: Maintain a variable to keep track of the current size of the stack.
        3. ** Operations**:
           - `Push`: Add an element to the top of the stack.
           - `Pop`: Remove and return the top element of the stack.
           - `Peek`: Return the top element without removing it.
           - `IsEmpty`: Check if the stack is empty.


        ### Explanation

        1. ** Constructor**: Initializes the stack with a specified capacity and sets the initial size to 0.
        2. ** Push**: Adds an element to the stack.If the stack is full, it throws an exception.
        3. **Pop**: Removes and returns the top element of the stack.If the stack is empty, it throws an exception.
        4. **Peek**: Returns the top element without removing it.If the stack is empty, it throws an exception.
        5. **IsEmpty**: Checks if the stack is empty by comparing the size to 0.
        6. **IsFull**: Checks if the stack is full by comparing the size to the capacity.
        7. **Main Method**: Demonstrates usage by creating a stack, pushing elements, and popping elements while printing them.

        This implementation provides a clear and efficient way to use an array to manage a stack,
        ensuring O(1) time complexity for all primary stack operations(push, pop, and peek).

        */

        private int[] _elements;
        private int _size;
        private int _capacity;

        public ImplementStackUsingArray_E_1(int capacity)
        {
            _capacity = capacity;
            _elements = new int[_capacity];
            _size = 0;
        }

        // Push an element onto the stack
        public void Push(int item)
        {
            if (_size == _capacity)
            {
                throw new InvalidOperationException("Stack is full");
            }
            _elements[_size] = item;
            _size++;
        }

        // Pop an element from the stack
        public int Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            _size--;
            return _elements[_size];
        }

        // Peek at the top element of the stack
        public int Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return _elements[_size - 1];
        }

        // Check if the stack is empty
        public bool IsEmpty()
        {
            return _size == 0;
        }

        // Check if the stack is full
        public bool IsFull()
        {
            return _size == _capacity;
        }

        public static void ImplementStackUsingArrayDriver()
        {
            ImplementStackUsingArray_E_1 stack = new ImplementStackUsingArray_E_1(5);

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("Top element is: " + stack.Peek());

            Console.WriteLine("Stack elements:");
            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }

            // Uncomment the following line to see the exception for empty stack
            // Console.WriteLine(stack.Pop());
        }
    }

    public class ImplementQueueUsingArray_E_2
    {
        /*
        Implementing a queue using an array in C# involves creating a custom class that manages an array and provides standard queue operations
        like `Enqueue`, `Dequeue`, `Peek`, and checking if the queue is empty. Here is a detailed explanation and implementation:

        ### Step-by-Step Guide

        1. ** Initialize Array**: Create an array to store queue elements.
        2. ** Track Indices**: Maintain two indices, `front` and `rear`, to keep track of the front and rear of the queue.
        3. ** Operations**:
           - `Enqueue`: Add an element to the rear of the queue.
           - `Dequeue`: Remove and return the front element of the queue.
           - `Peek`: Return the front element without removing it.
           - `IsEmpty`: Check if the queue is empty.
           - `IsFull`: Check if the queue is full.


        ### Explanation

        1. ** Constructor**: Initializes the queue with a specified capacity, sets the initial size to 0, and sets the `front` and `rear` indices appropriately.
        2. **Enqueue**: Adds an element to the rear of the queue.If the queue is full,
        it throws an exception. The rear index is incremented in a circular manner using modulo arithmetic.
        3. ** Dequeue**: Removes and returns the front element of the queue.If the queue is empty, it throws an exception.
        The front index is incremented in a circular manner using modulo arithmetic.
        4. ** Peek**: Returns the front element without removing it.If the queue is empty, it throws an exception.
        5. **IsEmpty**: Checks if the queue is empty by comparing the size to 0.
        6. **IsFull**: Checks if the queue is full by comparing the size to the capacity.
        7. **Main Method**: Demonstrates usage by creating a queue, enqueuing elements, and dequeuing elements while printing them.

        This implementation provides an efficient way to use an array to manage a queue, 
        ensuring O(1) time complexity for all primary queue operations(enqueue, dequeue, and peek).
        */

        private int[] _elements;
        private int _front;
        private int _rear;
        private int _size;
        private int _capacity;

        public ImplementQueueUsingArray_E_2(int capacity)
        {
            _capacity = capacity;
            _elements = new int[_capacity];
            _front = 0;
            _rear = -1;
            _size = 0;
        }

        // Enqueue an element into the queue
        public void Enqueue(int item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Queue is full");
            }
            _rear = (_rear + 1) % _capacity;
            _elements[_rear] = item;
            _size++;
        }

        // Dequeue an element from the queue
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            int item = _elements[_front];
            _front = (_front + 1) % _capacity;
            _size--;
            return item;
        }

        // Peek at the front element of the queue
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return _elements[_front];
        }

        // Check if the queue is empty
        public bool IsEmpty()
        {
            return _size == 0;
        }

        // Check if the queue is full
        public bool IsFull()
        {
            return _size == _capacity;
        }

        public static void ImplementQueueUsingArrayDriver()
        {
            ImplementQueueUsingArray_E_2 queue = new ImplementQueueUsingArray_E_2(5);

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Console.WriteLine("Front element is: " + queue.Peek());

            Console.WriteLine("Queue elements:");
            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }

            // Uncomment the following line to see the exception for empty queue
            // Console.WriteLine(queue.Dequeue());
        }
    }

    public class ImplementStackUsingSingleQueue_M_3
    {
        /*
        Implementing a stack using a single queue involves manipulating the order of elements to simulate the Last In First Out(LIFO) behavior of a stack.
        The basic idea is to use a single queue and for each `push` operation, rearrange the queue so that the newly added element is moved to the front,
        thus simulating stack behavior.

        ### Detailed Explanation

        1. **Queue**: Use a single queue to store the elements.
        2. **Push**: Add the element to the queue and then rotate the queue elements such that the new element is at the front.
        3. ** Pop**: Remove the element from the front of the queue.
        4. ** Top**: Peek at the element at the front of the queue.
        5. **Empty**: Check if the queue is empty.


        ### Explanation

        1. ** Constructor**: Initializes the stack by creating an empty queue.
        2. **Push**: Adds the new element to the queue and then rotates the elements in the queue such that the new element is moved to the front.
        This is achieved by dequeuing all elements one by one and enqueuing them back after the new element.
        3. ** Pop**: Removes and returns the front element of the queue.
        4. ** Top**: Returns the front element of the queue without removing it.
        5. **IsEmpty**: Checks if the queue is empty by checking its count.
        6. **Main Method**: Demonstrates the usage by creating a stack, pushing elements, and popping elements while printing them.

        ### Complexity

        - **Time Complexity**:
          - `Push`: O(n), where n is the number of elements in the queue (due to the rotation of the queue).
          - `Pop`: O(1).
          - `Top`: O(1).
          - `IsEmpty`: O(1).

        - ** Space Complexity**: O(n), where n is the number of elements in the queue.

        This implementation efficiently uses a single queue to simulate stack operations, adhering to the LIFO principle.
        */
        private Queue<int> queue;

        public ImplementStackUsingSingleQueue_M_3()
        {
            queue = new Queue<int>();
        }

        // Push an element onto the stack
        public void Push(int x)
        {
            int size = queue.Count;
            queue.Enqueue(x);

            // Rotate the queue to move the new element to the front
            for (int i = 0; i < size; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        // Pop the top element from the stack
        public int Pop()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return queue.Dequeue();
        }

        // Get the top element of the stack
        public int Top()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return queue.Peek();
        }

        // Check if the stack is empty
        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public static void ImplementStackUsingSingleQueueDriver()
        {
            ImplementStackUsingSingleQueue_M_3 stack = new ImplementStackUsingSingleQueue_M_3();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Top element is: " + stack.Top()); // Output: 3

            Console.WriteLine("Stack elements:");
            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop()); // Output: 3 2 1
            }

            // Uncomment the following line to see the exception for empty stack
            // Console.WriteLine(stack.Pop());
        }
    }

    public class ImplementQueueUsingStacks_M_4
    {
        /*
        To implement a queue using two stacks with O(1) amortized time complexity for enqueue and dequeue operations, we can use the following approach:

        ### Detailed Explanation

        1. * *Two Stacks * *: Use two stacks, `stack1` and `stack2`.
        2. * *Enqueue(Push operation for the queue) **: Always push the new element onto `stack1`.
        3. * *Dequeue(Pop operation for the queue) **:
           -If `stack2` is empty, transfer all elements from `stack1` to `stack2`. 
        This reverses the order of elements, making the oldest element(the front of the queue) accessible from the top of `stack2`.
           -Pop the top element from `stack2`.

        ### Amortized Time Complexity

        -**Enqueue * *: O(1) – The push operation on `stack1` is always O(1).
        - **Dequeue * *: O(1) amortized – Although transferring elements from `stack1` to `stack2` can take O(n) in the worst case,
        each element is moved at most once from `stack1` to `stack2`, making the amortized time complexity O(1) over a sequence of operations.


        ### Explanation

        1. * *Constructor * *: Initializes the queue by creating two empty stacks, `stack1` and `stack2`.
        2. * *Enqueue * *: Adds the new element to `stack1`.
        3. * *Dequeue * *: 
           -If `stack2` is empty, it transfers all elements from `stack1` to `stack2`. This makes the oldest element available at the top of `stack2`.
           -Removes and returns the top element from `stack2`.
        4. * *Peek * *: Returns the front element of the queue without removing it.It ensures that `stack2` is populated by transferring elements from `stack1` if necessary.
        5. * *IsEmpty * *: Checks if both stacks are empty.
        6. * *Main Method * *: Demonstrates the usage by creating a queue, enqueuing elements, and dequeuing elements while printing them.

        This implementation ensures that both enqueue and dequeue operations are efficient, with the amortized time complexity for dequeue being O(1).
        */

        private Stack<int> stack1;
        private Stack<int> stack2;

        public ImplementQueueUsingStacks_M_4()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        // Enqueue an element into the queue
        public void Enqueue(int x)
        {
            stack1.Push(x);
        }

        // Dequeue an element from the queue
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Pop();
        }

        // Peek at the front element of the queue
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Peek();
        }

        // Check if the queue is empty
        public bool IsEmpty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }

        public static void ImplementQueueUsingStacksDriver()
        {
            ImplementQueueUsingStacks_M_4 queue = new ImplementQueueUsingStacks_M_4();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("Front element is: " + queue.Peek()); // Output: 1

            Console.WriteLine("Queue elements:");
            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue()); // Output: 1 2 3
            }

            // Uncomment the following line to see the exception for empty queue
            // Console.WriteLine(queue.Dequeue());
        }
    }

    public class BalancedParentheses_M_5
    {
        /*
        To check for balanced parentheses in an expression, we can use a stack data structure.The idea is to iterate through the characters of the string and use the stack to keep track of opening parentheses.When a closing parenthesis is encountered, it should match the top element of the stack.If it does, we pop the stack; otherwise, the parentheses are not balanced.

        ### Detailed Explanation

        1. ** Initialization**: Create an empty stack.
        2. **Iterate through characters**: For each character in the string:
           - If the character is an opening parenthesis (`(`, `{`, `[`), push it onto the stack.
           -If the character is a closing parenthesis(`)`, `}`, `]`):
             - Check if the stack is empty.If it is, the parentheses are not balanced.
             - Otherwise, pop the stack and check if the popped element is the corresponding opening parenthesis.If not, the parentheses are not balanced.
        3. **Final Check**: After processing all characters, check if the stack is empty.If it is, the parentheses are balanced; otherwise, they are not.

        ### Explanation

        1. ** IsBalanced Method**:
           - Creates an empty stack to store opening parentheses.
           - Iterates through each character in the input string.
           - Pushes opening parentheses onto the stack.
           - For closing parentheses, it checks if the stack is empty.If not, it pops the stack and checks if the popped element matches the current closing parenthesis.
           - Returns `true` if the stack is empty at the end of the iteration, indicating all parentheses were matched and balanced.Otherwise, it returns `false`.

        2. **IsMatchingPair Method**:
           - A helper function that checks if the given pair of opening and closing parentheses match.

        3. **Main Method**:
           - Demonstrates the usage by checking several example expressions for balanced parentheses and prints the results.

        This solution efficiently checks for balanced parentheses using a stack, ensuring O(n) time complexity where n is the length of the input string.
        The space complexity is O(n) in the worst case, as all opening parentheses might be pushed onto the stack before any closing parenthesis is encountered.
        */

        public static bool IsBalanced(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in expression)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char top = stack.Pop();
                    if (!IsMatchingPair(top, ch))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        private static bool IsMatchingPair(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }

        public static void BalancedParenthesesDriver()
        {
            string expression1 = "{[()]}";
            string expression2 = "{[(])}";
            string expression3 = "{[()}";

            Console.WriteLine($"Is the expression '{expression1}' balanced? {IsBalanced(expression1)}");
            Console.WriteLine($"Is the expression '{expression2}' balanced? {IsBalanced(expression2)}");
            Console.WriteLine($"Is the expression '{expression3}' balanced? {IsBalanced(expression3)}");
        }
    }

    public class NextGreaterElement_E_6
    {
        /*
        The "Next Greater Element" problem can be efficiently solved using a stack.
        The idea is to traverse the array from right to left and use a stack to keep track of elements
        for which the next greater element is not yet found.By maintaining a stack of indices,
        we can find the next greater element for each array element in linear time.

        ### Detailed Explanation

        1. **Initialization**: Create an empty stack and an array to store the result.
        2. **Traverse the Array from Right to Left**:
           - For each element, pop elements from the stack until you find an element greater than the current element or the stack becomes empty.
           - If the stack is empty, there is no greater element on the right, so store -1 in the result.
           - If the stack is not empty, the top element of the stack is the next greater element for the current element.
           - Push the current element onto the stack.
        3. **Result Array**: After processing all elements, the result array will contain the next greater elements for each position in the original array.


        ### Explanation

        1. ** FindNextGreaterElements Method**:
           - Initializes a result array to store the next greater elements.
           - Uses a stack to keep track of elements for which the next greater element is not yet found.
           - Traverses the input array from right to left:
             - Pops elements from the stack until a greater element is found or the stack becomes empty.
             - If the stack is empty, stores -1 in the result (no greater element exists).
             - Otherwise, stores the top element of the stack in the result(the next greater element).
             - Pushes the current element onto the stack.
        2. ** Main Method**:
           - Demonstrates the usage by finding the next greater elements for a sample array and printing the results.

        ### Complexity

        - ** Time Complexity**: O(n), where n is the length of the input array.Each element is pushed and popped from the stack at most once.
        - **Space Complexity**: O(n) for the stack and the result array.

        This solution efficiently finds the next greater element for each element in the array using a stack, ensuring linear time complexity.
        */

        public static int[] FindNextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= nums[i])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    result[i] = -1;
                }
                else
                {
                    result[i] = stack.Peek();
                }

                stack.Push(nums[i]);
            }

            return result;
        }

        public static void NextGreaterElementDriver()
        {
            int[] nums = { 4, 5, 2, 25 };
            Console.WriteLine($"Input numbers: {string.Join(", ", nums)}");
            int[] result = FindNextGreaterElements(nums);

            Console.WriteLine("Next greater elements:");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"Element {nums[i]} -> Next Greater {result[i]}");
            }
        }
    }

    public class SortStack_E_7
    {
        /*
        Sorting a stack can be done using another auxiliary stack.
        The idea is to use a temporary stack to sort the elements in the original stack.We pop elements from the original 
        stack one by one and insert them into the temporary stack in sorted order. 
        To insert an element in the sorted order, we may need to move elements from the temporary stack back to the original stack temporarily.

        ### Detailed Explanation

        1. **Initialization**: Create an empty auxiliary stack.
        2. **Iterate through the elements of the original stack**:
           - Pop the top element from the original stack.
           - While the auxiliary stack is not empty and the top of the auxiliary stack is greater than the popped element,
        move elements from the auxiliary stack back to the original stack.
           - Push the popped element into the auxiliary stack.
        3. **Transfer the sorted elements back to the original stack**: After the original stack is empty,
        the auxiliary stack will contain the elements in sorted order. Transfer them back to the original stack.


        ### Explanation

        1. ** Sort Method**:
           - Uses a temporary stack `auxStack` to help sort the elements in the original stack.
           - Pops elements from the original stack and, while doing so, compares them with the elements in `auxStack`.
           - Moves elements from `auxStack` back to the original stack if they are greater than the current element.
           - Pushes the current element into `auxStack`.
           - After all elements are processed, transfers the elements from `auxStack` back to the original stack.

        2. ** PrintStack Method**:
           - Prints the elements of the stack.

        3. **Main Method**:
           - Demonstrates the usage by creating a stack, printing the original stack, sorting it, and then printing the sorted stack.

        ### Complexity

        - **Time Complexity**: O(n²), where n is the number of elements in the stack.Each element is processed and compared with other elements,
        potentially leading to quadratic time complexity.
        - **Space Complexity**: O(n), where n is the number of elements in the stack.
        An auxiliary stack is used to hold the elements during the sorting process.

        This solution provides a clear and efficient way to sort a stack using another stack, ensuring that the stack is sorted in ascending order.
        */

        // Function to sort a stack
        public static void Sort(Stack<int> stack)
        {
            Stack<int> auxStack = new Stack<int>();

            // Process each element in the original stack
            while (stack.Count > 0)
            {
                int temp = stack.Pop();

                // Move elements from auxStack back to stack if they are greater than temp
                while (auxStack.Count > 0 && auxStack.Peek() > temp)
                {
                    stack.Push(auxStack.Pop());
                }

                // Push temp into auxStack
                auxStack.Push(temp);
            }

            // Transfer the sorted elements back to the original stack
            while (auxStack.Count > 0)
            {
                stack.Push(auxStack.Pop());
            }
        }

        // Function to print elements of the stack
        public static void PrintStack(Stack<int> stack)
        {
            foreach (int item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void SortStackDriver()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(34);
            stack.Push(3);
            stack.Push(31);
            stack.Push(98);
            stack.Push(92);
            stack.Push(23);

            Console.WriteLine("Original Stack:");
            PrintStack(stack);

            Sort(stack);

            Console.WriteLine("Sorted Stack:");
            PrintStack(stack);
        }
    }

    public class NextSmallerElement_E_8
    {
        /*
        To solve the "Next Smaller Element" problem efficiently, we can use a stack.
        The idea is similar to the "Next Greater Element" problem, but we look for the next smaller element instead.
        We iterate through the array from right to left and use a stack to keep track of elements
        for which the next smaller element is not yet found.

        ### Detailed Explanation

        1. **Initialization**: Create an empty stack and an array to store the results.
        2. **Traverse the Array from Right to Left**:
           - For each element, pop elements from the stack until you find
        an element smaller than the current element or the stack becomes empty.
           - If the stack is empty, there is no smaller element on the right, so store -1 in the result.
           - If the stack is not empty, the top element of the stack is the next smaller element for the current element.
           - Push the current element onto the stack.
        3. **Result Array**: After processing all elements, the result array will contain the next smaller elements
        for each position in the original array.

        
        ### Explanation

        1. ** FindNextSmallerElements Method**:
           - Initializes a result array to store the next smaller elements.
           - Uses a stack to keep track of elements for which the next smaller element is not yet found.
           - Traverses the input array from right to left:
             - Pops elements from the stack until a smaller element is found or the stack becomes empty.
             - If the stack is empty, stores -1 in the result (no smaller element exists).
             - Otherwise, stores the top element of the stack in the result(the next smaller element).
             - Pushes the current element onto the stack.
        2. ** Main Method**:
           - Demonstrates the usage by finding the next smaller elements for a sample array and printing the results.

        ### Complexity

        - ** Time Complexity**: O(n), where n is the length of the input array.
        Each element is pushed and popped from the stack at most once.
        - **Space Complexity**: O(n) for the stack and the result array.

        This solution efficiently finds the next smaller element for each element in the array using a stack, 
        ensuring linear time complexity.

        */

        public static int[] FindNextSmallerElements(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() >= nums[i])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    result[i] = -1;
                }
                else
                {
                    result[i] = stack.Peek();
                }

                stack.Push(nums[i]);
            }

            return result;
        }

        public static void NextSmallerElementDriver()
        {
            int[] nums = { 4, 8, 5, 2, 25 };
            Console.WriteLine($"Numbers : {string.Join(", ", nums)}");
            int[] result = FindNextSmallerElements(nums);

            Console.WriteLine("Next smaller elements:");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"Element {nums[i]} -> Next Smaller {result[i]}");
            }
        }
    }

    public class LRUCache_H_9_IMP
    {
        /*
        The Least Recently Used(LRU) cache is a data structure that supports two main operations: `get` and `put`. 
        The `get` operation retrieves a value from the cache, while the `put` operation adds a value to the cache.
        If the cache reaches its capacity, it should remove the least recently used item before inserting a new item.

        To implement an LRU cache efficiently, we need to achieve O(1) time complexity for both operations.
        This can be accomplished using a combination of a doubly linked list and a hash map.

        - **Hash Map**: The hash map stores the keys and their corresponding nodes in the doubly linked list.
        - **Doubly Linked List**: The doubly linked list maintains the order of elements with the 
        most recently used elements near the head and the least recently used elements near the tail.

        ### Detailed Explanation

        1. **Node Class**: Represents an individual element in the doubly linked list,
        with pointers to the previous and next nodes, along with the key and value.
        2. **Doubly Linked List**: Supports operations to add nodes to the front,
        remove nodes, and move nodes to the front.
        3. **LRUCache Class**: Manages the cache operations (`get` and `put`)
        and maintains the doubly linked list and hash map.

        
        ### Explanation

        1. ** Node Class**: Represents each element in the doubly linked list.
        It contains the key, value, and pointers to the previous and next nodes.
        2. **LRUCache Class**:
           - **Constructor**: Initializes the cache with a given capacity, sets up the hash map,
        and creates dummy head and tail nodes for the doubly linked list.
           - **Get Method**: Retrieves a value from the cache. If the key is found,
        the corresponding node is moved to the head of the list (marking it as recently used).
           - ** Put Method**: Inserts a key-value pair into the cache.If the key already exists,
        its value is updated, and the node is moved to the head of the list.
        If the key does not exist and the cache is at capacity, the least recently used item(the tail) is removed.
        A new node is then added to the head of the list.
           - **AddToHead Method**: Adds a node to the front of the doubly linked list.
           - **RemoveNode Method**: Removes a node from the doubly linked list.
           - **MoveToHead Method**: Moves a node to the front of the doubly linked list.
           - **PopTail Method**: Removes and returns the node at the tail of the doubly linked list (the least recently used item).

        ### Complexity

        - ** Time Complexity**: O(1) for both `get` and `put` operations because all operations on the hash map 
        and doubly linked list are O(1).
        - ** Space Complexity**: O(capacity), where capacity is the maximum number of items the cache can hold.
        This accounts for the space used by the hash map and the doubly linked list.

        This solution ensures that the LRU cache operates efficiently with constant time complexity for both 
        `get` and `put` operations.
        */


        private class Node
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly int capacity;
        private readonly Dictionary<int, Node> cache;
        private readonly Node head;
        private readonly Node tail;

        public LRUCache_H_9_IMP(int capacity)
        {
            this.capacity = capacity;
            cache = new Dictionary<int, Node>(capacity);
            head = new Node(0, 0); // Dummy head
            tail = new Node(0, 0); // Dummy tail
            head.Next = tail;
            tail.Prev = head;
        }

        public int Get(int key)
        {
            if (cache.TryGetValue(key, out Node node))
            {
                MoveToHead(node);
                return node.Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (cache.TryGetValue(key, out Node node))
            {
                node.Value = value;
                MoveToHead(node);
            }
            else
            {
                if (cache.Count >= capacity)
                {
                    Node tailPrev = PopTail();
                    cache.Remove(tailPrev.Key);
                }
                Node newNode = new Node(key, value);
                cache[key] = newNode;
                AddToHead(newNode);
            }
        }

        private void AddToHead(Node node)
        {
            node.Prev = head;
            node.Next = head.Next;
            head.Next.Prev = node;
            head.Next = node;
        }

        private void RemoveNode(Node node)
        {
            Node prev = node.Prev;
            Node next = node.Next;
            prev.Next = next;
            next.Prev = prev;
        }

        private void MoveToHead(Node node)
        {
            RemoveNode(node);
            AddToHead(node);
        }

        private Node PopTail()
        {
            Node res = tail.Prev;
            RemoveNode(res);
            return res;
        }

        public static void LRUCacheDriver()
        {
            LRUCache_H_9_IMP cache = new LRUCache_H_9_IMP(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1)); // returns 1
            cache.Put(3, 3); // evicts key 2
            Console.WriteLine(cache.Get(2)); // returns -1 (not found)
            cache.Put(4, 4); // evicts key 1
            Console.WriteLine(cache.Get(1)); // returns -1 (not found)
            Console.WriteLine(cache.Get(3)); // returns 3
            Console.WriteLine(cache.Get(4)); // returns 4
        }
    }

    public class LFUCache_H_10
    {
        /*
        An LFU(Least Frequently Used) cache evicts the least frequently used items first.
        To implement an LFU cache efficiently, we need to maintain access frequency counts and ensure that both `get` and `put` operations are performed in O(1) time complexity.
        This can be achieved using a combination of a hash map and a double-linked list for each frequency count.

        ### Detailed Explanation

        1. ** Node Class**: Represents an individual element in the cache, containing key, 
        value, frequency count, and pointers to the previous and next nodes.
        2. ** Doubly Linked List**: Used to maintain nodes with the same frequency count.
        Nodes are added and removed from these lists.
        3. **LFUCache Class**: Manages the cache operations (`get` and `put`), 
        maintains the doubly linked lists for frequency counts, and updates the minimum frequency count.


        ### Explanation

        1. ** Node Class**:
           - Represents each element in the cache with a key, value, and frequency count.
           - Contains pointers to the previous and next nodes in the doubly linked list.

        2. **DoublyLinkedList Class**:
           - Manages a list of nodes with the same frequency count.
           - Supports operations to add, remove, and check if the list is empty.
           - The `RemoveLast` method removes and returns the least recently used node (the node at the tail).

        3. ** LFUCache Class**:
           - ** Constructor**: Initializes the cache with a given capacity, 
        sets up the hash map, and initializes the minimum frequency count.
           - **Get Method**: Retrieves a value from the cache. 
        If the key is found, the corresponding node's frequency is updated.
           - **Put Method**: Inserts a key-value pair into the cache.
        If the key already exists, its value is updated, and the node's frequency is updated.
        If the key does not exist and the cache is at capacity, the least frequently used item (managed by the frequency list) is removed. A new node is then added to the frequency list.
           - **UpdateFrequency Method**: Updates the frequency count of a node and moves it to the appropriate frequency list.

        ### Complexity

        - **Time Complexity**: O(1) for both `get` and `put` operations because all operations on the hash map 
        and doubly linked list are O(1).
        - ** Space Complexity**: O(capacity), where capacity is the maximum number of items the cache can hold.
        This accounts for the space used by the hash map and the doubly linked lists.

        This solution ensures that the LFU cache operates efficiently with constant time complexity for both `get` and `put` operations.
        */


        private class Node
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public int Frequency { get; set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
                Frequency = 1;
            }
        }

        private class DoublyLinkedList
        {
            private Node head;
            private Node tail;

            public DoublyLinkedList()
            {
                head = new Node(0, 0);
                tail = new Node(0, 0);
                head.Next = tail;
                tail.Prev = head;
            }

            public void AddNode(Node node)
            {
                Node next = head.Next;
                node.Next = next;
                node.Prev = head;
                head.Next = node;
                next.Prev = node;
            }

            public void RemoveNode(Node node)
            {
                Node prev = node.Prev;
                Node next = node.Next;
                prev.Next = next;
                next.Prev = prev;
            }

            public Node RemoveLast()
            {
                if (tail.Prev == head) return null;
                Node last = tail.Prev;
                RemoveNode(last);
                return last;
            }

            public bool IsEmpty()
            {
                return head.Next == tail;
            }
        }

        private readonly int capacity;
        private int minFrequency;
        private readonly Dictionary<int, Node> cache;
        private readonly Dictionary<int, DoublyLinkedList> frequencyList;

        public LFUCache_H_10(int capacity)
        {
            this.capacity = capacity;
            cache = new Dictionary<int, Node>(capacity);
            frequencyList = new Dictionary<int, DoublyLinkedList>();
            minFrequency = 0;
        }

        public int Get(int key)
        {
            if (!cache.ContainsKey(key)) return -1;

            Node node = cache[key];
            UpdateFrequency(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (capacity == 0) return;

            if (cache.ContainsKey(key))
            {
                Node node = cache[key];
                node.Value = value;
                UpdateFrequency(node);
            }
            else
            {
                if (cache.Count >= capacity)
                {
                    DoublyLinkedList minFreqList = frequencyList[minFrequency];
                    Node toRemove = minFreqList.RemoveLast();
                    cache.Remove(toRemove.Key);
                }

                Node newNode = new Node(key, value);
                cache[key] = newNode;
                minFrequency = 1;
                if (!frequencyList.ContainsKey(minFrequency))
                {
                    frequencyList[minFrequency] = new DoublyLinkedList();
                }
                frequencyList[minFrequency].AddNode(newNode);
            }
        }

        private void UpdateFrequency(Node node)
        {
            int freq = node.Frequency;
            frequencyList[freq].RemoveNode(node);
            if (frequencyList[freq].IsEmpty() && minFrequency == freq)
            {
                minFrequency++;
            }

            node.Frequency++;
            if (!frequencyList.ContainsKey(node.Frequency))
            {
                frequencyList[node.Frequency] = new DoublyLinkedList();
            }
            frequencyList[node.Frequency].AddNode(node);
        }

        public static void LFUCacheDriver()
        {
            LFUCache_H_10 cache = new LFUCache_H_10(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1)); // returns 1
            cache.Put(3, 3); // evicts key 2
            Console.WriteLine(cache.Get(2)); // returns -1 (not found)
            Console.WriteLine(cache.Get(3)); // returns 3
            cache.Put(4, 4); // evicts key 1
            Console.WriteLine(cache.Get(1)); // returns -1 (not found)
            Console.WriteLine(cache.Get(3)); // returns 3
            Console.WriteLine(cache.Get(4)); // returns 4
        }
    }

    public class LargestRectangleInHistogram_M_11
    {
        /*
        To solve the problem of finding the largest rectangle in a histogram efficiently, we can use a stack-based approach.
        This method allows us to maintain a stack of indices of the histogram bars and ensures that each bar is processed only once, 
        resulting in an overall time complexity of O(n).

        // start histogram defination
        A histogram is a graphical representation of the distribution of a dataset. 
        It is used to visualize the frequency of data points within specified ranges, called bins. 
        Here are the key components of a histogram:

        Imagine you have the following data set representing the test scores of a class:

        ```
        45, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100
        ```

        1. **Determine the number of bins**: Let's say you decide to use 5 bins.

        2. **Calculate the bin width**: The range of the data (100 - 45 = 55) divided by the number of bins (5) gives a bin width of 11.

        3. **Create bins**: The bins might be 45-55, 56-66, 67-77, 78-88, and 89-100.

        4. **Count frequencies**: Count how many data points fall into each bin:
           - 45-55: 2 scores (45, 55)
           - 56-66: 1 score (60)
           - 67-77: 2 scores (65, 70)
           - 78-88: 3 scores (75, 80, 85)
           - 89-100: 3 scores (90, 95, 100)

        5. **Draw the histogram**: Draw a bar for each bin with a height corresponding to the frequency of data points in that bin.
        //end histogram defination

        ### Detailed Explanation

        1. **Initialization**: Create an empty stack and a variable to store the maximum area.
        2. **Traverse the Histogram**:
           - For each bar, if the stack is empty or the current bar is higher than the bar at the stack's top,
        push the current index onto the stack.
           - If the current bar is lower than the bar at the stack's top,
        calculate the area for the rectangle with the height of the bar at the stack's top. 
        Keep removing bars from the stack until you find a bar that is less than or equal to the current bar.
           - Calculate the area with the popped bar as the smallest (or minimum height) bar, 
        update the maximum area if needed, and push the current index onto the stack.
        3. **Final Pass**: After the traversal, there may be remaining bars in the stack.
        Process each bar to calculate the area and update the maximum area.


        ### Explanation

        1. ** Initialization**:
           - `stack` is used to store the indices of the histogram bars.
           - `maxArea` keeps track of the maximum rectangular area found.

        2. **First Loop** (Processing each bar in the histogram):
           - If the stack is empty or the current bar is taller than the bar at the stack's top, the index is pushed onto the stack.
           - If the current bar is shorter, calculate the area of rectangles with the bar at the top of the stack as the smallest height:
             - Pop the index from the stack.
             - The height of the rectangle is the height of the popped bar.
             - The width of the rectangle is the difference between the current index and the index of the new top of the stack minus one.
             - Update `maxArea` with the area of this rectangle if it is larger than the current `maxArea`.

        3. **Second Loop** (Processing remaining bars in the stack):
           - After the first loop, process the remaining bars in the stack similarly to calculate and update the area for each rectangle.

        ### Complexity

        - **Time Complexity**: O(n), where n is the number of bars in the histogram. 
        Each bar is pushed and popped from the stack at most once.
        - **Space Complexity**: O(n), where n is the number of bars in the histogram. 
        This is for the stack used to store the indices of the bars.

        This solution ensures that the largest rectangle area in the histogram is found efficiently using a stack-based approach.
        */

        public static int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] > heights[i])
                {
                    int height = heights[stack.Pop()];
                    int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? n : n - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }

            return maxArea;
        }

        public static void LargestRectangleInHistogramDriver()
        {
            int[] heights = { 2, 1, 5, 6, 2, 3 };
            Console.WriteLine($"Heights: {string.Join(", ", heights)}");
            Console.WriteLine("Largest Rectangle Area: " + LargestRectangleArea(heights));
        }
    }

    public class SlidingWindowMaximum_H_12
    {
        /*
        To solve the problem of finding the maximum value in each sliding window of size (k ) in an array efficiently,
        we can use a deque(double-ended queue) data structure.
        This approach allows us to maintain a sliding window of indices and ensures that each element is processed only once,
        resulting in an overall time complexity of (O(n) ).

        ### Detailed Explanation

        1. ** Initialization**: Create an empty deque and a list to store the maximum values of each sliding window.
        2. **Traverse the Array**:
           - For each element in the array:
             - Remove elements from the front of the deque if they are out of the current window.
             - Remove elements from the back of the deque while the elements
        in the deque are less than the current element (maintaining the deque in decreasing order).
             - Add the current element's index to the deque.
             - If the current index is greater than or equal to (k-1 ),
        append the element at the front of the deque to the result list(as it is the maximum element of the current window).
        3. ** Return the Result**: After the traversal, the result list will contain the maximum values of each sliding window.

        
        ### Explanation

        1. ** Initialization**:
           - `deque` is used to store the indices of the elements in the current sliding window.
           - `result` is an array to store the maximum values for each sliding window.

        2. **First Loop** (Processing each element in the array):
           - ** Remove Out-of-Window Elements**: If the element at the front of the deque is out of the current window
        (i.e., its index is less than or equal to (i - k )), remove it from the deque.
           - ** Maintain Decreasing Order**: Remove elements from the back of the deque while they are less than or
        equal to the current element to maintain the decreasing order in the deque.
           - **Add Current Element**: Add the current element's index to the deque.
           - **Store Maximum**: If the current index is greater than or equal to (k-1 ),
        append the element at the front of the deque to the result array(as it is the maximum element of the current window).

        3. ** Return the Result**: After processing all elements, the result array contains the maximum values for each sliding window.

        ### Complexity

        - ** Time Complexity**: (O(n) ), where (n ) is the number of elements in the array.
        Each element is added and removed from the deque at most once.
        - **Space Complexity**: (O(k) ), where (k ) is the size of the sliding window.
        This is for the deque used to store the indices of the elements.

        This solution ensures that the maximum values of each sliding window are found efficiently using a deque.
        */

        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0)
                return new int[0];

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            LinkedList<int> deque = new LinkedList<int>();

            for (int i = 0; i < n; i++)
            {
                // Remove elements out of the current window
                if (deque.Count > 0 && deque.First.Value <= i - k)
                    deque.RemoveFirst();

                // Remove elements smaller than the current element
                while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
                    deque.RemoveLast();

                // Add current element at the end of the deque
                deque.AddLast(i);

                // The element at the front of the deque is the largest element of the window
                if (i >= k - 1)
                    result[i - k + 1] = nums[deque.First.Value];
            }

            return result;
        }

        public static void SlidingWindowMaximumDriver()
        {
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;
            Console.WriteLine("Numbers: " + string.Join(", ", nums));
            Console.WriteLine($"K value: {k}");
            int[] maxValues = MaxSlidingWindow(nums, k);
            Console.WriteLine("Max Sliding Window: " + string.Join(", ", maxValues));
        }
    }

    public class ImplementMinStack_M_13
    {
        /*
        A Min Stack is a special type of stack that, in addition to the usual stack operations(`push`, `pop`, `top`),
        supports a `getMin` operation that returns the minimum element in the stack in constant time.

        To implement this efficiently, we can use two stacks:
        1. The main stack to store the elements.
        2. The auxiliary stack to keep track of the minimum elements.

        ### Detailed Explanation

        1. **Initialization**: Create two stacks: one for storing all the elements and another for tracking the minimum values.
        2. **Push Operation**: Push the element onto the main stack.
        If the auxiliary stack is empty or the new element is smaller than or equal to the current minimum(top of the auxiliary stack), 
        push the new element onto the auxiliary stack.
        3. ** Pop Operation**: Pop the element from the main stack.
        If the popped element is the same as the top of the auxiliary stack, also pop from the auxiliary stack.
        4. ** Top Operation**: Return the top element of the main stack.
        5. **GetMin Operation**: Return the top element of the auxiliary stack, which is the current minimum.


        ### Explanation

        1. ** Initialization**:
           - `mainStack`: Stores all the elements pushed onto the stack.
           - `minStack`: Stores the minimum elements, ensuring the top element is always the minimum of the current stack.

        2. **Push Operation**:
           - Push the value onto `mainStack`.
           - If `minStack` is empty or the value is less than or equal to the current minimum (top of `minStack`),
        push the value onto `minStack`.

        3. ** Pop Operation**:
           - Pop the value from `mainStack`.
           - If the popped value is the same as the top of `minStack`, pop from `minStack` as well.

        4. ** Top Operation**:
           - Return the top element of `mainStack`.

        5. ** GetMin Operation**:
           - Return the top element of `minStack`, which is the current minimum.

        ### Complexity

        - ** Time Complexity**: O(1) for all operations(`push`, `pop`, `top`, `getMin`).
        - ** Space Complexity**: O(n) for storing elements in `mainStack` and `minStack`, 
        where `n` is the number of elements in the stack.

        This implementation ensures that all stack operations, including retrieving the minimum element,
        are performed efficiently in constant time.
        */

        private Stack<int> mainStack;
        private Stack<int> minStack;

        /** initialize your data structure here. */
        public ImplementMinStack_M_13()
        {
            mainStack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            mainStack.Push(val);
            if (minStack.Count == 0 || val <= minStack.Peek())
            {
                minStack.Push(val);
            }
        }

        public void Pop()
        {
            if (mainStack.Peek() == minStack.Peek())
            {
                minStack.Pop();
            }
            mainStack.Pop();
        }

        public int Top()
        {
            return mainStack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }

        public static void ImplementMinStackDriver()
        {
            ImplementMinStack_M_13 minStack = new ImplementMinStack_M_13();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Console.WriteLine(minStack.GetMin()); // return -3
            minStack.Pop();
            Console.WriteLine(minStack.Top());    // return 0
            Console.WriteLine(minStack.GetMin()); // return -2
        }
    }

    public class RottenOranges_M_14
    {
        /*
        To solve the Rotten Oranges problem using the Breadth-First Search(BFS) algorithm, 
        we need to find the minimum time required to rot all fresh oranges in a grid.The grid contains three types of values:
        - 0: Empty cell.
        - 1: Fresh orange.
        - 2: Rotten orange.

        Rotten oranges can rot adjacent (up, down, left, right) fresh oranges in one time unit.
        We'll use BFS because it naturally handles the shortest path problem in an unweighted grid.

        ### Detailed Explanation

        1. **Initialization**:
           - Create a queue to store the positions of all initially rotten oranges along with the initial time (0).
           - Keep track of the number of fresh oranges.
           - Define directions for movement (up, down, left, right).

        2. **BFS Traversal**:
           - For each rotten orange, rot its adjacent fresh oranges and add them to the queue with the incremented time.
           - Keep track of the maximum time during this process.
           - Decrease the count of fresh oranges for each rotted orange.

        3. **Result**:
           - If there are no fresh oranges left, return the maximum time.
           - If there are still fresh oranges, return -1 indicating that not all oranges can be rotted.


        ### Explanation

        1. ** Initialization**:
           - `queue`: A queue to store the positions and the time of initially rotten oranges.
           - `freshOranges`: Counter for fresh oranges.
           - `rowDirections` and `colDirections`: Arrays to move in 4 possible directions.

        2. **BFS Traversal**:
           - Dequeue a position from the queue, check its adjacent cells.
           - If an adjacent cell contains a fresh orange, rot it,
        decrement the count of fresh oranges, and enqueue the new rotten orange with incremented time.
           - Track the maximum time required.

        3. ** Result**:
           - If all fresh oranges are rotted, return the maximum time.
           - If there are still fresh oranges left, return -1.

        ### Complexity

        - ** Time Complexity**: (O(n times m)), where (n) is the number of rows and (m) is the number of columns in the grid.
        Each cell is processed at most once.
        - **Space Complexity**: (O(n times m)) for the queue used in BFS, where (n) is the number of rows and (m) is the number of columns.

        This solution ensures an efficient way to determine the minimum time to rot all fresh oranges using BFS.
        */

        public class Position
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Time { get; set; }

            public Position(int row, int col, int time)
            {
                Row = row;
                Col = col;
                Time = time;
            }
        }

        public static int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return -1;

            int rows = grid.Length;
            int cols = grid[0].Length;
            Queue<Position> queue = new Queue<Position>();
            int freshOranges = 0;

            // Directions array for moving in 4 possible directions
            int[] rowDirections = { -1, 1, 0, 0 };
            int[] colDirections = { 0, 0, -1, 1 };

            // Initialize the queue with all initially rotten oranges and count fresh oranges
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        queue.Enqueue(new Position(r, c, 0));
                    }
                    else if (grid[r][c] == 1)
                    {
                        freshOranges += 1;
                    }
                }
            }

            int maxTime = 0;

            // BFS traversal
            while (queue.Count > 0)
            {
                Position pos = queue.Dequeue();
                int row = pos.Row;
                int col = pos.Col;
                int time = pos.Time;

                for (int d = 0; d < 4; d++)
                {
                    int newRow = row + rowDirections[d];
                    int newCol = col + colDirections[d];

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1)
                    {
                        grid[newRow][newCol] = 2; // Rot the fresh orange
                        freshOranges -= 1;
                        queue.Enqueue(new Position(newRow, newCol, time + 1));
                        maxTime = Math.Max(maxTime, time + 1);
                    }
                }
            }

            return freshOranges == 0 ? maxTime : -1;
        }

        public static void RottenOrangesDriver()
        {
            int[][] grid = new int[][]
            {
            new int[] {2, 1, 1},
            new int[] {1, 1, 0},
            new int[] {0, 1, 1}
            };

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    Console.Write(grid[i][j] + " ");
                }
                Console.WriteLine();
            }


            int result = OrangesRotting(grid);
            Console.WriteLine("Minimum time to rot all oranges: " + result);
        }
    }

    public class StockSpanProblem_M_15
    {
        /*
        The Stock Span Problem is a financial problem where we have a series of daily stock prices and
        we need to calculate the span of the stock’s price for all days.
        The span of the stock’s price on a given day is defined as the maximum number of consecutive days just before the given day,
        for which the price of the stock on the current day is less than or equal to its price on the given day.

        ### Explanation and Approach

        To solve this problem efficiently, we can use a stack to keep track of the indices of the days.
        The idea is to traverse the list of prices, and for each price,
        we determine the span by popping elements from the stack until we find a price greater than the current price.

        1. **Initialization**:
           - Create a stack to store the indices of the days.
           - Create an array to store the span values.

        2. **Processing Each Price**:
           - For each price, pop elements from the stack while the stack is not empty and
        the price at the top index of the stack is less than or equal to the current price.
           - If the stack is empty, it means the current price is greater than all previous prices,
        so the span is the current index plus one.
           - If the stack is not empty, the span is the difference between the current index and 
        the index of the top element of the stack.
           - Push the current index onto the stack.


        ### Explanation

        1. ** Initialization**:
           - `stack`: Used to store indices of the prices array.
           - `spans`: Array to store the span values for each day.

        2. **Processing Each Price**:
           - For each price, remove elements from the stack while the stack is not empty and
        the price at the top index of the stack is less than or equal to the current price.
           - Calculate the span for the current price:
             - If the stack is empty, the span is `i + 1` (i.e., the price is greater than all previous prices).
             - Otherwise, the span is `i - stack.Peek()` (i.e., the difference between the current index and the top index of the stack).
           - Push the current index onto the stack.

        ### Complexity

        - ** Time Complexity**: (O(n)), where (n) is the number of days.Each element is pushed and popped from the stack at most once.
        - **Space Complexity**: (O(n)) for the stack and the spans array.

        This solution efficiently calculates the span of stock prices using a stack to keep track of indices of days,
        ensuring that each price is processed in constant time.

        */

        public static int[] CalculateSpan(int[] prices)
        {
            int n = prices.Length;
            int[] spans = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                // Pop elements from the stack while stack is not empty and the current price is greater than or equal to the price at the top index of the stack
                while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
                {
                    stack.Pop();
                }

                // If stack is empty, then the current price is greater than all previous prices
                spans[i] = stack.Count == 0 ? i + 1 : i - stack.Peek();

                // Push the current index onto the stack
                stack.Push(i);
            }

            return spans;
        }

        public static void StockSpanProblemDriver()
        {
            int[] prices = { 100, 80, 60, 70, 60, 75, 85 };
            int[] spans = CalculateSpan(prices);

            Console.WriteLine("Stock Prices: " + string.Join(", ", prices));
            Console.WriteLine("Spans: " + string.Join(", ", spans));
        }
    }

    public class MaximumOfMinimumsOfEveryWindowSize_M_16
    {
        /*
        To solve the problem of finding the "maximum of minimums" of every possible window size in an array, 
        we can use a two-step approach involving:
        1. Preprocessing to compute the minimum element for each possible window size.
        2. Finding the maximum value from these computed minimums.

        ### Approach

        #### Step 1: Preprocessing Using Two Arrays

        We'll use two arrays:
        - `left`: To store the index of the nearest smaller element on the left for each element in the array.
        - `right`: To store the index of the nearest smaller element on the right for each element in the array.

        1. **Initialize Arrays**:
           - `left` array is initialized to store the nearest smaller element index on the left using a stack-based approach.
           - `right` array is initialized to store the nearest smaller element index on the right using a stack-based approach.

        2. **Calculate `left` Array**:
           - Traverse the array from left to right.
           - Use a stack to store indices of elements in a way that elements are in decreasing order.
           - For each element, pop elements from the stack until finding an element smaller than the current one.
           - The element at the top of the stack after this step is the index of the nearest smaller element on the left.

        3. **Calculate `right` Array**:
           - Traverse the array from right to left using a similar approach.
           - Use a stack to store indices of elements in a way that elements are in decreasing order.
           - For each element, pop elements from the stack until finding an element smaller than the current one.
           - The element at the top of the stack after this step is the index of the nearest smaller element on the right.

        #### Step 2: Calculate the Result

        - After computing the `left` and `right` arrays, iterate through them to calculate the size of the windows
        for which each element in the array is the minimum.
        - For each element, compute the window size as `right[i] - left[i] - 1`.
        - Track the maximum of these computed window sizes.


        ### Explanation

        1. ** CalculateLeft and CalculateRight Functions**:
           - `CalculateLeft`: Computes the `left` array where each element at index `i` contains the index
        of the nearest smaller element on the left.
           - `CalculateRight`: Computes the `right` array where each element at index `i` contains the index
        of the nearest smaller element on the right.

        2. ** MaxMinOfEveryWindowSize Function**:
           - Computes the `left` and `right` arrays using the functions `CalculateLeft` and `CalculateRight`.
           - Iterates through the array to calculate the size of windows where each element is the minimum.
           - Tracks the maximum of these computed window sizes using the `result` array.

        3. ** Main Function**:
           - Initializes an array `arr` with stock prices.
           - Calls `MaxMinOfEveryWindowSize` to compute and print the maximum of minimums of every window size.

        ### Complexity

        - **Time Complexity**: (O(n)) for each `CalculateLeft` and `CalculateRight` function,
        where (n) is the number of elements in the array.Overall time complexity is (O(n)).
        - ** Space Complexity**: (O(n)) for the `left`, `right`, and `result` arrays.

        This solution efficiently computes the maximum of minimums for every window size using
        a stack-based approach to find the nearest smaller elements on the left and right of each element in the array.

        */
        public static int[] CalculateLeft(int[] arr)
        {
            int n = arr.Length;
            int[] left = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }

                left[i] = (stack.Count == 0) ? -1 : stack.Peek();
                stack.Push(i);
            }

            return left;
        }

        public static int[] CalculateRight(int[] arr)
        {
            int n = arr.Length;
            int[] right = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }

                right[i] = (stack.Count == 0) ? n : stack.Peek();
                stack.Push(i);
            }

            return right;
        }

        public static int[] MaxMinOfEveryWindowSize(int[] arr)
        {
            int n = arr.Length;
            int[] left = CalculateLeft(arr);
            int[] right = CalculateRight(arr);
            int[] result = new int[n + 1]; // +1 because we need to consider all window sizes

            for (int i = 0; i < n; i++)
            {
                int windowSize = right[i] - left[i] - 1;
                result[windowSize] = Math.Max(result[windowSize], arr[i]);
            }

            // Fill in the missing gaps with the maximums found so far
            for (int i = n - 1; i >= 1; i--)
            {
                result[i] = Math.Max(result[i], result[i + 1]);
            }

            return result;
        }

        public static void MaximumOfMinimumsOfEveryWindowSizeDriver()
        {
            int[] arr = { 10, 20, 30, 50, 10, 70, 30 };
            Console.WriteLine("Array: " + string.Join(", ", arr));
            int[] maxMinWindows = MaxMinOfEveryWindowSize(arr);

            Console.WriteLine("Maximum of minimums of every window size:");
            for (int i = 1; i <= arr.Length; i++)
            {
                Console.WriteLine($"Window size {i}: {maxMinWindows[i]}");
            }
        }
    }

    public class CelebrityProblem_H_17
    {
        /*
        Sure, let's revisit the Celebrity Problem using a stack-based approach, 
        which can be useful for scenarios where we want to utilize a stack or queue in the algorithm.

        ### Approach Using Stack

        The idea is to use a stack to track potential candidates for the celebrity as we iterate through the list of people.
        Here's how the approach works:

        1. ** Identifying Potential Candidates**:
           - Push all people onto the stack initially.

        2. ** Pairwise Elimination**:
           - Pop the top two people(`p1` and `p2`) from the stack.
           - Check if `p1` knows `p2`. If true, `p1` cannot be the celebrity, so discard `p1`.
           - If `p1` does not know `p2`, then `p2` cannot be the celebrity, so discard `p2`.
           - Repeat until only one person remains on the stack, which could potentially be the celebrity.

        3. **Validation**:
           - Validate the remaining candidate by checking if they are known by everyone
        (if `p` knows all other people) and if they know no one(if no one knows `p` except possibly themselves).

        ### Explanation

        1. ** Knows Function**:
           - Replace `Knows` method with your actual implementation to check if person `a` knows person `b`.

        2. ** FindCelebrity Function**:
           - Initialize a stack to keep track of potential candidates.
           - Push all people onto the stack initially.
           - Use pairwise elimination with the stack to narrow down the potential celebrity.
           - Validate the remaining candidate to ensure they meet the criteria of a celebrity.

        3. **Main Function**:
           - Initialize `n` as the number of people.
           - Create an instance of `CelebrityProblem` and call `FindCelebrity` to find and print the index of the celebrity.

        ### Complexity

        - **Time Complexity**: (O(n)), where (n) is the number of people.Each person is pushed and popped from the stack at most once.
        - **Space Complexity**: (O(n)) for the stack used to store the people.

        This stack-based approach efficiently identifies the celebrity using pairwise elimination,
        ensuring optimal performance and leveraging stack operations for tracking potential candidates.
        Adjust the `Knows` method according to your actual implementation to fit the context where this problem is applied.

        */

        // Sample method to check if person a knows person b
        private bool Knows(int a, int b)
        {
            // Implementation of your knows function
            return true; // Replace with actual logic
        }

        public int FindCelebrity(int n)
        {
            Stack<int> stack = new Stack<int>();

            // Push all people onto the stack initially
            for (int i = 0; i < n; i++)
            {
                stack.Push(i);
            }

            // Pairwise elimination to find potential celebrity
            while (stack.Count > 1)
            {
                int p1 = stack.Pop();
                int p2 = stack.Pop();

                if (Knows(p1, p2))
                {
                    // p1 cannot be the celebrity, discard p1
                    stack.Push(p2);
                }
                else
                {
                    // p2 cannot be the celebrity, discard p2
                    stack.Push(p1);
                }
            }

            int candidate = stack.Pop();

            // Validate the candidate
            for (int i = 0; i < n; i++)
            {
                if (i != candidate && (Knows(candidate, i) || !Knows(i, candidate)))
                {
                    return -1; // No celebrity found
                }
            }

            return candidate;
        }

        public static void CelebrityProblemDriver()
        {
            int n = 7; // Example number of people
            Console.WriteLine("Number of people : " + n);
            CelebrityProblem_H_17 problem = new CelebrityProblem_H_17();
            int celebrity = problem.FindCelebrity(n);

            if (celebrity == -1)
            {
                Console.WriteLine("No celebrity found.");
            }
            else
            {
                Console.WriteLine("Celebrity found at index: " + celebrity);
            }
        }
    }

}
