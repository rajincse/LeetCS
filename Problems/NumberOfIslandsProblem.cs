using System;
using Common;

namespace Problems
{
    public class NumberOfIslandsProblem
    {
         public int NumIslands(char[][] grid) {
             if(grid == null || grid.Length == 0 || grid[0].Length == 0)
             {
                 return 0;
             }
             int totalIslands = 0;

             for(int i=0;i<grid.Length;i++)
             {
                 for(int j=0;j<grid[i].Length;j++)
                 {
                     if(grid[i][j] =='1')
                     {
                         totalIslands++;
                         MarkCellAsVisited(i, j, grid);
                     }
                 }
             }
             return totalIslands;
        }

        public void MarkCellAsVisited(int row, int column, char[][] grid)
        {
            if(grid == null || grid.Length == 0 || grid[0].Length == 0 || row<0 || row >= grid.Length || column<0 || column >= grid[0].Length)
            {
                return ;
            }

            if(grid[row][column] =='1')
            {
                grid[row][column] = 'X';
                MarkCellAsVisited(row-1, column, grid);
                MarkCellAsVisited(row+1, column, grid);
                MarkCellAsVisited(row, column-1, grid);
                MarkCellAsVisited(row, column+1, grid);
            }
        }
        // public static void Main(string[] args)
        // {

        //     char[][] grid = new char[][]
        //     {
        //         "11110".ToCharArray(),
        //         "11010".ToCharArray(),
        //         "11000".ToCharArray(),
        //         "00000".ToCharArray()
        //     };
        //     var result = new NumberOfIslandsProblem().NumIslands(grid);
        //     Console.WriteLine($"Input: \n{Utility.Print2DArray<char>(grid , '\n')}\n=> {result}");
        // }
    }
}