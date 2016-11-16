using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_product_in_a_grid
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();
            int maxMulty = grid.GetMaxMulty(grid.GetArryaFromFile(), 4);
            Console.WriteLine(maxMulty);
            Console.Read();
        }
    }
    class Grid
    {
        public int[,] GetArryaFromFile()
        {
            int height = File.ReadAllLines("File.txt").Length;
            int[,] resultArray;
            Stream stream = new FileStream("File.txt", FileMode.OpenOrCreate);
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                string temp = reader.ReadLine();
                int width = temp.Split(' ').Select(int.Parse).Count();
                resultArray = new int[height + 1, width + 1];
                reader.DiscardBufferedData();
                stream.Position = 0;
                int i = 0;
                while (reader.Peek() >= 0)
                {
                    temp = reader.ReadLine();
                    if (temp != null)
                    {
                        int[] tempArray = temp.Split(' ').Select(int.Parse).ToArray();
                        for (int j = 0; j < tempArray.Length; j++)
                        {
                            resultArray[i, j] = tempArray[j];
                        }
                    }
                    i++;
                }
            }
            return resultArray;
        }

        public int GetMaxMulty(int[,] array, int count)
        {
            int max = 0;
            //Horizontal
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int h = 0; h < array.GetUpperBound(1) - count; h++)
                {
                    int temp = 1;
                    for (int j = h; j < h + count; j++)
                    {
                        temp *= array[i, j];
                    }
                    max = Math.Max(max, temp);
                }
            }
            //Vertical
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int v = 0; v < array.GetUpperBound(1) - count; v++)
                {
                    int temp = 1;
                    for (int j = v; j < v + count; j++)
                    {
                        temp *= array[j, i];
                    }
                    max = Math.Max(max, temp);
                }
            }
            //Diagonal
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                int d2 = 0;
                for (int d1 = i; d1 < array.GetUpperBound(0)-count 
                    && d2 < array.GetUpperBound(1)-count; d1++, d2++)
                {
                    int dd2 = d2;
                    int temp = 1;
                    for (int dd1 = d1; dd1 < d1+count && dd2 < d2+count; dd1++, dd2++)
                    {
                        temp *= array[dd1, dd2];
                    }
                    max = Math.Max(max,temp);
                }
            }
            return max;
        }
    }
}
