using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Roles.Queries.GetRolesList
{
    public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, RolesListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetRolesListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<RolesListViewModel> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var vm = new RolesListViewModel
            {
                Roles = await _context.Roles
                    .Select(e => new RoleLookupModel
                    {
                        Id = e.RoleId,
                        Name = e.Name
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
