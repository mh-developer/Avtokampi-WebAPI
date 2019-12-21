using AvtokampiWebAPI.Models;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services.Interfaces
{
    public interface IKampirnaMestaRepository
    {
        List<KampirnaMesta> GetKampirnoMestoByAvtokamp(int avtokamp_id);

        KampirnaMesta GetKampirnoMestoByID(int kamp_mesto_id);

        bool CreateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id);

        KampirnaMesta UpdateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id, int kamp_mesto_id);

        bool RemoveKampMesto(int kamp_id, int kamp_mesto_id);

        List<Kategorije> GetKategorijeKampirnihMest();
    }
}
