using AutoMapper;
using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.Interfaces;
using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Create;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task = Evolutionizer.BusinessLayer.Entities.Task;

namespace Evolutionizer.BusinessLayer.Services.Programs.Commands
{
    public class CreateProgramDtoHandler : IRequestHandler<CreateProgramDto, ProgramViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CreateProgramDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProgramViewModel> Handle(CreateProgramDto request, CancellationToken cancellationToken)
        {
            try
            {
                var programEntity = new Program { Name = request.Name, Description = request.Description };
                if (request.Projects != null && request.Projects.Count > 0)
                {
                    var projectEntityList = new List<Project>();
                    foreach (var item in request.Projects)
                    {
                        var projectEntity = new Project(programEntity, item.Name, item.Description);
                        //var projectEntity = new Project { Name = item.Name, Description = item.Description };
                        if (item.Tasks != null && item.Tasks.Count > 0)
                        {
                            var taskEntityList = new List<Task>();
                            foreach (var x in item.Tasks)
                            {
                                var taskEntity = new Task(projectEntity, x.Name, x.Description, x.StartDate, x.EndDate);
                                taskEntityList.Add(taskEntity);
                            }
                            projectEntity.Tasks = taskEntityList;

                        }
                        projectEntityList.Add(projectEntity);
                    }
                    programEntity.Projects = projectEntityList;
                }

                await _repository.AddProgram(programEntity);
                var viewResult = _mapper.Map<ProgramViewModel>(programEntity);
                return viewResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
