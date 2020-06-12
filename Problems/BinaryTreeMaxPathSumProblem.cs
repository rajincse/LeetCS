using System;
using Common;

namespace Problems
{
    public class BinaryTreeMaxPathSumProblem
    {
        public int MaxPathSum(TreeNode root) {
            if(root == null)
            {
                return 0;
            }
            int maxPathSum = int.MinValue;
            int localPathSum = 0;
            (localPathSum, maxPathSum) = GetMaxPathSumWithRoot(root, maxPathSum);
            return maxPathSum;
        }

        public (int, int) GetMaxPathSumWithRoot(TreeNode root, int maxPathSum)
        {
            if(root == null)
            {
                return (0, maxPathSum);
            }
            int leftPathSum = 0;
            (leftPathSum, maxPathSum) =  GetMaxPathSumWithRoot(root.left, maxPathSum);

            int rightPathSum = 0;
            (rightPathSum, maxPathSum) =  GetMaxPathSumWithRoot(root.right, maxPathSum);

            int localMaxSum = Math.Max(root.val, root.val + Math.Max(leftPathSum, rightPathSum));
            maxPathSum = Math.Max(maxPathSum, localMaxSum);
            maxPathSum = Math.Max(maxPathSum, leftPathSum +root.val + rightPathSum);

            return (localMaxSum,maxPathSum);
        }

        // public static void Main(string[] args)
        // {
        //     TreeNode node = TreeNode.StringToTreeNode($"[-10, -1, 0, 1]");
        //     var result = new BinaryTreeMaxPathSumProblem().MaxPathSum(node);
        //     Console.WriteLine($"input :\n{node}\n => {result}");
        // }

    }
}