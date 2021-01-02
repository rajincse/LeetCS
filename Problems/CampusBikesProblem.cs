using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common;

namespace Problems
{    
    public class CampusBikesProblem
    {
        public class DistanceWorkerBike: IComparable<DistanceWorkerBike>
        {
            public int Distance {get; set;}
            public int WorkerIndex {get; set;}
            public int BikeIndex {get; set;}

            public int CompareTo( DistanceWorkerBike other)
            {
                if(this.Distance != other.Distance)
                {
                    return this.Distance - other.Distance;
                }
                else if(this.WorkerIndex != other.WorkerIndex)
                {
                    return this.WorkerIndex - other.WorkerIndex;
                }
                else
                {
                    return this.BikeIndex - other.BikeIndex;
                }
            }
        }
        public int[] AssignBikes(int[][] workers, int[][] bikes) {
            if(workers == null || workers.Length == 0 || workers[0].Length != 2 
            ||
            bikes == null || bikes.Length == 0 || bikes[0].Length != 2
            )
            {
                return null;
            }

            List<DistanceWorkerBike> distanceList = new List<DistanceWorkerBike>();

            for(int i=0;i<workers.Length;i++)
            {
                for(int j=0;j<bikes.Length;j++)
                {
                    int distance = Math.Abs(workers[i][0] - bikes[j][0])+ Math.Abs(workers[i][1] - bikes[j][1]);
                    var distanceWorkerBike = new DistanceWorkerBike()
                    {
                        Distance = distance,
                        WorkerIndex = i,
                        BikeIndex  = j
                    };
                    distanceList.Add(distanceWorkerBike);
                }
            }
            
            distanceList.Sort();

            bool[] workerAssigned = new bool[workers.Length];
            bool[] bikesAssigned  = new bool[bikes.Length];

            int[] result = new int[workers.Length];

            foreach(var distanceWorkerBike in distanceList)
            {
                if(!workerAssigned[distanceWorkerBike.WorkerIndex] && !bikesAssigned[distanceWorkerBike.BikeIndex])
                {
                    result[distanceWorkerBike.WorkerIndex] = distanceWorkerBike.BikeIndex;
                    workerAssigned[distanceWorkerBike.WorkerIndex] = true;
                    bikesAssigned[distanceWorkerBike.BikeIndex] = true;
                }
            }

            return result;
        }

        // public static void Main(string[] args)
        // {
        //     int[][] workers = new int[][]{
        //         new int[]{0,0},
        //         new int[]{2,1},
        //     };

        //     int[][] bikes = new int[][]{
        //         new int[]{1,2},
        //         new int[]{3,3}
        //     };

        //     var result = new CampusBikesProblem().AssignBikes(workers, bikes);
        //     Console.WriteLine($"[{Utility.Print2DArray<int>(workers)}], [{Utility.Print2DArray<int>(bikes)}] => [{Utility.PrintArray<int>(result)}]");
        // }
    }
}