// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days

using System;
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
            return null;
        }

        // public static void Main(string[] args)
        // {
        //     var nodeP = Node.FromTreeNode(Common.TreeNode.StringToTreeNode("[5,6,2,null,null,7,4]"));
        //     var nodeQ = Node.FromTreeNode(Common.TreeNode.StringToTreeNode("[1,0,8]"));
        //     var result = new LowestCommonAncestorIIIProblem().LowestCommonAncestor(nodeP, nodeQ);
        //     Console.WriteLine($"p: \n{nodeP},\nq:\n{nodeQ},\n=>{result}");
        // }
    }
}