using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class MeetingRoomProblem
    {
        public class Interval: IComparable<Interval>
        {
            public int Start{ get; set;}
            public int End {get;set;}
            
            public Interval(int start, int end)
            {
                Start = start;
                End = end;
            }
            
            public int CompareTo(Interval other)
            {
                return Start - other.Start;
            }
            
            public bool Overlaps(Interval other)
            {
                // Start and end are exclusive 
                //if inclusive then: this.Start < other.End && other.Start < this.End;
                return this.Start < other.End && other.Start < this.End;
            }
        }
        public bool CanAttendMeetings(int[][] intervals) {
            if(intervals == null || intervals.Length ==0 || intervals[0].Length != 2)
            {
                return true;
            }
            List<Interval> intervalList = new List<Interval>();
            for(int i=0;i<intervals.Length;i++)
            {
                Interval interval = new Interval(intervals[i][0], intervals[i][1]);
                intervalList.Add(interval);
            }
            intervalList.Sort();
            
            Interval previous = null;
            foreach(Interval current in intervalList)
            {
                if(previous != null)
                {
                    if(previous.Overlaps(current))
                    {
                        return false;
                    }
                }
                previous = current;
            }
            
            return true;
            
        }
        public int MinMeetingRooms(int[][] intervals) {
            if(intervals == null || intervals.Length ==0 || intervals[0].Length != 2)
            {
                return 0;
            }
            
            int[] startTimes = new int[intervals.Length];        
            int[] endTimes = new int[intervals.Length];
            
            for(int i=0;i<intervals.Length;i++)
            {
                startTimes[i] = intervals[i][0];
                endTimes[i] = intervals[i][1];
            }
            
            Array.Sort(startTimes);
            Array.Sort(endTimes);
            
            int startPointer = 0;
            int endPointer = 0;
            
            int roomCount =0;
            
            while(startPointer < startTimes.Length)
            {
                if(startTimes[startPointer] >= endTimes[endPointer])
                {
                    endPointer++;                
                }
                else
                {
                    
                    roomCount++;
                }
                startPointer++;
            }
            
            return roomCount;
        }

        public static void Main(string[] args)
        {
            int[][] input = new int[][]{
                new int[]{13, 15},
                new int[]{1, 13},
            };
            var result = new MeetingRoomProblem().CanAttendMeetings(input);
            Console.WriteLine($"Input:{Utility.Print2DArray<int>(input)} =>{result}");
        }
    }
}