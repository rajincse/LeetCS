// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days

using System;
using System.Collections.Generic;
using Common;

namespace Problems.BinaryTree
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;

        public TreeNode TreeNode;

        public override string ToString()
        {
            return this.TreeNode.ToString();
        }

        public static Node FromTreeNode(Common.TreeNode treeNode)
        {
            if (treeNode is null)
            {
                return null;
            }
            var node = new Node();
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
    public class LowestCommonAncestorIIIProblem
    {
        public Node LowestCommonAncestor(Node p, Node q)
        {
            var ancestors = new HashSet<Node>();

            var node = p;

            while (node != null)
            {
                ancestors.Add(node);
                node = node.parent;
            }

            node = q;
            while (node != null && !ancestors.Contains(node))
            {
                node = node.parent;
            }

            return node;
        }

        // public static void Main(string[] args)
        // {
        //     var root = Node.FromTreeNode(Common.TreeNode.StringToTreeNode("[3,5,1,6,2,0,8,null,null,7,4]"));
        //     var nodeP = root.left;
        //     var nodeQ = root.right;
        //     var result = new LowestCommonAncestorIIIProblem().LowestCommonAncestor(nodeP, nodeQ);
        //     Console.WriteLine($"p: \n{nodeP},\nq:\n{nodeQ},\n=>{result}");
        // }
    }
}