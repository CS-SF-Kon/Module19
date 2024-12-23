using SocNet.BLL.Models;
using SocNet.DAL.Repositories;
using SocNet.BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocNet.DAL.Entities;

namespace SocNet.BLL.Services;

internal class MessageService
{
    IMessageRepository messageRepository;
    IUserRepository userRepository;
    public MessageService()
    {
        userRepository = new UserRepository();
        messageRepository = new MessageRepository();
    }

    public IEnumerable<Message> GetIncomingMessagesByUserID(int recipientID)
    {
        var messages = new List<Message>();

        messageRepository.FindByRecipientID(recipientID).ToList().ForEach(m =>
        {
            var senderUserEntity = userRepository.FindByID(m.sender_id);
            var recipientUserEntity = userRepository.FindByID(m.recipient_id);

            messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
        });

        return messages;
    }

    public IEnumerable<Message> GetOutgoingMessagesByUserID(int senderID)
    {
        var messages = new List<Message>();

        messageRepository.FindByRecipientID(senderID).ToList().ForEach(m =>
        {
            var senderUserEntity = userRepository.FindByID(m.sender_id);
            var recipientUserEntity = userRepository.FindByID(m.recipient_id);

            messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
        });

        return messages;
    }

    public void SendMEssage(MessageSendingData messageSendingData)
    {
        if (String.IsNullOrEmpty(messageSendingData.Content))
            throw new ArgumentNullException();

        if (messageSendingData.Content.Length > 5000)
            throw new ArgumentOutOfRangeException();

        var findUserEntity = this.userRepository.FindByEmail(messageSendingData.RecipientEmail);
        if (findUserEntity is null) throw new UserNotFoundException();

        var messageEntity = new MessageEntity()
        {
            content = messageSendingData.Content,
            sender_id = messageSendingData.SenderID,
            recipient_id = findUserEntity.id
        };

        if (this.messageRepository.Create(messageEntity) == 0)
            throw new Exception();
    }
}
