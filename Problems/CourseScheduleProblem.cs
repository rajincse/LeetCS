using System;
using Common;

namespace Problems
{
    public class CourseScheduleProblem
    {
        public enum State {NotVisited = 0, Visiting = 1, Visited = 2}
    
        public bool CanFinish(int numCourses, int[][] prerequisites) {
            if(numCourses == 0 || prerequisites == null || prerequisites.Length == 0 || prerequisites[0].Length != 2)
            {
                return true;
            }
            int[,] graph = new int[numCourses, numCourses ];
            
            for(int i=0;i<prerequisites.Length;i++)
            {
                int source = prerequisites[i][0];
                int destination = prerequisites[i][1];
                graph[source, destination] = 1;
            }
            return !HasCycle(graph);
        }
        private bool HasCycle(int[,] graph)
        {
            if(graph == null || graph.Length == 0 || graph.Rank != 2 || graph.GetLength(0) != graph.GetLength(1))
            {
                return false;
            }
            
            int totalVertices =  graph.GetLength(0);
            State[] states = new State[totalVertices];
            bool[] hasCycle = new bool[totalVertices];
            for(int i=0;i<states.Length;i++)
            {
                states[i] = State.NotVisited;
            }
            
            for(int v=0;v<totalVertices;v++)
            {
                if(states[v] == State.NotVisited)
                {
                    if(HasCycle(graph, v, states, hasCycle))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        private bool HasCycle(int[,] graph, int vertex, State[] states ,  bool[] hasCycle)
        {
            if(graph == null || graph.Length == 0 || graph.Rank != 2 || graph.GetLength(0) != graph.GetLength(1)|| vertex < 0 || vertex >= graph.GetLength(0))
            {
                return false;
            }

            if(states[vertex] == State.Visited)
            {
                return hasCycle[vertex];
            }

            states[vertex] = State.Visiting;
            for(int neighbor=0;neighbor<graph.GetLength(0);neighbor++)
            {
                if(graph[vertex, neighbor] != 1)
                {
                    continue;
                }
                if(states[neighbor] == State.NotVisited)
                {
                    if(HasCycle(graph, neighbor, states, hasCycle))
                    {
                        hasCycle[vertex] = true;
                        states[vertex] = State.Visited;
                        return hasCycle[vertex];
                    }
                }
                else if(states[neighbor] == State.Visited && hasCycle[neighbor])
                {
                    hasCycle[vertex] = true;
                    states[vertex] = State.Visited;
                    return hasCycle[vertex];
                }
                else if(states[neighbor] == State.Visiting)
                {
                    hasCycle[vertex] = true;
                    states[vertex] = State.Visited;
                    return hasCycle[vertex];
                }
            }
            states[vertex] = State.Visited;
            hasCycle[vertex] = false;
            return hasCycle[vertex];
        }
        // public static void Main(string[] args)
        // {
        //     int numCourses = 3;
        //     var prerequisites = new int[][]
        //     {
        //         new int[]{1, 0 } ,
        //         new int[]{2, 1} ,
        //         // new int[]{1,2} ,
                
        //         // new int[]{3,2} ,
        //     };
        //     var result = new CourseScheduleProblem().CanFinish(numCourses, prerequisites);
        //     Console.WriteLine($"Input: {numCourses}, {Utility.Print2DArray<int>(prerequisites)} =>{result}");
        // }
    }
}