namespace SocNet.BLL.Models;

/// <summary>
/// Набор данных для поиска друга по почте
/// </summary>
public class FindFriendData
{
    public int UserId { get; set; }
    public string FriendEmail {  get; set; }
}
