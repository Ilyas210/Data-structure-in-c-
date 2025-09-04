using Interfaces.Collections;
using Interfaces.Collections2;
using Interfaces.ICollection;
using Interfaces.IComparableCollection;
using Interfaces.IList_gen;

// ---- IEnumerbale
//clsIEnumerable items = new clsIEnumerable();
//foreach (var item in items)
//{
//    Console.WriteLine(item);
//}
// compile to
//      |
//var enumerator = items.GetEnumerator();
//while (enumerator.MoveNext())
//{
//    var item = enumerator.Current;
//    Console.WriteLine(item);
//}

//clsGIEnumerable<int> it = new clsGIEnumerable<int>();
//it.Add(1);
//it.Add(2);
//it.Add(3);
//foreach(var item in it)
//    { Console.WriteLine(item); }


//ArrayCollection<int> itemss = new ArrayCollection<int>(2);
//itemss.Add(0);
//itemss.Add(1);
//itemss.Add(1);
//itemss.Remove(0);

//foreach (var item in itemss)
//    Console.WriteLine(item);

// ---- IList
//IListCollection<int> collection = new IListCollection<int> { 0 , 1, 2, 3};
//Console.WriteLine($"{collection[3]}\n");
//collection.RemoveAt(0);
//foreach ( int i in collection )
//    Console.WriteLine(i);

// ----- IComparable

List <person> ps = new List<person>() { new person("Ilyas", 25), new person("Riyad", 19), new person("Akram", 12)};
person p1 = new person("Ilyas", 25);
person p2 = new person("Hmida", 30);

if (p1.CompareTo(p2) > 0)
    Console.WriteLine($"{p1.Name} greater than {p2.Name}");
else
    Console.WriteLine($"{p2.Name} greater than {p1.Name}");
Console.WriteLine();

var orderper = ps.Order(); // it uses my compare to to sort my list that why the list automatically sorted by age
foreach( person p in orderper) Console.WriteLine(p.ToString());
Console.WriteLine("-----------------------------------");
var orderper2 = ps.OrderBy(x => x.Name);
foreach( person p in orderper) Console.WriteLine(p.ToString());



