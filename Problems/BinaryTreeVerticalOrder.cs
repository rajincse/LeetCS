// https://leetcode.com/problems/binary-tree-vertical-order-traversal/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class BinaryTreeVerticalOrderProblem
    {
        public IList<IList<int>> VerticalOrder(TreeNode root) {
            return null;
        }

        public static void Main(string[] args)
        {
            // string tree = $"[1,2,3,4,5,6,7,null, null, 8]";
            var tree = "[1,2,3,4,5,null, null, 6, null, null, 7, 8, null,null,9]";
            TreeNode node = TreeNode.StringToTreeNode(tree);
            var result = new BinaryTreeVerticalOrderProblem().VerticalOrder(node);
            Console.WriteLine($"Input: \n{node}\n=>{result}");
        }
    }
}