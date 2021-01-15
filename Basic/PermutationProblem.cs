using System;
using System.Collections.Generic;
using Common;

namespace Basic
{
    public class PermutationProblem
    {
        public IList<IList<int>> Permute(int[] nums) {
            var result = new List<IList<int>>();
            if(nums == null || nums.Length == 0)
            {
                return result;
            }
            Calculate(new List<int>(nums), new List<int>(), result);
            return result;
        }
        public void Calculate(IList<int> nums, IList<int> prefix,  IList<IList<int>> result)
        {
            if(nums.Count == 0)
            {
                result.Add(prefix);
                return;
            }
            else
            {
                for(int i=0;i<nums.Count;i++)
                {
                    IList<int> remainder = new List<int>();
                    int item = nums[i];
                    for(int j=0;j<nums.Count;j++)
                    {
                        if(i!=j)
                        {
                            remainder.Add(nums[j]);
                        }
                    }
                    var newPrefix= new List<int>(prefix);
                    newPrefix.Add(item);
                    Calculate(remainder, newPrefix, result);
                }
            }
        }


        // public static void Main(string[] args)
        // {
        //     var source = new int[]{1,2,3};
        //     var result = new PermutationProblem().Permute(source);
        //     Console.WriteLine($"{Utility.PrintArray<int>(source)} => \r\n{Utility.Print2DList<int>(result)}");
        // }
    }
}