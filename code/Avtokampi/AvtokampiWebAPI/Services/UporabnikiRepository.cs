using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services
{
    public class UporabnikiRepository : IUporabnikiRepository
    {
        public bool CreateMnenje(Mnenja mnenje)
        {
            throw new NotImplementedException();
        }

        public Mnenja GetMnenje(int mnenje_id)
        {
            throw new NotImplementedException();
        }

        public List<Mnenja> GetMnenjeByUporabnik(int uporabnik_id)
        {
            throw new NotImplementedException();
        }

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

        public bool RemoveMnenje(int mnenje_id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUporabnik(int uporabnik_id)
        {
            throw new NotImplementedException();
        }

        public Mnenja UpdateMnenje(Mnenja mnenje, int mnenje_id)
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
