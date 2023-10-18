using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class BreathFirstSearch
    {
        // input [2,3,1,-4,-4,2]
        // output true 
        public void RunSolution()
        {
            var rest = GetBreathFirstSearch();
        }

        private string[] GetBreathFirstSearch()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");
            var f = new Node("F");
            var g = new Node("G");
            var h = new Node("H");
            var i = new Node("I");
            var j = new Node("J");
            var k = new Node("K");
            a.Children.Add(b);
            a.Children.Add(c);
            a.Children.Add(d);
            b.Children.Add(e);
            b.Children.Add(f);
            d.Children.Add(g);
            d.Children.Add(h);
            f.Children.Add(i);
            f.Children.Add(j);
            g.Children.Add(k);

            var resultList = new List<string>();

            var queue = new Queue<Node>();
            queue.Enqueue(a);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                resultList.Add(current.Value);
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return resultList.ToArray();
        }
    }

    public class Node
    {
        public Node(string value)
        {
            Value = value;
            Children = new List<Node>();
        }
        public string Value { get; set; }
        public List<Node> Children { get; set; }
    }
}
