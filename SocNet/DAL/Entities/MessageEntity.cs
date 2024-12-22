﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.DAL.Entities;

internal class MessageEntity
{
    public int id { get; set; }
    public string content { get; set; }
    public int sender_id { get; set; }
    public int recipient_id {  get; set; }
}
