using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class DijkstraClass : RunableClass
    {

        public class Vertex<T> {
            public GraphNode<T> Edge { get; set; }
            public int Weight { get; set; }

            public Vertex(GraphNode<T> edge, int weight) {
                Edge = edge;
                Weight = weight;
            }
        }
        
        public class GraphNode<T>
        {
            public T Value { get; set; }
            public List<Vertex<T>> Vertices { get; set; }

            public int Distance { get; set; }
            public GraphNode<T> Parent { get; set; }

            public GraphNode(T val)
            {
                Vertices = new List<Vertex<T>>();
                Value = val;
            }
        }

        public class queueList<T>
        {

            public class queueNode<T>
            {
                public GraphNode<T> Data { get; set; }
                public queueNode<T> Next { get; set; }

                public queueNode(GraphNode<T> data)
                {
                    Data = data;
                }
            }
            public queueNode<T> queue { get; set; }

            public GraphNode<T> DeQueue()
            {
                GraphNode<T> data = null;

                if (queue != null)
                {
                    data = queue.Data;
                    queue = queue.Next;

                }
                else
                {
                    queue = null;
                }

                return data;
            }

            public void EnQueue(GraphNode<T> val)
            {
                queueNode<T> root = queue;
                if (root == null)
                {
                    queue = new queueNode<T>(val);
                }
                else
                {
                    while (root.Next != null)
                    {
                        root = root.Next;
                    }

                    root.Next = new queueNode<T>(val);
                }

            }
            
        }

        public GraphNode<T> getNodeWithSmallestDist<T>(List<GraphNode<T>> vertexSet) {

            GraphNode<T> graphNode = null;

            if (vertexSet.Count != 0) {

                graphNode = vertexSet[0];

                foreach (GraphNode<T> currentNode in vertexSet) {

                    if (graphNode.Distance > currentNode.Distance)
                    {
                        graphNode = currentNode;
                    }
                }
            }
            return graphNode;
        }


        public void Dijkstra<T>(List<GraphNode<T>> graph, GraphNode<T> source) {

            List<GraphNode<T>> vertexSet = new List<GraphNode<T>>();

            foreach (GraphNode<T> graphNode in graph)  {
                graphNode.Distance = int.MaxValue;
                graphNode.Parent = null;
                vertexSet.Add(graphNode);
            }
            
            source.Distance = 0;

            while (vertexSet.Count != 0) {

                GraphNode<T> graphNode = getNodeWithSmallestDist<T>(vertexSet);
                vertexSet.Remove(graphNode);

                foreach (Vertex<T> neighborVertex in graphNode.Vertices) {

                    int alt = graphNode.Distance + neighborVertex.Weight;

                    if (alt < neighborVertex.Edge.Distance) {
                        neighborVertex.Edge.Distance = alt;
                        neighborVertex.Edge.Parent = graphNode;
                    }
                }
            }
        }

        public void Run()
        {

            /*
            Visualisation of Graph
               3
            1----2
            |    |
          2 |    | 1
            3----4
               1
            */

            GraphNode<int> nodeOne = new GraphNode<int>(1);
            GraphNode<int> nodeTwo = new GraphNode<int>(2);
            GraphNode<int> nodeThree = new GraphNode<int>(3);
            GraphNode<int> nodeFour = new GraphNode<int>(4);

            nodeOne.Vertices.Add(new Vertex<int>(nodeTwo, 3));
            nodeOne.Vertices.Add(new Vertex<int>(nodeThree,2));
            nodeTwo.Vertices.Add(new Vertex<int>(nodeOne, 3));
            nodeTwo.Vertices.Add(new Vertex<int>(nodeFour, 1));
            nodeThree.Vertices.Add(new Vertex<int>(nodeOne,2));
            nodeThree.Vertices.Add(new Vertex<int>(nodeFour,1));
            nodeFour.Vertices.Add(new Vertex<int>(nodeTwo,1));
            nodeFour.Vertices.Add(new Vertex<int>(nodeThree,1));

            List<GraphNode<int>> graph = new List<GraphNode<int>>();
            graph.Add(nodeOne);
            graph.Add(nodeTwo);
            graph.Add(nodeThree);
            graph.Add(nodeFour);

            Dijkstra(graph, nodeOne);

            Console.WriteLine("DONE");

        }
    }
}
