using System;
using Common;

namespace Problems
{
    public class SameTreeProblem
    {
        public bool IsSameTree(TreeNode p, TreeNode q) {
            if(p== null && q == null)
            {
                return true;
            }

            if(p== null || q == null)
            {
                return false;
            }


            return p.val == q.val 
                && IsSameTree(p.left, q.left)
                && IsSameTree(p.right, q.right)
            ;
        }
        // public static void Main(string[] args)
        // {
        //     string tree1 = $"[1,2,3]";
        //     string tree2 = $"[1,2,3]";
        //     TreeNode node1 = TreeNode.StringToTreeNode(tree1);
        //     TreeNode node2 = TreeNode.StringToTreeNode(tree2);
        //     bool result = new SameTreeProblem().IsSameTree(node1, node2);
        //     Console.WriteLine($"Input: \n{node1}\n{node2}\n=>{result}");
        // }
    }
}