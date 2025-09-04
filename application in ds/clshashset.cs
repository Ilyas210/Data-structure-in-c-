using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clshashset
    {
        static public void application()
        {
            HashSet<string> hset = new HashSet<string>()
            {
                "ilyas","riyad","Ilyas","ilyas"
            };
            hset.Add("akram");
            hset.Remove("Ilyas");
            foreach (var item in hset)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(hset.Contains("riyad") ? "yes" : "no");
        }

        static public void application2()
        {
            string[] arr = new string[] { "ilyas", "akram", "riyad", "asmae" ,"aymen", "none"};
            HashSet<string> winners = new HashSet<string>();
            Random rnd = new Random();
            for (int i = 0; i < 2; i++)
            {
                winners.Add(arr[rnd.Next(0, arr.Length - 1)]);
            }
            Console.WriteLine("the winners are : ");
            foreach (var winner in winners)
            {
                Console.WriteLine(winner);
            }
            var namesstartwitha = winners.Where(x => x.StartsWith("a"));
            Console.WriteLine("names start with a :");
            foreach (var item in namesstartwitha)
            {
                Console.WriteLine(item);
            }
        }

        static public void application3()
        {
            int[] nums = new int[] { 1, 2, 2, 3, 4, 4, 4, 6, 7 };

            HashSet<int> arr = new HashSet<int>(nums); // application 3 better than application 4 specially when we have a large number
            Console.WriteLine("unique numbers :");
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static public void application4()
        {
            int[] nums = new int[] { 1, 2, 2, 3, 4, 4, 4, 6, 7 };
            List<int> lst = new List<int>();

            Console.WriteLine("unique numbers :");
            foreach (var item in nums)
            {
                if (!lst.Contains(item))
                {
                    Console.WriteLine(item);
                    lst.Add(item);
                }
            }
        }

        static public void application5()
        {
            HashSet<int> arr = new HashSet<int>() { 1, 3, 4};
            HashSet<int> arr1 = new HashSet<int>() { 0, 3, 3};
            arr.UnionWith(arr1);
            var container = arr.OrderBy(x => x);
            foreach (var item in container)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("intersection : ");
            arr = new HashSet<int>() { 1,3,4};
            arr.IntersectWith(arr1);
            container = arr.OrderBy(x => x);
            foreach (var item in container)
            {
                Console.WriteLine(item);
            }
        }

        static public void application6()
        {
            List<clsperson> people = new List<clsperson>
            {
                new clsperson(1, "ilyas", 25, new List<string> {"programming", "football", "music"}),
                new clsperson(1, "riyad", 20, new List<string> {"body_building", "football", "music", "cooking"}),
                new clsperson(1, "ypcef", 20, new List<string> {"programming", "football", "AI"})
            };

            HashSet<string> set = new HashSet<string>(people.First().Hobbies);

            foreach (var person in people)
            {
                set.IntersectWith(person.Hobbies); // football
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------");
            set = new HashSet<string> { "1", "2", "3" };
            HashSet <string> set2 = new HashSet<string> { "3", "4", "5" };
            set.ExceptWith(set2); // set - set2
            foreach(var item in set)
            {
                Console.WriteLine(item); // 1 2
            }
            Console.WriteLine("---------------------");

            set = new HashSet<string> { "1", "2", "3" };
            set.SymmetricExceptWith(set2); // set + set2 exept intersect number
            foreach( var item in set)
                { Console.WriteLine(item); } // 1 2 4 5
        }

        static public void lastApplication()
        {
            // the order is not necessary la7a9ash aslan l hash set makat htamch bl order f insertion
            HashSet <int> set1 = new HashSet<int> {3 , 1, 2};
            HashSet <int> set2 = new HashSet<int> { 2 , 1, 3};
            Console.WriteLine($"set1 equal set2 {set1.SetEquals(set2)}"); // true
            HashSet<int> set3 = new HashSet<int> { 3, 4, 5, 1, 2 };
            Console.WriteLine($"set2 part of set3 {set2.IsSubsetOf(set3)}"); // true
            Console.WriteLine($"set2 part of set3 {set3.IsSupersetOf(set2)}"); // true //the line before and this are the same
            Console.WriteLine($"set3 part of set2 {set3.IsSubsetOf(set2)}"); //false
            HashSet<int> set4 = new HashSet<int> { 4 , 10};
            Console.WriteLine($"set3 intersect with set4 {set3.Overlaps(set4)}"); // true intersect in 4
            set4.Remove(4);
            Console.WriteLine($"set3 intersect with set4 {set3.Overlaps(set4)}"); // false
        }

    }
}
