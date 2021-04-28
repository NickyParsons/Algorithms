using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
        }
    }
}
