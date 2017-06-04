using System;
namespace MailManager
{
    public class Pager
    {
        public Pager(MailMngr mm)
        {
            mm.MailMsg += PageMsg;
        }

		private void PageMsg(Object sender, MailEventMsgArgs e)
		{
			Console.WriteLine(string.Format("Beep-beep: {0} is in trouble.", e.to));
		}

        public void Unregister(MailMngr mm)
        {
            mm.MailMsg -= PageMsg;
        }
    }
}
