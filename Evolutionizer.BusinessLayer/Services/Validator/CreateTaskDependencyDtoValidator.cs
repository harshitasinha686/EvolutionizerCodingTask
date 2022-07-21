using Evolutionizer.BusinessLayer.Services.Tasks.Command.CreateTaskDependency;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Validator
{
    public class CreateTaskDependencyDtoValidator : AbstractValidator<CreateTaskDependencyDto>
    {
        public CreateTaskDependencyDtoValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty");

            RuleFor(x => x.DependentIds)
            .NotEmpty()
            .WithMessage("Dependent Ids cannot be empty");
        }
    }
}
