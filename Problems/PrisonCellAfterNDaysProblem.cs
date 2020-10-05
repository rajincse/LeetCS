using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class PrisonCellAfterNDaysProblem
    {
        public int[] PrisonAfterNDays(int[] cells, int N) {
            if(cells == null || cells.Length !=8 || N < 1)
            {
                return cells;
            }
            Dictionary<int, int> seenMap = new Dictionary<int, int>();
            int cellNum = ArrayToBitMap(cells);
            bool isFastForward = false;
            while(N>0)
            {
                if(!isFastForward)
                {
                    if(seenMap.ContainsKey(cellNum))
                    {
                        int cycleLength = seenMap[cellNum] - N;
                        N = N % cycleLength;
                        isFastForward = true;
                    }
                    else{
                        seenMap[cellNum] = N;
                    }
                }
                if(N>0)
                {
                    cellNum = NextDay(cellNum);
                    N--;
                }
            }
            cells = BitmapToArray(cellNum);
            return cells;
        }
        public int NextDay(int cellNum)
        {
            int leftShift = cellNum << 1;
            int rightShift = cellNum >> 1;
            int val = ~(leftShift ^ rightShift);
            val = val & 0x7E;
            return val;
        }

        public int ArrayToBitMap(int[] cells)
        {
            if(cells == null || cells.Length !=8 )
            {
                return 0;
            }
            int result = 0;
            int mask = 0x080;
            for(int i=0;i<cells.Length;i++)
            {
                if(cells[i] == 1)
                {
                    result = result | mask;                    
                }
                mask >>= 1;
            }

            return result;
        }

        public int[] BitmapToArray(int num)
        {
            int[] cells = new int[8];
            int mask = 0x080;
            num = num & 0xFF;
            for(int i=0;i<cells.Length;i++)
            {
                if((num & mask) >> (cells.Length-i-1) == 1)
                {
                    cells[i] = 1; 
                }
                mask >>= 1;
            }
            return cells;
        }

        // public static void Main(string [] args)
        // {
        //     var cells = new int[] {0,1,0,1,1,0,0,1};
        //     int N = 7;
        //     // var p = new PrisonCellAfterNDaysProblem();
        //     // Console.WriteLine($"{Utility.PrintArray<int>(cells)} => {Convert.ToString(p.ArrayToBitMap(cells), 16)}");
        //     // Console.WriteLine($"{Convert.ToString(p.ArrayToBitMap(cells), 16)} => {Utility.PrintArray<int>(p.BitmapToArray(p.ArrayToBitMap(cells)))}");
        //     var result = new PrisonCellAfterNDaysProblem().PrisonAfterNDays(cells, N);
        //     Console.WriteLine($"{Utility.PrintArray<int>(cells)},{N} => {Utility.PrintArray<int>(result)} ");
        // }
    }
}