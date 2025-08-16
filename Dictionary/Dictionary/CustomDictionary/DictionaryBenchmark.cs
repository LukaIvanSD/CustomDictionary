using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace Dictionary.CustomDictionary
{
    [MemoryDiagnoser]
    public class DictionaryBenchmarks
    {
        private MySimpleDictionary<string, string> myDictionary;
        private Dictionary<string, string> dotnetDictionary;
        private const int N = 100000;

        private string[] keys;
        private string[] values;
        private Random random;


        [GlobalSetup]
        public void Setup()
        {
            Random random = new Random();
            keys = new string[N];
            values = new string[N];
            myDictionary = new MySimpleDictionary<string, string>();
            dotnetDictionary = new Dictionary<string, string>();
            for (int i = 0; i < N; i++)
            {
                keys[i] = GetRandomAsciiString(10);
                values[i] = GetRandomAsciiString(20);
            }
        }
        private string GetRandomAsciiString(int length)
        {
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                int rangePick = random.Next(3);
                if (rangePick == 0)
                    chars[i] = (char)random.Next(48, 58);
                else if (rangePick == 1)
                    chars[i] = (char)random.Next(65, 91);
                else
                    chars[i] = (char)random.Next(97, 123);
            }
            return new string(chars);
        }

        [Benchmark]
        public void MyDictionary_Add()
        {
            myDictionary = new MySimpleDictionary<string, string>();
            for (int i = 0; i < N; i++)
                myDictionary.Add(keys[i], keys[i]);
        }

        [Benchmark]
        public void DotNetDictionary_Add()
        {
            dotnetDictionary = new Dictionary<string,string>();
            for (int i = 0; i < N; i++)
                dotnetDictionary.Add(keys[i], keys[i]);
        }
        [Benchmark]
        public void MyDictionary_Lookup()
        {
            for (int i = 0; i < N; i++)
                _ = myDictionary.TryGetValue(keys[i]);
        }

        [Benchmark]
        public void DotNetDictionary_Lookup()
        {
            string value;
            for (int i = 0; i < N; i++)
                _ = dotnetDictionary.TryGetValue(keys[i],out value);
        }

        [Benchmark]
        public void MyDictionary_Remove()
        {
            for (int i = 0; i < N; i++)
                myDictionary.Remove(keys[i]);
        }

        [Benchmark]
        public void DotNetDictionary_Remove()
        {
            for (int i = 0; i < N; i++)
                dotnetDictionary.Remove(keys[i]);
        }
    }
}
