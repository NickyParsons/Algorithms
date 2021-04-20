using System;

namespace Lesson_2_1
{
    class Program
    {
        static bool CompareList(LinkedList list, int[] array)
        {
            if (list.GetCount() != array.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != list.GetNode(i).Value)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        static void TestAddNode(TestCase testCase, int value)
        {
            bool validTest = false;
            try
            {
                testCase.InputList.AddNode(value);
                if (CompareList(testCase.InputList, testCase.ExpectedResult))
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
                Console.Write("Ожидаемый список: ");
                PrintArray(testCase.ExpectedResult);
                Console.Write($"Полученный список: ");
                PrintNodes(testCase.InputList);
                Console.WriteLine();
            }
        }
        static void TestAddNodeAfter(TestCase testCase, Node node, int value)
        {
            bool validTest = false;
            try
            {
                testCase.InputList.AddNodeAfter(node, value);
                if (CompareList(testCase.InputList, testCase.ExpectedResult))
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
                Console.Write("Ожидаемый список: ");
                PrintArray(testCase.ExpectedResult);
                Console.Write($"Полученный список: ");
                PrintNodes(testCase.InputList);
                Console.WriteLine();
            }
        }
        static void TestRemoveNode(TestCase testCase, int index)
        {
            bool validTest = false;
            try
            {
                testCase.InputList.RemoveNode(index);
                if (CompareList(testCase.InputList, testCase.ExpectedResult))
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
                Console.Write("Ожидаемый список: ");
                PrintArray(testCase.ExpectedResult);
                Console.Write($"Полученный список: ");
                PrintNodes(testCase.InputList);
                Console.WriteLine();
            }
        }
        static void PrintNodes(LinkedList list)
        {
            try
            {
                Node currentNode = list.GetNode(0);
                do
                {
                    Console.Write($"{currentNode.Value} ");
                    currentNode = currentNode.NextNode;
                } while (currentNode != null);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Write("Cписок пуст");
            }
            finally
            {
                Console.WriteLine();
            }
        }
        static void PrintArray(int[] array)
        {
            if (array.Length == 0)
            {
                Console.Write("Cписок пуст");
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
        static void Main()
        {
            LinkedList list = new LinkedList();
            TestCase testCase; 
            
            //AddNode
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10 }, ExpectedException = null };
            TestAddNode(testCase, 10);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20 }, ExpectedException = null };
            TestAddNode(testCase, 20);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20 }, ExpectedException = null }; // Заведомо проваленный тест
            TestAddNode(testCase, 30);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 40 }, ExpectedException = null };
            TestAddNode(testCase, 40);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 40, 55 }, ExpectedException = null }; // Заведомо проваленный тест
            TestAddNode(testCase, 50);

            //AddNodeAfter
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 66, 40, 50 }, ExpectedException = null };
            TestAddNodeAfter(testCase, testCase.InputList.GetNode(2), 66);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 66, 78, 40, 50 }, ExpectedException = null }; // Заведомо проваленный тест
            TestAddNodeAfter(testCase, testCase.InputList.GetNode(3), 77);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 66, 77, 40, 50, 88 }, ExpectedException = null };
            TestAddNodeAfter(testCase, testCase.InputList.GetNode(6), 88);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { -7, 10, 20, 30, 66, 77, 40, 50, 88 }, ExpectedException = null }; // Заведомо проваленный тест
            TestAddNodeAfter(testCase, testCase.InputList.GetNode(0), -7);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, -8, -7, 20, 30, 66, 77, 40, 50, 88 }, ExpectedException = null };
            TestAddNodeAfter(testCase, testCase.InputList.GetNode(0), -8);

            //RemoveNode
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { -8, -7, 20, 30, 66, 77, 40, 50, 88 }, ExpectedException = null }; // Заведомо проваленный тест
            TestRemoveNode(testCase, 1);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 66, 77, 40, 50, 88 }, ExpectedException = null };
            TestRemoveNode(testCase, 1);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 77, 40, 50, 88 }, ExpectedException = null };
            TestRemoveNode(testCase, 3);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 40, 50, 88 }, ExpectedException = null };
            TestRemoveNode(testCase, 3);
            testCase = new TestCase { InputList = list, ExpectedResult = new int[] { 10, 20, 30, 40, 50, 88 }, ExpectedException = null }; // Заведомо проваленный тест
            TestRemoveNode(testCase, 5);
        }
    }
}
