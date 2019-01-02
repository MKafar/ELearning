using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;

namespace ELearning.Application.Evaluations.Queries.GetEvaluationById
{
    public class GetEvaluationByIdQueryHandler : IRequestHandler<GetEvaluationByIdQuery, EvaluationViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetEvaluationByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluationViewModel> Handle(GetEvaluationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Evaluations
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Evaluation), request.Id);

            return new EvaluationViewModel
            {
                Id = entity.EvaluationId,
                AssignmentId = entity.AssignmentId,
                SectionId = entity.SectionId,
                Grade = entity.Grade
            };
        }
    }
}
