// https://leetcode.com/problems/shortest-path-in-binary-matrix/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;
using Common;

namespace Problems.Matrix
{
    public class ShortestPathBinaryMatrixProblem
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            return 0;
        }

        public static void Main(string[] args)
        {
            var input = new int[][]{
                [0,1],
                [1,0]
            };

            var result = new ShortestPathBinaryMatrixProblem().ShortestPathBinaryMatrix(input);
            Console.WriteLine($"input = {Utility.Print2DArray<int>(input)}=> {result}");
        }
    }
}