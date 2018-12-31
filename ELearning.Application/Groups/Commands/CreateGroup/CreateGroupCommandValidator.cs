using FluentValidation;
using System;

namespace ELearning.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(30);

            RuleFor(v => v.AcademicYear)
                .LessThanOrEqualTo(DateTime.Now.Year);

            RuleFor(v => v.SubjectId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
