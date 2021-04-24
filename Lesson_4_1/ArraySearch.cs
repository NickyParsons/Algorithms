using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_4_1
{
    public class ArraySearch
    {
        public string[] ArrayOfStrings { get; set; }
        public HashSet<string> HashTable { get; set; }
        
        public ArraySearch()
        {
            GenerateValues(10000);
        }
        public void GenerateValues(int count)
        {
            ArrayOfStrings = new string[count];
            HashTable = new HashSet<string>();

            int uniqueStringNumber = new Random().Next(0, count - 1);
            string uniqueString = "Уникальная строка";
            for (int i = 0; i < count; i++)
            {
                if (i == uniqueStringNumber)
                {
                    ArrayOfStrings[i] = uniqueString;
                    HashTable.Add(uniqueString);
                }
                else
                {
                    string generatedString = "Строка" + i;
                    ArrayOfStrings[i] = generatedString;
                    HashTable.Add(generatedString);
                }
            }
        }
        [Benchmark]
        public bool TestSearchArray()
        {
            string uniqueString = "Уникальная строка";
            foreach (string item in ArrayOfStrings)
            {
                if (item == uniqueString)
                {
                    return true;
                }
            }
            return false;
        }

        [Benchmark]
        public bool TestSearchHashTable()
        {
            string uniqueString = "Уникальная строка";
            if (HashTable.Contains(uniqueString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
