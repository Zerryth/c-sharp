using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Dojo : BaseEntity
    {
        [Key]
        public int DojoId { get; set; }
        public string DojoName { get; set; }
        public string Location { get; set; }
        public string Info { get; set; }

        public List<Ninja> NinjaCohort { get; set; }

        public Dojo()
        {
            NinjaCohort = new List<Ninja>();
        }
    }
}