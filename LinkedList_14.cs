using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Collections;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using System.Numerics;
using System.ComponentModel;
using System.Data;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace LinkedLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class ListNodeWithChild
    {
        public int val;
        public ListNodeWithChild next;
        public ListNodeWithChild child;

        public ListNodeWithChild(int val = 0, ListNodeWithChild next = null, ListNodeWithChild child = null)
        {
            this.val = val;
            this.next = next;
            this.child = child;
        }
    }

    public class ListNodeWithRandom
    {
        public int val;
        public ListNodeWithRandom next;
        public ListNodeWithRandom random;

        public ListNodeWithRandom(int val = 0, ListNodeWithRandom next = null, ListNodeWithRandom random = null)
        {
            this.val = val;
            this.next = next;
            this.random = random;
        }
    }

    public class ReverseLinkedList_E_1
    {

        /*
        Reversing a linked list is a common problem in data structures.The goal is to reverse the pointers of a singly linked list
        so that the last node becomes the first and vice versa.

        ### Approach

        To reverse a linked list, we need to change the next pointers of each node so that they point to the previous node instead of the next one.

        1. **Initialize Pointers**:
           - `prev`: Points to the previous node (initially `null`).
           - `current`: Points to the current node(initially the head of the list).
           - `next`: Will be used to store the next node temporarily.

        2. ** Iterate Through the List**:
           - For each node, save the next node.
           - Reverse the current node's pointer.
           - Move the `prev` and `current` pointers one step forward.

        3. **Update the Head**:
           - After the loop, `prev` will be pointing to the new head of the reversed list.



        1. ** Initialization**:
           - `prev` is initialized to `null` because the new tail of the reversed list should point to `null`.
           - `current` is initialized to the head of the list.

        2. ** Reversal Process**:
           - In each iteration of the loop:
             - `next` stores the next node of `current` to prevent losing the reference.
             - `current.next` is set to `prev` to reverse the link.
             - `prev` is moved to the current node.
             - `current` is moved to the next node stored in `next`.

        3. **Update the Head**:
           - After the loop completes, `prev` will be pointing to the new head of the reversed list.

        4. ** PrintList Method**:
           - This method is used to print the linked list for testing purposes.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - We iterate through each node of the list exactly once.

        **Space Complexity**: O(1) - No additional space is used apart from a few pointers.

        This approach efficiently reverses the linked list in linear time with constant space.
       */

        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;

            while (current != null)
            {
                ListNode next = current.next; // Store next node
                current.next = prev;          // Reverse the current node's pointer
                prev = current;               // Move prev to current node
                current = next;               // Move current to next node
            }

            return prev; // New head of the reversed list
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void ReverseListDriver()
        {
            // Creating a linked list 1 -> 2 -> 3 -> 4 -> 5 -> null
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            Console.WriteLine("Original List:");
            PrintList(head);

            ReverseLinkedList_E_1 reverseLinkedList = new ReverseLinkedList_E_1();
            ListNode reversedHead = reverseLinkedList.ReverseList(head);

            Console.WriteLine("Reversed List:");
            PrintList(reversedHead);
        }
    }

    public class FindMiddleElement_E_2
    {
        /*
         * 
        Finding the middle element in a singly linked list can be done efficiently using the two-pointer technique, often referred to as the "Tortoise and Hare" algorithm.This approach uses two pointers that move at different speeds through the list.

        ### Approach

        1. ** Two Pointers**:
           - ** Slow pointer** (`slow`): Moves one step at a time.
           - **Fast pointer** (`fast`): Moves two steps at a time.

        2. **Traverse the List**:
           - Both pointers start at the head of the list.
           - Move the `slow` pointer one step and the `fast` pointer two steps until the `fast` pointer reaches the end of the list.
           - When the `fast` pointer reaches the end, the `slow` pointer will be at the middle of the list.

        
        ### Explanation

        1. ** Initialization**:
           - `slow` and `fast` pointers are both initialized to the head of the list.

        2. **Traverse the List**:
           - In each iteration of the loop:
             - `slow` pointer moves one step (`slow = slow.next`).
             - `fast` pointer moves two steps(`fast = fast.next.next`).
           - The loop continues until the `fast` pointer reaches the end of the list or the node before the end(for lists with an even number of elements).

        3. ** Middle Element**:
           - When the loop ends, the `slow` pointer will be at the middle of the list.

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - We traverse each node of the list once.

        **Space Complexity**: O(1) - Only a few pointers are used, with no additional data structures.

        This approach efficiently finds the middle element in a singly linked list using constant space.
        */

        public ListNode FindMiddleElement(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void FindMiddleElementDriver()
        {
            // Creating a linked list 1 -> 2 -> 3 -> 4 -> 5 -> null
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            Console.WriteLine("Original List:");
            PrintList(head);

            FindMiddleElement_E_2 solution = new FindMiddleElement_E_2();
            ListNode middle = solution.FindMiddleElement(head);

            if (middle != null)
            {
                Console.WriteLine("Middle Element: " + middle.val); // Output: 3
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }

            // Test with an even number of elements
            head.next.next.next.next.next = new ListNode(6);

            Console.WriteLine("Original List:");
            PrintList(head);

            middle = solution.FindMiddleElement(head);

            if (middle != null)
            {
                Console.WriteLine("Middle Element: " + middle.val); // Output: 4
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }
    }

    public class MergeTwoLists_E_3
    {
        /*
        Merging two sorted linked lists involves creating a new linked list that contains all elements from both input lists in sorted order.
        This can be efficiently done using a two-pointer approach.

        ### Approach

        1. **Initialize Pointers**:
           - Use two pointers, `l1` and `l2`, to traverse the two input linked lists.
           - Use a dummy node to simplify the merging process, with a `current` pointer starting at the dummy node.

        2. **Merge the Lists**:
           - Compare the current nodes of both lists.
           - Append the smaller node to the merged list and move the corresponding pointer forward.
           - Repeat the process until one of the lists is exhausted.

        3. **Append Remaining Elements**:
           - If one list is exhausted before the other, append the remaining elements of the other list to the merged list.

        
        ### Explanation

        1. ** Initialization**:
           - A dummy node is used to simplify edge cases where the merged list is initially empty.
           - `current` pointer is used to build the merged list.

        2. **Merge Process**:
           - Compare the values of nodes pointed to by `l1` and `l2`.
           - Append the smaller node to the merged list and move the corresponding pointer.
           - Repeat until one of the lists is exhausted.

        3. **Append Remaining Elements**:
           - If one list is exhausted, append the remaining nodes of the other list to the merged list.

        4. **Return Result**:
           - The merged list starts from `dummy.next` since `dummy` is a placeholder.

        ### Time and Space Complexity

        **Time Complexity**: O(N + M) - Where \(N\) and \(M\) are the lengths of the two linked lists.Each node is processed once.

        **Space Complexity**: O(1) - Only a few additional pointers are used, with no extra data structures.

        This approach efficiently merges two sorted linked lists into a single sorted linked list.
        */

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }

            // Append the remaining elements
            if (l1 != null)
            {
                current.next = l1;
            }
            else if (l2 != null)
            {
                current.next = l2;
            }

            return dummy.next;
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void MergeTwoListsDriver()
        {
            // Creating first sorted linked list: 1 -> 2 -> 4 -> null
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            // Creating second sorted linked list: 1 -> 3 -> 4 -> null
            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            Console.WriteLine("First List:");
            PrintList(l1);

            Console.WriteLine("Second List:");
            PrintList(l2);

            MergeTwoLists_E_3 solution = new MergeTwoLists_E_3();
            ListNode mergedList = solution.MergeTwoLists(l1, l2);

            Console.WriteLine("Merged List:");
            PrintList(mergedList); // Output: 1 -> 1 -> 2 -> 3 -> 4 -> 4 -> null
        }
    }

    public class RemoveNthFromEnd_M_4
    {
        /*
        Removing the N-th node from the end of a linked list can be efficiently achieved using
        the two-pointer technique.This approach allows us to do it in a single pass through the list.

        ### Approach

        1. **Two Pointers**:
           - Use two pointers, `first` and `second`, initially pointing to the head of the list.
           - Move the `first` pointer `n` steps ahead.

        2. **Move Both Pointers**:
           - Move both `first` and `second` pointers one step at a time until `first` reaches the end of the list.
           - At this point, the `second` pointer will be just before the N-th node from the end.

        3. **Remove the Node**:
           - Change the `next` pointer of the `second` pointer to skip the N-th node.

        4. **Edge Cases**:
           - If the node to remove is the head, handle this case separately.
        ### Explanation

        1. ** Initialization**:
           - A dummy node is used to handle edge cases, such as removing the head node.
           - `first` and `second` pointers both start from the dummy node.

        2. **Advance the First Pointer**:
           - Move the `first` pointer `n` steps ahead. Since the dummy node is included, we move `n + 1` steps.

        3. **Move Both Pointers**:
           - Move both pointers one step at a time until the `first` pointer reaches the end of the list.
           - The `second` pointer will now be just before the node to remove.

        4. **Remove the Node**:
           - Change the `next` pointer of the `second` pointer to skip the node that needs to be removed.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - We traverse the list once, where \(N\) is the length of the list.

        ** Space Complexity**: O(1) - Only a few additional pointers are used, with no extra data structures.

        This approach efficiently removes the N-th node from the end of a linked list in a single pass.

        */

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0, head);
            ListNode first = dummy;
            ListNode second = dummy;

            // Move the first pointer n steps ahead
            for (int i = 0; i <= n; i++)
            {
                first = first.next;
            }

            // Move both pointers until the first pointer reaches the end
            while (first != null)
            {
                first = first.next;
                second = second.next;
            }

            // Remove the N-th node from the end
            second.next = second.next.next;

            return dummy.next;
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void RemoveNthFromEndDriver()
        {
            // Creating a linked list 1 -> 2 -> 3 -> 4 -> 5 -> null
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            Console.WriteLine("Original List:");
            PrintList(head);

            RemoveNthFromEnd_M_4 solution = new RemoveNthFromEnd_M_4();
            ListNode modifiedList = solution.RemoveNthFromEnd(head, 2);

            Console.WriteLine("Modified List after removing 2nd node from end:");
            PrintList(modifiedList); // Output: 1 -> 2 -> 3 -> 5 -> null

            // Creating a linked list 1 -> null
            ListNode head1 = new ListNode(1);

            Console.WriteLine("Original List:");
            PrintList(head1);

            RemoveNthFromEnd_M_4 solution1 = new RemoveNthFromEnd_M_4();
            ListNode modifiedList1 = solution1.RemoveNthFromEnd(head1, 1);

            Console.WriteLine("Modified List after removing 1st node from end:");
            PrintList(modifiedList1); // Output: null
        }
    }

    public class DeleteGivenNode_M_5
    {
        /*
            To delete a given node in a linked list in O(1) time, 
        you need to have direct access to the node that you want to delete.
        This approach does not work if the node to be deleted is the last node.
        The idea is to copy the data from the next node to the current node and then delete the next node.

        ### Approach

        1. **Copy the Data**:
            - Copy the data from the next node to the current node.

        2. **Delete the Next Node**:
            - Update the next pointer of the current node to skip the next node.


        ### Explanation

        1. ** Initialization**:
            - A `ListNode` class is defined with `val` and `next` properties.
            - The `DeleteNode` method accepts a node to delete.

        2. **Copy the Data**:
            - Check if the node is `null` or if it is the last node.
                If so, throw an exception because this method cannot handle these cases.
            - Copy the value of the next node to the current node.

        3. **Delete the Next Node**:
            - Update the `next` pointer of the current node to point to the node after the next node,
            effectively removing the next node from the list.

        4. **PrintList Method**:
            - This method is used to print the linked list for testing purposes.

        ### Time and Space Complexity

        **Time Complexity**: O(1) - The operation of copying the data and updating the pointer takes constant time.

        ** Space Complexity**: O(1) - No additional space is used apart from a few variables.

        This approach efficiently deletes a given node in O(1) time, 
        provided that the node is not the last node in the list.

        */

        public void DeleteNode(ListNode node)
        {
            if (node == null || node.next == null)
            {
                throw new InvalidOperationException("Cannot delete the last node or a null node using this method.");
            }

            node.val = node.next.val;
            node.next = node.next.next;
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void DeleteNodeDriver()
        {
            // Creating a linked list 4 -> 5 -> 1 -> 9 -> null
            ListNode head = new ListNode(4);
            head.next = new ListNode(5);
            head.next.next = new ListNode(1);
            head.next.next.next = new ListNode(9);

            Console.WriteLine("Original List:");
            PrintList(head);

            DeleteGivenNode_M_5 solution = new DeleteGivenNode_M_5();
            // Let's delete the node with value 5
            ListNode nodeToDelete = head.next; // Node with value 5
            solution.DeleteNode(nodeToDelete);

            Console.WriteLine("Modified List after deleting node with value 5:");
            PrintList(head); // Output should be: 4 -> 1 -> 9 -> null
        }
    }

    public class AddTwoNumbers_M_6
    {
        /*
        Adding two numbers represented as linked lists involves performing addition similar to how you would do it manually, digit by digit, but starting from the least significant digit(the head of the list). This requires considering carry over for digits that sum to more than 9.

        ### Approach

        1. ** Initialize Pointers and Variables**:
           - Use pointers to traverse the two linked lists.
           - Use a dummy node to simplify the construction of the result list.
           - Maintain a carry variable for sums that exceed 9.

        2. **Traverse and Add**:
           - Traverse both linked lists, adding corresponding digits along with any carry from the previous step.
           - Create a new node for the sum of each pair of nodes and append it to the result list.
           - Update the carry.

        3. **Handle Remaining Carry**:
           - If there is any carry left after the traversal, append a new node with that carry.


        ### Explanation

        1. ** Initialization**:
           - A dummy node is used to simplify the creation of the result list.
           - `current` pointer starts at the dummy node.
           - `carry` is initialized to 0.

        2. **Traverse and Add**:
           - In each iteration, add the values of the current nodes of `l1` and `l2` (if they exist) along with the carry.
           - Create a new node with the digit resulting from the sum modulo 10 and update the carry.
           - Move the `l1`, `l2`, and `current` pointers forward.

        3. **Handle Remaining Carry**:
           - After the loop, if there is any carry left, append a new node with that carry.

        4. **PrintList Method**:
           - This method is used to print the linked list for testing purposes.

        ### Time and Space Complexity

        **Time Complexity**: O(max(N, M)) - Where \(N\) and \(M\) are the lengths of the two linked lists.We traverse each list once.

        **Space Complexity**: O(max(N, M)) - The space used for the result list is proportional to the length of the longer input list plus one if there is a carry.

        This approach efficiently adds two numbers represented as linked lists, handling carries correctly and constructing the result in a straightforward manner.
        */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
            }

            return dummy.next;
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void AddTwoNumbersDriver()
        {
            // Creating first linked list: 2 -> 4 -> 3 -> null (represents the number 342)
            ListNode l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);

            // Creating second linked list: 5 -> 6 -> 4 -> null (represents the number 465)
            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);

            Console.WriteLine("First List:");
            PrintList(l1);

            Console.WriteLine("Second List:");
            PrintList(l2);

            AddTwoNumbers_M_6 solution = new AddTwoNumbers_M_6();
            ListNode result = solution.AddTwoNumbers(l1, l2);

            Console.WriteLine("Resultant List after addition:");
            PrintList(result); // Output should be: 7 -> 0 -> 8 -> null (represents the number 807)
        }
    }

    public class GetIntersectionNode_M_7
    {
        /*
        Finding the intersection of two singly linked lists involves determining the node at 
        which the two lists intersect.
        The intersection is defined by reference, not by value.
        This means that the two lists merge at some point and share all subsequent nodes.

        ### Approach

        1. **Calculate Lengths**:
           - Calculate the lengths of both linked lists.

        2. **Align Start Points**:
           - If one list is longer than the other, advance its head pointer by the difference in lengths to align the start points.

        3. **Traverse Together**:
           - Move both pointers one step at a time until they either meet at the intersection node or reach the end of the list (null).

        ### Explanation

        1. ** Calculate Lengths**:
           - `GetLength` method calculates the length of a linked list by traversing it.

        2. ** Align Start Points**:
           - If one list is longer than the other, advance its head pointer by the difference in lengths to make sure both pointers have the same number of steps to reach the end of their respective lists.

        3. **Traverse Together**:
           - Move both pointers one step at a time. When the pointers meet, that is the intersection node.
           - If the pointers reach the end (`null`) without meeting, there is no intersection.

        ### Time and Space Complexity

        **Time Complexity**: O(N + M) - Where (N) and (M) are the lengths of the two linked lists.We traverse each list at most twice.

        **Space Complexity**: O(1) - Only a few additional pointers are used, with no extra data structures.

        This approach efficiently finds the intersection node of two linked lists by aligning their start points and 
        then traversing them together.
        */
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }

            int lengthA = GetLength(headA);
            int lengthB = GetLength(headB);

            // Align start points
            while (lengthA > lengthB)
            {
                headA = headA.next;
                lengthA--;
            }
            while (lengthB > lengthA)
            {
                headB = headB.next;
                lengthB--;
            }

            // Traverse together
            while (headA != headB)
            {
                headA = headA.next;
                headB = headB.next;
            }

            return headA; // Or headB, they are the same at this point
        }

        private int GetLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.next;
            }
            return length;
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void GetIntersectionNodeDriver()
        {
            // Creating two intersecting linked lists
            // List A: 4 -> 1 -> 8 -> 4 -> 5 -> null
            // List B: 5 -> 6 -> 1 -> 8 -> 4 -> 5 -> null
            ListNode intersect = new ListNode(8, new ListNode(4, new ListNode(5)));

            ListNode headA = new ListNode(4, new ListNode(1, intersect));
            ListNode headB = new ListNode(5, new ListNode(6, new ListNode(1, intersect)));

            Console.WriteLine("List A:");
            PrintList(headA);

            Console.WriteLine("List B:");
            PrintList(headB);

            GetIntersectionNode_M_7 solution = new GetIntersectionNode_M_7();
            ListNode intersectionNode = solution.GetIntersectionNode(headA, headB);

            if (intersectionNode != null)
            {
                Console.WriteLine("Intersection at node with value: " + intersectionNode.val);
            }
            else
            {
                Console.WriteLine("No intersection.");
            }
        }
    }

    public class DetectCycleInLinkedList_M_08
    {
        /*
        Detecting a cycle in a linked list can be efficiently done using Floyd’s Tortoise and Hare algorithm.
        This algorithm uses two pointers moving at different speeds to detect if there is a cycle.

        ### Approach

        1. **Initialize Pointers**:
           - Use two pointers, `slow` and `fast`. Both start at the head of the list.

        2. **Move Pointers**:
           - Move `slow` one step at a time.
           - Move `fast` two steps at a time.

        3. **Cycle Detection**:
           - If `fast` and `slow` pointers meet at any point, there is a cycle.
           - If `fast` reaches the end of the list (`null`), there is no cycle.

        ### Explanation

        1. ** Initialization**:
           - Two pointers, `slow` and `fast`, both starting at the head of the list.

        2. **Move Pointers**:
           - `slow` moves one step at a time.
           - `fast` moves two steps at a time.

        3. **Cycle Detection**:
           - If there is a cycle, the `slow` and `fast` pointers will eventually meet inside the cycle.
           - If there is no cycle, the `fast` pointer will reach the end of the list (`null`).

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - In the worst case, where there is no cycle, 
        *each node is visited once by the `slow` pointer, and the `fast` pointer visits each node at most once.

        ** Space Complexity**: O(1) - Only a few additional pointers are used, with no extra data structures.

        This approach efficiently detects a cycle in a linked list using constant space and linear time.
        */

        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        public static void DetectCycleInLinkedListDriver()
        {
            // Creating a linked list with a cycle
            // 3 -> 2 -> 0 -> -4 -> 2 (cycle here)
            ListNode head = new ListNode(3);
            ListNode second = new ListNode(2);
            ListNode third = new ListNode(0);
            ListNode fourth = new ListNode(-4);

            head.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = second; // Creates a cycle

            DetectCycleInLinkedList_M_08 solution = new DetectCycleInLinkedList_M_08();
            bool hasCycle = solution.HasCycle(head);

            if (hasCycle)
            {
                Console.WriteLine("The linked list has a cycle.");
            }
            else
            {
                Console.WriteLine("The linked list does not have a cycle.");
            }
        }
    }

    public class ReverseKGroup_H_09
    {
        /*
        Reversing a linked list in groups of size (k ) involves reversing every (k ) nodes in the list.
        If the number of nodes is not a multiple of (k ), the remaining nodes at the end should remain in their original order.

        ### Approach

        1. ** Initialize Pointers**:
           - Use a dummy node to simplify operations on the head of the list.
           - Use pointers to keep track of the previous group's tail and the current group's head.

        2. **Traverse and Reverse**:
           - For each group of (k ) nodes:
             - Reverse the nodes in the group.
             - Connect the previous group's tail to the new head of the reversed group.
             - Move the pointers to process the next group.

        3. **Handle Remaining Nodes**:
           - If the number of remaining nodes is less than (k ), they remain in their original order.

        
        ### Explanation

        1. ** Initialization**:
           - A dummy node is used to handle edge cases and simplify list operations.
           - `prevGroupTail` keeps track of the tail of the previous reversed group.
           - `current` traverses the list to process each group.

        2. **Traverse and Reverse**:
           - For each group of (k ) nodes:
             - Identify the group head(`groupHead`) and group tail(`groupTail`).
             - If the number of nodes left is less than (k ), break out of the loop.
             - Reverse the group of nodes using the `Reverse` method.
             - Connect the previous group's tail to the new head of the reversed group.
             - Move the pointers to process the next group.

        3. **Reverse Method**:
           - Reverses nodes between `head` and `tail`.

        4. **PrintList Method**:
           - This method is used to print the linked list for testing purposes.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - Each node is processed and visited a constant number of times, where (N ) is the number of nodes in the list.

        **Space Complexity**: O(1) - No extra space proportional to the input size is used, just a few pointers.

        This approach efficiently reverses the nodes of a linked list in groups of size (k ),
        maintaining constant space complexity and linear time complexity.
        */

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k == 1)
            {
                return head;
            }

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode prevGroupTail = dummy;
            ListNode current = head;

            while (current != null)
            {
                ListNode groupHead = current;
                ListNode groupTail = current;
                for (int i = 1; i < k && groupTail != null; i++)
                {
                    groupTail = groupTail.next;
                }

                if (groupTail == null)
                {
                    break;
                }

                ListNode nextGroupHead = groupTail.next;
                Reverse(groupHead, groupTail);

                prevGroupTail.next = groupTail;
                groupHead.next = nextGroupHead;

                prevGroupTail = groupHead;
                current = nextGroupHead;
            }

            return dummy.next;
        }

        private void Reverse(ListNode head, ListNode tail)
        {
            ListNode prev = null;
            ListNode current = head;

            while (prev != tail)
            {
                ListNode next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void ReverseKGroupDriver()
        {
            // Creating a linked list: 1 -> 2 -> 3 -> 4 -> 5 -> null
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            Console.WriteLine("Original List:");
            PrintList(head);

            ReverseKGroup_H_09 solution = new ReverseKGroup_H_09();
            int k = 2;
            ListNode modifiedList = solution.ReverseKGroup(head, k);

            Console.WriteLine($"List after reversing in groups of {k}:");
            PrintList(modifiedList); // Output: 2 -> 1 -> 4 -> 3 -> 5 -> null
        }
    }

    public class IsPalindrome_M_10
    {
        /*
        To check if a linked list is a palindrome, we need to verify if the list reads the same forwards and backwards.The optimal way to do this involves reversing the second half of the list and then comparing it with the first half.

        ### Approach

        1. **Find the Middle**:
           - Use the slow and fast pointer technique to find the middle of the linked list.

        2. **Reverse the Second Half**:
           - Reverse the second half of the list starting from the middle.

        3. **Compare Both Halves**:
           - Compare the nodes of the first half and the reversed second half.

        4. **Restore the List** (Optional):
           - Restore the original list structure by reversing the second half again.

        
        ### Explanation

        1. ** Find the Middle**:
           - Use the slow and fast pointer technique to reach the middle of the list.The `slow` pointer moves one step at a time, while the `fast` pointer moves two steps at a time.When `fast` reaches the end, `slow` will be at the middle.

        2. **Reverse the Second Half**:
           - The `Reverse` method reverses the linked list from the middle to the end.

        3. **Compare Both Halves**:
           - Compare the nodes of the first half with the nodes of the reversed second half.If all corresponding nodes match, the list is a palindrome.

        4. **Restore the List** (Optional):
           - Reverse the second half again to restore the original list structure.This step is optional depending on whether you need to retain the original list.

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - Each node is visited a constant number of times, where (N ) is the number of nodes in the list.

        **Space Complexity**: O(1) - No extra space proportional to the input size is used, just a few pointers.

        This approach efficiently checks if a linked list is a palindrome using constant space and linear time.

        */

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            // Find the middle of the linked list
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // Reverse the second half of the list
            ListNode secondHalf = Reverse(slow);

            // Compare the first half and the reversed second half
            ListNode firstHalf = head;
            ListNode secondHalfCopy = secondHalf;
            bool isPalindrome = true;
            while (secondHalf != null)
            {
                if (firstHalf.val != secondHalf.val)
                {
                    isPalindrome = false;
                    break;
                }
                firstHalf = firstHalf.next;
                secondHalf = secondHalf.next;
            }

            // Restore the list (optional)
            Reverse(secondHalfCopy);

            return isPalindrome;
        }

        private ListNode Reverse(ListNode head)
        {
            ListNode prev = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void IsPalindromeDriver()
        {
            // Creating a palindrome linked list: 1 -> 2 -> 3 -> 2 -> 1 -> null
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(2);
            head.next.next.next.next = new ListNode(1);

            Console.WriteLine("Original List:");
            PrintList(head);

            IsPalindrome_M_10 solution = new IsPalindrome_M_10();
            bool isPalindrome = solution.IsPalindrome(head);

            if (isPalindrome)
            {
                Console.WriteLine("The linked list is a palindrome.");
            }
            else
            {
                Console.WriteLine("The linked list is not a palindrome.");
            }

            // Print list to show it is restored
            Console.WriteLine("Restored List:");
            PrintList(head);
        }
    }

    public class DetectCycle_M_11
    {
        /*
        To find the starting point of a loop in a linked list, you can use Floyd’s Tortoise and Hare algorithm.
        Once you detect a cycle, you can find the starting node of the cycle.

        ### Approach

        1. ** Detect Cycle**:
           - Use the slow and fast pointer technique to detect if there is a cycle in the list.
   
        2. **Find the Start of the Cycle**:
           - Once a cycle is detected, initialize one pointer at the head of the list and the other at the meeting point.
        Move both pointers one step at a time; the point at which they meet is the start of the cycle.

        
        ### Explanation

        1. ** Detect Cycle**:
           - Initialize two pointers, `slow` and `fast`, both starting at the head of the list.
           - Move `slow` one step at a time, and `fast` two steps at a time.
           - If `slow` and `fast` meet, there is a cycle.

        2. **Find the Start of the Cycle**:
           - After detecting the cycle, initialize one pointer at the head of the list (`pointer1`) and the other at the meeting point(`pointer2`).
           - Move both pointers one step at a time.The point where they meet is the starting point of the cycle.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - Each node is visited a constant number of times, where (N ) is the number of nodes in the list.

        **Space Complexity**: O(1) - No extra space proportional to the input size is used, just a few pointers.

        This approach efficiently finds the starting point of a cycle in a linked list using constant space and linear time.
        */
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null;
            }

            // Step 1: Detect if there is a cycle using Floyd’s Tortoise and Hare
            ListNode slow = head;
            ListNode fast = head;
            bool hasCycle = false;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    hasCycle = true;
                    break;
                }
            }

            // Step 2: If there is a cycle, find the starting point
            if (hasCycle)
            {
                ListNode pointer1 = head;
                ListNode pointer2 = slow; // Or fast, since slow == fast at the meeting point

                while (pointer1 != pointer2)
                {
                    pointer1 = pointer1.next;
                    pointer2 = pointer2.next;
                }

                return pointer1; // The starting point of the cycle
            }

            return null; // No cycle
        }

        public static void DetectCycleDriver()
        {
            // Creating a linked list with a cycle
            // 3 -> 2 -> 0 -> -4 -> 2 (cycle here)
            ListNode head = new ListNode(3);
            ListNode second = new ListNode(2);
            ListNode third = new ListNode(0);
            ListNode fourth = new ListNode(-4);

            head.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = second; // Creates a cycle

            DetectCycle_M_11 solution = new DetectCycle_M_11();
            ListNode cycleStart = solution.DetectCycle(head);

            if (cycleStart != null)
            {
                Console.WriteLine("The cycle starts at node with value: " + cycleStart.val);
            }
            else
            {
                Console.WriteLine("No cycle detected.");
            }
        }
    }

    public class Flatten_H_12
    {
        /*
        Flattening a linked list involves converting a multi-level linked list into a single-level linked list.
        Here, each node in the list contains a next pointer and a child pointer that may point to another list.
        The goal is to flatten this multi-level linked list into a single-level linked list.

        ### Approach

        1. **Iterate through the Main List**:
           - Use a pointer to iterate through the main list.
           - For each node, if there is a child list, insert it into the main list.
   
        2. **Merge Child Lists**:
           - When you encounter a node with a child list, append the child list to the main list by updating the next pointers.
   
        3. **Continue Flattening**:


        ### Explanation

        1. ** Iterate through the Main List**:
           - Start from the head of the list and iterate through each node.

        2. **Merge Child Lists**:
           - When a node with a `child` pointer is encountered, set the `next` pointer of the current node to point to the head of the child list.
           - Traverse to the end of the child list and link it to the `next` node of the current node.

        3. **Continue Flattening**:
           - Continue iterating through the main list, flattening each child list into the main list.

        ### Time and Space Complexity

        **Time Complexity**: O(N) - Each node is visited once, where (N ) is the total number of nodes in the multi-level list.

        **Space Complexity**: O(1) - No additional space is used other than a few pointers.

        This approach efficiently flattens a multi-level linked list into a single-level linked list using constant space and linear time complexity.

        */
        public ListNodeWithChild Flatten(ListNodeWithChild head)
        {
            if (head == null)
            {
                return null;
            }

            ListNodeWithChild current = head;

            while (current != null)
            {
                if (current.child != null)
                {
                    ListNodeWithChild childList = current.child;
                    ListNodeWithChild nextNode = current.next;
                    current.next = childList;
                    current.child = null;

                    ListNodeWithChild temp = childList;
                    while (temp.next != null)
                    {
                        temp = temp.next;
                    }
                    temp.next = nextNode;
                }
                current = current.next;
            }

            return head;
        }

        public static void PrintList(ListNodeWithChild head)
        {
            ListNodeWithChild current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void FlattenDriver()
        {
            // Creating a multi-level linked list:
            // 1 -> 2 -> 3 -> null
            //      |
            //      4 -> 5 -> null
            //           |
            //           6 -> null

            ListNodeWithChild head = new ListNodeWithChild(1);
            head.next = new ListNodeWithChild(2);
            head.next.next = new ListNodeWithChild(3);

            head.next.child = new ListNodeWithChild(4);
            head.next.child.next = new ListNodeWithChild(5);
            head.next.child.next.child = new ListNodeWithChild(6);

            Console.WriteLine("Original List:");
            PrintList(head);
            if (head.next != null) PrintList(head.next.child);
            if (head.next.child.next != null) PrintList(head.next.child.next.child);

            Flatten_H_12 solution = new Flatten_H_12();
            ListNodeWithChild flattenedList = solution.Flatten(head);

            Console.WriteLine("Flattened List:");
            PrintList(flattenedList);
        }
    }

    public class RotateRight_M_13
    {
        /*
        To rotate a linked list to the right by (k ) places, we can follow these steps:

        1. ** Find the Length of the List**:
           - Traverse the list to find its length and simultaneously make it circular by connecting the last node to the head.

        2. **Compute the Effective Rotations**:
           - Since rotating the list by its length (n ) results in the same list, we can reduce (k ) modulo (n ) (i.e., (k = k % n )).

        3. ** Find the New Tail and New Head**:
           - The new tail is the ((n - k - 1) )-th node(0-indexed), and the new head is the ((n - k) )-th node.

        4. **Break the Circle**:
           - Break the circle by setting the next pointer of the new tail to null.

        ### Explanation

        1. ** Compute the Length**:
           - Traverse the list to compute its length.
           - Connect the last node to the head to make the list circular.

        2. **Compute Effective Rotations**:
           - Calculate (k % text{ length} ) to handle cases where (k ) is larger than the length of the list.

        3. ** Find the New Tail and Head**:
           - The new tail is the ((length - k - 1) )-th node.
           - The new head is the ((length - k) )-th node.

        4. **Break the Circle**:
           - Break the circular list by setting the next pointer of the new tail to null.

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - Each node is visited a constant number of times, where (N ) is the number of nodes in the list.

        **Space Complexity**: O(1) - No extra space is used other than a few pointers.

        This approach efficiently rotates a linked list to the right by (k ) places using constant space and linear time complexity.
        */

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || k == 0)
            {
                return head;
            }

            // Step 1: Compute the length of the list and connect the tail to the head
            ListNode current = head;
            int length = 1;
            while (current.next != null)
            {
                current = current.next;
                length++;
            }
            current.next = head; // Make it circular

            // Step 2: Find the effective number of rotations
            k = k % length;

            // Step 3: Find the new tail (length - k - 1) and the new head (length - k)
            for (int i = 0; i < length - k - 1; i++)
            {
                head = head.next;
            }
            ListNode newHead = head.next;
            head.next = null; // Break the circle

            return newHead;
        }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void RotateRightDriver()
        {
            // Creating a linked list: 1 -> 2 -> 3 -> 4 -> 5 -> null
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            Console.WriteLine("Original List:");
            PrintList(head);

            RotateRight_M_13 solution = new RotateRight_M_13();
            int k = 2;
            ListNode rotatedList = solution.RotateRight(head, k);

            Console.WriteLine($"List after rotating by {k} positions:");
            PrintList(rotatedList); // Output should be: 4 -> 5 -> 1 -> 2 -> 3 -> null
        }
    }

    public class CopyRandomListUsingRandomAndNextPointer_H_14
    {
        /*
        To clone a linked list with both `next` and `random` pointers, 
        you can use a three-pass algorithm that efficiently copies the list in O(N) time complexity and O(1) space complexity
        (excluding the space required for the new nodes).

        ### Approach

        1. ** Interweave the Original List with the Cloned Nodes**:
           - For each node in the original list, create a new node and insert it right next to the original node.
        This way, each original node will be followed by its copy.

        2. **Assign the Random Pointers for the Cloned Nodes**:
           - Iterate through the list again, and for each original node, set the `random` pointer of its copy node
        to the copy of the original node’s random node.

        3. **Restore the Original List and Extract the Cloned List**:
           - Separate the interweaved list into the original list and the cloned list.


        ### Explanation

        1. ** Interweave the Original List with the Cloned Nodes**:
           - For each node in the original list, create a new node and insert it right next to the original node.
        This new node is the copy of the original node.

        2. **Assign the Random Pointers for the Cloned Nodes**:
           - Traverse the list again and set the `random` pointer for each cloned node.
        If the original node's `random` pointer is not null, the `random` pointer of the cloned node
        will point to the `next` of the original node’s `random` node.

        3. **Restore the Original List and Extract the Cloned List**:
           - Separate the interweaved list back into the original list and the cloned list by fixing the `next` pointers.

        ### Time and Space Complexity

        ** Time Complexity**: O(N) - Each node is visited a constant number of times.

        **Space Complexity**: O(1) - No extra space proportional to the input size is used,
        *other than a few pointers(excluding the space required for the new nodes).

        This approach efficiently clones a linked list with both `next` and `random` pointers using linear time and constant space.
        */

        public ListNodeWithRandom CopyRandomListUsingRandomAndNextPointer(ListNodeWithRandom head)
        {
            if (head == null) return null;

            // Step 1: Interweave the original list with the cloned nodes
            ListNodeWithRandom current = head;
            while (current != null)
            {
                ListNodeWithRandom next = current.next;
                ListNodeWithRandom copy = new ListNodeWithRandom(current.val);
                current.next = copy;
                copy.next = next;
                current = next;
            }

            // Step 2: Assign random pointers for the cloned nodes
            current = head;
            while (current != null)
            {
                if (current.random != null)
                {
                    current.next.random = current.random.next;
                }
                current = current.next.next;
            }

            // Step 3: Restore the original list and extract the cloned list
            current = head;
            ListNodeWithRandom dummy = new ListNodeWithRandom(0);
            ListNodeWithRandom copyCurrent = dummy;

            while (current != null)
            {
                ListNodeWithRandom next = current.next.next;

                // Extract the copy
                ListNodeWithRandom copy = current.next;
                copyCurrent.next = copy;
                copyCurrent = copy;

                // Restore the original list
                current.next = next;
                current = next;
            }

            return dummy.next;
        }

        public static void PrintList(ListNodeWithRandom head)
        {
            ListNodeWithRandom current = head;
            while (current != null)
            {
                Console.Write($"Value: {current.val}, Random: {(current.random != null ? current.random.val.ToString() : "null")}\n");
                current = current.next;
            }
        }

        public static void CopyRandomListUsingRandomAndNextPointerDriver()
        {
            // Creating a linked list: 1 -> 2 -> 3 -> null
            // Random pointers: 1.random -> 3, 2.random -> 1, 3.random -> 2
            ListNodeWithRandom head = new ListNodeWithRandom(1);
            head.next = new ListNodeWithRandom(2);
            head.next.next = new ListNodeWithRandom(3);

            head.random = head.next.next; // 1.random -> 3
            head.next.random = head; // 2.random -> 1
            head.next.next.random = head.next; // 3.random -> 2

            Console.WriteLine("Original List:");
            PrintList(head);

            CopyRandomListUsingRandomAndNextPointer_H_14 solution = new CopyRandomListUsingRandomAndNextPointer_H_14();
            ListNodeWithRandom clonedList = solution.CopyRandomListUsingRandomAndNextPointer(head);

            Console.WriteLine("Cloned List:");
            PrintList(clonedList);
        }
    }


}