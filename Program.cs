using System;

namespace LeetCS
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode p = new TreeNode(1);
            p.left = new TreeNode(2);
            p.right = new TreeNode(1);

            TreeNode q = new TreeNode(1);
            q.left = new TreeNode(1);
            q.right = new TreeNode(2);

            Utility.PrettyPrintTree(p);
            Console.WriteLine($"{p}\n{q}\n IsSame => {new IsSameTreeProblem().IsSameTree(p, q)}");
        }
    }
}
