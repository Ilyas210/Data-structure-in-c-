using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_in_ds
{
    internal class clshashtable
    {
        static public void application()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("key1", "value1");
            hashtable.Add('a', 64);
            hashtable.Add(1, "value2");
            hashtable.Add("key2", "value22");

            foreach (DictionaryEntry key in hashtable)
            {
                Console.WriteLine($"key = {key.Key}, value = {key.Value}"); //unordred
            }
        }
    }
}
