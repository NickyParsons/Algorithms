using System;

namespace Lesson_1_1
{
    class Program
    {
        static bool IsNumberSimple(int number)
        {
            int d = 0;
            int i = 2;
            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Test(TestCase test)
        {
            try
            {
                bool actualResult = IsNumberSimple(test.InputNumber);
                if (test.ExpectedException == null)
                {
                    if (actualResult == test.ExpectedResult)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Test complete!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Test failed!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Test failed!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"Expected exception: {test.ExpectedException}");
                }
                Console.WriteLine($"Input: {test.InputNumber}");
                Console.WriteLine($"Expected result: {test.ExpectedResult}");
                Console.WriteLine($"Actual result: {actualResult}");

            }
            catch (Exception ex)
            {
                if (ex.GetType() == test.ExpectedException.GetType())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Test complete!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Test failed!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine($"Input: {test.InputNumber}");
                Console.WriteLine($"Expected exception: {test.ExpectedException}");
                Console.WriteLine($"Actual exception: {ex}");
            }
            finally
            { 
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            TestCase testCase1 = new TestCase { InputNumber = 2, ExpectedResult = true, ExpectedException = null };
            Test(testCase1);
            TestCase testCase2 = new TestCase { InputNumber = 9, ExpectedResult = false, ExpectedException = null };
            Test(testCase2);
            TestCase testCase3 = new TestCase { InputNumber = 144, ExpectedResult = false, ExpectedException = null };
            Test(testCase3);
        }
    }
}
