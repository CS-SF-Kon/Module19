using SocNet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.DAL.Repositories;

internal interface IFriendRepository
{
    int Create(FriendEntity friend);
    IEnumerable<FriendEntity> FindAllByUserID(int userId);
    int Delete(int id);
}

internal class FriendRepository : BaseRepository, IFriendRepository
{
    public int Create(FriendEntity friend)
    {
        return Execute(@"INSERT INTO friends (user_id, friend_id) VALUES (:user_id, :friend_id)", friend);
    }

    public IEnumerable<FriendEntity> FindAllByUserID(int userID)
    {
        return Query<FriendEntity>(@"SELECT * FROM friends WHERE user_id = :user_id", new {user_id = userID});
    }

    public int Delete(int id)
    {
        return Execute(@"DELETE FROM friends WHERE id = :id_p", new {id_p = id});
    }
}
