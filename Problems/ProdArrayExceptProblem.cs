namespace Problems
{
    public class ProdArrayExceptProblem
    {
        public int[] ProductExceptSelf(int[] nums) {
            if(nums == null || nums.Length < 2)
            {
                return null;
            }
            int[] result = new int[nums.Length];
            int temp = 1;
            for(int i=0;i<nums.Length;i++)
            {
                result[i] = temp;
                temp *= nums[i];
            }
            
            temp = 1;
            for(int i = nums.Length -1;i>= 0;i--)
            {
                result[i] *= temp;
                temp *= nums[i];
            }
            
            return result;
        }
    }
}