using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.AlgoExpert.Medium.BinarySearchTreeConstruction;

namespace leetcode.AlgoExpert.Medium
{
    public class ValidateBinarySearchTree
    {
        public void RunSolution()
        {
            var bst = new BinarySearchTree<int>(10);
            bst.Insetion(new Node<int>(5));
            bst.Insetion(new Node<int>(15));
            bst.Insetion(new Node<int>(2));
            bst.Insetion(new Node<int>(5));
            bst.Insetion(new Node<int>(13));
            bst.Insetion(new Node<int>(22));
            bst.Insetion(new Node<int>(1));
            bst.Insetion(new Node<int>(14));
            var r = validateBinarySearchTree(bst);
        }

        private bool validateBinarySearchTree(BinarySearchTree<int> bst)
        {
            // this can be done with a depth frist search or a breath first search
            //BFS(bst.Root);
            validateBst(bst);
            return true;
        }

        private void validateBst(BinarySearchTree<int> bst)
        {
            validateBstHelper(bst.Root, int.MinValue, int.MaxValue);
        }
        private bool validateBstHelper(Node<int> node, int min, int max)
        {
            if (node == null)
                return true;

            if (node.value < min || node.value >= max)
            {
                return false;
            }

            bool leftIsValid = validateBstHelper(node.Left, min, node.value);
            bool rightIsValid = validateBstHelper(node.Right, node.value, max);
            return leftIsValid && rightIsValid;

        }

        private bool DFS(Node<int> node)
        {

            if (node == null) return true;
            if (node.Left == null && node.Right == null)
            {
                return true;
            }
            // check node value is greate then left and right value
            if (node.Left != null && node.Right != null)
            {
                if (node.value >= node.Right.value && node.value < node.Left.value)
                {
                    return false;
                }
                if (node.Right.value < node.Left.value)
                {
                    return false;
                }
            }
            // check if right value is greate then left value
            //  if(node.value < node.Left?.value)
            var leftResult = DFS(node.Left);
            var rightResult = DFS(node.Right);

            return leftResult && rightResult;
        }

        private bool BFS(Node<int> node)
        {
            Queue<Node<int>> queue = new();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var n = queue.Dequeue();
                if (n.Left != null && n.Right != null)
                {
                    if (n.value >= n.Right.value && n.value < n.Left.value)
                    {
                        return false;
                    }
                    if (n.Right.value < n.Left.value)
                    {
                        return false;
                    }
                }
                else if (n.Left != null)
                {
                    if (n.value < n.Left.value)
                    {
                        return false;
                    }
                }
                else if (n.Right != null)
                {
                    if (n.value >= n.Right.value)
                    {
                        return false;
                    }
                }
                if (n.Left != null)
                    queue.Enqueue(n.Left);
                if (n.Right != null)
                    queue.Enqueue(n.Right);
            }
            return true;
        }
    }
}
