using System;

namespace Problems
{
    public class ValidPalindromeProblem
    {
        public bool IsPalindrome(string s) {
            if(string.IsNullOrWhiteSpace(s))
            {
                return true;
            }
            char[] charArray = s.ToCharArray();
            int left = 0;
            int right = charArray.Length-1;
            while(left < right)
            {                
                if(!char.IsLetterOrDigit(charArray[left]))
                {
                    left++;
                    continue;
                }
                if(!char.IsLetterOrDigit(charArray[right]))
                {
                    right--;
                    continue;
                }
                if(! IsEqual(charArray[left], charArray[right]))
                {
                    return  false;
                }
                left++;
                right--;

            }

            return true;
        }
        public bool IsEqual(char c1, char c2 )
        {            
            return char.ToUpper(c1).Equals(char.ToUpper(c2));
        }

        public static void Main(string[] args)
        {
            string input = "12hah21";
            var result = new ValidPalindromeProblem().IsPalindrome(input);
            Console.WriteLine($"Input: {input} => {result}");
        }
    }
}