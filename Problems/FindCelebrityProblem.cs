using System;

namespace Problems
{
    public class FindCelebrityProblem
    {
        public bool Knows(int a, int b)
        {
            int[][] graph = new int[][]{
                new int[]{0,1},
                new int[]{1,0},
            };

            return graph[a][b] == 1;
        }
        public int FindCelebrity(int n) {
            if(n<=0)
            {
                return -1;
            }
            
            int i=0;
            int j=0;
            while(i<n && j<n)
            {
                if(i!=j && Knows(i,j))
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            Console.WriteLine(i);
            if(i>=n)
            {
                return -1;
            }
            else if(!IsSink(i,n))
            {
                return -1;
            }
            else 
            {
                return i;
            }
        }
        private bool IsSink(int node, int totalNodes)
        {
            if(node<0 || node >= totalNodes)
            {
                return false;
            }
            
            for(int i=0;i<totalNodes;i++)
            {
                if(i!=node && Knows(node,i))
                {
                    return false;
                }
                
                if(!Knows(i,node))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}