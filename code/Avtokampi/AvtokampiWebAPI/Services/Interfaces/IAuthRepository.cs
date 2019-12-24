using AvtokampiWebAPI.Models;
using System;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Interfaces
{
    public interface IAuthRepository
    {
        Task<Tuple<bool, string>> IsAuthenticated(TokenModel request);

        Task<bool> IsValidUser(string username, string password);

        Task<bool> IsRegister(RegisterModel user);
    }
}
