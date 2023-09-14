using System.Collections.Generic;

namespace leetcode.AlgoExpert.Models
{
    public class Stack<T>
    {
        private List<T> items;

        public Stack()
        {
            items = new List<T>();
        }

        public int Count { get { return items.Count; } }

        public void Push(T item) { items.Add(item); }

        public T Pop()
        {
            if (items.Count == 0)
            {
                return default(T);
            }

            int lastIntex = Count - 1;
            T item = items[lastIntex];
            items.RemoveAt(lastIntex);
            return item;
        }

        public T Peek()
        {
            if (items.Count == 0)
            {
                return default(T);
            }
            return items[Count - 1];
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
