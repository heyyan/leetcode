using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class CloneGraph
    {
        // Given a referenceof a node in a connected undirected graph
        // return a deep copy (clone) of the graph
        // Each node in the graph contains a value and a list (list[Node] of its neighbors
        public void RunSolution()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            node1.neighbors.Add(node2);
            node1.neighbors.Add(node3);
            node2.neighbors.Add(node1);
            node2.neighbors.Add(node4);
            node3.neighbors.Add(node1);
            node3.neighbors.Add(node4);
            node4.neighbors.Add(node3);
            node4.neighbors.Add(node2);
            var result = CloneGraph1(node1);
        }

        private Node GetCloneGraph(Node root)
        {
            Dictionary<Node, Node> oldToNew = new Dictionary<Node, Node>();

            Node Dfs(Node node)
            {
                if (oldToNew.ContainsKey(node))
                {
                    return oldToNew[node];
                }
                var copy = new Node(node.val);
                oldToNew.Add(node, copy);
                foreach (var nei in node.neighbors)
                {
                    copy.neighbors.Add(Dfs(nei));
                }
                return copy;
            }
            return Dfs(root);
        }

        private Node CloneGraph1(Node node)
        {
            if(node == null) return null;
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            Node newNode = new Node(node.val);
            map[node] = newNode;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                Node curr = queue.Dequeue();
                List<Node> newNeighbors = map[curr].neighbors;

                foreach (Node n in curr.neighbors)
                {
                    if (!map.ContainsKey(n))
                    {
                        Node tmp = new Node(n.val);
                        map[n] = tmp;
                        queue.Enqueue(n);
                    }
                    newNeighbors.Add(map[n]);
                }
            }

            return newNode;
        }

        class Node
        {
            public int val { get; set; }
            public List<Node> neighbors { get; set; }
            public Node(int val)
            {
                this.val = val;
                neighbors = new List<Node>();
            }
        }
    }
}
