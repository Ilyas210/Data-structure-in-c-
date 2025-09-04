using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class Graph
    {
        public enum enDirectionType { Directed, unDirected}

        private int[,] _adjacencyMatrix;

        private Dictionary<string, int> _vertexDictionary;
        private int _numberOfVertices;
        private enDirectionType _enGraphicDirectionType = enDirectionType.unDirected;

        public Graph (List<string> vertices, enDirectionType GraphDirectionType)
        {
            _enGraphicDirectionType = GraphDirectionType;
            _numberOfVertices = vertices.Count;

            _adjacencyMatrix = new int[_numberOfVertices, _numberOfVertices];
            _vertexDictionary = new Dictionary<string, int>();
            for(int i = 0; i < vertices.Count; i++)
            {
                _vertexDictionary[vertices[i]] = i;
            }
        }

        public void AddEdge(string source, string destination, int weight)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                int sourceindex = _vertexDictionary[source];
                int destinationindex = _vertexDictionary[destination];

                _adjacencyMatrix[sourceindex, destinationindex] = weight;

                if (_enGraphicDirectionType == enDirectionType.unDirected)
                    _adjacencyMatrix[destinationindex, sourceindex] = weight;
            }
            else
            {
                Console.WriteLine($"\n\nIgnored:Invalid vertices. {source} ==> {destination}");
            }
        }

        public void RemoveEdge(string source, string destination)
        {
            //AddEdge(source, destination, 0);
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                int sourceindex = _vertexDictionary[source];
                int destinationindex = _vertexDictionary[destination];

                _adjacencyMatrix[sourceindex, destinationindex] = 0;
                _adjacencyMatrix[destinationindex, sourceindex] = 0;
            }
            else
            {
                Console.WriteLine($"\n\nIgnored:Invalid vertices. {source} ==> {destination}");
            }

        }

        public bool IsEdge(string source, string destination)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                int sourceindex = _vertexDictionary[source];
                int destinationindex = _vertexDictionary[destination];
                return (_adjacencyMatrix[sourceindex, destinationindex] > 0);
            }
            else
            {
                return false;
            }
        }

        public int GetDegree(string source, Func<int, int, bool> OutIn)
        {
            int count = 0;
            if (_vertexDictionary.ContainsKey(source))
            {
                int index = _vertexDictionary[source];

                for (int i = 0; i < _vertexDictionary.Count; i++)
                {
                    if (OutIn(index, i))
                        count++;
                }
                return count;
            }
            return 0;
        }

        public void DisplayGraph(string message)
        {
            Console.WriteLine(message);

            Console.Write("  ");
            foreach(var vertex in _vertexDictionary.Keys)
                Console.Write(vertex + " ");
            foreach(var destination in _vertexDictionary)
            {
                Console.WriteLine();
                Console.Write(destination.Key + " ");
                for(int i = 0; i < _vertexDictionary.Count; i++)
                    Console.Write(_adjacencyMatrix[destination.Value, i] + " ");
            }
        }
    }
}
