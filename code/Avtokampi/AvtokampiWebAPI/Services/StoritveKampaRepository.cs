using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvtokampiWebAPI.Services
{
    public class StoritveKampaRepository : IStoritveKampaRepository
    {
        public List<Storitve> GetStoritveByKampirnoMesto(int kampirno_mesto_id)
        {
            using (var _db = new avtokampiContext())
            {
                var storitve_kamp_mesta = _db.StoritveKampirnihMest .Where(o => o.KampirnoMesto == kampirno_mesto_id)
                                                                    .Select(o => o.Storitev)
                                                                    .ToList();
                List<Storitve> storitve = null;

                storitve_kamp_mesta.ForEach(o => {
                    storitve.Add(_db.Storitve.Find(o));
                });
                return storitve;
            }
        }

        public List<Storitve> GetStortiveByAvtokamp(int avtokamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                var storitve_kampa = _db.SoritveCenikov .Where(o => o.AvtokampiAvtokampId == avtokamp_id)
                                                        .Select(o => o.StoritveStoritevId)
                                                        .ToList();
                List<Storitve> storitve = null;

                storitve_kampa.ForEach(o => {
                    storitve.Add(_db.Storitve.Find(o));
                });
                return storitve;
            }
        }

        public Storitve GetStoritevByID(int storitev_id)
        {
            using (var _db = new avtokampiContext())
            {
                return _db.Storitve.Find(storitev_id);
            }
        }

        public bool CreateStoritev(Storitve storitev, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Storitve.Add(storitev);
                _db.SaveChanges();
                return true;
            }
        }

        public Storitve UpdateStoritev(Storitve storitev, int storitev_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Entry(storitev).State = EntityState.Modified;
                _db.SaveChanges();
                return _db.Storitve.Find(storitev_id);
            }
        }

        public bool RemoveStoritev(int storitev_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Storitve.Remove(_db.Storitve.Find(storitev_id));
                _db.SaveChanges();
                return true;
            }
        }

        public List<KategorijeStoritev> GetKategorijeStoritev()
        {
            using (var _db = new avtokampiContext())
            {
                return _db.KategorijeStoritev.ToList();
            }
        }
    }
}
