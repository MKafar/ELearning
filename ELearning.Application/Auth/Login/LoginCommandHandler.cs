using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Application.Interfaces;
using ELearning.Common;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthData>
    {
        private readonly ELearningDbContext _context;
        private readonly IAuthService _authService;

        public LoginCommandHandler(ELearningDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<AuthData> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .SingleAsync(e => e.Login == request.Login);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Login);

            var passwordIsValid = _authService.VerifyPassword(request.Password, entity.Password);

            if (!passwordIsValid)
                throw new InvalidPasswordException(request.Login);

            return _authService.GetAuthData(entity.Login, entity.Role.Name);
        }
    }
}
