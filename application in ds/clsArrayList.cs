using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsArrayList
    {
        public static void Application()
        {
            ArrayList array = new ArrayList { 1, 'a', 'c'};
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            array.Add("ilyas");
            string name = (string)array[array.Count - 1]; // unboxing
            Console.WriteLine(name);
            array.RemoveAt(1);
            Console.WriteLine("before trim size");
            Console.WriteLine(array.Capacity);
            Console.WriteLine(array.Count);
            Console.WriteLine("after trim size");
            array.TrimToSize();
            Console.WriteLine(array.Capacity);
            Console.WriteLine(array.Count);
            Console.WriteLine("-----------------------------------------");
        }

        public static void application1()
        {
            ArrayList array = new ArrayList() { 1, 3, 4, 5, 1, 6};

            int x = array.Cast<int>().Min();
            Console.WriteLine("Min = " + x);
            x = array.Cast<int>().Max();
            Console.WriteLine("Max = " + x);

            var v = array.Cast<int>().Count(y => y == 1);
            Console.WriteLine($"num 1 repeated {v} times");
            var even = array.Cast<int>().Where(y => y % 2 == 0);
            Console.WriteLine("even numbers : " + string.Join(" ", even));
        }
    }
}
