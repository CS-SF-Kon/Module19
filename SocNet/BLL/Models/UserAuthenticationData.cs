using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.BLL.Models;

/// <summary>
/// Набор данных для авторизации
/// </summary>
internal class UserAuthenticationData
{
    public string Email { get; set; }
    public string Password { get; set; }
}
