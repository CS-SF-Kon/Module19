﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.DAL.Entities;

internal class UserEntity
{
    public int id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string photo { get; set; }
    public string favourite_movie { get; set; }
    public string favorite_book { get; set; }
}
