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

internal class UserRepository : BaseRepository, IUserRepository
{
    public int Create(UserEntity userEntity)
    {
        return Execute(@"INSERT INTO users (firstname, lastname, password, email)
                        VALUES (:firstname, :lastname, :password, :email)", userEntity);
    }

    public UserEntity FindByEmail(string email)
    {
        return QueryFirstOrDefault<UserEntity>("SELECT * FROM users WHERE email = :email_p", new { email_p = email });
    }

    public IEnumerable<UserEntity> FindAll()
    {
        return Query<UserEntity>("SELECT * FROM users");
    }

    public UserEntity FindByID(int id)
    {
        return QueryFirstOrDefault<UserEntity>("SELECT * FROM users WHERE id = :id_p", new {id_p =  id});
    }

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

    public int DeleteByID(int id)
    {
        return Execute("DELETE FROM users WHERE id = :id_p", new {id_p = id});
    }
}
