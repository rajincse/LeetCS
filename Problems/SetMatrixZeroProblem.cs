using System;
using Common;

namespace Problems
{
    public class SetMatrixZeroProblem
    {
        public void SetZeroes(int[][] matrix) {
            if(matrix == null || matrix.Length == 0 || matrix[0].Length ==0)
            {
                return;
            }

            bool[] rowCheck = new bool[matrix.Length];
            bool[] colCheck = new bool[matrix[0].Length];

            for(int i=0;i<matrix.Length;i++)
            {
                for(int j=0;j<matrix[i].Length;j++)
                {
                    if(matrix[i][j] ==0)
                    {
                        rowCheck[i] = true;
                        colCheck[j] = true;
                    }
                }
            }

            for(int i=0; i< rowCheck.Length;i++)
            {
                if(rowCheck[i])
                {
                    for(int j=0;j<matrix[0].Length;j++)
                    {
                        matrix[i][j] =0;
                    }
                }
            }
            for(int j=0;j< colCheck.Length;j++)
            {
                if(colCheck[j])
                {
                    for(int i=0;i<matrix.Length;i++)
                    {
                        matrix[i][j] =0;
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            int[][] input = new int[][]
            {
                new int[]{1,1,1},
                new int[]{1,0,1},
                new int[]{1,1,1}
            };
            string inputString = Utility.Print2DArray<int>(input);
            new SetMatrixZeroProblem().SetZeroes(input);
            var result = Utility.Print2DArray<int>(input);
            Console.WriteLine($"Input: {inputString} => {result}");
        }
    }
}