using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.AlgoExpert.Medium.BinarySearchTreeConstruction;

namespace leetcode.AlgoExpert.Medium
{
    public class MinHeightBST
    {
        // create a bst with the min height
        //input [1,2,5,7,10,13,14,15,22]
        public void RunSolution()
        {
            //int x = GetHeight();
            var r = minHeightBST(new int[] { 1, 2, 5, 7, 10, 13, 14, 15, 22 });
        }

        private BinarySearchTree<int> minHightBst(int[] array)
        {
            return constructMinHeihtBst(array, null, 0, array.Length - 1);
        }

        private BinarySearchTree<int> constructMinHeihtBst(int[] array, BinarySearchTree<int> bst, int StartIdx, int EndIdx)
        {
            if (EndIdx < StartIdx)
            {
                return bst;
            }
            int midIdx = (StartIdx + EndIdx) / 2;
            int valueToAdd = array[midIdx];
            if (bst is null)
            {
                bst = new BinarySearchTree<int>(valueToAdd);
            }
            else
            {
                bst.Insetion(new Node<int>(valueToAdd));
            }
            constructMinHeihtBst(array, bst, StartIdx, midIdx - 1);
            constructMinHeihtBst(array, bst, midIdx + 1, EndIdx);
            return bst;
        }

        private BinarySearchTree<int> constructMinHeihtBst2(int[] array, BinarySearchTree<int> bst, int StartIdx, int EndIdx, Node<int> currentNode)
        {
            if (currentNode == null) { return bst; }
            if (EndIdx < StartIdx)
            {
                return bst;
            }
            int midIdx = (StartIdx + EndIdx) / 2;
            int valueToAdd = array[midIdx];
            Node<int> newBstNode = new Node<int>(valueToAdd);
            if (bst is null)
            {
                bst = new BinarySearchTree<int>(valueToAdd);
            }
            else
            {
                if (valueToAdd < currentNode.value)
                {
                    currentNode.Left = new Node<int>(valueToAdd);
                }
                else
                {
                    currentNode.Right = new Node<int>(valueToAdd);
                }
            }
            constructMinHeihtBst2(array, bst, StartIdx, midIdx - 1, currentNode.Left);
            constructMinHeihtBst2(array, bst, midIdx + 1, EndIdx, currentNode.Right);
            return bst;
        }

        private object minHeightBST(int[] array)
        {
            int mid = array.Length / 2;
            BinarySearchTree<int> bst = new(array[mid]);
            AddLeft(array, bst, 0, mid - 1);
            AddLeft(array, bst, mid + 1, array.Length - 1);

            //throw new NotImplementedException();
            return bst;
        }

        private void AddLeft(int[] array, BinarySearchTree<int> bst, int start, int end)
        {
            int mid = (end + start) / 2;
            if (mid >= 0)
            {
                bst.Insetion(new Node<int>(array[mid]));
                if (start != mid)
                {
                    AddLeft(array, bst, start, mid - 1);

                }
                if (end != mid)
                {
                    AddLeft(array, bst, mid + 1, end);
                }

            }
        }

        private object minHeightBST2(int[] array)
        {
            int mid = array.Length / 2;
            BinarySearchTree<int> bst = new(array[mid]);
            AddLeftNode(array, bst.Root, 0, mid - 1);
            AddRightNode(array, bst.Root, mid + 1, array.Length - 1);

            return bst;
        }

        private void AddLeftNode(int[] array, Node<int> root, int start, int end)
        {
            int mid = (end + start) / 2;
            if (mid >= 0)
            {
                var node = new Node<int>(array[mid]);
                root.Left = node;
                if (start != mid)
                {
                    AddLeftNode(array, node, start, mid - 1);

                }
                if (end != mid)
                {
                    AddRightNode(array, node, mid + 1, end);
                }

            }
        }

        private void AddRightNode(int[] array, Node<int> root, int start, int end)
        {
            int mid = (end + start) / 2;
            if (mid >= 0)
            {
                var node = new Node<int>(array[mid]);
                root.Right = node;
                if (start != mid)
                {
                    AddLeftNode(array, node, start, mid - 1);

                }
                if (end != mid)
                {
                    AddRightNode(array, node, mid + 1, end);
                }
            }
        }
        //private void AddRight(int[] array, BinarySearchTree<int> bst, int start, int end)
        //{

        //}

        private int GetHeight()
        {

            List<int> InOrder = new();
            List<int> PreOrder = new();
            List<int> PostOrder = new();
            var bst = new BinarySearchTree<int>(10);
            bst.Insetion(new Node<int>(2));
            bst.Insetion(new Node<int>(14));
            bst.Insetion(new Node<int>(1));
            bst.Insetion(new Node<int>(5));
            bst.Insetion(new Node<int>(7));
            bst.Insetion(new Node<int>(6));
            bst.Insetion(new Node<int>(13));
            bst.Insetion(new Node<int>(15));
            bst.Insetion(new Node<int>(22));
            //  bst.Insetion(new Node<int>(14));
            int height = 0;
            var r = GetHeightValue(bst.Root, height);
            return height;
        }

        private int GetHeightValue(Node<int> root, int height)
        {
            int max = 0;
            if (root == null) return height;
            height++;
            int leftHeiht = GetHeightValue(root.Left, height);
            int rightHeihgt = GetHeightValue(root.Right, height);
            max = Math.Max(leftHeiht, rightHeihgt);
            return max;
        }
    }
}
