using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6_1
{
    public static class Tests
    {
        public static void PrintIntArray(int[] array)
        {
            if (array.Length != 0)
            {
                Console.Write("массив:");
                foreach (int item in array)
                {
                    Console.Write($"{item}, ");
                }
            }
            else
            {
                Console.Write("массив пуст.");
            }
            Console.WriteLine();
        }
        public static void PrintNodeArray(Node[] array)
        {
            if (array.Length != 0)
            {
                Console.Write("массив:");
                foreach (Node node in array)
                {
                    Console.Write($"{node.Value}, ");
                }
            }
            else
            {
                Console.Write("массив пуст.");
            }
            Console.WriteLine();
        }
        public static bool Compare(Node[] resultArray, int[] expectedArray)
        {
            if (resultArray.Length != expectedArray.Length)
            {
                return false;
            }
            for (int i = 0; i < expectedArray.Length; i++)
            {
                if (expectedArray[i] != resultArray[i].Value)
                {
                    return false;
                }
            }
            return true;
        }
        public static void TestBFS(TestCase testCase)
        {
            bool isTestValid = true;
            Node[] result = Graph.GetNodeArrayBFS(testCase.InputNode);
            if (!Compare(result, testCase.ExpectedResult))
            {
                isTestValid = false;
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
            PrintIntArray(testCase.ExpectedResult);
            Console.Write("Полученный ");
            PrintNodeArray(result);
        }
        public static void TestDFS(TestCase testCase)
        {
            bool isTestValid = true;
            Node[] result = Graph.GetNodeArrayDFS(testCase.InputNode);
            if (!Compare(result, testCase.ExpectedResult))
            {
                isTestValid = false;
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
            PrintIntArray(testCase.ExpectedResult);
            Console.Write("Полученный ");
            PrintNodeArray(result);
        }
    }
}
