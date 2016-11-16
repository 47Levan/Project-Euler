using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Largest_prime_factor
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeFactor primefactor = new PrimeFactor();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<int> primes = primefactor.GetPrimesFactor2(600851475143);
            stopWatch.Stop();
            primes.ForEach(x => { Console.Write(x + ", "); });
            Console.WriteLine($"\n Solution took {stopWatch.ElapsedMilliseconds}");
            Console.Read();
        }
    }

    class PrimeFactor
    {
        public SortedSet<int> GetPrimes(int number)
        {
            SortedSet<int> primes = new SortedSet<int>();
            BitArray input = new BitArray(number + 1);
            Dictionary<int, int> findedCounter = new Dictionary<int, int>(number + 1);
            int sqrtBound = (int)Math.Sqrt((double)number);
            primes.Add(2);
            primes.Add(3);
            primes.Add(5);

            for (int x = 0; x <= sqrtBound; x++)
            {
                int x2 = (int)Math.Pow(x, 2);
                for (int y = 0; y <= sqrtBound; y++)
                {
                    int y2 = (int)Math.Pow(y, 2);
                    int firstExp = 4 * x2 + y2;
                    int secondExp = 3 * x2 + y2;
                    int thirdExp = 3 * x2 - y2;
                    if (firstExp <= number
                        && (firstExp % 12 == 1 || firstExp % 12 == 5)
                        && firstExp % 2 != 0
                        && firstExp % 3 != 0
                        && firstExp % 5 != 0)
                    {
                        if (!findedCounter.ContainsKey(firstExp))
                        {
                            input.Set(firstExp, true);
                            findedCounter.Add(firstExp, 1);
                        }
                        else
                        {
                            input.Set(firstExp, false);
                            findedCounter[firstExp] += 1;
                        }
                        if (Math.Pow(firstExp, 2) < input.Length)
                        {
                            input.Set((int)Math.Pow(firstExp, 2)
                                , false);
                        }
                    }
                    if (secondExp <= number
                        && secondExp % 12 == 7
                        && secondExp % 2 != 0
                        && secondExp % 3 != 0
                        && secondExp % 5 != 0)
                    {
                        if (!findedCounter.ContainsKey(secondExp))
                        {
                            input.Set(secondExp, true);
                            findedCounter.Add(secondExp, 1);
                        }
                        else
                        {
                            input.Set(secondExp, false);
                            findedCounter[secondExp] += 1;
                        }
                        if (Math.Pow(secondExp, 2) < input.Length)
                        {
                            input.Set((int)Math.Pow(secondExp, 2)
                                , false);
                        }
                    }
                    if (x > y && thirdExp <= number && thirdExp % 12 == 11
                        && thirdExp % 2 != 0
                        && thirdExp % 3 != 0
                        && thirdExp % 5 != 0)
                    {
                        if (!findedCounter.ContainsKey(thirdExp))
                        {
                            input.Set(thirdExp, true);
                            findedCounter.Add(thirdExp, 1);
                        }
                        else
                        {
                            input.Set(thirdExp, false);
                            findedCounter[thirdExp] += 1;
                        }
                        if (Math.Pow((int)thirdExp, 2) < input.Length)
                        {
                            input.Set((int)Math.Pow(thirdExp, 2)
                                , false);
                        }
                    }
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public List<int> GetPrimesFactor(long number)
        {
            List<int> result = new List<int>();
            SortedSet<int> primes = GetPrimes((int)Math.Sqrt(number));
            long toDevide = number;
            foreach (int prime in primes)
            {
                if (toDevide % prime == 0)
                {
                    result.Add(prime);
                    toDevide = toDevide / prime;
                }
            }
            return result;
        }
        public List<int> GetPrimesFactor2(long number)
        {
            List<int> result = new List<int>();
            if (number % 2 == 0)
            {
                result.Add(2);
                number = number / 2;
            }
            else if (number % 3 == 0)
            {
                result.Add(3);
                number = number / 3;
            }
            for (int i = 5; i  <= number; i = i + 2)
            {
                if (number % i == 0)
                {
                    bool isPrime = true;
                    for (int j = 5; j < i; j = j + 2)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                        }
                    }
                    if (isPrime)
                    {
                        result.Add(i);
                        number = number / i;
                    }
                }
            }
            return result;
        }
    }
}
