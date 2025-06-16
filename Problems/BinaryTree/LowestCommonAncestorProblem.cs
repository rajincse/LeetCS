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
    }
    public class LowestCommonAncestorProblem
    {
        public Dictionary<int, NodeWithParent> NodeMap { get; set; }
        public NodeWithParent GenerateNodeWithParent(TreeNode treeNode)
        {
            if (treeNode is null)
            {
                return null;
            }

            var node = new NodeWithParent();
            node.TreeNode = treeNode;
            node.val = treeNode.val;
            node.left = GenerateNodeWithParent(treeNode.left);
            node.right = GenerateNodeWithParent(treeNode.right);

            if (node.left is not null)
            {
                node.left.parent = node;
            }

            if (node.right is not null)
            {
                node.right.parent = node;
            }
            this.NodeMap[treeNode.val] = node;

            return node;
        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            this.NodeMap = new Dictionary<int, NodeWithParent>();
            var rootWithParent = this.GenerateNodeWithParent(root);
            var pWithParent = this.NodeMap[p.val];
            var qWithParent = this.NodeMap[q.val];

            var ancestor = new HashSet<int>();

            var node = pWithParent;

            while (node != null)
            {
                ancestor.Add(node.TreeNode.val);
                node = node.parent;
            }

            node = qWithParent;

            while (node != null && !ancestor.Contains(node.TreeNode.val))
            {
                node = node.parent;
            }

            return node.TreeNode;
        }

        // public static void Main(string[] args)
        // {
        //     var nodeP = TreeNode.StringToTreeNode("[5,6,2,null,null,7,4]");
        //     var nodeQ = TreeNode.StringToTreeNode("[1,0,8]");
        //     var root = new TreeNode(3);
        //     root.left = nodeP;
        //     root.right = nodeQ;
        //     var result = new LowestCommonAncestorProblem().LowestCommonAncestor(root, nodeP, nodeQ);
        //     Console.WriteLine($"root: {root}p:{nodeP.val},\nq:{nodeQ.val},\n=>{result}");
        // }
    }
}