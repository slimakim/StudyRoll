using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTutorial
{
	public delegate void WorkPerformedHandler(int hours, string description);
	public class Worker
	{
		public event WorkPerformedHandler WorkPerformed;
		public event EventHandler WorkCompleted;

		public void DoWork(int hours, string description)
		{
			for (int i = 0; i < hours; i++)
			{
				OnWorkPerformed(i + 1, description);
				System.Threading.Thread.Sleep(1000);
			}

			OnWorkCompleted(hours, description);
		}

		public void OnWorkPerformed(int hours, string description)
		{
			var del = WorkPerformed as WorkPerformedHandler;
			description += " performed.";
			del?.Invoke(hours, description);			
		}

		public void OnWorkCompleted(int hours, string description)
		{
			var del = WorkCompleted as EventHandler;
			del?.Invoke(this, EventArgs.Empty);
		}
	}
}
