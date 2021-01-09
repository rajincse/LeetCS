using System;

namespace Problems
{
    public class BullsAndCowsProblem
    {
        public string GetHint(string secret, string guess) {
            if(string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(guess) || secret.Length != guess.Length)
            {
                return $"0A0B";
            }
            char[] charArraySecret = secret.ToCharArray();
            char[] charArrayGuess = guess.ToCharArray();

            int[] occurenceCountExceptBull = new int[10];
            bool[] isBull = new bool[charArraySecret.Length];
            int bullCount = 0;
            int cowCount = 0;

            for(int i=0;i< charArraySecret.Length;i++)
            {
                if(charArraySecret[i] == charArrayGuess[i])
                {
                    bullCount++;
                    isBull[i] = true;
                }
                else
                {
                    int digit = charArraySecret[i] - '0';
                    occurenceCountExceptBull[digit] ++;
                }
            }

            for(int i=0;i< charArrayGuess.Length;i++)
            {
                if(!isBull[i])
                {
                    int digit = charArrayGuess[i] - '0';
                    if(occurenceCountExceptBull[digit] > 0)
                    {
                        cowCount++;
                        occurenceCountExceptBull[digit]--;
                    }
                }
            }

            return $"{bullCount}A{cowCount}B";
        }

        // public static void Main(string[] args)
        // {
        //     var secret = "11123";
        //     var guess = "01011";
        //     var result = new BullsAndCowsProblem().GetHint(secret, guess);
        //     Console.WriteLine($"{secret}, {guess} => {result}");
        // }
    }
}