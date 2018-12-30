using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly ELearningDbContext _context;

        public UpdateUserCommandHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .SingleOrDefaultAsync(e => e.UserId == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Id);

            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Email = request.Email;
            entity.Login = request.Login;
            entity.Password = request.Password;
            entity.RoleId = request.RoleId;

            _context.Users.Update(entity);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
