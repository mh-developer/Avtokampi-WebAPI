using AvtokampiWebAPI.Models;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services.Interfaces
{
    interface IAvtokampiRepository
    {
        List<Avtokampi> GetAll();

        Avtokampi GetAvtokampByID(int kamp_id);

        bool CreateAvtokamp(Avtokampi avtokamp);

        Avtokampi UpdateAvtokamp(Avtokampi avtokamp, int avtokamp_id);

        bool RemoveAvtokamp(int avtokamp_id);
    }
}
