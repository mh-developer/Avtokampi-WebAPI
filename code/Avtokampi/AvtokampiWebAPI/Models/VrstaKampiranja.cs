using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class VrstaKampiranja
    {
        public VrstaKampiranja()
        {
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int VrstaKampiranjaId { get; set; }
        public string Naziv { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
