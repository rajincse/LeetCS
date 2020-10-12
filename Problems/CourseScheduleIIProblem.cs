using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class CourseScheduleIIProblem
    {
        private enum VisitingState
        {
            Unvisited = 0,
            Visiting = 1,
            Visited = 2
        }
        public int[] FindOrder(int numCourses, int[][] prerequisites) {   
            if(numCourses == 1)
            {
                return new int[]{0};
            }
         
            if(numCourses <= 0 || prerequisites == null || prerequisites.Length ==0 || prerequisites[0].Length != 2 )
            {
                return new int[0];
            }

            
            List<List<int>> adjacencyList = new List<List<int>>();
            for(int i=0;i< numCourses;i++)
            {
                adjacencyList.Add(new List<int>());
            }
            foreach(var pair in prerequisites)
            {
                adjacencyList[pair[0]].Add(pair[1]);
            }
            VisitingState[] visitingStates = new VisitingState[numCourses];
            for(int i=0;i<visitingStates.Length;i++)
            {
                visitingStates[i] = VisitingState.Unvisited;
            }

            List<int> topologicalList = new List<int>();
            for(int i=0;i<visitingStates.Length;i++)
            {
                if(visitingStates[i] == VisitingState.Unvisited)
                {
                    bool acyclic = DfsVisit(adjacencyList, i, visitingStates, topologicalList);
                    if(!acyclic)
                    {
                        return new int[0];
                    }
                }
            }

            return topologicalList.ToArray();
        }

        private bool DfsVisit(List<List<int>> adjacencyList, int vertex, VisitingState[] visitingStates, List<int> topologicalList)
        {
            if(vertex < 0 || vertex >= visitingStates.Length)
            {
                return false;    
            }

            visitingStates[vertex] = VisitingState.Visiting;
            
            foreach( var v in adjacencyList[vertex])
            {
                if(visitingStates[v] == VisitingState.Visiting)
                {
                    return false;
                }
                else if(visitingStates[v] == VisitingState.Unvisited)
                {
                    bool acyclic = DfsVisit(adjacencyList, v, visitingStates, topologicalList);
                    if(!acyclic)
                    {
                        return false;
                    }
                }
            }
            visitingStates[vertex] = VisitingState.Visited;
            topologicalList.Add(vertex);
            return true;
        }
        // public static void Main(string[] args)
        // {
        //     var numCourses = 4;
        //     var prerequisites = new int[][]{
        //         new int[]{0,1},
        //         new int[]{1,2},
        //         new int[]{1,3},
        //         new int[]{2,3},
        //         new int[]{0,2},
        //     };

        //     var result = new CourseScheduleIIProblem().FindOrder(numCourses, prerequisites);
        //     Console.WriteLine($"{numCourses}, {Utility.Print2DArray(prerequisites)} => {Utility.PrintArray<int>(result)}");
        // }
    }
}