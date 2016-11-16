using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
namespace Highly_divisible_triangular_number
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int result = new Triangle().GetNumberWithCount(500);
            Console.WriteLine($"result={result} in {watch.ElapsedMilliseconds} ms");
            Console.Read();
        }
    }

    class Triangle
    {
        public int FindDivisorsCount(int number)
        {
            int counter = 0;
            int sqrt = (int)Math.Sqrt(number);
            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    counter += 2;
                }
            }
            if (sqrt * sqrt == number)
            {
                counter--;
            }
            return counter;
        }
        public int GetNumberWithCount(int count)
        {
            int i = 1;
            while (FindDivisorsCount(i) < count)
            {
                i++;
                Console.WriteLine(i);
            }
            return i;
        }
    }
    class Problem12
    {


        public void TrialDivision()
        {
            Stopwatch clock = Stopwatch.StartNew();
            int number = 0;
            int i = 1;


            while (NumberOfDivisors(number) < 500)
            {
                number += i;
                i++;
            }

            clock.Stop();
            Console.WriteLine("The first triangle number with over 500 digits is: {0}", number);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }


        private int NumberOfDivisors(int number)
        {
            int nod = 0;
            int sqrt = (int)Math.Sqrt(number);

            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    nod += 2;
                }
            }
            //Correction if the number is a perfect square
            if (sqrt * sqrt == number)
            {
                nod--;
            }

            return nod;
        }

        #region Prime Divisors
        public void PrimeDivisors()
        {
            Stopwatch clock = Stopwatch.StartNew();
            int number = 1;
            int i = 2;
            int[] primelist = ESieve(75000);

            while (PrimeFactorisationNoD(number, primelist) < 500)
            {
                number += i;
                i++;
            }

            clock.Stop();
            Console.WriteLine("The first triangle number with over 500 digits is: {0}", number);

            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }


        private int PrimeFactorisationNoD(int number, int[] primelist)
        {
            int nod = 1;
            int exponent;
            int remain = number;

            for (int i = 0; i < primelist.Length; i++)
            {

                // In case there is a remainder this is a prime factor as well
                // The exponent of that factor is 1
                if (primelist[i] * primelist[i] > number)
                {
                    return nod * 2;
                }

                exponent = 1;
                while (remain % primelist[i] == 0)
                {
                    exponent++;
                    remain = remain / primelist[i];
                }
                nod *= exponent;

                //If there is no remainder, return the count
                if (remain == 1)
                {
                    return nod;
                }
            }
            return nod;
        }

        // Returns the list of prime numbers up to the input
        public int[] ESieve(int upperLimit)
        {

            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }
        #endregion Prime Divisors


        #region Prime Divisors
        public void CoPrimes()
        {
            Stopwatch clock = Stopwatch.StartNew();
            int number = 1;
            int i = 2;
            int cnt = 0;
            int Dn1 = 2;
            int Dn = 2;
            int[] primelist = ESieve(1000);

            while (cnt < 500)
            {
                if (i % 2 == 0)
                {
                    Dn = PrimeFactorisationNoD(i + 1, primelist);
                    cnt = Dn * Dn1;
                }
                else
                {
                    Dn1 = PrimeFactorisationNoD((i + 1) / 2, primelist);
                    cnt = Dn * Dn1;
                }
                i++;
            }
            number = i * (i - 1) / 2;

            clock.Stop();
            Console.WriteLine("The first triangle number with over 500 digits is: {0}", number);

            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        #endregion Prime Divisors
    }
}
