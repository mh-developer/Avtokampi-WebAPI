using AvtokampiWebAPI.Models;

namespace AvtokampiWebAPI.Services.Interfaces
{
    interface IUporabnikiRepository
    {
        Uporabniki GetUporabnikByID(int id);

        Uporabniki GetUporabnikByUsername(string username);

        bool RegisterUporabnik(Uporabniki uporabnik);

        Uporabniki UpdateUporabnik(Uporabniki uporabnik, int uporabnik_id);

        bool RemoveUporabnik(int uporabnik_id);


        bool UporabnikExists(string username = null, int? up_id = null);
    }
}
