using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IList_gen
{
    internal class IListCollection<T> : IList<T>
    {
        List<T> items = new List<T>();
        public T this[int index] 
        { 
            get => items[index];
            set => items[index] = value; 
        }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        public void Add(T item) => items.Add(item);

        public void Clear() => items.Clear();

        public bool Contains(T item) => items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        public int IndexOf(T item) => items.IndexOf(item);

        public void Insert(int index, T item) => items.Insert(index, item);

        public bool Remove(T item) => items.Remove(item);
        public void RemoveAt(int index) => items.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
