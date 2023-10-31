using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class RemoveNthNodeFromEnd
    {
        public void RunSolution()
        {
            Node n0 = new Node(0);
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);
            Node n9 = new Node(9);
            n0.Next = n1;
            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;
            n4.Next = n5;
            n5.Next = n6;
            n6.Next = n7;
            n7.Next = n8;
            n8.Next = n9;

            var head = removeNthNodeFromEnd1(n0, 4);
        }

        private Node removeNthNodeFromEnd1(Node head, int n)
        {
            int counter = 1;
            var first = head;
            var secount = head;
            while (counter <= n)
            {
                secount = secount.Next;
                counter++;
            }

            if (secount == head)// head
            {
                head.Value = head.Next.Value;
                head.Next = head.Next.Next;
            }
            while (secount.Next != null)
            {
                secount = secount.Next;
                first = first.Next;
            }
            first.Next = first.Next.Next;
            return head;
        }

        private Node removeNthNodeFromEnd(Node head, int n)
        {
            var firstPoint = head;
            var secountPointer = head;
            var previousNode = head;
            for (int i = 0; i < n; i++)
            {
                secountPointer = secountPointer.Next;
            }

            while (secountPointer != null)
            {
                previousNode = firstPoint;
                secountPointer = secountPointer.Next;
                firstPoint = firstPoint.Next;
            }

            if (previousNode == head)// head
            {
                head = previousNode.Next;
                head = null;
            }
            else
            {
                var nodeToRemove = previousNode.Next;
                previousNode.Next = previousNode.Next.Next;
                nodeToRemove.Next = null;
            }

            return head;
        }
        private Node GetRemoveNthNodeFromEnd(Node n0, int nthLastValue)
        {
            var currentNode = n0;
            while (currentNode != null)
            {
                var nthNode = currentNode;
                for (var i = 0; i < nthLastValue + 1; i++)
                {
                    nthNode = nthNode.Next;
                }
                if (nthNode == null)
                {
                    currentNode.Next = currentNode.Next.Next; break;
                }
                currentNode = currentNode.Next;
            }
            return n0;
        }

        private Node GetRemoveNthNodeFromEnd2(Node n0, int nthLastValue)
        {
            int counter = 0;
            var currentNode = n0;
            while (currentNode != null)
            {
                counter++;
                currentNode = currentNode.Next;
            }
            currentNode = n0;
            for (var i = 0; i < counter - nthLastValue - 1; i++)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = currentNode.Next.Next;
            return n0;
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
