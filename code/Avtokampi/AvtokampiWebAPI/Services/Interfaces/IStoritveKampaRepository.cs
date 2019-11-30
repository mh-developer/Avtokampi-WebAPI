using AvtokampiWebAPI.Models;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services.Interfaces
{
    interface IStoritveKampaRepository
    {
        List<Storitve> GetStoritveByKampirnoMesto(int kampirno_mesto_id);

        List<Storitve> GetStortiveByAvtokamp(int avtokamp_id);

        Storitve GetStoritevByID(int storitev_id);

        bool CreateStoritev(Storitve storitev);

        Storitve UpdateStoritev(Storitve storitev);

        bool RemoveStoritev(int storitev_id);
    }
}
