using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.BLL.Models;

internal class MessageSendingData
{
    public int SenderID { get; set; }
    public string Content { get; set; }
    public string RecipientEmail { get; set; }
}
