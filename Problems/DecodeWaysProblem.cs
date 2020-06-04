using System;

namespace Problems
{
    public class DecodeWaysProblem
    {
        public int NumDecodings(string s) {
            if(string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            char[] charArray = s.ToCharArray();
            if(charArray[0] == '0')
            {
                return 0;
            }
            if(charArray.Length ==1 )
            {
                return 1;
            }
            bool containsZero = false;
            int totalCombinations = 0;
            for(int i=0;i<charArray.Length-1;i++)
            {
                int msb = charArray[i] -'0';
                int lsb = charArray[i+1] -'0';
                if(msb == 0 && lsb == 0)
                {
                    return 0;
                }
                else if(msb ==0 || lsb ==0)
                {
                    containsZero = true;                    
                }

                if(msb != 0)
                {
                    int val = msb * 10 + lsb;
                    totalCombinations = val < 27 ? totalCombinations+1: totalCombinations;
                }
            }

            return containsZero? totalCombinations: totalCombinations+1;
        }
        public static void Main(string[] args)
        {
            string input = "1010";            
            var result = new  DecodeWaysProblem().NumDecodings(input);
            Console.WriteLine($"Input: {input} => {result}");
        }
    }
}