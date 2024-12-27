using SocNet.BLL.Services;
using SocNet.PLL.Views;

namespace SocNet;

public class Program
{
    static MessageService messageService;
    static UserService userService;

    static FriendService friendService;

    public static MainView mainView;
    public static RegistrationView registrationView;
    public static AuthenticationView authenticationView;
    public static UserMenuView userMenuView;
    public static UserInfoView userInfoView;
    public static UserDataUpdateView userDataUpdateView;
    public static MessageSendingView messageSendView;
    public static UserIncomingMessageView userIncomingMessageView;
    public static UserOutgoingMessageView userOutgoingMessageView;

    public static FriendsInfoView friendsInfoView;

    static void Main(string[] args)
    {
        messageService = new MessageService();
        userService = new UserService();

        friendService = new FriendService();

        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticationView(userService);
        userMenuView = new UserMenuView(userService);
        userInfoView = new UserInfoView();
        userDataUpdateView = new UserDataUpdateView(userService);
        messageSendView = new MessageSendingView(userService, messageService);
        userIncomingMessageView = new UserIncomingMessageView();
        userOutgoingMessageView = new UserOutgoingMessageView();

        friendsInfoView = new FriendsInfoView(userService, friendService);

        while (true)
        {
            mainView.Show();            
        }
    }
}
