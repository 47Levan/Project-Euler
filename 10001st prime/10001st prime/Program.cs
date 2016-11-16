using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10001st_prime
{
    class Program
    {
        static void Main(string[] args)
        {
            Primes primes = new Primes();
            int a=primes.GetPrimeByIndex(10001);
            Console.WriteLine(a);
            Console.Read();
        }
    }

    class Primes
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

        public int GetPrimeByIndex(int index)
        {
            int counter = 3;
            int currentPrime = 3;
            if (index == 1)
            {
                return 2;
            }
            if (index == 2)
            {
                return 3;
            }
            while (counter <= index)
            {
                currentPrime = currentPrime + 2;
                bool isPrime = true;
                for (int i = 3; i < currentPrime; i = i + 2)
                {
                    if (currentPrime % i == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    counter++;
                }
            }
            return currentPrime;
        }
    }
}
