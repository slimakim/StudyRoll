using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;



namespace DelegatesExample
{
    /// <summary>
    /// Main class.
    /// </summary>
    class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            StaticCallbacks();
            InstanceCallbacks();
        }

        private static void StaticCallbacks()
        {
            Set setOfItems = new Set(5);

            setOfItems.ProcessItems(null);

            Console.WriteLine();

            setOfItems.ProcessItems(MainClass.FeedbackToConsole);

            Console.WriteLine();

            setOfItems.ProcessItems(MainClass.FeedBackToMsgBox);

            Console.WriteLine();

            Set.Feedback fb = null;

            fb += new Set.Feedback(MainClass.FeedbackToConsole);

            fb += new Set.Feedback(MainClass.FeedBackToMsgBox);

            foreach (var dlgt in fb.GetInvocationList())
            {
                Console.WriteLine("Delegate info: {0}", dlgt.Method.ToString());
            }       

            setOfItems.ProcessItems(fb);

            Console.WriteLine();
        }

        private static void FeedbackToConsole(Object value, int item, int numItems)
        {
            Console.WriteLine(string.Format("Processing item {0} of {1}: {2}.", item, numItems, value));
        }

        private static void FeedBackToMsgBox(Object value, int item, int numItems)
        {
            Console.WriteLine("====================================");
            Console.WriteLine(string.Format("| Processing item {0} of {1}", item, numItems));
            Console.WriteLine(string.Format("| Object: {0}", value));
            Console.WriteLine("====================================");
        }

        public static void InstanceCallbacks()
        {
            Set setOfItems = new Set(6);

            var appobj = new MainClass();

            setOfItems.ProcessItems(new Set.Feedback(appobj.FeedBackToFile));
        }

        private void FeedBackToFile(Object value, int item, int numItems)
        {
            Console.WriteLine(string.Format("Dumping to file item {0} of {1}\nitem value:\t {2}", item, numItems, value));
        }
    }
}
