using SocNet.BLL.Models;

namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для "окна" входящих сообщений
/// </summary>
public class UserIncomingMessageView
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
