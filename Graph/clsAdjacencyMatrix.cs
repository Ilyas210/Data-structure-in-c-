using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace GraphImplementation
{
    internal class clsAdjacencyMatrix
    {

        int[,] matrix;

        public enum enDirectionType { unDericted, Directed};
        enDirectionType Type = enDirectionType.Directed;

        Dictionary<string, int> _VertexDictionnary;

        int _NumberOfVertices;
        public clsAdjacencyMatrix(List <string> verteces, enDirectionType type)
        {
            _VertexDictionnary = new Dictionary<string, int>();
            for(int i = 0; i < verteces.Count; i++)
            {
                _VertexDictionnary.Add(verteces[i], i);
            }
            Type = type;
            matrix = new int[verteces.Count, verteces.Count];
            _NumberOfVertices = verteces.Count;
        }
        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            private set { matrix[i, j] = value; }
        }

        public void AddEdge(string source, string destination, int weight)
        {
            if (_VertexDictionnary.ContainsKey(source) && _VertexDictionnary.ContainsKey(destination))
            {
                int soureindex = _VertexDictionnary[source];
                int destinationindex = _VertexDictionnary[destination];

                matrix[soureindex, destinationindex] = weight;
                if (Type == enDirectionType.unDericted)
                {
                    matrix[destinationindex, soureindex] = weight;
                }
            }
            else
            {
                Console.WriteLine("one of two or two edges doesn't exist");
            }
        }

        public bool IsEdge(string source, string destination)
        {
            if (_VertexDictionnary.ContainsKey(source) && _VertexDictionnary.ContainsKey(destination))
            {
                int soureindex = _VertexDictionnary[source];
                int destinationindex = _VertexDictionnary[destination];

                return matrix[soureindex, destinationindex] > 0;
            }
            return false;
        }

        public void RemoveEdge(string source, string destination)
        {
            if (_VertexDictionnary.ContainsKey(source) && _VertexDictionnary.ContainsKey(destination))
            {
                int soureindex = _VertexDictionnary[source];
                int destinationindex = _VertexDictionnary[destination];

                matrix[soureindex, destinationindex] =  0;
                matrix[destinationindex , soureindex] =  0;
            }
            else
            {
                Console.WriteLine("one of two or two edges doesn't exist");
            }
        }

        public void DisplayGraph(string message)
        {
            Console.WriteLine("\n" + message + "\n");

            Console.Write("  ");
            foreach (var vertece in _VertexDictionnary)
            {
                Console.Write(vertece.Key + " ");
            }

            foreach (var vertece in _VertexDictionnary)
            {
                Console.WriteLine();
                Console.Write(vertece.Key + " ");
                for(int i = 0; i < _NumberOfVertices; i++)
                {
                    Console.Write(matrix[vertece.Value, i] +  " ");
                }
            }
        }

        public int GetOutDegree(string vertece)
        {
            int count = 0;
            if (_VertexDictionnary.ContainsKey(vertece))
            {
                for (int i = 0; i < _VertexDictionnary.Count; i++)
                {
                    if (matrix[_VertexDictionnary[vertece], i] > 0)
                        count++;
                }
                return count;
            }
            return 0;
        }

        public int GetInDegree(string vertece)
        {
            int count = 0;
            if (_VertexDictionnary.ContainsKey(vertece))
            {
                for (int i = 0; i < _VertexDictionnary.Count; i++)
                {
                    if (matrix[i, _VertexDictionnary[vertece]] > 0)
                        count++;
                }
                return count;
            }
            return 0;
        }

        public int GetDegree(string vertece, Func<int, int, int> exe) // resume of two fun getout getin
        {
            int count = 0;
            if (_VertexDictionnary.ContainsKey(vertece))
            {
                for (int i = 0; i < _VertexDictionnary.Count; i++)
                {
                    if (exe(_VertexDictionnary[vertece], i) > 0)
                        count++;
                }
                return count;
            }
            return 0;
        }
    }
}
