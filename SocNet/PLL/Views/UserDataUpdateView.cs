using SocNet.BLL.Models;
using SocNet.BLL.Services;
using SocNet.PLL.Helpers;

namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для "окна" редактирования профиля
/// </summary>
public class UserDataUpdateView
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

        userService.Update(user);

        SuccessMessage.Show("Profile successfully updated");
    }
}
