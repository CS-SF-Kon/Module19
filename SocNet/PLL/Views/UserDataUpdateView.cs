using SocNet.BLL.Models;
using SocNet.BLL.Services;
using SocNet.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для "окна" редактирования профиля
/// </summary>
internal class UserDataUpdateView
{
    UserService userService;
    public UserDataUpdateView(UserService userService)
    {
        this.userService = userService;
    }

    public void Show(User user)
    {
        Console.Write("New name: ");
        user.FirstName = Console.ReadLine();

        Console.Write("New surname: ");
        user.LastName = Console.ReadLine();

        Console.Write("New photo link: ");
        user.Photo = Console.ReadLine();

        Console.Write("New favorite movie: ");
        user.FavoriteMovie = Console.ReadLine();

        Console.Write("New favorite book: ");
        user.FavoriteBook = Console.ReadLine();

        this.userService.Update(user);

        SuccessMessage.Show("Profile successfully updated");
    }
}
