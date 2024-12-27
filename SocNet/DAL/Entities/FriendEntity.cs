namespace SocNet.DAL.Entities;

/// <summary>
/// Набор данных для связи с БД, обозначающий объект Друг
/// </summary>
public class FriendEntity
{
    public int id { get; set; }
    public int user_id {  get; set; }
    public int friend_id { get; set; }
}
