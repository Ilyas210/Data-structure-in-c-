using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Collections
{
    internal class clsIEnumerable : IEnumerable
    {
        string[] items = new string [3] { "bread", "banana", "orange"}; 
        public IEnumerator GetEnumerator()
        {
           return new clsIEnumerator(items);
        }
    }
}
