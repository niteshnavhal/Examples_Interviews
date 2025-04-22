using System;
using System.Threading;
using System.Threading.Tasks;

/*
 * Deadlock Example in C# using Locks
 * -----------------------------------
 * - A deadlock occurs when two threads hold locks on resources and wait for each other to release them.
 * - In this example, Thread 1 locks `lock1` and waits for `lock2`, while Thread 2 locks `lock2` and waits for `lock1`.
 * - Since both threads are waiting on each other, they will never proceed, causing a deadlock.
 * - If changes are made to the order of acquiring locks, the deadlock can be avoided.
 */


/*
 *  What is Multithreading?
 * -----------------------------------
 */

//   
//Multithreading is a technique that allows an application to run multiple “threads” or smaller units of tasks simultaneously.By doing so, we can maximize the CPU’s efficiency, reduce waiting time for users, and make the application more responsive.

//Key Concepts to Know:
//Threads: The smallest units of execution within a process.
//Concurrency: The ability of a system to handle multiple tasks at the same time.
//In.NET Core, creating and managing threads can be done with the Thread class, giving you control over how tasks are scheduled and executed.

//When to Use Multithreading:
//CPU-intensive tasks: Operations that require significant CPU power benefit from running in separate threads.
//Independent tasks: When tasks are not dependent on one another, like image processing or parallel calculations.


/*
 * Multitasking in .NET Core with Async and Await
 * -----------------------------------------------
 */

//
//What is Multitasking?
//Multitasking allows an application to handle multiple operations simultaneously, but unlike multithreading, it focuses on asynchronous tasks that don’t need to run in parallel. This technique is especially useful in I/O-bound tasks, like network calls, where waiting for a response can slow down your application.

//Key Concepts to Know:
//Async and Await: Keywords in .NET Core that allow tasks to run asynchronously without blocking the main thread.
//Task: An operation that runs asynchronously, such as a network call or file read.
//When to Use Multitasking:
//I / O - bound operations: Tasks that involve network calls or database queries.
//Non-blocking requirements: When you want to keep the application responsive, especially in UI apps.

class DeadLockThreadExample
{
    private static readonly object lock1 = new object();
    private static readonly object lock2 = new object();

    // Method executed by Thread 1
    public void ThreadMethod1()
    {
        lock (lock1) // Acquires lock1 first
        {
            Console.WriteLine("Thread 1: Acquired lock1, waiting for lock2...");
            Thread.Sleep(1000); // Simulating some work

            lock (lock2) // Now tries to acquire lock2
            {
                Console.WriteLine("Thread 1: Acquired lock2!");
            }
        }
    }

    // Method executed by Thread 2
    public void ThreadMethod2()
    {
        lock (lock1) // Acquires lock2 first
        {
            Console.WriteLine("Thread 2: Acquired lock2, waiting for lock1...");
            Thread.Sleep(1000); // Simulating some work

            lock (lock2) // Now tries to acquire lock1
            {
                Console.WriteLine("Thread 2: Acquired lock1!");
            }
        }
    }


    public void CreateDeadlock()
    {
        Thread thread1 = new Thread(ThreadMethod1);
        Thread thread2 = new Thread(ThreadMethod2);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }

    public void Run()
    {
        Console.WriteLine("Starting deadlock example...");
        CreateDeadlock();
        Console.WriteLine("Deadlock example completed.");
    }
}