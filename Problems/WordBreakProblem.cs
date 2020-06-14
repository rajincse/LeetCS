using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Problems
{
    public class WordBreakProblem
    {
        public bool WordBreak(string s, IList<string> wordDict) {
            if(string.IsNullOrEmpty(s) || wordDict == null || wordDict.Count ==0)
            {
                return false;
            }
            HashSet<string> dict = new HashSet<string>();
            foreach(string word in wordDict)
            {
                dict.Add(word);
            }
            int[,] dp = new int[s.Length, s.Length];

            return WordBreak(s, 0, s.Length-1, dict, dp);
        }

        private bool WordBreak(string s, int start, int end, HashSet<string> dict, int[,] dp)
        {
            if(string.IsNullOrEmpty(s) || dict == null || dict.Count == 0 )
            {
                return false;
            }

            if(start > end)
            {
                dp[start, end] =2;
                return true;
            }
            else if(dp[start, end] > 0)
            {
                return dp[start, end] ==2;
            }
            else
            {
                string substring = s.Substring(start , end-start+1);
                if(dict.Contains(substring))
                {
                    dp[start, end] =2;
                    return true;
                }
                else
                {
                    StringBuilder  sb = new StringBuilder();
                    for(int i=start;i<= end; i++)
                    {
                        sb.Append(s[i]);
                        if(dict.Contains(sb.ToString()) && WordBreak(s, i+1, end, dict, dp))
                        {
                            dp[start, end] =2;
                            return true;
                        }
                    }
                    dp[start, end] =1;                    
                    return false;
                }
            }
            
        }
        public static void Main(string[] args)
        {
            string s = "catsandog";
            var dictString =  new List<string>{"cats", "dog", "sand", "and", "cat"};
            var result = new WordBreakProblem().WordBreak(s, dictString);
            Console.WriteLine($"Input: {s}, [{Utility.PrintList<string>(dictString)}] => {result}");
        }
    }
}