using AvtokampiWebAPI.Models;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services.Interfaces
{
    public interface IAvtokampiRepository
    {
        List<Avtokampi> GetAll();

        Avtokampi GetAvtokampByID(int kamp_id);

        bool CreateAvtokamp(Avtokampi avtokamp);

        Avtokampi UpdateAvtokamp(Avtokampi avtokamp, int avtokamp_id);

        bool RemoveAvtokamp(int avtokamp_id);

        List<Slike> GetSlikeAvtokampa(int kamp_id);

        bool CreateSlikaAvtokampa(Slike slika, int kamp_id);

        bool CreateSlikeAvtokampa(List<Slike> slike, int kamp_id);

        Slike UpdateSlikaAvtokampa(Slike slika, int slika_id);

        List<Slike> UpdateSlikeAvtokampa(List<Slike> slike, List<int> slika_id);

        bool RemoveSlikaAvtokampa(int slika_id);

        List<Ceniki> GetCenikiAvtokampa(int kamp_id);

        Ceniki GetCenikAvtokampa(int cenik_id);

        bool CreateCenikAvtokampa(Ceniki cenik, int kamp_id);

        Ceniki UpdateCenik(Ceniki cenik, int cenik_id);

        bool RemoveCenikAvtokampa(int cenik_id);

        List<Regije> GetRegije();

        List<Drzave> GetDrzave();
    }
}
