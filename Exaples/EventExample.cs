using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    public class EventExample
    {
        // 🔹 What is an Event in C#?
        // ----------------------------------
        // An event is a wrapper around a delegate that allows a class to notify subscribers when something occurs.
        // Events can only be triggered from within the class where they are declared.
        // Subscribers (event handlers) register themselves using the += operator and unregister using -=.

        // 🔹 Step 1: Define a Delegate
        // A delegate acts as a function pointer that holds a reference to methods that match its signature.
        // Step 1: Define a delegate
        public delegate void UserRegisteredEventHandler(string username);

        // Step 2: Define a class with an event
        public class UserRegistration
        {
            public event UserRegisteredEventHandler UserRegistered;

            public void Register(string username)
            {
                Console.WriteLine($"User {username} has registered successfully!");

                // Step 3: Raise the event
                UserRegistered?.Invoke(username);
            }
        }

        // Step 4: Create subscriber classes
        public class EmailNotifier
        {
            public void OnUserRegistered(string username)
            {
                Console.WriteLine($"Sending Email to {username}");
            }
        }

        public class SmsNotifier
        {
            public void OnUserRegistered(string username)
            {
                Console.WriteLine($"Sending SMS to {username}");
            }
        }

        public class PushNotifier
        {
            public void OnUserRegistered(string username)
            {
                Console.WriteLine($" Sending Push Notification to {username}");
            }
        }

        public void Run()
        {
            var userRegistration = new UserRegistration();
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SmsNotifier();
            var pushNotifier = new PushNotifier();

            // Step 5: Subscribe to the event
            userRegistration.UserRegistered += emailNotifier.OnUserRegistered;
            userRegistration.UserRegistered += smsNotifier.OnUserRegistered;
            userRegistration.UserRegistered += pushNotifier.OnUserRegistered;

            Console.Write("Enter username to register: ");
            string username = Console.ReadLine();
            userRegistration.Register(username);

            // Step 6: Unsubscribe if needed
            userRegistration.UserRegistered -= smsNotifier.OnUserRegistered;
        }
    }
}
