using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiples_of_3_and_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Finder finder = new Finder();
            Console.WriteLine(finder.findSumMulty(1000));
            Console.Read();
        }
    }

    class Finder
    {
        public int findSumMulty(int count)
        {
            int summa=0;
            for (int i = 3; i < count; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    summa += i;
                }
            }
            return summa;
        }
    }
}
