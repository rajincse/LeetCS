// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days

namespace Problems.BinaryTree
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;

        public static Node FromTreeNode(Common.TreeNode treeNode)
        {
            if (treeNode is null)
            {
                return null;
            }


        }
    }
    public class LowestCommonAncestorIIIProblem
    {
        public Node LowestCommonAncestor(Node p, Node q)
        {
            return null;
        }

        public static void Main(string[] args)
        {
            var nodeP = Common.TreeNode.StringToTreeNode("[5,6,2,null,null,7,4]");
            var nodeQ = Common.TreeNode.StringToTreeNode("[1,0,8]");
            int result = new LowestCommonAncestorIIIProblem().LowestCommonAncestor(nodeP, nodeQ);
            Console.WriteLine($"Input: \n{node}\n=>{result}");
        }
    }
}