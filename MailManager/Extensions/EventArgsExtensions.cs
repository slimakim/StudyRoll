using System;
using System.Threading;

namespace MailManager
{
    public static class EventArgsExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e, Object sender, ref EventHandler<TEventArgs> eventDelegate)
        {
            //Copy a reference to the delegate field now into a temporary field for thread safety
            EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);

            //if any methods subscribed to an event, notify them.
            temp?.Invoke(sender, e);
        }
    }
}
