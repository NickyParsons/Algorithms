using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_5_1
{
    public class BinaryTree
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
        public int[] GetArrayBFS()
        {
            List<int> resultArray = new List<int>();
            Queue<TreeNode> buffer = new Queue<TreeNode>();
            if (GetRoot() != null)
            {
                buffer.Enqueue(GetRoot());
            }
            while (buffer.Count != 0)
            {
                TreeNode element = buffer.Dequeue();
                resultArray.Add(element.Value);
                if (element.LeftChild != null)
                {
                    buffer.Enqueue(element.LeftChild);
                }
                if (element.RightChild != null)
                {
                    buffer.Enqueue(element.RightChild);
                }
            }
            return resultArray.ToArray();
        }
        public int[] GetArrayDFS()
        {
            List<int> resultArray = new List<int>();
            Stack<TreeNode> buffer = new Stack<TreeNode>();
            if (GetRoot() != null)
            {
                buffer.Push(GetRoot());
            }
            while (buffer.Count != 0)
            {
                TreeNode element = buffer.Pop();
                resultArray.Add(element.Value);
                if (element.RightChild != null)
                {
                    buffer.Push(element.RightChild);
                }
                if (element.LeftChild != null)
                {
                    buffer.Push(element.LeftChild);
                }
            }
            return resultArray.ToArray();
        }
    }
}
