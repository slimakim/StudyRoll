using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingFw
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(DoSomeWork);

           // thread.IsBackground = true;
            thread.Start();
            
            Thread.Sleep(4000);
            Console.WriteLine("First thread quitting work");

            
        }

        public static void DoSomeWork()
        {
            while (true)
            {
                Console.WriteLine("Second thread working");
                Thread.Sleep(1500);
            }
        }


    }
}
