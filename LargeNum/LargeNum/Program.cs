using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LargeNum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Sum is {new LargeNumber().GetSum()}");
            Console.Read();
        }
    }

    class LargeNumber
    {
        public BigInteger GetSum()
        {
            BigInteger sum = new BigInteger();
            using (StreamReader reader=new StreamReader("Numbers.txt",Encoding.UTF8))
            {
                string line;
                while ((line=reader.ReadLine())!=null)
                {
                    sum += BigInteger.Parse(line);
                }
            }
            
            return BigInteger.Parse(sum.ToString().Substring(0,10));
        }
    }
}
