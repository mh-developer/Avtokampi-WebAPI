using AvtokampiWebAPI.Models;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services.Interfaces
{
    interface IRezervacijeRepository
    {
        List<Rezervacije> GetRezervacijeByUporabnik(int uporabnik_id);

        Rezervacije GetRezervacijaByID(int rez_id);

        bool CreateRezervacija(Rezervacije rez);

        Rezervacije UpdateRezervacija(Rezervacije rez);

        bool RemoveRezervacija(int rez_id);
    }
}
