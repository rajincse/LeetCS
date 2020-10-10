using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Common;

namespace Problems
{
    public class MostVisitedPatternProblem
    {
        public class VisitPattern : IComparable<VisitPattern>
        {
            public string Name {get;}
            public IList<string> List {get;}
            public HashSet<string> UserList {get; set;}
            public string Pattern {get;}
            public VisitPattern(IList<string> list)
            {   
                List = list;
                Pattern = string.Join(" ", list);
                UserList = new HashSet<string>();
            }

            public int CompareTo( VisitPattern other)
            {
                if(UserList.Count != other.UserList.Count)
                {
                    return  other.UserList.Count - UserList.Count;
                }
                else
                {
                    return string.Compare(Pattern, other.Pattern);
                }
                
            }
            public override string ToString()
            {
                return $"{{{Pattern},{UserList.Count}}}";
            }
        }
        public class VisitTime : IComparable<VisitTime>
        {
            public string Name {get;}
            public string Website {get;}

            public int Timestamp {get;}

            public VisitTime(string name, string website, int timestamp)
            {
                Name = name;
                Website = website;
                Timestamp = timestamp;
            }

            public int CompareTo(VisitTime other)
            {
                return Timestamp - other.Timestamp;
            }

            public override string ToString()
            {
                return $"{{{Name},{Website}, {Timestamp}}}";
            }
        }
        public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website) {
            if(username == null || username.Length ==0 ||
             timestamp == null || timestamp.Length != username.Length ||
              website == null || website.Length != username.Length)
            {
                return null;
            }
            
            List<VisitTime> visitTimes = new List<VisitTime>();
            for(int i=0;i< username.Length;i++)
            {
                visitTimes.Add ( new VisitTime(username[i], website[i], timestamp[i]));
            }
            visitTimes.Sort();

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();            
            foreach(var visitTime in visitTimes)
            {
                if(!map.ContainsKey(visitTime.Name))
                {
                    map[visitTime.Name] = new List<string>();
                }
                map[visitTime.Name].Add(visitTime.Website);
            }

            Dictionary<string, VisitPattern> visitPatternMap = new Dictionary<string, VisitPattern>();
            foreach(var name in map.Keys)
            {
                var allVisitsList = map[name];
                string[] allVisitArray = allVisitsList.ToArray();
                IList<IList<string>> patternList = Generate3VisitPatterns(allVisitArray);
                if(patternList != null)
                {
                    foreach(var pattern in patternList)
                    {
                        var visitPattern = new VisitPattern(pattern);
                        if(!visitPatternMap.ContainsKey(visitPattern.Pattern))
                        {
                            visitPatternMap[visitPattern.Pattern] = visitPattern;
                        }
                        visitPatternMap[visitPattern.Pattern].UserList.Add(name);
                    }
                }
                
            }
            List<VisitPattern> allVisitPatterns = new List<VisitPattern>();
            foreach(var key in visitPatternMap.Keys)
            {
                allVisitPatterns.Add(visitPatternMap[key]);
            }
            allVisitPatterns.Sort();

            return allVisitPatterns.First().List;
        }

        public IList<IList<string>> Generate3VisitPatterns(string[] allVisits)
        {   
            if(allVisits == null || allVisits.Length < 3)
            {
                return null;
            }
            IList<IList<string>> patternList = new List<IList<string>>();
            if(allVisits.Length == 3)
            {
                patternList.Add(allVisits);
                return patternList;
            }
            
            Dfs(patternList, new List<string>(), 0, allVisits);
            return patternList;
        }

        private void Dfs(IList<IList<string>> allPatterns, IList<string> currentPattern, int startIndex,  string[] allVisits)
        {
            if(allPatterns == null )
            {
                return ;
            }

            if(currentPattern.Count == 3)
            {
                var list = new List<string>();
                list.AddRange(currentPattern);
                allPatterns.Add(list);
                return;
            }

            
            for(int i=startIndex;i< allVisits.Length;i++)
            {                
                currentPattern.Add(allVisits[i]);
                Dfs(allPatterns, currentPattern, i+1 , allVisits);
                currentPattern.RemoveAt(currentPattern.Count-1);
            }
            
        }
        // public static void Main(string[] args)
        // {
        //     var usernames = new string[]{"him","mxcmo","jejuvvtye","wphmqzn","uwlblbrkqv","flntc","esdtyvfs","nig","jejuvvtye","nig","mxcmo","flntc","nig","jejuvvtye","odmspeq","jiufvjy","esdtyvfs","mfieoxff","nig","flntc","mxcmo","qxbrmo"};
        //     var timestamp = new int[]{113355592,304993712,80831183,751306572,34485202,414560488,667775008,951168362,794457022,813255204,922111713,127547164,906590066,685654550,430221607,699844334,358754380,301537469,561750506,612256123,396990840,60109482};
        //     var website  = new string[]{"k","o","o","nxpvmh","dssdnkv","kiuorlwdcw","twwginujc","evenodb","qqlw","mhpzoaiw","jukowcnnaz","m","ep","qn","wxeffbcy","ggwzd","tawp","gxm","pop","xipfkhac","weiujzjcy","x"};

        //     var result = new MostVisitedPatternProblem().MostVisitedPattern(usernames, timestamp, website);
        //     Console.WriteLine($"{Utility.PrintArray<string>(usernames)}\n{Utility.PrintArray<int>(timestamp)}\n{Utility.PrintArray<string>(website)}");
        //     Console.WriteLine($"\n=>{Utility.PrintList<string>(result)}");
        // }
    }
}