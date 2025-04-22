using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Exaples.CalculatorDelegate;

namespace Exaples
{
    /*
 * Thread Example in C# using System.Threading
 * --------------------------------------------
 * - A thread is a lightweight process that enables parallel execution.
 * - In this example, we create a thread to run the `Run()` function.
 * - The thread is started when created and properly stopped before exiting.
 * - Thread.Sleep(500) , Thread(StartThread), myThread.Join(),  myThread.IsAlive
 */

    public class ThreadExample
    {
        private Thread myThread; // Thread object
        private bool isRunning = true; // Control flag to stop the thread safely

        public void StartThread()
        {
            int count = 0;
            while (isRunning)
            {
                Console.WriteLine($"Thread is running... {++count}");
                Thread.Sleep(500); // Simulating work
            }
        }

        public void CreateThreaad()
        {
            myThread = new Thread(StartThread);
            myThread.Start();
        }

        public void StopThread()
        {
            isRunning = false; // Set the flag to stop the thread
            if (myThread != null && myThread.IsAlive)
            {
                myThread.Join(); // Wait for the thread to finish
                Console.WriteLine("Thread stopped.");
            }
        }

        public void Run() {
            CreateThreaad();
            Thread.Sleep(3000); // Simulating work
            StopThread();
        }
    }
}
