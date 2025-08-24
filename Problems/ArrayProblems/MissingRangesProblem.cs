// https://leetcode.com/problems/missing-ranges/

using System;
using System.Collections;
using System.Collections.Generic;
using Common;

namespace Problems.ArrayProblems
{
    public class MissingRangesProblem
    {
        public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            var result = new List<IList<int>>();
            var currentLower = lower;
            foreach (var num in nums)
            {
                if (num > currentLower && num <= upper)
                {
                    var range = new List<int>() { currentLower, num - 1 };
                    result.Add(range);
                }
                else if (num > upper)
                {
                    break;
                }
                currentLower = num+1;
            }
            if (currentLower <= upper)
            {
                var range = new List<int>() { currentLower, upper };
                result.Add(range);
            }
            return result;
        }
        // public static void Main(string[] args)
        // {
        //     var input = new int[] { -1 };
        //     var lower = -2;
        //     var upper = -1;
        //     var result = new MissingRangesProblem().FindMissingRanges(input, lower, upper);
        //     Console.WriteLine($"input: {Utility.PrintArray<int>(input)}, lower:{lower}, upper:{upper}=> {Utility.Print2DList<int>(result)}");
        // }
    }
}