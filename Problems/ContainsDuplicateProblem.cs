using System.Collections.Generic;

namespace Problems
{
    public class ContainsDuplicateProblem
    {
        public bool ContainsDuplicate(int[] nums) {
            if(nums == null || nums.Length ==0)
            {
                return false;
            }
            HashSet<int> numSet = new HashSet<int>();
            
            foreach(int n in nums)
            {
                if(numSet.Contains(n))
                {
                    return true;
                }
                else
                {
                    numSet.Add(n);
                }
            }
            
            
            return false;
        }
    }
}