using FluentValidation;

namespace ELearning.Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
    {
        public DeleteGroupCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
