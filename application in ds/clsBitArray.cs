using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsBitArray
    {

        static void changestringandprintit(StringBuilder sb)
        {
            sb.Append(" world");
            Console.WriteLine(sb);
        }
        static public void application()
        {
            StringBuilder sb = new StringBuilder("hello");
            changestringandprintit(sb);
            Console.WriteLine(sb);
        }
        static void changestringandprintit1(string sb)
        {
            sb += " world";
            Console.WriteLine(sb);
        }
        static public void application1()
        {
            string sb = "hello";
            changestringandprintit1(sb);
            Console.WriteLine(sb);
        }

        static string bitarraytostring(BitArray arr)
        {
            char[] bits = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                bits[i] = arr[i] ? '1' : '0';
            }
            return new string(bits);
        }

        static public void Application()
        {
            BitArray arr1 = new BitArray(4);
            Console.WriteLine($"\nbits1 content " + bitarraytostring(arr1));

            BitArray bits2 = new BitArray(new bool []{ true, false, true, false, true, true});
            Console.WriteLine($"\nbits2 content " + bitarraytostring(bits2));

            byte[] bytes = new byte[] { 0xAA, 0x1 };
            BitArray bits3 = new BitArray(bytes);
            Console.WriteLine($"\nbits3 content " + bitarraytostring(bits3));
            for (int i = 0; i < bits3.Length; i++)
            {
                bool val = bits3[i];
                Console.WriteLine($"bit at index {i} : {val}");
            }

            BitArray bits4 = new BitArray(5);
            bits4.SetAll(true);
            Console.WriteLine($"\nbits4 content " + bitarraytostring(bits4));
            for (int i = 0; i < bits4.Length; i++)
            {
                bool val = bits4[i];
                Console.WriteLine($"bit at index {i} : {val}");
            }
            bits4.Set(2, false);
        }

        public static void Application2()
        {
            BitArray bits1 = new BitArray(new bool []{ true, false, true, false }); // 1010
            BitArray bits2 = new BitArray (new bool []{ true, false, false, true }); // 1001
            Console.WriteLine(bitarraytostring(bits1));
            Console.WriteLine(bitarraytostring(bits2));
            Console.WriteLine("------------------");
            BitArray resultAnd = bits1.And(bits2);
            Console.WriteLine(bitarraytostring(resultAnd));
            Console.WriteLine();
            Console.WriteLine(bitarraytostring(bits1)); // 1000
            Console.WriteLine(bitarraytostring(bits2)); // 1001
            BitArray resultOr = bits1.Or(bits2);
            Console.WriteLine("------------------");
            Console.WriteLine(bitarraytostring(resultOr));

            Console.WriteLine();
            Console.WriteLine(bitarraytostring(bits2));
            Console.WriteLine("------------------");
            Console.WriteLine(bitarraytostring(bits2.Not()));

            Console.WriteLine();
            bits1[1] = true;
            bits1[3] = false;
            Console.WriteLine(bitarraytostring(bits1)); // 1100
            Console.WriteLine(bitarraytostring(bits2)); // 0110
            Console.WriteLine("------------------");
            Console.WriteLine(bitarraytostring(bits1.Xor(bits2)));

        }
    }
}
