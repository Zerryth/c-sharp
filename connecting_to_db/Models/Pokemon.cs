using System;
using System.ComponentModel.DataAnnotations;

namespace connecting_to_db.Models
{
    public abstract class BaseEntity {}
    public class Pokemon: BaseEntity
    {
        public string name { get; set; }
        public string type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}