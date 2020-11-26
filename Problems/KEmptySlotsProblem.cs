using System;
using Common;

namespace Problems
{
    public class KEmptySlotsProblem
    {
        public int KEmptySlots(int[] bulbs, int k) {
            int[] days  =  new int[bulbs.Length];
            for(int i=0;i< bulbs.Length;i++)
            {
                days[bulbs[i]-1] = i+1;
            }

            int ans = int.MaxValue;
            int left = 0;
            int right = k+1;
            while(right < days.Length)
            {
                bool continueLoop = false;
                for(int i=left+1;i< right ;i++)
                {
                    if(days[i] < days[left] || days[i] < days[right])
                    {
                        left = i;
                        right = i+k+1;
                        continueLoop = true;
                        break;
                    }
                }
                if(continueLoop)
                {
                    continue;
                }

                ans = Math.Min(ans, Math.Max(days[left], days[right]));
                left = right;
                right = left+k+1;
            }
            return ans < int.MaxValue? ans: -1;
        }

        public static void Main(string[] args)
        {
            int[] bulbs = new int[]{3,2,5,4,1,6,7};
            int k = 1;

            var result = new KEmptySlotsProblem().KEmptySlots(bulbs, k);
            Console.WriteLine($"{Utility.PrintArray<int>(bulbs)}, {k} => {result}");

        }
    }
    
}