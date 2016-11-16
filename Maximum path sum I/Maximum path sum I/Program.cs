using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using MoreLinq;
namespace Maximum_path_sum_I
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Triangle triangle = new Triangle();
            int[][] array = triangle.GetTriangle("BigTriangle.txt");
            int sum = triangle.MaxSum(array);

            Console.WriteLine(sum);
            Console.Read();
        }
    }

    class Triangle
    {
        public int[][] GetTriangle(string path)
        {
            string text;
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }
            List<string[]> temp = text.Split('\n').Select(x => x.Split()).ToList();
            int[][] result = new int[temp.Count][];
            for (int i = 0; i < temp.Count(); i++)
            {
                List<int> temp2 = new List<int>();
                for (int j = 0; j < temp[i].Count(); j++)
                {
                    if (temp[i][j] != "")
                    {
                        temp2.Add(int.Parse(temp[i][j]));
                    }
                }
                result[i] = temp2.ToArray();
            }
            return result;
        }
        public int MaxSum(int[][] array)
        {
            foreach (var item in array)
            {
                item.ForEach(x => { Console.Write($"{x} "); });
                Console.WriteLine();
            }
            for (int i = array.Length - 2; i >= 0; i--)
            {
                for (int j = array[i].Length - 1; j >= 0; j--)
                {
                    int max = 0;
                    for (int k = j - 1; k <= j + 1; k++)
                    {
                        if (k >= 0 && k < array[i+1].Length)
                        {
                            max = Math.Max(array[i][j] + array[i+1][k],max);
                        }
                    }
                    array[i][j] = max;
                }
                foreach (var item in array)
                {
                    item.ForEach(x => { Console.Write($"{x} "); });
                    Console.WriteLine();
                }
            }
      
            return array[0][0];
        }

        public int MaxSum2(int[][] array)
        {
          
            int lines = array.Length;

            for (int i = lines - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    array[i][j] += Math.Max(array[i + 1][j], array[i + 1][j + 1]);
                }
            }
            return array[0][0];
        }
    }
}
