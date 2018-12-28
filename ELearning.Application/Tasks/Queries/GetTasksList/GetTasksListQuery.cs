using MediatR;

namespace ELearning.Application.Tasks.Queries.GetTasksList
{
    public class GetTasksListQuery : IRequest<TasksListViewModel>
    {
    }
}
