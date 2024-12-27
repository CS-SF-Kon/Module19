using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocNet.DAL.Entities;

namespace SocNet.DAL.Repositories;

internal interface IUserRepository
{
    int Create(UserEntity userEntity);
    UserEntity FindByEmail(string email);
    IEnumerable<UserEntity> FindAll();
    UserEntity FindByID(int id);
    int Update(UserEntity userEntity);
    int DeleteByID(int id);
}

/// <summary>
/// Класс для взаимодействия с БД в части работы с Пользователями. 
/// Позволяет добавлять в БД запись о новых пользователях, искать пользователя по его почте, получать перечень всех пользователей в системе (не используется), искать пользователя по его id, обновлять данные пользователя в БД, удалять запись из БД о пользователе 
/// </summary>
internal class UserRepository : BaseRepository, IUserRepository
{
    /// <summary>
    /// Метод для добавления в БД записи о новом пользователе
    /// </summary>
    /// <param name="userEntity"></param>
    /// <returns>Выполняет запрос на добавление записи в БД</returns>
    public int Create(UserEntity userEntity)
    {
        return Execute(@"INSERT INTO users (firstname, lastname, password, email)
                        VALUES (:firstname, :lastname, :password, :email)", userEntity);
    }

    /// <summary>
    /// Метод для поиска записи о пользователе по его почте
    /// </summary>
    /// <param name="email"></param>
    /// <returns>Набор данных о пользователе из БД</returns>
    public UserEntity FindByEmail(string email)
    {
        return QueryFirstOrDefault<UserEntity>("SELECT * FROM users WHERE email = :email_p", new { email_p = email });
    }

    /// <summary>
    /// Метод для получения перечня всех пользователей
    /// </summary>
    /// <returns>Коллекция наборов данных о пользователях из БД</returns>
    public IEnumerable<UserEntity> FindAll()
    {
        return Query<UserEntity>("SELECT * FROM users");
    }

    /// <summary>
    /// Метод для поиска записи о пользователе по его id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Набор данных о пользователе из БД</returns>
    public UserEntity FindByID(int id)
    {
        return QueryFirstOrDefault<UserEntity>("SELECT * FROM users WHERE id = :id_p", new {id_p =  id});
    }

    /// <summary>
    /// Метод для обновления запсии о пользователе в БД
    /// </summary>
    /// <param name="userEntity"></param>
    /// <returns>Выполняет зарпос на обновление записи в БД</returns>
    public int Update(UserEntity userEntity)
    {
        return Execute(@"UPDATE users SET firstname = :firstname,
                                          lastname = :lastname,
                                          password = :password,
                                          email = :email,
                                          photo = :photo,
                                          favourite_movie = :favourite_movie,
                                          favourite_book = :favourite_book", userEntity);
    }

    /// <summary>
    /// Метод, отвечающий за удаление записи из БД по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Выполняет запрос на удаление записи из БД</returns>
    public int DeleteByID(int id)
    {
        return Execute("DELETE FROM users WHERE id = :id_p", new {id_p = id});
    }
}
