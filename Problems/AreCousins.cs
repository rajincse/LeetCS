using Common;
using System;

namespace Problems
{
    public class AreCousins
    {
        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (AreSiblings(root, x, y))
            {
                return false;
            }

            int depthX = CalculateDepth(root, x);
            int depthY = CalculateDepth(root, y);
            if(depthX == depthY)
                return true;
            return false;
        }
        public bool AreSiblings(TreeNode root, int x, int y)
        {
            if (root == null)
            {
                return false;
            }
            else if(root.left != null && root.right != null && ((root.left.val == x && root.right.val == y) || (root.left.val == y && root.right.val == x)) )
            {
                return true;
            }
            else
            {
                return AreSiblings(root.left, x, y) || AreSiblings(root.right, x, y);
            }
        }
        public int CalculateDepth(TreeNode root, int val) {
            if (root == null)
            {
                return int.MinValue;
            }
            else if (root.val == val)
            {
                return 0;
            }
            else
            {
                return Math.Max(CalculateDepth(root.left, val), CalculateDepth(root.right, val))+1;
            }
        }
        //public static void Main(string[] args)
        //{
        //    string input = "[1,null,2,3,5,4,null,null,null,null,6]";
        //    int x = 5;
        //    int y = 3;
        //    TreeNode node = TreeNode.StringToTreeNode(input);
        //    Console.WriteLine($"{node.ToString()}");
        //    Console.WriteLine($"x={x}, y={3}");
        //    Console.WriteLine($"IsCousins=>{new AreCousins().IsCousins(node,x,y)}");
        //}
    }
}
