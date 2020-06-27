using System;
using Common;

namespace Problems
{
    public class LongestIncreasingSubsequenceProblem
    {
        public int LengthOfLIS(int[] nums) {
            if(nums == null || nums.Length == 0)
            {
                return 0;
            }
            
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int maxans = 1;
            for (int i = 1; i < dp.Length; i++) {
                int maxval = 0;
                for (int j = 0; j < i; j++) {
                    if (nums[i] > nums[j]) {
                        maxval = Math.Max(maxval, dp[j]);
                    }
                }
                dp[i] = maxval + 1;
                maxans = Math.Max(maxans, dp[i]);
            }
            return maxans;
        }

        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{10,9,2,5,3,7,101,18};
        //     var result = new LongestIncreasingSubsequenceProblem().LengthOfLIS(input);
        //     Console.WriteLine($"Input :{Utility.PrintArray<int>(input)} =>{result}");
        // }
    }
}