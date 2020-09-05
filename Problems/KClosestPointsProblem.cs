using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common;

namespace Problems
{
    public class KClosestPointsProblem
    {
        public class Point2d : IComparable<Point2d>
        {
            public int X {get;}
            public int Y {get;}

            public Point2d(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int SquaredEuclideanDistance()
            {
                return X* X + Y * Y;
            }

            public int[] GetPointArray()
            {
                return new int[]{X, Y};
            }
            public int CompareTo( Point2d other)
            {
                return this.SquaredEuclideanDistance() - other.SquaredEuclideanDistance();
            }
        }
        public int[][] KClosest(int[][] points, int K) {
            if(points == null || points.Length == 0 || points[0].Length != 2 || K <1)
            {
                return points;
            }

            List<Point2d> list = new List<Point2d>();
            foreach(var pointArr in points)
            {
                list.Add(new Point2d(pointArr[0], pointArr[1]));
            }
            list.Sort();
            int[][] result = new int[K][];

            int counter = 0;
            foreach(Point2d point in list)
            {
                result[counter] = point.GetPointArray();
                counter++;
                if(counter >= K)
                {
                    break;
                }
            }
            return result;
        }   

        // public static void Main(string[] args)
        // {
        //     var points = new int[][]
        //     {
        //         new int[]{1,3},
        //         new int[]{-2,2},
        //     };

        //     int K = 1;
        //     var result = new KClosestPointsProblem().KClosest(points, K);
        //     Console.WriteLine($"{Utility.Print2DArray<int>(points)}, {K} => {Utility.Print2DArray<int>(result)}");
        // }

    }
}