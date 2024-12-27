using SocNet.BLL.Models;
using SocNet.DAL.Repositories;
using SocNet.BLL.Exceptions;
using SocNet.DAL.Entities;

namespace SocNet.BLL.Services;

/// <summary>
/// Сервис, отвечающий за работу с объектом Друг внутри приложения. 
/// Позволяет создавать перечень друзей (имя и фамилия) по id пользователя, передавать данные о новой дружбе в БД через FriendRepository
/// </summary>
public class FriendService
{
    IFriendRepository friendRepository;
    IUserRepository userRepository;

    public FriendService()
    {
        friendRepository = new FriendRepository();
        userRepository = new UserRepository();
    }

    /// <summary>
    /// Метод для полученния коллекции объектов Друг
    /// </summary>
    /// <param name="userID"></param>
    /// <returns>Коллекция объектов Друг для использования внутри приложения</returns>
    public IEnumerable<Friend>GetFriendsList(int userID)
    {
        var friends = new List<Friend>();
        friendRepository.FindAllByUserID(userID).ToList().ForEach(f =>
        {
            var friendID = userRepository.FindByID(f.friend_id);

            friends.Add(new Friend(friendID.firstname, friendID.lastname, friendID.email));
        });

        return friends;
    }

    /// <summary>
    /// Метод для поиска друга по почте и передачи информции о новой дружбе в БД через FriendRepository
    /// </summary>
    /// <param name="friend"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="Exception"></exception>
    public void AddFriend(FindFriendData friend)
    {
        if (String.IsNullOrEmpty(friend.FriendEmail))
            throw new ArgumentNullException();

        var findFriend = userRepository.FindByEmail(friend.FriendEmail);
        if (findFriend is null) throw new UserNotFoundException();

        var friendEntity = new FriendEntity()
        {
            user_id = friend.UserId,
            friend_id = findFriend.id
        };

        if (friendRepository.Create(friendEntity) == 0) // интересная конструкция, сразу и выполнение, и проверка результата выполнения. try-catch на минималках
            throw new Exception();

    }

}
