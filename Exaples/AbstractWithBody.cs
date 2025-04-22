using System;

/*
 * Abstract Class with Method Body (Real-World Example)
 * ---------------------------------------------------
 * - The `ProcessPayment()` method is abstract (must be overridden).
 * - The `PrintReceipt()` method has a body (can be used directly or overridden).
 *  Before C# 8 – Interfaces could only contain method signatures (no body).
 */
namespace Exaples
{

    abstract class Payment
    {
        // Abstract method (MUST be implemented by derived classes)
        public abstract void ProcessPayment(double amount);

        // Concrete method (CAN be used or overridden by derived classes)
        public virtual void PrintReceipt()
        {
            Console.WriteLine("Receipt: Thank you for your payment!");
        }
    }

    // Derived class for Credit Card Payment
    class CreditCardPayment : Payment
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount}");
        }

        // Overriding the concrete method
        public override void PrintReceipt()
        {
            Console.WriteLine("Receipt: Payment done using Credit Card.");
        }
    }

    // Derived class for PayPal Payment
    class PayPalPayment : Payment
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount}");
        }
        // Uses the default `PrintReceipt()` method from the base class
    }

    internal class AbstractWithBody
    {
        public void Run()
        {
            Payment payment1 = new CreditCardPayment();
            payment1.ProcessPayment(100.50);
            payment1.PrintReceipt();

            Console.WriteLine();

            Payment payment2 = new PayPalPayment();
            payment2.ProcessPayment(75.25);
            payment2.PrintReceipt();
        }
    }
}