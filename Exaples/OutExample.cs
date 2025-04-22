using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    public class DivisionHelper
    {
        public void Divide(decimal numerator, decimal denominator, out decimal quotient, out decimal remainder)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            quotient = Math.Floor(numerator / denominator);
            remainder = numerator % denominator;
        }
    }


    /// <summary>
    ///  out Keyword(Output Parameter)
    ///  Used when a method returns multiple values.
    ///  A parameter marked as out must be assigned within the method.
    ///  Example: Finding the Quotient and Remainder
    /// 
    /// </summary>
    public class OutExample
    {
        public void Run()
        {
            Console.WriteLine("Get First NO");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Get Secound NO");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            DivisionHelper helper = new DivisionHelper();
            decimal quotient, remainder;
            
            helper.Divide(a, b, out quotient, out remainder);
            Console.WriteLine($"Quotient: {quotient}, Remainder: {remainder}");
        }
    }
}
