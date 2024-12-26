using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.BLL.Models;

internal class Friend
{
    public string FriendFirstName {  get; set; }
    public string FriendLastName {  get; set; }
    public string FriendEmail { get; set; }

    public Friend(string userName, string userSurname, string friendEmail)
    {
        FriendFirstName = userName;
        FriendLastName = userSurname;
        FriendEmail = friendEmail;
    }
}
