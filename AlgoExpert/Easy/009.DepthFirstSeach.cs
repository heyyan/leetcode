using leetcode.AlgoExpert.Models;
using System.Collections.Generic;

namespace leetcode.AlgoExpert.Easy
{
    public class DepthFirstSeach
    {
        public void RunSolution()
        {
            //Graph<string> graph = new Graph<string>();
            //graph.AddVertex("A");
            //graph.AddVertex("B");
            //graph.AddVertex("C");
            //graph.AddVertex("D");
            //graph.AddVertex("E");
            //graph.AddVertex("F");
            //graph.AddVertex("G");
            //graph.AddVertex("H");
            //graph.AddVertex("I");
            //graph.AddVertex("J");
            //graph.AddVertex("K");
            //graph.AddEdge("A", "B");
            //graph.AddEdge("A", "C");
            //graph.AddEdge("A", "D");
            //graph.AddEdge("B", "E");
            //graph.AddEdge("B", "F");
            //graph.AddEdge("F", "I");
            //graph.AddEdge("F", "J");
            //graph.AddEdge("D", "G");
            //graph.AddEdge("D", "H");
            //graph.AddEdge("G", "K");

            NodeGraph graphA = new NodeGraph("A");
            NodeGraph graphB = new NodeGraph("B");
            NodeGraph graphC = new NodeGraph("C");
            NodeGraph graphD = new NodeGraph("D");
            NodeGraph graphE = new NodeGraph("E");
            NodeGraph graphF = new NodeGraph("F");
            NodeGraph graphG = new NodeGraph("G");
            NodeGraph graphH = new NodeGraph("H");
            NodeGraph graphI = new NodeGraph("I");
            NodeGraph graphJ = new NodeGraph("J");
            NodeGraph graphK = new NodeGraph("K");
            NodeGraph graphL = new NodeGraph("L");
            graphA.AddChild(graphB);
            graphA.AddChild(graphC);
            graphA.AddChild(graphD);
            graphB.AddChild(graphE);
            graphB.AddChild(graphF);
            graphD.AddChild(graphG);
            graphD.AddChild(graphH);
            graphF.AddChild(graphI);
            graphF.AddChild(graphJ);
            graphG.AddChild(graphK);

            //graph.PrintGraph();
            var result = new List<string>();
            GetDepthFirstSeach(graphA, result);
            //var result = GetNodeDepths(node1, 0);
        }

        private void GetDepthFirstSeach(NodeGraph graph, List<string> names)
        {
            names.Add(graph.Name);
            foreach (var child in graph.Children)
            {
                GetDepthFirstSeach(child, names);
            }

        }
    }
}
