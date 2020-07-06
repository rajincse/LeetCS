using System;
using Common;

namespace Problems
{
    public class VerifyingAlienDictionaryProblem
    {
        public bool IsAlienSorted(string[] words, string order) {
            if(words == null || words.Length ==0 || string.IsNullOrEmpty(order))
            {
                return false;
            }
            if(words.Length ==1)
            {
                return true;
            }
            int[] rank  = new int[26];
            char[] charArrayOrder = order.ToCharArray();
            for(int i=0;i<charArrayOrder.Length;i++)
            {
                int index =(int)( charArrayOrder[i] - 'a');
                rank[index] = i;
            }
            
            for(int i=0;i<words.Length -1;i++)
            {
                if(!IsLessThanOrEqual(words[i], words[i+1], rank))
                {
                    return false;
                }
            }
            
            return true;
        }
        
        private bool IsLessThanOrEqual(string word1, string word2, int[] rank)
        {
            if(string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
            {
                return true;
            }
            
            if(string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2) || rank == null || rank.Length ==0 )
            {
                return false;
            }
            
            char[] charArray1 = word1.ToCharArray();
            char[] charArray2 = word2.ToCharArray();
            int minLength = Math.Min(charArray1.Length, charArray2.Length);
            
            for(int i=0;i<minLength;i++)
            {
                int index1 = (int)(charArray1[i] - 'a');
                int index2 = (int)(charArray2[i] - 'a');
                
                if(rank[index1] > rank[index2])
                {
                    return false;
                }
                else if(rank[index1] < rank[index2])
                {
                    return true;
                }
            }
            
            if(charArray1.Length > charArray2.Length)
            {
                return false;
            }
            
            return true;
        }

        // public static void Main(string[] args)
        // {
        //     string[] words = new string[]{"hello","leetcode"};
        //     string order = "hlabcdefgijkmnopqrstuvwxyz";

        //     var result = new VerifyingAlienDictionaryProblem().IsAlienSorted(words, order);
        //     Console.WriteLine($"Input: {Utility.PrintArray<string>(words)}, {order} => {result}");
        // }
    }
}