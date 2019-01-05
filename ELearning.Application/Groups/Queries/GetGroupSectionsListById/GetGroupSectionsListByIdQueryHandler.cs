using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Groups.Queries.GetGroupSectionsListById
{
    public class GetGroupSectionsListByIdQueryHandler : IRequestHandler<GetGroupSectionsListByIdQuery, GroupSectionsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetGroupSectionsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<GroupSectionsListViewModel> Handle(GetGroupSectionsListByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Groups
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Group), request.Id);

            var vm = new GroupSectionsListViewModel
            {
                GroupSections = await _context.Sections
                    .Select(e => new GroupSectionLookupModel
                    {
                        GroupId = e.GroupId,
                        SectionId = e.SectionId,
                        SectionNumber = e.Number,
                        UserId = e.UserId,
                        UserName = $"{e.User.Name} {e.User.Surname}"
                    }).Where(e => e.GroupId == request.Id)
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
