using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class BinaryTreeLevelOrderProblem
    {
        public class TreeLevel
        {
            public TreeNode Node {get; set;}
            public int Level {get; set;}
            public TreeLevel(TreeNode node, int level)
            {
                Node = node;
                Level = level;
            }
        }
        public IList<IList<int>> LevelOrder(TreeNode root) {
            IList<IList<int>> result = new List<IList<int>>();
            if(root == null)
            {
                return result;
            }
            Queue<TreeLevel> queue = new Queue<TreeLevel>();
            
            List<int> currentLevelList = new List<int>();
            int currentLevel = 0;
            queue.Enqueue(new TreeLevel(root, currentLevel));
            while(queue.Count > 0)
            {
                TreeLevel nodeWithLevel = queue.Dequeue();
                if(nodeWithLevel.Level == currentLevel)
                {
                    currentLevelList.Add(nodeWithLevel.Node.val);
                }
                else
                {
                    result.Add(currentLevelList);
                    currentLevelList = new List<int>();
                    currentLevelList.Add(nodeWithLevel.Node.val);
                    currentLevel = nodeWithLevel.Level;
                }
                if(nodeWithLevel.Node.left != null)
                {
                    queue.Enqueue(new TreeLevel(nodeWithLevel.Node.left, nodeWithLevel.Level +1));
                }
                if(nodeWithLevel.Node.right != null)
                {
                    queue.Enqueue(new TreeLevel(nodeWithLevel.Node.right, nodeWithLevel.Level +1));
                }
            }
            result.Add(currentLevelList);
            return result;
        }
        public static void Main(string[] args)
        {
            string tree = $"[1,2,3,4,5,6,7,null, null, 8]";            
            TreeNode node = TreeNode.StringToTreeNode(tree);            
            var result = new BinaryTreeLevelOrderProblem().LevelOrder(node);
            Console.WriteLine($"Input: \n{node}\n=>{Utility.Print2DList<int>(result)}");
        }
    }
}