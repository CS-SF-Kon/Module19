namespace SocNet.PLL.Helpers;

/// <summary>
/// Класс для оформления сообщения об ошибке
/// </summary>
public class AlertMessage
{
    public static void Show(string message)
    {
        ConsoleColor origColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = origColor;
    }
}
