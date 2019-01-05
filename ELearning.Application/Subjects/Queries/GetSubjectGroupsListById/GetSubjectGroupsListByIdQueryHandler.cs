using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Application.Exceptions;
using ELearning.Domain.Entities;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Subjects.Queries.GetSubjectGroupsListById
{
    public class GetSubjectGroupsListByIdQueryHandler : IRequestHandler<GetSubjectGroupsListByIdQuery, SubjectGroupsListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetSubjectGroupsListByIdQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectGroupsListViewModel> Handle(GetSubjectGroupsListByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Subjects
                .FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Subject), request.Id);

            var vm = new SubjectGroupsListViewModel
            {
                SubjectGroups = await _context.Groups
                    .Select(e => new SubjectGroupLookupModel
                    {
                        SubjectId = e.SubjectId,
                        GroupId = e.GroupId,
                        GroupName = e.Name
                    }).Where(e => e.SubjectId == request.Id)
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
