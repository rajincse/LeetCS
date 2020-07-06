using System;
using Common;

namespace Problems
{
    public class CoinChangeProblem
    {
        private const int Invalid = -2;
        public int CoinChange(int[] coins, int amount) {
            if(coins == null || coins.Length == 0 || amount <0)
            {
                return -1;
            }
            if(amount ==0)
            {
                return 0;
            }
            int[] dp = new int[amount];
            for(int i=0;i<dp.Length;i++)
            {
                dp[i] = Invalid;
            }
            
            return CoinChangeRecursive(coins, amount, dp);
        }

        public int CoinChangeRecursive(int[] coins, int amount , int[] dp)
        {
            if(coins == null || coins.Length == 0 || amount <0)
            {
                return -1;
            }

            if(amount == 0)
            {
                return 0;
            }

            if(dp[amount-1] != Invalid)
            {
                return dp[amount-1];
            }

            int min = int.MaxValue;
            foreach(int coin in coins)
            {
                int result = CoinChangeRecursive(coins, amount-coin, dp);
                if(result >=0 && result+1 < min)
                {
                    min = result +1;
                }
            }
            if(min == int.MaxValue)
            {
                dp[amount-1] =-1;
                return dp[amount-1];
            }
            dp[amount-1] = min;
            return dp[amount-1];
        }
        // public static void Main(string[] args)
        // {
        //     int[] coins = new int[]{1,2,5};
        //     int amount = 11;
        //     var result = new CoinChangeProblem().CoinChange(coins, amount);
        //     Console.WriteLine($"Input: {Utility.PrintArray<int>(coins)}, {amount} => {result}");
        // }
    }
}