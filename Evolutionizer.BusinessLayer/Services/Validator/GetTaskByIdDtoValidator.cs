﻿using Evolutionizer.BusinessLayer.Services.Tasks.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Validator
{
    public class GetTaskByIdDtoValidator : AbstractValidator<GetTaskByIdDto>
    {
        public GetTaskByIdDtoValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty()
           .WithMessage("Program Id cannot be empty")
           .GreaterThanOrEqualTo(1)
           .WithMessage("Id must be greater that or equal to 1");
        }
    }
}
