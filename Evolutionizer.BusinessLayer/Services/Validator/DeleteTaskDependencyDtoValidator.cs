using Evolutionizer.BusinessLayer.Services.Tasks.Command.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Validator
{
    public class DeleteTaskDependencyDtoValidator : AbstractValidator<DeleteTaskDependencyDto>
    {
        public DeleteTaskDependencyDtoValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty");
        }
    }
}
