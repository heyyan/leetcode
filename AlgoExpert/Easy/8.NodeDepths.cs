using leetcode.AlgoExpert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class NodeDepths
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
            node1.Left = node2;
            node1.Right = node3;
            node2.Left = node4;
            node2.Right = node5;
            node3.Left = node6;
            node3.Right = node7;
            node4.Left = node8;
            node4.Right = node9;

            //var result = GetNodeDepths(node1);
            var result = GetNodeDepths(node1, 0);
        }

        private int GetNodeDepths(Node<int> node)
        {
            int totalSum = 0;
            CalculateNodeDepth(node, ref totalSum, 0);
            return totalSum;
        }

        private void CalculateNodeDepth(Node<int> node, ref int totalSum, int currentDepth)
        {
            totalSum += currentDepth;
            if (node == null) return;

            if (node.Left == null && node.Right == null)
            {
                return;
            }
            currentDepth += 1;
            CalculateNodeDepth(node.Left, ref totalSum, currentDepth);
            CalculateNodeDepth(node.Right, ref totalSum, currentDepth);
        }

        private int GetNodeDepthInterative(Node<int> root)
        {
            int sumOfDepth = 0;
            var stack = new Models.Stack<StackValue>();
            stack.Push(new StackValue { Node = root, depth = 0 });
            while (stack.Count > 0)
            {
                var nodeInfo = stack.Pop();
                if (nodeInfo.Node == null)
                {
                    continue;
                }
                sumOfDepth += nodeInfo.depth;
                stack.Push(new StackValue { Node = nodeInfo.Node.Left, depth = nodeInfo.depth + 1 });
                stack.Push(new StackValue { Node = nodeInfo.Node.Right, depth = nodeInfo.depth + 1 });
            }
            return sumOfDepth;
        }


        private class StackValue
        {
            public Node<int> Node { get; set; }
            public int depth { get; set; }
        }


        private int GetNodeDepths(Node<int> node, int depth = 0)
        {
            if (node == null) return 0;
            return depth + GetNodeDepths(node.Left, depth + 1) + GetNodeDepths(node.Right, depth + 1);
        }
    }
}
