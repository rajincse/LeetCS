using Common;

namespace Problems
{
    public class LowestCommonAncestorBSTProblem
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            if(root == null || root.val == p.val || root.val == q.val)
            {
                return root;
            }
            if(p.val < root.val && q.val < root.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else if(p.val > root.val && q.val > root.val)
            {
                return LowestCommonAncestor(root.right, p, q);
            }
            else
            {
                return root;
            }
        }
    }
}