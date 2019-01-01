using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Groups.Queries.GetGroupById
{
    public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery, GroupViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetGroupByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<GroupViewModel> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Groups
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Group), request.Id);

            return new GroupViewModel
            {
                Id = entity.GroupId,
                Name = entity.Name,
                AcademicYear = entity.AcademicYear,
                SubjectId = entity.SubjectId,
                SubjectName = entity.Subject.Name,
                SubjectAbreviation = entity.Subject.Abreviation
            };
        }
    }
}
