using leetcode.AlgoExpert.Models;
using System.Collections.Generic;

namespace leetcode.AlgoExpert.Easy
{
    public class BranchSums
    {
        public void RunSolution()
        {
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);
            var node4 = new Node<int>(4);
            var node5 = new Node<int>(5);
            var node6 = new Node<int>(6);
            var node7 = new Node<int>(7);
            var node8 = new Node<int>(8);
            var node9 = new Node<int>(9);
            var node10 = new Node<int>(10);
            node1.Left = node2;
            node1.Right = node3;
            node2.Left = node4;
            node2.Right = node5;
            node3.Left = node6;
            node3.Right = node7;
            node4.Left = node8;
            node4.Right = node9;
            node5.Right = node10;

            var result = GetBranchSums(node1);
        }

        private int[] GetBranchSums(Node<int> node)
        {
            int runningSum = 0;
            var sums = new List<int>();
            CalculateBranchSum(node, runningSum, sums);
            return sums.ToArray();
        }

        private void CalculateBranchSum(Node<int> node, int runningSum, List<int> sums)
        {
            if(node ==  null) return;
            int newRunningSum = runningSum + node.Data;
            if (node.Left == null && node.Right == null)
            {
                sums.Add(newRunningSum);
                return;
            }

            CalculateBranchSum(node.Left, newRunningSum, sums);
            CalculateBranchSum(node.Right, newRunningSum, sums);
        }
    }
}
