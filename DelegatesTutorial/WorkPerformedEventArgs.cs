using System;
namespace DelegatesTutorial
{
    public class WorkPerformedEventArgs : System.EventArgs
    {
        public int Hours { get; set; }

        public string WorkType { get; set; }
    }
}
