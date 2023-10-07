using leetcode.AlgoExpert.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.AlgoExpert.Medium.BinarySearchTreeConstruction;

namespace leetcode.AlgoExpert.Medium
{
    public class BinarySearchTreeTraversal
    {
        public void RunSolution()
        {
            List<int> InOrder = new();
            List<int> PreOrder = new();
            List<int> PostOrder = new();
            var bst = new BinarySearchTree<int>(10);
            bst.Insetion(new Node<int>(5));
            bst.Insetion(new Node<int>(15));
            bst.Insetion(new Node<int>(2));
            bst.Insetion(new Node<int>(5));
           // bst.Insetion(new Node<int>(13));
            bst.Insetion(new Node<int>(22));
            bst.Insetion(new Node<int>(1));
          //  bst.Insetion(new Node<int>(14));
            var r = binarySearchTreeTraversal(bst, InOrder, PreOrder,PostOrder);
        }

        private object binarySearchTreeTraversal(BinarySearchTree<int> bst, List<int> inOrder, List<int> preOrder, List<int> postOrder)
        {
            DFS(bst.Root, inOrder, preOrder, postOrder);
            return bst;
        }

        private void DFS(Node<int> root, List<int> inOrder, List<int> preOrder, List<int> postOrder)
        {
            if(root == null)
            {
                return;
            }
            preOrder.Add(root.value);
            DFS(root.Left, inOrder, preOrder, postOrder);
            inOrder.Add(root.value);
            DFS(root.Right, inOrder, preOrder, postOrder);  
            postOrder.Add(root.value);
        }
    }
}
