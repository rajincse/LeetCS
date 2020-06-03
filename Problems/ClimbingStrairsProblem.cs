using System;

namespace Problems
{
    public class ClimbingStrairsProblem
    {
        public int ClimbStairs(int n) {
            if(n<0)
            {
                return 0;
            }
            int[] dp = new int[n+1];            
            return ClimbStairsDP(n, dp);
        }
        private int ClimbStairsDP(int n, int[] dp)
        {
            if(n<0)
            {
                return 0;
            }
            if(dp[n] > 0)
            {
                return dp[n];
            }
            if(n==1 || n == 0)
            {
                dp[n] = 1;
                return dp[n];
            }
            dp[n] = ClimbStairsDP(n-1, dp)+ ClimbStairsDP(n-2, dp);
            return dp[n];
        }
        private int ClimbStairsRecursive(int n)
        {
            if(n<0)
            {
                return 0;
            }
            if(n==1 || n == 0)
            {
                return 1;
            }

            return ClimbStairsRecursive(n-1)+ ClimbStairsRecursive(n-2);
        }
        // public static void Main(string[] args)
        // {
        //     int input = 6;
        //     int result = new ClimbingStrairsProblem().ClimbStairs(input);
        //     Console.WriteLine($"Input: {input} => {result}");
        // }
    }
}