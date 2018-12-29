using MediatR;

namespace ELearning.Application.Exercises.Commands.DeleteExercise
{
    public class DeleteExerciseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
