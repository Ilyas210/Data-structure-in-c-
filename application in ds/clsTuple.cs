using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsTuple
    {

        static public void Application ()
        {
            Tuple<int, int> tuple1 = new Tuple<int, int> ( 1, 3 );

            Tuple<int, string> tuple2 = new Tuple<int, string>(1, "ilyas");
            var tuple3 = Tuple.Create(1, 2, 3, Tuple.Create(4, 5));

            //Console.WriteLine(tuple2.Item2);
            Console.WriteLine(tuple3.Item4.Item2);

            var tuple4 = new Tuple<int, clsperson>(1, new clsperson(1, "ilyas", 24, new List<string> { "tomato", "botato" }));
         
            Console.WriteLine(tuple4.Item2.name);
        }

        static public void Application2 ()
        {
            ValueTuple<int, string> valtuple = new ValueTuple<int, string>(1, "ilyas");
            ValueTuple<int, string> valtuple2 = valtuple;

            (int, string, bool) p = (1, "ok", true);
            (int, (int, string)) p2 = (1, (2, "koko"));

            valtuple.Item1 = 2;
            Console.WriteLine(valtuple2.Item1);

            Tuple<int, string> tuple = new Tuple<int, string>(1, "Ilyas");
            Tuple<int, string> tuple1 = tuple;

            Console.WriteLine(p2.Item2.Item2); // "koko"
         
        }
    }
}
