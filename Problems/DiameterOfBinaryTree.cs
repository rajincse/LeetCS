using System;
using Common;

namespace Problems
{
    public class DiameterOfBinaryTreeProblem
    {
        public class HeightAndDiameter
        {
            public int Height { get; set; }
            public int Diameter { get; set; }

            public HeightAndDiameter(int height, int diameter)
            {
                this.Height = height;
                this.Diameter = diameter;
            }
        }
        public int DiameterOfBinaryTree(TreeNode root)
        {
            var heightAndDiameter = GetHeightAndDiameter(root);
            return heightAndDiameter.Diameter;
        }

        public HeightAndDiameter GetHeightAndDiameter(TreeNode root)
        {
            if (root is null)
            {
                return new HeightAndDiameter(-1, 0);
            }
            var heightDiameterLeft = GetHeightAndDiameter(root.left);
            var heightDiameterRight = GetHeightAndDiameter(root.right);

            var height = Math.Max(heightDiameterLeft.Height, heightDiameterRight.Height) + 1;
            var maxDiameterBetweenChildren = Math.Max(heightDiameterLeft.Diameter, heightDiameterRight.Diameter);
            var diameterWithHeights = heightDiameterLeft.Height + heightDiameterRight.Height + 2;
            var diameter = Math.Max(maxDiameterBetweenChildren, diameterWithHeights);

            return new HeightAndDiameter(height, diameter);
        }
        // public static void Main(string[] args)
        // {
        //     string tree = $"[1,2,3,4,5,6,7,null, null, 8]";
        //     TreeNode node = TreeNode.StringToTreeNode(tree);
        //     var result = new DiameterOfBinaryTreeProblem().DiameterOfBinaryTree(node);
        //     Console.WriteLine($"Input: \n{node}\n=>{result}");
        // }
    }
}