using AutoMapper;
using Evolutionizer.BusinessLayer.Interfaces;
using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.Programs.Queries.Get
{
    public class GetAllProgramDtoHandler : IRequestHandler<GetAllProgramDto, List<ProgramViewModel>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProgramDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ProgramViewModel>> Handle(GetAllProgramDto request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAllPrograms();
            var result = _mapper.Map<List<ProgramViewModel>>(entity);
            return result;
        }
    }
}
