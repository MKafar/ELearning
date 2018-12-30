using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Subjects.Queries.GetSubjectsList
{
    public class GetSubjectsListQueryHandler : IRequestHandler<GetSubjectsListQuery, SubjectsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetSubjectsListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectsListViewModel> Handle(GetSubjectsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new SubjectsListViewModel
            {
                Subjects = await _context.Subjects
                    .Select(e => new SubjectLookupModel
                    {
                        Id = e.SubjectId,
                        Name = e.Name,
                        Abreviation = e.Abreviation
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
