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

namespace Evolutionizer.BusinessLayer.Services.Programs.Commands.Edit
{
    public class UpdateProgramDtoHandler : IRequestHandler<UpdateProgramDto, ProgramViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UpdateProgramDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProgramViewModel> Handle(UpdateProgramDto request, CancellationToken cancellationToken)
        {
            var programEntity = await _repository.GetProgramById(request.Id);
            if (programEntity == null) throw new EntityNotFoundException(nameof(Program), request.Id);
            programEntity.UpdateProgram(request.Name, request.Description);
            await _repository.UpdateProgram(programEntity);
            var result = _mapper.Map<ProgramViewModel>(programEntity);
            return result;
        }
    }
}
