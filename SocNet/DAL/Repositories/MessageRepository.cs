using SocNet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.DAL.Repositories;

internal interface IMessageRepository
{
    int Create(MessageEntity message);
    IEnumerable<MessageEntity> FindBySenderID(int senderID);
    IEnumerable<MessageEntity> FindByRecipientID(int recipientID);
    int DeleteByID(int messageID);
}

/// <summary>
/// Класс для взаимодействия с БД в части работы с Сообщениями. 
/// Позволяет добавлять запись в БД о новом сообщении, запрашивать перечень сообщений по id оправителя, запрашивать перечень сообщений по почте получателя, удалять записи о сообщениях по id в таблице
/// </summary>
internal class MessageRepository : BaseRepository, IMessageRepository
{
    /// <summary>
    /// Метод добавления в БД записи о новом сообщении
    /// </summary>
    /// <param name="message"></param>
    /// <returns>Выполняет запрос в БД на создание записи о новом сообщении</returns>
    public int Create(MessageEntity message)
    {
        return Execute(@"INSERT INTO messages (content, sender_id, recipient_id)
                        VALUES (:content, :sender_id, :recipient_id)", message);
    }

    /// <summary>
    /// Метод, запрашивающий записи о сообщениях по id оправителя
    /// </summary>
    /// <param name="senderID"></param>
    /// <returns>Резульат выполнения запроса</returns>
    public IEnumerable<MessageEntity> FindBySenderID(int senderID)
    {
        return Query<MessageEntity>("SELECT * FROM messages WHERE sender_id = :sender_id", new {sender_id =  senderID});
    }

    /// <summary>
    /// Метод, запрашивающий записи о сообщениях по посте получателя
    /// </summary>
    /// <param name="recipientID"></param>
    /// <returns>Резульат выполнения запроса</returns>
    public IEnumerable<MessageEntity> FindByRecipientID(int recipientID)
    {
        return Query<MessageEntity>("SELECT * FROM messages WHERE recipient_id = :recipient_id", new { recipient_id = recipientID });
    }

    /// <summary>
    /// Метод для удаления из БД записи о сообщении по id записи
    /// </summary>
    /// <param name="messageID"></param>
    /// <returns>Выполняет запрос на удаление записи в таблице</returns>
    public int DeleteByID(int messageID)
    {
        return Execute("DELETE FROM messages WHERE id = :id", new {id =  messageID});
    }
}
