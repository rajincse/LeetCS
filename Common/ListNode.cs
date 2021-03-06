using System.Text;

namespace Common
{
    public class ListNode{
        public int val;
        public ListNode next;
        public ListNode(int x){
            val =x;                        
            next = null;
        }
        private static void BuildStringValue(ListNode node, StringBuilder sb){
            if(node == null)
            {
                return;
            }
            if(sb.Length > 0)
            {
                sb.Append("->");
            }
            sb.Append(node.val);
            BuildStringValue(node.next, sb);
        }
        public static ListNode CreateFromInt(int[] input)
        {
            ListNode head = new ListNode(input[0]);
            ListNode  node = head;
            for(int i=1;i<input.Length;i++)
            {
                ListNode tempNode = new ListNode(input[i]);
                node.next = tempNode;
                node = node.next;
            }
            return head;
        }
        public override string ToString()
        {
            if(HasCycle(this))
            {
                return $"{this.val} (Contains Cycle)";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                BuildStringValue(this, sb);
                return sb.ToString();
            }
            
        }
        private bool HasCycle(ListNode head) {
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
    }
    
    
}