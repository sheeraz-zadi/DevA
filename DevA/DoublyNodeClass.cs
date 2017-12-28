using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class DoublyNodeClass : RunableClass
    {

        public class CompareClass<T>
        {
            public Func<T, T, bool> isBiggerThan { get; set; }
            public Func<T, T, bool> isSameAs { get; set; }

            public CompareClass(Func<T, T, bool> biggerThan, Func<T, T, bool> same)
            {
                isBiggerThan = biggerThan;
                isSameAs = same;
            }
        }

        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Prev { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }

        public class NodeTree<T>
        {
            public Node<T> Root { get; set; }
            public Node<T> End { get; set; }
            public CompareClass<T> Compare { get; set; }
            public NodeTree(Func<T, T, bool> biggerThan, Func<T, T, bool> same)
            {
                Compare = new CompareClass<T>(biggerThan, same);
            }

            public void Add(T val)
            {
                Node<T> inNode = Root;
                Node<T> newNode = new Node<T>(val);

                if (inNode == null)
                {
                    Root = new Node<T>(val);
                    End = Root;
                }
                else if (Compare.isBiggerThan(inNode.Data, val))
                {
                    newNode.Next = inNode;
                    Root = newNode;
                }
                else
                {
                    while (inNode.Next != null && Compare.isBiggerThan(val, inNode.Next.Data))
                    {
                        inNode = inNode.Next;
                    }

                    Node<T> nextNode = inNode.Next;

                    newNode.Next = nextNode;
                    
                    inNode.Next = newNode;
                    newNode.Prev = inNode;

                    if (nextNode == null)
                    {
                        End = newNode;
                    }
                    else {
                        nextNode.Prev = newNode;
                    }
                }
            }

            public Node<T> Search(T val)
            {
                Node<T> inNode = Root;

                while (inNode != null)
                {
                    if (Compare.isSameAs(inNode.Data, val))
                    {
                        return inNode;
                    }
                    inNode = inNode.Next;
                }

                return inNode;
            }

            public void InsertBeginning(T val) {
                Node<T> inNode = Root;
                Node<T> newNode = new Node<T>(val);

                if (inNode == null)
                {
                    Root = newNode;
                    End = newNode;
                }
                else
                {
                    newNode.Next = inNode;
                    inNode.Prev = newNode;
                    Root = newNode;
                }
            }

            public void InsertEnd(T val) {

                Node<T> inNode = End;
                Node<T> newNode = new Node<T>(val);

                if (inNode == null) {
                    Root = newNode;
                    End = newNode;
                }
                else
                {
                    newNode.Prev = inNode;
                    inNode.Next = newNode;
                    End = newNode;
                }
            }

            public void InsertAfter(Node<T> inNode, T val) {

                Node<T> newNode = new Node<T>(val);
                newNode.Next = inNode.Next;
                newNode.Prev = inNode;

                inNode.Next = newNode;

                if (newNode.Next != null) {
                    newNode.Next.Prev = newNode;
                }
                
            }

            public void InsertBefore(Node<T> inNode, T val)
            {
               
                Node<T> newNode = new Node<T>(val);
                newNode.Prev = inNode.Prev;
                newNode.Next = inNode;

                inNode.Prev = newNode;

                if (newNode.Prev != null)
                {
                    newNode.Prev.Next = newNode;
                }

            }

            public void Delete(T val)
            {
                Node<T> inNode = Search(val);
                if (inNode == null)
                {
                    Console.WriteLine("Value Not Found");
                }
                else {
                    if (inNode.Prev != null) {
                        inNode.Prev.Next = inNode.Next;
                    }
                    if (inNode.Next != null) {
                        inNode.Next.Prev = inNode.Prev;
                    }
                    inNode = null;
                }
            }
        }

        public void Run()
        {
            
            NodeTree<int> intNodeTree = new NodeTree<int>((x, y) => x > y, (x, y) => x == y);
            intNodeTree.Add(5);
            intNodeTree.Add(7);
            intNodeTree.Add(2);
            intNodeTree.Add(4);
            intNodeTree.Add(3);

            intNodeTree.InsertBeginning(100);
            intNodeTree.InsertEnd(1);
            
            Node<int> searchIntNode = intNodeTree.Search(5);

            intNodeTree.InsertAfter(searchIntNode, 6);
            intNodeTree.InsertBefore(searchIntNode, 30);

            intNodeTree.Delete(30);

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
