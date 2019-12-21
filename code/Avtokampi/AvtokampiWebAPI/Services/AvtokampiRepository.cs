using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AvtokampiWebAPI.Services
{
    public class AvtokampiRepository : IAvtokampiRepository
    {
        public List<Avtokampi> GetAll()
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Avtokampi.ToList();
            }
        }

        public Avtokampi GetAvtokampByID(int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Avtokampi.Where(o => o.AvtokampId == kamp_id).FirstOrDefault();
            }
        }

        public bool CreateAvtokamp(Avtokampi avtokamp)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Avtokampi.Add(avtokamp);
                _db.SaveChanges();
                return true;
            }
        }

        public Avtokampi UpdateAvtokamp(Avtokampi avtokamp, int avtokamp_id)
        {
            return null;
        }

        public bool RemoveAvtokamp(int avtokamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Avtokampi.Remove(_db.Avtokampi.Find(avtokamp_id));
                _db.SaveChanges();
                return true;
            }
        }

        public List<Slike> GetSlikeAvtokampa(int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Slike.Where(o => o.Avtokamp == kamp_id).ToList();
            }
        }

        public bool CreateSlikaAvtokampa(Slike slika, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Slike.Add(slika);
                _db.SaveChanges();
                return true;
            }
        }

        public bool CreateSlikeAvtokampa(List<Slike> slike, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Slike.AddRange(slike);
                _db.SaveChanges();
                return true;
            }
        }

        public Slike UpdateSlikaAvtokampa(Slike slika, int slika_id)
        {
            return null;
        }

        public List<Slike> UpdateSlikeAvtokampa(List<Slike> slike, List<int> slika_id)
        {
            return null;
        }

        public bool RemoveSlikaAvtokampa(int slika_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Slike.Remove(_db.Slike.Find(slika_id));
                _db.SaveChanges();
                return true;
            }
        }

        public List<Ceniki> GetCenikiAvtokampa(int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Ceniki.Where(o => o.Avtokamp == kamp_id).ToList();
            }
        }

        public Ceniki GetCenikAvtokampa(int cenik_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Ceniki.Find(cenik_id);
            }
        }

        public bool CreateCenikAvtokampa(Ceniki cenik, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Ceniki.Add(cenik);
                _db.SaveChanges();
                return true;
            }
        }

        public Ceniki UpdateCenik(Ceniki cenik, int cenik_id)
        {
            return null;
        }

        public bool RemoveCenikAvtokampa(int cenik_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Ceniki.Remove(_db.Ceniki.Find(cenik_id));
                _db.SaveChanges();
                return true;
            }
        }

        public List<Regije> GetRegije()
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Regije.ToList();
            }
        }

        public List<Drzave> GetDrzave()
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Drzave.ToList();
            }
        }
    }
}
