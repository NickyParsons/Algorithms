using System;

namespace Lesson_4_2
{
    class Program
    {
        static void Main()
        {
            // Создание объектов для тестов
            TestCase testCase = new TestCase();
            testCase.InputTree = new BinaryTree();
            
            // Тест на добавление 1
            testCase.ExpectedResult = new int?[1];
            testCase.ExpectedResult[0] = 4;
            Test.TestAdd(testCase, 4);
            
            // Тест на удаление 1
            testCase.ExpectedResult = null;
            Test.TestRemove(testCase, 4);

            // Тест на добавление 2
            testCase.ExpectedResult = new int?[1];
            testCase.ExpectedResult[0] = 10;
            Test.TestAdd(testCase, 10);

            // Тест на добавление 3 (заведомо ложный)
            testCase.ExpectedResult = new int?[3];
            testCase.ExpectedResult[0] = 10;
            testCase.ExpectedResult[1] = 12;
            testCase.ExpectedResult[2] = null;
            Test.TestAdd(testCase, 12);

            // Тест на добавление 4
            testCase.ExpectedResult = new int?[7];
            testCase.ExpectedResult[0] = 10;
            testCase.ExpectedResult[1] = null;
            testCase.ExpectedResult[2] = 12;
            testCase.ExpectedResult[3] = null;
            testCase.ExpectedResult[4] = null;
            testCase.ExpectedResult[5] = 11;
            testCase.ExpectedResult[6] = null;
            Test.TestAdd(testCase, 11);

            testCase.InputTree.AddItem(9);
            testCase.InputTree.AddItem(8);

            // Тест на добавление 5
            testCase.ExpectedResult = new int?[15];
            testCase.ExpectedResult[0] = 10;
            testCase.ExpectedResult[1] = 9;
            testCase.ExpectedResult[2] = 12;
            testCase.ExpectedResult[3] = 8;
            testCase.ExpectedResult[4] = null;
            testCase.ExpectedResult[5] = 11;
            testCase.ExpectedResult[6] = null;
            testCase.ExpectedResult[7] = 8;
            testCase.ExpectedResult[8] = null;
            testCase.ExpectedResult[9] = null;
            testCase.ExpectedResult[10] = null;
            testCase.ExpectedResult[11] = null;
            testCase.ExpectedResult[12] = null;
            testCase.ExpectedResult[13] = null;
            testCase.ExpectedResult[14] = null;
            Test.TestAdd(testCase, 8);

            // Тест на удаление 3
            testCase.ExpectedResult[2] = null;
            testCase.ExpectedResult[5] = null;
            Test.TestRemove(testCase, 12);

            // Тест на удаление 4
            testCase.ExpectedResult = new int?[1];
            testCase.ExpectedResult[0] = 10;
            Test.TestRemove(testCase, 9);

            // Тест на удаление 5
            testCase.ExpectedResult = new int?[0];
            Test.TestRemove(testCase, 10);
        }
    }
}
