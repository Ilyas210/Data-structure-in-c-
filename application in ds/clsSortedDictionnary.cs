using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsSortedDictionnary
    {
        static public void Application()
        {
            SortedDictionary<int, string> keyValuePairs = new SortedDictionary<int, string>();
            keyValuePairs.Add(22, "Ilyas");
            keyValuePairs.Add(2, "Riyad");
            keyValuePairs.Add(100, "Akram");
            foreach (var x in keyValuePairs)
            {
              Console.WriteLine($"{x.Key} -> {x.Value}");           
            }
        }
    }
}
