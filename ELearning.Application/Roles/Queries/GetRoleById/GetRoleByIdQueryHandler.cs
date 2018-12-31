using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetRoleByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<RoleViewModel> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Role), request.Id);

            return new RoleViewModel
            {
                Id = entity.RoleId,
                Name = entity.Name
            };
        }
    }
}
