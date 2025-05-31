using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    internal class Count_Char_In_String
    {
        public void Run() {
            Console.Write("Enter the number of elements: ");
            string input = Console.ReadLine().ToLower();
            Dictionary<char, int> charCount = new Dictionary<char, int>();


            foreach (char c in input) {
                if (c != ' ')
                {
                    if (!charCount.ContainsKey(c))
                        charCount[c] = 0;
                    charCount[c]++;
                }
                else {
                    if (!charCount.ContainsKey(c))
                        charCount['-'] = 0;
                    charCount['-']++;
                }

            }
           
            Console.WriteLine("Character counts:");

            foreach (var kv in charCount) {
                Console.WriteLine($"'{kv.Key}': {kv.Value}");
            }

        }
    }
}
