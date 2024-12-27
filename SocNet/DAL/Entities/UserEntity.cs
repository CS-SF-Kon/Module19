namespace SocNet.DAL.Entities;

/// <summary>
/// Набор даннх для связи с БД, обозначающий объект Пользователь
/// </summary>
public class UserEntity
{
    public int id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string photo { get; set; }
    public string favourite_movie { get; set; }
    public string favorite_book { get; set; }
}
