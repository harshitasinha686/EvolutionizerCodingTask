using AutoMapper;
using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.ExceptionHandling;
using Evolutionizer.BusinessLayer.Interfaces;
using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Programs.Commands.CalculateDuration
{
    public class CalculateProgramDurationDtoHandler : IRequestHandler<CalculateProgramDurationDto, ProgramViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CalculateProgramDurationDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProgramViewModel> Handle(CalculateProgramDurationDto request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetProgramById(request.Id);
            if (entity == null) throw new EntityNotFoundException(nameof(Program), request.Id);
            var hours = entity.Projects.Select(x => x.Duration).Sum();
            entity.Duration = hours;
            await _repository.UpdateProgram(entity);
            var result = _mapper.Map<ProgramViewModel>(entity);
            return result;
        }
    }
}
