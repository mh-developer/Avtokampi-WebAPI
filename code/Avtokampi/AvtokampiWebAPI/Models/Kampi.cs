using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class Kampi
    {
        public Kampi()
        {
            Mnenja = new HashSet<Mnenja>();
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Cena { get; set; }
        public string Kraj { get; set; }
        public byte[] Slika { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Mnenja> Mnenja { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
