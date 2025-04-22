using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{

    public class NumberGenerator
    {
        public IEnumerable<int> GetEvenNumbers(int limit)
        {
            for (int i = 0; i <= limit; i += 2)
            {
                yield return i;  // Returns each even number lazily
            }
        }
    }
    public class YieldExample
    {
        public void Run()
        {
            NumberGenerator generator = new NumberGenerator();

            foreach (var number in generator.GetEvenNumbers(10))
            {
                Console.WriteLine(number);
            }
        }
    }
}
