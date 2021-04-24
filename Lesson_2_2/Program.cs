using System;

namespace Lesson_2_2
{
    class Program
    {
        static void PrintArray(int[] array)
        {
            if (array.Length == 0)
            {
                Console.Write("Массив пуст");
            }
            else
            {
                foreach (int item in array)
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
        }
        static void TestSearch(TestCase testCase, int value)
        {

            int result = 0;
            bool validTest = false;
            try
            {
                result = BinarySearch(testCase.InputArray, value);
                if (result == testCase.ExpectedIndex)
                {
                    validTest = true;
                }
                else
                {
                    validTest = false;
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException == null)
                {
                    validTest = false;
                }
                else
                {
                    if (ex.GetType() == testCase.ExpectedException.GetType())
                    {
                        validTest = true;
                    }
                    else
                    {
                        validTest = false;
                    }
                }
            }
            finally
            {
                if (validTest)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("VALID");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FAILED");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine($"Ожидаемый индекс: {testCase.ExpectedIndex}");
                Console.WriteLine($"Полученный индекс: {result}");
                Console.WriteLine();
            }
        }

        public static int BinarySearch(int[] inputArray, int searchValue) //Асимпотическая сложность алгоритма O(log(N))
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        static void Main(string[] args)
        {
            int[] array = new int[] { 2, -1, 0, 4, 10, 6, -7, 8, 15, 68, 90,74 , 60, 55, -40 };
            Array.Sort(array);
            PrintArray(array);
            TestCase testCase;
            testCase = new TestCase { InputArray = array, ExpectedIndex = 3, ExpectedException = null };
            TestSearch(testCase, 0);
            testCase = new TestCase { InputArray = array, ExpectedIndex = 5, ExpectedException = null }; // Заведомо проваленный тест
            TestSearch(testCase, 0);
            testCase = new TestCase { InputArray = array, ExpectedIndex = 8, ExpectedException = null };
            TestSearch(testCase, 10);
            testCase = new TestCase { InputArray = array, ExpectedIndex = 4, ExpectedException = null }; // Заведомо проваленный тест
            TestSearch(testCase, 0);
            testCase = new TestCase { InputArray = array, ExpectedIndex = 0, ExpectedException = null };
            TestSearch(testCase, -40);
        }
    }
}
