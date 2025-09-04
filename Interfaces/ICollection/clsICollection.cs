using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.ICollection
{
    internal class ArrayCollection<T> : ICollection<T>
    {
        private T[] _array;
        private int _count;

        public ArrayCollection(int capacity = 4)
        {
            _array = new T[capacity];
            _count = 0;
        }
        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
           if (_array.Length == _count)
                Array.Resize(ref _array, _count * 2);
           _array[_count++] = item;
        }

        public void Clear()
        {
            Array.Clear(_array, 0, _count);
            _count = 0;
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(_array, item, 0, _count) != -1; 
            // if we resize the array can allocate more space but just some in allocation space fill with values
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_array, 0, array, arrayIndex, _count);
        }


        public bool Remove(T item)
        {
            if (_count <= 0)
                return false;
           T[] temp = new T[_count - 1];
           bool isremoved = false;
           int i = 0;
           while (i < _count)
           {
                if (_array[i].Equals(item))
                {
                    isremoved = true; break;
                }
                if (i != _count - 1)
                    temp[i] = _array[i];
                i++;
           }
            if (i == Count && _array[i - 1].Equals(item))
                isremoved = true;      
           i++;
           if (isremoved)
           {
                while (i < _count)
                {
                    temp[i - 1] = _array[i];
                    i++;
                }
                _count--;
                _array = temp;
           }
           return isremoved;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int LastIdx = _count - 1;

            for (int i = 0; i <= LastIdx; i++)
                yield return _array[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
