using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int WeddingId { get; set; }

        [Required]
        [Display(Name="Wedder One")]
        public string WedderOne { get; set; }
        
        [Required]
        [Display(Name="Wedder Two")]
        public string WedderTwo { get; set; }

        [Required]
        [Display(Name="Date")]
        public DateTime WeddingDate { get; set; }

        [Required]
        [Display(Name="Wedding Address")]
        public string WeddingAddress { get; set; }
        public int? CreatorId { get; set; }

        public List<WeddingMap> Guests { get; set; }

        public Wedding()
        {
            Guests = new List<WeddingMap>();
        }
    }
}