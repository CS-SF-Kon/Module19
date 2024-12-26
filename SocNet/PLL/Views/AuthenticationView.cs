using SocNet.BLL.Exceptions;
using SocNet.BLL.Models;
using SocNet.BLL.Services;
using SocNet.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Views;

internal class AuthenticationView
{
    UserService userService;
    public AuthenticationView(UserService userService)
    {
        this.userService = userService;
    }

    public void Show()
    {
        var authenticationData = new UserAuthenticationData();

        Console.Write("Your email: ");
        authenticationData.Email = Console.ReadLine();

        Console.Write("Your password: ");
        authenticationData.Password = Console.ReadLine();

        try
        {
            var user = this.userService.Authenticate(authenticationData);

            SuccessMessage.Show($"Success! Welcome to FB vol.2, {user.FirstName}");

            Program.userMenuView.Show(user);
        }
        catch (WrongPasswordException)
        {
            AlertMessage.Show("Wrong password!");
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("User not found!");
        }
    }
}
