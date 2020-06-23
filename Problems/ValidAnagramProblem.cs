namespace Problems
{
    public class ValidAnagramProblem
    {
        public bool IsAnagram(string s, string t) {
            if(string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t))
            {
                return true;
            }
            else if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            {
                return false;            
            }
            
            int[] frequencyCountS = new int['z'-'a'+1];
            int[] frequencyCountT = new int['z'-'a'+1];
            
            char[] charArrayS = s.ToCharArray();
            char[] charArrayT = t.ToCharArray();
            
            foreach(char c in charArrayS)
            {
                frequencyCountS[c-'a']++;
            }
            
            foreach(char c in charArrayT)
            {
                frequencyCountT[c-'a']++;
            }
            
            for(int i=0;i<frequencyCountS.Length;i++)
            {
                if(frequencyCountS[i] != frequencyCountT[i])
                {
                    return false;
                }
            }
        
            return true;
        }
    }
}