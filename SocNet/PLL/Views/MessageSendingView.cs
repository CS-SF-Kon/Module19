﻿using SocNet.BLL.Services;
using SocNet.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocNet.PLL.Helpers;
using SocNet.BLL.Exceptions;

namespace SocNet.PLL.Views;

internal class MessageSendingView
{
    UserService userService;
    MessageService messageService;
    public MessageSendingView(UserService userService, MessageService messageService)
    {
        this.userService = userService;
        this.messageService = messageService;
    }

    public void Show(User user)
    {
        var messageSendingData = new MessageSendingData();

        Console.Write("Enter recipient email: ");
        messageSendingData.RecipientEmail = Console.ReadLine();

        Console.Write("Enter message (less than 5000 symbols): ");
        messageSendingData.Content = Console.ReadLine();

        messageSendingData.SenderID = user.Id;

        try
        {
            messageService.SendMEssage(messageSendingData);
            SuccessMessage.Show("Message successfully sent");
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("User not found!");
        }
        catch (ArgumentOutOfRangeException)
        {
            AlertMessage.Show("Too many symbols!");
        }
        catch (Exception ex)
        {
            AlertMessage.Show($"Something went wrong - {ex}");
        }
    }
}
