using ELearning.Domain.Entities;

namespace ELearning.Application.Interfaces
{
    public interface IAuthService
    {
        User IssueToken(User user);
    }
}
