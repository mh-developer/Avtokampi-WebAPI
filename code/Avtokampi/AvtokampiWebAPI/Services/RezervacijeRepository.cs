using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services
{
    public class RezervacijeRepository : IRezervacijeRepository
    {
        public async Task<List<Rezervacije>> GetRezervacijeByUporabnik(int uporabnik_id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Rezervacije.Where(o => o.Uporabnik == uporabnik_id).ToListAsync();
            }
        }

        public async Task<Rezervacije> GetRezervacijaByID(int rez_id)
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.Rezervacije.Where(o => o.RezervacijaId == rez_id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> CreateRezervacija(Rezervacije rez)
        {
            using (var _db = new avtokampiContext())
            {
                rez.CreatedAt = rez.UpdatedAt = DateTime.Now;
                await _db.Rezervacije.AddAsync(rez);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Rezervacije> UpdateRezervacija(Rezervacije rez, int rez_id)
        {
            using (var _db = new avtokampiContext())
            {
                rez.UpdatedAt = DateTime.Now;
                _db.Entry(rez).State = EntityState.Modified;
                _db.Entry(rez).Property(x => x.CreatedAt).IsModified = false;
                await _db.SaveChangesAsync();
                return await _db.Rezervacije.FindAsync(rez_id);
            }
        }

        public async Task<bool> RemoveRezervacija(int rez_id)
        {
            using (var _db = new avtokampiContext())
            {
                _db.Rezervacije.Remove(await _db.Rezervacije.FindAsync(rez_id));
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<VrstaKampiranja>> GetVrstaKmapiranja()
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.VrstaKampiranja.ToListAsync();
            }
        }

        public async Task<List<StatusRezervacije>> GetStatusRezervacije()
        {
            using (var _db = new avtokampiContext())
            {
                return await _db.StatusRezervacije.ToListAsync();
            }
        }
    }
}
