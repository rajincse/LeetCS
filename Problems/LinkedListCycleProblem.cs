using System;
using Common;

namespace Problems
{
    public class LinkedListCycleProblem
    {
        public bool HasCycle(ListNode head) {
            if(head == null)
            {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head;

            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
        // public static void Main(string[] args)
        // {
        //     ListNode node1 = new ListNode(3);
        //     ListNode node2 = new ListNode(2);
        //     ListNode node3 = new ListNode(0);
        //     ListNode node4 = new ListNode(-4);
        //     node1.next = node2;
        //     node2.next = node3;
        //     node3.next = node4;
        //     node4.next = node2;
        //     var result = new LinkedListCycleProblem().HasCycle(node1);
        //     Console.WriteLine($"Input: {node1} => {result}");
        // }
    }
}