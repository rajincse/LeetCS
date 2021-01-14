using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Problems
{
    public class ExpressiveWordsProblem
    {
        public class CharacterGroup
        {
            public char C {get;}
            public int Count {get;set;}
            public bool IsModifiable()
            {
                return Count >= 3;
            }

            public CharacterGroup(char c, int count)
            {
                C = c;
                Count = count;
            }

            public static bool Equivalent(string query, string target)
            {
                if(string.IsNullOrEmpty(query) && string.IsNullOrEmpty(target))
                {
                    return true;
                }

                if(string.IsNullOrEmpty(query) || string.IsNullOrEmpty(target))
                {
                    return false;
                }
                var queryGroups = GetGroups(query);
                var targetGroups = GetGroups(target);
                if(queryGroups.Count != targetGroups.Count)
                {
                    return false;
                }

                for(int i=0;i<queryGroups.Count;i++)
                {
                    if(!Equivalent(queryGroups[i], targetGroups[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
            public static bool Equivalent(CharacterGroup queryGroup, CharacterGroup targetGroup)
            {
                if(queryGroup.C != targetGroup.C)
                {
                    return false;
                }

                if(queryGroup.IsModifiable() && queryGroup.Count >= targetGroup.Count)
                {
                    return true;
                }

                return queryGroup.Count == targetGroup.Count;
            }

            public static List<CharacterGroup> GetGroups(string s)
            {
                var result = new List<CharacterGroup>();
                if(string.IsNullOrEmpty(s))
                {
                    return result;
                }

                char[] charArray = s.ToCharArray();
                char c= charArray[0];
                int count =1;

                for(int i=1;i<charArray.Length;i++)
                {
                    if(charArray[i] != c)
                    {
                        var characterGroup = new CharacterGroup(c, count);
                        result.Add(characterGroup);
                        c = charArray[i];
                        count = 1;
                    }
                    else
                    {
                        count++;         
                    }
                }                
                result.Add(new CharacterGroup(c, count));

                return result;
            }
        }
        public int ExpressiveWords(string S, string[] words) {
            if(string.IsNullOrEmpty(S) || words == null || words.Length ==0)
            {
                return 0;
            }
            int count =0;
            foreach(string word in words)
            {               
                if(CharacterGroup.Equivalent(S, word))
                {
                    count++;
                }
            }

            return count;
        }

        // public static void Main(string[] args)
        // {
        //     var S = "zzzzzyyyyy";
        //     var words = new string[]{"zzyy","zy","zyy"};
        //     // var S = "heeellooo";
        //     // var words = new string[]{"hello", "hi", "helo"};
        //     var result = new ExpressiveWordsProblem().ExpressiveWords(S, words);
        //     Console.WriteLine($"{S}, [{Utility.PrintArray<string>(words)}] => {result}");
        // }
    }
}