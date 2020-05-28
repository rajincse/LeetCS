using System;
using System.Collections.Generic;

namespace Problems{
    public class LengthOfLongestSubstringProblem{
        public int LengthOfLongestSubstring(string s) {
            if(string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            char[] charArray = s.ToCharArray();
            int maxLength = 0;
            int start=0;
            int end=0;
            HashSet<int> charSet = new HashSet<int>();
            while(start < charArray.Length && end < charArray.Length)
            {
                char ch = charArray[end];
                if(!charSet.Contains(ch))
                {
                    charSet.Add(ch);
                    end++;
                    maxLength = Math.Max(maxLength, end- start);
                }
                else
                {
                    char startChar = charArray[start];
                    start++;
                    charSet.Remove(startChar);
                }
            }

            return maxLength;   
        }
        
        public static void Main(string[] args)
        {
            string input = null ;
            int result= new LengthOfLongestSubstringProblem().LengthOfLongestSubstring(input);
            Console.WriteLine($"Input:{input} => {result}");
        }
    }

}