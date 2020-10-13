using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class CriticalConnectionProblem
    {
        private int _time;
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
            IList<IList<int>> criticalConnections = new List<IList<int>>();

            if(n <= 0 )
            {
                return criticalConnections;
            }

            List<int>[] graph = GenerateGraph(n, connections);
            bool[] visited = new bool[n];
            int[] visitedTimes = new int[n];
            int[] lowestVisitedTimes = new int[n];
            _time = 0;

            DfsVisit(0, -1, graph, visited, visitedTimes, lowestVisitedTimes, criticalConnections);
            return criticalConnections;
        }

        private void DfsVisit(int currentNodeIndex, int parentNodeIndex, 
        List<int>[] graph, bool[] visited, int[] visitedTimes, int[] lowestVisitedTimes,
        IList<IList<int>> criticalConnections )
        {
            if(currentNodeIndex < 0 || currentNodeIndex >= graph.Length)
            {
                return;
            }

            visited[currentNodeIndex] = true;
            visitedTimes[currentNodeIndex] = _time;
            lowestVisitedTimes[currentNodeIndex] = _time;
            _time++;

            List<int> adjacencyList = graph[currentNodeIndex];
            foreach(int neighborIndex in adjacencyList)
            {
                if(neighborIndex == parentNodeIndex)
                {
                    continue;
                }

                if(!visited[neighborIndex])
                {
                    DfsVisit(neighborIndex, currentNodeIndex, graph, visited, visitedTimes, lowestVisitedTimes, criticalConnections);
                    if(lowestVisitedTimes[neighborIndex] < visitedTimes[currentNodeIndex])
                    {
                        lowestVisitedTimes[currentNodeIndex] = lowestVisitedTimes[neighborIndex];
                    }
                    else if ( lowestVisitedTimes[neighborIndex] > visitedTimes[currentNodeIndex] )
                    {
                        criticalConnections.Add(new List<int>(){currentNodeIndex, neighborIndex});
                    }

                }
                else
                {
                    lowestVisitedTimes[currentNodeIndex] = Math.Min(lowestVisitedTimes[currentNodeIndex], visitedTimes[neighborIndex]);
                }
            }
        }
        private List<int>[] GenerateGraph(int n, IList<IList<int>> connections)
        {
            List<int>[] graph = new List<int>[n];
            for(int i=0;i<n;i++)
            {
                graph[i] = new List<int>();
            }
            
            if(connections == null || connections.Count == 0)
            {
                return graph;
            }

            foreach(var pair in connections)
            {
                graph[pair[0]].Add(pair[1]);
                graph[pair[1]].Add(pair[0]);
            }

            return graph;
        }

        // public static void Main(string[] args)
        // {
        //     int n = 4;
        //     IList<IList<int>> connections = new List<IList<int>>()
        //     {
        //         new List<int>(){0,1},
        //         new List<int>(){1,2},
        //         new List<int>(){2,0},
        //         new List<int>(){1,3}
        //     };
        //     var result = new CriticalConnectionProblem().CriticalConnections(n, connections);
        //     Console.WriteLine($"{n},{Utility.Print2DList<int>(connections)} => {Utility.Print2DList<int>(result)}");
        // }
    }
}