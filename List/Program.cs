using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace List
{

    public class clsperson
    {
        public int id;
        public string name;
        public int age;
        public delegate void PersonDelegate();
        public PersonDelegate printinfo;
        public clsperson (int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            printinfo = print_persinfo;
        }

        void print_persinfo()
        {
            Console.WriteLine("ID = {0}",this.id);
            Console.WriteLine("NAME = {0}", this.name);
        }
        static public void foreach1(List <clsperson> persons, Action<clsperson> action)
        {
            foreach (clsperson obj in persons)
            {
                action?.Invoke(obj);
            }
        }
    }
    
    internal class Program
    {
        public delegate bool del(int a, int b);

        public static List<int> get_values(List<int> val, int value, del operation)
        {
            List<int> output = new List<int>();
            foreach (int a in val)
            {
                if (operation(a, value)) output.Add(a);
            }
            return output;
        }
        delegate void del2(int a);
        static void Main(string[] args)
        {
            //List <clsperson> persons = new List<clsperson>() { new clsperson(1, "ilyas", 24), new clsperson(2, "riyad", 19) };
            //persons.ForEach(p => Console.WriteLine(string.Join(", ", p.id.ToString(), "name = " + p.name, "age =>" + p.age.ToString())));
            //persons.ForEach(person => Console.WriteLine(person.name));
            //foreach (clsperson per in persons)
            //    Console.WriteLine(per.name + " ok");
            //for (int i = 0; i < persons.Count; i++)
            //    Console.WriteLine(persons[i].name + "h h");

            //Action<int> p = x => { Console.WriteLine("hello {0}", x); Console.WriteLine("my name is ilyas"); };
            //p(1);
            //Program prog = new Program();
            //p(1);
            //clsperson person = new clsperson(11, "ILYAS", 24);
            //person.printinfo();

            //clsemployee employee = new clsemployee(1, "ilyas", 26, 10000);
            //employee.to_string = () => "id : " + employee.id + "name : " + 
            //employee.name + "salry => " + employee.salary;
            List<clsemployee> emps = new List<clsemployee>{ new clsemployee(1, "ilyas", 26, 10000) };
            emps.Add(new clsemployee(2, "aymen", 22, 12000));
            emps.Add(new clsemployee(3, "yocef", 24, 8000));
            emps.Add(new clsemployee(4, "hamid", 28, 11000));
            emps.ForEach(e => e.subscibe(
                () => "id : " + e.id + ", name : " 
                + e.name + ", salary => " + e.salary)
            );

            //List < clsemployee> filter_emp = emps.Where((e ,index) => e.salary >= 10000).ToList();
            //Console.WriteLine(filter_emp.Count > 0 ? "Employees with salary more than 10000dh :" : "nobody exist");
            //filter_emp.ForEach(e => Console.WriteLine(e.to_string()));
            //string name = Console.ReadLine();
            //var filter_emp = emps.Where(e => e.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            //foreach (var item in filter_emp)
            //{
            //    Console.WriteLine("Name = " + item.name);
            //    Console.WriteLine("salary = " + item.salary);
            //}

            //List<clsemployee> sort_asc = emps.OrderBy(n => n.salary).ToList();
            //sort_asc.ForEach(e => Console.WriteLine(e.name));
            emps.Sort((e, e1) => e.salary.CompareTo(e1.salary)); // it sould be understand comparison class inumerable ..
            emps.ForEach(e => Console.WriteLine(e.name));

            Console.WriteLine("name with age more than 22");
            emps.FindAll(e => e.age > 22).ForEach(e => Console.WriteLine("name : " + e.name + " age : " + e.age));
            Console.WriteLine("----------------------------------------");
            
            Console.WriteLine(emps.Any(e => e.id == 1) ? "exist" : "doesnt exist");
            Console.WriteLine("----------------------------------------");

            clsemployee ep = null;
            Console.WriteLine(emps.Exists(e => e.age > 22 && (ep = e) != null) ? $"{ep.name} has {ep.age} y old" : "no");
            Console.WriteLine("----------------------------------------");

            ep = null;
            Console.WriteLine((ep = emps.Find(e => e.id == 1)) != null ?
                $"{ep.name} with id = 1" : "an employee with id = 1 doesnt exist");
            Console.WriteLine("----------------------------------------");

            List<clsemployee> tmp_emp = emps.FindAll(e => e.salary > 10000);
            List <string> names = new List<string>();
            tmp_emp.ForEach(e => names.Add(e.name));
            Console.WriteLine("all eployees with salary more than 10000 : " + 
                string.Join(", ", names));
            Console.WriteLine("----------------------------------------");
            string[] arr = names.ToArray();
            Console.WriteLine("names = " + string.Join(" - ", arr));
            if (names.Contains("hamid"))
                Console.WriteLine("yes");

            if (names.Any(name => name.StartsWith("h")))
                Console.WriteLine("yes exist");
            Console.WriteLine("the name end with d : " + names.Any(name => name.StartsWith("h")));
            Console.ReadLine();
        }
    }
}
