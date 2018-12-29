using MediatR;

namespace ELearning.Application.Exercises.Commands.CreateExercise
{
    public class CreateExerciseCommand : IRequest
    {
        public string Title { get; set; }
    }
}
