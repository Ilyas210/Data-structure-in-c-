using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clsObservableCollection
    {
        static public void Application()
        {
            ObservableCollection<string> Items = new ObservableCollection<string>();
            Items.CollectionChanged += Item_CollectionChanged;
            Items.Add("Item 1");
            Items.Add("Item 2");
            Items.Add("Item 3");

            //Items.RemoveAt(1);
            Items.Insert(0, "Item 0");
            Items[1] = "here we go";
            Items.Move(1, 3);  // item 0 -> item 2 -> item3 -> here we go
            Console.WriteLine($"\n {Items[0]}");
            Console.WriteLine($"\n {Items[1]}");
            Console.WriteLine($"\n {Items[2]}");
            Console.WriteLine($"\n {Items[3]}");
            Items.Clear();
        }

        static void Item_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("\nCollection Changed");
            
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Added:");
                    foreach(var newitem in e.NewItems)
                        Console.WriteLine("- " + newitem);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Removed:");
                    Console.WriteLine($"{e.NewStartingIndex}");
                    foreach (var oldItem in e.OldItems)
                        Console.WriteLine("- " + oldItem);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Replaced");
                    foreach(var oldItem in e.OldItems)
                        Console.WriteLine("- " + oldItem);
                    Console.WriteLine("with:");
                    foreach (var newItem in e.NewItems)
                        Console.WriteLine("- " + newItem);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    Console.WriteLine("Moved:");
                    Console.WriteLine($"- From index {e.OldStartingIndex} to index {e.NewStartingIndex}");
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                        Console.WriteLine("the items cleared");
                        break;
            }
        }
    }
}
