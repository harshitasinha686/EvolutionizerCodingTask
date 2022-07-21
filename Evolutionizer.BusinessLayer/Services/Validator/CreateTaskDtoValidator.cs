using Evolutionizer.BusinessLayer.Services.Tasks.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Validator
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty()
           .WithMessage("Name cannot be empty");

            RuleFor(x => x.ProjectId)
           .NotEmpty()
           .WithMessage("ProgramId cannot be empty");

            RuleFor(x => x.StartDate)
           .NotEmpty()
           .WithMessage("StartDate cannot be empty");

            RuleFor(x => x.EndDate)
           .NotEmpty()
           .WithMessage("EndDate cannot be empty");

            RuleFor(x => x.StartDate)
           .GreaterThanOrEqualTo(System.DateTime.Now.Date)
           .WithMessage("StartDate cannot be older than today's date");

            RuleFor(x => x.EndDate)
           .GreaterThanOrEqualTo(x => x.StartDate)
           .WithMessage("EndDate cannot be older than startdate.");
        }
    }
}
