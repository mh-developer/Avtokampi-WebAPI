using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class Pravice
    {
        public Pravice()
        {
            Uporabniki = new HashSet<Uporabniki>();
        }

        public int PravicaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Uporabniki> Uporabniki { get; set; }
    }
}
