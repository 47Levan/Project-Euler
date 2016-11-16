using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LongestCollatzSequence
{
    class Program
    {
        static void Main(string[] args)
        {

            long result = new Collatz().FindMaxCache(1000000);
            Console.Read();
        }
    }

    class Collatz
    {
        public List<long> GenerateSequance(long number)
        {
            if (number < 1)
            {
                return new List<long>();
            }
            List<long> result = new List<long>();
            long current = number;
            result.Add(current);
            while (current != 1)
            {
                current = (current % 2) == 0 ? current / 2 : 3 * current + 1;
                result.Add(current);
            }
            return result;
        }
        public long FindMax(int number)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (number < 1)
            {
                return -1;
            }
            int best = 0;
            int counter = 0;
            int bestCounter = 0;
            for (int i = 2; i <= number; i++)
            {
                long current = i;
                while (current != 1)
                {
                    current = current % 2 == 0 ? current / 2 : 3 * current + 1;
                    counter++;
                }
                if (counter > bestCounter)
                {
                    bestCounter = counter;
                    best = i;
                }
                counter = 0;
            }

            Console.WriteLine($"result={best} with chain of length {bestCounter} finished at {watch.ElapsedMilliseconds} ms");
            return best;
        }
        public long FindMaxCache(int number)
        {
            if (number < 1)
            {
                return -1;
            }
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int[] cache = new int[number];
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = -1;
            }
            int index = -1;
            int counter = 0;
            int bestCounter = 0;
            for (int i = 2; i < number; i++)
            {
                long current = i;
                while (current != 1 && current >= i)
                {
                    current = current % 2 == 0 ? current / 2 : 3 * current + 1;
                    counter++;
                }
                cache[i] = counter + cache[current];
                if (cache[i] > bestCounter)
                {
                    bestCounter = cache[i];
                    index = i;
                }
                counter = 0;
            }

            Console.WriteLine($"result={index} with chain of length {bestCounter} finished at {watch.ElapsedMilliseconds} ms");
            return cache[index];
        }
    }
}
