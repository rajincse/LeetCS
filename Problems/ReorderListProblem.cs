using System;
using Common;

namespace Problems
{
    public class ReorderListProblem
    {
        private ListNode forwardTail = null;
        private bool isEnough = false;
        private ListNode currentHead = null;
        public void ReorderList(ListNode head) {
            if(head == null)
            {
                return ;
            }
            forwardTail = head;
            ListNode processNode = head;
            currentHead = head;
            Process(processNode);
        }

        private void Process(ListNode node)
        {
            if(isEnough || node==null || node.next == null)
            {
                return ;
            }
            else
            {
                Process(node.next); 
                if(isEnough || forwardTail == null)
                {
                    return;
                }               
                
                if(forwardTail.next == node)
                {
                    isEnough = true;                    
                }

                ListNode nodeNext = node.next;
                node.next = null;
                ListNode forwardTailNext = forwardTail.next;
                forwardTail.next = nodeNext;
                nodeNext.next = forwardTailNext;
                forwardTail = forwardTailNext;                
            }
        }
        public static void Main(string[] args)
        {
            ListNode node = ListNode.CreateFromInt(new int[]{1,2,3,4,5,6,7,8,9 });
            string input = node.ToString();
            new ReorderListProblem().ReorderList(node);
            Console.WriteLine($"Input: {input} => {node}");
        }
    }
}