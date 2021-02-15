using System;
using System.Collections.Generic;

namespace Problems
{
    public class LongestSubstringKDistinctProblem
    {
        public static void Main(string[] args)
        {
            var s = "a@b$5!a8alskj234jasdf*()@$&%&#FJAvjjdaurNNMa8ASDF-0321jf?>{}L:fh";
            int k = 10;
            var result = new LongestSubstringKDistinctProblem().LengthOfLongestSubstringKDistinct(s, k);
            Console.WriteLine($"{s}, {k} => {result}");
        }

        public int LengthOfLongestSubstringKDistinct(string s, int k) {
            if(s == null || s.Length ==0 || k <=0)
            {
                return 0;
            }
            int left =0;
            int right =0;
            char[] charArray = s.ToCharArray();
            Dictionary<char, int> charCountMap = new Dictionary<char, int>();
            int maxLength = 0;
            while(left <= right && right < charArray.Length)
            {
                char c = charArray[right];
                if(!charCountMap.ContainsKey(c))
                {
                    charCountMap[c] = 0;
                }
                charCountMap[c]++;

                int uniqueCharacter = GetUniqueCharCount(charCountMap);
                if(uniqueCharacter<=k)
                {
                    int length = right - left +1;
                    maxLength = Math.Max(maxLength, length);
                    
                }
                else
                {                    
                    while(uniqueCharacter> k && left <= right)
                    {
                        char leftChar = charArray[left];
                        charCountMap[leftChar]--;
                        if(charCountMap[leftChar] <= 0)
                        {
                            charCountMap.Remove(leftChar);
                        }
                        uniqueCharacter = GetUniqueCharCount(charCountMap);
                        left++;
                    }
                }
                right++;
            }
            return maxLength;
        }

        public int GetUniqueCharCount(Dictionary<char, int> charCountMap)
        {
            if(charCountMap == null || charCountMap.Keys.Count ==0 )
            {
                return 0;
            }
            return charCountMap.Keys.Count;
        }
    }
}