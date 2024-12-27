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
/// Оформлюшка для "окна" регистрации
/// </summary>
internal class RegistrationView
{
    UserService userService;

    public RegistrationView(UserService userService)
    {
        this.userService = userService;
    }

    public void Show()
    {
        var userRegistrationData = new UserRegistrationData();

        Console.Write("Enter your name:");
        userRegistrationData.FirstName = Console.ReadLine();

        Console.Write("Enter your surname:");
        userRegistrationData.LastName = Console.ReadLine();

        Console.Write("Enter your password:");
        userRegistrationData.Password = Console.ReadLine();

        Console.Write("Enter your email:");
        userRegistrationData.Email = Console.ReadLine();

        try
        {
            this.userService.Register(userRegistrationData);
            SuccessMessage.Show("Success! Now you can sign in");
        }
        catch (ArgumentNullException)
        {
            AlertMessage.Show("Some fields were filled incorrectly");
        }
        catch (Exception ex)
        {
            AlertMessage.Show($"Something went wrong - {ex}");
        }
    }
}
