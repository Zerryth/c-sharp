using System;

namespace gettingStartedWithEntity.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string RestaurantName { get; set; }
        public string ReviewDesc { get; set; }
        public DateTime VisitDate { get; set; }
        public int Stars { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}