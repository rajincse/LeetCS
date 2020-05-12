using System;
using System.Collections.Generic;
using Common;

namespace Problems{
    public class BinaryTreePreorder{
        public IList<int> PreorderTraversal(TreeNode root) {

            return PreorderTraversalIterative(root);
        }
        public IList<int> PreorderTraversalIterative(TreeNode root)
        {
            
            List<int> result = new List<int>();
            if(root == null)
            {
                return result;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();   
            stack.Push(root);

            while(stack.Count !=0)
            {
                TreeNode node = stack.Pop();
                if(node != null)
                {
                    result.Add(node.val);
                    stack.Push(node.right);
                    stack.Push(node.left);
                }
                
            }
            return result;
        }
        public IList<int> PreorderTraversalRecursive(TreeNode root)
        {
            List<int> result = new List<int>();
            if(root != null)
            {
                result.Add(root.val);
                result.AddRange(PreorderTraversal(root.left));
                result.AddRange(PreorderTraversal(root.right));
            }    
            return result;
        }
        public static void Main(string[] args)
        {
            string input ="[1,null,2,3]";
            TreeNode node = TreeNode.StringToTreeNode(input);
            Console.WriteLine($"{node.ToString()}");
            Console.WriteLine($"Preorder=>{Utility.PrintList<int>(new BinaryTreePreorder().PreorderTraversal(node))}");
        }
    }

}