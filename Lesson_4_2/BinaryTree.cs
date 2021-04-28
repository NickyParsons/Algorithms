using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_4_2
{
    public class BinaryTree : ITree
    {
        private TreeNode _root;
        public void AddItem(int value)
        {
            TreeNode newNode = new TreeNode();
            newNode.Value = value;
            // Если дерево пустое
            if (this.GetRoot() == null)
            {
                this._root = newNode;
            }
            // Если есть корень
            else
            {
                AddItem(newNode, this._root);
            }
        }
        void AddItem(TreeNode insertNode, TreeNode currentNode)
        {
            // Вставка в левую ноду
            if (insertNode.Value <= currentNode.Value)
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = insertNode;
                    insertNode.Parrent = currentNode;
                }
                else
                {
                    AddItem(insertNode, currentNode.LeftChild);
                }
            }
            // Вставка в правую ноду
            else
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = insertNode;
                    insertNode.Parrent = currentNode;
                }
                else
                {
                    AddItem(insertNode, currentNode.RightChild);
                }
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            return FindInNode(value, this.GetRoot());
            
        }
        TreeNode FindInNode(int searchValue, TreeNode node)
        {
            TreeNode returnNode = null;
            if (searchValue == node.Value)
            {
                returnNode = node;
            }
            else if (searchValue < node.Value)
            {
                if (node.LeftChild != null)
                {
                    returnNode = FindInNode(searchValue, node.LeftChild);
                }
            }
            else
            {
                if (node.RightChild != null)
                {
                    returnNode = FindInNode(searchValue, node.RightChild);
                }
            }
            return returnNode;
        }

        public TreeNode GetRoot()
        {
            if (this._root != null)
            {
                return _root;
            }
            else
            {
                return null;
            }
        }

        public void PrintTree()
        {
            if (GetRoot() != null)
            {
                Console.WriteLine("Дерево:");
                TreeNode[] nodeArray = TreeHelper.GetTreeInArray(this);
                int maxDepth = TreeHelper.GetDepth(this);
                int currentDepth = 0;
                for (int i = maxDepth - currentDepth; i >= 0; i--)
                {
                    int min = Convert.ToInt32(Math.Pow(2, currentDepth));
                    int max = min + min - 1;
                    int spacerSize = ((Convert.ToInt32(Math.Pow(2, i))) - 1) * 3;

                    Console.Write(new string(' ', spacerSize));
                    for (int j = min - 1; j < max; j++)
                    {
                        Console.Write(TreeHelper.FormatNode(nodeArray[j]));
                        Console.Write(new string(' ', spacerSize * 2 + 1));
                    }
                    currentDepth++;
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Дерево пустое.");
            }
            Console.WriteLine();
        }

        public void RemoveItem(int value)
        {
            TreeNode nodeToDelete = GetNodeByValue(value);
            RemoveNode(nodeToDelete);

        }
        void RemoveNode(TreeNode deleteNode)
        {
            if (deleteNode != null)
            {
                if (deleteNode.LeftChild != null)
                {
                    RemoveNode(deleteNode.LeftChild);
                    deleteNode.LeftChild = null;
                }
                if (deleteNode.RightChild != null)
                {
                    RemoveNode(deleteNode.RightChild);
                    deleteNode.RightChild = null;
                }
                if (deleteNode == GetRoot())
                {
                    _root = null;
                }
                // Удаление связи у родительской ноды
                else
                {
                    if (deleteNode.Value <= deleteNode.Parrent.Value)
                    {
                        deleteNode.Parrent.LeftChild = null;
                    }
                    else
                    {
                        deleteNode.Parrent.RightChild = null;
                    }
                }
            }
        }
    }
}
