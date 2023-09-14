namespace leetcode.AlgoExpert.Models
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Left;
        public Node<T> Right;

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
