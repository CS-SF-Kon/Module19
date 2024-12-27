using SocNet.BLL.Models;
using SocNet.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для "окна" главного меню
/// </summary>
internal class UserMenuView
{
    UserService UserService;

    public UserMenuView(UserService userService)
    {
        UserService = userService;
    }

    public void Show(User user)
    {
        while (true)
        {
            Console.WriteLine($"Friends: {user.friends.Count()}\n"); // 
            
            Console.WriteLine($"Incoming messages: {user.incomingMessages.Count()}");
            Console.WriteLine($"Outgoing messages: {user.outgoingMessages.Count()}\n");

            Console.WriteLine("Profile (1)");
            Console.WriteLine("Edit profile (2)");
            Console.WriteLine("Add a friends (3)");
            Console.WriteLine("Write a message (4)");
            Console.WriteLine("Check incoming messages (5)");
            Console.WriteLine("Check outgoing messages (6)");
            Console.WriteLine("Logout (7)");

            string keyValue = Console.ReadLine();

            if (keyValue == "7") break;

            switch (keyValue)
            {
                case "1":
                    {
                        Program.userInfoView.Show(user);
                        break;
                    }
                case "2":
                    {
                        Program.userDataUpdateView.Show(user);
                        break;
                    }
                case "3":
                    {
                        Program.friendsInfoView.Show(user); 
                        break;
                    }
                case "4":
                    {
                        Program.messageSendView.Show(user);
                        break;
                    }
                case "5":
                    {
                        Program.userIncomingMessageView.Show(user.incomingMessages);
                        break;
                    }
                case "6":
                    {
                        Program.userOutgoingMessageView.Show(user.outgoingMessages);
                        break;
                    }
            }
        }
    }
}
