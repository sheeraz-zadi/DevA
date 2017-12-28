using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class HashTableWithNode : RunableClass
    {

        public class Node {
            public string Value { get; set; }
            public Node Next { get; set; }

            public Node(string val) {
                Value = val;

            }
        }

        public class NodeTree {

            public Node Start { get; set; }

            public void Add(string val) {

                Node newNode = new Node(val);

                if (Start == null)
                {
                    Start = newNode;
                }
                else {
                    int result = string.Compare(Start.Value, newNode.Value);
                    Node inNode = Start;

                    if (result == 1)
                    {
                        newNode.Next = Start;
                        Start = newNode;
                    }
                    else {

                        while (inNode.Next != null && string.Compare(inNode.Next.Value, newNode.Value) != 1) {
                            inNode = inNode.Next;
                        }


                        newNode.Next = inNode.Next;
                        inNode.Next = newNode;

                    }
                }
            }

            public void Delete(string val) {

                Node inNode = Start;

                if (inNode == null)
                {
                    Console.WriteLine("Element not in Node");
                } else if (inNode.Value == val) {
                    Start = inNode.Next;
                }
                else {

                    while (inNode.Next != null) {
                        if (inNode.Next.Value == val) {
                            inNode.Next = inNode.Next.Next;
                        }
                        inNode = inNode.Next;
                    }
                }
            }
        }

        public class HashtableObject
        {
            public NodeTree[] array { get; set; }
            public int storagelimit { get; set; }

            public HashtableObject(int sl) {
                storagelimit = sl;
                array = new NodeTree[sl];
            }

            public void Add(string val) {
                int key = hash(val, storagelimit);
            
                if (array[key] == null) {
                    array[key] = new NodeTree();
                }
                array[key].Add(val);
            }

            public void Remove(string val) {
                int key = hash(val, storagelimit);

                if (array[key] == null)
                {
                    Console.WriteLine("Value is not in the list");
                }
                else {
                    array[key].Delete(val);
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

        public void Run(){

            HashtableObject hashTable = new HashtableObject(9);
            hashTable.Add("A");
            hashTable.Add("Z");
            hashTable.Add("S");
            hashTable.Add("F");
            hashTable.Add("G");
            hashTable.Add("R");
            hashTable.Add("T");
            hashTable.Add("Y");


            hashTable.Remove("S");



            Console.WriteLine("");
        }


    }
}
