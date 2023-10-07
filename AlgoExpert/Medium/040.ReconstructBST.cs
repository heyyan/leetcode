using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.AlgoExpert.Medium.BinarySearchTreeConstruction;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcode.AlgoExpert.Medium
{
    public class ReconstructBST
    {
        public void RunSolution()
        {
            // var r = GetReconstructBST(new int[] { 10, 4, 2, 1, 5, 17, 19, 18 });
            var re = reBst(new int[] { 10, 4, 2, 1, 5, 17, 19, 18 });
        }


        private Node<int> reBst(int[] array)
        {
            int inf0 = 0;
            return ReconstructBSTFromRange(int.MinValue, int.MaxValue, array, ref inf0);
        }

        private Node<int> ReconstructBSTFromRange(int lowerBound, int upperBound, int[] array, ref int inf0)
        {
            if (inf0 == array.Length)
            {
                return null;
            }
            int rootValue = array[inf0];
            if (rootValue < lowerBound || rootValue >= upperBound)
            {
                return null;
            }
            inf0++;
            var leftSubtree = ReconstructBSTFromRange(lowerBound, rootValue, array, ref inf0); 
            var rightSubtree = ReconstructBSTFromRange(rootValue, upperBound, array, ref inf0);

            Node<int> root = new Node<int>(rootValue);
            root.Left = leftSubtree;
            root.Right = rightSubtree;
            return root;
        }

        private Node<int> reconstruntBTS(int[] preOrderTraversalValues)
        {
            if (preOrderTraversalValues.Length == 0)
            {
                return null;
            }

            int currentValue = preOrderTraversalValues[0];
            int rightSubtreeRootIdx = preOrderTraversalValues.Length;
            for (int i = 1; i < preOrderTraversalValues.Length; i++)
            {
                if (preOrderTraversalValues[i] > currentValue)
                {
                    rightSubtreeRootIdx = i;
                    break;
                }
            }

            var leftSubtree = reconstruntBTS(preOrderTraversalValues[1..rightSubtreeRootIdx]);
            var rightSubtree = reconstruntBTS(preOrderTraversalValues[rightSubtreeRootIdx..]);

            Node<int> rootNode = new Node<int>(currentValue);
            rootNode.Left = leftSubtree;
            rootNode.Right = rightSubtree;
            return rootNode;
        }


        private Node<int> reBts(int[] array)
        {
            if (array.Length == 0)
            { return null; }

            int currentValue = array[0];
            int endIndex = array.Length;
            int startIdx = 0;
            int endIdx = array.Length;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > currentValue)
                {
                    endIdx = i;
                    break;
                }
            }

            var leftNode = reBts(array[1..endIdx]);
            var rightNode = reBts(array[endIdx..]);

            var node = new Node<int>(currentValue);
            node.Left = leftNode;
            node.Right = rightNode;
            return node;


        }
        private object GetReconstructBST(int[] array)
        {
            Node<int> root = new(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                AddToBST(array[i], root);
            }
            return root;
            // left side find midpoint and add
            // right side find midpoint and add
        }

        private void AddToBST(int cal, Node<int> root)
        {
            var newNode = new Node<int>(cal);
            var currentNode = root;
            while (currentNode != null)
            {
                if (cal < currentNode.value)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }

                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
            }
        }
    }
}
