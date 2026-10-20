// https://leetcode.com/problems/split-array-largest-sum/
using System;
using Common;

namespace Problems.ArrayProblems
{
    public class SplitArraySumProblem
    {
        public int SplitArray(int[] nums, int k) {
        
        }

        public static void Main(string[] args)
        {
            var input = new int[] { 7,2,5,10,8 };
            var k = 2;
            var result = new SplitArraySumProblem().SplitArray(input, k);
            Console.WriteLine($"input: {Utility.PrintArray<int>(input)}, k:{k}=> {result}");
        }
    }
}