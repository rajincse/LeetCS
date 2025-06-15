// https://leetcode.com/problems/valid-palindrome-ii/description/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;

namespace Problems
{
    public class ValidPalindromeIIProblem
    {
        public bool IsSubstringPalindrome(string s, int start, int end)
        {
            Console.WriteLine($" Substring match {s.Substring(start, end - start + 1)}");
            char[] chars = s.ToCharArray();
            int left = start;
            int right = end;
            while (left < right)
            {
                if (chars[left] != chars[right])
                {
                    Console.WriteLine($"Matching {left}=>{chars[left]} and {right}=>{chars[right]}");
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public bool ValidPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            char[] chars = s.ToCharArray();
            while (start < end)
            {
                if (chars[start] != chars[end])
                {
                    return IsSubstringPalindrome(s, start, end - 1)
                    || IsSubstringPalindrome(s, start + 1, end);
                }

                start++;
                end--;
            }

            return true;

        }

        // public static void Main(string[] args)
        // {
        //     string input = "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga";
        //     var result = new ValidPalindromeIIProblem().ValidPalindrome(input);
        //     Console.WriteLine($"Input: {input} => {result}");
        // }
    }
}