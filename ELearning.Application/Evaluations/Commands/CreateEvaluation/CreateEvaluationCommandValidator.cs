using FluentValidation;

namespace ELearning.Application.Evaluations.Commands.CreateEvaluation
{
    public class CreateEvaluationCommandValidator : AbstractValidator<CreateEvaluationCommand>
    {
        public CreateEvaluationCommandValidator()
        {
            RuleFor(v => v.AssignmentId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.SectionId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.Grade)
                .NotEmpty()
                .InclusiveBetween(0.0, 10.0);
        }
    }
}
