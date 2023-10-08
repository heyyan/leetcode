using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.AlgoExpert.Medium.BinarySearchTreeConstruction;

namespace leetcode.AlgoExpert.Medium
{
    public class FindSuccessor
    {
        public void RunSolution()
        {
            SuccessorNode root1 = new(1);
            SuccessorNode root2 = new(2);
            SuccessorNode root3 = new(3);
            SuccessorNode root4 = new(4);
            SuccessorNode root5 = new(5);
            SuccessorNode root6 = new(6);

            root2.Parent = root1;
            root3.Parent = root1;
            root4.Parent = root2;
            root5.Parent = root2;
            root6.Parent = root4;

            root1.Left = root2;
            root1.Right = root3;
            root2.Left = root4;
            root2.Right = root5;
            root4.Left = root6;
           // var rest = GetSuccor(root1, 5);
            var rest = findSuccooorr(root5);
        }

        private SuccessorNode findSuccooorr(SuccessorNode node)
        {
            if(node.Right != null)
            {
                return GetLeftMostChild(node.Right);
            }
            return GetRightMostParent(node);
        }

        private SuccessorNode GetRightMostParent(SuccessorNode node)
        {
            var currentNode = node;
            while (currentNode.Parent != null && currentNode.Parent.Right == currentNode)
            {
                currentNode = currentNode.Parent;
            }
            return currentNode.Parent;
        }

        private SuccessorNode GetLeftMostChild(SuccessorNode node)
        {
            var currentNode = node;
            while(currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }
            return currentNode;
        }

        private object GetSuccor(SuccessorNode node, int succorOf)
        {
            List<int> inOrder = new List<int>();
            findSuccessor(node, inOrder);
            for (int i = 0; i < inOrder.Count - 1; i++)
            {
                if (inOrder[i] == succorOf)
                {
                    return inOrder[i + 1];
                }
            }
            return -1;
        }

        private void findSuccessor(SuccessorNode node, List<int> inOrder)
        {
            if (node == null) return;
            findSuccessor(node.Left, inOrder);
            inOrder.Add(node.value);
            findSuccessor(node.Right, inOrder);

        }
    }

    internal class SuccessorNode
    {
        public SuccessorNode(int value)
        {
            this.value = value;
            Parent = null;
            Right = null;
            Left = null;
        }
        public int value { get; set; }
        public SuccessorNode Parent { get; set; }
        public SuccessorNode Right { get; set; }
        public SuccessorNode Left { get; set; }
    }
}
