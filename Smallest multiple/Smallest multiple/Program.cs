using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallest_multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            Multiples multiples = new Multiples();
            int a =multiples.SmallestMultiple();
            Console.WriteLine(a);
            Console.Read();
        }
    }

    class Multiples
    {
        public int SmallestMultiple()
        {
            int divisorMax = 10;
            int[] p = getPrimes(divisorMax);
            int result = 1;

            foreach (int item in p)
            {
                int a = (int)Math.Floor(Math.Log(divisorMax) / Math.Log(item));
                result = result * ((int)Math.Pow(item, a));
            }
            return result;
        }

        public int[] getPrimes(int upperLimit)
        {
          
            List<int> primes = new List<int>();
            bool isPrime;
            int j;

            primes.Add(2);

            for (int i = 3; i <= upperLimit; i += 2)
            {
                j = 0;
                isPrime = true;
                while (primes[j] * primes[j] <= i)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    j++;
                }
                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            return primes.ToArray<int>();
        }
    }
}
