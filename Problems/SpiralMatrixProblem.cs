using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class SpiralMatrixProblem
    {
        public IList<int> SpiralOrder(int[][] matrix) {
            IList<int> result = new List<int>();
            if(matrix == null || matrix.Length ==0 || matrix[0] == null || matrix[0].Length ==0)
            {
                return result;
            }
            int m = matrix.Length;
            int n = matrix[0].Length;
            int maxRowOffset = m/2;
            int maxColOffset = n/2;
            for(int rowOffset = 0, colOffset =0;rowOffset <= maxRowOffset && colOffset<= maxColOffset;rowOffset++, colOffset++)
            {
                Generate(result, matrix, rowOffset, m-1-rowOffset, colOffset, n-1-colOffset);
            }

            return result;
        }
        private void Generate(IList<int> result , int[][] matrix, int startRowIndex, int endRowIndex, int startColIndex, int endColIndex)
        {
            if(startRowIndex > endRowIndex || startColIndex > endColIndex || matrix == null || matrix.Length ==0 || matrix[0] == null || matrix[0].Length ==0)
            {
                return;
            }
            //top
            for(int j=startColIndex;j<= endColIndex;j++)
            {
                result.Add(matrix[startRowIndex][j]);
            }
            //right
            for(int i=startRowIndex+1;i<= endRowIndex-1;i++)
            {
                result.Add(matrix[i][endColIndex]);
            }
            //bottom            
            for(int j=endColIndex;startRowIndex < endRowIndex && j>= startColIndex;j--)
            {
                result.Add(matrix[endRowIndex][j]);
            }
            //left            
            for(int i=endRowIndex-1;startColIndex < endColIndex &&  i>= startRowIndex+1;i--)
            {
                result.Add(matrix[i][startColIndex]);
            }
        }
        public static void Main(string[] args)
        {
            int[][] input = new int[][]{
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{4,5,6},
                new int[]{7,8,9}
                // new int[]{1,2,3,4,5,6,7},
                // new int[]{4,5,6,7,8,9,1},
                // new int[]{7,8,9,1,2,3,4},
                // new int[]{4,5,6,7,8,9,1}
            };                        
            var result = new SpiralMatrixProblem().SpiralOrder(input);
            Console.WriteLine($"Input:\n{Utility.Print2DArray<int>(input, '\n')}=> {Utility.PrintList<int>(result)}");
        }
    }
}