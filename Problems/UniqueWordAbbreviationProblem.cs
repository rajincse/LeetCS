using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class UniqueWordAbbreviationProblem
    {
        // public static void Main(string[] args)
        // {
        //     var validateWord = new ValidWordAbbr(new string[]{"deer","door","cake","card"});
        //     var words = new string[]{"dear","cart","cane","make","cake"};
        //     foreach(var word in words)
        //     {
        //         Console.WriteLine($"{word} => {validateWord.IsUnique(word)}");
        //     }
            
        // }
    }
    public class ValidWordAbbr {

        private Dictionary<string, HashSet<string>> _abbreviationMap;        
        public ValidWordAbbr(string[] dictionary) {
            _abbreviationMap = new Dictionary<string, HashSet<string>>();
            
            
            foreach(string word in dictionary)
            {
                string abbreviation = Abbreviate(word);
                if(_abbreviationMap.ContainsKey(abbreviation))
                {
                    _abbreviationMap[abbreviation].Add(word);
                }
                else
                {
                    _abbreviationMap[abbreviation] = new HashSet<string>(){word};

                }
            }
        }
        
        public bool IsUnique(string word) {
            string abbreviation = Abbreviate(word);

            if(!_abbreviationMap.ContainsKey(abbreviation))
            {
                return true;
            }

            var wordSet = _abbreviationMap[abbreviation];
            if(wordSet.Count > 1)
            {
               return false;
            }
            
            return word.Equals(wordSet.First(), StringComparison.OrdinalIgnoreCase);            
        }
        
        private string Abbreviate(string word)
        {
            if(string.IsNullOrEmpty(word))
            {
                return string.Empty;
            }
            
            if(word.Length <3)
            {
                return word;
            }
            
            return $"{word[0]}{word.Length-2}{word[word.Length-1]}";
        }
    }
}