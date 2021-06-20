using System;
using System.Collections.Generic;

namespace Problems
{
    public class MaxLengthUniqueConcatProblem
    {
        private HashSet<string> _stringSet;
        private int _max=0;
        public int MaxLength(IList<string> arr) {
            if(arr == null || arr.Count == 0)
            {
                return 0;
            }
            _stringSet= new HashSet<string>();
            
            foreach(string s in arr)
            {
                Add(s);
            }
            
            return _max;
        }
        
        private void Add(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return;
            }
            
            if(_stringSet.Count> 0)
            {
                List<string> stringList = new List<string>(_stringSet);
                foreach(string s1 in stringList)
                {
                    if(IsUniqueConcatenation(s1, s))
                    {
                        _stringSet.Add($"{s1}{s}");
                        _max = Math.Max(_max, s1.Length+s.Length);
                    }
                }
            }
            if(IsUnique(s))
            {
                _stringSet.Add(s);
                _max = Math.Max(_max, s.Length);
            }
            
        }
        private bool IsUnique(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return false;
            }
            int[] charCount = new int[26];
            
            foreach(char c in s.ToCharArray())
            {
                charCount[c-'a']++;
            }
            for(int i=0;i<charCount.Length;i++)
            {
                if(charCount[i]>1)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        private bool IsUniqueConcatenation(string s1, string s2)
        {
            if(string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return false;
            }
            
            int[] charCount = new int[26];
            
            foreach(char c in s1.ToCharArray())
            {
                charCount[c-'a']++;
            }
            
            foreach(char c in s2.ToCharArray())
            {
                charCount[c-'a']++;
            }
            
            for(int i=0;i<charCount.Length;i++)
            {
                if(charCount[i]>1)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}