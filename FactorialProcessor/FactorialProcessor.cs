using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialProcessor
{
    /// <summary>
    /// The class calculating factorial of a number in parallel or sequential mode
    /// </summary>
    public class FactorialProcessor
    {
        object locker = new object();

        /// <summary>
        /// Public method containing logic for parallel and sequential calculation
        /// </summary>
        /// <param name="param"> </param> 
        /// <param name="parallelMode"> </param> 

        public void Go(int param, bool parallelMode)
        {
            // Condition for validation of input parameter
            if (param >= 1 && param <= 15)

            {
                // The first code block for parallel calculation
                if (parallelMode is true)
                {
                    Console.WriteLine("Parallel  calculation of factorial:");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // Loop for creating and running a new thread of calculating factorial of each number. 
                    for (int i = 1; i <= param; i++)

                    {
                        int a = i;
                        var thread = new Thread(() => FactorialCount(a));
                        thread.Name = $"Thread# {a}";
                        thread.Start();
                    }

                    stopwatch.Stop();

                    // Console output of the results of time elapsed for calculation

                    long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                    Console.WriteLine($"Time of parallel calculation in milliseconds:" +
                        $" {elapsedMilliseconds}");

                    long elapsedTicks = stopwatch.ElapsedTicks;
                    Console.WriteLine($"Time of parallel calculation in ticks: {elapsedTicks}");
                }
                // The second code block for sequential calculation
                else

                {
                    Console.WriteLine("Sequential  calculation of factorial:");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // Calling the method in the loop without creation a new thread

                    for (int i = 1; i <= param; i++)

                    {
                        FactorialCount(i);
                    }

                    stopwatch.Stop();

                    long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                    Console.WriteLine($"Time of sequential calculation in milliseconds:" +
                        $" {elapsedMilliseconds}");

                    long elapsedTicks = stopwatch.ElapsedTicks;
                    Console.WriteLine($"Time of sequential calculation in ticks: {elapsedTicks}");
                }
            }
            //Throw ArgumentException code block

            else
            {
                throw new ArgumentException("The parameter value must be between 1 and 15", nameof(param));
            }

        }

        /// <summary>
        /// The method using recursion for calculation of factorial
        /// </summary>
        /// <param name="value"> </param> 
        
        int FactorialCount(int value)

        {
            ///Locker used to lock the code block that should be calculated by one thread only

            lock (locker)
            {
                if (value == 1)
                {
                    Console.WriteLine("Factorial of 1 equal 1");
                    return 1;
                }
                int f = 1;

                for (int i = 2; i <= value; i++)

                {
                    f *= i;
                }
                Console.WriteLine($" {Thread.CurrentThread.Name}->" +
                    $"ThreadID {Thread.CurrentThread.ManagedThreadId} -> {f}");
                Console.WriteLine($"Factorial of {value} equal {f}");
                return f;
            }
        }
    }
}
    

