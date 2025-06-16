// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/

using System;
using System.Collections.Generic;
using Common;

namespace Problems.BinaryTree
{
    public class NodeWithParent
    {
        public int val;
        public NodeWithParent left;
        public NodeWithParent right;
        public NodeWithParent parent;

        public TreeNode TreeNode;

        public override string ToString()
        {
            return this.TreeNode.ToString();
        }

        public static NodeWithParent FromTreeNode(TreeNode treeNode)
        {
            if (treeNode is null)
            {
                return null;
            }
            var node = new NodeWithParent();
            node.TreeNode = treeNode;
            node.val = treeNode.val;
            node.left = FromTreeNode(treeNode.left);
            node.right = FromTreeNode(treeNode.right);

            if (node.left is not null)
            {
                node.left.parent = node;
            }

            if (node.right is not null)
            {
                node.right.parent = node;
            }

            return node;
        }
    }
    public class LowestCommonAncestorProblem
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var pWithParent = NodeWithParent.FromTreeNode(p);
            var qWithParent = NodeWithParent.FromTreeNode(q);

            var ancestor = new HashSet<TreeNode>();

            var node = pWithParent;

            while (node != null)
            {
                ancestor.Add(node.TreeNode);
                node = node.parent;
            }

            node = qWithParent;

            while (!ancestor.Contains(node.TreeNode))
            {
                node = node.parent;
            }

            return node.TreeNode;
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