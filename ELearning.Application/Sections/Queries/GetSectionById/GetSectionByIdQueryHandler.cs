using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Sections.Queries.GetSectionById
{
    public class GetSectionByIdQueryHandler : IRequestHandler<GetSectionByIdQuery, SectionViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetSectionByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<SectionViewModel> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Sections
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Section), request.Id);

            return new SectionViewModel
            {
                Id = entity.SectionId,
                GroupId = entity.GroupId,
                GroupName = entity.Group.Name,
                UserId = entity.UserId,
                UserName = $"{entity.User.Name} {entity.User.Surname}",
                Number = entity.Number
            };
        }
    }
}
