using FluentValidation;

namespace ELearning.Application.Evaluations.Commands.DeleteEvaluation
{
    public class DeleteEvaluationCommandValidator : AbstractValidator<DeleteEvaluationCommand>
    {
        public DeleteEvaluationCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
