using System;
using Common;

namespace Problems
{
    public class MergeKListProblem
    {
        public ListNode MergeKLists(ListNode[] lists) {
            ListNode head = null;                      
            (lists, head) = GetMinNode(lists);
            if(head == null){
                return null;
            }
            ListNode tail = head;
            ListNode minNode = null;
            while(tail != null)
            {
                (lists, minNode) = GetMinNode(lists);
                tail.next = minNode;
                tail = tail.next;
            }
            return head;
        }
        public (ListNode[], ListNode) GetMinNode(ListNode[] lists)
        {            
            if(lists == null || lists.Length ==0)
            {
                return (lists, null);
            }

            int minValue = int.MaxValue;
            int candidateIndex = -1;

            for(int i=0;i<lists.Length;i++)
            {
                if(lists[i] != null && lists[i].val <= minValue)
                {
                    candidateIndex = i;
                    minValue = lists[i].val;
                }
            }
            if(candidateIndex >=0)
            {
                ListNode minNode = lists[candidateIndex];
                lists[candidateIndex] = lists[candidateIndex].next;
                return (lists, minNode);
            }
            return (lists, null);
        }
        // public static void Main(string[] args)
        // {
        //     ListNode[] lists = new ListNode[]
        //     {
        //         ListNode.CreateFromInt(new int[]{1,4,5}),
        //         null,
        //         null,                
        //         ListNode.CreateFromInt(new int[]{1,3,4}),
        //         ListNode.CreateFromInt(new int[]{2,6}), 
        //         ListNode.CreateFromInt(new int[]{int.MinValue,int.MaxValue})
        //     };            
        //     string inputString = Utility.PrintArray<ListNode>(lists);
        //     ListNode result = new MergeKListProblem().MergeKLists(lists);

        //     Console.WriteLine($"Input:{inputString} => {result}");
        // }
    }
}