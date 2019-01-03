﻿using FluentValidation;

namespace ELearning.Application.Assignments.Commands.UpdateAssignment
{
    public class UpdateAssignmentCommandValidator : AbstractValidator<UpdateAssignmentCommand>
    {
        public UpdateAssignmentCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.SectionId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.VariantId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.Date)
                .NotEmpty()
                .Matches(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)\d{2})$")
                .WithMessage("Date format should be DD/MM/YYYY, DD-MM-YYYY or DD.MM.YYYY");

        }
    }
}