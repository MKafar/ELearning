using ELearning.Common;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ELearning.Application.Interfaces
{
    public interface IAuthService
    {
        AuthData GetAuthData(string id, string role);
    }
}
