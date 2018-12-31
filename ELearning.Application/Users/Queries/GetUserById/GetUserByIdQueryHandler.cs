using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetUserByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Id);

            return new UserViewModel
            {
                Id = entity.UserId,
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                RoleId = entity.RoleId,
                RoleName = entity.Role.Name
            };
        }
    }
}
