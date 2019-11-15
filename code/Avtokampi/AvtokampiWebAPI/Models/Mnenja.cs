using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class Mnenja
    {
        public int MnenjeId { get; set; }
        public string Mnenje { get; set; }
        public int? Ocena { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Uporabnik { get; set; }
        public int Avtokamp { get; set; }

        public virtual Avtokampi AvtokampNavigation { get; set; }
        public virtual Uporabniki UporabnikNavigation { get; set; }
    }
}
