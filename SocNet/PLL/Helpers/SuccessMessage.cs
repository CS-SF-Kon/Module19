namespace SocNet.PLL.Helpers;

/// <summary>
/// Класс для оформления сообещния об успешном выполнении
/// </summary>
public class SuccessMessage
{
    public static void Show(string message)
    {
        ConsoleColor origColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = origColor;
    }
}
