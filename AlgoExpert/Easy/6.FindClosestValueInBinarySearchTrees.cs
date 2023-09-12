using leetcode.AlgoExpert.Models;
using System;

namespace leetcode.AlgoExpert.Easy
{
    public class FindClosestValueInBinarySearchTrees
    {
        public void RunSolution()
        {
            var bst = new BinarySearchTree();
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(2);
            bst.Insert(5);
            bst.Insert(13);
            bst.Insert(22);
            bst.Insert(1);
            bst.Insert(14);
            var result = GetFindClosestValueInBinarySearchTrees(bst, 12);
            //var result = findClosedValueInBst(bst, 12);
        }

        private int GetFindClosestValueInBinarySearchTrees(BinarySearchTree bst, int value)
        {
            int closest = int.MaxValue;
            Node currentNode = bst.root;
            while (currentNode != null)
            {
                if (Math.Abs(currentNode.Data - value) < Math.Abs(closest - value))
                {
                    closest = currentNode.Data;
                }
                if (currentNode.Data < value)
                {
                    currentNode = currentNode.Right;
                }
                else if (currentNode.Data > value) 
                {
                    currentNode = currentNode.Left;
                }else
                {
                    break;
                }
            }

            return closest;
        }

        private int findClosedValueInBst(BinarySearchTree tree, int target)
        {
            return FindClosestValueInBstHelper(tree.root, target, int.MaxValue);
        }

        private int FindClosestValueInBstHelper(Node node, int target, int closest)
        {
            if (node == null)
            {
                return closest;
            }

            if (Math.Abs(target - closest) > Math.Abs(closest - node.Data))
            {
                closest = node.Data;
            }

            if (target < node.Data)
            {
                return FindClosestValueInBstHelper(node.Left, target, closest);
            }
            else if (target > node.Data)
            {
                return FindClosestValueInBstHelper(node.Right, target, closest);
            }
            else
            {
                return closest;
            }
        }
    }
}
