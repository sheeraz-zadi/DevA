using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class BinaryTreeClass : RunableClass
    {
        BinaryTree binaryTree;
        public void Run()
        {
            binaryTree = new BinaryTree();
            binaryTree.Root = new Node(5);
            binaryTree.Add(4);
            binaryTree.Add(6);
            binaryTree.Add(3);
            binaryTree.Add(2);
            binaryTree.Add(9);
            binaryTree.Add(7);
            binaryTree.Add(5);

            Node searchNode = binaryTree.Search(7, binaryTree.Root);


            binaryTree.Delete(2);

            Console.Write("");
        }

        public class BinaryTree {
            public Node Root { get; set; }

            public BinaryTree() {
            }

            public Node FindSuccessor(Node inNode) {
                if (inNode.Left == null)
                {
                    return FindPreDecessor(inNode);
                }
                else {
                    inNode = inNode.Left;
                    while (inNode.Right != null) {
                        inNode = inNode.Right;
                    }
                    return inNode;
                }
            }

            public Node FindPreDecessor(Node inNode) {
                if (inNode.Right == null)
                {
                    //No Successor or Predecessor
                    return null;
                }
                else
                {
                    inNode = inNode.Right;
                    while (inNode.Left != null)
                    {
                        inNode = inNode.Left;
                    }
                    return inNode;
                }
            }

            public void Delete(int val) {

                Node inNode = Root;
                if (inNode == null)
                {
                    Console.WriteLine("val does not exsist in node");
                    return;
                }

                while (inNode != null) {

                    if (inNode.Value > val)
                    {
                        Console.WriteLine("Val:" + val + " Is smaller then " + inNode.Value);
                        inNode = inNode.Left;
                        // Go Left
                    }
                    else if (inNode.Value < val)
                    {
                        Console.WriteLine("Val:" + val + " Is bigger then " + inNode.Value);
                        inNode = inNode.Right;
                        // Go Right
                    }
                    else
                    {
                        Console.WriteLine("Val:" + val + " Is " + inNode.Value);
                        if (inNode.Left == null && inNode.Right == null)
                        {
                            // Deletion of leaf
                            Console.WriteLine("Val:" + val + " Has no childeren");
                            inNode = null;
                        }
                        else if (inNode.Left != null || inNode.Right != null)
                        {
                            if (inNode.Left != null && inNode.Right != null)
                            {
                                // Deletion child with two childeren
                                Console.WriteLine("Val:" + val + " Has 2 childeren");
                                Console.Write("TODO");

                            }
                            else
                            {
                                // Deletion node with one child

                                if (inNode.Left != null)
                                {
                                    Console.WriteLine("Val:" + val + " Has left child");
                                    inNode = inNode.Left;
                                }
                                else
                                {
                                    Console.WriteLine("Val:" + val + " Has right child");
                                    inNode = inNode.Right;
                                }
                            }
                        }
                    }
                }
            }

            public Node Search(int val, Node inNode) {

                if (inNode == null) {
                    return null;
                }

                if (inNode.Value == val) {
                    return inNode;
                } else if (inNode.Value < val) {
                    return Search(val, inNode.Right);
                } else{
                    return Search(val, inNode.Left);
                }
                
            }

            public void Add(int val, Node inNode = null) {
                if (inNode == null) {
                    inNode = Root;
                }

                if (inNode.Value < val) {
                    if (inNode.Right == null)
                    {
                        inNode.Right = new Node(val);
                    }
                    else {
                        Add(val, inNode.Right);
                    }
                }
                else if (inNode.Value > val)
                {
                    if (inNode.Left == null)
                    {
                        inNode.Left = new Node(val);
                    }
                    else
                    {
                        Add(val, inNode.Left);
                    }
                }
            }
        }

        public class Node {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int val) {
                Value = val;
            }
        }
    }
}
