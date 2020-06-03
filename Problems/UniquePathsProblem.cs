using System;

namespace Problems
{
    public class UniquePathsProblem
    {
        public int UniquePaths(int m, int n) {
            if(m<1 || n <1)
            {
                return 0;
            }            
            int[][] dp = new int[m][];
            for(int i=0;i<dp.Length;i++)
            {
                dp[i] = new int[n];
                for(int j=0;j<dp[i].Length;j++)
                {
                    dp[i][j] = -1;
                }
            }
            
            return UniquePathRecursive(0,0, m, n, dp);
        }

        private int UniquePathRecursive(int currentRow , int currentCol, int m, int n, int[][] dp)
        {
            if( currentRow >= m || currentCol >= n)
            {
                return 0;
            }
            if(dp != null && dp[currentRow][currentCol] != -1)
            {
                return dp[currentRow][currentCol];
            }
            if(currentRow == m-1 && currentCol == n-1) {
                dp[currentRow][currentCol] = 1;
                return 1;
            } 
            
            int down = 0;
            if(currentRow <m-1)
            {
                down = UniquePathRecursive(currentRow+1, currentCol, m, n, dp);
            }
            int right = 0;
            if(currentCol < n-1)
            {
                right = UniquePathRecursive(currentRow, currentCol+1, m, n, dp);
            }
            dp[currentRow][currentCol] = down + right;
            return dp[currentRow][currentCol] ;
        }
        // public static void Main(string[] args)
        // {
        //     int m = 7;
        //     int n = 3;
        //     var result = new UniquePathsProblem().UniquePaths(m, n);
        //     Console.WriteLine($"input => ({m}, {n}) => {result}");
        // }
    }
}