using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class RottingOrangesProblem
    {
        public class OrangePosition
        {
            public int Row {get;}
            public int Column {get;}

            public int Level {get;}

            public OrangePosition(int row, int col, int level)
            {
                Row = row;
                Column = col;
                Level = level;
            }

            public override string ToString()
            {
                return $"{{{Row}, {Column}, {Level}}}";
            }
        }
        public enum CellStatus
        {
            EmptyCell = 0,
            FreshOrange = 1,
            RottenOrange = 2
        } 
        private int _maxLevel = 0;
        private int _freshOrangeCount = 0;
        public int OrangesRotting(int[][] grid) {
            if(grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
            {
                return -1;
            }
            var queue = new Queue<OrangePosition>();

            for(int i=0;i< grid.Length;i++)
            {
                for(int j=0; j< grid[i].Length;j++)
                {
                    if(grid[i][j]== (int) CellStatus.FreshOrange)
                    {
                        _freshOrangeCount++;
                    }
                    else if(grid[i][j]== (int) CellStatus.RottenOrange)
                    {
                        var orangePosition = new OrangePosition(i, j, 0);
                        queue.Enqueue(orangePosition);
                    }
                }
            }

            while(queue.Count != 0)
            {
                var orangePosition = queue.Dequeue();                

                EnqueueOranges(orangePosition.Row-1, orangePosition.Column, grid, orangePosition.Level+1, queue);
                EnqueueOranges(orangePosition.Row+1, orangePosition.Column, grid, orangePosition.Level+1, queue);
                EnqueueOranges(orangePosition.Row, orangePosition.Column-1, grid, orangePosition.Level+1, queue);
                EnqueueOranges(orangePosition.Row, orangePosition.Column+1, grid, orangePosition.Level+1, queue);
            }
            

            return _freshOrangeCount == 0?  _maxLevel : -1;
        }

        private void EnqueueOranges(int row, int col, int[][] grid, int level, Queue<OrangePosition> queue)
        {
            if(
                (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
                ||
                (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length )
                ||
                grid[row][col] != (int)CellStatus.FreshOrange
            )
            {
                return ;
            }
            _freshOrangeCount--;
            _maxLevel = Math.Max(_maxLevel, level);
            grid[row][col] = (int) CellStatus.RottenOrange;
            var orangePosition = new OrangePosition(row, col, level);
            queue.Enqueue(orangePosition);
        }

        // public static void Main(string[] args)
        // {
        //     var input = new int[][]
        //     {
        //         new int[]{2,1,1},
        //         new int[]{1,1,0},
        //         new int[]{0,1,1},
        //     };
        //     var result = new RottingOrangesProblem().OrangesRotting(input);
        //     Console.WriteLine($"{Utility.Print2DArray<int>(input, '\n')} => {result}");
        // }
    }
}