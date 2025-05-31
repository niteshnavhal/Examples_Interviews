using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    internal class FibonacciExample
    {

        public void Run() { 
            int n1 = 0, n2 = 1,n3,i;
            Console.Write("Enter the number of elements: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("\n");
                Console.Write(n1 + " " + n2 + " ");
                for (i = 2; i < number; ++i)
                {
                    n3 = n1 + n2;
                    Console.Write(n3 + " ");
                    n1 = n2;
                    n2 = n3;
                }
            }
            else {
                Console.WriteLine("Please Enter Number betweent 1 to 100");
            }
        
        }
    }
}
