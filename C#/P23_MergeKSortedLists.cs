using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode;

public class P23_MergeKSortedLists
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

    public ListNode? MergeKLists(ListNode?[] lists)
    {
        // Runtime is O(mn), where m is the number of lists and n is the maximum linked list length
        // But no new ListNodes or intermediate lists were allocated, which I think was the main part of this challenge
        // Flattening the linked lists and sorting is simpler and most likely faster, but requires more memory

        // Find the head node with the minimum value, and use this as a starting point
        ListNode? head = null;
        int minimumIndex = 0;

        for (int i = 0; i < lists.Length; i++)
        {
            ListNode? list = lists[i];
            if (list != null && (head == null || list.val < head.val))
            {
                head = list;
                minimumIndex = i;
            }
        }

        // If there's no lists to merge, then just return an empty list
        if (head == null)
        {
            return null;
        }

        // Detach the head node from the list we took it from
        lists[minimumIndex] = head.next;
        head.next = null;

        // Repeat this process of finding the list with the minimum head value, until all lists are empty
        ListNode? current = head;
        ListNode? next;

        while (current != null)
        {
            next = null;

            // Find the next head node to use
            for (int i = 0; i < lists.Length; i++)
            {
                ListNode? list = lists[i];
                if (list != null && (next == null || list.val < next.val))
                {
                    next = list;
                    minimumIndex = i;
                }
            }

            // If we found a node to merge, detach it from it's list
            if (next != null)
            {
                lists[minimumIndex] = next.next;
                next.next = null;
            }

            // Update the current node being merged
            current.next = next;
            current = next;
        }

        return head;
    }
}
