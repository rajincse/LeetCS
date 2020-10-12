using System;
using System.Collections.Generic;
using Common;

namespace Problems{
    public class DistanceKTreeNodeProblem
    {
        public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
            List<int> nodeValueList = new List<int>();
            if(K ==0)
            {
                nodeValueList.Add(target.val);
                return nodeValueList;
            }
            GetAncestralDistance(root, target.val, K, nodeValueList);
            return nodeValueList;
        }

        private int GetAncestralDistance(TreeNode root, int targetValue, int K, List<int> nodeValueList)
        {
            if(root == null)
            {
                return -1;
            }
            //Check if current is target
            if(root.val == targetValue)
            {                
                nodeValueList.AddRange(GetAllKDistanceChildren(root, K));
                return 1;
            }
            //Check Left tree
            int ancestralDistance = GetAncestralDistance(root.left, targetValue, K, nodeValueList);
            if(ancestralDistance > 0)
            {
                if(K == ancestralDistance)
                {
                    nodeValueList.Add(root.val);                    
                }
                else if(K >= ancestralDistance+1)
                {
                    nodeValueList.AddRange(GetAllKDistanceChildren(root.right, K-ancestralDistance-1));
                }
                return ancestralDistance+1;
            }

            //Check Right Tree
            ancestralDistance = GetAncestralDistance(root.right, targetValue, K, nodeValueList);
            if(ancestralDistance > 0)
            {
                if(K == ancestralDistance)
                {
                    nodeValueList.Add(root.val);                    
                }
                else if(K >= ancestralDistance+1)
                {
                    nodeValueList.AddRange(GetAllKDistanceChildren(root.left, K-ancestralDistance-1));
                }
                return ancestralDistance+1;
            }

            return -1;
        }

        public IList<int> GetAllKDistanceChildren(TreeNode root, int k)
        {
            List<int> nodeValueList = new List<int>();
            if(root == null || k < 0)
            {
                return nodeValueList;
            }
            
            if(k== 0)
            {
                nodeValueList.Add(root.val);
                return nodeValueList;
            }

            //Check left
            var leftList = GetAllKDistanceChildren(root.left, k-1);
            if(leftList != null && leftList.Count > 0)
            {
                nodeValueList.AddRange(leftList);
            }
            //Check right
            var rightList = GetAllKDistanceChildren(root.right, k-1);
            if(rightList != null && rightList.Count > 0)
            {
                nodeValueList.AddRange(rightList);
            }

            return nodeValueList;
        }

        // public static void Main(string[] args)
        // {
        //     // var root = TreeNode.StringToTreeNode("[3,5,1,6,2,0,8,null,null,7,4]");
        //     // var target = TreeNode.StringToTreeNode("[5,6,2,null,null,7,4]");
        //     var root = TreeNode.StringToTreeNode("[0,null,1,null,2,null,3]");
        //     var target = TreeNode.StringToTreeNode("[1,null,2,null,3]");
        //     int K = 2;
        //     var result = new DistanceKTreeNodeProblem().DistanceK(root, target, K);
        //     Console.WriteLine($"root\n{ root}\n{target.val}, {K} => \n{Utility.PrintList<int>(result)}");
        // }
    }
}