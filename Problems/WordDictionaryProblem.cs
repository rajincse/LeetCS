using System;
using System.Collections.Generic;

namespace Problems
{
    public class WordDictionary {

        public class WordTrieNode
        {
            public const char RootChar = '*';
            public const char TerminatingChar = '*';
            public char Val {get;set;}
            public Dictionary<char, WordTrieNode> Children {get;set;}
            public WordTrieNode(char val)
            {
                Val = val;
                Children = new Dictionary<char, WordTrieNode>();
            }
        }
        public const char WildCardChar = '.';
        public WordTrieNode Root {get;set;}
        /** Initialize your data structure here. */
        public WordDictionary() {
            Root = new WordTrieNode(WordTrieNode.RootChar);
        }
        
        /** Adds a word into the data structure. */
        public void AddWord(string word) {
            if(string.IsNullOrEmpty(word))
            {
                return;
            }
            AddWord(Root, word.ToCharArray(), 0);
        }
        private void AddWord(WordTrieNode node, char[] charArray, int startIndex)
        {
            if(node == null || charArray == null || charArray.Length == 0 || startIndex < 0 || startIndex > charArray.Length)
            {
                return;
            }
            if(startIndex == charArray.Length)
            {
                node.Children[WordTrieNode.TerminatingChar] = new WordTrieNode(WordTrieNode.TerminatingChar);
            }
            else
            {
                char ch = charArray[startIndex];
                if(!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new WordTrieNode(ch);
                }
                AddWord(node.Children[ch], charArray, startIndex+1);
            }
        }
        
        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word) {
            if(string.IsNullOrEmpty(word))
            {
                return false;
            }
            return Search(Root, word.ToCharArray(), 0);
        }

        private bool Search(WordTrieNode node, char[] charArray, int startIndex)
        {
            if(node == null || charArray == null || charArray.Length == 0 || startIndex < 0 || startIndex > charArray.Length)
            {
                return false;
            }
            if(startIndex == charArray.Length)
            {
                return node.Children.ContainsKey(WordTrieNode.TerminatingChar);
            }
            else
            {
                char ch = charArray[startIndex];
                if(ch == WildCardChar)
                {                    
                    foreach (char childChar in node.Children.Keys)
                    {
                        if(childChar != WordTrieNode.TerminatingChar)
                        {
                            WordTrieNode childNode = node.Children[childChar];
                            if(Search(childNode, charArray, startIndex+1))
                            {
                                return true;
                            }
                        }                        
                    }
                    return false;
                }
                else
                {
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
        }
    }
    public class WordDictionaryProblem
    {
        // public static void Main(string[] args)
        // {
        //     //["WordDictionary","addWord","addWord","addWord","addWord","search","search","addWord","search","search","search","search","search","search"]
        //     //[[],               ["at"]  , ["and"] , ["an"]  ,["add"]  ,["a"]   ,[".at"] ,["bat"]  ,[".at"] ,["an."] ,["a.d."],["b."]  ,["a.d"] ,["."]]
        //     //[null            ,null     ,null     ,null     ,null     ,false   ,false   ,null     ,true    ,true    ,false   ,false   ,true    ,false]
        //     WordDictionary wordDictionary = new WordDictionary();
        //     wordDictionary.AddWord("at");
        //     wordDictionary.AddWord("and");            
        //     wordDictionary.AddWord("an");
        //     wordDictionary.AddWord("add");
        //     string searchWord = "a";
        //     Console.WriteLine($"Search({searchWord}) =>{wordDictionary.Search(searchWord)}");
        //     searchWord = ".at";
        //     Console.WriteLine($"Search({searchWord}) =>{wordDictionary.Search(searchWord)}");
        //     wordDictionary.AddWord("bat");
        //     searchWord = ".at";
        //     Console.WriteLine($"Search({searchWord}) =>{wordDictionary.Search(searchWord)}");
        //     searchWord = "an.";
        //     Console.WriteLine($"Search({searchWord}) =>{wordDictionary.Search(searchWord)}");
        //     searchWord = "a.d.";
        //     Console.WriteLine($"Search({searchWord}) =>{wordDictionary.Search(searchWord)}");
        //     searchWord = "b.";
        //     Console.WriteLine($"Search({searchWord}) =>{wordDictionary.Search(searchWord)}");

        // }
    }
}