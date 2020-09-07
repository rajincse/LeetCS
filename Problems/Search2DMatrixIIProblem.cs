using System;
using Common;

namespace Problems
{
    public class Search2DMatrixIIProblem
    {
        public bool SearchMatrix(int[,] matrix, int target) {
            if(matrix == null || matrix.Rank != 2 || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return false;
            }
            return SearchMatrix(matrix, target, 0, matrix.GetLength(0) -1, 0, matrix.GetLength(1)-1);
        }
        private bool SearchMatrix(int [,] matrix, int target, int startRow, int endRow, int startCol, int endCol)
        {
            if(matrix == null || matrix.Rank != 2 || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return false;
            }

            if(
                startRow < 0 || endRow >= matrix.GetLength(0) || startRow > endRow
                ||
                startCol < 0 || endCol >= matrix.GetLength(1) || startCol > endCol
            )
            {
                return false;
            }
            int rowCount = endRow - startRow+1;
            int colCount = endCol - startCol+1;
            if(rowCount == 1 && colCount == 1)
            {
                return target == matrix[startRow, startCol];
            }

            if(target < matrix[startRow, startCol] || target > matrix[endRow, endCol])
            {
                return false;
            }
            bool exist = false;
            int pivotRow = startRow + (rowCount-1)/2;
            int pivotCol = startCol + (colCount-1)/2;
            
            exist = SearchMatrix(matrix, target, startRow, pivotRow, startCol, pivotCol);
            

            if(!exist)
            {
                exist = SearchMatrix(matrix, target, startRow, pivotRow, pivotCol+1, endCol);
            }
            else
            {
                return true;
            }

            if(!exist)
            {
                exist = SearchMatrix(matrix, target, pivotRow+1, endRow, startCol, pivotCol);
            }
            else
            {
                return true;
            }
            if(!exist)
            {
                exist = SearchMatrix(matrix, target, pivotRow+1, endRow, pivotCol+1, endCol);
            }
            else
            {
                return true;
            }

            return exist;
        }

        // public static void Main(string[] args)
        // {
        //     int[, ] matrix = new int[,]
        //     {
        //         {1,   4,  7, 11, 15},
        //         {2,   5,  8, 12, 19},
        //         {3,   6,  9, 16, 22},
        //         {10, 13, 14, 17, 24},
        //         {18, 21, 23, 26, 30}
        //     };
        //     int target = 20;
        //     var result = new Search2DMatrixIIProblem().SearchMatrix(matrix, target);
        //     Console.WriteLine($"{Utility.Print2DArray<int>(matrix, '\n')}, {target} => {result}");
        // }
    }
}