using ELearning.Common;
using MediatR;

namespace ELearning.Application.Auth.Login
{
    public class LoginCommand : IRequest<AuthData>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
