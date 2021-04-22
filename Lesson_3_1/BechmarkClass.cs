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
        public BechmarkClass()
        {
            PointClassOne = new PointClass { X = 2, Y = 4 };
            PointClassTwo = new PointClass { X = 37, Y = 15 };
            PointStructOne = new PointStruct { X = 2, Y = 4 };
            PointStructTwo = new PointStruct { X = 37, Y = 15 };
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
