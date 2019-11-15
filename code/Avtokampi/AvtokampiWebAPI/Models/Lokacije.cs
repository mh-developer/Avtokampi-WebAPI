using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class Lokacije
    {
        public Lokacije()
        {
            Avtokampi = new HashSet<Avtokampi>();
        }

        public int LokacijaId { get; set; }
        public string Naziv { get; set; }
        public string KoordinataX { get; set; }
        public string KoordinataY { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Regija { get; set; }

        public virtual Regije RegijaNavigation { get; set; }
        public virtual ICollection<Avtokampi> Avtokampi { get; set; }
    }
}
