using SocNet.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Views;

internal class UserInfoView
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
