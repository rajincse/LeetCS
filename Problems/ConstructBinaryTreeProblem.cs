using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class ConstructBinaryTreeProblem
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder) {
            if(preorder == null || preorder.Length ==0 || inorder == null || inorder.Length ==0)
            {
                return null;
            }
            Dictionary<int, int> indexMapInorder = new Dictionary<int, int>();
            for(int i=0;i<inorder.Length;i++)
            {
                indexMapInorder[inorder[i]] = i;
            }
            return GetTree(preorder, 0, preorder.Length-1, inorder, 0, inorder.Length-1, indexMapInorder);
        }

        public TreeNode GetTree(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd, Dictionary<int, int> indexMapInorder)
        {
            if(preorder == null || preorder.Length ==0 || inorder == null || inorder.Length ==0 || indexMapInorder.Count != inorder.Length || preStart> preEnd || inStart > inEnd )
            {
                return null;
            }
            TreeNode node = new TreeNode(preorder[preStart]);
            int rootInIndex = indexMapInorder[node.val];
            int preLength = rootInIndex - inStart;
            node.left = GetTree(preorder, preStart+1, preStart+preLength, inorder, inStart, rootInIndex-1, indexMapInorder);
            node.right = GetTree(preorder, preStart+preLength+1, preEnd, inorder, rootInIndex+1, inEnd, indexMapInorder);

            return node;
        }


        public static void Main(string[] args)
        {
            int[] pre = new int[]{1,2,4,5,8,3,6,7};
            int[] inOrder = new int[]{4,2,8,5,1,6,3,7};
            TreeNode result = new ConstructBinaryTreeProblem().BuildTree(pre, inOrder);
            Console.WriteLine($"input: {Utility.PrintArray<int>(pre)}, {Utility.PrintArray<int>(inOrder)}=>\n{result}");
        }
    }
}