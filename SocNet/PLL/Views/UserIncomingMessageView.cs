using SocNet.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для "окна" входящих сообщений
/// </summary>
internal class UserIncomingMessageView
{
    public void Show(IEnumerable<Message> incomingMessages)
    {
        Console.WriteLine("Incoming messages:");

        if (incomingMessages.Count() == 0)
        {
            Console.WriteLine("There is no incoming messages yet");
            return;
        }

        incomingMessages.ToList().ForEach(m => Console.WriteLine($"From {m.SenderEmail}: {m.Content}"));
    }
}
