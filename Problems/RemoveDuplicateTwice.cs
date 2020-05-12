using System;
using Common;

namespace  Problems
{
    public class RemoveDuplicateTwice {
        public int RemoveDuplicates(int[] nums) {
            if(nums == null)
            {
                return 0;
            }
            if(nums.Length < 2)
            {
                return nums.Length;
            }
            int maxCount =2;
            int currentIndex =0;                       
            int currentCount =1;
            for(int i=1;i<nums.Length;i++)
            {
                if(nums[i] == nums[currentIndex] && currentCount < maxCount)
                {
                    currentIndex++;
                    currentCount++;
                    nums[currentIndex] = nums[i];
                }
                if(nums[i] != nums[currentIndex])
                {
                    currentIndex++;
                    currentCount=1;                                       
                    nums[currentIndex] = nums[i];
                }
            }

            return currentIndex+1;
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{1,1,1,2,2,3};
        //     Console.WriteLine($"{Utility.PrintArray<int>(input)} => {new RemoveDuplicateTwice().RemoveDuplicates(input)}");
        // }
    }
}
