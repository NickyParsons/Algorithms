using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_4_2
{
    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }

        public static int GetDepth(ITree tree)
        {
            int maxDepth = -1;
            if (tree.GetRoot() != null)
            {
                Queue<NodeInfo> bufer = new Queue<NodeInfo>();
                NodeInfo root = new NodeInfo() { Node = tree.GetRoot(), Depth = 0 };
                bufer.Enqueue(root);
                while (bufer.Count != 0)
                {
                    NodeInfo element = bufer.Dequeue();
                    maxDepth = element.Depth;
                    int depth = element.Depth + 1;
                    if (element.Node.LeftChild != null)
                    {
                        NodeInfo left = new NodeInfo()
                        {
                            Node = element.Node.LeftChild,
                            Depth = depth,
                        };
                        bufer.Enqueue(left);
                    }
                    if (element.Node.RightChild != null)
                    {
                        NodeInfo right = new NodeInfo()
                        {
                            Node = element.Node.RightChild,
                            Depth = depth,
                        };
                        bufer.Enqueue(right);
                    }

                }
            }
            return maxDepth;
        }
        public static TreeNode[] GetTreeInArray(ITree tree)
        {
            int maxDepth = GetDepth(tree) + 1;
            int arraySize = Convert.ToInt32(Math.Pow(2, maxDepth)) - 1;
            TreeNode[] returnArray = new TreeNode[arraySize];
            TreeNode root = tree.GetRoot();
            if (root != null)
            {
                returnArray[0] = root;
            }
            for (int i = 0; i < arraySize; i++)
            {
                TreeNode element = returnArray[i];
                if (element != null)
                {
                    if (element.LeftChild != null)
                    {
                        returnArray[((i + 1) * 2) - 1] = element.LeftChild;
                    }
                    if (element.RightChild != null)
                    {
                        returnArray[((i + 1) * 2)] = element.RightChild;
                    }
                }
            }
            return returnArray;
        }
        public static string FormatNode(TreeNode node)
        {
            if (node == null)
            {
                return "[---]";
            }
            else
            {
                string str = node.Value.ToString();
                if (str.Length == 1)
                {
                    return $"[ {str} ]";
                }
                else if (str.Length == 2)
                {
                    return $"[ {str}]";
                }
                else
                {
                    return $"[{str}]";
                }
            }
        }
        
        public static BinaryTree GenerateTree(int elementsCount)
        {
            int[] valuesArray = new int[elementsCount];
            for (int i = 0; i < elementsCount; i++)
            {
                valuesArray[i] = new Random().Next(0, 9);
            }
            Console.Write("Значения дерева будут: ");
            foreach (int item in valuesArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine();
            BinaryTree tree = new BinaryTree();
            foreach (int value in valuesArray)
            {
                tree.AddItem(value);
            }
            return tree;
        }
    }
}
