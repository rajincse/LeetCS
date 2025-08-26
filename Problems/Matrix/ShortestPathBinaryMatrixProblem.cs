// https://leetcode.com/problems/shortest-path-in-binary-matrix/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;
using System.Collections.Generic;
using Common;

namespace Problems.Matrix
{
    public class ShortestPathBinaryMatrixProblem
    {
        public class MatrixCell
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public int Level { get; set; }
        }
        private int[][] Grid { get; set; }
        private bool[,] VisitedMap { get; set; }
        private Queue<MatrixCell> Queue { get; set; }
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid is null || grid.Length == 0 || grid[0] is null || grid[0].Length == 0 || grid.Length != grid[0].Length)
            {
                return -1;
            }

            if (grid[0][0] != 0)
            {
                return -1;
            }
            this.VisitedMap = new bool[grid.Length, grid[0].Length];
            this.Grid = grid;
            this.Queue = new Queue<MatrixCell>();

            this.Visit(0, 0, 0);

            int endRow = grid.Length - 1;
            int endColumn = grid[0].Length - 1;

            while (this.Queue.Count != 0)
            {
                var node = this.Queue.Dequeue();
                if (node.Row == endRow && node.Column == endColumn)
                {
                    return node.Level + 1;
                }

                // Left
                this.Visit(node.Row, node.Column - 1, node.Level + 1);
                // Bottom Left
                this.Visit(node.Row + 1, node.Column - 1, node.Level + 1);
                // Bottom
                this.Visit(node.Row + 1, node.Column, node.Level + 1);
                // Bottom Right
                this.Visit(node.Row + 1, node.Column + 1, node.Level + 1);
                // Right 
                this.Visit(node.Row, node.Column + 1, node.Level + 1);
                // Upper right
                this.Visit(node.Row - 1, node.Column + 1, node.Level + 1);
                //Up
                this.Visit(node.Row - 1, node.Column, node.Level + 1);
                // Upper left
                this.Visit(node.Row - 1, node.Column-1, node.Level + 1);
            }

            return -1;
        }

        private void Visit(int row, int col, int level)
        {
            var endRow = this.Grid.Length-1;
            var endColumn = this.Grid[0].Length-1;
            if (row <= endRow && col <= endColumn && row >= 0 && col >= 0 && this.Grid[row][col] == 0 && !this.VisitedMap[row, col])
            {
                var node = new MatrixCell()
                {
                    Row = row,
                    Column = col,
                    Level = level
                };
                this.Queue.Enqueue(node);
                this.VisitedMap[row, col] = true;
            }
        }

        // public static void Main(string[] args)
        // {
        //     var input = new int[][]{
        //         [0,1],[1,0]
        //     };

        //     var result = new ShortestPathBinaryMatrixProblem().ShortestPathBinaryMatrix(input);
        //     Console.WriteLine($"input = {Utility.Print2DArray<int>(input)}=> {result}");
        // }
    }
}