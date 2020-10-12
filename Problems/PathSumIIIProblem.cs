using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class PathSumIIIProblem
    {
        private int _totalPaths = 0;
        public int PathSum(TreeNode root, int sum) {
            if(root == null)
            {
                return 0;
            }
            List<int> requiredSums = new List<int>();                       
            SearchPath(root, requiredSums , sum);
            return _totalPaths;
        }

        private void SearchPath(TreeNode root, List<int> requiredSums, int sum)
        {
            if(root == null)
            {
                return;
            }
            if(root.val == sum)
            {
                _totalPaths++;
            }
            List<int> sums = new List<int>();
            
            foreach(var remainingSum in requiredSums)
            {
                if(remainingSum == root.val)
                {
                    _totalPaths++;
                }
                sums.Add(remainingSum - root.val);
            }
            sums.Add(sum - root.val);
            SearchPath(root.left, sums, sum);
            SearchPath(root.right, sums, sum);
        }

        // public static void Main(string[] args)
        // {
        //     TreeNode root = TreeNode.StringToTreeNode("[10,5,-3,3,2,null,11,3,-2,null,1]");
        //     int sum = 8;
        //     var result = new PathSumIIIProblem().PathSum(root, sum);
        //     Console.WriteLine($"{root}\n{sum} => {result}");
        // }
    }
}
