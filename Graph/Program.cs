using GraphImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

            //Graph graph = new Graph(vertices, Graph.enDirectionType.Directed);
            //graph.AddEdge("A", "B", 1);
            //graph.AddEdge("B", "C", 1);
            //graph.AddEdge("A", "C", 1);
            //graph.AddEdge("C", "D", 1);
            //graph.AddEdge("E", "D", 1);

            //graph.DisplayGraph("undirected matrix : ");

            clsAdjacencyMatrix graph = new clsAdjacencyMatrix(vertices, clsAdjacencyMatrix.enDirectionType.Directed);
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("B", "C", 1);
            graph.AddEdge("A", "C", 1);
            graph.AddEdge("C", "D", 1);
            graph.AddEdge("E", "D", 1);
            graph.DisplayGraph("adjacency matrix (directed Graph)");
            Console.WriteLine();
            Console.WriteLine(graph.IsEdge("A", "B") ? "it was an edge between A => b " : "any edge between a and b");
            int outdegree = graph.GetDegree("A", (x, y) => graph[x, y]);

            
            Console.WriteLine("A out degrees are = " + outdegree);
        }
    }
}
