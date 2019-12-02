﻿using System;
using System.Collections.Generic;
using System.Collections;

namespace AvtokampiWebAPI.Models
{
    public partial class Storitve
    {
        public Storitve()
        {
            SoritveCenikov = new HashSet<SoritveCenikov>();
            StoritveKampirnihMest = new HashSet<StoritveKampirnihMest>();
        }

        public int StoritevId { get; set; }
        public string Naziv { get; set; }
        public int KategorijaStoritve { get; set; }
        public int Cenik { get; set; }
        public BitArray Isactive { get; set; }

        public virtual Ceniki CenikNavigation { get; set; }
        public virtual KategorijeStoritev KategorijaStoritveNavigation { get; set; }
        public virtual ICollection<SoritveCenikov> SoritveCenikov { get; set; }
        public virtual ICollection<StoritveKampirnihMest> StoritveKampirnihMest { get; set; }
    }
}
