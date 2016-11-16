using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacchiSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibonacchiGenerator = new Fibonacci();
         //   int[] fibonacchi = fibonacchiGenerator.GenerateFibonacchi(1000000);
            int sum = fibonacchiGenerator.FindSum(4000000);
            Console.WriteLine(sum);
            Console.Read();
        }
    }

    class Fibonacci
    {
        public int[] GenerateFibonacchi(int count)
        {
            if (count < 3)
            {
                return new int[0];
            }
            List<int> result = new List<int> { 1, 2 };
            while (result[result.Count - 2] + result[result.Count - 1] < count)
            {
                result.Add(result[result.Count - 2] + result[result.Count - 1]);
            }
            return result.ToArray();
        }
        public int FindSum(int count)
        {
            int summa = 0;
            int temp;
            int[] tempArr = new int[2] { 1, 2 };
            int lastVar = tempArr.Last();
            while (lastVar <= count)
            {
                if (lastVar % 2 == 0)
                {
                    summa += lastVar;
                }
                temp = tempArr[1];
                tempArr[1] = tempArr[0]+ tempArr[1];
                tempArr[0] = temp;
                lastVar = tempArr[1];
            }
            return summa;
        }
    }
}
