using System;
using Common;

namespace Problems
{
    public class ContainerMostWaterProblem{
        public int MaxArea(int[] height) {
            if(height == null || height.Length ==0 ){
                return 0;
            }
            int maxArea = 0;
            int left = 0;
            int right = height.Length-1;
            while(left < right)
            {
                maxArea = Math.Max(maxArea, (right - left ) * Math.Min(height[left], height[right]) );
                if(height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maxArea;
        }
        // public static void Main(string[] args)
        // {
        //     int[] input = new int[]{1,8,6,2,5,4,8,3,7};
        //     int result= new ContainerMostWaterProblem().MaxArea(input);
        //     Console.WriteLine($"Input:{Utility.PrintArray<int>(input)} => {result}");
        // }
    }
}