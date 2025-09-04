using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsArray
    {
        public static void application()
        {
            int[] arr = { 1, 70, 10 , 2}; // stored in the heap
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"element {i + 1} -> value = " + arr[i]);
            }
            Console.WriteLine();
            Array.Sort(arr);
            foreach(int i in arr)
                Console.WriteLine("value = " + i);
            int index = Array.IndexOf(arr, 10);
            Console.WriteLine($"\nindex of 10 : {index}");
        }

        public static void application2()
        {
            int[,] arr = { { 1, 2, 0 }, { 10, 11, 12 } };
            
            // get_length(0) => number of lines
            // get_length(1) => number of columns
            for (int i = 0;i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                    Console.WriteLine($"line {i} colomn {j} => {arr[i, j]}");
            }
            int[,] arr2 = new int [2, 3];
            Array.Copy(arr, arr2, arr.Length);
            Console.WriteLine("\ncopy array : ");
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                    Console.WriteLine($"line {i} colomn {j} => {arr2[i, j]}");
            }
        }

        public static void application3()
        {
            // LINQ

            var arr = new[]
            {
               new {name = "meryem", age = 25},
               new {name = "riyad", age = 20},
               new {name = "Akram", age = 12},
               new{ name = "ilyas", age = 25 },
               new {name = "sami", age = 12}
            };

            var people = arr.GroupBy(x => x.age);
            foreach (var item in people)
            {
                Console.WriteLine("Age = " + item.Key);
                foreach (var item2 in item)
                { Console.WriteLine($"name = {item2.name}"); }
            }

            var people2 = arr.GroupBy(x => x.age).Select(x => new { age = x.Key, people = x.OrderBy(person => person.name) });
            foreach (var item in people2)
            {
                Console.WriteLine("Age = " + item.age);
                foreach (var item2 in item.people)
                { Console.WriteLine($"name = {item2.name}"); }
            }
        }

        static public void application4()
        {
            // join
            var employees = new[]
            {
                new {Id = 1, Name = "Ilyas", DepartmentId = 2},
                new {Id = 2, Name = "Riyad", DepartmentId = 1},
                new {Id = 2, Name = "Krimo", DepartmentId = 3}
            };

            var departments = new[]
            {
                new {Id = 1, Name = "Human Resources"},
                new {Id = 2, Name = "Devlopment"}
            };

            //methode 1
            var employeeDetails = employees.Join(departments, e => e.DepartmentId, d => d.Id,
                (e, d) => new { e.Name, Department = d.Name });

            // method 2
            var employeeDetails1 = from e in employees join d in departments 
                                   on e.DepartmentId equals d.Id select new {e.Name, Department = d.Name};
            foreach (var detail in employeeDetails)
                Console.WriteLine($"Employee: {detail.Name}, Department: {detail.Department}");
        }
    }
}
