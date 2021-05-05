using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7_1
{
    public static class Table
    {
        static string FormatCell(int number, int maxLenght)
        {
            string cell = Convert.ToString(number);
            if (cell.Length < maxLenght)
            {
                return new string(' ', maxLenght - cell.Length) + cell;
            }
            else
            {
                return cell;
            }
        }
        static void PrintHeader(int sizeX, int maxCellSize)
        {
            Console.Write('┌');
            for (int i = 0; i < sizeX; i++)
            {
                Console.Write(new string('─', maxCellSize));
                if (i != sizeX - 1)
                {
                    Console.Write('┬');
                }
                else
                {
                    Console.Write('┐');
                }
            }
            Console.Write("\r\n");
        }
        static void PrintFooter(int sizeX, int maxCellSize)
        {
            Console.Write('└');
            for (int i = 0; i < sizeX; i++)
            {
                Console.Write(new string('─', maxCellSize));
                if (i != sizeX - 1)
                {
                    Console.Write('┴');
                }
                else
                {
                    Console.Write('┘');
                }
            }
            Console.Write("\r\n");
        }
        static void PrintSeparator(int sizeX, int maxCellSize)
        {
            Console.Write('├');
            for (int i = 0; i < sizeX; i++)
            {
                Console.Write(new string('─', maxCellSize));
                if (i != sizeX - 1)
                {
                    Console.Write('┼');
                }
                else
                {
                    Console.Write('┤');
                }
            }
            Console.Write("\r\n");
        }
        public static void PrintTable(int[,] a)
        {
            int lenghtX = a.GetLength(1);
            int lenghtY = a.GetLength(0);
            int maxCellSize = Convert.ToString(a[lenghtY - 1, lenghtX - 1]).Length;
            PrintHeader(lenghtX, maxCellSize);
            for (int i = 0; i < lenghtY; i++)
            {
                Console.Write('│');
                for (int j = 0; j < lenghtX; j++)
                {
                    Console.Write(FormatCell(a[i, j], maxCellSize));
                    Console.Write('│');
                }
                Console.Write("\r\n");
                if (i != lenghtY - 1)
                {
                    PrintSeparator(lenghtX, maxCellSize);
                }
            }
            PrintFooter(lenghtX, maxCellSize);
        }
    }
}
