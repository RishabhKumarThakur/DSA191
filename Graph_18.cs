namespace Graph
{
    public class CloneAGraph_H_1
    {
        /*
        Cloning a graph involves creating a deep copy of the graph, which means replicating not only the nodes but also the edges connecting them.
        Given a node in a graph, we can use either BFS or DFS to traverse the graph and clone each node and its connections.
        Here's how you can achieve this in C#:

        ### Approach

        To clone an undirected graph, you need to:
        1. Use a map(or dictionary) to store the mapping between original nodes and their cloned counterparts.
        2. Perform a traversal(BFS or DFS) starting from the given node, cloning each node and its neighbors, and updating the map accordingly.

        ### Explanation

        - ** Node Class**: Represents a node in the graph with a value `val` and a list of neighbors `neighbors`.

        - ** Solution Class**:
          - ** CloneGraph Method**: Clones the graph using BFS.
            - If the input node is null, it returns null.
            - Uses a dictionary `map` to map original nodes to their clones.
            - Uses a queue for BFS traversal.For each node, it clones the node and its neighbors, updating the map and queue accordingly.
            - Finally, it returns the cloned node corresponding to the given node.
          - **PrintGraph Method**: Prints the graph using BFS for testing purposes.

        - **Main Method**: 
          - Constructs an example graph.
          - Clones the graph using `CloneGraph`.
          - Prints both the original and cloned graphs to verify correctness.

        ### Complexity

        - **Time Complexity**: (O(N + E)), where (N) is the number of nodes and (E) is the number of edges.Each node and edge is processed once.
        - **Space Complexity**: (O(N)) for the dictionary storing the mapping of original nodes to their clones and the queue used for BFS.

        This implementation efficiently clones an undirected graph using BFS and ensures that all nodes and their connections are correctly replicated.
        */

        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }


        // Clones a graph using BFS.
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;

            // Dictionary to save the cloned nodes.
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            // Queue for BFS traversal.
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            // Clone the root node.
            map[node] = new Node(node.val);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                // Iterate through the neighbors of the current node.
                foreach (Node neighbor in current.neighbors)
                {
                    if (!map.ContainsKey(neighbor))
                    {
                        // Clone the neighbor.
                        map[neighbor] = new Node(neighbor.val);
                        // Enqueue the neighbor for BFS traversal.
                        queue.Enqueue(neighbor);
                    }
                    // Add the cloned neighbor to the cloned current node's neighbors.
                    map[current].neighbors.Add(map[neighbor]);
                }
            }

            // Return the cloned node corresponding to the given node.
            return map[node];
        }

        // Helper method to print the graph (for testing purposes).
        public void PrintGraph(Node node)
        {
            if (node == null) return;

            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            visited.Add(node);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.Write(current.val + ": ");

                foreach (Node neighbor in current.neighbors)
                {
                    Console.Write(neighbor.val + " ");
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
                Console.WriteLine();
            }
        }

        public static void CloneAGraphDriver()
        {
            // Example usage:
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);

            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);
            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);
            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);
            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            CloneAGraph_H_1 solution = new CloneAGraph_H_1();

            // Clone the graph
            Node clonedGraph = solution.CloneGraph(node1);

            // Print the original graph
            Console.WriteLine("Original graph:");
            solution.PrintGraph(node1);

            // Print the cloned graph
            Console.WriteLine("Cloned graph:");
            solution.PrintGraph(clonedGraph);
        }
    }

    public class DFSinGraph_H_2
    {
        /*
        To traverse an undirected graph using depth-first search(DFS) and return a list of all nodes visited, 
        we can use a recursive DFS approach.Here's how you can implement it in C#:


        ### Explanation

        - ** Node Class**: Represents a node in the graph with a value `val` and a list of neighbors `neighbors`.

        - ** Solution Class**:
          - ** DFS Method**: Performs DFS on the graph starting from the given node and returns a list of all nodes visited.
            - If the input node is null, it returns an empty list.
            - Initializes a list `result` to store the nodes visited during DFS and a hash set `visited` to keep track of visited nodes.
            - Uses a nested helper method `DFSHelper` to perform the recursive DFS traversal.
            - Adds the current node's value to the result list and recursively visits all its neighbors that haven't been visited.
          - **Main Method**:
            - Constructs an example graph.
            - Performs DFS starting from a given node using `DFS`.
            - Prints the result of the DFS traversal.

        ### Complexity

        - ** Time Complexity**: (O(N + E)), where (N) is the number of nodes and (E) is the number of edges.Each node and edge is processed once.
        - **Space Complexity**: (O(N)) for the recursion stack and the hash set storing visited nodes.

        This implementation efficiently performs a depth-first search (DFS) on an undirected graph and returns a list of all nodes visited, 
        ensuring that each node is visited exactly once.
        */

        // Definition for a graph node.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }


        // Method to perform DFS and return a list of all nodes.
        public List<int> DFS(Node node)
        {
            if (node == null) return new List<int>();

            // List to store the result of DFS traversal.
            List<int> result = new List<int>();
            // HashSet to keep track of visited nodes.
            HashSet<Node> visited = new HashSet<Node>();

            // Helper method to perform DFS.
            void DFSHelper(Node current)
            {
                // Mark the current node as visited.
                visited.Add(current);
                // Add the current node's value to the result list.
                result.Add(current.val);

                // Recursively visit all the neighbors of the current node.
                foreach (Node neighbor in current.neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFSHelper(neighbor);
                    }
                }
            }

            // Start DFS from the given node.
            DFSHelper(node);

            return result;
        }

        public static void DFSinGraphDriver()
        {
            // Example usage:
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);

            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);
            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);
            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);
            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            DFSinGraph_H_2 solution = new DFSinGraph_H_2();

            // Perform DFS and get the list of all nodes.
            List<int> dfsResult = solution.DFS(node1);

            // Print the result of DFS traversal.
            Console.WriteLine("DFS Traversal:");
            foreach (int val in dfsResult)
            {
                Console.Write(val + " ");
            }
        }
    }

    public class BFSinGraph_M_3
    {
        /*
        To traverse an undirected graph using breadth-first search(BFS) and return a list of all nodes visited, you can use a queue to manage the traversal order.Here's how you can implement it in C#:

        ### Explanation

        - ** Node Class**: Represents a node in the graph with a value `val` and a list of neighbors `neighbors`.

        - ** Solution Class**:
          - ** BFS Method**: Performs BFS on the graph starting from the given node and returns a list of all nodes visited.
            - If the input node is null, it returns an empty list.
            - Initializes a list `result` to store the nodes visited during BFS, a hash set `visited` to keep track of visited nodes, and a queue `queue` to manage the BFS traversal.
            - Adds the starting node to the queue and marks it as visited.
            - While the queue is not empty, dequeues a node, adds its value to the result list, and enqueues all its unvisited neighbors.
          - **Main Method**:
            - Constructs an example graph.
            - Performs BFS starting from a given node using `BFS`.
            - Prints the result of the BFS traversal.

        ### Complexity

        - ** Time Complexity**: (O(N + E)), where (N) is the number of nodes and (E) is the number of edges.Each node and edge is processed once.
        - **Space Complexity**: (O(N)) for the queue used for BFS and the hash set storing visited nodes.

        This implementation efficiently performs a breadth-first search (BFS) on an undirected graph and returns a list of all nodes visited, ensuring that each node is visited exactly once.

        */

        // Definition for a graph node.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }


        // Method to perform BFS and return a list of all nodes.
        public List<int> BFS(Node node)
        {
            if (node == null) return new List<int>();

            // List to store the result of BFS traversal.
            List<int> result = new List<int>();
            // HashSet to keep track of visited nodes.
            HashSet<Node> visited = new HashSet<Node>();
            // Queue for BFS traversal.
            Queue<Node> queue = new Queue<Node>();

            // Start BFS from the given node.
            queue.Enqueue(node);
            visited.Add(node);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                result.Add(current.val);

                // Visit all the neighbors of the current node.
                foreach (Node neighbor in current.neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }

        public static void BFSinGraphDriver()
        {
            // Example usage:
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);

            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);
            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);
            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);
            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            BFSinGraph_M_3 solution = new BFSinGraph_M_3();

            // Perform BFS and get the list of all nodes.
            List<int> bfsResult = solution.BFS(node1);

            // Print the result of BFS traversal.
            Console.WriteLine("BFS Traversal:");
            foreach (int val in bfsResult)
            {
                Console.Write(val + " ");
            }
        }
    }

    public class DetectCycleinUndirectedGraphUsingBFS_H_4
    {
        /*
        To check whether an undirected graph contains a cycle or not, we can use Depth-First Search(DFS).
        During the DFS traversal, we keep track of the visited nodes and their parent nodes.
        If we encounter a visited node that is not the parent of the current node, it indicates the presence of a cycle.

        ### Explanation

        1. ** Graph Class**:
           - ** Constructor**: Initializes the graph with `V` vertices and an adjacency list.
           - ** AddEdge Method**: Adds an undirected edge between vertices `v` and `w`.
           - ** IsCyclic Method**: Checks whether the graph contains any cycle by iterating through all vertices.
        If a vertex is not visited, it calls the `IsCyclicUtil` method for that vertex.
           - **IsCyclicUtil Method**: A recursive utility function that performs DFS to detect cycles. 
        It marks the current node as visited and recurses for all adjacent vertices.
        If an adjacent vertex is already visited and is not the parent of the current vertex, it indicates a cycle.

        2. **Program Class**:
           - **Main Method**: Demonstrates the usage of the `Graph` class by creating two sample graphs and checking for cycles.

        ### Complexity

        - ** Time Complexity**: (O(V + E)), where (V) is the number of vertices and (E) is the number of edges.
        This is because each vertex and each edge is processed once.
        - **Space Complexity**: (O(V)) for the visited array and the recursion stack.

        This implementation efficiently checks for cycles in an undirected graph using DFS, ensuring each vertex and edge is visited exactly once.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Method to add an edge into the graph
            public void AddEdge(int v, int w)
            {
                adj[v].Add(w);
                adj[w].Add(v); // Since the graph is undirected
            }

            // Method to check if the graph contains a cycle
            public bool IsCyclic()
            {
                bool[] visited = new bool[V];

                for (int u = 0; u < V; u++)
                {
                    if (!visited[u])
                    {
                        if (IsCyclicUtil(u, visited, -1))
                            return true;
                    }
                }

                return false;
            }

            // A recursive function that uses DFS to detect a cycle in the subgraph
            // reachable from vertex v.
            private bool IsCyclicUtil(int v, bool[] visited, int parent)
            {
                visited[v] = true;

                foreach (int i in adj[v])
                {
                    if (!visited[i])
                    {
                        if (IsCyclicUtil(i, visited, v))
                            return true;
                    }
                    else if (i != parent)
                    {
                        return true;
                    }
                }

                return false;
            }
        }


        public static void DetectCycleinUndirectedGraphUsingBFSDriver()
        {
            Graph g1 = new Graph(5);
            g1.AddEdge(0, 1);
            g1.AddEdge(1, 2);
            g1.AddEdge(2, 0);
            g1.AddEdge(1, 3);
            g1.AddEdge(3, 4);

            if (g1.IsCyclic())
                Console.WriteLine("Graph contains cycle - UnDirected Graph Using BFS");
            else
                Console.WriteLine("Graph doesn't contain cycle - UnDirected Graph Using BFS");

            Graph g2 = new Graph(3);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);

            if (g2.IsCyclic())
                Console.WriteLine("Graph contains cycle - UnDirected Graph Using BFS");
            else
                Console.WriteLine("Graph doesn't contain cycle - UnDirected Graph Using BFS");
        }
    }

    public class DetectCycleinUndirectedGraphUsingDFS_H_5
    {
        /*
        To check whether an undirected graph contains a cycle, we can use Depth-First Search(DFS). 
        During the DFS traversal, we track the visited nodes and their parent nodes.
        If we encounter a visited node that is not the parent of the current node, it indicates the presence of a cycle.

        ### Explanation

        1. ** Graph Class**:
           - ** Constructor**: Initializes the graph with `V` vertices and an adjacency list.
           - ** AddEdge Method**: Adds an undirected edge between vertices `v` and `w`.
           - ** IsCyclic Method**: Checks whether the graph contains any cycle by iterating through all vertices.
        If a vertex is not visited, it calls the `IsCyclicUtil` method for that vertex.
           - **IsCyclicUtil Method**: A recursive utility function that performs DFS to detect cycles. 
        It marks the current node as visited and recurses for all adjacent vertices.
        If an adjacent vertex is already visited and is not the parent of the current vertex, it indicates a cycle.

        2. **Program Class**:
           - **Main Method**: Demonstrates the usage of the `Graph` class by creating two sample graphs and checking for cycles.

        ### Complexity

        - ** Time Complexity**: (O(V + E)), where (V) is the number of vertices and (E) is the number of edges.This is because each vertex and each edge is processed once.
        - **Space Complexity**: (O(V)) for the visited array and the recursion stack.

        This implementation efficiently checks for cycles in an undirected graph using DFS, ensuring each vertex and edge is visited exactly once.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Method to add an edge into the graph
            public void AddEdge(int v, int w)
            {
                adj[v].Add(w);
                adj[w].Add(v); // Since the graph is undirected
            }

            // Method to check if the graph contains a cycle
            public bool IsCyclic()
            {
                bool[] visited = new bool[V];

                for (int u = 0; u < V; u++)
                {
                    if (!visited[u])
                    {
                        if (IsCyclicUtil(u, visited, -1))
                            return true;
                    }
                }

                return false;
            }

            // A recursive function that uses DFS to detect a cycle in the subgraph
            // reachable from vertex v.
            private bool IsCyclicUtil(int v, bool[] visited, int parent)
            {
                visited[v] = true;

                foreach (int i in adj[v])
                {
                    if (!visited[i])
                    {
                        if (IsCyclicUtil(i, visited, v))
                            return true;
                    }
                    else if (i != parent)
                    {
                        return true;
                    }
                }

                return false;
            }
        }


        public static void DetectCycleinUndirectedGraphUsingDFSDriver()
        {
            // Example 1
            Graph g1 = new Graph(5);
            g1.AddEdge(0, 1);
            g1.AddEdge(1, 2);
            g1.AddEdge(2, 0);
            g1.AddEdge(1, 3);
            g1.AddEdge(3, 4);

            if (g1.IsCyclic())
                Console.WriteLine("Graph contains cycle - UnDirected Graph Using DFS");
            else
                Console.WriteLine("Graph doesn't contain cycle - UnDirected Graph Using DFS");

            // Example 2
            Graph g2 = new Graph(3);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            if (g2.IsCyclic())
                Console.WriteLine("Graph contains cycle - UnDirected Graph Using DFS");
            else
                Console.WriteLine("Graph doesn't contain cycle - UnDirected Graph Using DFS");
        }
    }

    public class DetectCycleinDirectedGraphUsingDFS_H_6
    { 
        /*
        To detect a cycle in a directed graph, we can use Depth-First Search(DFS).
        During the DFS traversal, we use a recursion stack to keep track of the vertices currently being processed.
        If we encounter a vertex that is already in the recursion stack, it indicates the presence of a cycle.

        ### Explanation

        1. ** Graph Class**:
           - ** Constructor**: Initializes the graph with `V` vertices and an adjacency list.
           - ** AddEdge Method**: Adds a directed edge from vertex `v` to vertex `w`.
           - ** IsCyclic Method**: Checks whether the graph contains any cycle by iterating through all vertices.
        If a vertex is not visited, it calls the `IsCyclicUtil` method for that vertex.
           - **IsCyclicUtil Method**: A recursive utility function that performs DFS to detect cycles.
        It uses an additional array `recStack` to keep track of the vertices currently in the recursion stack.
        If a vertex is found in the `recStack`, it indicates a cycle.

        2. **Program Class**:
           - **Main Method**: Demonstrates the usage of the `Graph` class by creating two sample graphs and checking for cycles.

        ### Complexity

        - ** Time Complexity**: (O(V + E)), where (V) is the number of vertices and (E) is the number of edges.
        This is because each vertex and each edge is processed once.
        - **Space Complexity**: (O(V)) for the visited array, recursion stack array, and the recursion call stack.

        This implementation efficiently checks for cycles in a directed graph using DFS, ensuring each vertex and edge is visited exactly once.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Method to add an edge into the graph
            public void AddEdge(int v, int w)
            {
                adj[v].Add(w); // Since the graph is directed
            }

            // Method to check if the graph contains a cycle
            public bool IsCyclic()
            {
                bool[] visited = new bool[V];
                bool[] recStack = new bool[V];
                for (int i = 0; i < V; i++)
                {
                    if (IsCyclicUtil(i, visited, recStack))
                        return true;
                }
                return false;
            }

            // A recursive function that uses DFS to detect a cycle in the subgraph
            // reachable from vertex v.
            private bool IsCyclicUtil(int v, bool[] visited, bool[] recStack)
            {
                if (recStack[v])
                    return true;
                if (visited[v])
                    return false;
                visited[v] = true;
                recStack[v] = true;

                foreach (int neighbor in adj[v])
                {
                    if (IsCyclicUtil(neighbor, visited, recStack))
                        return true;
                }

                recStack[v] = false;
                return false;
            }
        }

        public static void DetectCycleinDirectedGraphUsingDFSDriver()
        {
            // Example 1
            Graph g1 = new Graph(4);
            g1.AddEdge(0, 1);
            g1.AddEdge(1, 2);
            g1.AddEdge(2, 0);
            g1.AddEdge(2, 3);

            if (g1.IsCyclic())
                Console.WriteLine("Graph contains cycle - Directed Graph Using DFS");
            else
                Console.WriteLine("Graph doesn't contain cycle - Directed Graph Using DFS");

            // Example 2
            Graph g2 = new Graph(4);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            g2.AddEdge(2, 3);

            if (g2.IsCyclic())
                Console.WriteLine("Graph contains cycle - Directed Graph Using DFS");
            else
                Console.WriteLine("Graph doesn't contain cycle - Directed Graph Using DFS");
        }
    }

    public class DetectCycleinDirectedGraphUsingBFS_H_7
    {
        /*
        To detect a cycle in a directed graph using Breadth-First Search(BFS), we can use Kahn's Algorithm for Topological Sorting.
        The idea is based on counting the in-degrees of all nodes and processing nodes with zero in-degrees.
        If we can process all the nodes in this manner, the graph is acyclic; otherwise, it contains a cycle.

        ### Explanation

        1. ** Graph Class**:
           - ** Constructor**: Initializes the graph with `V` vertices and an adjacency list.
           - ** AddEdge Method**: Adds a directed edge from vertex `v` to vertex `w`.
           - ** IsCyclic Method**: Checks whether the graph contains any cycle using Kahn's Algorithm for topological sorting.
             - ** In-Degree Calculation**: Initializes the in-degree of each vertex.
             - **Queue Initialization**: Enqueues all vertices with in-degree 0.
             - **Processing Queue**: Processes vertices from the queue, 
        reducing the in-degree of their neighbors and enqueuing neighbors with in-degree 0.
             - **Cycle Detection**: If the number of processed vertices is not equal to the total number of vertices, the graph contains a cycle.

        2. **Program Class**:
           - **Main Method**: Demonstrates the usage of the `Graph` class by creating two sample graphs and checking for cycles.

        ### Complexity

        - ** Time Complexity**: (O(V + E)), where (V) is the number of vertices and (E) is the number of edges
        .This is because each vertex and each edge is processed once.
        - **Space Complexity**: (O(V)) for the in-degree array and the queue.

        This implementation efficiently checks for cycles in a directed graph using BFS and Kahn's Algorithm for topological sorting.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Method to add an edge into the graph
            public void AddEdge(int v, int w)
            {
                adj[v].Add(w); // Since the graph is directed
            }

            // Method to check if the graph contains a cycle using BFS (Kahn's Algorithm)
            public bool IsCyclic()
            {
                int[] inDegree = new int[V];

                // Initialize in-degree of each vertex
                for (int i = 0; i < V; i++)
                {
                    foreach (var node in adj[i])
                    {
                        inDegree[node]++;
                    }
                }

                // Create a queue and enqueue all vertices with in-degree 0
                Queue<int> queue = new Queue<int>();
                for (int i = 0; i < V; i++)
                {
                    if (inDegree[i] == 0)
                        queue.Enqueue(i);
                }

                int count = 0; // Count of vertices visited

                // Process until the queue is empty
                while (queue.Count > 0)
                {
                    int u = queue.Dequeue();
                    count++;

                    // Reduce in-degree by 1 for all its neighboring nodes
                    foreach (var node in adj[u])
                    {
                        if (--inDegree[node] == 0)
                            queue.Enqueue(node);
                    }
                }

                // If count of visited nodes is not equal to the number of vertices, there is a cycle
                return count != V;
            }
        }

        public static void DetectCycleinDirectedGraphUsingBFSDriver()
        {
            // Example 1
            Graph g1 = new Graph(4);
            g1.AddEdge(0, 1);
            g1.AddEdge(1, 2);
            g1.AddEdge(2, 0);
            g1.AddEdge(2, 3);

            if (g1.IsCyclic())
                Console.WriteLine("Graph contains cycle - Directed Graph Using BFS");
            else
                Console.WriteLine("Graph doesn't contain cycle - Directed Graph Using BFS");

            // Example 2
            Graph g2 = new Graph(4);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            g2.AddEdge(2, 3);

            if (g2.IsCyclic())
                Console.WriteLine("Graph contains cycle - Directed Graph Using BFS");
            else
                Console.WriteLine("Graph doesn't contain cycle - Directed Graph Using BFS");
        }
    }

    public class TopologicalSortUsingBFS_H_8
    {
        /*
        To perform a topological sort using Breadth-First Search(BFS), we need to consider a Directed Acyclic Graph(DAG).
        Topological sorting arranges the vertices of a DAG in such a way that for every directed edge u -> v,
        vertex u comes before vertex v in the ordering.


        ### Explanation

        1. ** Graph Class**:
           - ** Constructor**: Initializes the graph with `V` vertices and an adjacency list.
           - ** AddEdge Method**: Adds a directed edge from vertex `v` to vertex `w`.
           - ** TopologicalSort Method**: Performs topological sorting using BFS (Kahn's Algorithm for topological sorting).
             - ** In-Degree Calculation**: Initializes the in-degree of each vertex.
             - **Queue Initialization**: Enqueues all vertices with in-degree 0.
             - **Processing Queue**: Processes vertices from the queue, reducing the in-degree of their neighbors and enqueuing neighbors with in-degree 0.
             - **Cycle Detection**: If the number of vertices processed is less than `V`, the graph contains a cycle, and topological sorting is not possible.

        2. **Program Class**:
           - **Main Method**: Demonstrates the usage of the `Graph` class by creating an example graph and printing the topological sorting order.

        ### Complexity

        - **Time Complexity**: (O(V + E)), where (V) is the number of vertices and (E) is the number of edges.
        This is because each vertex and each edge is processed once.
        - **Space Complexity**: (O(V)) for the in-degree array, queue, and topological order list.

        This implementation efficiently computes the topological sorting of a Directed Acyclic Graph(DAG) using BFS.
        It ensures that the vertices are ordered such that all directed edges point from a vertex earlier in the order to a vertex later in the order,
                making it suitable for tasks like scheduling or resolving dependencies.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Method to add an edge into the graph
            public void AddEdge(int v, int w)
            {
                adj[v].Add(w); // Since the graph is directed
            }

            // Method to perform topological sort using BFS
            public List<int> TopologicalSort()
            {
                // Initialize in-degree of each vertex
                int[] inDegree = new int[V];
                for (int i = 0; i < V; i++)
                {
                    foreach (var node in adj[i])
                    {
                        inDegree[node]++;
                    }
                }

                // Create a queue and enqueue all vertices with in-degree 0
                Queue<int> queue = new Queue<int>();
                for (int i = 0; i < V; i++)
                {
                    if (inDegree[i] == 0)
                        queue.Enqueue(i);
                }

                List<int> topoOrder = new List<int>();

                // Process until the queue is empty
                while (queue.Count > 0)
                {
                    int u = queue.Dequeue();
                    topoOrder.Add(u);

                    // Reduce in-degree by 1 for all its neighboring nodes
                    foreach (var node in adj[u])
                    {
                        if (--inDegree[node] == 0)
                            queue.Enqueue(node);
                    }
                }

                // Check if topological sort is possible
                if (topoOrder.Count != V)
                {
                    Console.WriteLine("Graph contains cycle. Topological sort not possible.");
                    return new List<int>(); // Return empty list if cycle is detected
                }

                return topoOrder;
            }
        }

        public static void TopologicalSortUsingBFSDriver()
        {
            // Example graph
            Graph g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            List<int> topoSort = g.TopologicalSort();

            Console.WriteLine("Topological sorting of the graph using BFS:");
            foreach (var vertex in topoSort)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();
        }
    }

    public class TopologicalSortUsingBFS_H_9
    {
        /*
        To perform Topological Sort using Depth-First Search(DFS), we typically use a recursive approach where nodes are visited in a depth-first
        manner and added to a result list in reverse order of their finishing times.
        This ordering guarantees that for every directed edge u -> v, vertex u appears before vertex v in the ordering.

        ### Explanation

        1. ** Graph Class**:
           - ** Constructor**: Initializes the graph with `V` vertices and an adjacency list.
           - ** AddEdge Method**: Adds a directed edge from vertex `v` to vertex `w`.
           - ** DFSUtil Method**: Helper function for DFS traversal.
                It recursively visits all vertices adjacent to a given vertex and pushes the vertex onto the stack after visiting all its neighbors.
           - **TopologicalSort Method**: Initiates DFS traversal for all vertices that haven't been visited yet and 
                returns a list containing the topologically sorted order.

        2. **Program Class**:
           - **Main Method**: Demonstrates the usage of the `Graph` class by creating an example graph and printing the topological sorting order.

        ### Complexity

        - **Time Complexity**: (O(V + E)), where (V) is the number of vertices and (E) is the number of edges.
                This is because each vertex and each edge is processed once during the DFS traversal.
        - **Space Complexity**: (O(V)) for the stack used for storing the topologically sorted order and (O(V + E)) for the adjacency list.

        This implementation efficiently computes the topological sorting of a Directed Acyclic Graph(DAG) using DFS. 
        It's useful for tasks such as scheduling or resolving dependencies where the order of operations is crucial and must respect the directed edges of the graph.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list
            private Stack<int> stack; // Stack to store topologically sorted vertices

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();

                stack = new Stack<int>();
            }

            // Method to add an edge into the graph
            public void AddEdge(int v, int w)
            {
                adj[v].Add(w); // Since the graph is directed
            }

            // Helper function for DFS traversal
            private void DFSUtil(int v, bool[] visited)
            {
                visited[v] = true;

                // Recur for all the vertices adjacent to this vertex
                foreach (var node in adj[v])
                {
                    if (!visited[node])
                        DFSUtil(node, visited);
                }

                // Push current vertex to stack which stores result
                stack.Push(v);
            }

            // Method to perform topological sort using DFS
            public List<int> TopologicalSort()
            {
                bool[] visited = new bool[V];

                // Initialize all vertices as not visited
                for (int i = 0; i < V; i++)
                {
                    if (!visited[i])
                        DFSUtil(i, visited);
                }

                // Create a list to store topologically sorted order
                List<int> topoOrder = new List<int>(stack);

                return topoOrder;
            }
        }

        public static void TopologicalSortUsingBFSDriver()
        {
            // Example graph
            Graph g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            List<int> topoSort = g.TopologicalSort();

            Console.WriteLine("Topological sorting of the graph using DFS:");
            foreach (var vertex in topoSort)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();
        }
    }

    public class NumberOfDistinctIslandsUsingGrid_H_10
    {
        /*
        To solve the problem of finding the number of distinct islands in a boolean 2D matrix,
        we need to identify connected components of 1s(islands) and represent each island uniquely.
        Here's how we can approach this problem using C#:

        ### Steps to Solve the Problem:

        1. ** Define the Problem Scope**: We are given a boolean grid where '1's represent land and 
        '0's represent water.Islands are clusters of connected '1's either horizontally or vertically.

        2. ** Identify Connected Components(Islands)**:
           - Use Depth-First Search(DFS) to explore and mark all cells of each island.
           - While marking cells of an island during DFS, capture the relative positions 
        of each cell in relation to the starting cell to uniquely identify the island shape.

        3. ** Normalize Island Shapes**:
           - Each island's shape can be represented uniquely based on its relative positions of cells.
        For instance, the sequence of movements (up, down, left, right) during DFS can be recorded and used to identify the island shape.

        4. ** Store and Count Distinct Islands**:
           - Use a HashSet or similar data structure to store normalized shapes of islands.
           - Count the number of unique shapes in the HashSet to determine the number of distinct islands.

        ### Explanation:

        - ** DFS Function**: `DFS` function is used to explore each island starting from a cell `(i, j)`.
        It recursively visits all connected '1's and records the relative positions of each cell with respect to the starting cell `(startX, startY)`.

        - ** Normalization**: Each island's shape is represented as a list of relative coordinates. 
        These coordinates are sorted and converted into a single string representation, which is added to the HashSet `set`.

        - ** Counting Distinct Islands**: The number of unique strings in the HashSet `set` gives us the count of distinct islands in the grid.

        ### Complexity:

        - **Time Complexity**: (O(R times C)), where (R) is the number of rows and (C) is the number of columns in the grid.
        This is because each cell is processed exactly once during DFS traversal.
  
        - **Space Complexity**: (O(R times C)) for the DFS recursion stack and the HashSet used to store island shapes.

        This approach efficiently identifies and counts distinct islands in a given boolean grid, 
        ensuring each island is uniquely represented based on its shape and relative cell positions.
        */

        public class DistinctIslands
        {
            // Function to find the number of distinct islands
            public int NumDistinctIslands(int[,] grid)
            {
                int rows = grid.GetLength(0);
                int cols = grid.GetLength(1);

                HashSet<string> set = new HashSet<string>(); // Set to store distinct island shapes

                // Direction arrays for exploring neighbors (up, down, left, right)
                int[] dx = new int[] { -1, 1, 0, 0 };
                int[] dy = new int[] { 0, 0, -1, 1 };

                // Function to perform DFS and capture island shape
                void DFS(int x, int y, int startX, int startY, List<string> shape)
                {
                    if (x < 0 || x >= rows || y < 0 || y >= cols || grid[x, y] == 0)
                        return;

                    grid[x, y] = 0; // Mark cell as visited

                    // Record relative position of current cell compared to starting cell
                    shape.Add((x - startX) + "-" + (y - startY));

                    // Recursively visit all neighboring cells
                    for (int i = 0; i < 4; i++)
                    {
                        int nx = x + dx[i];
                        int ny = y + dy[i];
                        DFS(nx, ny, startX, startY, shape);
                    }
                }

                // Traverse the grid to find islands and record their shapes
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 1)
                        {
                            List<string> shape = new List<string>();
                            DFS(i, j, i, j, shape);
                            // Normalize shape list to form a unique representation of island
                            set.Add(string.Join(" ", shape));
                        }
                    }
                }

                return set.Count;
            }
        }

        public static void NumberOfDistinctIslandsUsingGridDriver()
        {
            int[,] grid = new int[,] {
                { 1, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1 }
            };

            DistinctIslands islands = new DistinctIslands();
            int numDistinct = islands.NumDistinctIslands(grid);

            Console.WriteLine("Number of distinct islands: " + numDistinct);
        }
    }

    public class NumberOfDistinctIslandsUsingGraph_H_10
    {
        /*
        ### Explanation:

        - ** Graph Class**: Represents a graph using adjacency lists.It has methods to add edges(`AddEdge`), perform DFS(`DFS`),
        and find the number of distinct islands(`NumDistinctIslands`).

        - ** AddEdge Method**: Connects vertices based on adjacency rules(up, down, left, right).

        - ** DFS Method**: Traverses connected components starting from a given node, 
        marking all nodes of the island as visited and collecting them in a list.

        - **NumDistinctIslands Method**: Iterates through the grid, identifies islands of '1's, builds the graph, 
        and uses DFS to find connected components (islands). Each island's shape is normalized (sorted) and added to a HashSet to ensure uniqueness.

        - **NormalizeIsland Method**: Sorts the nodes list to normalize the shape of the island.

        - **Main Method**: Initializes the grid, creates an instance of the `Graph` class, and computes the number of distinct islands.

        ### Complexity:

        - ** Time Complexity**: (O(R times C + V + E)), where (R) and (C) are the number of rows and columns in the grid,
        (V) is the number of vertices(nodes), and (E) is the number of edges in the graph.
        The DFS traversal and building of the graph contribute to this complexity.

        - **Space Complexity**: (O(R times C + V + E)) for storing the grid, visited array,
        adjacency list, and DFS recursion stack.

        This implementation efficiently finds the number of distinct islands in a boolean grid using graph traversal techniques,
        ensuring each island's shape is uniquely represented and counted.
                */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Add an edge to the adjacency list
            private void AddEdge(int u, int v)
            {
                adj[u].Add(v);
                adj[v].Add(u); // Since the graph is undirected
            }

            // Function to perform DFS and mark all nodes of the current island
            private void DFS(int u, bool[] visited, List<int> nodes)
            {
                visited[u] = true;
                nodes.Add(u);

                foreach (int v in adj[u])
                {
                    if (!visited[v])
                        DFS(v, visited, nodes);
                }
            }

            // Function to find the number of distinct islands in the grid
            public int NumDistinctIslands(int[,] grid)
            {
                int rows = grid.GetLength(0);
                int cols = grid.GetLength(1);

                // Initialize graph with enough vertices
                Graph graph = new Graph(rows * cols);

                // Build the graph based on the grid
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        if (grid[i, j] == 1)
                        {
                            // Check neighbors (up, down, left, right)
                            if (i > 0 && grid[i - 1, j] == 1)
                                graph.AddEdge(i * cols + j, (i - 1) * cols + j); // Up neighbor
                            if (i < rows - 1 && grid[i + 1, j] == 1)
                                graph.AddEdge(i * cols + j, (i + 1) * cols + j); // Down neighbor
                            if (j > 0 && grid[i, j - 1] == 1)
                                graph.AddEdge(i * cols + j, i * cols + (j - 1)); // Left neighbor
                            if (j < cols - 1 && grid[i, j + 1] == 1)
                                graph.AddEdge(i * cols + j, i * cols + (j + 1)); // Right neighbor
                        }
                    }
                }

                // Perform DFS traversal to find connected components (islands)
                bool[] visited = new bool[rows * cols];
                HashSet<List<int>> distinctIslands = new HashSet<List<int>>();

                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        if (grid[i, j] == 1 && !visited[i * cols + j])
                        {
                            List<int> nodes = new List<int>();
                            graph.DFS(i * cols + j, visited, nodes);

                            // Normalize the island shape
                            NormalizeIsland(nodes);

                            // Add the normalized island to the set
                            distinctIslands.Add(nodes);
                        }
                    }
                }

                // Return the number of distinct islands
                return distinctIslands.Count;
            }

            // Helper function to normalize the island shape
            private void NormalizeIsland(List<int> nodes)
            {
                // Sort the nodes to normalize the shape
                nodes.Sort();
            }
        }

        public static void NumberOfDistinctIslandsUsingGraphDriver()
        {
            int[,] grid = new int[,] {
                { 1, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1 }
            };

            Graph graph = new Graph(grid.GetLength(0) * grid.GetLength(1));
            int numDistinctIslands = graph.NumDistinctIslands(grid);

            Console.WriteLine("Number of distinct islands: " + numDistinctIslands);
        }
    }

    /* Bipartite graph -
     In graph theory, a bipartite graph is a graph whose vertices can be divided into two disjoint and 
     independent sets ( U ) and ( V ) such that every edge connects a vertex in ( U ) to a vertex in ( V ). 
     In simpler terms, a bipartite graph is a graph that can be colored using two colors such that no two adjacent vertices have the same color.

        ### Properties of Bipartite Graphs:

        1. **Vertex Partition**: A bipartite graph ( G = (V, E) ) can be partitioned into two sets ( U ) and ( V ) 
            such that ( U cup V = V ) and ( U cap V = emptyset ).
   
        2. **Edge Set**: Every edge in a bipartite graph connects a vertex in ( U ) to a vertex in ( V ).

        3. **No Odd Cycles**: Bipartite graphs do not contain any odd-length cycles. This is because in a bipartite graph,
            if you start at any vertex and traverse an edge, you move from one set (say ( U )) to the other set (say ( V )),
            and subsequent traversal would alternate between ( U ) and ( V ), ensuring that the cycle length is even.

        ### Testing for Bipartiteness:

        To determine if a graph is bipartite, we can use various algorithms such as BFS (Breadth-First Search) or
            DFS (Depth-First Search) with a two-coloring approach:
        - **BFS Approach**: Use a queue to perform BFS. Start coloring the source vertex with one color (say 1),
            then color its neighbors with the opposite color (say -1), and continue this process while ensuring that no two adjacent vertices have the same color.
        - **DFS Approach**: Use recursion to perform DFS. Start coloring the current vertex with one color, 
            then recursively color its neighbors with the opposite color, and backtrack if a conflict is found (i.e., two adjacent vertices have the same color).

        If during the coloring process, you find that two adjacent vertices have the same color, then the graph is not bipartite.

        ### Applications:

        Bipartite graphs have applications in various fields such as:
        - **Matching Problems**: In bipartite graphs, a matching can be found efficiently using algorithms like Hopcroft-Karp algorithm.
        - **Graph Coloring**: Bipartite graphs are the simplest class of graphs for which the chromatic number is 2.
        - **Networks and Communications**: They are used to model interactions between different types of entities where there are constraints on the relationships.

        Understanding bipartite graphs and being able to identify them is fundamental in graph theory 
            and has practical applications in solving real-world problems efficiently.
    */

    public class CheckBipartiteInGraphUsingBFS_M_11
    {
        /*
         * bipartite - 
         A bipartite graph is a graph in which the vertices can be divided into two disjoint sets, 
        such that no two vertices within the same set are adjacent.In other words,
        it is a graph in which every edge connects a vertex of one set to a vertex of the other set.

        To determine if a graph is bipartite using BFS (Breadth-First Search), we can use a two-coloring approach.Here's how you can implement it in C#:

        ### Explanation:

        - ** Graph Class**: Represents a graph using adjacency lists.It has methods to add edges(`AddEdge`) and 
        check if the graph is bipartite(`IsBipartite`).

        - ** AddEdge Method**: Connects vertices based on adjacency rules(undirected graph).

        - ** IsBipartite Method**: Initializes a color array to keep track of the two colors(-1 and 1). 
        It iterates through each component of the graph and applies BFS to check if the graph can be colored with 
        two colors such that no two adjacent vertices have the same color.

        - **BFSIsBipartite Method**: Performs BFS starting from a source vertex `src`.
        It colors the source vertex with the first color (1) and its neighbors with the opposite color(-1).
        It checks if adjacent vertices have the same color during traversal.

        - **Main Method**: Initializes a sample graph and checks if it is bipartite using the `IsBipartite` method of the `Graph` class.

        ### Complexity:

        - ** Time Complexity**: (O(V + E)), where (V) is the number of vertices and (E) is the number of edges in the graph.
        BFS runs in (O(V + E)) time.

        - ** Space Complexity**: (O(V)) for the color array and (O(V + E)) for the adjacency list and BFS queue.

        This implementation efficiently determines whether a given undirected graph is bipartite using
        BFS and a two-coloring approach.It ensures that no two adjacent vertices have the same color,
        which is a fundamental property of bipartite graphs.

        */

    public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Add an edge to the adjacency list
            public void AddEdge(int u, int v)
            {
                adj[u].Add(v);
                adj[v].Add(u); // Since the graph is undirected
            }

            // Function to check if the graph is bipartite using BFS
            public bool IsBipartite()
            {
                int[] color = new int[V]; // 0 for uncolored, 1 and -1 for two colors
                Array.Fill(color, 0);

                // Traverse each component of the graph
                for (int i = 0; i < V; ++i)
                {
                    if (color[i] == 0) // If not colored
                    {
                        if (!BFSIsBipartite(i, color))
                            return false;
                    }
                }

                return true;
            }

            // Helper function for BFS to check bipartiteness
            private bool BFSIsBipartite(int src, int[] color)
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(src);
                color[src] = 1; // Color the source with first color

                while (queue.Count > 0)
                {
                    int u = queue.Dequeue();

                    foreach (int v in adj[u])
                    {
                        if (color[v] == 0) // If not colored
                        {
                            color[v] = -color[u]; // Color with opposite color of u
                            queue.Enqueue(v);
                        }
                        else if (color[v] == color[u]) // If adjacent vertices have same color
                        {
                            return false; // Not bipartite
                        }
                    }
                }

                return true; // Bipartite
            }
        }

        public static void CheckBipartiteInGraphUsingBFSDriver()
        {
            int V = 6; // Number of vertices
            Graph graph = new Graph(V);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);

            bool isBipartite = graph.IsBipartite();
            Console.WriteLine("Is the graph bipartite using BFS ? " + isBipartite);
        }
    }

    public class CheckBipartiteInGraphUsingDFS_M_12
    {
        /*
        bipartite - 
         A bipartite graph is a graph in which the vertices can be divided into two disjoint sets, 
        such that no two vertices within the same set are adjacent.In other words,
        it is a graph in which every edge connects a vertex of one set to a vertex of the other set.

        To check if a graph is bipartite using Depth-First Search(DFS), we can use a two-coloring approach similar to the BFS solution.
        Here's how you can implement it in C#:

        ### Explanation:

        - ** Graph Class**: Represents a graph using adjacency lists.It has methods to add edges(`AddEdge`) 
        and check if the graph is bipartite(`IsBipartite`).

        - ** AddEdge Method**: Connects vertices based on adjacency rules(undirected graph).

        - ** IsBipartite Method**: Initializes a color array to keep track of the two colors(-1 and 1). 
        It iterates through each component of the graph and applies DFS to check if the graph
        can be colored with two colors such that no two adjacent vertices have the same color.

        - **DFSIsBipartite Method**: Performs DFS starting from a vertex `u`. 
        It colors the current vertex with the first color (1) and its neighbors with the opposite color(-1). It checks if adjacent vertices have the same color during traversal.

        - **Main Method**: Initializes a sample graph and checks if it is bipartite using the `IsBipartite` method of the `Graph` class.

        ### Complexity:

        - ** Time Complexity**: (O(V + E)), where (V) is the number of vertices and (E) is the number of edges in the graph.
        DFS runs in (O(V + E)) time.

        - ** Space Complexity**: (O(V)) for the color array and (O(V + E)) for the adjacency list and DFS recursion stack.

        This implementation efficiently determines whether a given undirected graph is bipartite using DFS and a two-coloring approach.
        It ensures that no two adjacent vertices have the same color, which is a fundamental property of bipartite graphs.

        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Add an edge to the adjacency list
            public void AddEdge(int u, int v)
            {
                adj[u].Add(v);
                adj[v].Add(u); // Since the graph is undirected
            }

            // Function to check if the graph is bipartite using DFS
            public bool IsBipartite()
            {
                int[] color = new int[V]; // 0 for uncolored, 1 and -1 for two colors
                Array.Fill(color, 0);

                // Traverse each component of the graph
                for (int i = 0; i < V; ++i)
                {
                    if (color[i] == 0) // If not colored
                    {
                        if (!DFSIsBipartite(i, color))
                            return false;
                    }
                }

                return true;
            }

            // Helper function for DFS to check bipartiteness
            private bool DFSIsBipartite(int u, int[] color)
            {
                if (color[u] == 0)
                    color[u] = 1; // Color the current vertex with first color

                foreach (int v in adj[u])
                {
                    if (color[v] == 0) // If not colored
                    {
                        color[v] = -color[u]; // Color with opposite color of u
                        if (!DFSIsBipartite(v, color))
                            return false;
                    }
                    else if (color[v] == color[u]) // If adjacent vertices have same color
                    {
                        return false; // Not bipartite
                    }
                }

                return true; // Bipartite
            }
        }

        public static void CheckBipartiteInGraphUsingDFSDriver()
        {
            int V = 6; // Number of vertices
            Graph graph = new Graph(V);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);

            bool isBipartite = graph.IsBipartite();
            Console.WriteLine("Is the graph bipartite using DFS ? " + isBipartite);
        }
    }

    public class KosarajuAlgorithmToFindStronglyConnectedComponentOfDirectedGraph_H_13
    {
        /*
        Kosaraju's algorithm is a popular algorithm to find the strongly connected components (SCCs) of a directed graph. 
        A strongly connected component of a directed graph is a maximal strongly connected subgraph. 
        Kosaraju's algorithm runs in (O(V + E)) time, where (V) is the number of vertices and (E) is the number of edges in the graph.

        Here is a step-by-step explanation of the algorithm along with its C# implementation:

        ### Steps of Kosaraju's Algorithm

        1. **Perform a DFS on the original graph**: Create an empty stack and perform a DFS traversal of the graph, 
        pushing each vertex onto the stack upon completion of the DFS for that vertex. 
        This ensures that vertices are pushed onto the stack in the order of their finishing times.

        2. **Transpose the graph**: Reverse the direction of all edges to get the transpose of the original graph.

        3. **Perform a DFS on the transposed graph**: Pop vertices one by one from the stack and perform a DFS on the transposed graph,
        starting from each popped vertex.Each DFS traversal on the transposed graph will give you one SCC.

        ### Explanation:

        1. ** Graph Class**: Represents a graph using an adjacency list and provides methods to add edges, transpose the graph, and perform DFS.

        2. **DFSUtil Method**: Performs a depth-first search from a given vertex and fills the stack with vertices in the order of their finishing times.

        3. **GetTranspose Method**: Generates the transpose of the graph by reversing the direction of all edges.

        4. **PrintSCCs Method**: Implements Kosaraju's algorithm to find and print all strongly connected components in the graph.

        5. **Main Method**: Creates a sample graph, adds edges, and calls the method to print SCCs.

        ### Complexity:

        - **Time Complexity**: (O(V + E)), as we perform DFS traversals twice, each taking (O(V + E)) time.
        - ** Space Complexity**: (O(V)) for the stack and visited array.

        Kosaraju's algorithm efficiently finds all SCCs in a directed graph using two DFS traversals and graph transposition.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<int>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<int>();
            }

            // Add an edge to the graph
            public void AddEdge(int v, int w)
            {
                adj[v].Add(w);
            }

            // A recursive function to perform DFS starting from vertex v
            public void DFSUtil(int v, bool[] visited, Stack<int> stack)
            {
                visited[v] = true;
                foreach (int i in adj[v])
                    if (!visited[i])
                        DFSUtil(i, visited, stack);
                stack.Push(v);
            }

            // Function to transpose the graph
            public Graph GetTranspose()
            {
                Graph g = new Graph(V);
                for (int v = 0; v < V; v++)
                {
                    foreach (int i in adj[v])
                        g.adj[i].Add(v);
                }
                return g;
            }

            // The main function that finds and prints all SCCs
            public void PrintSCCs()
            {
                Stack<int> stack = new Stack<int>();

                // Mark all vertices as not visited (for the first DFS)
                bool[] visited = new bool[V];
                for (int i = 0; i < V; i++)
                    visited[i] = false;

                // Fill vertices in stack according to their finishing times
                for (int i = 0; i < V; i++)
                    if (visited[i] == false)
                        PrintDFSUtil(i, visited, stack);

                // Get the transpose of the graph
                Graph gr = GetTranspose();

                // Mark all vertices as not visited (for the second DFS)
                for (int i = 0; i < V; i++)
                    visited[i] = false;

                // Now process all vertices in order defined by Stack
                while (stack.Count > 0)
                {
                    int v = stack.Pop();
                    if (!visited[v])
                    {
                        gr.DFSUtil(v, visited, new Stack<int>());
                        Console.WriteLine();
                    }
                }
            }

            // Function to perform DFS and print the strongly connected component
            public void PrintDFSUtil(int v, bool[] visited, Stack<int> stack)
            {
                visited[v] = true;
                Console.Write(v + " ");
                foreach (int i in adj[v])
                    if (!visited[i])
                        PrintDFSUtil(i, visited, stack);
            }
        }

        public static void KosarajuAlgorithmToFindStronglyConnectedComponentOfDirectedGraphDriver()
        {
            Graph g = new Graph(5);
            g.AddEdge(1, 0);
            g.AddEdge(0, 2);
            g.AddEdge(2, 1);
            g.AddEdge(0, 3);
            g.AddEdge(3, 4);

            Console.WriteLine("Strongly Connected Components in the given graph:");
            g.PrintSCCs();
        }
    }

    public class DijkstraAlgorithmPrintShortestPath_H_14
    {
        /*
        Dijkstra's algorithm is used to find the shortest path from a source vertex to all other vertices in a graph with non-negative edge weights.
        Here is a C# implementation of Dijkstra's algorithm to print the shortest path.

        ### Steps of Dijkstra's Algorithm

        1. **Initialization**:
           - Create a distance array `dist[]` and initialize all distances as infinite(except the distance to the source vertex which is 0).
           - Create a priority queue to store vertices based on their distances from the source.

        2. **Relaxation**:
           - Extract the vertex with the minimum distance from the priority queue.
           - Update the distance of all its adjacent vertices.

        3. **Repeat**:
           - Repeat the relaxation process until the priority queue is empty.

        4. **Path Reconstruction**:
           - Maintain a parent array to store the shortest path tree.
           - Backtrack from the destination to the source using the parent array to reconstruct the path.

        ### Explanation:

        1. ** Graph Class**: This class contains methods to add edges and find the shortest path using Dijkstra's algorithm.

        2. ** AddEdge Method**: Adds an edge to the adjacency list.

        3. ** PrintShortestPath Method**:
           - Initializes the distance array, parent array, and priority queue.
           - Performs relaxation for each vertex.
           - Uses a priority queue to ensure the vertex with the smallest distance is processed first.

        4. **PrintPath Method**: Recursively prints the path from the source to the target using the parent array.

        5. **Program Class**: Creates a graph, adds edges, and calls the method to print the shortest path from a given source to a target vertex.

        ### Complexity:

        - **Time Complexity**: (O((V + E) log V)) due to the priority queue operations.
        - **Space Complexity**: (O(V + E)) for storing the graph and additional data structures.

        This implementation uses a priority queue to efficiently find the shortest paths in the graph and prints the path along with the shortest distance.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<Tuple<int, int>>[] adj; // Adjacency list

            public Graph(int V)
            {
                this.V = V;
                adj = new List<Tuple<int, int>>[V];
                for (int i = 0; i < V; ++i)
                    adj[i] = new List<Tuple<int, int>>();
            }

            // Function to add an edge to the graph
            public void AddEdge(int u, int v, int weight)
            {
                adj[u].Add(Tuple.Create(v, weight));
                adj[v].Add(Tuple.Create(u, weight)); // Assuming undirected graph
            }

            // Function to print the shortest path from source to target
            public void PrintShortestPath(int src, int target)
            {
                int[] dist = new int[V];
                int[] parent = new int[V];
                bool[] visited = new bool[V];
                PriorityQueue<Tuple<int, int>, int> pq = new PriorityQueue<Tuple<int, int>, int>();

                for (int i = 0; i < V; i++)
                {
                    dist[i] = int.MaxValue;
                    parent[i] = -1;
                }
                dist[src] = 0;

                pq.Enqueue(Tuple.Create(src, 0), 0);

                while (pq.Count > 0)
                {
                    var node = pq.Dequeue();
                    int u = node.Item1;

                    if (visited[u])
                        continue;

                    visited[u] = true;

                    foreach (var neighbor in adj[u])
                    {
                        int v = neighbor.Item1;
                        int weight = neighbor.Item2;

                        if (!visited[v] && dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                        {
                            dist[v] = dist[u] + weight;
                            pq.Enqueue(Tuple.Create(v, dist[v]), dist[v]);
                            parent[v] = u;
                        }
                    }
                }

                PrintPath(parent, target);
                Console.WriteLine("\nShortest Path Distance: " + dist[target]);
            }

            // Function to print the path from source to target
            private void PrintPath(int[] parent, int j)
            {
                if (parent[j] == -1)
                {
                    Console.Write(j + " ");
                    return;
                }

                PrintPath(parent, parent[j]);
                Console.Write(j + " ");
            }
        }

        public static void DijkstraAlgorithmPrintShortestPathDriver()
        {
            Graph g = new Graph(9);
            g.AddEdge(0, 1, 4);
            g.AddEdge(0, 7, 8);
            g.AddEdge(1, 2, 8);
            g.AddEdge(1, 7, 11);
            g.AddEdge(2, 3, 7);
            g.AddEdge(2, 8, 2);
            g.AddEdge(2, 5, 4);
            g.AddEdge(3, 4, 9);
            g.AddEdge(3, 5, 14);
            g.AddEdge(4, 5, 10);
            g.AddEdge(5, 6, 2);
            g.AddEdge(6, 7, 1);
            g.AddEdge(6, 8, 6);
            g.AddEdge(7, 8, 7);

            int src = 0, target = 4;
            Console.WriteLine("Shortest path from " + src + " to " + target + ":");
            g.PrintShortestPath(src, target);
        }

    }

    public class BellmanFordAlgorithmmPrintShortestPath_H_15
    {
        /*
        The Bellman-Ford algorithm is used to find the shortest path from a single source vertex to all other vertices in a weighted graph.
        Unlike Dijkstra's algorithm, Bellman-Ford can handle negative weight edges and detect negative weight cycles.

        ### Steps of Bellman-Ford Algorithm

        1. ** Initialization**:
           - Initialize the distance to the source vertex as 0 and all other vertices as infinite.
           - Initialize the predecessor of each vertex as `null`.

        2. ** Relaxation**:
           - Repeat |V|-1 times(where |V| is the number of vertices) :
             - For each edge(u, v) with weight w, if `dist[u] + w<dist[v]`, then update `dist[v] = dist[u] + w`.

        3. **Check for Negative Weight Cycles**:
           - For each edge (u, v) with weight w, if `dist[u] + w<dist[v]`, then a negative weight cycle exists.

        ### Explanation:

        1. ** Graph Class**:
           - Contains the number of vertices and a list of edges.
           - `AddEdge` method adds edges to the graph.
           - `BellmanFord` method implements the Bellman-Ford algorithm.

        2. **BellmanFord Method**:
           - Initializes distances and predecessors.
           - Relaxes all edges |V|-1 times.
           - Checks for negative weight cycles.

        3. **PrintSolution and PrintPath Methods**:
           - `PrintSolution` prints the distances from the source to all vertices and their paths.
           - `PrintPath` recursively prints the path from the source to a given vertex.

        ### Complexity:

        - **Time Complexity**: (O(V cdot E)), where (V) is the number of vertices and (E) is the number of edges.
        - **Space Complexity**: (O(V + E)) for storing the graph and additional data structures.

        This implementation ensures the shortest paths are found even if there are negative weights,
            and it correctly identifies if a negative weight cycle exists in the graph.
        */

        public class Graph
        {
            private int V; // Number of vertices
            private List<Tuple<int, int, int>> edges; // List of edges (u, v, w)

            public Graph(int V)
            {
                this.V = V;
                edges = new List<Tuple<int, int, int>>();
            }

            // Function to add an edge to the graph
            public void AddEdge(int u, int v, int weight)
            {
                edges.Add(new Tuple<int, int, int>(u, v, weight));
            }

            // Function to find the shortest path from source to all vertices using Bellman-Ford algorithm
            public void BellmanFord(int src)
            {
                int[] dist = new int[V];
                int[] pred = new int[V];

                // Step 1: Initialize distances from src to all other vertices as INFINITE
                for (int i = 0; i < V; ++i)
                {
                    dist[i] = int.MaxValue;
                    pred[i] = -1;
                }
                dist[src] = 0;

                // Step 2: Relax all edges |V| - 1 times
                for (int i = 1; i < V; ++i)
                {
                    foreach (var edge in edges)
                    {
                        int u = edge.Item1;
                        int v = edge.Item2;
                        int weight = edge.Item3;
                        if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                        {
                            dist[v] = dist[u] + weight;
                            pred[v] = u;
                        }
                    }
                }

                // Step 3: Check for negative-weight cycles
                foreach (var edge in edges)
                {
                    int u = edge.Item1;
                    int v = edge.Item2;
                    int weight = edge.Item3;
                    if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                    {
                        Console.WriteLine("Graph contains negative weight cycle");
                        return;
                    }
                }

                // Print the distance array
                PrintSolution(dist, pred, src);
            }

            // Function to print the distance and predecessor arrays
            private void PrintSolution(int[] dist, int[] pred, int src)
            {
                Console.WriteLine("Vertex Distance from Source and Path:");
                for (int i = 0; i < V; ++i)
                {
                    Console.Write("Vertex " + i + " Distance: " + dist[i] + " Path: ");
                    PrintPath(pred, i);
                    Console.WriteLine();
                }
            }

            // Function to print the path from source to a given vertex
            private void PrintPath(int[] pred, int j)
            {
                if (pred[j] == -1)
                {
                    Console.Write(j + " ");
                    return;
                }
                PrintPath(pred, pred[j]);
                Console.Write(j + " ");
            }
        }
        public static void BellmanFordAlgorithmmPrintShortestPathDriver()
        {
            int V = 5; // Number of vertices
            Graph graph = new Graph(V);

            // Add edges to the graph
            graph.AddEdge(0, 1, -1);
            graph.AddEdge(0, 2, 4);
            graph.AddEdge(1, 2, 3);
            graph.AddEdge(1, 3, 2);
            graph.AddEdge(1, 4, 2);
            graph.AddEdge(3, 2, 5);
            graph.AddEdge(3, 1, 1);
            graph.AddEdge(4, 3, -3);

            int src = 0;
            graph.BellmanFord(src);
        }
    }

    public class FloydWarshallAlgorithmPrintShortestPath_H_16
    {
        /*
        The Floyd-Warshall algorithm is a graph analysis algorithm for finding shortest paths in a weighted graph with positive or 
        negative edge weights(but with no negative cycles). 
        The algorithm works by considering all pairs of vertices and systematically improving the path between each pair.

        ### Algorithm Steps

        1. **Initialization**:
           - Create a distance matrix `dist` where `dist[i][j]` is the weight of the edge from vertex `i` to vertex `j`.
           - If there is no direct edge between `i` and `j`, initialize `dist[i][j]` to infinity(`INF`).

        2. **Relaxation**:
           - For each vertex `k` as an intermediate vertex:
             - For each pair of vertices `(i, j)`, update `dist[i][j]` to be the minimum of `dist[i][j]` and `dist[i][k] + dist[k][j]`.

        3. **Negative Cycle Detection**:
           - After running the algorithm, if any `dist[i][i]` is negative, then the graph contains a negative cycle.

        ### Explanation:

        1. ** Graph Initialization**:
           - The input graph is represented as an adjacency matrix where `graph[i][j]` is the weight of the edge from vertex `i` to vertex `j`. 
        If there is no direct edge between vertices `i` and `j`, it is initialized to `INF`.

        2. ** Floyd-Warshall Algorithm**:
           - The distance matrix `dist` is initialized to be the same as the input graph.
           - For each intermediate vertex `k`, update the distance matrix for all pairs of vertices `(i, j)`.

        3. ** Print Solution**:
           - The `PrintSolution` method prints the shortest distance between every pair of vertices.

        ### Complexity:

        - **Time Complexity**: (O(V^3)), where (V) is the number of vertices.
        - **Space Complexity**: (O(V^2)) for the distance matrix.

        The Floyd-Warshall algorithm is effective for dense graphs where the number of edges is close to (V^2), 
        and it can handle negative weights(but not negative cycles).
                */

        public static void FloydWarshallAlgorithm(int[,] graph, int V)
        {
            int[,] dist = new int[V, V];

            // Initialize the solution matrix same as input graph matrix
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    dist[i, j] = graph[i, j];
                }
            }

            // Add all vertices one by one to the set of intermediate vertices
            for (int k = 0; k < V; k++)
            {
                // Pick all vertices as source one by one
                for (int i = 0; i < V; i++)
                {
                    // Pick all vertices as destination for the above picked source
                    for (int j = 0; j < V; j++)
                    {
                        // If vertex k is on the shortest path from i to j, then update the value of dist[i, j]
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue &&
                            dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            PrintSolution(dist, V);
        }

        public static void PrintSolution(int[,] dist, int V)
        {
            Console.WriteLine("The following matrix shows the shortest distances between every pair of vertices:");
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (dist[i, j] == int.MaxValue)
                    {
                        Console.Write("INF ");
                    }
                    else
                    {
                        Console.Write(dist[i, j] + "   ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void FloydWarshallAlgorithmPrintShortestPathDriver()
        {
            int INF = int.MaxValue;
            int[,] graph = {
                    {0, 3, INF, 5},
                    {2, 0, INF, 4},
                    {INF, 1, 0, INF},
                    {INF, INF, 2, 0}
            };

            int V = graph.GetLength(0);
            FloydWarshallAlgorithm(graph, V);
        }
    }

    public class PrimsAlgorithmMinimumSpanningTree_H_17
    {
        /*
        Prim's algorithm is a greedy algorithm that finds a minimum spanning tree (MST) for a connected weighted graph.
        This means it finds a subset of the edges that forms a tree including every vertex, 
        where the total weight of all the edges in the tree is minimized.

        ### Algorithm Steps

        1. ** Initialize**:
           - Start with an arbitrary vertex and add it to the MST.
           - Initialize a set to keep track of vertices included in the MST.
           - Initialize an array to store the minimum weights to connect each vertex to the MST.
           - Initialize a priority queue to store vertices based on their minimum weights.

        2. **Process Vertices**:
           - While there are vertices not yet included in the MST:
             - Extract the vertex with the minimum weight from the priority queue.
             - Add this vertex to the MST.
             - For each adjacent vertex not yet included in the MST,
        if the weight of the edge connecting to this vertex is less than the current minimum weight for this vertex,
        update the minimum weight and add it to the priority queue.

        3. **Output**:
           - The edges in the MST and their total weight.

        ### Explanation

        1. ** Graph Initialization**:
           - The graph is represented as an adjacency matrix where `graph[i, j]` is the weight of the edge between vertex `i` and vertex `j`.

        2. ** Prim's MST**:
           - The `PrimMST` function initializes arrays to store the MST structure, key values, and the MST set.
           - It starts with the first vertex and iteratively includes the minimum weight edge connected to the growing MST.
           - The `MinKey` function helps select the next vertex to include in the MST.

        3. **Print MST**:
           - The `PrintMST` function prints the edges included in the MST along with their weights.

        ### Complexity

        - **Time Complexity**: (O(V^2)) for the dense graph representation using the adjacency matrix.
        - **Space Complexity**: (O(V)) for the arrays used to store the MST, key values, and MST set.

        Prim's algorithm is efficient for dense graphs and ensures that the minimum spanning tree is found with a greedy approach.
        */

        public static void PrimMST(int[,] graph, int V)
        {
            int[] parent = new int[V]; // Array to store constructed MST
            int[] key = new int[V]; // Key values used to pick minimum weight edge in cut
            bool[] mstSet = new bool[V]; // To represent set of vertices not yet included in MST

            // Initialize all keys as INFINITE
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // Always include first 1st vertex in MST.
            key[0] = 0; // Make key 0 so that this vertex is picked as first vertex
            parent[0] = -1; // First node is always root of MST

            // The MST will have V vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum key vertex from the set of vertices not yet included in MST
                int u = MinKey(key, mstSet, V);

                // Add the picked vertex to the MST Set
                mstSet[u] = true;

                // Update key value and parent index of the adjacent vertices of the picked vertex.
                // Consider only those vertices which are not yet included in MST
                for (int v = 0; v < V; v++)
                {
                    // graph[u, v] is non zero only for adjacent vertices of m
                    // mstSet[v] is false for vertices not yet included in MST
                    // Update the key only if graph[u, v] is smaller than key[v]
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            PrintMST(parent, graph, V);
        }

        public static int MinKey(int[] key, bool[] mstSet, int V)
        {
            // Initialize min value
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }

            return minIndex;
        }

        public static void PrintMST(int[] parent, int[,] graph, int V)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
        }

        public static void PrimsAlgorithmMinimumSpanningTreeDriver()
        {
            int[,] graph = {
                { 0, 2, 0, 6, 0 },
                { 2, 0, 3, 8, 5 },
                { 0, 3, 0, 0, 7 },
                { 6, 8, 0, 0, 9 },
                { 0, 5, 7, 9, 0 }
            };

            int V = graph.GetLength(0);
            PrimMST(graph, V);
        }
    }

    public class KruskalAlgorithmMinimumSpanningTree_H_18
    {
        /*
        Kruskal's algorithm is another popular algorithm for finding the Minimum Spanning Tree (MST) of a connected, weighted graph. 
        Unlike Prim's algorithm, which grows the MST one vertex at a time, 
        Kruskal's algorithm grows the MST by adding the smallest edges one by one, ensuring no cycles are formed.

        ### Algorithm Steps

        1. ** Sort** all the edges in non-decreasing order of their weight.
        2. ** Initialize** a subset for each vertex, initially each subset contains only one vertex.
        3. **Process** the smallest edge and check if it forms a cycle with the MST formed so far.
           - If it does not form a cycle, include this edge in the MST.
           - If it forms a cycle, discard this edge.
        4. **Repeat** step 3 until there are (V-1) edges in the MST.

        ### Explanation

        1. ** Edge Class**:
           - Represents an edge with a source, destination, and weight.
           - Implements `IComparable` to allow sorting edges by weight.

        2. **Subset Class**:
           - Represents subsets for union-find operations.
           - Contains parent and rank.

        3. **Initialization**:
           - The graph is initialized with the number of vertices and edges.
           - Each edge is initialized with its source, destination, and weight.

        4. **Union-Find Operations**:
           - `Find`: Finds the root of a subset.
           - `Union`: Unites two subsets into a single subset based on rank.

        5. **Kruskal's MST**:
           - Sorts all edges in non-decreasing order of their weight.
           - Uses union-find to ensure no cycles are formed when adding edges to the MST.
           - Prints the MST and its minimum cost.

        ### Complexity

        - **Time Complexity**: (O(E log E + E log V))
          - Sorting the edges takes (O(E log E)).
          - Union-Find operations take (O(log V)) per operation.
        - **Space Complexity**: (O(V + E)) for storing edges and subsets.

        Kruskal's algorithm is efficient for sparse graphs and ensures that the minimum spanning tree is
        found by processing the smallest edges first, using union-find to manage cycles.
        */


        public class Edge : IComparable<Edge>
        {
            public int Source, Destination, Weight;
            public int CompareTo(Edge compareEdge)
            {
                return this.Weight - compareEdge.Weight;
            }
        }

        public class Subset
        {
            public int Parent, Rank;
        }

        public int Vertices, Edges;
        public Edge[] edge;

        public KruskalAlgorithmMinimumSpanningTree_H_18(int vertices, int edges)
        {
            Vertices = vertices;
            Edges = edges;
            edge = new Edge[edges];
            for (int i = 0; i < edges; ++i)
                edge[i] = new Edge();
        }

        public int Find(Subset[] subsets, int i)
        {
            if (subsets[i].Parent != i)
                subsets[i].Parent = Find(subsets, subsets[i].Parent);
            return subsets[i].Parent;
        }

        public void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].Rank < subsets[yroot].Rank)
                subsets[xroot].Parent = yroot;
            else if (subsets[xroot].Rank > subsets[yroot].Rank)
                subsets[yroot].Parent = xroot;
            else
            {
                subsets[yroot].Parent = xroot;
                subsets[xroot].Rank++;
            }
        }

        public void KruskalMST()
        {
            Edge[] result = new Edge[Vertices];
            int e = 0;
            int i = 0;
            for (i = 0; i < Vertices; ++i)
                result[i] = new Edge();

            Array.Sort(edge);

            Subset[] subsets = new Subset[Vertices];
            for (i = 0; i < Vertices; ++i)
                subsets[i] = new Subset();

            for (int v = 0; v < Vertices; ++v)
            {
                subsets[v].Parent = v;
                subsets[v].Rank = 0;
            }

            i = 0;

            while (e < Vertices - 1)
            {
                Edge nextEdge = edge[i++];
                int x = Find(subsets, nextEdge.Source);
                int y = Find(subsets, nextEdge.Destination);

                if (x != y)
                {
                    result[e++] = nextEdge;
                    Union(subsets, x, y);
                }
            }

            Console.WriteLine("Following are the edges in the constructed MST");
            int minimumCost = 0;
            for (i = 0; i < e; ++i)
            {
                Console.WriteLine(result[i].Source + " -- " + result[i].Destination + " == " + result[i].Weight);
                minimumCost += result[i].Weight;
            }
            Console.WriteLine("Minimum Cost Spanning Tree: " + minimumCost);
        }

        public static void KruskalAlgorithmMinimumSpanningTreeDriver()
        {
            int vertices = 4;
            int edges = 5;
            KruskalAlgorithmMinimumSpanningTree_H_18 graph = new KruskalAlgorithmMinimumSpanningTree_H_18(vertices, edges);

            graph.edge[0].Source = 0;
            graph.edge[0].Destination = 1;
            graph.edge[0].Weight = 10;

            graph.edge[1].Source = 0;
            graph.edge[1].Destination = 2;
            graph.edge[1].Weight = 6;

            graph.edge[2].Source = 0;
            graph.edge[2].Destination = 3;
            graph.edge[2].Weight = 5;

            graph.edge[3].Source = 1;
            graph.edge[3].Destination = 3;
            graph.edge[3].Weight = 15;

            graph.edge[4].Source = 2;
            graph.edge[4].Destination = 3;
            graph.edge[4].Weight = 4;

            graph.KruskalMST();
        }
    }

}
