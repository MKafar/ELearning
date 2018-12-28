using System.Collections.Generic;

namespace ELearning.Application.Tasks.Queries.GetTasksList
{
    public class TasksListViewModel
    {
        public IList<TaskLookupModel> Tasks { get; set; }
    }
}