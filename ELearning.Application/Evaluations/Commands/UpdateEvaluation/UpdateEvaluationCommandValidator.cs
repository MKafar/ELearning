using FluentValidation;

namespace ELearning.Application.Evaluations.Commands.UpdateEvaluation
{
    public class UpdateEvaluationCommandValidator : AbstractValidator<UpdateEvaluationCommand>
    {
        public UpdateEvaluationCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);

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
