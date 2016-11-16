using System;

namespace Sum_square_difference
{
    class Program
    {
        static void Main(string[] args)
        {
            SumSquare sumSquare = new SumSquare();
            int a = sumSquare.GetSumSquareDifference(100);
            Console.WriteLine(a);
            Console.Read();
        }
    }

    class SumSquare
    {
        public int GetSumSquareDifference(int number)
        {
            int sumSquare = 0;
            int squareSum = 0;
            sumSquare = (number * (number + 1) * (2 * number + 1)) / 6;
              squareSum = ((1 + number)*number / 2);
            return squareSum * squareSum - sumSquare;
        }
    }
}
