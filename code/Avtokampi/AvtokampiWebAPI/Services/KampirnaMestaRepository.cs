using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvtokampiWebAPI.Services
{
    public class KampirnaMestaRepository : IKampirnaMestaRepository
    {
        public List<KampirnaMesta> GetKampirnoMestoByAvtokamp(int avtokamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.KampirnaMesta.Where(o => o.Avtokamp == avtokamp_id).ToList();
            }
        }

        public KampirnaMesta GetKampirnoMestoByID(int kamp_mesto_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.KampirnaMesta.Where(o => o.KampirnoMestoId == kamp_mesto_id).FirstOrDefault();
            }
        }

        public bool CreateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                kamp_mesto.CreatedAt = kamp_mesto.UpdatedAt = DateTime.Now;
                _db.Add(kamp_mesto);
                _db.SaveChanges();
                return true;
            }
        }

        public KampirnaMesta UpdateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id, int kamp_mesto_id)
        {
            using (var _db = new avtokampiContext())
            {
                kamp_mesto.UpdatedAt = DateTime.Now;
                _db.Entry(kamp_mesto).State = EntityState.Modified;
                _db.Entry(kamp_mesto).Property(x => x.CreatedAt).IsModified = false;
                _db.SaveChanges();
                return _db.KampirnaMesta.Find(kamp_mesto_id);
            }
        }

        public bool RemoveKampMesto(int kamp_id, int kamp_mesto_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.KampirnaMesta.Remove(_db.KampirnaMesta.Where(o => o.Avtokamp == kamp_id && o.KampirnoMestoId == kamp_mesto_id).FirstOrDefault());
                _db.SaveChanges();
                return true;
            }
        }

        public List<Kategorije> GetKategorijeKampirnihMest()
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Kategorije.ToList();
            }
        }
    }
}
