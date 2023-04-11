using System;
using System.Diagnostics;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks;

namespace Benchmark
{
    [Config(typeof(AntiVirusFriendlyConfig))]
    public class Bench
    {
        // private const int N = 10000;
        // private readonly byte[] data;

        // private readonly SHA256 sha256 = SHA256.Create();
        // private readonly MD5 md5 = MD5.Create();
        private List<Person> users;

        [GlobalSetup]
        public void Setup()
        {
            users = new List<Person>();
            Console.WriteLine("INIT()");
            for (int i = 0; i < 10_00000; i++)
            {
                users.Add(new Person
                {
                    Id = i,
                    Name = $"prop{i}"
                });
            }
        }

        public Bench()
        {
            // init();
            // data = new byte[N];
            // new Random(42).NextBytes(data);


        }

        // [Benchmark]
        // public byte[] Sha256() => sha256.ComputeHash(data);

        // [Benchmark]
        // public byte[] Md5() => md5.ComputeHash(data);


        [Benchmark]
        public void NormalLoop()
        {
            int j = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] != null)
                {
                    j++;
                }
            }
        }

        [Benchmark]
        public void ForEachLoop()
        {
            int j = 0;
            foreach (var person in users)
            {
                if (person != null)
                {
                    j++;
                }
            }
        }

    }
}