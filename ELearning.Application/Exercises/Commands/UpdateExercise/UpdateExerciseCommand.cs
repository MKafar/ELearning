using MediatR;

namespace ELearning.Application.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
