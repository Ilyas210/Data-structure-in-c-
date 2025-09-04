using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsperson
    {
        public int id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public List <string> Hobbies { get; set; }

        public clsperson(int id, string name, int age, List<string> lst) 
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.Hobbies = lst;
        }

        public override string ToString()
        {
            return $"{id} name = {name} age = {age} hobbies :" + string.Join("-", Hobbies);
        }
    }
}
