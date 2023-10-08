using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.AlgoExpert.Medium.BinarySearchTreeConstruction;

namespace leetcode.AlgoExpert.Medium
{
    public class InvertBinaryTree
    {
        public void RunSolution()
        {
            Node<int> root1 = new(1);
            Node<int> root2 = new(2);
            Node<int> root3 = new(3);
            Node<int> root4 = new(4);
            Node<int> root5 = new(5);
            Node<int> root6 = new(6);
            Node<int> root7 = new(7);
            Node<int> root8 = new(8);
            Node<int> root9 = new(9);
            Node<int> root10 = new(10);
            root1.Left = root2;
            root1.Right = root3;
            root2.Left = root4;
            root2.Right = root5;
            root3.Left = root6;
            root3.Right = root7;
            root4.Left = root8;
            root4.Right = root9;
            root5.Left = root10;
            bstSwap(root1);
        }

        private Node<int> invertBinaryTree(Node<int> bst)
        {
            bstSwap(bst);
            return bst;
        }

        private Node<int> bstSwap(Node<int> node)
        {
            if (node == null) return null;
            var leftResult = bstSwap(node.Left);
            var rightReult = bstSwap(node.Right);
            node.Left = rightReult;
            node.Right = leftResult;
            return node;

        }

        private Node<int> BFS(Node<int> node)
        {
            Queue<Node<int>> queue = new();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var n = queue.Dequeue();
                var temp = n.Left;
                n.Left = n.Right;
                n.Right = temp;

                if (n.Left != null)
                {
                    queue.Enqueue(n.Left);
                }
                if (n.Right != null)
                {
                    queue.Enqueue(n.Right);
                }

            }
            return node;
        }
    }
}
