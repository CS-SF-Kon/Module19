using SocNet.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Views;

internal class UserOutgoingMessageView
{
    public void Show(IEnumerable<Message> outgiongMessages)
    {
        Console.WriteLine("Outgiong messages:");

        if (outgiongMessages.Count() == 0)
        {
            Console.WriteLine("There is no outgiong messages yet");
            return;
        }

        outgiongMessages.ToList().ForEach(m => Console.WriteLine($"To whom: {m.RecipientEmail}: {m.Content}"));
    }
}
