using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Problems
{
    public class FindAndReplaceStringProblem
    {
        public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
            if(
                string.IsNullOrWhiteSpace(S) || indexes == null || indexes.Length == 0
                || sources == null || sources.Length == 0 || targets == null 
                || targets.Length == 0 || indexes.Length != sources.Length 
                || sources.Length != targets.Length
            )
            {
                return S;
            }
            Dictionary<int, int> replacementIndexMap = new Dictionary<int, int>();

            for(int i=0;i<indexes.Length;i++)
            {
                int index = indexes[i];
                string source = sources[i];
                string target = targets[i];
                if(IsReplaceable(S, index, source, target))
                {
                    replacementIndexMap[index] = i;
                }
            }
            StringBuilder sb = new StringBuilder();            
            List<int> replacementIndexList = new List<int>(replacementIndexMap.Keys);
            replacementIndexList.Sort();

            int lastIndex = 0;
            foreach(int currentIndex in replacementIndexList)
            {
                if(currentIndex> lastIndex)
                {
                    sb.Append(S.Substring(lastIndex, currentIndex - lastIndex));
                }
                int replaceIndex = replacementIndexMap[currentIndex];
                sb.Append(targets[replaceIndex]);
                lastIndex= currentIndex+ sources[replaceIndex].Length;
            }
            if(S.Length> lastIndex)
            {
                sb.Append(S.Substring(lastIndex, S.Length - lastIndex));
            }
            return sb.ToString();
        }
        private bool IsReplaceable(string original, int index, string source, string target)
        {
            if(
                string.IsNullOrWhiteSpace(original)|| index < 0 || index >= original.Length
                || string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target)
            )
            {
                return false;
            }
            string startingString = original.Substring(index);
            if(!startingString.StartsWith(source))
            {
                return false;
            }

            return true;
        }

        public static void Main(string[] args)
        {
            //"reauaqyxle"
            // [4,6,2]
            // ["aq","yxl","au"]
            // ["c","dh","ev"]
            var S = "reauaqyxle";
            var indexes = new int[] {4,6,2}; 
            var sources = new string[]{"aq","yxl","au"};
            var targets = new string[]{"c","dh","ev"};
            Console.WriteLine($"{S}, {Utility.PrintArray<int>(indexes)}, {Utility.PrintArray<string>(sources)}, {Utility.PrintArray<string>(targets)} => ");
            var result = new FindAndReplaceStringProblem().FindReplaceString(S, indexes, sources, targets);
            Console.WriteLine(result);
        }
    }
}