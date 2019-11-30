using AvtokampiWebAPI.Models;

namespace AvtokampiWebAPI.Services.Interfaces
{
    public interface IAuthRepository
    {
        bool IsAuthenticated(TokenModel request, out string token);

        bool IsValidUser(string username, string password);
    }
}
