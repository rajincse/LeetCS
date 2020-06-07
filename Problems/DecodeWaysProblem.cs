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
            int[] dp = new int[charArray.Length];
            for(int i=0;i<dp.Length;i++)
            {
                dp[i] = -1;
            }
            return GetNumberOfWays(charArray , 0, charArray.Length-1, dp);
        }

        public int GetNumberOfWays(char[] charArray, int start, int end, int[] dp)
        {
            if(charArray == null || charArray.Length ==0 || start > end || start <0 || end >= charArray.Length || dp == null || dp.Length ==0 || dp.Length != charArray.Length)
            {
                return 0;
            }
            if(dp[start] > -1)
            {
                return dp[start];
            }
            int n = end - start +1;
            if(n ==0 )
            {
                dp[start] = 0;
                return dp[start];
            }
            else if(n==1 && IsACode(charArray , start, end))
            {
                dp[start] = 1;
                return dp[start];
            }
            else if( n==2)
            {
                int ways = 0;
                if( IsACode(charArray, start , start) && IsACode(charArray, end , end))
                {
                    ways++;
                }
                if(IsACode(charArray, start , end))
                {
                    ways++;
                }
                
                dp[start] = ways;
                return dp[start];
            }
            else
            {
                int ways = 0;
                if( IsACode(charArray, start , start) )
                {
                    ways = GetNumberOfWays(charArray , start+1 , end, dp);
                }
                if(IsACode(charArray, start , start+1))
                {
                    ways = ways +  GetNumberOfWays(charArray , start+2 , end, dp);
                }
                dp[start] = ways;
                return dp[start];
            }

        }

        public bool IsACode(char[] charArray, int start, int end)
        {
            if(charArray == null || charArray.Length ==0 || start > end || start <0 || end >= charArray.Length)
            {
                return false;
            }
            if(charArray[start]<= '0' || charArray[start] >'9' || charArray[end]< '0' || charArray[end] >'9')
            {
                return false;
            }

            int n = end - start +1;
            if(n > 2)
            {
                return false;
            }

            int val = 0;
            if( n == 1)
            {
                val = (charArray[end] -'0');
            }
            
            if(n ==2)
            {
                val = (charArray[start]-'0') * 10+  (charArray[end] -'0');
            }

            return val > 0 && val < 27;

        }
        // public static void Main(string[] args)
        // {
        //     string input = "2345";            
        //     var result = new  DecodeWaysProblem().NumDecodings(input);
        //     Console.WriteLine($"Input: {input} => {result}");            
        // }
    }
}