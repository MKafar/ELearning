using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Application.Interfaces;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
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

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Select(e => new User
                {
                    UserId = e.UserId,
                    Name = e.Name,
                    Surname = e.Surname,
                    Email = e.Email,
                    Login = e.Login,
                    Password = e.Password,
                    Role = e.Role,
                    Token = e.Token
                }).SingleAsync(e => e.Login == request.Login);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Login);

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(entity, entity.Password, request.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                throw new InvalidPasswordException(request.Login);

            entity = _authService.IssueToken(entity);

            return new LoginViewModel
            {
                UserId = entity.UserId,
                UserName = $"{entity.Name} {entity.Surname}",
                Email = entity.Email,
                Login = entity.Login,
                Role = entity.Role,
                Token = entity.Token
            };
        }
    }
}
