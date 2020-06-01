using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common;

namespace Problems
{    
    public class MergeIntervalsProblem
    {
        public class Interval : IComparable<Interval>
        {
            public int Start {get; set;}
            public int End {get; set;}
            public Interval(int start, int end)
            {
                Start = start;
                End = end;
            }
            public bool IsOverlapping(Interval other)
            {
                return (other.Start>= Start && other.Start <= End)
                    || (other.End>= Start && other.End <= End);
            }

            public Interval Merge(Interval other)
            {
                if(!IsOverlapping(other))
                {
                    return null;
                }
                int start = Math.Min(Start, other.Start);
                int end = Math.Max(End, other.End);
                return new Interval(start, end);
            }
            public int CompareTo( Interval other)
            {
                return Start.CompareTo(other.Start);
            }
        }
        public int[][] Merge(int[][] intervals) {            
            if(intervals == null || intervals.Length ==0 )
            {
                return intervals;
            }
            List<Interval> intervalList = new List<Interval>();
            foreach(int[] intervalArray in intervals)
            {
                intervalList.Add(new Interval(intervalArray[0], intervalArray[1]));
            }
            intervalList.Sort();
            Stack<Interval> stack = new Stack<Interval>();
            foreach(Interval interval in intervalList)
            {
                if(stack.Count > 0)
                {
                    Interval top = stack.Peek();
                    if(top.IsOverlapping(interval))
                    {
                        top = stack.Pop();
                        top = top.Merge(interval);
                        stack.Push(top);
                    }
                    else
                    {
                        stack.Push(interval);
                    }
                }
                else
                {
                    stack.Push(interval);
                }
            }
            int[][] result = new int[stack.Count][];
            int index = 0;
            while(stack.Count >0)
            {
                Interval top = stack.Pop();
                result[index] = new int[]{top.Start, top.End};
                index++;
            }
            return result;
        }
        public static void Main(string[] args)
        {
            int[][] input = new int[][]{
                new int[]{1,3},
                new int[]{2,6},
                new int[]{8,10},
                new int[]{15,18}
            };
            var result = new MergeIntervalsProblem().Merge(input);
            Console.WriteLine($"input: {Utility.Print2DArray<int>(input)} =>{Utility.Print2DArray<int>(result)}");
        }
    }
}