using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common;

namespace Problems
{
    public class SentenceSimilarityProblem 
    {
        public enum NodeState { NotVisited, Visiting, Visited};
        public class GraphNode : IEquatable<GraphNode>
        {
            public string Word {get;set;}
            public NodeState NodeState {get;set;}

            public GraphNode(string word)
            {
                Word = word;
                NodeState = NodeState.NotVisited;
            }

            public bool Equals(GraphNode other)
            {
                return Word.Equals(other.Word);
            }

            public override string ToString()
            {
                return $"{{{Word}, {NodeState}}}";
            }
        }
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, IList<IList<string>> pairs) {
            if((words1 == null || words1.Length == 0) && (words2 == null || words2.Length == 0 ))
            {
                return true;
            }
            if(words1 == null || words1.Length == 0 || words2 == null || words2.Length == 0 || words1.Length != words2.Length)
            {
                return false;
            }

            if(pairs == null || pairs.Count == 0)
            {
                return true;
            }
            
            Dictionary<string, List<GraphNode>> graph = new Dictionary<string, List<GraphNode>>();
            HashSet<GraphNode> allNodes = new HashSet<GraphNode>();
            foreach(IList<string> pair in pairs)
            {
                if(pair.Count != 2)
                {
                    return false;
                }
                string word1 = pair[0];
                string word2 = pair[1];
                
                GraphNode node1 = new GraphNode(word1);
                GraphNode node2 = new GraphNode(word2);

                allNodes.Add(node1);
                allNodes.Add(node2);

                if(!graph.ContainsKey(word1))
                {
                    graph[word1] = new List<GraphNode>();
                }
                graph[word1].Add(node2);

                if(!graph.ContainsKey(word2))
                {
                    graph[word2] = new List<GraphNode>();
                }
                graph[word2].Add(node1);
            }
            
            for(int i=0;i<words1.Length;i++)
            {
                string word1 = words1[i];
                string word2 = words2[i];
                var isSimilar = IsSimilar(word1, word2, graph, allNodes);
                Console.WriteLine($"{{{word1},{word2}}} => {isSimilar}");
                if(!isSimilar)
                {
                    return false;
                }
            }

            return true;
        }
        private void SetAllUnvisited(HashSet<GraphNode> allNodes)
        {
            foreach(GraphNode node in allNodes)
            {
                node.NodeState = NodeState.NotVisited;
            }
        }
        private bool IsSimilar(string source, string target, Dictionary<string, List<GraphNode>> graph, HashSet<GraphNode> allNodes)
        {
            if(string.IsNullOrWhiteSpace(source) && string.IsNullOrWhiteSpace(target))
            {
                return true;
            }

            if(source.Equals(target))
            {
                return true;
            }

            if(string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target) || graph == null 
                || graph.Keys.Count == 0 || allNodes == null || allNodes.Count ==0 )
            {
                return false;   
            }

            if(!graph.ContainsKey(source))
            {
                return false;
            }

            SetAllUnvisited(allNodes);

            foreach(GraphNode neighbor in graph[source])
            {
                if(neighbor.NodeState == NodeState.NotVisited)
                {
                    if(Find(target, neighbor, graph))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        private bool Find(string target, GraphNode node, Dictionary<string, List<GraphNode>> graph)
        {
            if(target.Equals(node.Word))
            {
                return true;
            }

            if(!graph.ContainsKey(node.Word))
            {
                return false;
            }

            node.NodeState = NodeState.Visiting;
            foreach(GraphNode neighbor in graph[node.Word])
            {
                if(neighbor.NodeState == NodeState.NotVisited)
                {
                    if(Find(target, neighbor, graph))
                    {
                        return true;
                    }
                }
            }
            node.NodeState = NodeState.Visited;

            return false;
        }

        // public static void Main(string[] args)
        // {
        //     var words1 = new string[]{"great", "acting", "skills"};
        //     var words2 = new string[]{"fine", "drama", "talent"};
        //     var pairs = new List<IList<string>>
        //                 {
        //                     new List<string>(){"great", "good"},
        //                     new List<string>(){"fine", "good"},
        //                     new List<string>(){"acting", "drama"},
        //                     new List<string>(){"skills", "talent"},
        //                 };
        //     var result = new SentenceSimilarityProblem().AreSentencesSimilarTwo(words1, words2, pairs);
        //     Console.WriteLine($"{Utility.PrintArray<string>(words1)}, {Utility.PrintArray<string>(words2)}, ");
        //     Console.WriteLine($"{Utility.Print2DList<string>(pairs)} => {result}");
        // }

    }
}