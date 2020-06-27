using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class EncodeDecodeStringProblem
    {
        public class Codec {

            // Encodes a list of strings to a single string.
            public string encode(IList<string> strs) {
                if(strs == null || strs.Count ==0)
                {
                    return string.Empty;
                }
                StringBuilder sb = new StringBuilder();
                foreach(string str in strs)
                {
                    char[] charArray = str.ToCharArray();
                    foreach(char ch in charArray)
                    {
                        if(ch == '\\')
                        {
                            sb.Append(@"\\");
                        }
                        else if(ch == '+')
                        {
                            sb.Append(@"\+");
                        }
                        else
                        {
                            sb.Append(ch);
                        }
                    }
                    sb.Append("+");
                }
                
                return sb.ToString();
            }

            // Decodes a single string to a list of strings.
            public IList<string> decode(string s) {
                IList<string> result = new List<string>();
                if(string.IsNullOrEmpty(s))
                {
                    return result;
                }
                char[] charArray = s.ToCharArray();
                StringBuilder sb = new StringBuilder();
                for(int i=0;i< charArray.Length;i++)
                {
                    char ch = charArray[i];
                    if(ch == '+')
                    {
                        result.Add(sb.ToString());
                        sb.Clear();
                    }
                    else if(ch =='\\')
                    {
                        i++;
                        sb.Append(charArray[i]);
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                
                return result;
            }
        }
    }
}