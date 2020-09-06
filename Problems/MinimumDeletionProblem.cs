using System;
using Common;

namespace Problems
{
    public class MinimumDeletionProblem
    {
         public int MinCost(string s, int[] cost) {     
            if(string.IsNullOrWhiteSpace(s)|| cost == null || s.Length != cost.Length || s.Length == 1)
            {
                return 0;
            }
            char[] charArray = s.ToCharArray();
            int left = 0;
            int right = left + 1;
            int totalCost = 0;
            char deletedChar = '_';
            while(left < charArray.Length && right < charArray.Length)
            {
                if(charArray[left] != deletedChar && charArray[left] == charArray[right])
                {
                    if(cost[left] < cost[right])
                    {
                        totalCost += cost[left];
                        charArray[left] = deletedChar;
                    }
                    else
                    {
                        totalCost += cost[right];
                        charArray[right] = deletedChar;
                    }
                    Console.WriteLine($"{left}, {right} => {totalCost}");
                    int oldRight = right;
                    for(int i = left;i< charArray.Length;i++)
                    {
                        if(charArray[i] != deletedChar)
                        {
                            left = i;
                            for(int j= i+1;j<charArray.Length;j++)
                            {
                                if(charArray[j] != deletedChar)
                                {
                                    right = j;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    if(oldRight == right)
                    {
                        break;
                    }
                }
                else
                {
                    left++;
                    right = left+1;
                }
            }
            
            return totalCost;

        }

        public static void Main(string[] args)
        {
            //"aaabbbabbbb"
// [3,5,10,7,5,3,5,5,4,8,1]
            var s = "aaabbbabbbb";
            var cost = new int[] {3,5,10,7,5,3,5,5,4,8,1};
            var result = new MinimumDeletionProblem().MinCost(s, cost);
            Console.WriteLine($"{s}, [{Utility.PrintArray<int>(cost)}] => {result}");
        }
    }
}