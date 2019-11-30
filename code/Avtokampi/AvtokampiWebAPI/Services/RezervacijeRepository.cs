using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services
{
    public class RezervacijeRepository : IRezervacijeRepository
    {
        public bool CreateRezervacija(Rezervacije rez)
        {
            throw new NotImplementedException();
        }

        public Rezervacije GetRezervacijaByID(int rez_id)
        {
            throw new NotImplementedException();
        }

        public List<Rezervacije> GetRezervacijeByUporabnik(int uporabnik_id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRezervacija(int rez_id)
        {
            throw new NotImplementedException();
        }

        public Rezervacije UpdateRezervacija(Rezervacije rez)
        {
            throw new NotImplementedException();
        }
    }
}
