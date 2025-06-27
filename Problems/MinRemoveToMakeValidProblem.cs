// https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/description/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class MinRemoveToMakeValidProblem
    {
        public string MinRemoveToMakeValid(string s)
        {
            var stack = new Stack<int>();
            var chars = s.ToCharArray();
            var deleteIndices = new bool[chars.Length];

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        deleteIndices[i] = true;    
                    }
                    
                }
                else if (chars[i] == '(')
                {
                    stack.Push(i);
                }
            }

            while (stack.Count > 0)
            {
                var i = stack.Pop();
                deleteIndices[i] = true;
            }

            var result = new StringBuilder();
            for (int i = 0; i < deleteIndices.Length; i++)
            {
                if (!deleteIndices[i])
                {
                    result.Append(chars[i]);
                }
            }

            return result.ToString();
        }

        // public static void Main(string[] args)
        // {
        //     var input = "a)b(c)d";
        //     var result = new MinRemoveToMakeValidProblem().MinRemoveToMakeValid(input);
        //     Console.WriteLine($"{input} => {result}");
        // }
    }
}