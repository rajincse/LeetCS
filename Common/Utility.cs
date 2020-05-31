using System;
using System.Collections.Generic;
using System.Text;

namespace  Common
{
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

        public static string PrintArray<T>(T[] arr)
        {    
            if(arr == null) return null;      
            return string.Join<T>(",", arr);
        }
        public static string Print2DArray<T>(T[][] arr2D, char arraySeparator =',')
        {
            if(arr2D == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach(T[] arr in arr2D)
            {
                sb.Append("[");
                sb.Append(string.Join(",", arr));
                sb.Append("]");
                sb.Append(arraySeparator);
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static string PrintList<T>(IList<T> arr)
        {   
            if(arr == null) return null;     
            return string.Join<T>(",", arr);
        }

        public static string Print2DList<T>(IList<IList<T>> list2D)
        {
            if(list2D == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach(IList<T> list in list2D)
            {
                sb.Append("[");
                sb.Append(string.Join(",", list));
                sb.Append("],");
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
