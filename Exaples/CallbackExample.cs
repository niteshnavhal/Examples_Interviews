using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    public class CallbackExample
    {
        public delegate void CalculationCallback(decimal re);

        // Method using Delegate as Callback
        public void Add(int a, int b, CalculationCallback callback)
        {
            decimal result = a + b;
            callback(result);
        }

        // Method using Action as Callback
        public void Multiply(decimal a, decimal b, Action<decimal> callback)
        {
            decimal result = a * b;
            callback(result); // Invoke the callback function
        }
        // A non-static method to execute the example
        public void Run()
        {
            // Using a delegate as a callback
            CalculationCallback displayDelegate = result => Console.WriteLine($"[Delegate Callback] Result: {result}");
            Add(10, 5, displayDelegate); // Pass the delegate as a callback

            // Using Action as a callback
            Action<decimal> displayAction = result => Console.WriteLine($"[Action Callback] Result: {result}");
            Multiply(6, 3, displayAction); // Pass Action as a callback
        }
    }
}
