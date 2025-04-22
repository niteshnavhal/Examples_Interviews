using System;
using System.Runtime.Intrinsics.X86;
using System.Threading;

/*
 * Thread Safety in C# using Lock, Monitor, Mutex, and Semaphore
 * -------------------------------------------------------------------------------------------------
 * - Ensures safe access to shared resources when multiple threads operate concurrently.
 * - Demonstrates `lock`, `Monitor`, `Mutex`, and `Semaphore` for thread synchronization.
 */


/*
 * Explanation of Synchronization Methods
 * ---------------------------------------------------------------------------------------------------
 */
//
//lock (Simplest and Recommended for Most Cases)

//Prevents multiple threads from modifying a shared resource simultaneously.

//Uses less overhead compared to Monitor, Mutex, and Semaphore.

//Best choice for intra-process synchronization (when threads belong to the same process).

//Monitor (More Control Over Locking)

//Similar to lock, but allows manual entry/exit control.

//Provides Monitor.TryEnter() to avoid deadlocks.

//Useful if you need timeout-based locking.

//Mutex (Used for Inter-Process Synchronization)

//Ensures only one thread (even across different processes) can access a resource at a time.

//Slower than lock or Monitor due to cross-process access.

//Best for synchronizing resources between multiple applications.

//Semaphore (Allows a Limited Number of Threads)

//Controls how many threads can access a resource at the same time.

//Useful when limiting access to a shared resource (e.g., database connections).

//In this example, only two threads can modify counter simultaneously.

/*
 * Introduction
 * ---------------------------------------------------------------------------------------------------
 * In the ever-evolving world of software development, concurrency remains a critical concept, especially for those adept in C#.
 * Grasping the nuances of concurrency primitives like Lock, Monitor, Mutex, and Semaphore is not just about acing technical interviews; it’s about writing robust, efficient, and safe multi-threaded applications.
 * This post dives deep into these concurrency mechanisms, offering real-world examples and insights that transcend textbook definitions. Whether you’re architecting a high-traffic web application or fine-tuning performance-critical systems,\
 * understanding these tools is key to mastering the art of concurrent programming in C#.
 */

/*
 * 1.Lock
 * ---------------------------------------------------------------------------------------------------
 * Purpose: The lock keyword in C# provides a simple yet effective way of ensuring that only one thread can access a particular code block at a time. 
 * It's essentially syntactic sugar for Monitor.Enter and Monitor.Exit, offering a more straightforward and less error-prone approach.
 */

/*
 *  Monitor
 * ---------------------------------------------------------------------------------------------------
 * Purpose: Monitor, provided by the System.Threading namespace, offers more control than lock by allowing explicit acquisition and release of locks. It's useful for complex synchronization scenarios.
 */

/*
 * Mutex
 * ---------------------------------------------------------------------------------------------------
 * Purpose: A Mutex (Mutual Exclusion) is similar to a lock but can be used across different processes. It’s ideal for ensuring that only one instance of a piece of code runs across processes.
 */

/*
 * Semaphore
 * ---------------------------------------------------------------------------------------------------
 * Purpose: Semaphores are used to control access to a resource pool by multiple threads. It allows a specified number of threads to access a resource simultaneously.
 */
//✅ Use lock for most cases – it's simple and efficient.
//✅ Use Monitor if you need finer control (like timeouts).
//✅ Use Mutex if you need synchronization between different applications.
//✅ Use Semaphore to allow multiple threads to access a resource concurrently (with a limit).

class ThreadSafetyExample
{
    private int counter = 0;

    // Synchronization objects
    private readonly object lockObj = new object(); // Used for `lock` and `Monitor`
    private static readonly Mutex mutex = new Mutex();
    private static readonly Semaphore semaphore = new Semaphore(2, 2); // Allows 2 threads at a time

    // 🔹 1. Thread Safety using `lock`
    public void IncrementWithLock()
    {
        lock (lockObj) // Ensures only one thread modifies `counter` at a time
        {
            counter++;
            Console.WriteLine($"Lock: Counter = {counter}");
            Thread.Sleep(500); // Simulate work
        }
    }

    // 🔹 2. Thread Safety using `Monitor`
    public void IncrementWithMonitor()
    {
        bool lockTaken = false;
        try
        {
            Monitor.Enter(lockObj, ref lockTaken); // Acquires lock
            counter++;
            Console.WriteLine($"Monitor: Counter = {counter}");
            Thread.Sleep(500);
        }
        finally
        {
            if (lockTaken) Monitor.Exit(lockObj); // Releases lock
        }
    }

    // 🔹 3. Thread Safety using `Mutex`
    public void IncrementWithMutex()
    {
        mutex.WaitOne(); // Wait until mutex is available
        try
        {
            counter++;
            Console.WriteLine($"Mutex: Counter = {counter}");
            Thread.Sleep(500);
        }
        finally
        {
            mutex.ReleaseMutex(); // Release mutex
        }
    }

    // 🔹 4. Thread Safety using `Semaphore`
    public void IncrementWithSemaphore()
    {
        semaphore.WaitOne(); // Allow up to 2 threads to enter
        try
        {
            counter++;
            Console.WriteLine($"Semaphore: Counter = {counter}");
            Thread.Sleep(500);
        }
        finally
        {
            semaphore.Release(); // Release semaphore slot
        }
    }

    public void Run()
    {
        ThreadSafetyExample obj = new ThreadSafetyExample();

        // Create multiple threads for each synchronization method
        Thread[] threads = new Thread[8];

        for (int i = 0; i < 2; i++) threads[i] = new Thread(obj.IncrementWithLock);
        for (int i = 2; i < 4; i++) threads[i] = new Thread(obj.IncrementWithMonitor);
        for (int i = 4; i < 6; i++) threads[i] = new Thread(obj.IncrementWithMutex);
        for (int i = 6; i < 8; i++) threads[i] = new Thread(obj.IncrementWithSemaphore);

        // Start all threads
        foreach (Thread t in threads) t.Start();

        // Wait for all threads to complete
        foreach (Thread t in threads) t.Join();

        Console.WriteLine("All threads finished execution.");
    }
}
