using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class CountGoodMealsProblem
    {        
        //Unsolved
        public int CountPairs(int[] deliciousness) {
            if(deliciousness == null || deliciousness.Length == 0)
            {
                return 0;
            }

            Dictionary<int, int> occurrenceMap = new Dictionary<int, int>();
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
            int totalCount =0;
            var keyList = new List<int>(occurrenceMap.Keys);
            keyList.Sort();
            foreach(var num in keyList)
            {
                int complement = TwosPowerPair( num);
                if(IsPowerOfTwo(num) && occurrenceMap.ContainsKey(0))
                {
                    totalCount+= occurrenceMap[0];
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
            return totalCount;
        }

        private bool IsPowerOfTwo(int num)
        {
            return num != 0 && (num & (num-1)) ==0;
        }

        private int TwosPowerPair(int num)
        {
            int twosPower = 1;
            for(int i=0;i< 31;i++)
            {
                if(num <= twosPower)
                {
                    break;
                }
                twosPower <<=1;
            }

            return twosPower - num;
        }

        // public static void Main(string[] args)
        // {
        //     var input = new int[]{2160,1936,3,29,27,5,2503,1593,2,0,16,0,3860,28908,6,2,15,49,6246,1946,23,105,7996,196,0,2,55,457,5,3,924,7268,16,48,4,0,12,116,2628,1468};
        //     // var input = new int[]{1,1,1,3,3,3,7};
        //     var result = new CountGoodMealsProblem().CountPairs(input);
        //     Console.WriteLine($"{Utility.PrintArray<int>(input)} =>{result}");
        // }
    }
}