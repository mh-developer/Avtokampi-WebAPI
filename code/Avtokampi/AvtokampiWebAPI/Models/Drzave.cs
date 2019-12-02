using System;
using System.Collections.Generic;
using System.Collections;

namespace AvtokampiWebAPI.Models
{
    public partial class Drzave
    {
        public Drzave()
        {
            Regije = new HashSet<Regije>();
        }

        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public BitArray Isactive { get; set; }

        public virtual ICollection<Regije> Regije { get; set; }
    }
}
