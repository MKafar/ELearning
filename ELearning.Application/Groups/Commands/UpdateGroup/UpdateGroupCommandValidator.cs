using FluentValidation;
using System;

namespace ELearning.Application.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
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
