using Exaples;
using System;
using System.Collections.Generic;
using System.Threading;

class program
{
    static void Main()
    {
        Dictionary<string, Action> actions = new Dictionary<string, Action> {

            { "1", () => new CalculatorExample().Run() },
            { "2", () => new CalculatorDelegate().Run() }, 
            { "3", () => new MoreDelegetExamples().Run() },
            { "4", () => new CallbackExample().Run() },
            { "5", () => new OutExample().Run() },
            { "6", () => new InExample().Run() },
            { "7", () => new YieldExample().Run() },
            { "8", () => new StatinClass().Run() },
            { "9", () => new DictionaryExamples().Run() },
            { "10", () => new ThreadExample().Run() },
            { "11", () => new DeadLockThreadExample().Run() },
            { "12", () => new EventExample().Run() },
            { "13", () => new ThreadSafetyExample().Run() },
            { "14", () => new AbstractExample().Run() },
            { "15", () => new AbstractWithBody().Run() },
              { "16", () => new password().Run() }
        };

        bool continueApp = true;

        while (continueApp)

        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1 - Calculator");
            Console.WriteLine("2 - CalculatorDelegate");
            Console.WriteLine("3 - MoreDelegetExamples");
            Console.WriteLine("4 - Call Back Function in C#");
            Console.WriteLine("5 - OutExample in C#");
            Console.WriteLine("6 - InExample in C#");
            Console.WriteLine("7 - YieldExample in C#");
            Console.WriteLine("8 - Static Example");
            Console.WriteLine("9 - Dictionary Examples");
            Console.WriteLine("10 - ThreadExample Start and Destroy");
            Console.WriteLine("11 - DeadLockThreadExample");
            Console.WriteLine("12 - EventExample");
            Console.WriteLine("13 - ThreadSafetyExample");
            Console.WriteLine("14 - AbstractExample");
            Console.WriteLine("15 - AbstractWithBody");
            Console.WriteLine("16 - AbstractWithBody");

            //Console.WriteLine("10 - Threading Example");
            Console.WriteLine("0 - Exit");

            string choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("Exiting the application. Goodbye!");
                break;
            }

            // Execute the corresponding action using the dictionary
            if (actions.TryGetValue(choice, out Action action))
            {
                action.Invoke();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine("Do you want to continue? (y/n)");
            continueApp = Console.ReadLine().ToLower() == "y";
        }
    }
}