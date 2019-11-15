using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class SoritveCenikov
    {
        public int SoritveCenikovId { get; set; }
        public int CenikiCenikId { get; set; }
        public int StoritveStoritevId { get; set; }
        public int AvtokampiAvtokampId { get; set; }

        public virtual Avtokampi AvtokampiAvtokamp { get; set; }
        public virtual Ceniki CenikiCenik { get; set; }
        public virtual Storitve StoritveStoritev { get; set; }
    }
}
