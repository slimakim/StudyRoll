using System;
namespace Patterns
{
    public class Singleton
    {
        private static class SingletonHolder
        {
            internal static readonly Singleton instance = new Singleton();

            //Empty static constructor ensures laziness
            static SingletonHolder() { }
        }

        //private constructor excludes public constructor
        private Singleton()
        {
            Console.WriteLine("Singleton constructor");
        }

        public static Singleton Instance { get { return SingletonHolder.instance; } }

        public void DoSomething()
        {
        }

        public static void SayHi()
        {
            Console.WriteLine("Say Hi!");
        }
    }
}
