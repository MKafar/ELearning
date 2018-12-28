using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELearning.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Application.Tasks.Queries.GetTasksList
{
    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, TasksListViewModel>
    {
        private readonly ELearningDbContext _context;

        public GetTasksListQueryHandler(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task<TasksListViewModel> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            var vm = new TasksListViewModel
            {
                Tasks = await _context.Tasks.Select(c => 
                    new TaskLookupModel
                    {
                        Id = c.TaskId.ToString(),
                        Title = c.Title,
                        Description = c.Description
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
