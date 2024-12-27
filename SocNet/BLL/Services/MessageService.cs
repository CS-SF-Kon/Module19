using SocNet.BLL.Models;
using SocNet.DAL.Repositories;
using SocNet.BLL.Exceptions;
using SocNet.DAL.Entities;

namespace SocNet.BLL.Services;

/// <summary>
/// Сервис, отвечающий за работу с сщностью Сообщение внутри приложения. 
/// Позволяет получать перечень входящих, перечень исходящих сообщений, передавать данные о новом сообщении в БД через MessageRepository
/// </summary>
public class MessageService
{
    IMessageRepository messageRepository;
    IUserRepository userRepository;
    public MessageService()
    {
        userRepository = new UserRepository();
        messageRepository = new MessageRepository();
    }

    /// <summary>
    /// Метод для получения коллекции объектов Сообщение, обозначающей входящие сообщения
    /// </summary>
    /// <param name="recipientID"></param>
    /// <returns>Коллекция объектов Сообщение, обозначающих входящие сообщения, для использования внутри приложения</returns>
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

    /// <summary>
    /// Метод для получения коллекции объектов Сообщение, обозначающей исходящие сообщения
    /// </summary>
    /// <param name="senderID"></param>
    /// <returns>Коллекция объектов Сообщение, обозначающих исходящие сообщения, для использования внутри приложения</returns>
    public IEnumerable<Message> GetOutgoingMessagesByUserID(int senderID)
    {
        var messages = new List<Message>();

        messageRepository.FindBySenderID(senderID).ToList().ForEach(m =>
        {
            var senderUserEntity = userRepository.FindByID(m.sender_id);
            var recipientUserEntity = userRepository.FindByID(m.recipient_id);

            messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
        });

        return messages;
    }

    /// <summary>
    /// Метод для поиска пользователя и отправки ему сообщения, а также дял передачи данных в БД о новом сообщении через MessageRepository
    /// </summary>
    /// <param name="messageSendingData"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="Exception"></exception>
    public void SendMessage(MessageSendingData messageSendingData)
    {
        if (string.IsNullOrEmpty(messageSendingData.Content))
            throw new ArgumentNullException();

        if (messageSendingData.Content.Length > 5000)
            throw new ArgumentOutOfRangeException();

        var findUserEntity = userRepository.FindByEmail(messageSendingData.RecipientEmail);
        if (findUserEntity is null) throw new UserNotFoundException();

        var messageEntity = new MessageEntity()
        {
            content = messageSendingData.Content,
            sender_id = messageSendingData.SenderID,
            recipient_id = findUserEntity.id
        };

        if (messageRepository.Create(messageEntity) == 0)
            throw new Exception();
    }
}
