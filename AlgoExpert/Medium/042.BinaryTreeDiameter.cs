using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.AlgoExpert.Medium.BinarySearchTreeConstruction;

namespace leetcode.AlgoExpert.Medium
{
    internal class BinaryTreeDiameter
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
            root1.Left = root3;
            root1.Right = root2;
            root3.Left = root7;
            root3.Right = root4;
            root7.Left = root8;
            root8.Left = root9;
            root4.Right = root5;
            root5.Right = root6;

            var result = binaryTreeDiameter(root1);
        }

        private object binaryTreeDiameter(Node<int> node)
        {
            var res = Dfs(node);
            return res;
        }

        private TreeInfo Dfs(Node<int> node)
        {
            if (node == null) return new TreeInfo(0, 0);
            var leftTreeInfo = Dfs(node.Left);
            var rightTreeInfo = Dfs(node.Right);

            int longestPathThroughRoot = leftTreeInfo.Height + rightTreeInfo.Height;
            int maxDiameterSoFar = Math.Max(leftTreeInfo.Diameter, rightTreeInfo.Diameter);
            int currentDiameter = Math.Max(longestPathThroughRoot, maxDiameterSoFar);
            int currentHeight = 1 + Math.Max(leftTreeInfo.Height, rightTreeInfo.Height);
            return new TreeInfo(currentDiameter, currentHeight);
        }

        private class TreeInfo
        {
            public TreeInfo(int diameter, int height)
            {
                Height = height;
                Diameter = diameter;
            }

            public int Height { get; set; }
            public int Diameter { get; set; }
        }
    }
}
