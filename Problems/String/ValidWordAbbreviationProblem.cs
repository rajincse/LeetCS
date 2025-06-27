// https://leetcode.com/problems/valid-word-abbreviation/description/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days

using System;

namespace Problems.String
{
    public class ValidWordAbbreviationProblem
    {
        public bool ValidWordAbbreviation(string word, string abbr)
        {
            var wordArray = word.ToCharArray();
            var abbrArray = abbr.ToCharArray();
            var wordPointer = 0;
            var abbrPointer = 0;
            var currentAbbrSubstringLength = 0;

            while (wordPointer < wordArray.Length && abbrPointer < abbrArray.Length)
            {
                if (!char.IsDigit(abbrArray[abbrPointer]))
                {
                    wordPointer += currentAbbrSubstringLength;
                    if (wordPointer >= wordArray.Length)
                    {
                        return false;
                    }
                    // case for character matches and move on
                        if (wordArray[wordPointer] == abbrArray[abbrPointer])
                        {
                            wordPointer++;
                            abbrPointer++;
                            currentAbbrSubstringLength = 0;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                }
                else
                {
                    var digitChar = abbrArray[abbrPointer];
                    var digit = digitChar - '0';

                    // case for leading zero
                    if (currentAbbrSubstringLength == 0 && digit == 0)
                    {
                        return false;
                    }
                    else
                    {
                        currentAbbrSubstringLength = currentAbbrSubstringLength * 10 + digit;                        
                        abbrPointer++;
                    }
                }
            }

            // case for trailing digit in abbr
            wordPointer += currentAbbrSubstringLength;

            if (wordPointer == wordArray.Length && abbrPointer == abbrArray.Length)
            {
                return true;
            }

            return false;
        }

        // public static void Main(string[] args)
        // {
        //     var word = "substitution";
        //     var abbr = "12";
        //     var result = new ValidWordAbbreviationProblem().ValidWordAbbreviation(word, abbr);
        //     Console.WriteLine($"word: {word}, abbr:{abbr} => {result}");
        // }
    }
}