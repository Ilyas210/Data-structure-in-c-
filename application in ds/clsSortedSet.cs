using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{

    internal class clsSortedSet
    {
        public static void Application()
        {
            SortedSet<int> Set = new SortedSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var EvenNumber = Set.Where(x => x % 2 == 0).Select(x => x * x);
            foreach (var e in EvenNumber)
            {
                Console.WriteLine(e);
            }
            Set.Add(11);
            var sumoddnumber = Set.Where(x => x % 2 == 1).Sum();
            Console.WriteLine($"the sum of odd numbers is {sumoddnumber}");
        }
    }
}


