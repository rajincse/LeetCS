using System;
using Common;

namespace Problems
{
    public class ReverseListProblem
    {
        public ListNode ReverseList(ListNode head) {
            if(head == null)
            {
                return null;
            }
            else if(head.next == null)
            {
                return head;
            }
            else
            {
                ListNode tail = head.next;
                ListNode newHead = ReverseList(head.next);
                head.next = null;
                tail.next = head;

                return newHead;
            }
        }
        // public static void Main(string[] args)
        // {
        //     ListNode node = ListNode.CreateFromInt(new int[]{1,2,3, 4,5 });
        //     string input = node.ToString();
        //     var result = new ReverseListProblem().ReverseList(node);
        //     Console.WriteLine($"Input: {input} => {result}");
        // }
    }
}