using System;

namespace Lesson_5_1
{
    class Program
    {
        static void Main()
        {
            BinaryTree tree = new BinaryTree();
            tree.AddItem(10);
            tree.AddItem(9);
            tree.AddItem(11);
            tree.AddItem(8);
            tree.AddItem(12);
            tree.AddItem(10);

            // BFS
            TestCase testCaseBFS = new TestCase { InputTree = tree, ExpectedResult = new int[6]};
            testCaseBFS.ExpectedResult[0] = 10;
            testCaseBFS.ExpectedResult[1] = 9;
            testCaseBFS.ExpectedResult[2] = 11;
            testCaseBFS.ExpectedResult[3] = 8;
            testCaseBFS.ExpectedResult[4] = 10;
            testCaseBFS.ExpectedResult[5] = 12;
            Test.TestBFS(testCaseBFS);

            // DFS
            TestCase testCaseDFS = new TestCase { InputTree = tree, ExpectedResult = new int[6] };
            testCaseDFS.ExpectedResult[0] = 10;
            testCaseDFS.ExpectedResult[1] = 9;
            testCaseDFS.ExpectedResult[2] = 8;
            testCaseDFS.ExpectedResult[3] = 10;
            testCaseDFS.ExpectedResult[4] = 11;
            testCaseDFS.ExpectedResult[5] = 12;
            Test.TestDFS(testCaseDFS);
        }
    }
}
