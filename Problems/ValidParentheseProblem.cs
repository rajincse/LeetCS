using System;
using System.Collections;
using System.Collections.Generic;

namespace Problems
{
    class ValidParentheseProblem{
        public bool IsValid(string s) {
            if(string.IsNullOrWhiteSpace(s))
            {
                return true;
            }
            char[] charArray = s.ToCharArray();
            Dictionary<char, char> parenthesesMap = new Dictionary<char, char>();
            parenthesesMap.Add(')', '(');
            parenthesesMap.Add('}', '{');
            parenthesesMap.Add(']', '[');
            Stack<char> parenthesesStack = new Stack<char>();
            foreach(char ch in charArray)
            {
                if(ch == '(' || ch =='{' || ch == '[')
                {
                    parenthesesStack.Push(ch);
                }
                else
                {
                    char matchingStaring = parenthesesMap[ch];
                    if(parenthesesStack.Count ==0)
                    {
                        return false;
                    }
                    char topChar = parenthesesStack.Pop();
                    if(matchingStaring != topChar)
                    {
                        return false;
                    }
                }
            }
            return (parenthesesStack.Count ==0);
        }

        public static void Main(string[] args)
        {
            string input = "[{}{}({})]";
            bool result = new ValidParentheseProblem().IsValid(input);
            Console.WriteLine($"Input:{input} => {result}");
        }
    }
}