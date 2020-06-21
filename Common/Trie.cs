using System;
using System.Collections.Generic;

namespace Common
{
    public class Trie {
        public class TrieNode
        {
            public const char RootChar = '*';
            public const char TerminatingChar = '*';

            public char Val {get; set;}
            public Dictionary<char, TrieNode> Children {get;set;}
            public TrieNode(char val)
            {
                Val = val;
                Children = new Dictionary<char, TrieNode>();
            }
        }
        /** Initialize your data structure here. */
        public TrieNode Root {get;set;}
        public Trie() {
            Root = new TrieNode(TrieNode.RootChar);
        }
        
        /** Inserts a word into the trie. */
        public void Insert(string word) {
            if(string.IsNullOrEmpty(word))
            {
                return;
            }
            Insert(Root, word.ToCharArray(), 0);
        }

        private void Insert(TrieNode node, char[] charArray, int startIndex)
        {
            if(node == null || charArray == null || charArray.Length == 0 || startIndex < 0 || startIndex> charArray.Length)
            {
                return;
            }

            if(startIndex == charArray.Length)
            {
                node.Children[TrieNode.TerminatingChar] = new TrieNode(TrieNode.TerminatingChar);
            }
            else{
                char ch = charArray[startIndex];
                if(!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode(charArray[startIndex]);
                }               
                Insert(node.Children[ch], charArray , startIndex+1);
            }
        }
        
        /** Returns if the word is in the trie. */
        public bool Search(string word) {
            if(string.IsNullOrEmpty(word))
            {
                return true;
            }
            return Search(Root, word.ToCharArray(), 0);
        }

        private bool Search(TrieNode node,char[] charArray, int startIndex)
        {
            if(node == null || charArray == null || charArray.Length == 0 || startIndex < 0 || startIndex> charArray.Length)
            {
                return false;
            }
            if(startIndex == charArray.Length)
            {
                return node.Children.ContainsKey(TrieNode.TerminatingChar);
            }
            else
            {
                char ch = charArray[startIndex];
                if(node.Children.ContainsKey(ch))
                {
                    return Search(node.Children[ch], charArray, startIndex+1);
                }
                else
                {
                    return false;
                }
            }
        }
        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix) {
            if(string.IsNullOrEmpty(prefix))
            {
                return true;
            }

            return StartsWith(Root, prefix.ToCharArray(), 0);
        }

        private bool StartsWith(TrieNode node,char[] charArray, int startIndex)
        {
            if(node == null || charArray == null || charArray.Length == 0 || startIndex < 0 || startIndex> charArray.Length)
            {
                return false;
            }

            if(startIndex == charArray.Length)
            {
                return true;
            }
            else
            {
                char ch = charArray[startIndex];
                if(node.Children.ContainsKey(ch))
                {
                    return StartsWith(node.Children[ch], charArray, startIndex+1);
                }
                else
                {
                    return false;
                }
            }
        }
        // public static void Main(string[] args)
        // {
        //     Trie trie = new Trie();
        //     string word ="apple";
        //     trie.Insert(word);
        //     Console.WriteLine($" Search {word} =>{trie.Search(word)}");
        //     Console.WriteLine($" Search {word.Substring(0,3)} =>{trie.Search(word.Substring(0,3))}");
        //     Console.WriteLine($" Starts {word.Substring(0,3)} =>{trie.StartsWith(word.Substring(0,3))}");
        //     word ="app";
        //     trie.Insert(word);
        //     Console.WriteLine($" Search {word} =>{trie.Search(word)}");
        // }
    }
}