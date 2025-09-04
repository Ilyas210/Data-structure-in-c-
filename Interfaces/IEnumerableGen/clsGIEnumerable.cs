using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Collections2
{
    internal class clsGIEnumerable<T> : IEnumerable<T> // this interface inherit from non generic IEnumerable
    {
        // it should implement two methods one for generic and other for non generic IEnumerable interface
        private List <T> Items = new List <T>();
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                yield return Items [i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T Item)
        {
            Items.Add(Item);
        }
    }
}
