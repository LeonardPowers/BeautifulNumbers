using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Kaos.Combinatorics;

namespace BeautifulNumbers
{
    class Program
    {
        public static long CalculateBeautifulCount(int choices, int pick)
        {
            var mc = new Multicombination(choices, pick);
            var listExt = mc.GetRows().Select(x => new MulticombinationExt(x));
            var sumEqualsDictionary = listExt.GroupBy(o => o.Sum)
                .ToDictionary(g => g.Key, g => g.ToArray());

            long totalSum = 0;
            foreach (var space in sumEqualsDictionary.ToList())
            {
                foreach (var itemLeft in space.Value)
                {
                    foreach (var itemRight in space.Value)
                    {
                        totalSum += itemLeft.PermutationSize * itemRight.PermutationSize;
                    }
                }
            }
            return totalSum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CalculateBeautifulCount(13,6));
        }
    }
}
