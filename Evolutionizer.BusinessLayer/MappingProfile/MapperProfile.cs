using AutoMapper;
using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Create;
using Evolutionizer.BusinessLayer.Services.Projects.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.MappingProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Program, ProgramViewModel>();
            //CreateMap<CreateProgramDto, Program>();

            CreateMap<Project, ProjectViewModel>();
            //CreateMap<CreateProjectDto, Project>();

            CreateMap<Entities.Task, TaskViewModel>()
            .ForMember(q => q.ChildTask, option => option.MapFrom(q => q.ChildTaskDependency.Select(x => x.ChildTask)));
        }
    }
}
