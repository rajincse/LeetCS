using System;
using Common;

namespace Problems
{
    public class SignOfArrayProblem
    {
        public int ArraySign(int[] nums) {
            if(nums == null || nums.Length == 0)
            {
                return 0;
            }
            if(nums[0] == 0)
            {
                return 0;
            }
            int ans = (nums[0] >> 31 ) & 0x1;
            // Console.WriteLine($"num:{nums[0]} => {Convert.ToString(nums[0], 2)}");
            // Console.WriteLine($"ans:{ans} => {Convert.ToString(ans, 2)}");
            for(int i=1;i<nums.Length;i++)
            {
                if(nums[i] == 0)
                {
                    return 0;
                }
                ans = ans ^ ((nums[i] >> 31 ) & 0x1);
                // Console.WriteLine($"num:{nums[i]} => {Convert.ToString(nums[i], 2)}");
                // Console.WriteLine($"ans:{ans} => {Convert.ToString(ans, 2)}");
            }
            // Console.WriteLine($"last:{ans} => {Convert.ToString(ans, 2)}");
            return ans == 0? 1: -1; 
        }
        // public static void Main(string[] args)
        // {
        //     var input = new int[]{-1,-2,-3,-4,3,2,1};
        //     var result = new SignOfArrayProblem().ArraySign(input);
        //     Console.WriteLine($"{Utility.PrintArray<int>(input)}=>{result}");
        // }
    }
}