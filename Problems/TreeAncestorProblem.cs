using System;
using System.Collections.Generic;

// Time Complexity unsatisfactory
namespace Problems
{
    public class TreeAncestorProblem
    {
        public class TreeAncestor {
            public int[]  Parent {get;set;}
            public int TotalNodes {get;set;}
            public int[][] DP {get;set;}
            public int Height {get;set;}
            public TreeAncestor(int n, int[] parent) {
                TotalNodes = n;
                Parent = parent;
                int maxHeight = 1;
                int[] heightArray = new int[n];
                heightArray[0] = 1;
                for(int i=1;i< heightArray.Length;i++)
                {
                    heightArray[i] = heightArray[parent[i]]+1;
                    maxHeight = Math.Max(maxHeight, heightArray[i]);
                }
                Height = maxHeight;

                DP = new int[n][];
                for(int i=0;i<n;i++)
                {            
                    DP[i] = new int[Height];
                    DP[i][0] = i;
                    DP[i][1] = parent[i];
                }
            }
            private int GetKthAncestorRecursive(int node, int k)
            {
                if(node< 0 || node >= TotalNodes || k <0 || k>= Height)
                {
                    return -1;
                }

                if(k==0)
                {
                    DP[node][k] = node;
                    return DP[node][k];
                }

                if(node == 0 && k > 0)
                {
                    DP[node][k] = -1;
                    return DP[node][k] ;
                }
                if(DP[node][k] == -1)
                {
                    return DP[node][k];
                }

                if(DP[node][k] != 0 )
                {            
                    return DP[node][k];
                }
                else{
                    DP[node][k] = GetKthAncestorRecursive(Parent[node], k-1);
                    return DP[node][k];
                }
            }
            public int GetKthAncestor(int node, int k) {
                if(node< 0 || node >= TotalNodes || k <0 || k>= Height)
                {
                    return -1;
                }
                return GetKthAncestorRecursive(node, k);
            }
        }

        public static void Main(string[] args)
        {
             int n = 10;
             int [] parent = new int[]{-1,0,1,2,0,1,0,4,7,1};
             TreeAncestor ancestor = new TreeAncestor(10, parent);
             var result = ancestor.GetKthAncestor(3, 3);
             Console.WriteLine($"result:{result}");
        }
    }
}