using System;
using System.Diagnostics;
namespace Lattice_paths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int height=21;
            int width=21;
            long count = new Grid().Routes(height, width);
            Console.WriteLine($"Fro grid with height {height} and with width {width} " +
                              $"count of routes equals to {count},algoritm worked {watch.ElapsedMilliseconds} ms");
            Console.Read();
        }
    }

    class Grid
    {
        public long Routes(int height, int width)
        {
          
                long[,] array = new long[height, width];
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    array[i, 0] = 1;
                    array[0, i] = 1;
                }
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    for (int j = 1; j < array.GetLength(1); j++)
                    {
                        array[i, j] = array[i - 1, j] + array[i, j - 1];
                    }
                }
                return array[height - 1, width - 1];
            }
    }
}
