using System;
using System.Text;

public class Utility{
    public static void PrettyPrintTree(TreeNode node, string prefix = "", bool isLeft = true) {
        
        if (node == null) {
            Console.WriteLine("Empty tree");
            return;
        }

        if(node.right !=null) {
            PrettyPrintTree(node.right, prefix + (isLeft ? "│   " : "    "), false);
        }

        Console.WriteLine( $"{prefix }{ (isLeft ? "└── " : "┌── ")}{ node.val}");

        if (node.left !=null) {
            PrettyPrintTree(node.left, prefix + (isLeft ? "    " : "│   "), true);
        }
    }
}