// https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/description/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;

namespace Problems
{
    public class MinRemoveToMakeValidProblem
    {
        public string MinRemoveToMakeValid(string s)
        {
            return string.Empty;
        }

        public static void Main(string[] args)
        {
            var input = "lee(t(c)o)de)";
            var result = new MinRemoveToMakeValidProblem().MinRemoveToMakeValid(input);
            Console.WriteLine($"{input} => {result}");
        }
    }
}