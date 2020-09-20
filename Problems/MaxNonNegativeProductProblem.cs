using System;
using Common;

namespace Problems
{
    // Did not get accepted
    public class MaxNonNegativeProductProblem
    {
        public int MaxProductPath(int[][] grid) {
            (_, var max) = GetMinMaxProduct(grid, 0,0);

            if(max == null || max.Value < 0 )
            {
                return -1;
            }
            return max.Value;
            
        }

        public (int?, int?) GetMinMaxProduct(int[][] grid, int startRow, int startCol)
        {
            if(grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length ==0
            ||
            startRow < 0 || startRow >= grid.Length || startCol <0 || startCol >= grid[0].Length 
            )
            {
                return (null, null);
            }
            int currentVal = grid[startRow][startCol];
            if(startRow == grid.Length-1 && startCol == grid[0].Length-1)
            {
                return (currentVal, currentVal);
            }
            int? currentMin = null;
            int? currentMax = null;
            // go right
            (var min, var max) = GetMinMaxProduct(grid, startRow, startCol+1);
            (currentMin, currentMax) = GetCurrentMinMax(currentMin, currentMax, min, max, currentVal);

            //go down 
            (min,max) = GetMinMaxProduct(grid, startRow+1, startCol);
            (currentMin, currentMax) = GetCurrentMinMax(currentMin, currentMax, min, max, currentVal);

            // //go cross 
            // (min,max) = GetMinMaxProduct(grid, startRow+1, startCol+1);
            // (currentMin, currentMax) = GetCurrentMinMax(currentMin, currentMax, min, max, currentVal);

            return (currentMin, currentMax);
        }

        private (int?, int?) GetCurrentMinMax(int? currentMin, int? currentMax, int? min, int? max, int currentVal)
        {
            if(min != null && max != null )
            {
                if(currentMin == null)
                {
                    currentMin =Math.Min( currentVal * min.Value, currentVal * max.Value);
                }
                currentMin =Math.Min(currentMin.Value, Math.Min( currentVal * min.Value, currentVal * max.Value));
                if(currentMax == null)
                {
                    currentMax =Math.Max( currentVal * min.Value, currentVal * max.Value);
                }
                currentMax =Math.Max(currentMax.Value, Math.Max( currentVal * min.Value, currentVal * max.Value));
            }

            return (currentMin, currentMax);
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