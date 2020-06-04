using System;
using System.Collections.Generic;

namespace Problems
{
    public class MinimumWindowSubstringProblem
    {
        public string MinWindow(string s, string t) {
            if(string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
            {
                return string.Empty;
            }

            Dictionary<char, int> charOccurrenceMapT = new Dictionary<char, int>();
            char[] charArrayT = t.ToCharArray();
            foreach(char c in charArrayT)
            {
                int currentCount = charOccurrenceMapT.GetValueOrDefault(c,0);
                currentCount++;
                charOccurrenceMapT[c] = currentCount;
            }
            int distinctCharsT = charOccurrenceMapT.Keys.Count;

            int minWindowSize = -1;
            int minWindowLeft = 0;
            int minWindowRight = 0;
            int left =0;
            int right =0;

            Dictionary<char, int> charOccurrenceMapWindow = new Dictionary<char, int>();
            char[] charArrayS = s.ToCharArray();
            int currentlyExistingChars = 0;
            while(right< charArrayS.Length)
            {
                char rightChar = charArrayS[right];
                int rightCharCount = charOccurrenceMapWindow.GetValueOrDefault(rightChar, 0);
                rightCharCount++;
                charOccurrenceMapWindow[rightChar] = rightCharCount;

                if(charOccurrenceMapT.ContainsKey(rightChar) && charOccurrenceMapT[rightChar] == charOccurrenceMapWindow[rightChar])
                {
                    currentlyExistingChars++;
                }
                while(left <= right && currentlyExistingChars == distinctCharsT)
                {
                    char leftChar = charArrayS[left];
                    if(minWindowSize == -1 || right -left+1 < minWindowSize)
                    {
                        minWindowSize = right -left+1;
                        minWindowLeft = left;
                        minWindowRight = right;
                    }
                    
                    left++;
                    int leftCharCount = charOccurrenceMapWindow.GetValueOrDefault(leftChar,0);
                    leftCharCount--;
                    charOccurrenceMapWindow[leftChar] = leftCharCount;
                    if(charOccurrenceMapT.ContainsKey(leftChar) &&  charOccurrenceMapWindow[leftChar] < charOccurrenceMapT[leftChar] )
                    {
                        currentlyExistingChars--;
                    }
                }
                right++;
            }
            if(minWindowSize == -1)
            {
                return string.Empty;
            }

            return s.Substring(minWindowLeft, minWindowSize);
        }
        // public static void Main(string[] args)
        // {
        //     string s ="aaaaaaaaaaaabbbbbcdd";
        //     string t = "abcdd";
            
        //     var result = new MinimumWindowSubstringProblem().MinWindow(s, t); // "abbbbbcdd"
        //     Console.WriteLine($"Input: {s},{t} => {result}");
        // }
    }
}