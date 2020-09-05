using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class MostCommonWordProblem
    {
        public class WordFrequency : IComparable <WordFrequency>{
            public string Word {get;}
            public int Frequency {get; set;}
            public WordFrequency(string word)
            {
                Word = word;
                Frequency = 1;
            }
            public int CompareTo(WordFrequency other)
            {
                return other.Frequency - this.Frequency;
            }

            public override string ToString()
            {
                return $"{Word} => {Frequency}";
            }
        }
        public string MostCommonWord(string paragraph, string[] banned) {
            if(string.IsNullOrWhiteSpace(paragraph) || banned == null || banned.Length == 0)
            {
                return null;
            }
            
            var lowerCaseParagraph = paragraph.ToLower();
            
            HashSet<string> bannedSet = new HashSet<string>();
            foreach(var bannedWord in banned)
            {
                bannedSet.Add(bannedWord.ToLower());
            }
            
            string[] allWords  = lowerCaseParagraph.Split();
            Dictionary<string,WordFrequency> dictionary = new  Dictionary<string,WordFrequency>();
            foreach(string word in allWords)
            {
                if(!bannedSet.Contains(word))
                {
                    if(dictionary.ContainsKey(word))
                    {
                        var wordFrequency = dictionary[word];
                        wordFrequency.Frequency++;
                        dictionary[word] = wordFrequency;
                    }
                    else
                    {
                        dictionary[word] = new WordFrequency(word);
                    }
                }
            }
            List<WordFrequency> wordList =new List<WordFrequency>();
            foreach(var wordFrequency in dictionary.Values)
            {
                wordList.Add(wordFrequency);
            }
            
            wordList.Sort();
            
            if(wordList.Count <1)
            {
                return null;
            }
            
            return wordList[0].Word;
        }

        public static void Main(string[] args)
        {
            var paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            var banned = new string[]{"hit"};
            var result = new MostCommonWordProblem().MostCommonWord(paragraph, banned);
            Console.WriteLine($"{paragraph}, {Utility.PrintArray<string>(banned)} => {result} ");
        }
    }
}