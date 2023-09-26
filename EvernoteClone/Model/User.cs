﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Lastname { get; set; }
        [MaxLength(20)]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
