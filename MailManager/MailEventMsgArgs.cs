using System;
namespace MailManager
{
    /// <summary>
    /// Mail event message arguments.
    /// </summary>
    public class MailEventMsgArgs : EventArgs
    {
        /// <summary>
        /// Mail message fields.
        /// </summary>
        public readonly string from, to, subject, body;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MailManager.MailEventMsgArgs"/> class.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="body">Body.</param>
        public MailEventMsgArgs(string from, string to, string subject, string body)
        {
            this.from = from;
            this.to = to;
            this.subject = subject;
            this.body = body;
        }


    }
}
