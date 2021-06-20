using System;
using Common;

namespace Problems
{
    public class PartitionDisjointProblem
    {
        public int PartitionDisjoint(int[] nums) {
            int[] maxLeft = new int[nums.Length];
            int[] minRight = new int[nums.Length];
            
            int max = nums[0];
            for(int i=0;i<nums.Length;i++)
            {
                max = Math.Max(nums[i], max);
                maxLeft[i] = max;
            }
            
            int min= nums[nums.Length-1];
            
            for(int i=nums.Length-1;i>=0;i--)
            {
                min = Math.Min(nums[i], min);
                minRight[i] = min;
            }
            
            for(int i=1;i<nums.Length;i++)
            {
                if(maxLeft[i-1] <= minRight[i])
                {
                    return i;
                }
            }
            
            return -1;
        }
        // public static void Main(string[] args)
        // {
        //     var input = new int[]{5,0,3,5,6};
        //     var result = new PartitionDisjointProblem().PartitionDisjoint(input);
        //     Console.WriteLine($"{Utility.PrintArray<int>(input)} => {result}");
        // }
    }
}