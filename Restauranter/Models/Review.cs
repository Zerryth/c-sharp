using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restauranter.Models
{
    public class Review : BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ReviewerName { get; set; }

        [Required]
        public string RestaurantName { get; set; }

        [Required, MinLength(10, ErrorMessage="Reviews must be at least 10 characters.")]
        public string ReviewDesc { get; set; }

        [Required, DateBeforeNow(ErrorMessage="Date must be in the past")]
        public DateTime VisitDate { get; set; } = DateTime.Now;

        [Required]
        public int Stars { get; set; }

        public int Helpful { get; set; } = 0;

        public int Unhelpful { get; set; } = 0;

    }

    public class DateBeforeNowAttribute : ValidationAttribute
    {
        public DateBeforeNowAttribute() {}
        public override bool IsValid(object enteredDate)
        {
            var dt = (DateTime)enteredDate;
            if (dt <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}