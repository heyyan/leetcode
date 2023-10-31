using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class SumOfLinkedLists
    {
        // ll1: 2 -> 4 -> 7 -> 1
        // ll2: 9 -> 4 -> 5
        //output 
        // 1 -> 9 -> 2 -> 2
        // 1742
        // +549
        //------
        // 2291 (backwards)
        public void RunSolution()
        {
            Node head1 = new Node(2);
            Node n1 = new Node(4);
            Node n2 = new Node(7);
            Node n3 = new Node(1);

            head1.Next = n1;
            n1.Next = n2;
            n2.Next = n3;

            Node head2 = new Node(9);
            Node n8 = new Node(4);
            Node n9 = new Node(5);

            head2.Next = n8;
            n8.Next = n9;

            var head = GetSumOfLinkedLists3(head1, head2);
        }

        private object GetSumOfLinkedLists3(Node linkedListOne, Node linkedListTwo)
        {
            Node newLinkedListHeaderPointer = new Node(0);
            var currentNode = newLinkedListHeaderPointer;
            int carry = 0;
            var NodeOne = linkedListOne;
            var NodeTwo = linkedListTwo;

            while (NodeOne != null || NodeTwo != null || carry != 0)
            {
                int valueOne = NodeOne != null ? NodeOne.Value : 0;
                int valueTwo = NodeTwo != null ? NodeTwo.Value : 0;
                int sumOfValues = valueOne + valueTwo + carry;

                int newValue = sumOfValues % 10;
                var newNode = new Node(newValue);
                currentNode.Next = newNode;
                currentNode = newNode;

                carry = sumOfValues / 10;
                NodeOne = NodeOne != null ? NodeOne.Next : null;
                NodeTwo = NodeTwo != null ? NodeTwo.Next : null;
            }

            return newLinkedListHeaderPointer.Next;
        }
        private object GetSumOfLinkedLists2(Node head1, Node head2)
        {
            var h1 = head1;
            var h2 = head2;
            Node head = null;
            Node currentNode = null;
            while (h1 != null || h2 != null)
            {
                int n1 = 0;
                int n2 = 0;
                int carry = 0;
                if (h1 != null)
                {
                    n1 = h1.Value;
                }
                if (h2 != null)
                {
                    n2 = h2.Value;
                }
                int sum = n1 + n2 + carry;
                carry = sum / 10;
                int newVal = sum % 10;

                if (head == null)
                {
                    head = new Node(newVal);
                    head.Next = currentNode;
                }
                else
                {
                    var newNode = new Node(newVal);
                    if (currentNode == null)
                    {
                        currentNode = newNode;
                    }
                    else
                    {
                        currentNode.Next = newNode;
                    }

                    currentNode = currentNode.Next;
                }
                if (h1 != null)
                {
                    h1 = h1.Next;
                }
                if (h2 != null)
                {
                    h2 = h2.Next;
                }
            }
            return head;
        }

        private object GetSumOfLinkedLists(Node head1, Node head2)
        {
            int num1 = ConvertToNumber(head1);
            int num2 = ConvertToNumber(head2);
            int sum = num1 + num2;
            var node = GetNewLinkList(sum);
            return null;
        }

        private Node GetNewLinkList(int sum)
        {
            int val = sum;
            List<Node> list = new List<Node>();
            while (val > 0)
            {
                list.Add(new Node(val % 10));
                val = val / 10;
            }
            Node Head = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                list[i - 1].Next = list[i];
            }
            return Head;
        }

        private int ConvertToNumber(Node head)
        {
            int sum = 0;
            int unit = 1;
            var currentNode = head;
            while (currentNode != null)
            {
                sum += currentNode.Value * unit;
                unit *= 10;
                currentNode = currentNode.Next;
            }
            return sum;
        }

        internal class Node
        {
            public Node(int val)
            {
                Value = val;
            }
            public int Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
