using leetcode.AlgoExpert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class HeightBalancedBinaryTree
    {
        // difference in hight of the left subtree and the right subtree is equal to one.
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

            //root2.Parent = root1;
            //root3.Parent = root1;
            //root4.Parent = root2;
            //root5.Parent = root2;
            //root6.Parent = root4;

            root1.Left = root2;
            root1.Right = root3;
            root2.Left = root4;
            root2.Right = root5;
            root3.Right = root6;
            root5.Left = root7;
            root5.Right = root8;
            // var rest = GetSuccor(root1, 5);
            var rest = heightBalancedBinaryTree(root1);
        }

        private int heightBalancedBinaryTree(Node<int> node)
        {
            if (node == null) { return -1; }

            int leftHeight = heightBalancedBinaryTree(node.Left);
            int rightHeight = heightBalancedBinaryTree(node.Right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }
        private TreeInfo heightBalancedBinaryTree2(Node<int> node)
        {
            if (node == null) { return new TreeInfo(true, -1); }
            var leftSubTreeInfo = heightBalancedBinaryTree2(node.Left);
            var rightSubTreeInfo = heightBalancedBinaryTree2(node.Right);

            var isBalanced = leftSubTreeInfo.Balance && rightSubTreeInfo.Balance && Math.Abs(rightSubTreeInfo.Height - leftSubTreeInfo.Height) <= 1;
            var height = Math.Max(leftSubTreeInfo.Height, rightSubTreeInfo.Height) + 1;
            return new TreeInfo(isBalanced, height);
        }


        private class TreeInfo
        {
            public TreeInfo(bool balance, int height)
            {
                this.Height = height;
                Balance = balance;
            }
            public int Height { get; set; }
            public bool Balance { get; set; }
        }
    }
}
