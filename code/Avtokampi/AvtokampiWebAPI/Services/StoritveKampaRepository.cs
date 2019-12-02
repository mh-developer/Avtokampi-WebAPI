using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services
{
    public class StoritveKampaRepository : IStoritveKampaRepository
    {
        public bool CreateStoritev(Storitve storitev, int kamp_id)
        {
            throw new NotImplementedException();
        }

        public Storitve GetStoritevByID(int storitev_id)
        {
            throw new NotImplementedException();
        }

        public List<Storitve> GetStoritveByKampirnoMesto(int kampirno_mesto_id)
        {
            throw new NotImplementedException();
        }

        public List<Storitve> GetStortiveByAvtokamp(int avtokamp_id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStoritev(int storitev_id)
        {
            throw new NotImplementedException();
        }

        public Storitve UpdateStoritev(Storitve storitev, int storitev_id)
        {
            throw new NotImplementedException();
        }
    }
}
