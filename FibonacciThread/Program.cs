using System;
using System.Collections.Generic;
using System.Threading;

namespace FibonacciThread
{
   

    class Program
    {

        class Container
        {
            // A container class acts as a generic holder. Define a list to hold fibonacci numbers.
            public static List<int> fibseries = new List<int>();
            //In all methods below, we can reach this list by using Container.fibseries
        }

        public static void CreateFibSeries()
        //This method is used to create a list including first 10 elements of fibonacci series
        {
            int i;
            //Add first to elements of fibonacci series 0 and 1 to the list.
            Container.fibseries.Add(0);
            Container.fibseries.Add(1);
            //Starting from 2nd index, insert the other elements of fibonacci in the list.
            for (i = 2; i < 10; ++i)
                Container.fibseries.Insert(i, Container.fibseries[i - 1] + Container.fibseries[i - 2]);
        }

        public static void thread1()//first thread
        {
            Console.Write("Fibonacci Series:");
            for (int i = 0; i < 10; i += 1)
            {
                Console.Write(Container.fibseries[i] + " ");
                Thread.Sleep(500);
            }
            Console.WriteLine();

        }

        public static void thread2()//second thread
        {
            Console.Write("Reversed Series:");
            for (int i = 9; i >= 0; i -= 1)
            {
                Console.Write(Container.fibseries[i] + " ");
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            CreateFibSeries();
            Thread th1 = new Thread(new ThreadStart(thread1));
            Thread th2 = new Thread(new ThreadStart(thread2));

            th1.Start();
            th1.Join();
            Thread.Sleep(5000);
            th2.Start();
        }

    }//end of class program
}
