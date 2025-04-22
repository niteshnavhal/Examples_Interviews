using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exaples.MoreDelegetExamples;

namespace Exaples
{
    public class MoreDelegetExamples
    {
        public delegate decimal MathOprations(decimal a, decimal b);

        public decimal Add(decimal a, decimal b) => a + b;
        public decimal Sub(decimal a, decimal b) => a - b;
        public decimal Mul(decimal a, decimal b) => a * b;
        public decimal Div(decimal a, decimal b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero.");

        public void Run() {

            // Using delegate
            MathOprations mathOprations = null;

            //using Func for operations 
            Func<decimal, decimal, decimal> funcOp = null;
            Action<decimal> displayresult = result => Console.WriteLine($"Result: {result}");

            Console.WriteLine("Choose operation: 1 for Addition, 2 for Subtraction, 3 for Multiplication, 4 for Division");
            string choice = Console.ReadLine();

            Console.WriteLine("Enter first number:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal a)) { 
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter second number:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal b))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            switch (choice) {
                case "1":
                    mathOprations = Add;
                    funcOp = Add;
                    break;
                case "2":
                    mathOprations = Sub;
                    funcOp = Sub;
                    break;
                case "3":
                    mathOprations = Mul;
                    funcOp = Mul;
                    break;
                case "4":
                    mathOprations = Div;
                    funcOp = Div;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            decimal result = mathOprations(a, b);
            decimal result2 = funcOp(a, b);
            Console.WriteLine("Using Delegate:");
            displayresult(result);
            Console.WriteLine("Using Func:");
            displayresult(result2);

        }

    }
}
