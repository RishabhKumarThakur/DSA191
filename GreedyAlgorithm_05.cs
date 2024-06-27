using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace GreedyAlgorithm
{
    public class NMeetingInOneRoom_M_1
    {
        /* ACTIVITY SELECTION
        The problem of "N meetings in one room" involves selecting the maximum number of non-overlapping meetings that can be scheduled in a single room.
        Each meeting has a start time and an end time.The goal is to find the maximum number of meetings that can be accommodated without any overlaps.

        ### Approach

        1. **Sort the Meetings**:
           - First, sort the meetings based on their end times. If two meetings have the same end time,
        you can sort them by start time, but typically sorting by end time is sufficient.

        2. **Select Meetings**:
           - Use a greedy algorithm to select meetings.
        Start with the first meeting and keep adding subsequent meetings as long as they do not overlap with the previously selected meeting.

        ### Explanation

        1. ** Sort the Meetings**:
           - The meetings are sorted based on their end times.This sorting helps to ensure that the meetings selected are the ones that finish the earliest,
        leaving the most room for subsequent meetings.

        2. **Select Meetings**:
           - Initialize `lastEndTime` to track the end time of the last selected meeting.
           - Iterate through the sorted meetings.For each meeting, if its start time is greater than the `lastEndTime`, 
        it means it does not overlap with the previously selected meeting, so it can be added to the schedule.

        ### Time and Space Complexity

        **Time Complexity**: O(N log N) - The primary time complexity is due to the sorting step, where N is the number of meetings.

        **Space Complexity**: O(1) - The algorithm uses a constant amount of extra space regardless of the input size, assuming the input list can be sorted in place.

        This greedy approach ensures that you can select the maximum number of non-overlapping meetings efficiently.
        */

        public class Meeting
        {
            public int Start { get; set; }
            public int End { get; set; }

            public Meeting(int start, int end)
            {
                Start = start;
                End = end;
            }

        }


        public static int NMeetingInOneRoom(List<Meeting> meetings)
        {
            // Step 1: Sort the meetings based on their end time
            meetings.Sort((a, b) => a.End.CompareTo(b.End));

            int count = 0;
            int lastEndTime = -1;

            // Step 2: Iterate through the sorted meetings and select the maximum number of non-overlapping meetings
            foreach (var meeting in meetings)
            {
                if (meeting.Start > lastEndTime)
                {
                    count++;
                    lastEndTime = meeting.End;
                }
            }

            return count;
        }

        public static void NMeetingInOneRoomDriver()
        {
            List<Meeting> meetings = new List<Meeting>
            {
                new Meeting(1, 2),
                new Meeting(3, 4),
                new Meeting(0, 6),
                new Meeting(5, 7),
                new Meeting(8, 9),
                new Meeting(5, 9)
            };
            int maxMeetings = NMeetingInOneRoom(meetings);
            Console.WriteLine($"Maximum number of meetings that can be accommodated: {maxMeetings}");
        }
    }

    public class MinimumPlatformRequiredForRailway_M_2
    {
        /*
        To solve the problem of finding the minimum number of platforms required for a railway station to accommodate all trains without delay,
        we can use a greedy approach.The idea is to keep track of the arrival and departure times of trains,
        and use a timeline to determine the maximum number of trains that are at the station at the same time.

        ### Approach

        1. **Sort Arrival and Departure Times**:
           - Separate and sort the arrival and departure times of the trains.

        2. **Use Two Pointers to Track Platforms Needed**:
           - Use two pointers to traverse the sorted arrival and departure times.
           - Count the number of platforms needed at any given time by comparing the current arrival and departure times.


        ### Explanation

        1. ** Sort Arrival and Departure Times**:
           - Sort both `arr` (arrival times) and `dep` (departure times) arrays.

        2. **Two Pointers to Track Platforms Needed**:
           - Initialize two pointers, `i` and `j`, to traverse the arrival and departure arrays respectively.
           - Use `platformsNeeded` to track the current number of platforms needed and `maxPlatforms` to track the maximum platforms needed at any time.
           - Iterate through the arrival and departure times:
             - If the current arrival time (`arr[i]`) is less than or equal to the current departure time(`dep[j]`), it means a train has arrived and
        needs a platform.Increment `platformsNeeded` and move to the next arrival time (`i++`).
             - If the current arrival time(`arr[i]`) is greater than the current departure time(`dep[j]`),
        it means a train has departed and a platform is freed.Decrement `platformsNeeded` and move to the next departure time(`j++`).
           - Update `maxPlatforms` whenever `platformsNeeded` exceeds the current `maxPlatforms`.

        ### Time and Space Complexity

        ** Time Complexity**: O(N log N) - The primary time complexity is due to sorting the arrival and departure arrays.

        **Space Complexity**: O(1) - Only a constant amount of extra space is used, aside from the input arrays.

        This approach ensures that we efficiently determine the minimum number of platforms required using a greedy algorithm with sorted arrays and two pointers.
        */

        public static int MinimumPlatformRequiredForRailway(int[] arr, int[] dep, int n)
        {
            // Step 1: Sort the arrival and departure times
            Array.Sort(arr);
            Array.Sort(dep);

            // Step 2: Use two pointers to find the minimum number of platforms required
            int platformsNeeded = 0;
            int maxPlatforms = 0;
            int i = 0; // Pointer to traverse arrival times
            int j = 0; // Pointer to traverse departure times

            while (i < n && j < n)
            {
                // If next event in sorted order is arrival, increment platforms needed
                if (arr[i] <= dep[j])
                {
                    platformsNeeded++;
                    i++;
                    // Update result if needed
                    if (platformsNeeded > maxPlatforms)
                        maxPlatforms = platformsNeeded;
                }
                // Else decrement count of platforms needed
                else
                {
                    platformsNeeded--;
                    j++;
                }
            }

            return maxPlatforms;
        }

        public static void MinimumPlatformRequiredForRailwayDriver()
        {
            int[] arr = { 900, 940, 950, 1100, 1500, 1800 };
            int[] dep = { 910, 1200, 1120, 1130, 1900, 2000 };
            int n = arr.Length;

            Console.WriteLine("Minimum number of platforms required: " + MinimumPlatformRequiredForRailway(arr, dep, n)); // Output should be 3
        }
    }

    public class JobSequencing_M_3
    {
        /*
        The Job Sequencing Problem is a classic optimization problem where the objective is to maximize the total profit earned by scheduling jobs within their deadlines.
        Each job has a deadline and a profit associated with it, and it takes a single unit of time to complete each job. 
        The goal is to find the sequence of jobs that maximizes the total profit while ensuring that no two jobs overlap.

        ### Approach

        1. **Sort Jobs**:
           - Sort the jobs in decreasing order of profit. This way, we can consider the most profitable jobs first.

        2. **Create a Slot Array**:
           - Create an array to keep track of which time slots are occupied. The size of this array should be equal to the maximum deadline.

        3. **Assign Jobs to Slots**:
           - Iterate through the sorted jobs and try to place each job in the latest available slot before its deadline.

        ### Explanation

        1. ** Sort Jobs**:
           - The jobs are sorted in decreasing order of profit using a custom comparator.

        2. **Create a Slot Array**:
           - An array `result` is created to store the job ids assigned to each slot, and a boolean array `slot` is used to check if a slot is occupied.

        3. **Assign Jobs to Slots**:
           - Iterate through the sorted jobs and for each job, find the latest available slot before its deadline.
        If a free slot is found, assign the job to that slot and mark the slot as occupied.

        4. **Output the Job Sequence**:
           - Collect and print the job ids from the `result` array where slots are occupied.

        ### Time and Space Complexity

        ** Time Complexity**: O(N log N + N* D), where N is the number of jobs and D is the maximum deadline.
        *The sorting step takes O(N log N) and assigning jobs to slots takes O(N* D) in the worst case.

        ** Space Complexity**: O(D), where D is the maximum deadline.This space is used for the `result` and `slot` arrays.

        This approach efficiently schedules the jobs to maximize profit while ensuring no two jobs overlap within their deadlines.
        */

        public class Job
        {
            public int Id { get; set; }
            public int Deadline { get; set; }
            public int Profit { get; set; }

            public Job(int id, int deadline, int profit)
            {
                Id = id;
                Deadline = deadline;
                Profit = profit;
            }
        }


        public static int[] JobSequencing(List<Job> jobs)
        {
            // Step 1: Sort jobs in decreasing order of profit
            jobs.Sort((a, b) => b.Profit.CompareTo(a.Profit));

            // Find the maximum deadline
            int maxDeadline = 0;
            foreach (var job in jobs)
            {
                if (job.Deadline > maxDeadline)
                    maxDeadline = job.Deadline;
            }

            // Step 2: Create an array to keep track of free time slots
            int[] result = new int[maxDeadline]; // Result array to store job ids
            bool[] slot = new bool[maxDeadline]; // Slot array to check if slot is occupied

            for (int i = 0; i < maxDeadline; i++)
                slot[i] = false;

            // Step 3: Assign jobs to slots
            foreach (var job in jobs)
            {
                // Find a free slot for this job (starting from the last possible slot)
                for (int j = Math.Min(maxDeadline - 1, job.Deadline - 1); j >= 0; j--)
                {
                    if (slot[j] == false)
                    {
                        result[j] = job.Id; // Assign job id to the result array
                        slot[j] = true; // Mark this slot as occupied
                        break;
                    }
                }
            }

            // Collecting only the assigned job ids
            List<int> assignedJobs = new List<int>();
            for (int i = 0; i < maxDeadline; i++)
            {
                if (slot[i])
                    assignedJobs.Add(result[i]);
            }

            return assignedJobs.ToArray();
        }

        public static void JobSequencingDriver()
        {
            List<Job> jobs = new List<Job>
            {
                new Job(1, 4, 20), // id, deadline and profit
                new Job(2, 1, 10),
                new Job(3, 1, 40),
                new Job(4, 1, 30)
            };

            int[] jobSequence = JobSequencing(jobs);
            Console.WriteLine("Job sequence to maximize profit:");
            foreach (int jobId in jobSequence)
            {
                Console.WriteLine("Job ID: " + jobId);
            }
        }
    }

    public class FractionalKnapsack_M_4
    {
        /*
        The Fractional Knapsack problem is a classic optimization problem where the goal is to maximize the total value of items
        placed in a knapsack that has a weight capacity, allowing for the inclusion of fractions of items.
        This problem can be efficiently solved using a greedy approach.

        ### Approach

        1. **Calculate Value-to-Weight Ratio**:
           - For each item, calculate the ratio of value to weight.

        2. **Sort Items by Ratio**:
           - Sort the items in descending order based on the value-to-weight ratio.

        3. **Fill the Knapsack**:
           - Iterate through the sorted list of items and add them to the knapsack.
        If the item can be fully added without exceeding the capacity, add it entirely; otherwise, add as much of it as possible.

        ## Explanation

        1. ** Calculate Value-to-Weight Ratio**:
           - Each item has a weight and a value.Calculate the ratio `value/weight` for each item.

        2. **Sort Items by Ratio**:
           - Sort the items in descending order based on the calculated value-to-weight ratio.

        3. **Fill the Knapsack**:
           - Initialize `totalValue` to 0.
           - Iterate through the sorted list of items:
             - If the current item can be fully added to the knapsack without exceeding the capacity, add its full weight and value to the knapsack.
             - If the current item cannot be fully added, add as much of it as possible (fractionally),
        and break out of the loop since the knapsack will be full after this.

        ### Time and Space Complexity

        **Time Complexity**: O(N log N) - The primary time complexity comes from sorting the items based on their value-to-weight ratio.

        **Space Complexity**: O(1) - No extra space is required other than the input and a few variables.

        This approach efficiently solves the Fractional Knapsack problem using a greedy strategy,
        ensuring the maximum possible value is obtained for the given capacity.
        */

        public class Item
         {
            public double Weight { get; set; }
            public double Value { get; set; }

            public Item(double weight, double value)
            {
                Weight = weight;
                Value = value;
            }
        }

        public static double FractionalKnapsack(List<Item> items, double capacity)
        {
            // Step 1: Calculate value-to-weight ratio and sort items by this ratio in descending order
            items.Sort((a, b) => (b.Value / b.Weight).CompareTo(a.Value / a.Weight));

            double totalValue = 0.0;

            // Step 2: Iterate through the sorted items and add them to the knapsack
            foreach (var item in items)
            {
                if (capacity >= item.Weight)
                {
                    // If the item can be fully added, add it
                    capacity -= item.Weight;
                    totalValue += item.Value;
                }
                else
                {
                    // Add as much of the item as possible
                    totalValue += item.Value * (capacity / item.Weight);
                    break; // Knapsack is full
                }
            }

            return totalValue;
        }

        public static void FractionalKnapsackDriver()
        {
            List<Item> items = new List<Item>
            {
                new Item(10, 60), // weight, value
                new Item(20, 100),
                new Item(30, 120)
            };

            double capacity = 50;

            double maxValue = FractionalKnapsack(items, capacity);
            Console.WriteLine($"Maximum value in knapsack = {maxValue}"); // Output should be 240.0
        }
    }

    public class FindMinimumCoins_M_5
    {
        /*
        To solve the problem of finding the minimum number of coins required to make a given amount of money using coins of specified denominations,
        you can use a greedy approach.This approach works optimally when the denominations follow certain properties, 
        such as the denominations used in many real-world currency systems (e.g., 1, 5, 10, 25, etc.).

        ### Approach

        1. ** Sort the Coin Denominations**:
           - Sort the coin denominations in descending order.

        2. **Greedy Selection**:
           - Start with the largest denomination and use as many coins of that denomination as possible without exceeding the target amount.
           - Move to the next largest denomination and repeat until the amount is reduced to zero.


        ### Explanation

        1. ** Sort the Coin Denominations**:
           - The denominations are sorted in descending order to ensure the largest denomination is considered first,
        maximizing the amount covered by the largest coins.

        2. ** Greedy Selection**:
           - Iterate through the sorted denominations.For each denomination, while the remaining amount is greater than or equal to the denomination, 
        subtract the denomination from the amount and add the coin to the result list.

        3. **Output the Results**:
           - The result list contains the denominations of coins used to make up the total amount with the minimum number of coins.

        ### Example Walkthrough

        Let's walk through an example where the amount is 93 and the denominations are [1, 5, 10, 25]:

        1. **Sort Denominations**: [25, 10, 5, 1]
        2. **Start with 25**:
           - 93 - 25 = 68 (use one 25-coin)
           - 68 - 25 = 43 (use another 25-coin)
           - 43 - 25 = 18 (use another 25-coin)
        3. ** Next, use 10**:
           - 18 - 10 = 8 (use one 10-coin)
        4. ** Next, use 5**:
           - 8 - 5 = 3 (use one 5-coin)
        5. ** Finally, use 1**:
           - 3 - 1 = 2 (use one 1-coin)
           - 2 - 1 = 1 (use another 1-coin)
           - 1 - 1 = 0 (use another 1-coin)

        The minimum number of coins required is 7, and the coins used are[25, 25, 25, 10, 5, 1, 1, 1].

        ### Time and Space Complexity

        ** Time Complexity**: O(N log N) - The primary time complexity comes from sorting the denominations.

        ** Space Complexity**: O(1) - The extra space used is for the result list,
        *which depends on the input amount and is not considered additional space complexity relative to the input size.

        This approach ensures that the minimum number of coins is used to make the given amount by leveraging the greedy strategy effectively.
         */

        public static List<int> FindMinimumCoins(int amount, List<int> denominations)
        {
            // Step 1: Sort the coin denominations in descending order
            denominations.Sort((a, b) => b.CompareTo(a));

            List<int> result = new List<int>();

            // Step 2: Iterate through the sorted denominations and use as many as possible
            foreach (int coin in denominations)
            {
                while (amount >= coin)
                {
                    amount -= coin;
                    result.Add(coin);
                }
            }

            return result;
        }

        public static void FindMinimumCoinsDriver()
        {
            int amount = 93;
            List<int> denominations = new List<int> { 1, 5, 10, 25 };
            Console.WriteLine($"Amount : {amount} and Denominations are: {string.Join(", ", denominations)}");

            List<int> minimumCoins = FindMinimumCoins(amount, denominations);
            Console.WriteLine($"Minimum number of coins required: {minimumCoins.Count}");
            Console.WriteLine("Coins used:");
            foreach (int coin in minimumCoins)
            {
                Console.Write(coin + " ");
            }
        }
    }

}
