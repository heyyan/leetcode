using System.Collections.Generic;

namespace leetcode.AlgoExpert.Models
{
    public class NodeGraph
    {
        public string Name { get; set; }
        public List<NodeGraph> Children { get; set; }
        public NodeGraph(string name)
        {
            Children = new List<NodeGraph>();
            Name = name;
        }

        public void AddChild(NodeGraph child)
        {
            Children.Add(child);
        }
    }
}
