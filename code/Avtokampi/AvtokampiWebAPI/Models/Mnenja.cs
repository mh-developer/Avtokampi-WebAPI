using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class Mnenja
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int KampId { get; set; }
        public string Mnenje { get; set; }

        public virtual Kampi Kamp { get; set; }
        public virtual Users User { get; set; }
    }
}
