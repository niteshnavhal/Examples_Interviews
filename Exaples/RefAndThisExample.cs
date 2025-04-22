    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    internal class RefAndThisExample
    {
        /*
        * - ref is used to pass variables by reference, allowing the called method to modify the original value
        * - this refers to the current instance of a class or struct.
        */
        private int number;// <-- This is the instance variable (field)
        public RefAndThisExample(int number)// <-- This `number` is a parameter
        {
            this.number = number; // `this.number` refers to the instance variable, `number` refers to the parameter
        }

        // ✅ Using `ref` to modify the original value
        public void DoubleValue(ref int value)
        {
            value *= 2; // Modifies the original variable since it's passed by reference
            Console.WriteLine($"Inside Method: Value Doubled = {value}");
        }

        public void Display()
        {
            Console.WriteLine($"Instance Variable (this.number) = {this.number}");
        }

        public void Rund() {
            // ✅ `this` Example (Refers to instance variable)
            RefAndThisExample obj = new RefAndThisExample(10);
            obj.Display();

            Console.WriteLine("\nUsing `ref` Keyword:");

            // ✅ `ref` Example (Pass variable by reference)
            int myNumber = 5;
            Console.WriteLine($"Before Method Call: myNumber = {myNumber}");

            obj.DoubleValue(ref myNumber);

            Console.WriteLine($"After Method Call: myNumber = {myNumber}"); // Value is modified

        }
    }
}
