using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvtokampiWebAPI.Services
{
    public class UporabnikiRepository : IUporabnikiRepository
    {
        public Uporabniki GetUporabnikByID(int id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Uporabniki.Find(id);
            }
        }

        public Uporabniki GetUporabnikByUsername(string username)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Uporabniki.Where(o => o.Email == username).FirstOrDefault();
            }
        }

        public Uporabniki UpdateUporabnik(Uporabniki uporabnik, int uporabnik_id)
        {
            using (var _db = new avtokampiContext())
            {
                uporabnik.UpdatedAt = DateTime.Now;
                _db.Entry(uporabnik).State = EntityState.Modified;
                _db.Entry(uporabnik).Property(x => x.CreatedAt).IsModified = false;
                _db.SaveChanges();
                return _db.Uporabniki.Find(uporabnik_id);
            }
        }

        public bool RemoveUporabnik(int uporabnik_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Uporabniki.Remove(_db.Uporabniki.Find(uporabnik_id));
                _db.SaveChanges();
                return true;
            }
        }

        public List<Mnenja> GetMnenjeByUporabnik(int uporabnik_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Mnenja.Where(o => o.Uporabnik == uporabnik_id).ToList();
            }
        }

        public List<Mnenja> GetMnenjeByAvtokamp(int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Mnenja.Where(o => o.Avtokamp == kamp_id).ToList();
            }
        }

        public Mnenja GetMnenje(int mnenje_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Mnenja.Where(o => o.MnenjeId == mnenje_id).FirstOrDefault();
            }
        }

        public bool CreateMnenje(Mnenja mnenje, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Mnenja.Add(mnenje);
                _db.SaveChanges();
                return true;
            }
        }

        public Mnenja UpdateMnenje(Mnenja mnenje, int mnenje_id)
        {
            using(var _db = new avtokampiContext())
            {
                mnenje.UpdatedAt = DateTime.Now;
                _db.Entry(mnenje).State = EntityState.Modified;
                _db.Entry(mnenje).Property(x => x.CreatedAt).IsModified = false;
                _db.SaveChanges();
                return _db.Mnenja.Find(mnenje_id);
            }
        }

        public bool RemoveMnenje(int mnenje_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Mnenja.Remove(_db.Mnenja.Find(mnenje_id));
                _db.SaveChanges();
                return true;
            }
        }

        public bool UporabnikExists(string username = null, int? up_id = null)
        {
            using (var _db = new avtokampiContext())
            {
                if (!string.IsNullOrWhiteSpace(username))
                {
                    return _db.Uporabniki.Where(o => o.Email == username).Any();
                }

                return up_id != null ? _db.Uporabniki.Where(o => o.UporabnikId == up_id).Any() : false;
            }
        }
    }
}
