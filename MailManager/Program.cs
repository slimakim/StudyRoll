using System;

namespace MailManager
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MailMngr mm = new MailMngr();
            Fax fax = new Fax(mm);
            Pager pager = new Pager(mm);

            mm.SimulateArrivingMsg(
                "jerome@hitmail.com",
                "dana@hitmail.com",
                "Inappropriate workplace behaviour",
                "Hey Dana, Jeff said you flashed him again. As your supervisor I find it highly inappropriate that you flash him before you flash me."
            );

        }
    }
}
