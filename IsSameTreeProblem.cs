using Common;

public class IsSameTreeProblem{
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if(p == null && q == null)
        {
            return true;
        }
        else if(p == null || q == null)
        {
            return false;
        }
        else if(p.val != q.val)
        {
            return false;
        }
        else
        {
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }        
    }
    public bool IsSubtree(TreeNode s, TreeNode t) {
        if(s == null || t == null)
        {
            return false;
        }
        return IsSameTree(s,t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
    }
}