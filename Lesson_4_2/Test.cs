using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_4_2
{
    static class Test
    {
        public static void PrintNodeArray(TreeNode[] array)
        {
            if (array.Length != 0)
            {
                Console.Write("массив: ");
                foreach (TreeNode item in array)
                {
                    if (item != null)
                    {

                        Console.Write($"{item.Value}, ");
                    }
                    else
                    {
                        Console.Write("(empty), ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("массив пуст.");
            }
        }
        public static void PrintIntArray(int?[] array)
        {
            if (array == null)
            {
                Console.WriteLine("массив пуст.");
            }
            else
            {
                if (array.Length == 0)
                {
                    Console.WriteLine("массив пуст.");
                }
                else
                {
                    Console.Write("массив: ");
                    foreach (int? item in array)
                    {
                        if (item != null)
                        {

                            Console.Write($"{item}, ");
                        }
                        else
                        {
                            Console.Write("(empty), ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            
        }
        public static bool CompareNodeArray(TreeNode[] input, int?[] expected)
        {
            if ((input.Length == 0) && (expected == null))
            {
                return true;
            }
            if (input.Length == expected.Length)
            {
                for (int i = 0; i < expected.Length; i++)
                {
                    if ((input[i] != null) && expected[i] != null)
                    {
                        if (input[i].Value != expected[i])
                        {
                            return false;
                        }
                    }
                    else if ((input[i] == null) && expected[i] == null)
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
        public static void TestAdd(TestCase testCase, int value)
        {
            bool isTestValid = true;
            try
            {
                testCase.InputTree.AddItem(value);
                if (!CompareNodeArray(TreeHelper.GetTreeInArray(testCase.InputTree), testCase.ExpectedResult))
                {
                    isTestValid = false;
                }

            }
            catch (Exception)
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
                Console.WriteLine("Test failed!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write("Ожидаемый ");
            PrintIntArray(testCase.ExpectedResult);
            Console.Write("Полученный ");
            PrintNodeArray(TreeHelper.GetTreeInArray(testCase.InputTree));
            testCase.InputTree.PrintTree();
        }
        public static void TestRemove(TestCase testCase, int value)
        {
            bool isTestValid = true;
            try
            {
                testCase.InputTree.RemoveItem(value);
                if (!CompareNodeArray(TreeHelper.GetTreeInArray(testCase.InputTree), testCase.ExpectedResult))
                {
                    isTestValid = false;
                }

            }
            catch (Exception)
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
                Console.WriteLine("Test failed!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write("Ожидаемый ");
            PrintIntArray(testCase.ExpectedResult);
            Console.Write("Полученный ");
            PrintNodeArray(TreeHelper.GetTreeInArray(testCase.InputTree));
            testCase.InputTree.PrintTree();
        }
    }
}
