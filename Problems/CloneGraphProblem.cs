using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class CloneGraphProblem
    {
        public Node CloneGraph(Node node) {
            if(node == null)
            {
                return null;
            }
            List<Node> nodeList = new List<Node>();            
            (HashSet<int> nodeSet, List<(Node, Node)> adjacencyList) = GetAdjacencyList(node, new HashSet<int>(), new List<(Node, Node)>());
            Node[] nodes = new Node[nodeSet.Count];
            foreach(int nodeVal in nodeSet)
            {
                nodes[nodeVal-1] = new Node(nodeVal);
            }
            foreach((Node source, Node destination) in adjacencyList)
            {
                nodes[source.val -1].neighbors.Add(nodes[destination.val -1]);                
            }
            return nodes[0];
        }

        private ( HashSet<int>, List<(Node, Node)>) GetAdjacencyList(Node node, HashSet<int> nodeSet, List<(Node, Node)> adjacencyList)
        {
            if(node == null)
            {
                return (nodeSet, adjacencyList);
            }

            nodeSet.Add(node.val);
            
            foreach(Node target in node.neighbors)
            {
                adjacencyList.Add((node, target));
                if(!nodeSet.Contains(target.val))
                {
                    (nodeSet, adjacencyList) = GetAdjacencyList(target, nodeSet, adjacencyList);
                }
            }

            return (nodeSet, adjacencyList);
        }
        public static void Main(string[] args)
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);

            node1.neighbors.Add(node2);
            node2.neighbors.Add(node1);

            node1.neighbors.Add(node4);
            node4.neighbors.Add(node1);

            node3.neighbors.Add(node2);
            node2.neighbors.Add(node3);

            node3.neighbors.Add(node4);
            node4.neighbors.Add(node3);
            
            var result = new CloneGraphProblem().CloneGraph(node1);
            Console.WriteLine($"Input: {node1.GetAdjacencyListString()} => \n{result.GetAdjacencyListString()}");
        }
    }
}