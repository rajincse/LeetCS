using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Common;

namespace Problems
{
    public class  ReorderDataLogProblem
    {
        public class Log : IComparable<Log>
        {
            public string Identifier {get; set;}
            public string FullValue {get; set;}

            public int Order {get;}
            public bool IsLetterLog {get;set;}
            public string[] Items {get;}

            public Log(string value, int order)
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                string[] splits = value.Split(' ');
                Identifier = splits[0];
                FullValue = value;
                Order = order;

                Items = new string[splits.Length-1];
                for(int i=1;i<splits.Length;i++)
                {
                    Items[i-1] = splits[i];
                }

                IsLetterLog = !Char.IsDigit( Items[0].ToCharArray()[0]);
            }
            public override string ToString()
            {
                return FullValue;
            }
            public int CompareTo(Log other)
            {
                if(IsLetterLog && other.IsLetterLog)
                {
                    int minLength = Math.Min(Items.Length, other.Items.Length);
                    for(int i=0;i<minLength;i++)
                    {
                        int compareValue = string.Compare(Items[i], other.Items[i]);
                        if( compareValue != 0)
                        {
                            return compareValue;
                        }
                    }
                    if(Items.Length > minLength)
                    {
                        return 1;
                    }
                    else if(other.Items.Length > minLength)
                    {
                        return -1;
                    }
                    else
                    {
                        return string.Compare(Identifier, other.Identifier);
                    }

                }
                else if(!IsLetterLog && !other.IsLetterLog)
                {
                    return Order - other.Order;
                }
                else if(IsLetterLog && !other.IsLetterLog)
                {
                    return -1;
                }
                else 
                {
                    return 1;
                }
            }
        } 
        public string[] ReorderLogFiles(string[] logs) {
            if(logs == null || logs.Length ==0)
            {
                return null;
            }
            List<Log> list = new List<Log>();
            int order = 0;
            foreach(string logValue in logs)
            {
                Log log = new Log(logValue, order);
                order++;
                list.Add(log);
            }
            list.Sort();
            var result = list.Select(x=> x.FullValue).ToArray();
            return result;
        }
        // public static void Main(string[] args)
        // {
        //     string [] logs = new string[]
        //     {
        //         "l5sh 6 3869 08 1295", "16o 94884717383724 9", "43 490972281212 3 51", "9 ehyjki ngcoobi mi", "2epy 85881033085988", "7z fqkbxxqfks f y dg", "9h4p 5 791738 954209", "p i hz uubk id s m l", "wd lfqgmu pvklkdp u", "m4jl 225084707500464", "6np2 bqrrqt q vtap h", "e mpgfn bfkylg zewmg", "ttzoz 035658365825 9", "k5pkn 88312912782538", "ry9 8231674347096 00", "w 831 74626 07 353 9", "bxao armngjllmvqwn q", "0uoj 9 8896814034171", "0 81650258784962331", "t3df gjjn nxbrryos b"
        //     };
        //     var result = new ReorderDataLogProblem().ReorderLogFiles(logs);
        //     Console.WriteLine($"{Utility.PrintArray<string>(logs)} => {Utility.PrintArray<string>(result)}");
        // }
    }
}