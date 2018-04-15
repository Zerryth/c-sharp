using System.ComponentModel.DataAnnotations;
using System;

namespace TheWall.Models
{
    public class MessageModel
    {
        [Required]
        public string MessageContext { get; set; }
        [Required]
        public int users_id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}