using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_palindrome_product
{
    class Program
    {
        static void Main(string[] args)
        {
            Polyndrom polyndrom = new Polyndrom();
            int polydrom = polyndrom.LargestPolindrom();
            Console.WriteLine(polydrom);
            Console.Read();
        }
    }

    class Polyndrom
    {
        public int LargestPolindrom()
        {
            List<int> polidroms = new List<int>();
            for (int i = 999; i >= 100; i--)
            {
                for (int j = 999; j >= 100; j--)
                {
                    if (i*j==ReverseNumber(i*j))
                    {
                        polidroms.Add(i*j);
                    }
                }
            }
            return polidroms.Max();
        }

        public int ReverseNumber(int a)
        {
            int result = 0;
            while (a > 0)
            {
                result = result * 10 + a % 10;
                a /= 10;
            }
            return result;
        }
    }
}
