using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_Sundays
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
        }
    }

    class CountingSundays
    {
        public int GetSundaysCount()
        {
            int counter = 0;
            DateTime beginDate = new DateTime(1901,1,1);
            while(beginDate<new DateTime(2000,12,31))
            {
                if (beginDate.DayOfWeek==DayOfWeek.Monday)
                {
                    counter++;
                }
                beginDate=beginDate.AddDays(1);
            }
            return counter;
        }
    }
}
