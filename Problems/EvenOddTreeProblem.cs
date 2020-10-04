using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class EvenOddTreeProblem
    {
        public class TreeLevel
        {
            public TreeNode Node {get;}
            public int Level {get;}
            public TreeLevel(TreeNode node, int level)
            {
                Node = node;
                Level = level;
            }

            public override string ToString()
            {
                return $"{{{ Node.val} , {Level}}}";
            }
        }
        
        public bool IsEvenOddTree(TreeNode root) {
            if(root == null)
            {
                return false;
            }
            
            Queue<TreeLevel> queue = new Queue<TreeLevel>();
            TreeLevel rootTreeLevel = new TreeLevel(root, 0);
            TreeLevel previousTreeLevel = rootTreeLevel;
            queue.Enqueue(new TreeLevel(root, 0));
            while(queue.Count != 0)
            {
                TreeLevel treeLevel = queue.Dequeue();
                if(treeLevel.Node.left != null)
                {
                    queue.Enqueue(new TreeLevel(treeLevel.Node.left, treeLevel.Level+1));
                }
                if(treeLevel.Node.right != null)
                {
                    queue.Enqueue(new TreeLevel(treeLevel.Node.right, treeLevel.Level+1));
                }
                //Even odd value check                
                if(treeLevel.Level %2 ==0 && treeLevel.Node.val %2 ==0)
                {
                    return false;
                }
                else if(treeLevel.Level %2 ==1 && treeLevel.Node.val %2 ==1)
                {
                    return false;
                }
                
                
                //Check for increasing or decreasing
                if(treeLevel.Level > 0 && treeLevel.Level == previousTreeLevel.Level)
                {
                    //even Asceniding
                    if(treeLevel.Level %2 ==0 && treeLevel.Node.val <= previousTreeLevel.Node.val)
                    {
                        return false;
                    }
                    else if(treeLevel.Level %2 ==1 && treeLevel.Node.val >= previousTreeLevel.Node.val) // Odd descending
                    {
                        return false;
                    }
                    
                }
                
                previousTreeLevel = treeLevel;
                
            }
            
            return true;
        }

        // public static void Main(string[] args)
        // {
        //     var treeNode = TreeNode.StringToTreeNode("[2,12,8,5,9,null,null,18,16]");
        //     var result = new EvenOddTreeProblem().IsEvenOddTree(treeNode);
        //     Console.WriteLine($"{treeNode} \n => {result}");
        // }
    }
}