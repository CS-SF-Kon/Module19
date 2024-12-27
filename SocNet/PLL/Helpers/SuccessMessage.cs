using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Helpers;

/// <summary>
/// Класс для оформления сообещния об успешном выполнении
/// </summary>
internal class SuccessMessage
{
    public static void Show(string message)
    {
        ConsoleColor origColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = origColor;
    }
}
