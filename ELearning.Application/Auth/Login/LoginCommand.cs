using ELearning.Domain.Entities;
using MediatR;

namespace ELearning.Application.Auth.Login
{
    public class LoginCommand : IRequest<LoginViewModel>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
