using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common;

namespace Problems
{
    public class MinAreaRectangleProblem
    {
        //In progress
        public class YPointPair : IEquatable<YPointPair>
        {
            public int Y1 {get;}
            public int Y2 {get;}

            public YPointPair(int y1, int y2)
            {
                Y1 = y1;
                Y2 = y2;                
            }

            public bool Equals(YPointPair other)
            {
                return Y1 == other.Y1 && Y2 == other.Y2;
            }

            public override int GetHashCode()
            {
                return 17* Y1.GetHashCode()+Y1.GetHashCode();
            }

            public override string ToString()
            {
                return $"{{{Y1},{Y2}}}";
            }
        }
        public int MinAreaRect(int[][] points) {
            return 0;
        }

        // public static void Main(string[] args)
        // {
        //     var input = new int[][]
        //     {
        //         new int[]{1,1},
        //         new int[]{1,3},
        //         new int[]{3,1},
        //         new int[]{3,3},
        //         new int[]{2,2}
        //     };
        //     var result = new MinAreaRectangleProblem().MinAreaRect(input);
        //     Console.WriteLine($"{Utility.Print2DArray<int>(input)} => {result}");

        //     YPointPair pair1 = new YPointPair(1,1);
        //     YPointPair pair2 = new YPointPair(1,1);
        //     YPointPair pair3 = new YPointPair(3,3);
        //     HashSet<YPointPair> set = new HashSet<YPointPair>();
        //     set.Add(pair1);
        //     set.Add(pair2);
        //     set.Add(pair3);

        //     Console.WriteLine($"{Utility.PrintList<YPointPair>(new List<YPointPair>(set))}");

        // }
    }
}