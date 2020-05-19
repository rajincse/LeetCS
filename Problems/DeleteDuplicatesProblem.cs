using System;
using Common;

namespace Problems{
    public class DeleteDuplicatesProblem{

        public ListNode DeleteDuplicates(ListNode head) {
            if(head == null)
            {
                return head;
            }
            //move the head to appropriate position
            int currentVal = head.val;
            if(head.next != null && head.next.val == currentVal)
            {
                while(head != null && head.val == currentVal)
                {
                    head = head.next;
                }
                head = DeleteDuplicates(head);
            }
            else
            {
                head.next = DeleteDuplicates(head.next);
            }

            
            return head;
        }
        public ListNode DeleteDuplicatesKeep(ListNode head) {
            if(head == null)
            {
                return head;
            }

            ListNode movingNode = head.next;
            ListNode previousNode = head;
            int previousValue = head.val;
            while(movingNode != null)
            {
               if(previousValue == movingNode.val)
               {
                   previousNode.next = movingNode.next; 
               }
               else
               {
                   previousNode = movingNode;
                   previousValue = previousNode.val;
               }
               movingNode = movingNode.next;
            }

            return  head;
        }
        // public static void Main(string[] args)
        // {
        //     int [] input = new int[]{1,2,3};
        //     ListNode head = ListNode.CreateFromInt(input);
        //     Console.WriteLine($" Before: : {head}");
        //     ListNode result = new DeleteDuplicatesProblem().DeleteDuplicates(head);
        //     Console.WriteLine($" After: : {result}");
        // }
    }
}