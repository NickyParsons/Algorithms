using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_5_1
{
    public static class Test
    {
        public static void PrintNodeArray(int[] treeValueArray)
        {
            Console.Write("массив: ");
            if (treeValueArray.Length == 0)
            {
                Console.Write("пуст.");
            }
            else
            {
                foreach (int value in treeValueArray)
                {
                    Console.Write($"{value}, ");
                }
            }
            Console.WriteLine();
        }
        public static bool CompareResults(int[] treeValueArray, int[] expectedArray)
        {
            if (treeValueArray.Length != expectedArray.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < expectedArray.Length; i++)
                {
                    if (treeValueArray[i] != expectedArray[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static void TestBFS(TestCase testCase)
        {
            bool isTestValid = false;
            int[] arrayBFS = testCase.InputTree.GetArrayBFS();
            if (CompareResults(arrayBFS, testCase.ExpectedResult))
            {
                isTestValid = true;
            }
            if (isTestValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test valid!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed test!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write("Ожидаемый ");
            PrintNodeArray(testCase.ExpectedResult);
            Console.Write("Полученный ");
            PrintNodeArray(arrayBFS);
        }
        public static void TestDFS(TestCase testCase)
        {
            bool isTestValid = false;
            int[] arrayDFS = testCase.InputTree.GetArrayDFS();
            if (CompareResults(arrayDFS, testCase.ExpectedResult))
            {
                isTestValid = true;
            }
            if (isTestValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test valid!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed test!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write("Ожидаемый ");
            PrintNodeArray(testCase.ExpectedResult);
            Console.Write("Полученный ");
            PrintNodeArray(arrayDFS);
        }
    }
}