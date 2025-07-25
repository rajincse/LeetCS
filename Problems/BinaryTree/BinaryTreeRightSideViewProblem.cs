// https://leetcode.com/problems/binary-tree-right-side-view/description/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Problems.BinaryTree
{
    public class TreeNodeWithLevel
    {
        public TreeNode TreeNode { get; set; }
        public int Level { get; set; }
    }
    public class BinaryTreeRightSideViewProblem
    {
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            var queue = new Queue<TreeNodeWithLevel>();
            queue.Enqueue(new TreeNodeWithLevel { TreeNode = root, Level = 0 });
            var level = -1;
            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (node.TreeNode.left is not null)
                {
                    queue.Enqueue(new TreeNodeWithLevel { TreeNode = node.TreeNode.left, Level = node.Level + 1 });
                }
                if (node.TreeNode.right is not null)
                {
                    queue.Enqueue(new TreeNodeWithLevel { TreeNode = node.TreeNode.right, Level = node.Level + 1 });
                }
                if (level != node.Level)
                {
                    result.Add(node.TreeNode.val);
                    level = node.Level;
                }
            }

            return result;
        }

        public static void Main(string[] args)
        {
            var root = TreeNode.StringToTreeNode("[1,2,3,null,5,null,4]");
            var result = new BinaryTreeRightSideViewProblem().RightSideView(root);
            Console.WriteLine($"root: \n{root},\nresult=>{Utility.PrintList<int>(result)}");
        }
    }
}