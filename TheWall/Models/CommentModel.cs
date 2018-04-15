using System.ComponentModel.DataAnnotations;
using System;

namespace TheWall.Models
{
    public class CommentModel
    {
        public string CommentContext { get; set; }
        public int messages_id { get; set; }
        public int users_id { get; set; }
        public int CommentId { get; set; }

        public string CommenterName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}