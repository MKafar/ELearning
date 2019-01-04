using MediatR;

namespace ELearning.Application.Exercises.Queries.GetExerciseVariantsListById
{
    public class GetExerciseVariantsListByIdQuery : IRequest<ExerciseVariantsListViewModel>
    {
        public int Id { get; set; }
    }
}
