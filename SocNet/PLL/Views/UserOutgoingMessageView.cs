using SocNet.BLL.Models;

namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для "окна" исходящих сообщений
/// </summary>
public class UserOutgoingMessageView
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
