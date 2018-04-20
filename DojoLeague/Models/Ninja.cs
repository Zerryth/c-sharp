using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoLeague.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public int NinjaId { get; set; }

        [Required]
        [Display(Name="Ninja Name")]
        public string NinjaName { get; set; }

        [Required(ErrorMessage="Ninjaing level is required")]
        [Range(1, 10, ErrorMessage="Levels must be between 1 - 10.")]
        [Display(Name="Ninjaing Level (1-10)")]
        public int Level { get; set; }

        [Display(Name="Optional Description")]
        public string Description { get; set; }

        [ForeignKey("Dojo")]
        [Display(Name="Assigned Dojo?")]
        public int? MemberOfId { get; set; }

        public Dojo Dojo { get; set; }
    }
}