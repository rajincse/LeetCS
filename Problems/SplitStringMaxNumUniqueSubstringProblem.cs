using System;
using System.Collections.Generic;

namespace Problems
{
    public class SplitStringMaxNumUniqueSubstringProblem
    {
        private int _maxLength = 0;
        public int MaxUniqueSplit(string s) {
            if(string.IsNullOrWhiteSpace(s))
            {
                return 1;
            }

            
            Dfs(s, 0, new HashSet<string>());
            return _maxLength;
        }

        private void Dfs(string s , int startIndex, HashSet<string> set)
        {
            if(string.IsNullOrWhiteSpace(s)|| startIndex < 0 || startIndex > s.Length)
            {
                return;
            }

            if(startIndex == s.Length)
            {
                _maxLength = Math.Max(_maxLength, set.Count);
                return;
            }

            for(int i=startIndex;i<s.Length;i++)
            {
                string substring = s.Substring(startIndex, i - startIndex+1);
                if(!set.Contains(substring))
                {
                    set.Add(substring);
                    Dfs(s, i+1, set);
                    set.Remove(substring);
                }
            }
        }

        // public static void Main(string[] args)
        // {
        //     string s = "ababccc";
        //     var result = new SplitStringMaxNumUniqueSubstringProblem().MaxUniqueSplit(s);
        //     Console.WriteLine($"{s} => {result}");
        // }
    }
}