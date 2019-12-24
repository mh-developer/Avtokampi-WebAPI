using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services
{
    public class KampirnaMestaRepository : IKampirnaMestaRepository
    {
        public async Task<List<KampirnaMesta>> GetKampirnoMestoByAvtokamp(int avtokamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.KampirnaMesta.Where(o => o.Avtokamp == avtokamp_id).ToListAsync();
            }
        }

        public async Task<KampirnaMesta> GetKampirnoMestoByID(int kamp_mesto_id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.KampirnaMesta.Where(o => o.KampirnoMestoId == kamp_mesto_id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> CreateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                kamp_mesto.CreatedAt = kamp_mesto.UpdatedAt = DateTime.Now;
                await _db.AddAsync(kamp_mesto);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<KampirnaMesta> UpdateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id, int kamp_mesto_id)
        {
            using (var _db = new avtokampiContext())
            {
                kamp_mesto.UpdatedAt = DateTime.Now;
                _db.Entry(kamp_mesto).State = EntityState.Modified;
                _db.Entry(kamp_mesto).Property(x => x.CreatedAt).IsModified = false;
                await _db.SaveChangesAsync();
                return await _db.KampirnaMesta.FindAsync(kamp_mesto_id);
            }
        }

        public async Task<bool> RemoveKampMesto(int kamp_id, int kamp_mesto_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.KampirnaMesta.Remove(await _db.KampirnaMesta.Where(o => o.Avtokamp == kamp_id && o.KampirnoMestoId == kamp_mesto_id).FirstOrDefaultAsync());
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Kategorije>> GetKategorijeKampirnihMest()
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Kategorije.ToListAsync();
            }
        }
    }
}
