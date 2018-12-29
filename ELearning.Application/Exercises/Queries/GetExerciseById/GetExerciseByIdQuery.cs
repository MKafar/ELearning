using MediatR;

namespace ELearning.Application.Exercises.Queries.GetExerciseById
{
    public class GetExerciseByIdQuery : IRequest<ExerciseViewModel>
    {
        public int Id { get; set; }
    }
}
