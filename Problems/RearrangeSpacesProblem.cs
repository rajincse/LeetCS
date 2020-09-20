using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class RearrangeSpacesProblem
    {
        public string ReorderSpaces(string text) {
            if(string.IsNullOrWhiteSpace(text))
            {
                return text;
            }
            char[] charArray = text.ToCharArray();
            int spaceCount =0;
            List<string> wordList = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool newWordFound = false;
            foreach(char c in charArray)
            {
                if(c == ' ')
                {                
                    if(newWordFound)
                    {
                        wordList.Add(sb.ToString());
                        sb.Clear();
                        newWordFound = false;
                    }
                    spaceCount++;
                }
                else
                {
                    if(!newWordFound)
                    {
                        newWordFound = true;                                        
                    }
                    sb.Append(c);
                }
            }
            if(!string.IsNullOrWhiteSpace(sb.ToString()))
            {
                wordList.Add(sb.ToString());
            }            
            sb.Clear();
            if(wordList.Count ==1)
            {
                sb.Append(wordList[0]);
                sb.Append(GetSpaces(spaceCount));
                return sb.ToString();
            }
            int spacesToDistribute = spaceCount / (wordList.Count -1);
            int additionalSpace = spaceCount % (wordList.Count -1);
            for(int i=0;i<wordList.Count;i++)
            {
                sb.Append(wordList[i]);
                if(i != wordList.Count -1)
                {
                    sb.Append(GetSpaces(spacesToDistribute));
                }
            }
            
            sb.Append(GetSpaces(additionalSpace));
            
            return sb.ToString();
        }
        
        private string GetSpaces(int count)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0;i< count;i++)
            {
                sb.Append(' ');
            }
            return sb.ToString();
        }
        // public static void Main(string[] args)
        // {
        //     string input = " a   ";
        //     string output = new RearrangeSpacesProblem().ReorderSpaces(input);
        //     Console.WriteLine($" '{input}' => '{output}'" );
        // }
    }
}