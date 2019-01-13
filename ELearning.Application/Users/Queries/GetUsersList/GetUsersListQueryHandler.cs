using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetUsersListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<UsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var vm = new UsersListViewModel
            {
                Users = await _context.Users
                    .Select(e => new UserLookupModel
                    {
                        Id = e.UserId,
                        Name = $"{e.Name} {e.Surname}",
                        Email = e.Email,
                        Role = e.Role
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
