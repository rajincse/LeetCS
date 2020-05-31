using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class CombinationSumProblem
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target) {
            Array.Sort(candidates);
            IList<IList<int>> result =  DFS(new List<IList<int>>(), new List<int>(), 0, candidates, target);
            return result;
        }

        public IList<IList<int>> DFS(IList<IList<int>> result, IList<int> prefix, int currentSum, int[] candidates, int target)
        {
            if(currentSum > target)
            {
                return result;
            }
            if(currentSum == target)
            {                
                result.Add(new List<int>(prefix));
                return result;
            }
            foreach(int candidate in candidates)
            {
                if(prefix.Count > 0 && candidate < prefix[prefix.Count-1]) continue;
                prefix.Add(candidate);
                result = DFS(result, prefix, currentSum+candidate, candidates, target);
                prefix.RemoveAt(prefix.Count-1);
            }
            return result;
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{2,3,6,7};
        //     int target = 7;
        //     var result = new CombinationSumProblem().CombinationSum(input, target);
        //     Console.WriteLine($"Input:{Utility.PrintArray<int>(input)}, {target} => {Utility.Print2DList<int>(result)}");
        // }
    }
}