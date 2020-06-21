using System;
using System.Collections.Generic;
using Common;

namespace Problems
{    
    public class WordSearchIIProblem
    {
        public class BoardTrieNode
        {
            public const char RootChar = '*';
            public const char LeafChar = '*';
            
            public Dictionary<char, BoardTrieNode> Children {get; set;}
            public char Val {get;set;}
            
            public string Word {get;set;}
            
            public BoardTrieNode(char val)
            {
                Val = val;
                Children = new Dictionary<char, BoardTrieNode>();
                Word = null;
            }
            
            public override string ToString()
            {
                return $"Node:{Val}, {Children.Keys.Count}";
            }
        }
        public class BoardTrie
        {
            public BoardTrieNode Root {get;set;}
            public BoardTrie()
            {
                Root = new BoardTrieNode(BoardTrieNode.RootChar);
            }
            
            public void Insert(string word)
            {
                if(string.IsNullOrEmpty(word))
                {
                    return ;
                }
                Insert(Root, word.ToCharArray(), 0);
            }
            
            private void Insert(BoardTrieNode node, char[] charArray, int startIndex)
            {
                if(node == null || charArray == null || charArray.Length == 0 || startIndex < 0 || startIndex > charArray.Length)
                {
                    return ;
                }
                
                if(startIndex == charArray.Length)
                {
                    node.Children[BoardTrieNode.LeafChar] = new BoardTrieNode(BoardTrieNode.LeafChar);
                    node.Children[BoardTrieNode.LeafChar].Word = new string(charArray);
                }
                else
                {
                    char ch = charArray[startIndex];
                    if(!node.Children.ContainsKey(ch))
                    {
                        node.Children[ch] = new BoardTrieNode(ch);
                    }
                    Insert(node.Children[ch], charArray, startIndex+1);
                }
            }
        }
        public const char VisitingChar = '$';
        public IList<string> FindWords(char[][] board, string[] words) {
            var result = new List<string>();
            if(board == null || board.Length == 0 || board[0].Length ==0 || words == null || words.Length ==0)
            {
                return result;
            }
            
            BoardTrie trie = new BoardTrie();
            foreach(string word in words)
            {
                trie.Insert(word);
            }
            
            for(int r=0;r<board.Length;r++)
            {
                for(int c=0;c<board[r].Length;c++)
                {
                    if(trie.Root.Children.ContainsKey(board[r][c]))
                    {
                        Dfs(board, trie.Root, r, c, result);
                    }
                }
            }
            return result;
        }
        
        private void Dfs(char[][] board, BoardTrieNode parent, int row, int col, List<string> result)
        {
            if(board == null || board.Length ==0 || board[0].Length ==0 || parent == null || result == null)
            {
                return ;
            }
            if(parent.Children.ContainsKey(BoardTrieNode.LeafChar) && !string.IsNullOrEmpty(parent.Children[BoardTrieNode.LeafChar].Word))
            {
                result.Add(parent.Children[BoardTrieNode.LeafChar].Word);
                parent.Children[BoardTrieNode.LeafChar].Word = string.Empty;
                
            }
            if(row<0 || row >= board.Length || col<0 || col>=  board[0].Length)
            {
                return ;
            }
            char ch = board[row][col];
            if(!parent.Children.ContainsKey(ch))
            {
                return;
            }
            
            if(ch == VisitingChar)
            {
                return ;
            }
            
            board[row][col] = VisitingChar;
            
            if(!parent.Children.ContainsKey(ch))
            {
                return;
            }
            Dfs(board, parent.Children[ch], row-1, col, result);
            Dfs(board, parent.Children[ch], row+1, col, result);
            Dfs(board, parent.Children[ch], row, col-1, result);
            Dfs(board, parent.Children[ch], row, col+1, result);
            
            board[row][col] = ch;
            
            
        }

        // public static void Main(string[] args)
        // {
        //     char[][] board = new char[][]
        //     {
        //         new char[] {'s','e','e','n','e','w'},
        //         new char[] {'t','m','r','i','v','a'},
        //         new char[] {'o','b','s','i','b','d'},
        //         new char[] {'w','m','y','s','e','n'},
        //         new char[] {'l','t','s','n','s','a'},
        //         new char[] {'i','e','z','l','g','n'}
        //     };
        //     //[["s","e","e","n","e","w"],["t","m","r","i","v","a"],["o","b","s","i","b","d"],["w","m","y","s","e","n"],["l","t","s","n","s","a"],["i","e","z","l","g","n"]]
        //     string[] words = new string[]{"bena","bend","benda","besa","besan","bowl"};

        //     var result = new WordSearchIIProblem().FindWords(board, words);
        //     Console.WriteLine($"Input:\n{Utility.Print2DArray<char>(board, '\n')}\n, {Utility.PrintArray<string>(words)}\n =>\n {Utility.PrintList<string>(result)}");
        // }
    }
}