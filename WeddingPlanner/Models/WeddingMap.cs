using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class WeddingMap : BaseEntity
    {
        [Key]
        public int MapId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }
    }
}