using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services
{
    public class StoritveKampaRepository : IStoritveKampaRepository
    {
        public async Task<List<Storitve>> GetStoritveByKampirnoMesto(int kampirno_mesto_id)
        {
            using (var _db = new avtokampiContext())
            {
                var storitve_kamp_mesta = await _db.StoritveKampirnihMest   .Where(o => o.KampirnoMesto == kampirno_mesto_id)
                                                                            .Select(o => o.Storitev)
                                                                            .ToListAsync();
                List<Storitve> storitve = null;

                storitve_kamp_mesta.ForEach(o => {
                    storitve.Add(_db.Storitve.Find(o));
                });
                return storitve;
            }
        }

        public async Task<List<Storitve>> GetStortiveByAvtokamp(int avtokamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                var storitve_kampa = await _db.SoritveCenikov   .Where(o => o.AvtokampiAvtokampId == avtokamp_id)
                                                                .Select(o => o.StoritveStoritevId)
                                                                .ToListAsync();
                List<Storitve> storitve = null;

                storitve_kampa.ForEach(o => {
                    storitve.Add(_db.Storitve.Find(o));
                });
                return storitve;
            }
        }

        public async Task<Storitve> GetStoritevByID(int storitev_id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Storitve.FindAsync(storitev_id);
            }
        }

        public async Task<bool> CreateStoritev(Storitve storitev, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                await _db.Storitve.AddAsync(storitev);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Storitve> UpdateStoritev(Storitve storitev, int storitev_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Entry(storitev).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return await _db.Storitve.FindAsync(storitev_id);
            }
        }

        public async Task<bool> RemoveStoritev(int storitev_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Storitve.Remove(await _db.Storitve.FindAsync(storitev_id));
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<KategorijeStoritev>> GetKategorijeStoritev()
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.KategorijeStoritev.ToListAsync();
            }
        }
    }
}
