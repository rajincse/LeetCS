using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class NumTripletsProblem
    {
        public int NumTriplets(int[] nums1, int[] nums2) {
            if(nums1 == null || nums1.Length ==0 || nums2 == null || nums2.Length ==0)
            {
                return 0;
            }
            
            Dictionary<int,int> valueToIndex1 = new Dictionary<int,int>();
            for(int i=0;i<nums1.Length;i++)
            {
                valueToIndex1[nums1[i]] = i;
            }
            
            Dictionary<int,int> valueToIndex2 = new Dictionary<int,int>();
            for(int i=0;i<nums2.Length;i++)
            {
                valueToIndex2[nums2[i]] = i;
            }
            
            int counter =0;
            //Type -1 
            
            for(int i=0;i<nums1.Length;i++)
            {
                var mult =  (long) nums1[i] * (long) nums1[i];
                var result = GetTwoMultPossibility(nums2,mult, valueToIndex2);
                counter += result;
            }
            
            //Type -2
            
            for(int i=0;i<nums2.Length;i++)
            {
                var mult =  (long) nums2[i] * (long) nums2[i];
                var result = GetTwoMultPossibility(nums1, mult, valueToIndex1);
                counter += result;
            }
            
            return counter;
            
        }
        
        private int GetTwoMultPossibility(int[] nums, long target, Dictionary<int,int> valueToIndex )
        {
            int counter =0;
            for(int i=0;i<nums.Length;i++)
            {
                long remaining = target / (long) nums[i];
                if(target % nums[i] == 0)
                {
                    for(int j=i;j<nums.Length;j++)
                    {
                        if(i != j && nums[j] == remaining)
                        {
                            counter++;
                        }
                    }
                }
                
            }
            
            return counter;
        }

        // public static void Main(string[] args)
        // {
        //     var nums1 = new int[]{100000,100000};
        //     var nums2 = new int[]{100000,100000,100000};

        //     var result = new NumTripletsProblem().NumTriplets(nums1, nums2);
        //     Console.WriteLine($"[{Utility.PrintArray<int>(nums1)}], [{Utility.PrintArray<int>(nums2)}] => {result}");
        // }
    }
}