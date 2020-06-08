using System;
using Common;

namespace Problems
{
    public class BuySellStockProblem
    {
        public int MaxProfit(int[] prices) {
            if(prices == null || prices.Length < 2)
            {
                return 0;
            }
            int minValley = prices[0];
            int maxPeak = prices[0];
            int maxProfit = 0;
            for(int i=0;i<prices.Length;i++)
            {
                if(prices[i] < minValley)
                {
                    minValley = prices[i];
                    maxPeak = prices[i];
                }                
                else if(prices[i] > maxPeak)
                {
                    maxPeak = prices[i];
                }
                maxProfit = Math.Max(maxProfit, maxPeak - minValley);
            }
            return maxProfit;
        }
        public static void Main(string[] args)
        {
            int[] input = new int[]{7,17,1,2,3, 4, 6,5};
            int result = new BuySellStockProblem().MaxProfit(input);
            Console.WriteLine($"Input: {Utility.PrintArray<int>(input)} =>{result}");
        }
    }
}