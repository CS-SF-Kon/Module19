using SocNet.BLL.Models;
using SocNet.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocNet.BLL.Exceptions;
using SocNet.DAL.Entities;

namespace SocNet.BLL.Services;

internal class FriendService
{
    IFriendRepository friendRepository;
    IUserRepository userRepository;

    public FriendService()
    {
        friendRepository = new FriendRepository();
        userRepository = new UserRepository();
    }

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

        if (friendRepository.Create(friendEntity) == 0)
            throw new Exception();

    }

}
