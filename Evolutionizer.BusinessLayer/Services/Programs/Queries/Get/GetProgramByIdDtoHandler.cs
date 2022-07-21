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

namespace Evolutionizer.BusinessLayer.Services.Programs.Queries.Get
{
    public class GetProgramByIdDtoHandler : IRequestHandler<GetProgramByIdDto, ProgramViewModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public GetProgramByIdDtoHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProgramViewModel> Handle(GetProgramByIdDto request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetProgramById(request.Id);
            if (entity == null) throw new EntityNotFoundException(nameof(Program), request.Id);
            var result = _mapper.Map<ProgramViewModel>(entity);
            return result;
        }
    }
}
