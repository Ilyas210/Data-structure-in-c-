using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    internal class MaxHeap
    {
        List<int> _heap;

        public MaxHeap()
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

                if (_heap[index] <= _heap[parentindex]) break;

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
                int LargestIndex = index;
                int right = 2 * LargestIndex + 2;
                int left = 2 * LargestIndex + 1;
                if (left < _heap.Count && _heap[LargestIndex] < _heap[left])
                    LargestIndex = left;
                if (right < _heap.Count && _heap[LargestIndex] < _heap[right])
                    LargestIndex = right;
                if (LargestIndex == index) break;
                (_heap[LargestIndex], _heap[index]) = (_heap[index], _heap[LargestIndex]);
                index = LargestIndex;
            }
        }
        public int ExtractMax()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException("heap is empty");

            int minvalue = _heap[0];

            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            HeapifyDown(0);
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
