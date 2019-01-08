using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Queries.GetSectionsListById
{
    public class GetSectionsListByIdQueryHandler : IRequestHandler<GetSectionsListByIdQuery, SectionsDetailedListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetSectionsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<SectionsDetailedListViewModel> Handle(GetSectionsListByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Sections
                .Select(e => new SectionDetailedLookupModel
                {
                    UserId = e.UserId,
                    SectionId = e.SectionId,
                    SectionNumber = e.Number,
                    GroupId = e.GroupId,
                    GroupName = e.Group.Name
                }).Where(e => e.UserId == request.Id)
                .ToListAsync(cancellationToken);

            if (entity.Count == 0)
                throw new NoRecordFoundException(nameof(Section), nameof(Section.UserId), request.Id, "There are no sections associated with this user.");

            return new SectionsDetailedListViewModel
            {
                Sections = entity
            };
        }
    }
}
