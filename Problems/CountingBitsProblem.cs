namespace Problems
{
    public class CountingBitsProblem
    {
        public int[] CountBits(int num) {
        
            if(num < 0)
            {
                return  null;
            }
            else if(num ==0)
            {
                return new int[1]{0};
            }
            
            int[] result = new int[num+1];
            for(int n=0;n<=num;n++)
            {
                result[n] = GetBitCount(n);
            }
            
            return result;
        }
        
        public int GetBitCount(int num)
        {
            if(num <= 0)
            {
                return 0;
            }
            int sum =0;
            for(int i=0;i<32;i++)
            {
                int bit = (num >> (32-i-1)) & 0x01;
                sum+= bit;
            }
            
            return sum;
        }
    }
}