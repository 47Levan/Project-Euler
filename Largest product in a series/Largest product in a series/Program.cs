using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_product_in_a_series
{
    class Program
    {
        static void Main(string[] args)
        {
            Thoutsenddigits thousendDigits = new Thoutsenddigits();
            int a = thousendDigits.Largest_product_in_a_series(
                "731671765313306249192251196744265747423553491949349698352031" +
                "277450632623957831801698480186947885184385861560789112949495" +
                "4595017379583319528532088055111254069874715852386305071569329" +
                "0963295227443043557668966489504452445231617318564030987111217" +
                "2238311362229893423380308135336276614282806444486645238749303" +
                "58907296290491560440772390713810515859307960866701724271218839" +
                "98797908792274921901699720888093776657273330010533678812202354" +
                "21809751254540594752243525849077116705560136048395864467063244" +
                "1572215539753697817977846174064955149290862569321978468622482" +
                "8397224137565705605749026140797296865241453510047482166370484" +
                "40319989000889524345065854122758866688116427171479924442928230" +
                "8634656748139191231628245861786645835912456652947654568284891" +
                "2883142607690042242190226710556263211111093705442175069416589" +
                "6040807198403850962455444362981230987879927244284909188845801" +
                "56166097919133875499200524063689912560717606058861164671094050" +
                "7754100225698315520005593572972571636269561882670428252483600" +
                "823257530420752963450",13);
            Console.WriteLine(a);
            Console.Read();
        }
    }

    class Thoutsenddigits
    {
        public int Largest_product_in_a_series(string number,int count)
        {
            int max = 1;
            for (int i = 0; i < number.Length - count; i++)
            {
                IEnumerable<int> tempArray = number.Substring(i, count).ToCharArray()
                    .Select(x => int.Parse(x.ToString()));
                int temp = tempArray.Aggregate(1, (current, item) => current * item);
                if (temp > max)
                {
                    max = temp;
                }
            }
            return max;
        }
    }
}
