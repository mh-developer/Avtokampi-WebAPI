using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services
{
    public class AvtokampiRepository : IAvtokampiRepository
    {
        public bool CreateAvtokamp(Avtokampi avtokamp)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateCenikAvtokampa(Ceniki cenik, int kamp_id)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateSlikaAvtokampa(Slike slika, int kamp_id)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateSlikeAvtokampa(List<Slike> slike, int kamp_id)
        {
            throw new System.NotImplementedException();
        }

        public List<Avtokampi> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Avtokampi GetAvtokampByID(int kamp_id)
        {
            throw new System.NotImplementedException();
        }

        public Ceniki GetCenikAvtokampa(int cenik_id)
        {
            throw new System.NotImplementedException();
        }

        public List<Ceniki> GetCenikiAvtokampa(int kamp_id)
        {
            throw new System.NotImplementedException();
        }

        public List<Drzave> GetDrzave()
        {
            throw new System.NotImplementedException();
        }

        public List<Regije> GetRegije()
        {
            throw new System.NotImplementedException();
        }

        public List<Slike> GetSlikeAvtokampa(int kamp_id)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveAvtokamp(int avtokamp_id)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveCenikAvtokampa(int cenik_id)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveSlikaAvtokampa(int slika_id)
        {
            throw new System.NotImplementedException();
        }

        public Avtokampi UpdateAvtokamp(Avtokampi avtokamp, int avtokamp_id)
        {
            throw new System.NotImplementedException();
        }

        public Ceniki UpdateCenik(Ceniki cenik, int cenik_id)
        {
            throw new System.NotImplementedException();
        }

        public Slike UpdateSlikaAvtokampa(Slike slika, int slika_id)
        {
            throw new System.NotImplementedException();
        }

        public List<Slike> UpdateSlikeAvtokampa(List<Slike> slike, List<int> slika_id)
        {
            throw new System.NotImplementedException();
        }
    }
}
