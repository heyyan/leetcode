namespace leetcode.AlgoExpert.Models
{
    public class BinarySearchTree
    {
        public Node<int> root;
        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            root = InsertRec(root, data);
        }

        private Node<int> InsertRec(Node<int> root, int data)
        {
            if (root == null)
            {
                root = new Node<int>(data);
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

        private bool SearchRec(Node<int> root, int data)
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
