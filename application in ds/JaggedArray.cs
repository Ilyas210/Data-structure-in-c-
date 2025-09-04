using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class JaggedArray
    {


        public static void Application()
        {
            int[][] arr = new int[3][];

            arr[0] = new int[] { 1, 2, 3, 4 };
            arr[1] = new int[] { 0, 1 };
            arr[2] = new int[] { 0, 0, 0 };

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"array {i + 1}");
                for (int j = 0; j < arr[i].Length; j++)
                    Console.WriteLine(arr[i][j]);
            }
        }

        public static void Application2()
        {
            int[][] arr = new int[3][];

            arr[0] = new int[] { 1, 2, 3, 4 };
            arr[1] = new int[] { 0, 1 };
            arr[2] = new int[] { 0, 0, 0 };
            var sum1 = arr.SelectMany(x => x).Sum();
            var sum2 = arr.Select(x => x.Sum());
            Console.WriteLine(sum1);
            int i = 0;
            foreach (var s in sum2)
            {
                Console.WriteLine("sum" + i++ + " " + s);
            } 
        }

    }
}
