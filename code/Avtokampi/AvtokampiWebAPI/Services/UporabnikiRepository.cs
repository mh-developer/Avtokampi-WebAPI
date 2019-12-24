using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services
{
    public class UporabnikiRepository : IUporabnikiRepository
    {
        public async Task<Uporabniki> GetUporabnikByID(int id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Uporabniki.FindAsync(id);
            }
        }

        public async Task<Uporabniki> GetUporabnikByUsername(string username)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Uporabniki.Where(o => o.Email == username).FirstOrDefaultAsync();
            }
        }

        public async Task<Uporabniki> UpdateUporabnik(Uporabniki uporabnik, int uporabnik_id)
        {
            using (var _db = new avtokampiContext())
            {
                uporabnik.UpdatedAt = DateTime.Now;
                _db.Entry(uporabnik).State = EntityState.Modified;
                _db.Entry(uporabnik).Property(x => x.CreatedAt).IsModified = false;
                await _db.SaveChangesAsync();
                return await _db.Uporabniki.FindAsync(uporabnik_id);
            }
        }

        public async Task<bool> RemoveUporabnik(int uporabnik_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Uporabniki.Remove(await _db.Uporabniki.FindAsync(uporabnik_id));
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Mnenja>> GetMnenjeByUporabnik(int uporabnik_id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Mnenja.Where(o => o.Uporabnik == uporabnik_id).ToListAsync();
            }
        }

        public async Task<List<Mnenja>> GetMnenjeByAvtokamp(int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Mnenja.Where(o => o.Avtokamp == kamp_id).ToListAsync();
            }
        }

        public async Task<Mnenja> GetMnenje(int mnenje_id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Mnenja.Where(o => o.MnenjeId == mnenje_id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> CreateMnenje(Mnenja mnenje, int kamp_id)
        {
            using (var _db = new avtokampiContext())
            {
                await _db.Mnenja.AddAsync(mnenje);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Mnenja> UpdateMnenje(Mnenja mnenje, int mnenje_id)
        {
            using(var _db = new avtokampiContext())
            {
                mnenje.UpdatedAt = DateTime.Now;
                _db.Entry(mnenje).State = EntityState.Modified;
                _db.Entry(mnenje).Property(x => x.CreatedAt).IsModified = false;
                await _db.SaveChangesAsync();
                return await _db.Mnenja.FindAsync(mnenje_id);
            }
        }

        public async Task<bool> RemoveMnenje(int mnenje_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Mnenja.Remove(await _db.Mnenja.FindAsync(mnenje_id));
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UporabnikExists(string username = null, int? up_id = null)
        {
            using (var _db = new avtokampiContext())
            {
                if (!string.IsNullOrWhiteSpace(username))
                {
                    return await _db.Uporabniki.Where(o => o.Email == username).AnyAsync();
                }

                return up_id != null ? await _db.Uporabniki.Where(o => o.UporabnikId == up_id).AnyAsync() : false;
            }
        }
    }
}
