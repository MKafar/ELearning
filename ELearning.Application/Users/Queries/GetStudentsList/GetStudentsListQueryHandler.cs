using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Queries.GetStudentsList
{
    public class GetStudentsListQueryHandler : IRequestHandler<GetStudentsListQuery, StudentsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetStudentsListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<StudentsListViewModel> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new StudentsListViewModel
            {
                Students = await _context.Users
                    .Select(e => new StudentLookupModel
                    {
                        Id = e.UserId,
                        Name = $"{e.Name} {e.Surname}",
                        Email = e.Email,
                        RoleId = e.RoleId
                    }).Where(e => e.RoleId == 1)
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
