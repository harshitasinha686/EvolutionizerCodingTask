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

namespace Evolutionizer.BusinessLayer.Services.Projects.Commands.Delete
{
    public class DeleteProjectDtoHandler : IRequestHandler<DeleteProjectDto, bool>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public DeleteProjectDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteProjectDto request, CancellationToken cancellationToken)
        {
            var response = false;
            var projectEntity = await _repository.GetProjectById(request.Id);
            if (projectEntity == null) throw new EntityNotFoundException(nameof(Project), request.Id);
            if (projectEntity.Tasks.Count == 0)
            {
                await _repository.DeleteProject(projectEntity);
                response = true;
            }
            return response;
        }
    }
}
