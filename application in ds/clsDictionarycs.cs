using List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsDictionarycs
    {

        public class clsinfo
        {
            public string name { get; set; }
            public int age { get; set; }
            public clsinfo(string name, int age) {
                this.name = name;
                this.age = age;
            }
        }
        public static void application()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>{ { 4, "hmida"} };
            dic.Add(1, "ilyas");
            dic.Add(2, "riyad");
            dic.Add(3, "akram");
            dic.Add(5, "mama");
            foreach (var item in dic)
            {
                Console.WriteLine($"key = {item.Key}, value = {item.Value}");
            }
            Console.WriteLine();
            Dictionary<string, short> dic1 = new Dictionary<string, short>
            {
                {"ilyas", 24 },
                {"riyad", 19 },
                {"akram",  12}
            };
            dic1["ilyas"] = 25;
            Console.WriteLine(dic1.Remove("akram") ? "the pair removed sucessfuly" : "error occured");
            foreach (var item in dic1)
            {
                Console.WriteLine($"key = {item.Key}, value = {item.Value}");
            }
            if(dic.TryGetValue(1, out string s))
                Console.WriteLine($"the value is {s}");
            else
                Console.WriteLine("the value not found");
        }

        static public void application2()
        {
            clsemployee emp = new clsemployee(1, "ilyas", 25, 10000);
            clsemployee emp2 = new clsemployee(2, "aymen", 21, 9000);
            clsemployee emp3 = new clsemployee(3, "yocef", 22, 8000);

            Dictionary<int, clsemployee> table = new Dictionary<int, clsemployee>
            {
                {emp.id, emp},
                {emp2.id, emp2},
                {emp3.id, emp3},
            };

            var employees = table.Select(x => new {x.Value.name, x.Value.age }); // hada khtisar l star li darto lta7t talab meni 2anani crei class jdida
            IEnumerable<clsinfo> employees2 = table.Select(x => new clsinfo( x.Value.name, x.Value.age ));

            foreach (var item in employees)
            {
                Console.WriteLine(item.name);
            }

            
            var emps = table.Select(x => (x.Value.name, x.Value.salary)); // valuetuple (name,salary) | anonymos type new {name, salary}
            Console.WriteLine("\nemployes with age greater than 21 :");
            var values = employees.Where(x => x.age > 21);
            values.ToList().ForEach((x) => Console.WriteLine(" - " + x.name));

            Console.WriteLine("\nemployees with salary less than 10000");
            var values2 = emps.Where((x) => x.salary < 10000);
            values2 = values2.OrderBy(x => x.salary);
            foreach (var item in values2)
            {
                Console.WriteLine(" - " + item.name + " => " + item.salary);
            }
        }

        public static void application3()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                { "Banana", "Herb" },
                { "Cherry", "Tree" },
                { "Strawberry", "Bush" },
                { "Raspberry", "Bush" }
            };

            var group = dic.GroupBy(x => x.Value);
            foreach (var item in group)
            {
                Console.WriteLine($"category : {item.Key}");
                foreach (var item2 in group)
                {
                    Console.WriteLine($"- {item2.Key}");
                };
            }

            dic.Where(x => x.Key.Length > 6 || x.Value.StartsWith("T")).OrderBy(x => x.Key).ToList().
                ForEach((x) => Console.WriteLine($"- {x.Key} => {x.Value}"));
        }
    }
}
