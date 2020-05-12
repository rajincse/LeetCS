using System;
using Common;

namespace  Problems
{
    public class RemoveDuplicateProblem {
        public int RemoveDuplicates(int[] nums) {
            if(nums == null)
            {
                return 0;
            }
            if(nums.Length < 2)
            {
                return nums.Length;
            }

            int currentIndex =0;            
            for(int i=1;i<nums.Length;i++)
            {
                if(nums[i] != nums[currentIndex])
                {
                    currentIndex++;
                    //swap                    
                    nums[currentIndex] = nums[i];
                }
            }

            return currentIndex+1;
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{1,1,2,3,3,3,4};
        //     Console.WriteLine($"{Utility.PrintArray<int>(input)} => {new RemoveDuplicateProblem().RemoveDuplicates(input)}");
        // }
    }
}
