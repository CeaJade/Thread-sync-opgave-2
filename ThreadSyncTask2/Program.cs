using System;
using System.Threading;

namespace ThreadSyncTask2
{
    class Program
    {
        static int num = 60;
        static object key = new object();

        static void Main(string[] args)
        {

            while (true)
            {
                // Create two threads that call methods increase and decrease.
                Thread thread1 = new Thread(Star)
                {
                    Name = "1"
                };

                Thread thread2 = new Thread(Hash)
                {
                    Name = "2"
                };
                thread1.Start();
                Thread.Sleep(50);
                thread2.Start();
            }
        }

        // Method to print "*", 'num' amount of times.
        private static void Star()
        {
            // Check if 'key' is available. if 'key' is available run code.
            lock (key)
            {
                Console.Write("\n[Thread {0}] ", Thread.CurrentThread.Name);
                for (int i = 0; i < num; i++)
                {
                    Console.Write("*");
                    Thread.Sleep(1);
                }
                Console.WriteLine(" " + num);
                num += 60;
            }
        }

        // Method to print "#", 'num' amount of times and then increase 'num' by 60.
        static void Hash()
        {
            // Check if 'key' is available. if 'key' is available run code.
            lock (key)
            {
                Console.Write("\n[Thread {0}] ", Thread.CurrentThread.Name);
                for (int i = 0; i < num; i++)
                {
                    Console.Write("#");
                    Thread.Sleep(1);
                }
                Console.WriteLine(" " + num);
                num += 60;
            }
        }
    }
}
