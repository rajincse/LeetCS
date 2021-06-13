using System;
using Common;

namespace Problems
{
    public class CountGoodNodesProblem
    {
        public int GoodNodes(TreeNode root) {        
            if(root == null)
            {
                return 0;
            }
            
            return FindGoodNodes(root, int.MinValue);
        }
        
        public int FindGoodNodes(TreeNode root, int maxValue)
        {
            if(root == null)
            {
                return 0;
            }
            return (root.val >= maxValue ? 1: 0 )
                + FindGoodNodes(root.left, Math.Max(root.val, maxValue))
                + FindGoodNodes(root.right, Math.Max(root.val, maxValue));        
        }
        // public static void Main(string [] args)
        // {
        //     Console.WriteLine("Hello");
        // }
    }
}