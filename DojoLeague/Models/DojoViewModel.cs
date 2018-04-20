using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class DojoViewModel : BaseEntity
    {
        [Required, Display(Name="Dojo Name")]
        public string DojoName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required, Display(Name="Additional Dojo Information")]
        public string Info { get; set; }

    }
}