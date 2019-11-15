using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class StoritveKampirnihMest
    {
        public int StoritveKampirnihMestId { get; set; }
        public int KampirnoMesto { get; set; }
        public int Storitev { get; set; }

        public virtual KampirnaMesta KampirnoMestoNavigation { get; set; }
        public virtual Storitve StoritevNavigation { get; set; }
    }
}
