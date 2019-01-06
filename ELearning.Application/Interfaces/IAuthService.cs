using ELearning.Common;

namespace ELearning.Application.Interfaces
{
    public interface IAuthService
    {
        AuthData GetAuthData(string id, string role);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}
