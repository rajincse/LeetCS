using System;
using Common;

namespace Problems
{
    public class SearchRotatedSortedII{
        public bool Search(int[] nums, int target) {
            if(nums == null || nums.Length ==0){
                return false;
            }
            int low = 0;
            if(nums[low] == target)
            {
                return true;
            }
            while(low < nums.Length && nums[low] == nums[nums.Length-1])
            {
                low++;
            }

            return BinarySearch(nums, target, low, nums.Length-1);
        }

        public bool BinarySearch(int[] nums, int target, int low, int high)
        {
            if(high < low){
                return false;
            }
            int mid = low + (high-low) /2;

            if(nums[mid] == target)
            {
                return true;
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
        public static void Main(string[] args)
        {
            int[] input = new int[]{2,5,6,0,0,1,2};
            int target = 7;
            Console.WriteLine($"{Utility.PrintArray<int>(input)}, {target} => {new SearchRotatedSortedII().Search(input, target)}");
        }
    }
}
