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
    }
}

 