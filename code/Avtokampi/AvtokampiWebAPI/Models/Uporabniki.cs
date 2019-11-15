using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class Uporabniki
    {
        public Uporabniki()
        {
            Mnenja = new HashSet<Mnenja>();
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int UporabnikId { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public byte[] Slika { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Geslo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Pravice { get; set; }

        public virtual Pravice PraviceNavigation { get; set; }
        public virtual ICollection<Mnenja> Mnenja { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
