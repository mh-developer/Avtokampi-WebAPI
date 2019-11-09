using AvtokampiWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Interfaces
{
    public interface IAuthRepository
    {
        bool IsAuthenticated(TokenModel request, out string token);
    }
}
