using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Kaos.Combinatorics;

namespace BeautifulNumbers
{
    class MulticombinationExt:Multicombination
    {

        private int[] unicCountArray()
        {
            return this
                .GroupBy(o => o)
                .ToDictionary(g => g.Key, g => g.ToArray().Length)
                .Values
                .ToArray();
        }

        private void initPermutationSize()
        {
            var unicArray = unicCountArray();
            permutationSize = Combinatoric.Factorial(this.Picks);
            foreach (var item in unicArray)
            {
                permutationSize /= Combinatoric.Factorial(item);
            }
        }

        public MulticombinationExt(Multicombination source):base(source)
        {
            initPermutationSize();
            sum = this.Sum();
        }
        private long permutationSize { get; set; }

        private int sum { get; }

        public long PermutationSize => permutationSize;

        public int Sum => sum;
    }
}
