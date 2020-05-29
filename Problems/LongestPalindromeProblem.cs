using System;

namespace Problems
{

    public class LongestPalindromeProblem
    {
        public class IndexRange{
            int start;
            int end;

            public IndexRange(int start, int end)
            {
                this.start = start;
                this.end = end;
            }

            public int Length{
                get{                    
                    if(start > end) return 0;
                    return end-start+1;
                }
            }
            public string GetSubString(string s)
            {
                if(string.IsNullOrEmpty(s)) {
                    return string.Empty;
                }
                return s.Substring(start, this.Length);
            }
        }
        public string LongestPalindrome(string s) {
            IndexRange current = new IndexRange(0,0);
            char[] charArray = s.ToCharArray();
            for(int i=0;i<charArray.Length;i++)
            {
                IndexRange range1 = Expand(charArray, i, i);
                if(range1 !=null && range1.Length > current.Length)
                {
                    current = range1;
                }
                IndexRange range2 = Expand(charArray, i, i+1);
                if(range2 !=null && range2.Length > current.Length)
                {
                    current = range2;
                }
            }
            return current.GetSubString(s);
        }

        public IndexRange Expand(char[] charArray,
                                 int left,
                                 int right)
        {   
            if(charArray == null || charArray.Length ==0 || left > right || left < 0 || right >= charArray.Length || charArray[left] != charArray[right])
            {
                return null;
            }
            int start = left;
            int end = right;
            while(start >= 0 && end < charArray.Length && charArray[start] == charArray[end])
            {
                start--;
                end ++;
            }
            return new IndexRange(start+1, end-1);

        }
        // public static void Main(string[] args)
        // {
        //     string input = "acbbcad" ;
        //     string result= new LongestPalindromeProblem().LongestPalindrome(input);
        //     Console.WriteLine($"Input:{input} => {result}");
        // }
    }

}