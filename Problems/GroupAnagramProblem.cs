using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Problems
{
    public class GroupAnagramProblem
    {
        public IList<IList<string>> GroupAnagrams(string[] strs) {
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            foreach(string str in strs)
            {
                string key = GetAnagramKey(str);
                if(map.ContainsKey(key))
                {
                    IList<string> list = map[key];
                    list.Add(str);
                    map[key] = list;
                }
                else
                {
                    IList<string> list = new List<string>();
                    list.Add(str);
                    map[key] = list;
                }

            }
            IList<IList<string>> result = new List<IList<string>>();
            foreach(IList<string> list in map.Values)
            {
                result.Add(list);
            }
            return result;
        }

        private string GetAnagramKey(string str)
        {
            if(string.IsNullOrWhiteSpace(str) )
            {
                return string.Empty;
            }            

            int[] charCount = new int[26];            
            char[] charArr = str.ToCharArray();
            foreach( char ch in charArr)
            {
                charCount[(int)ch-'a']++;
            }
            StringBuilder sb = new StringBuilder();            
            for(int i=0;i< 26;i++)
            {
                char ch = (char)('a'+i);
                for(int j=0;j<charCount[i];j++)
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }
        public static void Main(string[] args)
        {
            string[] input = new string[]{"eat", "tea", "tan", "ate", "nat", "bat"};                        
            var result = new GroupAnagramProblem().GroupAnagrams(input);
            Console.WriteLine($"Input:{Utility.PrintArray<string>(input)}=> {Utility.Print2DList<string>(result)}");
        }
    }
}