using System;

namespace Lesson_7_1
{
    class Program
    {
        const int Y = 3;
        const int X = 3;

        static void Main(string[] args)
        {
            int[,] A = new int[Y, X];
            int i, j;
            for (j = 0; j < X; j++)
                A[0, j] = 1;
            for (i = 1; i < Y; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < X; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }

            int[,] B = new int[Y, X];
            B[0, 0] = 1;
            B[0, 1] = 1;
            B[0, 2] = 1;
            B[1, 0] = 1;
            B[1, 1] = 2;
            B[1, 2] = 3;
            B[2, 0] = 1;
            B[2, 1] = 3;
            B[2, 2] = 6;
            TestCase testCase = new TestCase { InputArray = A, ExpectedArray = B };
            Tests.Test(testCase);

        }

    }
}
