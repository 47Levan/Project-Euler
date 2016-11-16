using System;
using MoreLinq;

namespace Special_Pythagorean_triplet
{
    class Program
    {
        static void Main(string[] args)
        {
            Pythagorean pythagorean = new Pythagorean();
            int[] result = pythagorean.FindABC(1000);
            result.ForEach(x => { Console.Write($"{x} ,"); });
            Console.Read();
        }
    }

    class Pythagorean
    {
        public int[] FindABC(int number)
        {
            for (int a = 1; a <= number; a++)
            {
                for (int b = a; b <= number; b++)
                {
                    double c = Math.Sqrt(a * a + b * b);
                    if (a + b + c == number)
                    {
                        return new[] { a, b, (int)c };
                    }
                }
            }
            return new int[3];
        }
        public int[] FindABC2(int number)
        {
            for (int a = 1; a <= number; a++)
            {
                for (int b = a; b <= number; b++)
                {
                    double c = Math.Sqrt(a * a + b * b);
                    if (a + b + c == number)
                    {
                        return new[] { a, b, (int)c };
                    }
                }
            }
            return new int[3];
        }
    }
}
