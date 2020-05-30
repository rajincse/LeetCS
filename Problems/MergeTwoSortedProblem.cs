using System;
using Common;

namespace Problems
{
    public class MergeTwoSortedProblem{
        public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
            if(l1 == null && l2 == null)
            {
                return null;
            }
            ListNode iterator1 = l1;
            ListNode iterator2 = l2;
            ListNode result = null;
            ListNode resultTail = null;
            while(iterator1 != null && iterator2 != null)
            {
                if(iterator1.val < iterator2.val)
                {
                   (iterator1, result, resultTail) = SpliceNode(iterator1, result, resultTail);
                }
                else
                {
                    (iterator2, result, resultTail) = SpliceNode(iterator2, result, resultTail);
                }

            }

            while(iterator1 != null)
            {
                (iterator1, result, resultTail) = SpliceNode(iterator1, result, resultTail);
            }

            while(iterator2 != null)
            {
                (iterator2, result, resultTail) = SpliceNode(iterator2, result, resultTail);
            }

            return result;
        }
        public (ListNode, ListNode, ListNode) SpliceNode(ListNode source, ListNode destinationHead, ListNode destinationTail)
        {
            if(destinationHead == null)
            {
                destinationHead = source;
                destinationTail = source;
            }
            else
            {
                destinationTail.next = source;
                destinationTail = source;
            }
            source = source.next;

            return (source, destinationHead, destinationTail);
        }
        // public static void Main(string[] args)
        // {
        //     ListNode l1 = ListNode.CreateFromInt(new int[]{1,2,4});
        //     string l1String = l1.ToString();
        //     ListNode l2 = ListNode.CreateFromInt(new int[]{1,3,4});
        //     string l2String = l2.ToString();
        //     ListNode result = new MergeTwoSortedProblem().MergeTwoLists(l1, l2);
        //     Console.WriteLine($"Input:{l1String}, {l2String} => {result}");
        // }
    }
}
