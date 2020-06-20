using System;

namespace Problems
{
    public class Number1BitsProblem
    {
        public int HammingWeight(uint n) {
            int count =0;
            if(n ==0)
            {
                return 0;
            }
            for(int i=0;i<32;i++)
            {
                uint bit = (n >> 32-i-1) & 0x01;
                count = bit==1? count+1: count;
            }
            return count;
        }

        // public static void Main(string[] args)
        // {
        //     uint input  = 0xA0;
        //     var result = new Number1BitsProblem().HammingWeight(input);
        //     Console.WriteLine($"Input: {Convert.ToString(input, 2)} => {result}");
        // }
         
    }
}