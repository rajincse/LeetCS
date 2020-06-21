using System;
using Common;

namespace Problems
{
    public class HouseRobberProblem
    {
        public int Rob(int[] nums) {
            return RobCircular(nums);
        }
        public int RobCircular(int[] nums)
        {
            if(nums == null || nums.Length ==0)
            {
                return 0;
            }
            if(nums.Length ==1 )
            {
                return nums[0];
            }
            int[,] dp = new int[nums.Length,nums.Length];
            for(int i=0;i<dp.GetLength(0);i++)
            {
                for(int j=0;j<dp.GetLength(1);j++)
                {
                    dp[i,j] = -1;
                }
            }
            return Math.Max( GetMaxAmountCircular(nums, 0, nums.Length-2, dp), GetMaxAmountCircular(nums, 1, nums.Length-1, dp));   
        }
        private int GetMaxAmountCircular(int[] nums, int startIndex, int endIndex, int[,] dp)
        {
            if(nums == null || nums.Length ==0 || dp == null || dp.Rank != 2 || dp.GetLength(0) != dp.GetLength(1))
            {
                return 0;
            }        
            if(startIndex > endIndex)
            {
                return 0;
            }
            
            if(dp[startIndex, endIndex] != -1)
            {
                return dp[startIndex, endIndex];
            }
            else if(startIndex == endIndex)
            {
                dp[startIndex, endIndex] = nums[startIndex];
                return dp[startIndex, endIndex];    
            }
            else            
            {
                int robThisHouse = nums[startIndex]+ GetMaxAmountCircular(nums, (startIndex+2), endIndex, dp);
                int robNextHouse = GetMaxAmountCircular(nums, (startIndex+1) , endIndex, dp);
                
                dp[startIndex, endIndex] = Math.Max(robThisHouse, robNextHouse);
                return dp[startIndex, endIndex];
            }
        }
        public int RobLinear(int[] nums) 
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
            return GetMaxAmountLinear(nums, 0, dp);        
        }
        
        private int GetMaxAmountLinear(int[] nums, int startIndex, int[] dp)
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
                int robThisHouse = nums[startIndex]+ GetMaxAmountLinear(nums, startIndex+2, dp);
                int robNextHouse = GetMaxAmountLinear(nums, startIndex+1, dp);
                
                dp[startIndex] = Math.Max(robThisHouse, robNextHouse);
                return dp[startIndex];
            }
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{2,3,2};
        //     var result = new HouseRobberProblem().Rob(input);
        //     Console.WriteLine($"Input: {Utility.PrintArray<int>(input)} => {result}");
        // }
    }
}