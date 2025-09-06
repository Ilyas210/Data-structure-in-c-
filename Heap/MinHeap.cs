using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    internal class MinHeap
    {
        List<int> _heap;
        
        public MinHeap()
        {
            _heap = new List<int>();
        }
        public void insert(int val)
        {
            _heap.Add(val);

            HeapifyUp(_heap.Count - 1);
        }

        void HeapifyUp(int index)
        {
            int parentindex = 0;
            while (index > 0)
            {
                parentindex = (index - 1) / 2; // 1 - 1 / 2 = 0 | 2 - 1 / 2 = 0

                if (_heap[index] >= _heap[parentindex]) break;

                (_heap[parentindex], _heap[index]) = (_heap[index], _heap[parentindex]);
                //table swap
                index = parentindex;
            }
        }

        public int Peek()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException("heap is empty");
            return _heap[0];
        }


        private void HeapifyDown(int index)
        {
            while (index < _heap.Count) 
            {
                int smallestindex = index;
                int right = 2 * smallestindex + 2;
                int left = 2 * smallestindex + 1;
                if (left < _heap.Count && _heap[smallestindex] > _heap[left])
                    smallestindex = left;
                if (right < _heap.Count && _heap[smallestindex] > _heap[right])
                    smallestindex = right;
                if (smallestindex == index) break;
                (_heap[smallestindex], _heap[index]) = (_heap[index], _heap[smallestindex]);
                index = smallestindex;
            }

        }

        private void HeapifyDown2(int index)
        {
            int smallestindex = index;
            int right = 2 * smallestindex + 2;
            int left = 2 * smallestindex + 1;
            if (left < _heap.Count && _heap[smallestindex] > _heap[left])
                smallestindex = left;
            if (right < _heap.Count && _heap[smallestindex] > _heap[right])
                smallestindex = right;
            if (smallestindex != index)
            {
                (_heap[smallestindex], _heap[index]) = (_heap[index], _heap[smallestindex]);
                HeapifyDown(smallestindex);
            }
        }
        public int ExtractMin()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException("heap is empty");

            int minvalue = _heap[0];

            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            HeapifyDown(0);
            //HeapifyDown2(0);
            return (minvalue);
        }

        public void DisplayHeap()
        {
            Console.WriteLine();
            for (int i = 0; i < _heap.Count; i++)
            {
                Console.Write(_heap[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
