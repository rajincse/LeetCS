using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common;

namespace Problems
{
    public class MinAreaRectangleProblem
    {
        //In progress
        public class Point : IEquatable<Point>
        {
            public int X {get;}
            public int Y {get;}

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool Equals(Point other)
            {
                return X == other.X && Y== other.Y;
            }

            public override int GetHashCode()
            {
                return 17* X.GetHashCode()+Y.GetHashCode();
            }

            public override string ToString()
            {
                return $"{{{X},{Y}}}";
            }
        }
        public int MinAreaRect(int[][] points) {
            if(points == null || points.Length == 0 || points[0].Length != 2)
            {
                return 0;
            }
            HashSet<Point> pointSet = new HashSet<Point>();

            foreach (var point in points)
            {
                pointSet.Add(new Point(point[0], point[1]));
            }

            int ans = int.MaxValue;
            for(int i = 0; i < points.Length; i++)
            {
                var pi = new Point(points[i][0], points[i][1]);
                for(int j = i+1;j< points.Length-1;j++)
                {
                    var pij = new Point(points[i][0], points[j][1]);
                    var pji = new Point(points[j][0], points[i][1]);
                    if(pij.X != pji.X && pij.Y != pji.Y)
                    {
                        
                        if(pointSet.Contains(pij) && pointSet.Contains(pji))
                        {
                            var area = Math.Abs((pij.X - pji.X) * (pij.Y - pji.Y));
                            ans = Math.Min(ans, area);
                        }
                    }
                }
            }
            return ans < int.MaxValue? ans: 0;
        }

        // public static void Main(string[] args)
        // {
        //     var input = new int[][]
        //     {
        //         new int[]{1,1},
        //         new int[]{1,3},
        //         new int[]{3,1},
        //         new int[]{3,3},
        //         new int[]{2,2},
        //         new int[]{4,1},
        //         new int[]{4,3},
        //     };
        //     var result = new MinAreaRectangleProblem().MinAreaRect(input);
        //     Console.WriteLine($"{Utility.Print2DArray<int>(input)} => {result}");

        // }
    }
}