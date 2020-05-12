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
}