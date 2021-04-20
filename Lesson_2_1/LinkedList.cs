using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_2_1
{
    class LinkedList : ILinkedList
    {
        private Node head;
        private Node tail;
        public void AddNode(int value)
        {
            Node newNode = new Node();
            newNode.Value = value;
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                newNode.PrevNode = this.tail;
                this.tail.NextNode = newNode;
            }
            this.tail = newNode;
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node();
            newNode.Value = value;
            if (node.NextNode == null)
            {
                newNode.PrevNode = node;
                node.NextNode = newNode;
                this.tail = newNode;
            }
            else
            {
                Node tempNode = node.NextNode;
                node.NextNode = newNode;
                tempNode.PrevNode = newNode;
                newNode.PrevNode = node;
                newNode.NextNode = tempNode;
            }
        }

        public Node FindNode(int searchValue)
        {
            if (this.head == null)
            {
                return null;
            }
            Node currentNode = this.head;
            do
            {
                if (currentNode.Value == searchValue)
                {
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            } while (currentNode != null);
            return null;
        }

        public Node GetNode(int index)
        {
            if (index >= this.GetCount())
            {
                throw new ArgumentOutOfRangeException();
            }
            Node currentNode = this.head;
            int count = 0;
            while (count != index)
            {
                currentNode = currentNode.NextNode;
                count++;
            }
            return currentNode;
        }

        public int GetCount()
        {
            int count = 0;
            if (this.head != null)
            {
                Node currentNode = head;
                count = 1;
                while (currentNode.NextNode != null)
                {
                    currentNode = currentNode.NextNode;
                    count++;
                }
            }
            return count;
        }

        public void RemoveNode(int index)
        {
            Node nodeToDelete = this.GetNode(index);
            this.RemoveNode(nodeToDelete);
        }

        public void RemoveNode(Node node)
        {
            if (node == this.head)
            {
                if (node.NextNode == null)
                {
                    this.head = null;
                }
                else
                {
                    Node nextNode = node.NextNode;
                    node.NextNode = null;
                    nextNode.PrevNode = null;
                    this.head = nextNode;
                }
            }
            else
            {
                Node prevNode = node.PrevNode;
                node.PrevNode = null;
                if (node.NextNode == null)
                {
                    prevNode.NextNode = null;
                }
                else
                {
                    Node nextNode = node.NextNode;
                    node.NextNode = null;
                    prevNode.NextNode = nextNode;
                    nextNode.PrevNode = prevNode;
                }
            }
        }
    }
}
