// https://leetcode.com/problems/split-array-largest-sum/
using System;
using Common;

namespace Problems.ArrayProblems
{
    public class SplitArraySumProblem
    {
        public int SplitArray(int[] nums, int k)
        {
            long low = 0;
            long high = 0;

            foreach (var num in nums)
            {
                low = Math.Max(low, num);
                high += num;
            }

            while (low < high)
            {
                var maxSubarraySum = low + (high - low) / 2;
                var subarrayCount = 1;
                long currentSum = 0;

                foreach (var num in nums)
                {
                    if (currentSum + num > maxSubarraySum)
                    {
                        subarrayCount++;
                        currentSum = num;
                    }
                    else
                    {
                        currentSum += num;
                    }
                }

                if (subarrayCount > k)
                {
                    low = maxSubarraySum + 1;
                }
                else
                {
                    high = maxSubarraySum;
                }
            }

            return checked((int)low);
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