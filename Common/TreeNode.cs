using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Common
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public override string ToString()
        {
            return TreeNode.GetTreeString(this);
        }

        public static string GetTreeString(TreeNode node, string prefix = null, bool isLeft = true) {
            
            if (node == null) {            
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            if(node.right !=null) {
                sb.Append(GetTreeString(node.right, $"{prefix}{(isLeft ? "│   " : "    ")}", false));
            }

            sb.AppendLine( $"{prefix }{ (isLeft ? "└── " : "┌── ")}{ node.val}");

            if (node.left !=null) {
                sb.Append(GetTreeString(node.left, prefix + (isLeft ? "    " : "│   "), true));
            }
            return sb.ToString();
        }

        public static TreeNode StringToTreeNode(string input) {
            input = input.Trim();
            
            input = input.Substring(1, input.Length - 2);
            if (string.IsNullOrWhiteSpace(input)) {
                return null;
            }

            
            string[] inputArray = input.Split(',');
            Queue<string> inputQueue = new Queue<string>();
            foreach(string i in inputArray)
            {
                inputQueue.Enqueue(i);
            }
            string item =inputQueue.Dequeue(); 
            TreeNode root = new TreeNode(int.Parse(item));
            
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);

            while (true) {
                TreeNode node = nodeQueue.Dequeue();                
                
                if(inputQueue.Count ==0)
                {
                    break;
                }
                else
                {
                    item =inputQueue.Dequeue(); 
                    item = item.Trim();
                }

                if (!item.Equals("null", StringComparison.InvariantCultureIgnoreCase)) {
                    int leftNumber = int.Parse(item);
                    node.left = new TreeNode(leftNumber);
                    nodeQueue.Enqueue(node.left);
                }

                if(inputQueue.Count ==0)
                {
                    break;
                }
                else
                {
                    item =inputQueue.Dequeue(); 
                    item = item.Trim();
                }
                
                if (!item.Equals("null", StringComparison.InvariantCultureIgnoreCase)) {
                    int leftNumber = int.Parse(item);
                    node.right = new TreeNode(leftNumber);
                    nodeQueue.Enqueue(node.right);
                }
            }
            return root;
        }
    }
}

 