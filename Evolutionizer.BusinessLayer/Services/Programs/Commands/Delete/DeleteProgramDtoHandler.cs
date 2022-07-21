using AutoMapper;
using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.ExceptionHandling;
using Evolutionizer.BusinessLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Programs.Commands.Delete
{
    public class DeleteProgramDtoHandler : IRequestHandler<DeleteProgramDto, bool>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public DeleteProgramDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteProgramDto request, CancellationToken cancellationToken)
        {
            var response = false;
            var programEntity = await _repository.GetProgramById(request.Id);
            if (programEntity == null) throw new EntityNotFoundException(nameof(Program), request.Id);
            if (programEntity.Projects.Count == 0)
            {
                await _repository.DeleteProgram(programEntity);
                response = true;
            }
            return response;
        }
    }
}
