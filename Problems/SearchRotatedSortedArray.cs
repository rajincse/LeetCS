using System;
using Common;

namespace Problems
{
    public class SearchRotatedSortedArray{
        public int Search(int[] nums, int target) {
            if(nums == null || nums.Length ==0){
                return -1;
            }


            return BinarySearch(nums, target, 0, nums.Length-1);
        }

        public int BinarySearch(int[] nums, int target, int low, int high)
        {
            if(high < low){
                return -1;
            }
            int mid = low + (high-low) /2;

            if(nums[mid] == target)
            {
                return mid;
            }
            else if(nums[low] <= nums[mid])
            {
                if(nums[low] <= target && target < nums[mid])
                {
                    return BinarySearch(nums, target, low, mid-1);
                }
                else
                {
                    return BinarySearch(nums, target, mid+1, high);
                }
            }
            else{
                if(nums[mid]< target && target <= nums[high])
                {
                    return BinarySearch(nums, target, mid+1, high);
                }
                else
                {
                    return BinarySearch(nums, target, low, mid-1);
                }
            }
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{4,5,6,7,8,0,1};
        //     int target = 1;
        //     Console.WriteLine($"{Utility.PrintArray<int>(input)}, {target} => {new SearchRotatedSortedArray().Search(input, target)}");
        // }
    }
}
