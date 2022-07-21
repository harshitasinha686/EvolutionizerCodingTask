using AutoMapper;
using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.Interfaces;
using Evolutionizer.BusinessLayer.Services.CommonDto;
using Evolutionizer.BusinessLayer.Services.CommonViewModel;
using Evolutionizer.BusinessLayer.Services.Programs.Commands;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.CalculateDuration;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Create;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Delete;
using Evolutionizer.BusinessLayer.Services.Programs.Commands.Edit;
using Evolutionizer.BusinessLayer.Services.Programs.Queries.Get;
using Evolutionizer.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace EvolutionizerCodingTask.Test.UnitTest
{
    public class ProgramUnitTest : IDisposable
    {
        private EvolutionizerCodingTaskDbContext _dbContext;
        private Mock<IRepository> _mockRepo;
        private Mock<IMapper> _mockMapper;
        // Handlers
        private CreateProgramDtoHandler _createProgramDtoHandler;
        private UpdateProgramDtoHandler _updateProgramDtoHandler;
        private DeleteProgramDtoHandler _deleteProgramDtoHandler;
        private GetProgramByIdDtoHandler _getProgramByIdDtoHandler;
        private GetAllProgramDtoHandler _getAllProgramDtoHandler;
        private CalculateProgramDurationDtoHandler _calculateProgramDurationDtoHandler;

        private CreateProgramDto _createProgramDto;
        private UpdateProgramDto _updateProgramdto;
        private DeleteProgramDto _deleteProgramDto;
        private GetProgramByIdDto _getProgramByIdDto;
        private ProgramViewModel _programViewModel;
        private bool SucessResponse = true;

       

        public ProgramUnitTest()
        {
            SetUpDataBase();
            InitializeMock();
            InitializeRequest();
            InitializeHandlers();
        }
        private void SetUpDataBase()
        {
            var dbContextOptions = new DbContextOptionsBuilder<EvolutionizerCodingTaskDbContext>().UseInMemoryDatabase("TestDB");
            _dbContext = new EvolutionizerCodingTaskDbContext(dbContextOptions.Options);
            _dbContext.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }

        private void InitializeMock()
        {
            _mockRepo = new Mock<IRepository>();
            _mockMapper = new Mock<IMapper>();
        }
        private void InitializeRequest()
        {
            _createProgramDto = new CreateProgramDto()
            {
                Name = "ProgramFromUnitTest",
                Description = "DescriptionFromUnitTest",
                Projects = new List<ProjectDto>()
            };
            _updateProgramdto = new UpdateProgramDto()
            {
                Id = 1,
                Name = "ProgramFromUnitTest-Updated",
                Description = "DescriptionFromUnitTest-Updated"
            };
            _deleteProgramDto = new DeleteProgramDto(1);
            _getProgramByIdDto = new GetProgramByIdDto
            {
                Id = 1
            };
            _programViewModel = new ProgramViewModel
            {
                Id = 1,
                Name = _createProgramDto.Name,
                Description = _createProgramDto.Description
            };
        }

        private void InitializeHandlers()
        {
            _createProgramDtoHandler = new CreateProgramDtoHandler(_mockRepo.Object, _mockMapper.Object);
            _updateProgramDtoHandler = new UpdateProgramDtoHandler(_mockRepo.Object, _mockMapper.Object);
            _deleteProgramDtoHandler = new DeleteProgramDtoHandler(_mockRepo.Object, _mockMapper.Object);
            _getProgramByIdDtoHandler= new GetProgramByIdDtoHandler(_mockRepo.Object, _mockMapper.Object);
            _getAllProgramDtoHandler = new GetAllProgramDtoHandler(_mockRepo.Object, _mockMapper.Object);
            _calculateProgramDurationDtoHandler = new CalculateProgramDurationDtoHandler(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void AddProgram_MustCreateProgram()
        {
            _mockRepo.Setup(x => x.AddProgram(It.IsAny<Program>())).Returns((Program x) =>System.Threading.Tasks.Task.FromResult(x));
            _mockMapper.Setup(m => m.Map<ProgramViewModel>(It.IsAny<Program>())).Returns(_programViewModel);
            var createdEntity = _createProgramDtoHandler.Handle(_createProgramDto, CancellationToken.None);
            _mockRepo.Verify(x => x.AddProgram(It.IsAny<Program>()), Times.Once);
            _mockMapper.Verify(m => m.Map<ProgramViewModel>(It.IsAny<Program>()), Times.Once);
            Assert.Equal(_programViewModel.Id, createdEntity.Result.Id);
        }

        //[Fact]
        //public void UpdateProgram_MustUpdateTheProgram()
        //{
        //    var createdEntity = _createProgramDtoHandler.Handle(_createProgramDto, CancellationToken.None);
        //    _mockRepo.Setup(x => x.GetProgramById(It.Is<int>(x=>x == _updateProgramdto.Id))).Returns((Program x) => System.Threading.Tasks.Task.FromResult(x));
        //    _mockRepo.Setup(x => x.UpdateProgram(It.IsAny<Program>())).Returns(System.Threading.Tasks.Task.FromResult(true));
        //    _mockMapper.Setup(m => m.Map<ProgramViewModel>(It.IsAny<Program>())).Returns(_programViewModel);
        //    var editedEntity = _updateProgramDtoHandler.Handle(_updateProgramdto, CancellationToken.None);
        //    _mockRepo.Verify(x => x.GetProgramById(It.Is<int>(x=>x == _updateProgramdto.Id)), Times.Once);
        //    _mockRepo.Verify(x => x.UpdateProgram(It.IsAny<Program>()));
        //    _mockMapper.Verify(m => m.Map<ProgramViewModel>(It.IsAny<Program>()), Times.Once);
        //    Assert.Equal(_updateProgramdto.Id, editedEntity.Result.Id);
        //    Assert.Equal(_updateProgramdto.Name, editedEntity.Result.Name);
        //    Assert.Equal(_updateProgramdto.Description, editedEntity.Result.Description);

        //}
        //[Fact]
        //public void DeleteProgram_MustDeleteTheProgram()
        //{
        //    var createdEntity = _createProgramDtoHandler.Handle(_createProgramDto, CancellationToken.None);
        //    _mockRepo.Setup(x => x.GetProgramById(It.Is<int>(x => x == _deleteProgramDto.Id))).Returns((Program x) => System.Threading.Tasks.Task.FromResult(x));
        //    _mockRepo.Setup(x => x.DeleteProgram(It.IsAny<Program>())).Returns(System.Threading.Tasks.Task.FromResult(true));
        //    var response = _deleteProgramDtoHandler.Handle(_deleteProgramDto, CancellationToken.None);
        //    _mockRepo.Verify(x => x.GetProgramById(It.Is<int>(x => x == _deleteProgramDto.Id)), Times.Once);
        //    _mockRepo.Verify(x => x.DeleteProgram(It.IsAny<Program>()), Times.Once);
        //    Assert.True(response.Result);
        //}

        [Fact]
        public void GetProgramById_MustGetProgram()
        {
            var createdEntity = _createProgramDtoHandler.Handle(_createProgramDto, CancellationToken.None);
            _mockRepo.Setup(x => x.GetProgramById(It.Is<int>(x => x == _getProgramByIdDto.Id))).Returns((Program x) => System.Threading.Tasks.Task.FromResult(x));
            _mockMapper.Setup(m => m.Map<ProgramViewModel>(It.IsAny<Program>())).Returns(_programViewModel);
            var response = _getProgramByIdDtoHandler.Handle(_getProgramByIdDto, CancellationToken.None);
            _mockRepo.Verify(x => x.GetProgramById(It.Is<int>(x => x == _getProgramByIdDto.Id)), Times.Once);
            _mockMapper.Verify(m => m.Map<ProgramViewModel>(It.IsAny<Program>()), Times.Once);
            Assert.Equal(_getProgramByIdDto.Id,  response.Id);
      
        }

    }
}
