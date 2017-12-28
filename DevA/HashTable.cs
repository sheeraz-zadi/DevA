using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class HashTable : RunableClass
    {

        public void Run() {

            HashtableObject hashTable = new HashtableObject();
            hashTable.storagelimit = 9;

            hashTable.array = new List<string>[hashTable.storagelimit];
            

            hashTable.Add("aasdsdsdf");
            hashTable.Add("wqeewqewq");
            hashTable.Add("opopu");
            hashTable.Add("uyyut");
            hashTable.Add("hjkkjh");

            Console.WriteLine("DONE");

        }

        public class HashtableObject{
            public List<string>[] array { get; set; }
            public int storagelimit { get; set; }

            public void Add(string val) {
                int key = hash(val, storagelimit);

                if (array[key] == null) {
                    array[key] = new List<string>();
                }
                array[key].Add(val);
            }

            public void Remove(string val) {

                int key = hash(val, storagelimit);

                if (array[key] == null)
                {
                    Console.WriteLine("Value is not in hastable");
                }
                else {
                    array[key].Remove(val);
                }
            }
        }

        public static int hash(string key, int buckets)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash += (int)c;
            }

            return hash % buckets;
        }
        
    }
}
