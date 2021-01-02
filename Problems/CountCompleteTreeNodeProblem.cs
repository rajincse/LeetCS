using System;
using Common;

namespace Problems
{
    public class CountCompleteTreeNodeProblem
    {
        public int CountNodes(TreeNode root) {
            if(root == null)
            {
                return 0;
            }
            int height = GetHeight(root);
            int totalNodes = (1 << height) -1 - _missingNodes;
            return totalNodes;
        }

        private int _missingNodes = 0;
        public int GetHeight(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }
            else
            {
                int leftTreeHeight = GetHeight(root.left);
                int rightTreeHeight = GetHeight(root.right);
                
                int heightDifference = Math.Abs(leftTreeHeight- rightTreeHeight);
                if(leftTreeHeight > rightTreeHeight )
                {
                    int expectedNodes = (1 << leftTreeHeight) -1;
                    int foundNodes = (1 << rightTreeHeight) -1;
                    int currentMissingNodes = expectedNodes - foundNodes;
                    
                    _missingNodes += currentMissingNodes;
                }

                return Math.Max(leftTreeHeight, rightTreeHeight)+1;
            }
        }

        // public static void Main(string[] args)
        // {
        //     var root = TreeNode.StringToTreeNode("[1,2,3,4, 5, 6,7,8]");
        //     var result = new CountCompleteTreeNodeProblem().CountNodes(root);
        //     Console.WriteLine($"{root} \r\n=>{result}");
        // }
    }
}