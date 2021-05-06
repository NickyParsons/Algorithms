using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7_1
{
    public static class Tests
    {
        public static bool Compare(int[ , ] resultArray, int[ , ] expectedArray)
        {
            if (resultArray.Length != expectedArray.Length)
            {
                return false;
            }
            for (int i = 0; i < expectedArray.GetLength(0); i++)
            {
                for (int j = 0; j < expectedArray.GetLength(1); j++)
                {
                    if (expectedArray[i, j] != resultArray[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static void Test(TestCase testCase)
        {
            bool isTestValid = true;
            if (!Compare(testCase.InputArray, testCase.ExpectedArray))
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
            Console.WriteLine("Ожидаемая матрица:");
            Table.PrintTable(testCase.ExpectedArray);
            Console.WriteLine("Полученная матрица:");
            Table.PrintTable(testCase.InputArray);
        }
    }
}
