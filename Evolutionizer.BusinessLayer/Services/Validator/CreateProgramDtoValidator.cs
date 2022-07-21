using Evolutionizer.BusinessLayer.Services.Programs.Commands.Create;
using FluentValidation;
using System.Linq;

namespace Evolutionizer.BusinessLayer.Services.Validator
{
    public class CreateProgramDtoValidator : AbstractValidator<CreateProgramDto>
    {
        public CreateProgramDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Program Name cannot be empty");

            RuleFor(x => x.Projects.Select(x => x.Name))
            .NotEmpty()
            .WithMessage("Project Name cannot be empty");

            RuleFor(x => x.Projects.Select(x => x.Tasks.Select(y => y.Name)))
           .NotEmpty()
           .WithMessage("Task Name cannot be empty");

            RuleFor(x => x.Projects.Select(x => x.Tasks.Select(y => y.StartDate))).NotEmpty().WithMessage("Start Date cannot be empty");
            RuleFor(x => x.Projects.Select(x => x.Tasks.Select(y => y.EndDate))).NotEmpty().WithMessage("End Date cannot be empty");


            RuleForEach(x => x.Projects).ChildRules(y => {
                y.RuleForEach(z => z.Tasks).ChildRules(a =>
                {
                    a.RuleFor(b => b.StartDate).GreaterThanOrEqualTo(System.DateTime.Now.Date)
                    .WithMessage("StartDate cannot be older than today's date");
                });
            });

            RuleForEach(x => x.Projects).ChildRules(y => {
                y.RuleForEach(z => z.Tasks).ChildRules(a =>
                {
                    a.RuleFor(b => b.EndDate).GreaterThanOrEqualTo(c => c.StartDate)
                    .WithMessage("EndDate cannot be older than startdate.");
                });
            });
        }
    }
}
