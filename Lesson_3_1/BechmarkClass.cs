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

        public PointClass[] ClassArray { get; set; }
        public PointStruct[] StructArray { get; set; }
        public BechmarkClass()
        {
            ClassArray = new PointClass[100];
            StructArray = new PointStruct[100];
            for (int i = 0; i < 100; i++)
            {
                int x = new Random().Next(0, 100);
                int y = new Random().Next(0, 100);
                ClassArray[i] = new PointClass { X = x, Y = y };
                StructArray[i] = new PointStruct { X = x, Y = y };
            }
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
            for (int i = 0; i < ClassArray.Length; i+=2)
            {
                PointDistance(ClassArray[i], ClassArray[i+1]);
            }
        }

        [Benchmark]
        public void TestStructFloat()
        {
            for (int i = 0; i < StructArray.Length; i += 2)
            {
                PointDistance(StructArray[i], StructArray[i + 1]);
            }
        }

        [Benchmark]
        public void TestStructDouble()
        {
            for (int i = 0; i < StructArray.Length; i += 2)
            {
                PointDistanceDouble(StructArray[i], StructArray[i + 1]);
            }
        }

        [Benchmark]
        public void TestStructFloatShort()
        {
            for (int i = 0; i < StructArray.Length; i += 2)
            {
                PointDistanceShort(StructArray[i], StructArray[i + 1]);
            }
        }

    }
}
