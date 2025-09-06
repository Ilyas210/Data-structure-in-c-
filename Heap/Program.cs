using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinHeap Heap = new MinHeap();
            Heap.insert(2);
            Heap.insert(4);
            Heap.insert(15);
            Heap.insert(10);
            //Heap.insert(8);
            Heap.insert(8);
            Heap.DisplayHeap();
            Console.WriteLine("extract minimum " + Heap.ExtractMin() + " :");
            Heap.DisplayHeap();
            Console.WriteLine("extract minimum " + Heap.ExtractMin() + " :");
            Heap.DisplayHeap();
        }
    }
}
