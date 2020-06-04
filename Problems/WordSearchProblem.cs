using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Common;

namespace Problems
{
    public class WordSearchProblem
    {
        public class BoardPosition : IEquatable<BoardPosition>
        {
            public int RowIndex {get; set;}
            public int ColIndex {get; set;}

            public BoardPosition(int row, int col)
            {
                RowIndex = row;
                ColIndex = col;
            }

            public bool IsAdjacent(BoardPosition other)
            {
                return (RowIndex == other.RowIndex && Math.Abs(ColIndex - other.ColIndex) == 1)
                || (ColIndex == other.ColIndex && Math.Abs(RowIndex - other.RowIndex) == 1);

            }

            public bool Equals(BoardPosition other)
            {
                return RowIndex == other.RowIndex && ColIndex == other.ColIndex;
            }            
        }
        public bool Exist(char[][] board, string word) {
            if(board == null || board.Length == 0 || board[0].Length ==0 || string.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            Dictionary<char, List<BoardPosition>> map = new Dictionary<char, List<BoardPosition>>();

            for(int i=0;i<board.Length;i++)
            {
                for(int j=0;j<board[0].Length;j++)
                {
                    char c = board[i][j];
                    List<BoardPosition> list = map.GetValueOrDefault(c, new List<BoardPosition>());
                    list.Add(new BoardPosition(i,j));
                    map[c] = list;
                }
            }
            return Exist(word.ToCharArray(), 0, map, new List<BoardPosition>());
        }

        private bool Exist(char[] charArray, int currentIndex, Dictionary<char, List<BoardPosition>> boardPositionMap, List<BoardPosition> visited)
        {
            if(charArray == null || charArray.Length ==0 || currentIndex > charArray.Length || currentIndex < 0)
            {
                return false;
            }
            if(currentIndex == charArray.Length)
            {
                return true;
            }
            
            if(boardPositionMap == null || !boardPositionMap.ContainsKey(charArray[currentIndex]))
            {
                return false;
            }

            if(visited == null)
            {
                visited = new List<BoardPosition>();
            }

            

            List<BoardPosition> positions = boardPositionMap[charArray[currentIndex]];
            foreach(BoardPosition position in positions)
            {
                if(visited.Count ==0)
                {
                    visited.Add(position);
                    if(Exist(charArray, currentIndex+1, boardPositionMap, visited))
                    {
                        return true;
                    }
                    visited.Remove(position);
                }
                else
                {
                    BoardPosition lastVisited = visited[visited.Count-1];
                    if(!visited.Contains(position) && position.IsAdjacent(lastVisited))
                    {
                        visited.Add(position);
                        if(Exist(charArray, currentIndex+1, boardPositionMap, visited))
                        {
                            return true;
                        }
                        visited.Remove(position);
                    }
                }    
            }

            return false;
        }
        // public static void Main(string[] args)
        // {
        //     char[][] board = new char[][]
        //     {
        //         new char[]{'A', 'B', 'C', 'E'},
        //         new char[]{'S', 'F', 'C', 'S'},
        //         new char[]{'A', 'D', 'E', 'E'}
        //     };
            
        //     string word = "ABCCED";
        //     var result = new  WordSearchProblem().Exist(board, word);
        //     Console.WriteLine($"Input: {Utility.Print2DArray<char>(board, '\n')},{word} => {result}");
        // }
    }
}