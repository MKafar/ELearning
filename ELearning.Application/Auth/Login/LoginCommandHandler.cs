using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Application.Interfaces;
using ELearning.Common;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthData>
    {
        private readonly ELearningDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAuthService _authService;

        public LoginCommandHandler(ELearningDbContext context, IPasswordHasher<User> passwordHasher, IAuthService authService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authService = authService;
        }

        public async Task<AuthData> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .SingleAsync(e => e.Login == request.Login);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Login);

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(entity, entity.Password, request.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                throw new InvalidPasswordException(request.Login);

            entity.Role = await _context.Roles
                .FindAsync(entity.RoleId);

            var authData = _authService.GetAuthData(entity.Login, entity.Role.Name);

            return authData;
        }
    }
}
