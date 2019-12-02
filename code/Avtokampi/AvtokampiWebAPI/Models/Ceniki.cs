﻿using System;
using System.Collections.Generic;
using System.Collections;

namespace AvtokampiWebAPI.Models
{
    public partial class Ceniki
    {
        public Ceniki()
        {
            SoritveCenikov = new HashSet<SoritveCenikov>();
            Storitve = new HashSet<Storitve>();
        }

        public int CenikId { get; set; }
        public string Naziv { get; set; }
        public decimal? Cena { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Avtokamp { get; set; }
        public BitArray Isactive { get; set; }

        public virtual Avtokampi AvtokampNavigation { get; set; }
        public virtual ICollection<SoritveCenikov> SoritveCenikov { get; set; }
        public virtual ICollection<Storitve> Storitve { get; set; }
    }
}
