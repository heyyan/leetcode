using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class LinkedListConstruction
    {
        // 
        public void RunSolution()
        {
            MinHeap heap = new MinHeap(new int[] { 8, 12, 23, 17, 31, 30, 44, 102, 18 });
            var r = heap.Heap;
        }
    }

    public class DoublyLinkedList
    {
        public LNode Head { get; set; }
        public LNode Tail { get; set; }

        public LNode Search(int value)
        {
            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            return null;
        }

        public void RemoveNode(LNode node)
        {
            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode == node)
                {

                    var prevousNode = currentNode.Previous;
                    var nextNode = currentNode.Next;
                    prevousNode.Next = nextNode;
                    nextNode.Previous = prevousNode;
                    if (currentNode == Head)
                    {
                        Head = nextNode;
                    }
                    if (currentNode == Tail)
                    {
                        Tail = prevousNode;
                    }
                    currentNode.Previous = null;
                    currentNode.Next = null;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }

        public void RemoveNodeWithValue(int value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    var nextNode = currentNode.Next;
                    RemoveNode(currentNode);
                    currentNode = nextNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
        }

        public void InsertBefore(LNode node, LNode newNode)
        {
            if (node == Head)
            {
                newNode.Next = node;
                node.Previous = newNode;
                Head = newNode;
                return;
            }
            var preiouseNode = node.Previous;
            preiouseNode.Next = newNode;
            newNode.Previous = preiouseNode;
            newNode.Next = node;
            node.Previous = newNode;
        }

        public void InsertAfter(LNode node, LNode newNode)
        {
            if (node == Tail)
            {
                node.Next = newNode;
                newNode.Previous = node;
                Tail = newNode;
                return;
            }
            var nextNode = node.Next;
            node.Next = newNode;
            newNode.Previous = node;
            newNode.Next = nextNode;
            nextNode.Previous = newNode;
        }

        public void SetHead(LNode head)
        {
            if (this.Head == null)
            {
                this.Head = head;
                this.Tail = head;
                return;
            }
            InsertBefore(this.Head, head);
        }

        public void SetTail(LNode tail)
        {
            if (this.Tail == null)
            {
                SetHead(tail);
                return;
            }
            InsertAfter(this.Tail, tail);
        }
    }
    public class LNode
    {
        public int Value { get; set; }
        public LNode Previous { get; set; }
        public LNode Next { get; set; }
    }


    public class DoublyLinkedList2
    {
        public LNode Head { get; set; }
        public LNode Tail { get; set; }

        public void SetHead(LNode node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            InsertBefore(Head, node);
        }

        public void SetTail(LNode node)
        {
            if (Tail == null)
            {
                SetHead(node);
                return;
            }
            InsertAfter(Tail, node);
        }

        public void InsertBefore(LNode node, LNode nodeToInsert)
        {
            if (nodeToInsert == Head && nodeToInsert == Tail)
            {
                return;
            }

            Remove(nodeToInsert);
            nodeToInsert.Previous = node.Previous;
            nodeToInsert.Next = node;
            if (node.Previous == null)
            {
                Head = nodeToInsert;
            }
            else
            {
                node.Previous.Next = nodeToInsert;
            }

            node.Previous = nodeToInsert;
        }

        public void InsertAfter(LNode node, LNode nodeToInsert)
        {
            if (nodeToInsert == Head && nodeToInsert == Tail)
            {
                return;
            }

            Remove(nodeToInsert);
            nodeToInsert.Next = node.Next;
            nodeToInsert.Previous = node;
            if (node.Next == null)
            {
                Tail = nodeToInsert;
            }
            else
            {
                node.Next.Previous = nodeToInsert;
            }

            node.Next = nodeToInsert;
        }

        public void InsertAtPosition(int position, LNode nodeToInsert)
        {
            if (position == 1)
            {
                SetHead(nodeToInsert);
                return;
            }
            var node = Head;
            var currentPosition = 1;
            while (node != null && currentPosition != position)
            {
                node = node.Next;
                currentPosition++;
            }

            if (node != null)
            {
                InsertBefore(node, nodeToInsert);
            }
            else
            {
                SetTail(nodeToInsert);
            }
        }

        public void RemoveNodesWithValue(int value)
        {
            var node = Head;
            while (node != null)
            {
                var nodeToRemove = node;
                node = node.Next;
                if (nodeToRemove.Value == value)
                {
                    Remove(nodeToRemove);
                    break;
                }
            }
        }

        public void Remove(LNode node)
        {
            if (this.Head == node)
            {
                Head = Head.Next;
            }
            if (Tail == node)
            {
                Tail = Tail.Previous;
            }
            RemoveNodeBinding(node);
        }

        public bool ContainsNodeWithValue(int value)
        {
            var node = Head;
            while (node != null && node.Value != value)
            {
                node = node.Next;
            }
            return node != null;
        }

        private void RemoveNodeBinding(LNode node)
        {
            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
            node.Previous = null;
            node.Next = null;
        }
    }
}
