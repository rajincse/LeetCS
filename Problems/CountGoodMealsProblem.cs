using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class CountGoodMealsProblem
    {
        public int CountPairs(int[] deliciousness) {
            if(deliciousness == null || deliciousness.Length == 0)
            {
                return 0;
            }

            Dictionary<long, long> occurrenceMap = new Dictionary<long, long>();
            for(int i=0;i<deliciousness.Length;i++)
            {
                if(occurrenceMap.ContainsKey(deliciousness[i]))
                {
                    occurrenceMap[deliciousness[i]]++;
                }
                else
                {
                    occurrenceMap[deliciousness[i]] = 1;
                }
            }
            long totalCount =0;

            foreach(var num in occurrenceMap.Keys)
            {
                if(num ==0) continue;
                long complement = TwosPowerPair( num);
                if(IsPowerOfTwo(num) && occurrenceMap.ContainsKey(0))
                {
                    totalCount+= (occurrenceMap[0]* occurrenceMap[num]);
                }
                if(occurrenceMap.ContainsKey(complement))
                {
                    if(complement != num)
                    {
                        totalCount += (occurrenceMap[complement] * occurrenceMap[num]);
                    }
                    else
                    {
                        totalCount += ((occurrenceMap[num] * (occurrenceMap[num]-1)) /2);
                    }
                }
            }
            return (int)(totalCount % (1_000_000_007));
        }

        private bool IsPowerOfTwo(long num)
        {
            return num != 0 && (num & (num-1)) ==0;
        }

        private long TwosPowerPair(long num)
        {
            long twosPower = 1;
            for(int i=0;i< 31;i++)
            {
                if(num < twosPower)
                {
                    break;
                }
                twosPower <<=1;
            }

            return twosPower - num;
        }

        // public static void Main(string[] args)
        // {
        //     var input = new int[100000];
        //     for(int i=0;i<input.Length;i++)
        //     {
        //         input[i] = 32;
        //     }
        //     // var input = new int[]{149,107,1,63,0,1,6867,1325,5611,2581,39,89,46,18,12,20,22,234};
        //     // var input = new int[]{2160,1936,3,29,27,5,2503,1593,2,0,16,0,3860,28908,6,2,15,49,6246,1946,23,105,7996,196,0,2,55,457,5,3,924,7268,16,48,4,0,12,116,2628,1468};
        //     // var input = new int[]{1,1,1,3,3,3,7};
        //     var result = new CountGoodMealsProblem().CountPairs(input);
        //     Console.WriteLine($"{Utility.PrintArray<int>(input)} =>{result}");
        // }
    }
}