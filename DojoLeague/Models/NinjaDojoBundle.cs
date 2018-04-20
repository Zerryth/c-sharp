using System.Collections.Generic;

namespace DojoLeague.Models
{
    public class NinjaDojoBundle
    {
        public Ninja NinjaModel { get; set;}
        public List<Dojo> DojoList { get; set; }
        public List<Ninja> NinjaList { get; set; }
    }
}