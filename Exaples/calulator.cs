using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    public class calulator
    {
        public decimal Add(decimal a, decimal b) => a + b;
        public decimal Sub(decimal a, decimal b) => a - b;
        public decimal Mul(decimal a, decimal b) => a * b;
        public decimal Div(decimal a, decimal b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero.");
    }


    public class CalculatorExample
    {
        public void Run()
        {
            calulator calc = new calulator();

            Console.WriteLine("Choose operation: 1 for Addition, 2 for Subtraction, 3 for Multiplication, 4 for Division");
            string choice = Console.ReadLine();

            Console.WriteLine("Enter first number:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal a))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter second number:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal b))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            decimal result = choice switch
            {
                "1" => calc.Add(a, b),
                "2" => calc.Sub(a, b),
                "3" => calc.Mul(a, b),
                "4" => calc.Div(a, b),
                _ => throw new InvalidOperationException("Invalid choice.")
            };

            Console.WriteLine($"Result: {result}");
        }
    }
}
