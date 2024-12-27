using SocNet.BLL.Models;
using SocNet.BLL.Exceptions;
using SocNet.DAL.Repositories;
using System.ComponentModel.DataAnnotations;
using SocNet.DAL.Entities;

namespace SocNet.BLL.Services;

/// <summary>
/// Сервис для работы с объектом Пользователь внутри приложения. 
/// Позволяет проводить регистарцию, авторизацию пользователя, поиск по почте, обновление описания профиля и сборку объекта Пользователь
/// </summary>
public class UserService
{
    IUserRepository userRepository;
    MessageService messageService;
    FriendService friendService;
    public UserService()
    {
        userRepository = new UserRepository();
        messageService = new MessageService();
        friendService = new FriendService();
    }

    /// <summary>
    /// Метод, отвечающий за регистарцию пользователя
    /// </summary>
    /// <param name="userRegistrationData"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public void Register(UserRegistrationData userRegistrationData)
    {
        if (string.IsNullOrEmpty(userRegistrationData.FirstName))
            throw new ArgumentNullException();
        if (string.IsNullOrEmpty(userRegistrationData.LastName))
            throw new ArgumentNullException();
        if (string.IsNullOrEmpty(userRegistrationData.Password))
            throw new ArgumentNullException();
        if (string.IsNullOrEmpty(userRegistrationData.Email))
            throw new ArgumentNullException();
        if (userRegistrationData.Password.Length < 8)
            throw new ArgumentNullException();
        if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
            throw new ArgumentNullException();
        if (userRepository.FindByEmail(userRegistrationData.Email) != null)
            throw new ArgumentNullException();

        var userEntity = new UserEntity()
        {
            firstname = userRegistrationData.FirstName,
            lastname = userRegistrationData.LastName,
            password = userRegistrationData.Password,
            email = userRegistrationData.Email
        };

        if (userRepository.Create(userEntity) == 0)
            throw new Exception();
    }

    /// <summary>
    /// Метод, отвечающий за авторизацию пользователя
    /// </summary>
    /// <param name="userAuthenticationData"></param>
    /// <returns>Объект Пользователь</returns>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="WrongPasswordException"></exception>
    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
       
        if (findUserEntity is null) 
            throw new UserNotFoundException();

        if (findUserEntity.password != userAuthenticationData.Password)
            throw new WrongPasswordException();

        return ConstructUserModel(findUserEntity);
    }

    /// <summary>
    /// Метод, осуществляющий поиск пользователя по почте
    /// </summary>
    /// <param name="email"></param>
    /// <returns>Объект Пользователь, найденная по почте</returns>
    /// <exception cref="UserNotFoundException"></exception>
    public User FindByEmail(string email)
    {
        var findUserEntity = userRepository.FindByEmail(email);
        if (findUserEntity is null)
            throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    /// <summary>
    /// Метод, обновляющий информацию о пользователе
    /// </summary>
    /// <param name="user"></param>
    public void Update(User user)
    {
        var updatableUserEntity = new UserEntity()
        {
            id = user.Id,
            firstname = user.FirstName,
            lastname = user.LastName,
            password = user.Password,
            email = user.Email,
            photo = user.Photo,
            favourite_movie = user.FavoriteMovie,
            favorite_book = user.FavoriteBook
        };
    }

    /// <summary>
    /// Метод, выполняющий сборку объекта Пользователь
    /// </summary>
    /// <param name="userEntity"></param>
    /// <returns>Объект Пользователь</returns>
    private User ConstructUserModel(UserEntity userEntity)
    {
        var incomingMessages = messageService.GetIncomingMessagesByUserID(userEntity.id);
        var outgoingMessages = messageService.GetOutgoingMessagesByUserID(userEntity.id);
        var friends = friendService.GetFriendsList(userEntity.id);
        return new User(userEntity.id,
                        userEntity.firstname,
                        userEntity.lastname,
                        userEntity.password,
                        userEntity.email,
                        userEntity.photo,
                        userEntity.favourite_movie,
                        userEntity.favorite_book,
                        incomingMessages,
                        outgoingMessages,
                        friends);
    }
}
