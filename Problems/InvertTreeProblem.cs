using Common;

namespace Problems
{
    public class InvertTreeProblem
    {
        public TreeNode InvertTree(TreeNode root) {
            if(root == null)
            {
                return null;
            }
            InvertTree(root.left);
            InvertTree(root.right);
            TreeNode previousLeft = root.left;
            TreeNode previousRight = root.right;
            root.left = previousRight;
            root.right = previousLeft;
            
            return root;
        }
    }

}