using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class NodeClass : RunableClass
    {
        public class CompareClass<T> {

            public Func<T, T, bool> isBiggerThan{ get; set; }
            public Func<T, T, bool> isSameAs { get; set; }

            public CompareClass(Func<T, T, bool> biggerThan, Func<T, T, bool> same) {
                isBiggerThan = biggerThan;
                isSameAs = same;
            }
        }

        public class Node<T> {
            public T Data { get; set; }
            public Node<T> Next { get; set; }

            public Node(T data) {
                Data = data;
            }
        }
        
        public class NodeTree<T>{
            public Node<T> Root { get; set; }
            public CompareClass<T> Compare { get; set; }
            public NodeTree(Func<T, T, bool> biggerThan,Func<T, T, bool> same) {
                Compare = new CompareClass<T>(biggerThan, same);
            }

            public void Add(T val) {
                Node<T> inNode = Root;
                Node<T> newNode = new Node<T>(val);

                if (inNode == null)
                {
                    Root = new Node<T>(val);
                } else if (Compare.isBiggerThan(inNode.Data, val)) {
                    
                    newNode.Next = inNode;
                    Root = newNode;
                }
                else {

                    while (inNode.Next != null && Compare.isBiggerThan(val, inNode.Next.Data)) {
                        inNode = inNode.Next;
                    }

                    Node<T> nextNode = inNode.Next;
                    newNode.Next = nextNode;
                    inNode.Next = newNode;
                    
                }
            }
            
            public Node<T> Search(T val) {
                Node<T> inNode = Root;

                while (inNode != null) {
                    if (Compare.isSameAs(inNode.Data, val)) {
                        return inNode;
                    }
                    inNode = inNode.Next;
                }

                return inNode;
            }
        }

        public void Run() {

            NodeTree<int> intNodeTree = new NodeTree<int>((x, y) => x > y, (x, y) => x == y);
            intNodeTree.Add(5);
            intNodeTree.Add(7);
            intNodeTree.Add(2);
            intNodeTree.Add(4);
            intNodeTree.Add(3);

            Node<int> searchIntNode = intNodeTree.Search(5);


            NodeTree<string> stringNodeTree = new NodeTree<string>((x, y) => { return string.Compare(x, y) == 1; }, (x, y) => x == y);
            stringNodeTree.Add("F");
            stringNodeTree.Add("G");
            stringNodeTree.Add("B");
            stringNodeTree.Add("A");
            stringNodeTree.Add("D");

            Node<string> searchStringNode = stringNodeTree.Search("B");

            Console.WriteLine("DONE");
        }
    }
}
