using Evolutionizer.BusinessLayer.Services.Tasks.Command.Edit;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Validator
{
    public class UpdateStartEndDateValidator : AbstractValidator<UpdateStartEndDateDto>
    {
        public UpdateStartEndDateValidator()
        {

            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Project Id cannot be empty")
            .GreaterThanOrEqualTo(1)
            .WithMessage("Id must be greater that or equal to 1");

            RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(System.DateTime.Now.Date)
            .WithMessage("StartDate cannot be older than today's date");

            RuleFor(x => x.EndDate)
           .GreaterThanOrEqualTo(x => x.StartDate)
           .WithMessage("EndDate cannot be older than startdate.");
        }
    }
}
