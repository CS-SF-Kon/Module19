using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.BLL.Exceptions;

/// <summary>
/// Если пользователь не найден в базе данных
/// </summary>
internal class UserNotFoundException : Exception
{
}
