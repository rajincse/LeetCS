using System;
using Common;

namespace Problems
{
    public class HouseRobberProblem
    {
        public int Rob(int[] nums) 
        {
            if(nums == null || nums.Length ==0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            for(int i=0;i<dp.Length;i++)
            {
                dp[i] = -1;
            }
            return GetMaxAmount(nums, 0, dp);        
        }
        
        private int GetMaxAmount(int[] nums, int startIndex, int[] dp)
        {
            if(nums == null || nums.Length ==0 || dp == null || dp.Length != nums.Length)
            {
                return 0;
            }        
            
            if(startIndex >= nums.Length)
            {            
                return 0;
            }
            else if(dp[startIndex] != -1)
            {
                return dp[startIndex];
            }
            else if(startIndex == nums.Length -1)
            {
                dp[startIndex] = nums[startIndex];
                return dp[startIndex];    
            }
            else            
            {
                int robThisHouse = nums[startIndex]+ GetMaxAmount(nums, startIndex+2, dp);
                int robNextHouse = GetMaxAmount(nums, startIndex+1, dp);
                
                dp[startIndex] = Math.Max(robThisHouse, robNextHouse);
                return dp[startIndex];
            }
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{2,7,9,3,1};
        //     var result = new HouseRobberProblem().Rob(input);
        //     Console.WriteLine($"Input: {Utility.PrintArray<int>(input)} => {result}");
        // }
    }
}