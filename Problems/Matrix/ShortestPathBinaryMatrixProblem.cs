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
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid is null || grid.Length == 0 || grid[0] is null || grid[0].Length == 0 || grid.Length != grid[0].Length)
            {
                return -1;
            }
            var visitedMap = new bool[grid.Length, grid[0].Length];

            var startNode = new MatrixCell()
            {
                Row = 0,
                Column = 0,
                Level = 0
            };

            Queue<MatrixCell> queue = new Queue<MatrixCell>();
            queue.Enqueue(startNode);

            visitedMap[startNode.Row, startNode.Column] = true;
            int endRow = grid.Length - 1;
            int endColumn = grid[0].Length - 1;

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node.Row == endRow && node.Column == endColumn)
                {
                    return node.Level+1;
                }

                // Bottom node
                var row = node.Row + 1;
                var col = node.Column;
                if (row <= endRow && col <= endColumn && grid[row][col] == 0 && !visitedMap[row, col])
                {
                    var bottomNode = new MatrixCell()
                    {
                        Row = row,
                        Column = col,
                        Level = node.Level + 1
                    };
                    queue.Enqueue(bottomNode);
                    visitedMap[row, col] = true;
                }

                // Diagonal Node
                row = node.Row + 1;
                col = node.Column+1;
                if (row <= endRow && col <= endColumn && grid[row][col] == 0 && !visitedMap[row, col])
                {
                    var bottomNode = new MatrixCell()
                    {
                        Row = row,
                        Column = col,
                        Level = node.Level + 1
                    };
                    queue.Enqueue(bottomNode);
                    visitedMap[row, col] = true;
                }

                // Right Node
                row = node.Row ;
                col = node.Column+1;
                if (row <= endRow && col <= endColumn && grid[row][col] == 0 && !visitedMap[row, col])
                {
                    var bottomNode = new MatrixCell()
                    {
                        Row = row,
                        Column = col,
                        Level = node.Level + 1
                    };
                    queue.Enqueue(bottomNode);
                    visitedMap[row, col] = true;
                }
            }
            
            return -1;
        }

        public static void Main(string[] args)
        {
            var input = new int[][]{
                [0,0,0],[1,1,0],[1,1,0]
            };

            var result = new ShortestPathBinaryMatrixProblem().ShortestPathBinaryMatrix(input);
            Console.WriteLine($"input = {Utility.Print2DArray<int>(input)}=> {result}");
        }
    }
}