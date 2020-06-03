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
            return Merge(intervalList);
            
        }
        public int[][] Merge(List<Interval> intervalList)
        {
            if(intervalList == null || intervalList.Count ==0)
            {
                return null;
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
            int index = result.Length-1;
            while(stack.Count >0)
            {
                Interval top = stack.Pop();
                result[index] = new int[]{top.Start, top.End};
                index--;
            }
            return result;
        }
        public int[][] Insert(int[][] intervals, int[] newInterval) {
            if(intervals == null && newInterval == null)
            {
                return null;
            }
            if(intervals != null && (newInterval == null || newInterval.Length ==0))
            {
                return Merge(intervals);
            }
            if(newInterval!= null && (intervals == null || intervals.Length ==0))
            {
                return new int[][]{newInterval};
            }
            List<Interval> intervalList = new List<Interval>();
            foreach(int[] intervalArray in intervals)
            {
                intervalList.Add(new Interval(intervalArray[0], intervalArray[1]));
            }
            intervalList.Add(new Interval(newInterval[0], newInterval[1]));

            return Merge(intervalList);
        }
        // public static void Main(string[] args)
        // {
        //     int[][] input = new int[][]{
        //         // new int[]{1,2},
        //         // new int[]{3,5},
        //         // new int[]{6,7},
        //         // new int[]{8,10},
        //         // new int[]{12,16},
        //     };
        //     int[] newInterval = new int[]{4,8};

        //     // var result = new MergeIntervalsProblem().Merge(input);
        //     // Console.WriteLine($"input: {Utility.Print2DArray<int>(input)} =>{Utility.Print2DArray<int>(result)}");
            
        //     var result = new MergeIntervalsProblem().Insert(input, newInterval);
        //     Console.WriteLine($"input: {Utility.Print2DArray<int>(input)} =>{Utility.Print2DArray<int>(result)}");            
        // }
    }
}