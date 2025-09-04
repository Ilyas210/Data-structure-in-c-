using List;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsSortedList
    {
        static public void application()
        {
            var list = new SortedList<string, int>();
            list.Add("ilyas", 25);
            list.Add("Riyad", 20);
            list.Add("Akram", 12);

            foreach (var item in list)
            {
                Console.WriteLine(item); // sort alphabetic a-A -> z-Z
            }

            list.Remove("ilyas");
            Console.WriteLine("result after remove ilyas : ");
            foreach(var item in list)
            {
                Console.WriteLine(string.Join(" - ", item.Key, item.Value));
            }

            list.Add("ilyas", 25);

            var selectnamewithagegreatherthan20 = from kvp in list where kvp.Value > 12 select kvp;

            Console.WriteLine("\nthe names with age greater than 12");
            foreach (var item in selectnamewithagegreatherthan20)
            {
                Console.WriteLine(string.Join(" - ", item.Key, item.Value));

            }

            var lessthan20 = list.Where(x => x.Value < 20);
            Console.WriteLine("\nthe names with age less than 20");
            foreach (var item in lessthan20)
            {
                Console.WriteLine(string.Join(" - ", item.Key, item.Value));
            }

            list.Add("zoubida", 34);
            list.Add("coco", 0);
            list.Add("mohammed", 20);
            list.Add("imane", 20);
            list.Add("meryem", 20);

            Console.WriteLine("\ngroup by length : ");

            var groupbylength = list.GroupBy(x => x.Key.Length);
            foreach (var item in groupbylength)
            {
                Console.WriteLine($"length = {item.Key} : {string.Join(" - ",item.Select(x => x.Key))}");
            }

            Console.WriteLine("\ngroup by first letter : ");
            var firstletter = list.GroupBy(x => x.Key[0]);
            foreach (var item in firstletter)
            {
                Console.WriteLine($"length = {item.Key} : {string.Join(" - ", item.Select(x => x.Key))}");
            }
        }

        static public void application2 ()
        {
            SortedList<int, clsemployee> employees = new SortedList<int, clsemployee>()
            {
            { 1, new clsemployee(1, "ilyas", 24, 4000) },
            { 2, new clsemployee(2, "akram", 30, 7000) },
            { 3, new clsemployee(3, "asmae", 22, 3500) },
            { 4, new clsemployee(4, "riyad", 28, 8000) },
            { 5, new clsemployee(5, "aymen", 34, 4500) },
            { 6, new clsemployee(5, "hmidaa", 32, 4500) }
            };

            var y = employees.GroupBy(x => x.Value.age).OrderBy(x => x.Key);
            foreach(var item in y)
                Console.WriteLine($"{item.Key}");

            Console.WriteLine("----");
            var youngestemp = employees.GroupBy(x => x.Value.age).OrderBy(x => x.Key).First();
            foreach(var employee in youngestemp)
                Console.WriteLine($"{employee.Key}   {employee.Value.name}");

            Console.WriteLine("----");
            bool empmorethan3000 = employees.Values.All(x => x.salary > 3000);
            Console.WriteLine(empmorethan3000 ? "yes the emps have a salary more than 3000" : "no");

            //gives a emp have a long name
            var empwithlonname = employees.OrderByDescending(x => x.Value.name.Length).First();
            Console.WriteLine($"{empwithlonname.Value.name}");

            //List the names of employees who are older than 30, ordered by their salary descending.
            var empolderthan30 = employees.Values.Where(e => e.age > 30).OrderByDescending(x => x.salary).Select(x => x.name);

            // Find the average salary of employees whose name starts with the letter 'A'.
            var averagesalary = employees.Values.Where(x => x.name.StartsWith("A")).Select(x => x.salary).DefaultIfEmpty().Average();

            //Get the name and age of the youngest employee(s).
            var younemployees = employees.Values.GroupBy(x => x.age).OrderBy(x => x.Key).First().Select(x => new { x.name, x.age });
            // methode2
            int minage = employees.Min(e => e.Value.age);
            var younemployees1 = employees.Values.Where(e => e.age == minage).Select(x => new { x.name, x.age });

            Console.WriteLine("--------------");
            //Get the top 3 employees with the highest salaries, showing their names and salaries.
            var highestsalary = employees.Values.OrderByDescending(x => x.salary).Take(3).Select(x => new { x.name, x.salary });
            foreach( var employee in highestsalary)
                Console.WriteLine($"{employee.name} => {employee.salary}");

            //❓Group employees by age range:
            var group = employees.Values.GroupBy(x => x.salary >= 4000);
            foreach( var employee in group)
                Console.WriteLine(employee.Key);
        }
    }
}
