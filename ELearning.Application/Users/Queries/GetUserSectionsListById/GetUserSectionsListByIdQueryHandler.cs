using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Users.Queries.GetUserSectionsListById
{
    public class GetUserSectionsListByIdQueryHandler : IRequestHandler<GetUserSectionsListByIdQuery, UserSectionsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetUserSectionsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<UserSectionsListViewModel> Handle(GetUserSectionsListByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Sections
                .Select(e => new UserSectionsLookupModel
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

            return new UserSectionsListViewModel
            {
                Sections = entity
            };
        }
    }
}
