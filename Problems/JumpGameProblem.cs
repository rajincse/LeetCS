using System;
using Common;

namespace Problems
{
    public class JumpGameProblem
    {
        public bool CanJump(int[] nums) {
            int lastPosition = nums.Length -1;
            for(int i=lastPosition-1;i>=0;i--)
            {
                if(nums[i]+i>= lastPosition)
                {
                    lastPosition =i;
                }
            }
            return lastPosition ==0;
        }
        public static void Main(string[] args)
        {
            int[] input = new int[]{3,2,1,0,4};
            var result = new JumpGameProblem().CanJump(input);
            Console.WriteLine($"input: {Utility.PrintArray<int>(input)} =>{result}");
        }
    }

}