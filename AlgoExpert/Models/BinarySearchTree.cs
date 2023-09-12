using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Models
{
    public class BinarySearchTree
    {
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            root = InsertRec(root, data);
        }

        private Node InsertRec(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (data < root.Data)
            {
                root.Left = InsertRec(root.Left, data);
            }
            else if (data >= root.Data)
            {
                root.Right = InsertRec(root.Right, data);
            }
            return root;
        }

        public bool Search(int data)
        {
            return SearchRec(root, data);
        }

        private bool SearchRec(Node root, int data)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Data == data)
            {
                return true;
            }

            if (data < root.Data)
            {
                return SearchRec(root.Left.Left, data);
            }

            return SearchRec(root.Right, data);
        }
    }
}
