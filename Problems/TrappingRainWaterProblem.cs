using System;
using Common;

namespace Problems
{
    public class TrappingRainWaterProblem
    {
        public int Trap(int[] height) {
            if(height == null || height.Length ==0)
            {
                return 0;
            }
            return TrapSlidingWindow(height);
        }

        private int TrapBruteForce(int[] height)
        {
            if(height == null || height.Length ==0)
            {
                return 0;
            }
            int waterAmount = 0;
            for(int i=0;i<height.Length;i++)
            {
                int leftMax = 0;
                int rightMax = 0;
                for(int j= i-1;j>= 0;j--)
                {
                    leftMax = Math.Max(leftMax, height[j]);
                }
                for(int j= i+1;j< height.Length;j++)
                {
                    rightMax = Math.Max(rightMax, height[j]);
                }

                waterAmount += Math.Max(0, Math.Min(leftMax, rightMax) - height[i]);
            }

            return waterAmount;
        }
        private int TrapRecursive(int[] height)
        {
            if(height == null || height.Length ==0)
            {
                return 0;
            }
            int waterAmount = 0;
            for(int i=0;i<height.Length;i++)
            {
                waterAmount += Math.Max(0, Math.Min(GetLeftMax(i-1, height), GetRightMax(i+1, height)) - height[i]);
            }

            return waterAmount;
        }

        private int TrapDynamic(int[] height)
        {
            if(height == null || height.Length ==0)
            {
                return 0;
            }
            int waterAmount = 0;
            int[] leftMax = new int[height.Length];
            int[] rightMax = new int[height.Length];
            for(int i=0;i<height.Length;i++)
            {
                waterAmount += Math.Max(0, Math.Min(GetLeftMax(i-1, height, leftMax), GetRightMax(i+1, height, rightMax)) - height[i]);
            }

            return waterAmount;
        }

        private int TrapSlidingWindow(int[] height)
        {
            if(height == null || height.Length ==0)
            {
                return 0;
            }
            int waterAmount = 0;

            int left = 0;
            int right = height.Length-1;
            int leftMax = 0;
            int rightMax =0;
            while(left < right)
            {
                if(height[left]< height[right])
                {
                    if(height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        waterAmount += Math.Max(0, leftMax - height[left]);
                    }
                    left++;
                }
                else
                {
                    if(height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        waterAmount += Math.Max(0, rightMax - height[right]);
                    }
                    right--;
                }
            }

            return waterAmount;
        }

        private int GetLeftMax(int index, int[] height)
        {
            if(index <0 || index >= height.Length)
            {
                return 0;
            }
            return Math.Max(GetLeftMax(index-1, height), height[index]);
        }
        private int GetLeftMax(int index, int[] height, int[] dp)
        {
            if(index <0 || index >= height.Length)
            {
                return 0;
            }
            if(dp[index] > 0)
            {
                return dp[index];
            }
            dp[index] = Math.Max(GetLeftMax(index-1, height, dp), height[index]);
            return dp[index];
        }

        private int GetRightMax(int index, int[] height)
        {
            if(index <0 || index >= height.Length)
            {
                return 0;
            }
            return Math.Max(GetRightMax(index+1, height), height[index]);
        }
        private int GetRightMax(int index, int[] height, int[] dp)
        {
            if(index <0 || index >= height.Length)
            {
                return 0;
            }
            if(dp[index] > 0)
            {
                return dp[index];
            }
            dp[index] =  Math.Max(GetRightMax(index+1, height, dp), height[index]);
            return dp[index];
        }

        // public static void Main(string[] args)
        // {
        //     var input = new int[] {0,1,0,2,1,0,1,3,2,1,2,1};
        //     var result = new TrappingRainWaterProblem().Trap(input);
        //     Console.WriteLine($"{Utility.PrintArray<int>(input)} =>{result}");
        // }
    }
}