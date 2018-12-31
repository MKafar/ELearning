using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Groups.Queries.GetGroupsList
{
    public class GetGroupsListQueryHandler : IRequestHandler<GetGroupsListQuery, GroupsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetGroupsListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<GroupsListViewModel> Handle(GetGroupsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new GroupsListViewModel
            {
                Groups = await _context.Groups
                    .Select(e => new GroupLookupModel
                    {
                        Id = e.GroupId,
                        Name = e.Name,
                        AcademicYear = e.AcademicYear,
                        SubjectId = e.SubjectId,
                        SubjectName = e.Subject.Name,
                        SubjectAbreviation = e.Subject.Abreviation
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
