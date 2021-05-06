using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6_1
{
    public class Graph
    {
        public static void DualLinkNodes(Node first, Node second, int weight)
        {
            first.Edges.Add(new Edge {Weight = weight, EndNode = second});
            second.Edges.Add(new Edge { Weight = weight, EndNode = first });
        }
        public static Node[] GetNodeArrayBFS(Node startNode)
        {
            List<Node> result = new List<Node>();
            Queue<Node> buffer = new Queue<Node>();
            if (startNode != null)
            {
                startNode.IsVisited = true;
                buffer.Enqueue(startNode);
            }
            while(buffer.Count != 0)
            {
                Node element = buffer.Dequeue();
                result.Add(element);
                foreach (Edge edge in element.Edges)
                {
                    if (!edge.EndNode.IsVisited)
                    {
                        edge.EndNode.IsVisited = true;
                        buffer.Enqueue(edge.EndNode);
                    }
                }
            }
            foreach (Node node in result)
            {
                node.IsVisited = false;
            }
            return result.ToArray();
        }
        public static Node[] GetNodeArrayDFS(Node startNode)
        {
            List<Node> result = new List<Node>();
            Stack<Node> buffer = new Stack<Node>();
            if (startNode != null)
            {    
                buffer.Push(startNode);
            }
            while (buffer.Count != 0)
            {
                Node element = buffer.Pop();
                if (!element.IsVisited)
                {
                    result.Add(element);
                    element.IsVisited = true;
                }
                foreach (Edge edge in element.Edges)
                {
                    if (!edge.EndNode.IsVisited)
                    {
                        buffer.Push(edge.EndNode);
                    }
                }
            }
            foreach (Node node in result)
            {
                node.IsVisited = false;
            }
            return result.ToArray();
        }
        public static List<Node> GetNodeArrayDFSRecursion(Node startNode)
        {
            List<Node> result = new List<Node>();
            startNode.IsVisited = true;
            result.Add(startNode);
            foreach (Edge edge in startNode.Edges)
            {
                if (!edge.EndNode.IsVisited)
                {
                   result.AddRange(GetNodeArrayDFSRecursion(edge.EndNode));
                }
            }
            return result;
            // Не могу очистить метки посещения не сломав алгоритм
        }
    }
}

