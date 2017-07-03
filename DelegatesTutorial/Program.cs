using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTutorial
{
	class Program
	{
		//Delegate: Method, Target, GetInvocationList();

		/*
		- MulticastDelegate. You cant explicitly inherit from Delegate or MulticastDelegate;
		- MulticastDelegate can reference more than one delegate functions. Is an array of multiple delegates.
		- Tracks delegate references using an invocation list.
		- Delegates in the list are invoked sequentially.
		  Combining delegates +=;
		  When you need to return a value - the last delegate wins.

		*/		
		
		static void Main(string[] args)
		{
			var worker = new Worker();

			worker.WorkPerformed += PerformWork;
			worker.WorkCompleted += PerformLazy;

			worker.DoWork(6, "Golf");

			Console.ReadKey();
		}

		static void PerformWork(object sender, WorkPerformedEventArgs args)
		{
            Console.WriteLine(string.Format("Did {0} for {1} hours.", args.WorkType, args.Hours));
		}

		static void PerformLazy(object sender, EventArgs args)
		{
			Console.WriteLine("Leaving for the dessert");
		}
	}
}
