using System;
using Common;

namespace  Problems
{
    public class AddTwoNumbersProblem
    {
        public ListNode AddTwoNumbers(ListNode l1,
                                      ListNode l2) {
            return AddTwoNumbers(l1, l2, 0);
        }
        
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry) {
            if(l1 == null && l2 == null && carry == 0)
            {
                return null;
            }
            
            
            int sum = (l1 == null? 0: l1.val)
                    + (l2 == null? 0 : l2.val )
                    + carry;
            int digit = sum %10;
            int newCarry = sum /10;
            ListNode result = new ListNode(digit);
            result.next = AddTwoNumbers(l1 == null? null: l1.next,
                                        l2 == null? null : l2.next , newCarry);
            
            return result;
        }

        // public static void Main(string [] args)
        // {
        //     ListNode l1 = ListNode.CreateFromInt(new int[]{9,9,9});
        //     ListNode l2 = ListNode.CreateFromInt(new int[]{9,8});
        //     var result = new AddTwoNumbersProblem().AddTwoNumbers(l1, l2);
        //     Console.WriteLine($"{l1} + {l2} => {result}");
        // }
    }
}