using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Subjects.Queries.GetSubjectById
{
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, SubjectViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetSubjectByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectViewModel> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Subject), request.Id);

            return new SubjectViewModel
            {
                Id = entity.SubjectId,
                Name = entity.Name,
                Abreviation = entity.Abreviation
            };
        }
    }
}
