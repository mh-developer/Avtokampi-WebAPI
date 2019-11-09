using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class Rezervacije
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int KampId { get; set; }
        public string Od { get; set; }
        public string Do { get; set; }
        public int Cena { get; set; }

        public virtual Kampi Kamp { get; set; }
        public virtual Users User { get; set; }
    }
}
