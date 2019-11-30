using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using System;

namespace AvtokampiWebAPI.Services
{
    public class UporabnikiRepository : IUporabnikiRepository
    {
        public Uporabniki GetUporabnikByID(int id)
        {
            throw new NotImplementedException();
        }

        public Uporabniki GetUporabnikByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public bool RegisterUporabnik(Uporabniki uporabnik)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUporabnik(int uporabnik_id)
        {
            throw new NotImplementedException();
        }

        public Uporabniki UpdateUporabnik(Uporabniki uporabnik, int uporabnik_id)
        {
            throw new NotImplementedException();
        }

        public bool UporabnikExists(string username = null, int? up_id = null)
        {
            throw new NotImplementedException();
        }
    }
}
