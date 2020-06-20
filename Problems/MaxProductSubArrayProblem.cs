using System;
using Common;

namespace Problems
{
    public class MaxProductSubArrayProblem
    {
        public int MaxProduct(int[] nums) {
            int maxProduct = nums[0];
            int currentMaxProduct = nums[0];
            int currentMinProduct = nums[0];
            
            for(int i=1;i<nums.Length;i++)
            {
                int previousMaxProduct = currentMaxProduct;
                int previousMinProduct = currentMinProduct;
                currentMaxProduct = Math.Max(Math.Max(previousMaxProduct * nums[i], previousMinProduct *nums[i] ), nums[i]);
                currentMinProduct = Math.Min(Math.Min(previousMaxProduct * nums[i], previousMinProduct *nums[i] ), nums[i]);

                maxProduct = Math.Max(maxProduct, currentMaxProduct);
            }

            return maxProduct;
        }
        // public static void Main(string[] args)
        // {
        //     int[] nums = new int[]{2,3,-2,-4, -50};
        //     int result = new MaxProductSubArrayProblem().MaxProduct(nums);
        //     Console.WriteLine($"Input: {Utility.PrintArray<int>(nums)} =>{result}");
        // }
    }
}