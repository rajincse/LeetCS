// https://leetcode.com/problems/binary-tree-vertical-order-traversal/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Problems
{
    public class BinaryTreeVerticalOrderProblem
    {
        public class TreeColumn
        {
            public TreeNode Node { get; set; }
            public int ColumnIndex { get; set; }

            public TreeColumn(TreeNode node, int columnIndex)
            {
                this.Node = node;
                this.ColumnIndex = columnIndex;
            }

        }
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            var queue = new Queue<TreeColumn>();
            var hashTable = new Dictionary<int, List<int>>();

            queue.Enqueue(new TreeColumn(root, 0));

            while (queue.Count != 0)
            {
                var treeColumn = queue.Dequeue();
                if (!hashTable.ContainsKey(treeColumn.ColumnIndex))
                {
                    var list = new List<int>();
                }
                hashTable[treeColumn.ColumnIndex].Add(treeColumn.Node.val);

                if (treeColumn.Node.left != null)
                {
                    queue.Enqueue(new TreeColumn(treeColumn.Node.left, treeColumn.ColumnIndex - 1));
                }

                if (treeColumn.Node.right != null)
                {
                    queue.Enqueue(new TreeColumn(treeColumn.Node.right, treeColumn.ColumnIndex + 1));
                }
            }
            var result = new List<IList<int>>();

            foreach (var kvp in hashTable)
            {
                result.Add(kvp.Value.ToList());
            }
            return result;
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