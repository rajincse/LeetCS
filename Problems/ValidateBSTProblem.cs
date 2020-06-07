using System;
using Common;

namespace Problems
{
    public class ValidateBSTProblem
    {
        public bool IsValidBST(TreeNode root) {
            if(root == null)
            {
                return true;
            }
            
            return IsValidBST(root, null, null);
        }

        public bool IsValidBST(TreeNode root, int? minValue, int? maxValue)
        {
            if(root == null)
            {
                return true;
            }            

            bool result = true;

            if(minValue != null)
            {
                result = result && root.val > minValue.Value;
            }

            if(maxValue != null)
            {
                result = result && root.val < maxValue.Value;
            }
            
            return result 
                && IsValidBST(root.left, minValue, root.val) 
                && IsValidBST(root.right, root.val, maxValue); 
        }
        public static void Main(string[] args)
        {
            string inputString = $"[1,null,5]";
            TreeNode node = TreeNode.StringToTreeNode(inputString);
            bool result = new ValidateBSTProblem().IsValidBST(node);
            Console.WriteLine($"Input: \n{node}\n=>{result}");
        }
    }
}