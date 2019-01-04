using MediatR;

namespace ELearning.Application.Exercises.Queries.GetExerciseVariantsListById
{
    public class GetExerciseVariantsListByIdQuery : IRequest<VariantsListViewModel>
    {
        public int Id { get; set; }
    }
}
