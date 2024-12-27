namespace SocNet.DAL.Entities;

/// <summary>
/// Набор даннх для связи с БД, обозначающий объект Сообщение
/// </summary>
public class MessageEntity
{
    public int id { get; set; }
    public string content { get; set; }
    public int sender_id { get; set; }
    public int recipient_id {  get; set; }
}
