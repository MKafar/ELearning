using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Assignments.Queries.GetAssignmentEvaluationsListById
{
    public class GetAssignmentEvaluationsListByIdQueryHandler : IRequestHandler<GetAssignmentEvaluationsListByIdQuery, AssignmentEvaluationsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetAssignmentEvaluationsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentEvaluationsListViewModel> Handle(GetAssignmentEvaluationsListByIdQuery request, CancellationToken cancellationToken)
        {
            var vm = new AssignmentEvaluationsListViewModel
            {
                AssignmentEvaluations = await _context.Evaluations
                    .Select(e => new AssignmentEvaluationLookupModel
                    {
                        AssignmentBeingEvaluatedId = e.AssignmentId,
                        SectionWhichEvaluatesId = e.SectionId,
                        StudentsName = $"{e.EvaluatorAssignment.Section.User.Name} {e.EvaluatorAssignment.Section.User.Surname}",
                        EvaluationId = e.EvaluationId,
                        Grade = e.Grade
                    }).Where(e => e.AssignmentBeingEvaluatedId == request.Id)
                    .ToListAsync(cancellationToken)
            };

            if (vm == null)
                throw new NotFoundException(nameof(Evaluation), request.Id);

            return vm;
        }
    }
}
