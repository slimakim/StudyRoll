using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingFw
{
	class MainClass
	{
        #region Example1

        static void PrintText(string text)
        {
            lock (typeof(MainClass))
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(string.Format("{0}:{1}",text,i));
                    Thread.Sleep(100);
                }
            }
        }

		

		static void FirstPrinter()
        {
            
            PrintText("x");

        }

        static void SecondPrinter()
        {
            PrintText("o");
        }

        #endregion Example1

        static int[] buffer = new int[100];

        static Thread writer;

		static void Main() 
        {
            /* Example:1
             * 
             * Thread th1 = new Thread(new ThreadStart(FirstPrinter));
            Thread th2 = new Thread(new ThreadStart(SecondPrinter));

            th1.Start();
            th2.Start();
            */

            for (int i = 0; i < 100; i++)
            {
                buffer[i] = i + 1;
            }

            writer = new Thread(new ThreadStart(WriterFunc));

            writer.Start();

            Thread[] readers = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                readers[i] = new Thread(new ThreadStart(ReaderFunc));
                readers[i].Start();
            }
        }

        static void ReaderFunc() {
            while (writer.IsAlive) {
                int sum = 0;

                lock (buffer)
                {
                    for (int k = 0; k < 100; k++) sum += buffer[k];
                }

                if (sum != 5050)
                {
                    Console.WriteLine(string.Format("Error in sum: {0}", sum));
                    return;
                }
                else
				{
					Console.WriteLine(string.Format("Correct sum: {0}", sum));
					return;
				}    
            }
        }

        static void WriterFunc()
        {
            Random rnd = new Random();

            DateTime start = DateTime.Now;

            while ((DateTime.Now - start).Seconds < 10) {
                int j = rnd.Next(0, 100);
                int k = rnd.Next(0, 100);
                int tmp = buffer[k];
                buffer[j] = buffer[k];
                buffer[k] = tmp;
            }
        }
    }
}
