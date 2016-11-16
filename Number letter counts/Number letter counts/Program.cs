using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_letter_counts
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine($"Sum= {new Calc().GetSum(1000)} in {watch.ElapsedMilliseconds} ms");
            Console.Read();
        }
    }

    class Calc
    {
        public int GetSum(int count)
        {
            int sum=0;
            if (count%2 == 0)
            {
                sum = (count + 1)*(count/2);
            }
            else
            {
                int temp = (count + 1) / 2;
                sum = (count + 1)*(temp - 1)+ temp;
            }
            return sum;
        }
        public int LettersCount(int count)
        {
            int sum = GetSum(count);
            return sum;
        }
    }
}
