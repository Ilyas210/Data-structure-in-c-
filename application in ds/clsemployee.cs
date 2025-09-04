﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class clsemployee
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public double salary { get; set; }

        public Func <string> to_string;

        public clsemployee(int id, string name, int age, double salary)
        { 
            this.id = id;
            this.name = name;
            this.age = age;
            this.salary = salary;
        }

        public void subscibe(Func<string> s)
        {
            to_string = s;
        }
    }
}
