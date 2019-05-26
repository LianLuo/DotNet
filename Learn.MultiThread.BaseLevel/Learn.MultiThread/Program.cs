using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learn.MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            var sample = new ThreadSample();
            var threadOne = new System.Threading.Thread(sample.CountNumber);
            threadOne.Name = "ThreadOne";
            var threadTwo = new System.Threading.Thread(sample.CountNumber);
            threadTwo.Name = "ThreadTwo";

            threadOne.Priority = System.Threading.ThreadPriority.Highest;
            threadTwo.Priority = System.Threading.ThreadPriority.Lowest;
            threadOne.Start();
            threadTwo.Start();

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            sample.Stop();
            Console.ReadKey();
        }

        static void PrintNumer()
        {
            Console.WriteLine("Starting...");
            for (int i = 0; i < 90; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void PrintNumberDelay()
        {
            Console.WriteLine("Delay print starting...");
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
    }

    class ThreadSample
    {
        private bool _isStopped = false;
        public void Stop()
        {
            _isStopped = true;
        }

        public void CountNumber()
        {
            long counter = 0;
            while (!_isStopped)
            {
                counter++;
            }
            Console.WriteLine("{0} with {1,11} priority has a count = {2,13}", System.Threading.Thread.CurrentThread.Name, System.Threading.Thread.CurrentThread.Priority, counter);
        }
    }
}
