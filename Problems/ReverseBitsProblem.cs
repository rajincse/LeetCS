using System;

namespace Problems
{
    public class ReverseBitsProblem
    {
        public uint reverseBits(uint n) {
            uint result = 0;
            for(int i=0;i<32;i++)
            {
                uint bit = (n >> (32-i-1) ) & 0x01 ;
                if(bit > 0)
                {
                    uint mask = 1;
                    mask = (mask << (i));
                    result = result | mask;
                }
                
            }
            return result;
        }
        // public static void Main(string[] args)
        // {
        //     uint input = 0xF0A0000F;
        //     var result = new ReverseBitsProblem().reverseBits(input);
        //     Console.WriteLine($"{Convert.ToString(input, 2)} = > {Convert.ToString(result, 2)}");
        // }
    }

}