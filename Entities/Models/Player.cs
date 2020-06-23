﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("PLAYERS")]
    public class Player
    {
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }
    }
}
