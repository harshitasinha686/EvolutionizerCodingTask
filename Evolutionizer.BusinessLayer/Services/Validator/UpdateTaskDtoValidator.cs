using Evolutionizer.BusinessLayer.Services.Tasks.Command.Edit;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Validator
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty()
           .WithMessage("Task Name cannot be empty");

            RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("Task Id can not be null")
            .NotEmpty()
            .WithMessage("Task Id cannot be empty")
            .GreaterThanOrEqualTo(1)
            .WithMessage("Id must be greater that or equal to 1");
        }
    }
}
