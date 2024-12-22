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

internal class MessageRepository : BaseRepository, IMessageRepository
{
    public int Create(MessageEntity message)
    {
        return Execute(@"INSERT INTO messages (content, sender_id, recipient_id)
                        VALUES (:content, :sender_id, :recipient_id", message);
    }

    public IEnumerable<MessageEntity> FindBySenderID(int senderID)
    {
        return Query<MessageEntity>("SELECT * FROM messages WHERE sender_id = :sender_id", new {sender_id =  senderID});
    }

    public IEnumerable<MessageEntity> FindByRecipientID(int recipientID)
    {
        return Query<MessageEntity>("SELECT * FROM messages WHERE recipient_id = :recipient_id", new { recipient_id = recipientID });
    }

    public int DeleteByID(int messageID)
    {
        return Execute("DELETE FROM messages WHERE id = :id", new {id =  messageID});
    }
}
