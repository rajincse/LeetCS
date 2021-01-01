using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class EvaluateDivisionProblem
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
            double[] result = Array.Empty<double>();
            if(
                equations == null || equations.Count ==0 || equations[0] == null || equations[0].Count == 0
                ||
                queries == null || queries.Count ==0 || queries[0] == null || queries[0].Count == 0
                ||
                values == null || values.Length != equations.Count

            )
            {
                return result;
            }
            IDictionary<string, IDictionary<string, double>> graph = new Dictionary<string, IDictionary<string, double>>();
            
            for(int i=0;i<equations.Count;i++)
            {
                string dividend = equations[i][0];
                string divisor = equations[i][1];
                double quotient = values[i];
                if(!graph.ContainsKey(dividend))
                {
                    graph[dividend] = new Dictionary<string, double>();
                }
                var neighborMap = graph[dividend];
                if(!neighborMap.ContainsKey(divisor))
                {
                    neighborMap.Add(divisor, quotient);
                }
                else
                {
                    neighborMap[divisor] = quotient;
                }
                graph[dividend]=neighborMap;

                if(!graph.ContainsKey(divisor))
                {
                    graph[divisor] = new Dictionary<string, double>();
                }
                neighborMap = graph[divisor];
                if(!neighborMap.ContainsKey(divisor))
                {
                    neighborMap.Add(dividend, 1/quotient);
                }
                else
                {
                    neighborMap[dividend] = 1/ quotient;
                }
                graph[divisor]=neighborMap;
            }
            
            result = new double[queries.Count];
            for(int i=0;i<result.Length;i++)
            {                
                string dividend = queries[i][0];
                string divisor = queries[i][1];
                result[i] = Calculate(dividend, divisor, 1, graph, new HashSet<string>());                
            }
            
            return result;
        }

        private double Calculate(string dividend, string divisor, double currentValue, IDictionary<string, IDictionary<string, double>> graph, HashSet<string> visited)
        {
            if(!graph.ContainsKey(dividend) || !graph.ContainsKey(divisor))
            {
                return -1;
            }            

            if(dividend.Equals(divisor, StringComparison.OrdinalIgnoreCase))
            {
                return 1;
            }            
            
            var neighborMap = graph[dividend];
            if(neighborMap.ContainsKey(divisor))
            {
                return currentValue * neighborMap[divisor];   
            }
            else
            {
                double value = -1;
                visited.Add(dividend);
                foreach(string neighbor in neighborMap.Keys)
                {
                    if(!visited.Contains(neighbor))
                    {
                        value = Calculate(neighbor, divisor, currentValue * neighborMap[neighbor], graph, visited);
                        if(value != -1)
                        {
                            break;
                        }
                    }
                }
                visited.Remove(dividend);
                return value;
            }
        }

        // public static void Main(string[] args)
        // {
        //     IList<IList<string>> equations = new List<IList<string>>()
        //     {
        //         new List<string>(){"a", "b"},
        //         new List<string>(){"b", "c"}
        //     };
        //     double[] values = new double[]{2,3};
        //     IList<IList<string>> queries = new List<IList<string>>()
        //     {
        //         new List<string>(){"a", "c"},
        //         new List<string>(){"b", "a"},
        //         new List<string>(){"a", "e"},
        //         new List<string>(){"a", "a"},
        //         new List<string>(){"a", "x"}
        //     };
        //     var result = new EvaluateDivisionProblem().CalcEquation(equations, values, queries);
        //     Console.WriteLine($"[{Utility.Print2DList<string>(equations)}], [{Utility.PrintArray<double>(values)}], [{Utility.Print2DList<string>(queries)}]");
        //     Console.WriteLine($"=>{Utility.PrintArray<double>(result)}");
        // }
    }
}