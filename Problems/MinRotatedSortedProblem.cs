using System;
using Common;

namespace Problems
{
    public class MinRotatedSortedProblem
    {
        public int FindMin(int[] nums) {
            if(nums == null || nums.Length ==0)
            {
                return int.MaxValue;
            }


            return BinarySearch(0, nums.Length-1, nums);
        }

        public int BinarySearch(int low, int high, int[] nums)
        {
            if(low  > high )
            {
                return int.MaxValue;
            }
            else if(low == high)
            {
                return nums[low];
            }
            else if(nums[low] < nums[high])
            {
                return nums[low];
            }
            else{
                int mid = low+ (high-low)/2;
                if(nums[low]<= nums[mid])
                {
                    return BinarySearch(mid+1, high, nums);
                }
                else
                {
                    return BinarySearch(low, mid, nums);
                }
            }
        }
        // public static void Main(string [] args)
        // {
        //     int[] nums = new int[]{5,6,0,1,2,3,4};
        //     var result = new MinRotatedSortedProblem().FindMin(nums);
        //     Console.WriteLine($"Input: {Utility.PrintArray<int>(nums)} =>{result}"); 
        // }
    }
}