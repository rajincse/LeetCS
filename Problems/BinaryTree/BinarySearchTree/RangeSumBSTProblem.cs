// https://leetcode.com/problems/range-sum-of-bst/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days

using System;
using Common;

namespace Problems.BinaryTree.BinarySearchTree
{
    public class RangeSumBSTProblem
    {
        public int Result { get; set; } = 0;
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null)
            {
                return 0;
            }
            Traverse(root, low, high);
            
            return this.Result;
        }

        public void Traverse(TreeNode root, int low, int high)
        {
            if (root == null)
            {
                return;
            }

            if (root.val >= low && root.val <= high)
            {
                this.Result += root.val;
            }
            Traverse(root.left, low, high);
            Traverse(root.right, low, high);
        }

        // public static void Main(string[] args)
        // {
        //     var root = TreeNode.StringToTreeNode("[10,5,15,3,7,13,18,1,null,6]");
        //     var low = 6;
        //     var high = 10;
        //     var result = new RangeSumBSTProblem().RangeSumBST(root, low, high);
        //     Console.WriteLine($"root:\n{root}\n low:{low}, high:{high}\n=> {result}");
        // }
    }
}