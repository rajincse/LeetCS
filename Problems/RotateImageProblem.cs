using System;
using Common;

namespace Problems
{
    public class RotateImageProblem
    {
        public void Rotate(int[][] matrix) {
            if(matrix == null || matrix.Length ==0 || matrix[0] == null || matrix[0].Length ==0 || matrix.Length != matrix[0].Length)
            {
                return;
            }
            int radius = matrix.Length/2;
            for(int i=0;i<=radius;i++)
            {
                
                for(int j=i;j<matrix.Length-1-i;j++)
                {
                    int top = matrix[i][j];
                    int right = matrix[j][matrix.Length-1-i];
                    int bottom = matrix[matrix.Length-1-i][matrix.Length-1-j];
                    int left = matrix[matrix.Length-1-j][i];
                    //top -> right
                     matrix[j][matrix.Length-1-i] = top; 
                    //right -> bottom
                    matrix[matrix.Length-1-i][matrix.Length-1-j] = right; 
                    //bottom -> left
                    matrix[matrix.Length-1-j][i] = bottom  ;
                    //left -> top
                    matrix[i][j] = left;
                }
            }
        }
        // public static void Main(string[] args)
        // {
        //     int[][] input = new int[][]{
        //         new int[]{5, 1, 9,11},
        //         new int[]{2, 4, 8,10},
        //         new int[]{13, 3, 6, 7},
        //         new int[]{15,14,12,16}
        //         };
        //     string inputString = Utility.Print2DArray<int>(input);
        //     new RotateImageProblem().Rotate(input);
        //     Console.WriteLine($"Input:{inputString}=> {Utility.Print2DArray<int>(input)}");
        // }
    }
}