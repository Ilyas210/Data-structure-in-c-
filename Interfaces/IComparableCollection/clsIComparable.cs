using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IComparableCollection
{
    internal class person : IComparable<person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(person? other)
        {
           if (other == null) return 1;

           return Age.CompareTo(other.Age);
        }

        public person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} {Age} years old";
        }
    }
}
