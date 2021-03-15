using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
        public class DeleteReturnForestProblem
        {
            public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
            _treeQueue = new Queue<TreeNode>();
            if(root == null)
            {
                return new List<TreeNode>(_treeQueue);
            }
            _treeQueue.Enqueue(root);
            if(to_delete == null || to_delete.Length == 0)
            {
                return new List<TreeNode>(_treeQueue);
            }
            
            foreach(int deleteValue in to_delete)
            {
                int count = _treeQueue.Count;
                for(int i=0;i<count;i++)
                {
                    TreeNode node = _treeQueue.Dequeue();
                    node = DeleteNode(node, deleteValue);
                    if(node != null)
                    {
                        _treeQueue.Enqueue(node);
                    }                    
                }           
            }
            
            return new List<TreeNode>(_treeQueue);
        }
        private Queue<TreeNode> _treeQueue {get;set;}
        
        private TreeNode DeleteNode(TreeNode root, int deleteValue)
        {
            if(root == null)
            {
                return root;
            }
            
            if(root.val == deleteValue)
            {
                if(root.left != null)
                {
                    _treeQueue.Enqueue(root.left);
                }
                
                if(root.right != null)
                {
                    _treeQueue.Enqueue(root.right);
                }
                return null;
            }
            
            root.left = DeleteNode(root.left, deleteValue);
            root.right = DeleteNode(root.right, deleteValue);
            
            return root;
        }

        // public static void Main(string[] args)
        // {
        //     TreeNode root = TreeNode.StringToTreeNode("[1,2,null,4,3]");
        //     int[] toDelete = new int[]{2,3};
        //     Console.WriteLine($"{root}, {Utility.PrintArray<int>(toDelete)}=>");
        //     var result = new DeleteReturnForestProblem().DelNodes(root, toDelete);
        //     Console.WriteLine($"{Utility.PrintList<TreeNode>(result)}");
        // }
    }
}