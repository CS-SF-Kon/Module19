using SocNet.BLL.Models;
using SocNet.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.PLL.Views;

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
            Console.WriteLine($"Incoming messages: {user.IncomingMessages.Count()}");
            Console.WriteLine($"Outgoing messages: {user.OutgoingMessages.Count()}");

            Console.WriteLine("Profile (1)");
            Console.WriteLine("Edit profile (2)");
            Console.WriteLine("Add a friends (3)");
            Console.WriteLine("Write a message (4)");
            Console.WriteLine("Check incoming messages (5)");
            Console.WriteLine("Check outgoing messages (6)");
            Console.WriteLine("Logout (7)");

            string keyValue = Console.ReadLine();

            if (keyValue == "7") break;

            switch (keyValue) {
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
                case "4":
                    {
                        Program.messageSendView.Show(user);
                        break;
                    }
                case "5":
                    {
                        Program.incomingMessageView.Show(user.IncomingMessages);
                        break;
                    }
                case "6":
                    {
                        Program.outgoingMessageView.Show(user.OutgoingMessages);
                        break;
                    }
            }
    }
}
