using System;
using Common;

namespace Problems
{    
    public class MaxNonNegativeProductProblem
    {
        public int MaxProductPath(int[][] grid) {
            if(grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length ==0)
            {
                return -1;
            }
            return MaxProductDp(grid);

        }
        
        private int MaxProductDp(int[][] g)
        {
            int m = g.Length, n = g[0].Length, mod = 1_000_000_007;
            var dp = new long[m,n,2];
            dp[0,0,0] = dp[0,0,1] = g[0][0];
            for (int i = 0; i < m; i++) {
                
                for (int j = 0; j < n; j++) {                
                    
                    if (i == 0 && j == 0) continue;
                    long a = 0, b = 0;
                    if (i == 0) {
                        dp[i,j,0] = dp[i,j,1] = g[i][j] * dp[i,j - 1,0];
                    } else if (j == 0) { 
                        dp[i,j,0] = dp[i,j,1] = g[i][j] * dp[i - 1,j,0];
                    } else {
                        a = g[i][j] * Math.Max(dp[i,j - 1,0], dp[i - 1,j,0]);
                        b = g[i][j] * Math.Min(dp[i,j - 1,1], dp[i - 1,j,1]);
                        dp[i,j,0] = Math.Max(a, b);
                        dp[i,j,1] = Math.Min(a, b);
                    }
                }
            }
            if (dp[m - 1,n - 1,0] < 0) return -1;
            return (int) ((dp[m - 1,n - 1,0]) % mod);
        }
        // public static void Main(string[] args)
        // {
        //     int[][] grid = new int[][]{                
                
        //         new int[]{-1,-2,-3},
        //         new int[]{-2,-3,-3},
        //         new int[]{-3,-3,-2},
        //     };
        //     var result = new MaxNonNegativeProductProblem().MaxProductPath(grid);
        //     Console.WriteLine($"{Utility.Print2DArray<int>(grid, '\n')} =>{result}");
        // }

    }
}