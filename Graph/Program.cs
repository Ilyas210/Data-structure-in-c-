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

            //clsAdjacencyMatrix graph = new clsAdjacencyMatrix(vertices, clsAdjacencyMatrix.enDirectionType.Directed);
            //graph.AddEdge("A", "B", 1);
            //graph.AddEdge("B", "C", 1);
            //graph.AddEdge("A", "C", 1);
            //graph.AddEdge("C", "D", 1);
            //graph.AddEdge("E", "D", 1);
            //graph.DisplayGraph("adjacency matrix (directed Graph)");
            //Console.WriteLine();
            //Console.WriteLine(graph.IsEdge("A", "B") ? "it was an edge between A => b " : "any edge between a and b");
            //int outdegree = graph.GetDegree("A", (x, y) => graph[x, y]);

            
            //Console.WriteLine("A out degrees are = " + outdegree);

            //clsAdjacencyMatrix graph2 = new clsAdjacencyMatrix(vertices, clsAdjacencyMatrix.enDirectionType.unDericted);
            //graph2.AddEdge("A", "B", 10);
            //graph2.AddEdge("B", "C", 7);
            //graph2.AddEdge("A", "C", 11);
            //graph2.AddEdge("C", "D", 8);
            //graph2.AddEdge("E", "D", 5);
            //graph2.DisplayGraph("adjacency matrix (weighted Graph)");

             //Adjacency List

            clsAdjacencyList graph = new clsAdjacencyList(vertices, clsAdjacencyList.enDirectionType.Directed);
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("B", "C", 1);
            graph.AddEdge("A", "C", 1);
            graph.AddEdge("C", "D", 1);
            graph.AddEdge("E", "D", 1);
            graph.DisplayList("adjacency List (directed Graph)");
            graph.RemoveEdge("A", "B");
            graph.DisplayList("adjacency List (directed Graph)");

            Console.WriteLine("----------------------------------------------\n");
            clsAdjacencyList graph2 = new clsAdjacencyList(vertices, clsAdjacencyList.enDirectionType.UnDirected);
            graph2.AddEdge("A", "B", 1);
            graph2.AddEdge("B", "C", 1);
            graph2.AddEdge("A", "C", 1);
            graph2.AddEdge("C", "D", 1);
            graph2.AddEdge("E", "D", 1);
            graph2.DisplayList("adjacency List (undirected Graph)");
            graph2.RemoveEdge("A", "B");
            graph2.DisplayList("adjacency List (undirected Graph)");
            Console.WriteLine("C in degree = " + graph2.GetInDegree("C"));
            Console.WriteLine("D in degree = " + graph2.GetOutDegree("A"));
            Console.WriteLine();


            //Console.WriteLine("----------------------------------------------\n");
            //clsAdjacencyList graph3 = new clsAdjacencyList(vertices, clsAdjacencyList.enDirectionType.Directed);
            //graph3.AddEdge("A", "B", 11);
            //graph3.AddEdge("B", "C", 15);
            //graph3.AddEdge("A", "C", 7);
            //graph3.AddEdge("C", "D", 4);
            //graph3.AddEdge("E", "D", 2);
            //graph3.DisplayList("adjacency List (weighted Graph)");
            //Console.WriteLine();
            //Console.WriteLine(graph.IsEdge("A", "B") ? "it was an edge between A => b " : "any edge between a and b");
            //int outdegree = graph.GetDegree("A", (x, y) => graph[x, y]);
        }
    }
}
