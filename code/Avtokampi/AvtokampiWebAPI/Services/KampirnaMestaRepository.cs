using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services
{
    public class KampirnaMestaRepository : IKampirnaMestaRepository
    {
        public bool CreateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id)
        {
            throw new NotImplementedException();
        }

        public List<KampirnaMesta> GetKampirnoMestoByAvtokamp(int avtokamp_id)
        {
            throw new NotImplementedException();
        }

        public KampirnaMesta GetKampirnoMestoByID(int kamp_mesto_id)
        {
            throw new NotImplementedException();
        }

        public List<Kategorije> GetKategorijeKampirnihMest()
        {
            throw new NotImplementedException();
        }

        public bool RemoveKampMesto(int kamp_id, int kamp_mesto_id)
        {
            throw new NotImplementedException();
        }

        public KampirnaMesta UpdateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id, int kamp_mesto_id)
        {
            throw new NotImplementedException();
        }
    }
}
