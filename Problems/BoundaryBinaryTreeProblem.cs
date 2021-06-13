using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class BoundaryBinaryTreeProblem
    {
        public IList<int> BoundaryOfBinaryTree(TreeNode root) {
            if(root == null)
            {
                return null;
            }
            if(isLeaf(root))
            {
                return new int[]{root.val};
            }
            IList<int> leafList = new List<int>();
            PopulateLeaves(root, leafList);

            IList<int> leftList = new List<int>();
            PopulateLeftBoundary(root, leftList);

            IList<int> rightList = new List<int>();
            PopulateRightBoundary(root, rightList);

            IList<int> result = new List<int>();
            Console.WriteLine($"root={root.val}, left={{{Utility.PrintList<int>(leftList)}}}, leaves={{{Utility.PrintList<int>(leafList)}}}, right={{{Utility.PrintList<int>(rightList)}}}");
            result.Add(root.val);
            for(int i=0;i< leftList.Count;i++)
            {
                result.Add(leftList[i]);
            }
            for(int i=0;i< leafList.Count;i++)
            {
                result.Add(leafList[i]);
            }
            for(int i=rightList.Count-1;i>= 0;i--)
            {
                result.Add(rightList[i]);
            }


            return result;
        }

        public void PopulateLeftBoundary(TreeNode root, IList<int> leftList)
        {
            if(leftList == null)
            {
                leftList = new List<int>();
            }
            if(root == null)
            {
                return ;
            }

            if(root.left == null && leftList.Count > 0 && !isLeaf(root.right))
            {
                leftList.Add(root.right.val);
                PopulateLeftBoundary(root.right, leftList);
            }
            else if(root.left != null && ! isLeaf(root.left) )
            {
                leftList.Add(root.left.val);
                PopulateLeftBoundary(root.left, leftList);
            }
        }

        public void PopulateRightBoundary(TreeNode root, IList<int> rightList)
        {
            if(rightList == null)
            {
                rightList = new List<int>();
            }
            if(root == null)
            {
                return ;
            }

            if(root.right == null && rightList.Count > 0 && !isLeaf(root.left))
            {
                rightList.Add(root.left.val);
                PopulateRightBoundary(root.left, rightList);
            }
            else if(root.right != null && ! isLeaf(root.right) )
            {
                rightList.Add(root.right.val);
                PopulateRightBoundary(root.right, rightList);
            }
        }
        public void PopulateLeaves(TreeNode root, IList<int> leafList)
        {
            if(leafList == null)
            {
                leafList = new List<int>();
            }
            if(root == null)
            {
                return ;
            }
            else if(root.left == null && root.right == null)
            {
                leafList.Add(root.val);
            }
            else if(root.left == null)
            {
                PopulateLeaves(root.right, leafList);
            }
            else if(root.right == null)
            {
                PopulateLeaves(root.left, leafList);
            }
            else
            {
                PopulateLeaves(root.left, leafList);
                PopulateLeaves(root.right, leafList);
            }
        }
        public bool isLeaf(TreeNode root)
        {
            if(root == null)
            {
                return false;
            }
            else
            {
                return root.left == null && root.right == null;
            }
        }
        // public static void Main(string[] args)
        // {
        //     TreeNode root = TreeNode.StringToTreeNode("[1,2,9,3,null,5,8,4,null,null,null,6,7]");
        //     var result = new BoundaryBinaryTreeProblem().BoundaryOfBinaryTree(root);
        //     Console.WriteLine($"{root.ToString()}\r\n=>{Utility.PrintList<int>(result)}");
        // }
    }
}