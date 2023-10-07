using leetcode.AlgoExpert.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.AlgoExpert.Medium.BinarySearchTreeConstruction;

namespace leetcode.AlgoExpert.Medium
{
    public class FindKthLargestValueInBST
    {
        public void RunSolution()
        {
            List<int> InOrder = new();
            var bst = new BinarySearchTree<int>(15);
            bst.Insetion(new Node<int>(5));
            bst.Insetion(new Node<int>(5));
            bst.Insetion(new Node<int>(2));
            bst.Insetion(new Node<int>(3));
            bst.Insetion(new Node<int>(1));
            bst.Insetion(new Node<int>(20));
            bst.Insetion(new Node<int>(17));
            bst.Insetion(new Node<int>(22));
            //var r = findKthLargestValueInBSTReverse(bst, InOrder, 3);
            var r = findKthLargestValueInBST2Variable(bst, 3);
        }

        private int findKthLargestValueInBST(BinarySearchTree<int> bst, List<int> inOrder, int k)
        {
            DFS(bst.Root, inOrder);
            return inOrder[inOrder.Count - k];
        }

        private void DFS(Node<int> node, List<int> inOrder)
        {
            if (node == null) return;
            DFS(node.Left, inOrder);
            inOrder.Add(node.value);
            DFS(node.Right, inOrder);
        }

        private int findKthLargestValueInBSTReverse(BinarySearchTree<int> bst, List<int> inOrder, int k)
        {
            DFSReverse(bst.Root, inOrder, k);
            return inOrder[k - 1];
        }
        private void DFSReverse(Node<int> node, List<int> inOrder, int kth)
        {
            if (node == null) return;

            DFSReverse(node.Right, inOrder, kth);
            if (kth <= inOrder.Count)
            {
                return;
            }
            else
            {
                inOrder.Add(node.value);
            }
            DFSReverse(node.Left, inOrder, kth);
        }

        private int findKthLargestValueInBST2Variable(BinarySearchTree<int> bst, int k)
        {
            int visited = 0;
           // var lastValue = DFSReverse2Variable(bst.Root, k, ref visited, 0);
            var lastValue = DFSReverse2Variable2(bst.Root, k, ref visited, 0);
            return lastValue;
        }
        private int DFSReverse2Variable(Node<int> node, int kth, ref int visited, int lastvalue)
        {
            if (node == null) return lastvalue;
            lastvalue = DFSReverse2Variable(node.Right, kth, ref visited, lastvalue);

            if (kth <= visited)
            {
                return lastvalue;
            }
            else
            {
                visited++;
                lastvalue = node.value;
            }
            lastvalue = DFSReverse2Variable(node.Left, kth, ref visited, lastvalue);
            return lastvalue;
        }

        private int DFSReverse2Variable2(Node<int> node, int kth, ref int visited, int lastvalue)
        {
            if (node == null && kth >= visited) return lastvalue;
         
            lastvalue = DFSReverse2Variable2(node.Right, kth, ref visited, lastvalue);
            if (visited < kth )
            {
                visited++;
                lastvalue = node.value;
                lastvalue = DFSReverse2Variable2(node.Left, kth, ref visited, lastvalue);
            }
            return lastvalue;
        }

    }
}
