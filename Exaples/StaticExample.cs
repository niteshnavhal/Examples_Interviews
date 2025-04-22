using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    public class StaticExample
    {
        public string id;
        public string name;

        public StaticExample()
        {
        }

        public StaticExample(string name, string id)
        {
            this.name = name;
            this.id = id;
        }

        public static int employeeCounter;

        public static int AddEmployee()
        {
            return ++employeeCounter;
        }
    }

    class StatinClass : StaticExample
    {
        public void Run()
        {
            Console.Write("Enter the employee's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the employee's ID: ");
            string id = Console.ReadLine();

            // Create and configure the employee object.
            StaticExample e = new StaticExample(name, id);
            Console.Write("Enter the current number of employees: ");
            string n = Console.ReadLine();
            StaticExample.employeeCounter = Int32.Parse(n);
            StaticExample.AddEmployee();

            // Display the new information.
            Console.WriteLine($"Name: {e.name}");
            Console.WriteLine($"ID:   {e.id}");
            Console.WriteLine($"New Number of Employees: {StaticExample.employeeCounter}");
        }
    }
}
