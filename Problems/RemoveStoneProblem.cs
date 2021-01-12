using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Problems
{
    public class RemoveStoneProblem
    {        
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

        

        public class DisjointSetUnion
        {
            private Dictionary<Point, Point> _parent;

            public DisjointSetUnion()
            {
                _parent = new Dictionary<Point, Point>();                
            }

            public void MakeSet(Point p)
            {
                _parent[p] = p; 
            }

            public Point Find(Point p)
            {
                if(_parent[p] != p)
                {
                    _parent[p] = Find(_parent[p]);
                }
                return _parent[p];
            }

            public void Union(Point p1, Point p2)
            {
                _parent[Find(p1)] = Find(p2);
            }

            // public string PrintSets(int[][] stones)
            // {
            //     StringBuilder sb = new StringBuilder();
            //     sb.Append("[");
            //     foreach (int[] stone in stones)
            //     {
            //         sb.Append($"({stone[0]}=>{_parent[stone[0]]}, {stone[1]+OffSet}=>{_parent[stone[1]+OffSet]}),");
            //     }
            //     sb.Append("]");
            //     return sb.ToString();
            // }
        }

        
        public int RemoveStones(int[][] stones) {
            DisjointSetUnion dsu = new DisjointSetUnion();
            // var printSet = dsu.PrintSets(stones);
            foreach(int[] stone in stones)
            {
                dsu.MakeSet(new Point(stone[0], stone[1]));
            }
            for(int i=0;i<stones.Length-1;i++)
            {
                Point p1 = new Point(stones[i][0], stones[i][1]);
                for(int j=i+1; j< stones.Length;j++)
                {
                    Point p2 = new Point(stones[j][0], stones[j][1]);
                    if(p1.X == p2.X || p1.Y == p2.Y)
                    {
                        dsu.Union(p1, p2);
                    }
                }
            }

            HashSet<Point> seenSet = new HashSet<Point>();
            for(int i=0;i< stones.Length;i++)
            {
                seenSet.Add(dsu.Find(new Point(stones[i][0], stones[i][1])));
            }

            return stones.Length - seenSet.Count;
        }

        public static void Main(string[] args)
        {
            var stones = new int[][]
            {
                new int[]{0,0},
                new int[]{0,2},
                new int[]{1,1},                
                new int[]{2,0},
                new int[]{2,2},
            };

            var result = new RemoveStoneProblem().RemoveStones(stones);

            Console.WriteLine($"{Utility.Print2DArray<int>(stones)} => {result}");
        }
    }
}