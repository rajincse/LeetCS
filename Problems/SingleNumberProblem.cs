using System;
using System.Collections;
using Common;

namespace Problems{
    public class SingleNumberProblem{
        public int SingleNumber(int[] nums) {
            return SingleNumberThrice(nums);
        }

        public int SingleNumberTwice(int[] nums)
        {
            int result = nums[0];
            for(int i=1;i<nums.Length;i++)
            {
                result = result ^ nums[i];
            }

            return result;
        }
        public int SingleNumberThrice(int[] nums)
        {
            int countOnes = 0;
            int result = 0;
            int TotalBitSize = 32;
            for(int i=0;i<TotalBitSize;i++)
            {
                countOnes=0;
                foreach(int n in nums)
                {
                    countOnes += (n >> i) & 1;
                }
                if(countOnes %3 !=0)
                {
                    result = result | (1 << i)  ;
                }
            }

            return result;
        }
        public static void Main(string[] args)
        {
            int [] nums = new int[]{2,3,2,2};
            Console.WriteLine($"Input:{Utility.PrintArray<int>(nums)}, out: {new SingleNumberProblem().SingleNumber(nums)}");
        }
    }
}