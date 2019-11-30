using AvtokampiWebAPI.Models;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services.Interfaces
{
    interface IKampirnaMestaRepository
    {
        List<KampirnaMesta> GetKampirnoMestoByAvtokamp(int avtokamp_id);

        KampirnaMesta GetKampirnoMestoByID(int kamp_mesto_id);

        bool CreateKampirnoMesto(KampirnaMesta kamp_mesto);

        KampirnaMesta UpdateKampirnoMesto(KampirnaMesta kamp_mesto);

        bool RemoveKampMesto(int kamp_mesto_id);
    }
}
