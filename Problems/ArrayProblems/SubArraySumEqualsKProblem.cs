using System;
using Common;

namespace Problems.ArrayProblems
{
    public class SubArraySumEqualsKProblem
    {
        public int SubarraySum(int[] nums, int k)
        {
            return 0;
        }

        public static void Main(string[] args)
        {
            var nums = new int[] { 1, 1, 1 };
            var k = 2;
            var result = new SubArraySumEqualsKProblem().SubarraySum(nums, k);
            Console.WriteLine($"nums: {Utility.PrintArray<int>(nums)}, k:{k} => {result}");
        }
    }
}