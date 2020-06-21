using System;
using Common;

namespace Problems
{
    public class KthSmallestBSTProblem
    {
        public int KthSmallest(TreeNode root, int k) {
            int? result = null;
            
            (result, _)  = GetMaxIndex(root,-1, k, result);
            
            if(result != null)
            {
                return result.Value;
            }
            
            return 0;
        }
        public (int?, int) GetMaxIndex(TreeNode node, int parentIndex, int k, int? result)
        {
            if(result != null || node == null)
            {
                return (result, -1);
            }
            int leftIndex = -1;
            ( result, leftIndex) = GetMaxIndex(node.left, parentIndex, k, result);
            int currentIndex = -1;

            if(leftIndex > -1)
            {
                currentIndex = leftIndex+1;
            }
            else if( leftIndex < 0 && parentIndex > -1)
            {
                currentIndex = parentIndex+1;
            }            
            else
            {
                currentIndex = 1;
            }
            
            if(result != null )
            {
                return (result, currentIndex);
            }
            
            if(currentIndex == k)
            {
                return (node.val, currentIndex);
            }
            
            int rightIndex = -1;
            (result,  rightIndex) = GetMaxIndex(node.right, currentIndex, k, result);

            if(rightIndex > -1)
            {
                return (result, rightIndex);
            }
            else
            {
                return (result, currentIndex);
            }
            
        }
        // public static void Main(string[] args)
        // {
        //     TreeNode root = TreeNode.StringToTreeNode("[3,1,5,0,2, 4,6]");
        //     int k = 2;
        //     var result = new KthSmallestBSTProblem().KthSmallest(root, k);
        //     Console.WriteLine($"Input:\n{root}\n{k} => {result}");
        // }
    }
}