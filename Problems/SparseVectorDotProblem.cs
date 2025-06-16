// https://leetcode.com/problems/dot-product-of-two-sparse-vectors/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class SparseVector
    {
        public Dictionary<int, int> Map { get; set; }

        public SparseVector(int[] nums)
        {
            this.Map = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    this.Map[i] = nums[i];
                }
            }
        }

        // Return the dotProduct of two sparse vectors
        public int DotProduct(SparseVector vec)
        {
            var result = 0;
            foreach (var i in this.Map.Keys)
            {
                if (vec.Map.ContainsKey(i))
                {
                    result += this.Map[i] * vec.Map[i];
                }
            }
            return result;
        }
    }
    public class SparseVectorDotProblem
    {
        public static void Main(string[] args)
        {
            var nums1 = new int[] { 1, 0, 0, 2, 3 };
            var nums2 = new int[] { 0, 3, 0, 4, 0 };

            var vector1 = new SparseVector(nums1);
            var vector2 = new SparseVector(nums2);

            var result = vector1.DotProduct(vector2);

            Console.WriteLine($"num1: [{Utility.PrintArray<int>(nums1)}]\nnum2: [{Utility.PrintArray<int>(nums2)}]\nresult: {result}");
        }
    }
}