using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class LongestConsecutiveSequenceProblem
    {
        public int LongestConsecutive(int[] nums) {
            if(nums == null || nums.Length == 0)
            {
                return 0;
            }
            HashSet<int> set = new HashSet<int>();
            foreach(int n in nums)
            {
                set.Add(n);
            }

            int longestStreak =0;
            int currentStreak = 0;
            int currentNum =0;
            foreach(int n in nums)
            {
                if(!set.Contains(n-1))
                {
                    currentStreak = 1;
                    currentNum = n;
                    while(set.Contains(currentNum+1))
                    {
                        currentNum++;
                        currentStreak++;
                    }
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }
            return longestStreak;
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{100, 4, 200, 1, 3, 2};
        //     var result = new LongestConsecutiveSequenceProblem().LongestConsecutive(input);
        //     Console.WriteLine($"Input: {Utility.PrintArray<int>(input)} => {result}");
        // }
    }
}