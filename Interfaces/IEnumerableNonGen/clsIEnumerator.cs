using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Collections
{
    internal class clsIEnumerator : IEnumerator
    {
        private string[] Items;
        private int position;
        public clsIEnumerator(string[] items)
        {
            Items = items;
            position = -1;
        }
        public object Current
        { 
            get { return Items[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return position < Items.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
