using SocNet.BLL.Exceptions;
using SocNet.BLL.Models;
using SocNet.BLL.Services;
using SocNet.PLL.Helpers;
using SocNet.PLL.Views;

namespace SocNet;

internal class Program
{
    static MessageService messageService;
    static UserService userService;
    public static MainView mainView;
    public static RegistrationView registrationView;
    public static AuthenticationView authenticationView;
    public static UserMenuView userMenuView;
    public static UserInfoView userInfoView;
    public static UserDataUpdateView userDataUpdateView;
    public static MessageSendingView messageSendView;
    public static UserIncomingMessageView userIncomingMessageView;
    public static UserOutgoingMessageView userOutgoingMessageView;

    static void Main(string[] args)
    {
        messageService = new MessageService();
        userService = new UserService();
        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticationView(userService);
        userMenuView = new UserMenuView(userService);
        userInfoView = new UserInfoView();
        userDataUpdateView = new UserDataUpdateView(userService);
        messageSendView = new MessageSendingView(userService, messageService);
        userIncomingMessageView = new UserIncomingMessageView();
        userOutgoingMessageView = new UserOutgoingMessageView();

        while (true)
        {
            mainView.Show();
        }
    }
}
