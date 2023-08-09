using System.Collections.Generic;

namespace LeetCode;

public class P133_CloneGraph
{
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

    public Node? CloneGraph(Node? node)
    {
        // A null node indicates an empty graph
        if (node == null)
        {
            return null;
        }

        // Clone this node and it's neighbors, keeping track of new nodes as they are created
        Node head = new(node.val);
        Dictionary<int, Node> clonedNodes = new() { { node.val, head } };
        Queue<Node> nodesToClone = new(new[] { node });

        while (nodesToClone.TryDequeue(out Node? oldNode))
        {
            Node clonedNode = clonedNodes[oldNode.val];

            // Clone this node's neighbors, and add these clones to the cloned node's list
            foreach (Node oldNeighborNode in oldNode.neighbors)
            {
                // If this neighbor node hasn't been cloned yet, create an empty clone and enqueue it for cloning
                if (!clonedNodes.TryGetValue(oldNeighborNode.val, out Node? clonedNeighborNode))
                {
                    clonedNeighborNode = new Node(oldNeighborNode.val);
                    clonedNodes.Add(clonedNeighborNode.val, clonedNeighborNode);
                    nodesToClone.Enqueue(oldNeighborNode);
                }

                clonedNode.neighbors.Add(clonedNeighborNode);
            }
        }

        return head;
    }
}
