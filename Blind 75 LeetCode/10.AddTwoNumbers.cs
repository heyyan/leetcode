using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class AddTwoNumbers
    {
        //you are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and 
        // each of their nodes contain a single digit. Add the two numbers and return it as a linked list
        // you may assume the two number do not contain any leading zero, ecpect the number 0 itself
        //input (2->4->3) + (5->6->4)
        //output 7->0->8
        //explanaation 342 + 465 = 807

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public void RunSolution()
        {
            ListNode l1 = new ListNode(2);
            ListNode l2 = new ListNode(4);
            ListNode l3 = new ListNode(3);
            l1.next = l2;
            l2.next = l3;

            ListNode l4 = new ListNode(5);
            ListNode l5 = new ListNode(6);
            ListNode l6 = new ListNode(4);
            l4.next = l5;
            l5.next = l6;

            var result = GetAddTwoNumbers(l1, l4);
        }

        private ListNode GetAddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode cur = dummy;
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int v1 = l1.val != 0 ? l1.val : 0;
                int v2 = l2.val != 0 ? l2.val : 0;

                int val = v1 + v2 + carry;
                carry = val / 10;
                val = val % 10;
                cur.next = new ListNode(val);
                cur = cur.next;
                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }
            return dummy.next;
        }
    }




}
