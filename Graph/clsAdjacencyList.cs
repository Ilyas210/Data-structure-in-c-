using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class clsAdjacencyList
    {
        private Dictionary<string, int> _verteces;

        private Dictionary<string, List<Tuple<string, int>>> _AdjacencyList;

        private int _NumberOfvertices;

        public enum enDirectionType { Directed, UnDirected};

        private enDirectionType _directionType = enDirectionType.Directed;

        public clsAdjacencyList(List<string> vertices, enDirectionType directiontype)
        {
            _NumberOfvertices = vertices.Count;
            _directionType = directiontype;
            _verteces = new Dictionary<string, int>();
            _AdjacencyList = new Dictionary<string, List<Tuple<string, int>>>();

            for(int i=0; i < _NumberOfvertices; i++)
            {
                _verteces[vertices[i]] = i;
                _AdjacencyList.Add(vertices[i], new List<Tuple<string, int>>());
                // two methodes to add a key and value to Dictionnary
            }
        }

        public void AddEdge(string source, string Direction, int weight)
        {
            if (_verteces.ContainsKey(source) && _verteces.ContainsKey(Direction))
            {
                _AdjacencyList[source].Add(new Tuple<string, int>(Direction, weight));
                if (_directionType == enDirectionType.UnDirected)
                    _AdjacencyList[Direction].Add(new Tuple<string, int>(source, weight));
            }
            else
                Console.WriteLine("\n\nIgnored Invalid vertices");
        }

        public bool IsEdge(string source, string Direction)
        {
            if (_verteces.ContainsKey(source) && _verteces.ContainsKey(Direction))
            {
                foreach(var value in _AdjacencyList[source])
                    if (value.Item1 == Direction) return true;
            }
            return false;
        }

        public void RemoveEdge(string source, string Direction)
        {
            if (_verteces.ContainsKey(source) && _verteces.ContainsKey(Direction))
            {
                if (_AdjacencyList[source].RemoveAll((x => x.Item1 == Direction)) > 0)
                    Console.WriteLine($"edge between {source} => {Direction} removed sucessfully");
                else
                    Console.WriteLine("remove item failed");
                if (_directionType == enDirectionType.UnDirected)
                    if (_AdjacencyList[Direction].RemoveAll((x => x.Item1 == source)) > 0)
                        Console.WriteLine($"edge between {Direction} => {source} removed sucessfully");
                    else
                        Console.WriteLine("remove item failed");
            }
            else
                Console.WriteLine("\n\nIgnored Invalid vertices");

        }

        public int GetOutDegree(string vertece)
        {
            if (_AdjacencyList.ContainsKey(vertece))
            {
                return _AdjacencyList[vertece].Count;
            }
            return 0;
        }

        public int GetInDegree(string vertece)
        {
            int count = 0;
            if (_AdjacencyList.ContainsKey(vertece))
            {
               foreach(var ver in _AdjacencyList)
               {
                    foreach(var value in ver.Value)
                        if(value.Item1 == vertece) count++;
               }
            }
            return count;
        }
        public void DisplayList(string Message)
        {
            Console.WriteLine("\n" + Message + "\n");
            foreach (var vertec in _verteces)
            {
                Console.Write(vertec.Key + " -> ");
                foreach (var value in _AdjacencyList[vertec.Key])
                {
                    Console.Write(value.Item1 + "(" + value.Item2 + ") ");
                }
                Console.WriteLine();
            }
        }
    }
}
