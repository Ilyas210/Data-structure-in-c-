using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    internal class MinHeapGen<T> where T : IComparable<T>
    {
        List<T> _heap;

        public MinHeapGen()
        {
            _heap = new List<T>();
        }
        public void insert(T val)
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

                if (_heap[parentindex].CompareTo(_heap[index]) <= 0) break;

                (_heap[parentindex], _heap[index]) = (_heap[index], _heap[parentindex]);
                //table swap
                index = parentindex;
            }
        }

        public T Peek()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException("heap is empty");
            return _heap[0];
        }
    }
}
