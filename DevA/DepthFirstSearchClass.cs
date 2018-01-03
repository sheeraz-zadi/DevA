using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class DepthFirstSearchClass : RunableClass
    {
       
        public class GraphNode<T>
        {
            public T value { get; set; }
            public List<GraphNode<T>> Edges { get; set; }

            public bool discoverd { get; set; }

            public GraphNode(T val)
            {
                Edges = new List<GraphNode<T>>();
                value = val;
            }
        }

        public class StackList<T>
        {
            public class StackNode<T>
            {
                public GraphNode<T> Data { get; set; }
                public StackNode<T> Next { get; set; }

                public StackNode(GraphNode<T> data)
                {
                    Data = data;
                }
            }
            public StackNode<T> stack { get; set; }

            public GraphNode<T> Peek() {
                GraphNode<T> retNode = null;

                if (stack != null)
                {
                    retNode = stack.Data;
                }

                return retNode;
            }
            public void Push(GraphNode<T> graphNode) {
                if (stack == null)
                {
                    stack = new StackNode<T>(graphNode);
                }
                else {
                    StackNode<T> newNode = new StackNode<T>(graphNode);
                    newNode.Next = stack;
                    stack = newNode;
                }
            }
            public GraphNode<T> Pop() {

                GraphNode<T> retNode = null;
                if (stack != null)
                {
                    retNode = stack.Data;
                    stack = stack.Next;
                }

                return retNode;
            }
            
        }

        public void DepthFirstSearch<T>(GraphNode<T> root) {

            StackList<T> stackList = new StackList<T>();
            stackList.Push(root);

            while (stackList.stack != null) {

                GraphNode<T> currentNode = stackList.Pop();

                if (currentNode.discoverd != true) {
                    Console.WriteLine("Visited:"+currentNode.value);

                    currentNode.discoverd = true;
                    foreach (GraphNode<T> edge in currentNode.Edges) {
                        stackList.Push(edge);
                    }
                }
            }
        }

        public void Run()
        {

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

            GraphNode<int> nodeOne = new GraphNode<int>(1);
            GraphNode<int> nodeTwo = new GraphNode<int>(2);
            GraphNode<int> nodeThree = new GraphNode<int>(3);
            GraphNode<int> nodeFour = new GraphNode<int>(4);

            nodeOne.Edges.Add(nodeTwo);
            nodeOne.Edges.Add(nodeThree);
            nodeTwo.Edges.Add(nodeOne);
            nodeTwo.Edges.Add(nodeFour);
            nodeThree.Edges.Add(nodeOne);
            nodeThree.Edges.Add(nodeFour);
            nodeFour.Edges.Add(nodeTwo);
            nodeFour.Edges.Add(nodeThree);

            List<GraphNode<int>> graph = new List<GraphNode<int>>();
            graph.Add(nodeOne);
            graph.Add(nodeTwo);
            graph.Add(nodeThree);
            graph.Add(nodeFour);

            DepthFirstSearch(nodeOne);

            Console.WriteLine("DONE");

        }
    }
}
