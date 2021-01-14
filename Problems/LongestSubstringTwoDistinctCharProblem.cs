using System;
using System.Collections.Generic;

namespace Problems
{
    public class LongestSubstringTwoDistinctCharProblem
    {

        public int LengthOfLongestSubstringTwoDistinct(string s) {
            if(string.IsNullOrEmpty(s))
            {
                return 0;
            }

            char[] charArray = s.ToCharArray();
            Dictionary<char,int> charCount = new Dictionary<char,int>();
            int max= 0;
            int left = 0;
            int right = 0;
            while(right < charArray.Length)
            {
                char rightChar = charArray[right];
                if(!charCount.ContainsKey(rightChar))
                {
                    charCount[rightChar] =0;
                }
                charCount[rightChar]++;

                while(charCount.Keys.Count > 2)
                {
                    char leftChar = charArray[left];
                    charCount[leftChar]--;                    
                    left++;
                    if(charCount[leftChar] <=0)
                    {
                        charCount.Remove(leftChar);
                    }
                }
                int length = right - left+1;
                max = Math.Max(max, length);
                right++;
            }
            return max;
        }

        // public static void Main(string [] args)
        // {
        //     var s = "dadsadsadsadasdasdasdasdasaswewqewqeqw";
        //     var result = new LongestSubstringTwoDistinctCharProblem().LengthOfLongestSubstringTwoDistinct(s);
        //     Console.WriteLine($"{s}=>{result}");
        // }
        
    }
}