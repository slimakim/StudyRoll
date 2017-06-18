using System;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


        }

        async void FetchPageLength()
        {
            Console.WriteLine("Fetching");
            await DoSomething();         
        }

        public Task<string> DoSomething()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Ta-dah!");
            return "ta-dah, Jim";
        }


    }
}
