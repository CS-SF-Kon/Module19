namespace SocNet.BLL.Models;

/// <summary>
/// Набор данных для отправки сообщения
/// </summary>
public class MessageSendingData
{
    public int SenderID { get; set; }
    public string Content { get; set; }
    public string RecipientEmail { get; set; }
}
