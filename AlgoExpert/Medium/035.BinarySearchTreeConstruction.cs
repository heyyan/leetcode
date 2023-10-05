using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class BinarySearchTreeConstruction
    {
        //input [[1,2],[3,5],[4,7],[6,8],[9,10]]
        // output [[1,2],[3,8],[9,10]]
        public void RunSolution()
        {
            //var r = mergeOverLappingIntervals2(new int[,] { { 1, 2 }, { 3, 5 }, { 4, 7 }, { 6, 8 }, { 9, 10 } });
            var r = binarySearchTreeConstruction(10);
        }

        private object binarySearchTreeConstruction(int root)
        {
            var bst = new BinarySearchTree<int>(root);
            bst.Insetion(new Node<int>(5));
            //bst.Insetion(new Node<int>(15));
            //bst.Insetion(new Node<int>(2));
            //bst.Insetion(new Node<int>(5));
            //bst.Insetion(new Node<int>(13));
            //bst.Insetion(new Node<int>(22));
            //bst.Insetion(new Node<int>(1));
            //bst.Insetion(new Node<int>(14));
            bst.Deletion(bst.Root, 10);
            return bst;
        }

        public class BinarySearchTree<T>
        {
            public Node<T> Root { get; set; }
            public BinarySearchTree(T val)
            {
                Root = new Node<T>(val);
            }

            public void Insetion(Node<T> newNode)
            {
                if (Root == null)
                {
                    Root = newNode;
                };
                Node<T> currentNode = Root;

                while (currentNode != null)
                {
                    if (Comparer<T>.Default.Compare(newNode.value, currentNode.value) < 0)
                    {
                        if (currentNode.Left != null)
                        {
                            currentNode = currentNode.Left;
                        }
                        else
                        {
                            currentNode.Left = newNode;
                            break;
                        }

                    }
                    else
                    {
                        if (currentNode.Right != null)
                        {
                            currentNode = currentNode.Right;
                        }
                        else
                        {
                            currentNode.Right = newNode;
                            break;
                        }
                    }
                }
            }

            public Node<T> Seach(int Value)
            {
                if (Root == null) return null;
                Node<T> currentNode = Root;

                while (currentNode != null)
                {
                    if (currentNode.value.Equals(Value)) return currentNode;
                    if (Value.CompareTo(currentNode.value) >= 0)
                    {
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                return currentNode;
            }

            public bool Deletion(Node<T> root, int value, Node<T> ParentNode = null)
            {
                Node<T> currentNode = root;
                while (currentNode != null)
                {
                    if (value.CompareTo(currentNode.value) < 0)
                    {
                        ParentNode = currentNode;
                        currentNode = currentNode.Left;
                    }
                    else if (value.CompareTo(currentNode.value) > 0)
                    {
                        ParentNode = currentNode;
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        // Node that has two children nodes
                        // find the smallest value in the right sub tree
                        // and replace the value of the deleting nodes value
                        // and remove that node
                        if (currentNode.Left != null && currentNode.Right != null)
                        {
                            currentNode.value = GetMinValue(currentNode.Right);
                            Deletion(currentNode.Right,int.Parse(currentNode.value.ToString()), currentNode);
                        }
                        else if (ParentNode == null) // we are gonna come back to root node case
                        {
                            // when we dont have 2 child nodes
                            // we have 2 subcases
                            // 1. we are dealing with the node that donest have parent node (root)
                            // 2. we are dealing with a node with a parent node.
                            if (currentNode.Left != null)
                            {
                                currentNode.value = currentNode.Left.value;
                                currentNode.Right = currentNode.Left.Right;
                                currentNode.Left = currentNode.Left.Left;
                            }
                            else if (currentNode.Right != null)
                            {
                                currentNode.value = currentNode.Right.value;
                                currentNode.Left = currentNode.Right.Right;
                                currentNode.Right = currentNode.Right.Left;
                            }
                            else
                            {
                                // removing root node and it doesnt have children
                                currentNode = null;
                            }

                        }
                        else if (ParentNode.Left == currentNode)
                        {
                            if (currentNode.Left != null)
                            {
                                ParentNode.Left = currentNode.Left;
                            }
                            else
                            {
                                ParentNode.Left = currentNode.Right;
                            }
                        }
                        else if (ParentNode.Right == currentNode)
                        {
                            if (currentNode.Right != null)
                            {
                                ParentNode.Right = currentNode.Left;
                            }
                            else
                            {
                                ParentNode.Right = currentNode.Right;
                            }
                        }
                        break;
                    }
                }
                return true;
            }
            private T GetMinValue(Node<T> node)
            {
                Node<T> current = node;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current.value;
            }

            private T findSmalletRightValue(Node<T> node)
            {
                Node<T> currentNode = node.Right;
                while (currentNode.Left != null)
                {
                    currentNode = currentNode.Left;
                }
                return currentNode.value;
            }

            private T findLargestRightValue(Node<T> node)
            {
                Node<T> currentNode = node.Left;
                while (currentNode.Right != null)
                {
                    currentNode = currentNode.Right;
                }
                return currentNode.value;
            }

            private void LeftRotaion(Node<T> node)
            {
                // node =10
                // node 
                Node<T> left = node.Left;
            }

            private void RightRotation(Node<T> node)
            {

            }
        }

        public class Node<T>
        {
            public T value;
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public Node(T value)
            {
                this.value = value;
            }
        }
    }
}
