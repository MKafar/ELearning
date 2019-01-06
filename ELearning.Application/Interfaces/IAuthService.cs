using ELearning.Common;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ELearning.Application.Interfaces
{
    public interface IAuthService
    {
        AuthData GetAuthData(string id, string role);
        string HashPassword(User user, string password);
        PasswordVerificationResult VerifyPassword(User user, string actualPassword, string hashedPassword);
    }
}
