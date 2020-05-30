using System;
using Common;

namespace Problems
{
    public class RemoveNthNodeProblem
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
            (ListNode result, int index) = Remove(head, n);
            return result;
        }

        public (ListNode , int ) Remove(ListNode node, int removeIndex)
        {
            if(node == null)
            {
                return (null, 0);
            }

            (ListNode nextNode, int nextIndex) = Remove(node.next, removeIndex);
            int currentIndex = nextIndex+1;
            if(currentIndex == removeIndex)
            {
                return (nextNode, currentIndex);
            }
            else
            {
                node.next = nextNode;
                return (node, currentIndex);
            }
        }
        // public static void Main(string[] args)
        // {
        //     int[] inputArr = new int[]{1,2,3,4,5};
        //     ListNode input = ListNode.CreateFromInt(inputArr);
        //     int target = 5;
        //     string inputList = input.ToString();
        //     ListNode result = new RemoveNthNodeProblem().RemoveNthFromEnd(input, target);

        //     Console.WriteLine($"Input:{inputList}, {target} => {result}");
        // }
    }
}