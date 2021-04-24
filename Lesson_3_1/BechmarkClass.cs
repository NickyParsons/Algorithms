using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_3_1
{
    public class BechmarkClass
    {
        public static PointClass PointClassOne {get; set; }
        public static PointClass PointClassTwo { get; set; }
        public static PointStruct PointStructOne { get; set; }
        public static PointStruct PointStructTwo { get; set; }

        public int[] ValueArray { get; set; }
        public BechmarkClass()
        {
            ValueArray = new int[8];
            Random random = new Random();
            for (int i = 0; i < ValueArray.Length; i++)
            {
                ValueArray[i] = random.Next(0, 100);
            }
            PointClassOne = new PointClass { X = ValueArray[0], Y = ValueArray[1] };
            PointClassTwo = new PointClass { X = ValueArray[2], Y = ValueArray[3] };
            PointStructOne = new PointStruct { X = ValueArray[4], Y = ValueArray[5] };
            PointStructTwo = new PointStruct { X = ValueArray[6], Y = ValueArray[7] };
        }

        // PointClass — координаты типа float
        public static float PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        // PointStruct — координаты типа float
        public static float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        // PointStruct — координаты типа double
        public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        // PointStruct — координаты типа float (сокращенный)
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        //ТЕСТЫ
        [Benchmark]
        public void TestClassFloat()
        {
            PointDistance(PointClassOne, PointClassTwo);
        }

        [Benchmark]
        public void TestStructFloat()
        {
            PointDistance(PointStructOne, PointStructTwo);
        }

        [Benchmark]
        public void TestStructDouble()
        {
            PointDistanceDouble(PointStructOne, PointStructTwo);
        }

        [Benchmark]
        public void TestStructFloatShort()
        {
            PointDistanceShort(PointStructOne, PointStructTwo);
        }

    }
}
