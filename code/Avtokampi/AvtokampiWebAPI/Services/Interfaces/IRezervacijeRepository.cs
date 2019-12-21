using AvtokampiWebAPI.Models;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services.Interfaces
{
    public interface IRezervacijeRepository
    {
        List<Rezervacije> GetRezervacijeByUporabnik(int uporabnik_id);

        Rezervacije GetRezervacijaByID(int rez_id);

        bool CreateRezervacija(Rezervacije rez);

        Rezervacije UpdateRezervacija(Rezervacije rez, int rez_id);

        bool RemoveRezervacija(int rez_id);

        List<VrstaKampiranja> GetVrstaKmapiranja();

        List<StatusRezervacije> GetStatusRezervacije();
    }
}
