using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class DataStructures : RunableClass
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(int val)
            {
                Value = val;
            }
        }

        public class NodeList {
            public Node start;
            public Node end;

            void UpdateEnd() {
                Node inNode = start;
                while (inNode.Next != null) {
                    inNode = inNode.Next;
                }

                end = inNode;
            }

            public void Add(int val) {

                Node newNode = new Node(val);
                Node startNode = start;

                if (start == null)
                {
                    start = newNode;
                    end = newNode;
                }
                else if (val <= start.Value)
                {
                    start = newNode;
                    newNode.Next = startNode;
                    startNode.Prev = newNode;
                }
                else {

                    while (startNode.Next != null && startNode.Next.Value < val) {
                        startNode = startNode.Next;
                    }

                    newNode.Prev = startNode;
                    newNode.Next = startNode.Next;

                    startNode.Next = newNode;

                }
                UpdateEnd();
            }

            public Node Search(int val) {

                Node inNode = start;

                while (inNode != null && inNode.Value != val) {
                    inNode = inNode.Next;
                }

                return inNode;
                
            }

            public void Delete(int val) {
                Node inNode = start;

                if (inNode == null || val < inNode.Value)
                {
                    return;
                }
                else if (inNode.Value == val)
                {
                    start = inNode.Next;
                    start.Prev = null;
                }
                else {

                    while (inNode.Next != null && inNode.Next.Value <= val) {
                        if (inNode.Next.Value == val) {
                            inNode.Next = inNode.Next.Next;
                            inNode.Next.Prev = inNode;
                            return;
                        }
                        
                        inNode = inNode.Next;
                    }   
                }
                UpdateEnd();
            }

        }

        public void Run() {

            NodeList nodelist = new NodeList();

            nodelist.Add(4);
            nodelist.Add(8);
            nodelist.Add(9);
            nodelist.Add(2);
            nodelist.Add(3);
            nodelist.Add(10);

            Node searchNode = nodelist.Search(8);
            
            Console.WriteLine("List: ");

        }

    }
}
