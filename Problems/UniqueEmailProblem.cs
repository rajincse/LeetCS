using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems
{
    public class UniqueEmailProblem
    {
        public int NumUniqueEmails(string[] emails) {
            if(emails == null || emails.Length == 0)
            {
                return 0;
            }
            
            HashSet<string> uniqueEmailSet = new HashSet<string>();
            foreach(string email in emails)
            {
                string filteredEmail = GetFilteredEmail(email);
                if(filteredEmail != null)
                {
                    uniqueEmailSet.Add(filteredEmail);
                }
                
            }
            
            return uniqueEmailSet.Count();
        }
        
        public string GetFilteredEmail(string emailAddress)
        {
            if(string.IsNullOrWhiteSpace(emailAddress))
            {
                return null;
            }
            
            StringBuilder sb = new StringBuilder();
            
            char[] charArray = emailAddress.ToCharArray();
            
            bool isDomain = false;
            
            foreach( char c in charArray)
            {
                if(isDomain)
                {
                    sb.Append(c);
                }
                else
                {
                    if(c == '@')
                    {
                        isDomain = true;                    
                    }
                    else if(c == '.' || c == '+')
                    {
                        continue;
                    }
                    sb.Append(c);
                }
            }        
            
            return sb.ToString();
        }
    }
}