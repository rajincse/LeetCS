using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Node {
        public int val;
        public IList<Node> neighbors;
        
        public Node() {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val) {
            val = _val;
            neighbors = new List<Node>();
        }
        
        public Node(int _val, List<Node> _neighbors) {
            val = _val;
            neighbors = _neighbors;
        }
        public override string ToString() 
        {
            return $"{this.val}";
        }

        public string GetAdjacencyListString()
        {
            
            List<(Node, Node)> adjacencyList = this.GetAdjacencyList(new HashSet<int>(), new List<(Node, Node)>());
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach((Node source, Node destination) in adjacencyList)
            {
                sb.Append($"({source.val}, {destination.val}), ");
            }
            sb.Append("]");
            return sb.ToString();
        }

        private List<(Node, Node)> GetAdjacencyList(HashSet<int> nodeSet, List<(Node, Node)> adjacencyList)
        {
            nodeSet.Add(this.val);
            
            foreach(Node target in this.neighbors)
            {
                adjacencyList.Add((this, target));
                if(!nodeSet.Contains(target.val))
                {
                    adjacencyList = target.GetAdjacencyList(nodeSet, adjacencyList);
                }
            }

            return adjacencyList;
        }

    }
}