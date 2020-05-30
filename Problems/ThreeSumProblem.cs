using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class ThreeSumProblem
    {
        public IList<IList<int>> ThreeSum(int[] nums) {
            List<IList<int>> result = new List<IList<int>>();
            if(nums == null || nums.Length < 3)
            {
                return result;
            }

            Array.Sort(nums);
            for(int i =0;i<nums.Length-2;i++)
            {
                if(i==0 || nums[i] > nums[i-1])
                {

                    int left = i+1;
                    int right = nums.Length-1;
                    while(left < right)
                    {
                        if(nums[i]+nums[left]+nums[right] ==0)
                        {
                            result.Add(new List<int>(){ nums[i], nums[left], nums[right]});
                            left++;
                            
                            while(left< right && nums[left] == nums[left-1])
                            {
                                left++;
                            }
                            
                        }
                        else if(nums[left]+nums[right] < - nums[i])
                        {
                            left++;   
                            while(left< right && nums[left] == nums[left-1])
                            {
                                left++;
                            }
                        }
                        else
                        {
                            right--;
                            while(left< right && nums[right] == nums[right+1])
                            {
                                right--;
                            }
                        }
                    }
                    
                }
            }
            return result;
        }
        public static void Main(string[] args)
        {
            int[] input = new int[]{-1, 0, 1, 2, -1, -4};
            var  result= new ThreeSumProblem().ThreeSum(input);
            Console.WriteLine($"Input:{Utility.PrintArray<int>(input)} => {Utility.Print2DList<int>(result)}");
        }
    }
}