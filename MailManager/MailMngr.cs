using System;

namespace MailManager
{
    /// <summary>   
    /// Mail manager.
    /// </summary>
    public class MailMngr
    {
        /// <summary>
        /// Occurs when mail message.
        /// </summary>
        public event EventHandler<MailEventMsgArgs> MailMsg;

        /// <summary>
        /// Ons the mail message.
        /// </summary>
        /// <param name="e">E.</param>
        protected virtual void OnMailMsg(MailEventMsgArgs e)
        {
            e.Raise(this, ref MailMsg);
        }

        public void SimulateArrivingMsg(string from, string to, string subject, string body)
        {
            MailEventMsgArgs e = new MailEventMsgArgs(from, to, subject, body);

            OnMailMsg(e);
        }
    }
}
