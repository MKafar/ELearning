using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly ELearningDbContext _context;
        private readonly Random _random;

        public CreateUserCommandHandler(ELearningDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var loginData = CreateLogin(request.Name, request.Surname);

            var entity = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Login = loginData,
                Password = loginData,
                Role = Role.Student
            };

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public string CreateLogin(string name, string surname)
        {
            return name.Substring(0, 3) + surname.Substring(0, 3) + _random.Next(100, 1000);
        }
    }
}
