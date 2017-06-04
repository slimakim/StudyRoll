using System;
namespace MailManager
{
    public class Fax
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MailManager.Fax"/> class.
        /// </summary>
        /// <param name="mm">Mm.</param>
        public Fax(MailMngr mm)
        {
            mm.MailMsg += FaxMsg;
        }

        /// <summary>
        /// Faxs the message.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void FaxMsg(Object sender, MailEventMsgArgs e)
        {
            Console.WriteLine("Sending fax...");
            Console.WriteLine(string.Format("Message from {0} to {1}.", e.from, e.to));
            Console.WriteLine(string.Format("Subject: {0}", e.subject));
            Console.WriteLine(e.body);
        }

        public void Unregister(MailMngr mm)
        {
            mm.MailMsg -= FaxMsg;
        }
    }
}
