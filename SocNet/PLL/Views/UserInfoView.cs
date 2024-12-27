using SocNet.BLL.Models;

namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для "окна" профиля пользователя
/// </summary>
public class UserInfoView
{
    public void Show(User user)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("My profile");
        Console.WriteLine($"My ID: {user.Id}");
        Console.WriteLine($"My name: {user.FirstName}");
        Console.WriteLine($"My surname: {user.LastName}");
        Console.WriteLine($"My Email: {user.Email}");
        Console.WriteLine($"My photo link: {user.Photo}");
        Console.WriteLine($"My favorite movie: {user.FavoriteMovie}");
        Console.WriteLine($"My favorite book: {user.FavoriteBook}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
