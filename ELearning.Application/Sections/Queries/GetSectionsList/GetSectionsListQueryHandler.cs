using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Sections.Queries.GetSectionsList
{
    public class GetSectionsListQueryHandler : IRequestHandler<GetSectionsListQuery, SectionsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetSectionsListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<SectionsListViewModel> Handle(GetSectionsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new SectionsListViewModel
            {
                Sections = await _context.Sections
                    .Select(e => new SectionLookupModel
                    {
                        Id = e.SectionId,
                        GroupId = e.GroupId,
                        GroupName = e.Group.Name,
                        UserId = e.UserId,
                        UserName = $"{e.User.Name} {e.User.Surname}",
                        Number = e.Number
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
