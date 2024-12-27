using SocNet.DAL.Entities;

namespace SocNet.DAL.Repositories;

public interface IFriendRepository
{
    int Create(FriendEntity friend);
    IEnumerable<FriendEntity> FindAllByUserID(int userId);
    int Delete(int id);
}

/// <summary>
/// Класс для взамимодействия с БД в части работы с Друзьями. 
/// Позволяет добавлять запись в БД о новой дружбе, запрашивать перечень друзей (id) по id пользователя, удалять записи о дружбе по id в таблице (не применяется)
/// </summary>
public class FriendRepository : BaseRepository, IFriendRepository
{
    /// <summary>
    /// Метод добавления в БД записи о новой дружбе
    /// </summary>
    /// <param name="friend"></param>
    /// <returns>Выполняет запрос в БД на создание записи о новой дружбе</returns>
    public int Create(FriendEntity friend)
    {
        return Execute(@"INSERT INTO friends (user_id, friend_id) VALUES (:user_id, :friend_id), (:friend_id, :user_id)", friend); // скорректировал код запроса так, чтобы и у пользователя А появлялся друг Б, и у пользователя Б появлялся друг А. Правда, таблица друзей будет в два раза больше нужного, но пока непридумал, как сделать по-другому
    }

    /// <summary>
    /// Метод для получения записей о всех друзьях по id пользователя
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public IEnumerable<FriendEntity> FindAllByUserID(int userID)
    {
        return Query<FriendEntity>(@"SELECT * FROM friends WHERE user_id = :user_id", new {user_id = userID});
    }

    /// <summary>
    /// Метод для удаления записей о дружбе по id запсии (id запсии именно в БД)
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Выполняет запрос в БД на удаление записи о дружбе</returns>
    public int Delete(int id)
    {
        return Execute(@"DELETE FROM friends WHERE id = :id_p", new {id_p = id});
    }
}
