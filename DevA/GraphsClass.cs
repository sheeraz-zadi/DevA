using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class GraphsClass : RunableClass
    {
        public class Node<T>{
            public T value { get; set; }
            public List<Node<T>> Edges { get; set; }

            public int distance { get; set; }
            public Node<T> parent { get; set; }

            public Node(T val) {
                Edges = new List<Node<T>>();
                value = val;
            }
        }

        public class queueList<T> {

            public class queueNode<T> {
                public Node<T> Data { get; set; }
                public queueNode<T> Next { get; set; }

                public queueNode(Node<T> data) {
                    Data = data;
                }
            }
            public queueNode<T> queue { get; set; }
           
            public void DeQueue()
            {
                if (queue != null)
                {
                    queue = queue.Next;
                }
                else {
                    queue = null;
                }
            }

            public void EnQueue(Node<T> val)
            {
                queueNode<T> root = queue;
                if (root == null)
                {
                    queue = new queueNode<T>(val);
                }
                else {
                    while (root.Next != null)
                    {
                        root = root.Next;
                    }

                    root.Next = new queueNode<T>(val);
                }
                
            }

            public bool isEmpty()
            {
                return queue == null;
            }

            public Node<T> peek()
            {
                if (queue != null)
                {
                    return queue.Data;
                }
                else {
                    return null;
                }
                
            }
        }


        public void BreadthFirstSearch<T>(List<Node<T>> graph, Node<T> root) {

            foreach (Node<T> node in graph) {
                node.distance = int.MaxValue;
                node.parent = null;
            }

            queueList<T> graphsQueue = new queueList<T>();

            root.distance = 0;

            graphsQueue.EnQueue(root);

            while (graphsQueue.queue != null) {

                Node<T> currentNode = graphsQueue.peek();

                if (currentNode != null) {
                    foreach (Node<T> adjascentNode in currentNode.Edges)
                    {
                        if (adjascentNode.distance == int.MaxValue)
                        {
                            adjascentNode.distance = currentNode.distance + 1;
                            adjascentNode.parent = currentNode;
                            graphsQueue.EnQueue(adjascentNode);

                        }
                    }
                }
                graphsQueue.DeQueue();
            }
            
        }


        public void Run() {

            /*
            Visualisation of Graph

            1----2
            |    |
            |    |
            3----4

             1 2 3 4
            1F T T F
            2T F F T
            3T F F T
            4F T T F

            {1,[2,3]}
            {2,[1,4]}
            {3,[1,4]}
            {4,[2,3]}
            */

            Node<int> nodeOne = new Node<int>(1);
            Node<int> nodeTwo = new Node<int>(2);
            Node<int> nodeThree = new Node<int>(3);
            Node<int> nodeFour = new Node<int>(4);
            
            nodeOne.Edges.Add(nodeTwo);
            nodeOne.Edges.Add(nodeThree);
            nodeTwo.Edges.Add(nodeOne);
            nodeTwo.Edges.Add(nodeFour);
            nodeThree.Edges.Add(nodeOne);
            nodeThree.Edges.Add(nodeFour);
            nodeFour.Edges.Add(nodeTwo);
            nodeFour.Edges.Add(nodeThree);

            List<Node<int>> graph = new List<Node<int>>();
            graph.Add(nodeOne);
            graph.Add(nodeTwo);
            graph.Add(nodeThree);
            graph.Add(nodeFour);

            BreadthFirstSearch(graph, nodeOne);
            
            Console.WriteLine("DONE");
            
        }
    }
}
