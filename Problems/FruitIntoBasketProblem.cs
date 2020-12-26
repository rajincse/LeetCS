using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class FruitIntoBasketProblem
    {
        public int TotalFruit(int[] tree) {
            if(tree == null || tree.Length ==0){
                return 0;
            }

            int max =0;
            int startIndex = 0;
            Dictionary<int, int> occurrenceMap = new Dictionary<int, int>();
            for(int i=0;i<tree.Length;i++){
                if(!occurrenceMap.ContainsKey(tree[i]))
                {
                    occurrenceMap[tree[i]] = 0;
                }
                occurrenceMap[tree[i]]++;
                while(occurrenceMap.Keys.Count >= 3)
                {
                    occurrenceMap[tree[startIndex]]--;
                    if(occurrenceMap[tree[startIndex]] ==0)
                    {
                        occurrenceMap.Remove(tree[startIndex]);
                    }
                    
                    startIndex++;
                }
                int currentWeight = i-startIndex+1;
                max = Math.Max(max, currentWeight);
            }
            return max;
        }
        // public static void Main(string[] args)
        // {
        //     int[] tree = new int[]{3,3,3,1,2,1,1,2,3,3,4};
        //     var result = new FruitIntoBasketProblem().TotalFruit(tree);
        //     Console.WriteLine($"{Utility.PrintArray<int>(tree)} => {result}");
        // }
    }
}