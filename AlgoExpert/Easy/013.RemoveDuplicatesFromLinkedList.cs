using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class RemoveDuplicatesFromLinkedList
    {
        public void RunSolution()
        {
            var RootNode = new Node<int>(1);
            var one = new Node<int>(1);
            var three = new Node<int>(3);
            var four = new Node<int>(4);
            var four1 = new Node<int>(4);
            var four2 = new Node<int>(4);
            var five = new Node<int>(5);
            var six = new Node<int>(6);
            var six1 = new Node<int>(6);

            RootNode.Next = one;
            one.Next = three;
            three.Next = four;
            four.Next = four1;
            four1.Next = four2;
            four2.Next = five;
            five.Next = six;
            six.Next = six1;
            var r = GetRemoveDuplicatesFromLinkedList(RootNode);
        }

        private Node<int> GetRemoveDuplicatesFromLinkedList(Node<int> root)
        {
            var currentNode = root;
            while (currentNode.Next != null)
            {
                if(currentNode.Value == currentNode.Next.Value)
                {
                    currentNode.Next = currentNode.Next.Next;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
               
            }
            return root;
        }

        private Node<int> GetRemoveDuplicatesFromLinkedList2(Node<int> linkedList)
        {
            var currentNode = linkedList;
            while (currentNode != null)
            {
                var nextDistinctNode = currentNode.Next;
                while (nextDistinctNode != null && nextDistinctNode.Value ==  currentNode.Value)
                {
                    nextDistinctNode = nextDistinctNode.Next;
                }
                currentNode.Next = nextDistinctNode;
                currentNode = nextDistinctNode;
            }
            return linkedList;
        }

        public class Node<T>
        {
            public T Value { get; set; }
            public Node(T value) { Value = value; }
            public Node<T> Next { get; set; }
        }
    }
}
