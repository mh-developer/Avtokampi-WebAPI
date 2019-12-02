using System;
using System.Collections.Generic;
using System.Collections;

namespace AvtokampiWebAPI.Models
{
    public partial class StoritveKampirnihMest
    {
        public int StoritveKampirnihMestId { get; set; }
        public int KampirnoMesto { get; set; }
        public int Storitev { get; set; }
        public BitArray Isactive { get; set; }

        public virtual KampirnaMesta KampirnoMestoNavigation { get; set; }
        public virtual Storitve StoritevNavigation { get; set; }
    }
}
