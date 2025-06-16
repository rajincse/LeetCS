// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/

using System;
using Common;

namespace Problems.BinaryTree
{
    public class LowestCommonAncestorProblem
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            return null;
        }

        public static void Main(string[] args)
        {
            var nodeP = TreeNode.StringToTreeNode("[5,6,2,null,null,7,4]");
            var nodeQ = TreeNode.StringToTreeNode("[1,0,8]");
            var root = new TreeNode(3);
            root.left = nodeP;
            root.right = nodeQ;
            var result = new LowestCommonAncestorProblem().LowestCommonAncestor(root, nodeP, nodeQ);
            Console.WriteLine($"root: {root}p:{nodeP.val},\nq:{nodeQ.val},\n=>{result}");
        }
    }
}