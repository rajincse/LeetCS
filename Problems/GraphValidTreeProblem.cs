using System;
using Common;

namespace Problems
{
    public class GraphValidTreeProblem
    {
         public bool ValidTree(int n, int[][] edges) {
            if(n == 1 && edges.Length ==0)
            {
                return true;
            }
            if(n<1 || edges.Length ==0 || edges[0].Length != 2)
            {
                return false;
            }
            // A tree has n-1 edges
            if(edges.Length != n-1)
            {
                return false;
            }
            int[,] graph = new int [n,n];
            for(int i=0;i<edges.Length;i++)
            {
                graph[edges[i][0], edges[i][1]] = 1;
                graph[edges[i][1], edges[i][0]] = 1;
            }
            
            
            return IsConnected(graph);
        }    
        
        public enum State {NotVisited = 0, Visiting = 1, Visited = 2}
        
        private bool IsConnected(int[,] graph)
        {
            if(graph == null || graph.Length == 0 || graph.Rank != 2 || graph.GetLength(0) != graph.GetLength(1))
            {
                return false;
            }
            
            int totalVertices =  graph.GetLength(0);
            State[] states = new State[totalVertices];
            for(int v=0;v<totalVertices;v++)
            {
                states[v] = State.NotVisited;
            }
            
            DfsVisit(graph, 0, states);
            
            int visitedCount = 0;
            for(int v=0;v<totalVertices;v++)
            {
                visitedCount = states[v] == State.Visited? visitedCount+1: visitedCount;
            }
            
            return visitedCount == totalVertices;
            
        }

        // public static void Main(string[] args)
        // {
        //     int n = 5;
        //     int[][] edges = new int[][]
        //     {
        //         new int[]{0,1},
        //         new int[]{0,2},
        //         new int[]{0,3},
        //         new int[]{1,4},
        //     };
        //     var result = new GraphValidTreeProblem().ValidTree(n, edges);
        //     Console.WriteLine($"Input: {n}, {Utility.Print2DArray<int>(edges)} => {result}");
        // }
    }
}