using System;

namespace Lesson_6_1
{
    class Program
    {
        static void Main()
        {
            // Создание графа
            Node node1 = new Node { Value = 1 };
            Node node2 = new Node { Value = 2 };
            Node node3 = new Node { Value = 3 };
            Node node4 = new Node { Value = 4 };
            Node node5 = new Node { Value = 5 };
            Node node6 = new Node { Value = 6 };
            Node node7 = new Node { Value = 7 };
            Graph.DualLinkNodes(node1, node2, 1);
            Graph.DualLinkNodes(node1, node3, 1);
            Graph.DualLinkNodes(node2, node4, 1);
            Graph.DualLinkNodes(node3, node4, 1);
            Graph.DualLinkNodes(node2, node5, 1);
            Graph.DualLinkNodes(node3, node6, 1);
            Graph.DualLinkNodes(node5, node6, 1);
            Graph.DualLinkNodes(node3, node7, 1);

            // Тесты
            TestCase testCaseBFS = new TestCase { InputNode = node1, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7 } };
            Tests.TestBFS(testCaseBFS);
            TestCase testCaseDFS = new TestCase { InputNode = node1, ExpectedResult = new int[] { 1, 3, 7, 6, 5, 2, 4 } };
            Tests.TestDFS(testCaseDFS);
        }
    }
}
