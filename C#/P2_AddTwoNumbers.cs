using System;

namespace LeetCode;

public class P2_AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode head = new();

        ListNode current = head;
        ListNode? current1 = l1;
        ListNode? current2 = l2;
        int carry = 0;

        // Add from both lists
        while (current1 != null && current2 != null)
        {
            carry = Math.DivRem(current1.val + current2.val + carry, 10, out int digit);
            current.val = digit;

            current1 = current1.next;
            current2 = current2.next;

            if (current1 != null || current2 != null)
            {
                current.next = new ListNode();
                current = current.next;
            }
        }

        // If either list still has digits, add these as well
        ListNode? remaining = current1 ?? current2;

        while (remaining != null)
        {
            carry = Math.DivRem(remaining.val + carry, 10, out int digit);
            current.val = digit;

            remaining = remaining.next;

            if (remaining != null)
            {
                current.next = new ListNode();
                current = current.next;
            }
        }

        // If we still have a carry, add this as well
        if (carry > 0)
        {
            current.next = new ListNode(carry);
        }

        return head;
    }
}
