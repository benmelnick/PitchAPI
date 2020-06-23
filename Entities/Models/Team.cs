using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TEAMS")]
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Column("team_name")]
        public string TeamName { get; set; }

        public string League { get; set; }

        public string Division { get; set; }
    }
}
