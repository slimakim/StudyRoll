using System;

namespace Patterns
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Singleton.SayHi();
            Console.WriteLine("Start of test");
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            Console.ReadKey();
        }
    }
}
