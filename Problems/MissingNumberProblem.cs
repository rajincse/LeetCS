namespace Problems
{
    public class MissingNumberProblem
    {
        public int MissingNumber(int[] nums) {
            if(nums == null || nums.Length ==0)
            {
                return 0;
            }
            int sum = 0;
            foreach(int num in nums)
            {
                sum+= num;
            }
            
            int n = nums.Length;
            return n*(n+1)/2 - sum;
        }
    }
}