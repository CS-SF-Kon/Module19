using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.BLL.Models;

/// <summary>
/// Набор данных для поиска друга по почте
/// </summary>
internal class FindFriendData
{
    public int UserId { get; set; }
    public string FriendEmail {  get; set; }
}
