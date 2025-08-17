// https://leetcode.com/problems/missing-ranges/

using System;
using System.Collections.Generic;
using Common;

namespace Problems.ArrayProblems
{
    public class MissingRangesProblem
    {
        public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            return null;
        }
        public static void Main(string[] args)
        {
            var input = new int[] { 0,1,3,50,75};
            var lower = 0;
            var upper = 99;
            var result = new MissingRangesProblem().FindMissingRanges(input, lower, upper);
            Console.WriteLine($"input: {Utility.PrintArray<int>(input)}, lower:{lower}, upper:{upper}=> {Utility.Print2DList<int>(result)}");
        }
    }
}