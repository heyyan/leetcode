using System;
using System.Collections.Generic;

namespace leetcode.AlgoExpert.Models
{
    public class Graph<T>
    {
        public Dictionary<T, List<T>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<T, List<T>>();
        }

        public void AddVertex(T vartex)
        {
            if(!adjacencyList.ContainsKey(vartex))
            {
                adjacencyList[vartex] = new List<T>();
            }
        }

        public void AddEdge(T source, T destination)
        {
            if (!adjacencyList.ContainsKey(source))
            {
                AddVertex(source);
            }

            if (!adjacencyList.ContainsKey(destination))
            {
                AddVertex(destination);
            }

            adjacencyList[source].Add(destination);
            //adjacencyList[destination].Add(source); // Uncomment this line for an undirected graph
        }

        public List<T> GetNeighbors(T Vertex)
        {
            if(adjacencyList.ContainsKey(Vertex))
            {
                return adjacencyList[Vertex];
            }
            return null;    
        }

        public void PrintGraph()
        {
            foreach (var vertex in adjacencyList)
            {
                Console.Write($"{vertex.Key}: ");
                foreach (var neighbor in vertex.Value)
                {
                    Console.Write($"{neighbor} ");
                }
                Console.WriteLine();
            }
        }
    }
}
