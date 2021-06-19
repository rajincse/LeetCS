using System;
using Common;

namespace Problems
{
    public class MinDeletionProblem{
        public int MinDeletions(string s) {
            if(string.IsNullOrEmpty(s))
            {
                return 0;
            }
            
            int[] charFrequency = new int[26];
            char[] charArray = s.ToCharArray();
            
            foreach(char c in charArray)
            {
                charFrequency[c-'a']++;
            }
            
            Array.Sort(charFrequency, (int a, int b) =>{ return b-a;});
            
            int currentFrequency = int.MaxValue;
            int result = 0;
            foreach(int frequency in charFrequency)
            {
                if(frequency == 0)
                {
                    break;
                }
                if(frequency>= currentFrequency)
                {
                    if(currentFrequency == 0)
                    {
                        result+= frequency;                        
                    }
                    else
                    {
                        result += (frequency - currentFrequency)+1;
                        currentFrequency--;
                    }
                }
                else
                {
                    currentFrequency = frequency;
                }
            }
            return result;
        }

        // public static void Main(string[] args)
        // {
        //     var input = "eaabbacc";
        //     var result = new MinDeletionProblem().MinDeletions(input);
        //     Console.WriteLine($"{input}={result}");
        // }
    }
}