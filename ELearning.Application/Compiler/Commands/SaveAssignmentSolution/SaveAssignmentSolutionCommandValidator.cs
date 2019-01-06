using FluentValidation;

namespace ELearning.Application.Compiler.Commands.SaveAssignmentSolution
{
    public class SaveAssignmentSolutionCommandValidator : AbstractValidator<SaveAssignmentSolutionCommand>
    {
        public SaveAssignmentSolutionCommandValidator()
        {
            RuleFor(v => v.AssignmentId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.Solution)
                .NotEmpty();
        }
    }
}
