using System;
using System.Collections.Generic;
using Common;

namespace Basic
{
    public class CombinationProblem
    {
        public IList<IList<int>> Combine(int n, int k) {

            List<IList<int>> result = new List<IList<int>>();
            Combination(new List<int>(),1,n,k,result);

            return result;
        }



        public void Combination(IList<int> prefixList, int next, int n, int k, IList<IList<int>>  result){
            if(prefixList.Count==k)
            {
                result.Add(new List<int>(prefixList));
            }
            else
            {
                for(int i=next;i<=n;i++)
                {
                    prefixList.Add(i);
                    Combination(prefixList,i+1,n,k,result);
                    prefixList.RemoveAt(prefixList.Count-1);
                }
            }
        }

        // public static void Main(string[] args)
        // {
        //     int n = 4;
        //     int k =2;
        //     var result = new CombinationProblem().Combine(n,k);
        //     Console.WriteLine($"{n}, {k} => {Utility.Print2DList<int>(result)}");
        // }
    }
}