using AvtokampiWebAPI.Models;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Services.Interfaces
{
    interface IUporabnikiRepository
    {
        Uporabniki GetUporabnikByID(int id);

        Uporabniki GetUporabnikByUsername(string username);

        Uporabniki UpdateUporabnik(Uporabniki uporabnik, int uporabnik_id);

        bool RemoveUporabnik(int uporabnik_id);

        List<Mnenja> GetMnenjeByUporabnik(int uporabnik_id);

        Mnenja GetMnenje(int mnenje_id);

        bool CreateMnenje(Mnenja mnenje);

        Mnenja UpdateMnenje(Mnenja mnenje, int mnenje_id);

        bool RemoveMnenje(int mnenje_id);

        bool UporabnikExists(string username = null, int? up_id = null);
    }
}
