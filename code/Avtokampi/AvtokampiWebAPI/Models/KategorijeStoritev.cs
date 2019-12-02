using System;
using System.Collections.Generic;
using System.Collections;

namespace AvtokampiWebAPI.Models
{
    public partial class KategorijeStoritev
    {
        public KategorijeStoritev()
        {
            Storitve = new HashSet<Storitve>();
        }

        public int KategorijaStoritveId { get; set; }
        public string Naziv { get; set; }
        public BitArray Isactive { get; set; }

        public virtual ICollection<Storitve> Storitve { get; set; }
    }
}
