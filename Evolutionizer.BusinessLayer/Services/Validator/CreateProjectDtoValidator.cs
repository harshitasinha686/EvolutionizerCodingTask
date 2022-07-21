using Evolutionizer.BusinessLayer.Services.Projects.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Validator
{
    public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Project Name cannot be empty");

            RuleFor(x => x.ProgramId)
           .NotEmpty()
           .WithMessage("Program link cannot be empty");

            RuleFor(x => x.Tasks.Select(y => y.StartDate)).NotEmpty().WithMessage("Start Date cannot be empty");
            RuleFor(x => x.Tasks.Select(y => y.EndDate)).NotEmpty().WithMessage("End Date cannot be empty");

            RuleForEach(x => x.Tasks).ChildRules(y => {
                y.RuleFor(z => z.StartDate).GreaterThanOrEqualTo(System.DateTime.Now.Date)
               .WithMessage("StartDate cannot be older than today's date");
            });

            RuleForEach(x => x.Tasks).ChildRules(y => {
                y.RuleFor(z => z.EndDate).GreaterThanOrEqualTo(z => z.StartDate)
               .WithMessage("EndDate cannot be older than startdate.");
            });
        }
    }
}
