// https://leetcode.com/problems/kth-missing-positive-number/description/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;
using Common;

namespace Problems.ArrayProblems
{
    public class KthMissingPositiveNumberProblem
    {
        public int FindKthPositive(int[] arr, int k)
        {
            if (arr is null || arr.Length == 0)
            {
                return k;
            }

            var candidate = k;
            var expectedItem = 1;

            foreach (var arrItem in arr)
            {
                if (arrItem > candidate)
                {
                    return candidate;
                }

                expectedItem = arrItem + 1;
                candidate++;
            }

            return candidate;
        }

        // public static void Main(string[] args)
        // {
        //     var input = new int[] { 2, 3, 4, 7, 11 };
        //     var k = 5;
        //     var result = new KthMissingPositiveNumberProblem().FindKthPositive(input, k);
        //     Console.WriteLine($"arr: {Utility.PrintArray<int>(input)}, k:{k}=> {result}");
        // }
    }
}