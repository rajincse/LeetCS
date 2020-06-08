using System;
using Common;

namespace Problems
{
    public class BinaryTreeMaxDepthProblem
    {
        public int MaxDepth(TreeNode root) {
            if(root == null)
            {
                return 0;
            }
            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);
            return Math.Max(leftDepth, rightDepth)+1;
        }
        // public static void Main(string[] args)
        // {
        //     string tree = $"[3,9,20,null,null,15,7]";            
        //     TreeNode node = TreeNode.StringToTreeNode(tree);            
        //     int result = new BinaryTreeMaxDepthProblem().MaxDepth(node);
        //     Console.WriteLine($"Input: \n{node}\n=>{result}");
        // }
    }
}