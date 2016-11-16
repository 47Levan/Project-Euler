using System;
using System.Diagnostics;
using System.Numerics;


namespace Power_digit_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int sum = new Calc().GetSum();
            Console.WriteLine(sum);
            Console.Read();
        }
    }

    class Calc
    {
        public int GetSum()
        {
            int result = 0;
            BigInteger number = BigInteger.Pow(2, 1000);
            while (number > 0)
            {
                result += (int)(number % 10);
                number /= 10;
            }
            return result;
        }
    }

}
