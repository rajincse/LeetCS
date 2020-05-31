using System;
using Common;

namespace Problems
{
    public class MaximumSubarrayProblem
    {
        public int MaxSubArray(int[] nums) {
            int maxSum = nums[0];
            int currentSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currentSum+= nums[i];
                if(currentSum < nums[i])
                {
                    currentSum = nums[i];
                }
                maxSum = Math.Max(maxSum, currentSum);
            }
            return maxSum;
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{-2,1,-3,4,-1,2,1,-5,4};                        
        //     int result = new MaximumSubarrayProblem().MaxSubArray(input);
        //     Console.WriteLine($"Input:{Utility.PrintArray<int>(input)}=> {result}");
        // }
    }
}