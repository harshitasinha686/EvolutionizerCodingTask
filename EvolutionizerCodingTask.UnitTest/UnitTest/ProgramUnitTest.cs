using AutoMapper;
using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.Interfaces;
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
using System.Threading;
using Xunit;
using Task = System.Threading;
namespace EvolutionizerCodingTask.UnitTest.UnitTest
{
    public class ProgramUnitTest : IDisposable
    {
        private EvolutionizerCodingTaskDbContext _dbContext;
        private Mock<IRepository> _mockRepo;
        private Mock<IMapper> _mockMapper;

        private CreateProgramDtoHandler _createProgramDtoHandler;
        private UpdateProgramDtoHandler _updateProgramDtoHandler;
        private DeleteProgramDtoHandler _deleteProgramDtoHandler;
        private GetProgramByIdDtoHandler _getProgramByIdDtoHandler;
        private GetAllProgramDtoHandler _getAllProgramDtoHandler;
        private CalculateProgramDurationDtoHandler _calculateProgramDurationDtoHandler;
        private CreateProgramDto _createProgramDto;
        private Program _programEntity;
        private ProgramViewModel _programViewModel;

       

        public ProgramUnitTest()
        {
            SetUpDataBase();
            InitializeMock();
            InitializeRequest();
            InitializeHandlers();
        }
        public void SetUpDataBase()
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
                Description = "DescriptionFromUnitTest"
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
            _deleteProgramDtoHandler = new DeleteProgramDtoHandler(_mockRepo.Object, _mockMapper.Object);
            _getProgramByIdDtoHandler= new GetProgramByIdDtoHandler(_mockRepo.Object, _mockMapper.Object);
            _getAllProgramDtoHandler = new GetAllProgramDtoHandler(_mockRepo.Object, _mockMapper.Object);
            _calculateProgramDurationDtoHandler = new CalculateProgramDurationDtoHandler(_mockRepo.Object, _mockMapper.Object);
    }

        [Fact]
        public void CreateProgram()
        {
            _mockRepo.Setup(x => x.AddProgram(It.IsAny<Program>())).Returns((Program x) =>System.Threading.Tasks.Task.FromResult(x));
            _mockMapper.Setup(m => m.Map<ProgramViewModel>(It.IsAny<Program>())).Returns(_programViewModel);
            var createdEntity = _createProgramDtoHandler.Handle(_createProgramDto, CancellationToken.None);
            _mockRepo.Verify(x => x.AddProgram(It.IsAny<Program>()), Times.Once);
            _mockMapper.Verify(m => m.Map<ProgramViewModel>(It.IsAny<Program>()), Times.Once);
            Assert.Equal(_programViewModel.Id, createdEntity.Result.Id);
        }


    }
}
