using System;

namespace Lesson_1_3
{
    class Program
    {
        static int FibonacciRecursion(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return FibonacciRecursion(number - 2) + FibonacciRecursion(number - 1);
            }
            
        }

        static int FibonacciLoop(int number)
        {
            int fibLow = 0;
            int fibHigh = 1;
            int fibSum = 0;
            if (number == 1)
            {
                fibSum = 1;
            }
            for (int i = 1; i < number; i++)
            {
                fibSum = fibLow + fibHigh;
                fibLow = fibHigh;
                fibHigh = fibSum;
            }
            return fibSum;
        }

        static void Test(TestCase test)
        {
            try
            {
                int actualResultRecursion = FibonacciRecursion(test.InputNumber);
                int actualResultLoop = FibonacciLoop(test.InputNumber);
                if (test.ExpectedException == null)
                {
                    if (actualResultLoop == test.ExpectedResult && actualResultRecursion == test.ExpectedResult)
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
                Console.WriteLine($"Actual result with loop : {actualResultLoop}");
                Console.WriteLine($"Actual result with recursion : {actualResultRecursion}");

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
        static void Main()
        {
            TestCase testCase1 = new TestCase { InputNumber = 0, ExpectedResult = 0, ExpectedException = null };
            Test(testCase1);
            TestCase testCase2 = new TestCase { InputNumber = 1, ExpectedResult = 1, ExpectedException = null };
            Test(testCase2);
            TestCase testCase3 = new TestCase { InputNumber = 10, ExpectedResult = 55, ExpectedException = null };
            Test(testCase3);
        }
    }
}
