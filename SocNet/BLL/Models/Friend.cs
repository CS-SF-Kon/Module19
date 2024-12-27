namespace SocNet.BLL.Models;

/// <summary>
/// Описание  объекта Друг, которой оперирует приложение внутри себя
/// </summary>
public class Friend
{
    public string FriendFirstName {  get; set; }
    public string FriendLastName {  get; set; }
    public string FriendEmail { get; set; }

    public Friend(string userName, string userSurname, string friendEmail)
    {
        FriendFirstName = userName;
        FriendLastName = userSurname;
        FriendEmail = friendEmail;
    }
}
