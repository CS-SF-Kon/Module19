using SocNet.BLL.Models;
using SocNet.BLL.Services;
using SocNet.PLL.Helpers;
using SocNet.BLL.Exceptions;

namespace SocNet.PLL.Views;

/// <summary>
/// Оформлюшка для "окна" просмотра и добавления друзей
/// </summary>
public class FriendsInfoView
{
    UserService userService;
    FriendService friendService;

    public FriendsInfoView(UserService userService, FriendService friendService)
    {
        this.userService = userService;
        this.friendService = friendService;
    }

    public void Show(User user)
    {
        Console.WriteLine($"Friends: {user.friends.Count()}"); // почему-то друзья появляются после выхода-входа в отличие от сообщений

        if (user.friends.Count() == 0)
        {
            Console.WriteLine("There is no friends yet");
        }
        else
        {
            user.friends.ToList().ForEach(f => Console.WriteLine($"{f.FriendFirstName} {f.FriendLastName} - {f.FriendEmail}"));
        }

        Console.WriteLine();

        Console.WriteLine("Let's find more friends!\nEnter your friend's email:");

        var findFriendData = new FindFriendData();

        findFriendData.FriendEmail = Console.ReadLine();

        findFriendData.UserId = user.Id;

        try
        {
            friendService.AddFriend(findFriendData);
            SuccessMessage.Show($"{findFriendData.FriendEmail} is now your friend!");
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("User not found!");
        }
       
        catch (Exception ex)
        {
            AlertMessage.Show($"Something went wrong - {ex}");
        }
    }
}
