using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvtokampiWebAPI.Services
{
    public class RezervacijeRepository : IRezervacijeRepository
    {
        public List<Rezervacije> GetRezervacijeByUporabnik(int uporabnik_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Rezervacije.Where(o => o.Uporabnik == uporabnik_id).ToList();
            }
        }

        public Rezervacije GetRezervacijaByID(int rez_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Rezervacije.Where(o => o.RezervacijaId == rez_id).FirstOrDefault();
            }
        }

        public bool CreateRezervacija(Rezervacije rez)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Rezervacije.Add(rez);
                _db.SaveChanges();
                return true;
            }
        }

        public Rezervacije UpdateRezervacija(Rezervacije rez, int rez_id)
        {
            return null;
        }

        public bool RemoveRezervacija(int rez_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Rezervacije.Remove(_db.Rezervacije.Find(rez_id));
                _db.SaveChanges();
                return true;
            }
        }

        public List<VrstaKampiranja> GetVrstaKmapiranja()
        {
            using (var _db = new avtokampiContext())
            {
                return _db.VrstaKampiranja.ToList();
            }
        }

        public List<StatusRezervacije> GetStatusRezervacije()
        {
            using (var _db = new avtokampiContext())
            {
                return _db.StatusRezervacije.ToList();
            }
        }
    }
}
